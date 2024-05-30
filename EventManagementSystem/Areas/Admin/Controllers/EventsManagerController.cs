using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CloudinaryDotNet.Actions;
using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.Models;
using EventManagementSystem.Models.ViewModels;

namespace EventManagementSystem.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class EventsManagerController : Controller
{
    private readonly IAdminEventRepository _adminEventRepository;
    private readonly IEventRepository _eventRepository;
    private readonly UserManager<User> _userManager;
    private readonly Cloudinary _cloudinary;
    private const int MaximumTicketTypes = 10;

    public EventsManagerController(IAdminEventRepository adminEventRepository, IEventRepository eventRepository, UserManager<User> userManager, Cloudinary cloudinary, IWebHostEnvironment webHostEnvironment)
    {
        _adminEventRepository = adminEventRepository;
        _eventRepository = eventRepository;
        _userManager = userManager;
        _cloudinary = cloudinary;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Event> events = await _eventRepository.GetAllAsync();

        return View(events);
    }

    public IActionResult Create()
    {
        var viewModel = new EventViewModel()
        {
            Event = new Event(),
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventViewModel eventViewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, nameof(UserRoles.Admin));
                if (isAdmin)
                {
                    var uploadResult = new ImageUploadResult();

                    using (var stream = eventViewModel.ImagePath.OpenReadStream())
                    {
                        uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams()
                        {
                            File = new FileDescription(eventViewModel.ImagePath.FileName, stream),
                            PublicId = $"EventManager/{eventViewModel.Event.Category}/{Guid.NewGuid()}"
                        });
                    }

                    if (uploadResult != null)
                    {
                        var ticketTypes = eventViewModel.TicketTypes?
                            .Where(tt => !string.IsNullOrEmpty(tt.Name)).ToList();

                        if (ticketTypes?.Count == 0)
                        {
                            ticketTypes = [];
                            ticketTypes.Add(new TicketType()
                            {
                                Tickets = [],
                                Name = "Free",
                                Detail = $"Free Ticket on {eventViewModel.Event.Title}",
                                EventId = eventViewModel.Event.Id,
                                MaxCapital = int.MaxValue,
                                Price = 0
                            });
                        }

                        var newEvent = new Event()
                        {
                            Title = eventViewModel.Event.Title,
                            ShortDescription = eventViewModel.Event.ShortDescription,
                            Description = eventViewModel.Event.Description,
                            UserId = user.Id,
                            User = user,
                            Create_at = DateTime.Now,
                            StartDate = eventViewModel.Event.StartDate,
                            EndDate = eventViewModel.Event.EndDate,
                            VenueName = eventViewModel.Event.VenueName,
                            Latitude = eventViewModel.Event.Latitude,
                            Longitude = eventViewModel.Event.Longitude,
                            Country = eventViewModel.Event.Country,
                            Address = eventViewModel.Event.Address,
                            Image = uploadResult.Url.ToString(),
                            Transports = eventViewModel.Transports
                            .Where(t => t.Value == "true")
                            .Select(st => (Transport)Enum.Parse(typeof(Transport), st.Text)).ToList(),
                            Category = eventViewModel.Event.Category,
                            TicketTypes = ticketTypes
                        };

                        await _adminEventRepository.CreateAsync(newEvent);
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
        }
        return View(eventViewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Event? _event)
    {
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        return RedirectToAction(nameof(Index));
    }
}
