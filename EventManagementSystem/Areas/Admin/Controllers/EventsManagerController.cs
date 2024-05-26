using EventManagementSystem.Areas.Admin.Models.Repositories;
using EventManagementSystem.Areas.Admin.ViewModel;
using EventManagementSystem.Models;
using EventManagementSystem.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        private const int MaximumTicketTypes = 10;

        public EventsManagerController(IAdminEventRepository adminEventRepository, IEventRepository eventRepository)
        {
            _adminEventRepository = adminEventRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAll();

            return View(events);
        }

        public async Task<IActionResult> Create()
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
            return RedirectToAction(nameof(Index));
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
