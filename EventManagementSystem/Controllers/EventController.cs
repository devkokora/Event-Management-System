using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers;

[Route("event")]
public class EventController : Controller
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public EventController(IEventRepository eventRepository, UserManager<User> userManager, IUserRepository userRepository)
    {
        _eventRepository = eventRepository;
        _userManager = userManager;
        _userRepository = userRepository;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        return Redirect("/events");
    }

    [Route("Details/{id?}")]
    public async Task<IActionResult> Details(int? id)
    {
        if (id is not null)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(id.Value);
            if (existingEvent is not null)
            {
                if (existingEvent.TicketTypes?.Count == 0)
                {
                    existingEvent.TicketTypes = [];
                    existingEvent.TicketTypes.Add(new TicketType()
                    {
                        Tickets = [],
                        Name = "Free",
                        Detail = $"Free Ticket on {existingEvent.Title}",
                        EventId = existingEvent.Id,
                        MaxCapital = int.MaxValue,
                        Price = 0
                    });
                    await _eventRepository.UpdateTicketTypeAsync(existingEvent);
                }

                ViewBag.GoogleMap = $"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3153.8354345090644!2d{existingEvent.Longitude}!3d{existingEvent.Latitude}!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad642af0f11fd81%3A0xf577b68364c12aef!2sFederation%20Square!5e0!3m2!1sen!2sau!4v1618973873610!5m2!1sen!2sau";
                return View(existingEvent);
            }
        }
        return Redirect("/events");
    }

    [Route("RegisterToEvent")]
    public async Task<IActionResult> RegisterToEvent(int ticketTypeId)
    {
        var ticketType = await _eventRepository.GetTicketTypeByIdAsync(ticketTypeId);

        if (ticketType is not null)
        {
            return View(ticketType);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("RegisterToEvent")]
    public async Task<IActionResult> RegisterToEvent(TicketType ticketType)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
                return Redirect("/Identity/Login");

            var ticket = new Ticket()
            {
                Detail = $"Ticket stamp of {ticketType.Detail}",
                TicketTypeId = ticketType.Id,
                TicketType = ticketType,
                UserId = user.Id,
                User = user
            };

            user.Tickets ??= [];
            user.Tickets.Add(ticket);
            var result = await _userRepository.UpdateUserAsync(user);
            return RedirectToAction(nameof(SuccessfulRegister), ticketType);
        }
        return Redirect
    }

    public IActionResult SuccessfulRegister(TicketType ticketType) => View(ticketType);
}
