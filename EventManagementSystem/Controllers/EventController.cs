using EventManagementSystem.DataAccess.Repository;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace EventManagementSystem.Controllers;

[Route("event")]
public class EventController : Controller
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly UserManager<User> _userManager;

    public EventController(IEventRepository eventRepository, UserManager<User> userManager, IUserRepository userRepository, ITicketTypeRepository ticketTypeRepository)
    {
        _eventRepository = eventRepository;
        _userManager = userManager;
        _userRepository = userRepository;
        _ticketTypeRepository = ticketTypeRepository;
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
                await _eventRepository.UpdateVisitorCountAsync(existingEvent.Id);                

                ViewBag.GoogleMap = $"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3153.8354345090644!2d{existingEvent.Longitude}!3d{existingEvent.Latitude}!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad642af0f11fd81%3A0xf577b68364c12aef!2sFederation%20Square!5e0!3m2!1sen!2sau!4v1618973873610!5m2!1sen!2sau";

                return View(existingEvent);
            }
        }
        return Redirect("/events");
    }

    [Route("ConfirmTicket")]
    public async Task<IActionResult> ConfirmTicket(int ticketTypeId)
    {
        var ticketType = await _eventRepository.GetTicketTypeByIdAsync(ticketTypeId);

        if (ticketType is not null)
        {
            if (ticketType.TotalTicketsSold < ticketType.MaxCapital)
            {
                return View(ticketType);
            }
        }

        var backUrl = TempData["Referer"]?.ToString();
        if (!string.IsNullOrEmpty(backUrl))
        {
            return Redirect(backUrl);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("ConfirmTicket")]
    public async Task<IActionResult> ConfirmTicket(TicketType ticketType)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            var existingTicketType = await _eventRepository.GetTicketTypeByIdAsync(ticketType.Id);

            if (user is null || existingTicketType is null || existingTicketType.Event is null)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (existingTicketType.TotalTicketsSold < existingTicketType.MaxCapital)
            {
                existingTicketType.TotalTicketsSold++;
                var ticket = new Ticket()
                {
                    Detail = $"Ticket detail - Ticket No.{existingTicketType.TotalTicketsSold} name: {existingTicketType.Detail} At {existingTicketType.Event.VenueName}, {existingTicketType.Event.Country} - {existingTicketType.Event.Address} in {existingTicketType.Event.StartDate}.",
                    TicketTypeId = existingTicketType.Id,
                    UserId = user.Id,
                    User = user
                };

                user.Tickets ??= [];
                user.Tickets.Add(ticket);
                await _userRepository.UpdateUserAsync(user);
                await _ticketTypeRepository.UpdateTicketTypeAsync(existingTicketType);

                var tickketJson = JsonConvert.SerializeObject(ticket, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                TempData["TicketSuccess"] = tickketJson;

                return RedirectToAction(nameof(SuccessfulRegister));
            }
        }

        var backUrl = TempData["Referer"]?.ToString();
        if (!string.IsNullOrEmpty(backUrl))
        {
            return Redirect(backUrl);
        }

        return RedirectToAction(nameof(Index));
    }

    [Route("SuccessfulRegister")]
    public IActionResult SuccessfulRegister()
    {
        var ticketJson = TempData["TicketSuccess"] as string;
        if (!string.IsNullOrEmpty(ticketJson))
        {
            var ticket = JsonConvert.DeserializeObject<Ticket>(ticketJson);
            return View(ticket);
        }

        return RedirectToAction(nameof(Index));
    }
}
