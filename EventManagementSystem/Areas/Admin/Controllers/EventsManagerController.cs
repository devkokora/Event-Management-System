using EventManagementSystem.Areas.Admin.Models.Repositories;
using EventManagementSystem.Areas.Admin.ViewModel;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace EventManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventsManagerController : Controller
    {
        private readonly IAdminEventRepository _adminEventRepository;
        private readonly IEventRepository _eventRepository;
        private readonly UserManager<User> _userManager;
        private const int MaximumTicketTypes = 10;

        public EventsManagerController(IAdminEventRepository adminEventRepository, IEventRepository eventRepository, UserManager<User> userManager)
        {
            _adminEventRepository = adminEventRepository;
            _eventRepository = eventRepository;
            _userManager = userManager;
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
                            Image = eventViewModel.Event.Image,
                            Transports = eventViewModel.Transports
                            .Where(t => t.Value == "true")
                            .Select(st => (Transport)Enum.Parse(typeof(Transport), st.Text)).ToList(),
                            Category = eventViewModel.Event.Category,
                            TicketTypes = eventViewModel.TicketTypes?
                            .Where(tt => !string.IsNullOrEmpty(tt.Name)).ToList()
                        };

                        await _adminEventRepository.CreateAsync(newEvent);
                        return RedirectToAction(nameof(Index));
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
}
