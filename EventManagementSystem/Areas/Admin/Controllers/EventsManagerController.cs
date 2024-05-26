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
            var categories = Enum.GetValues(typeof(Category)).Cast<Category>();
            IEnumerable<SelectListItem> categoriesListItem = new SelectList(categories);

            var transports = Enum.GetValues(typeof(Transport)).Cast<Transport>();
            IEnumerable<SelectListItem> transportsListItem = new SelectList(transports);

            var viewModel = new EventViewModel()
            {
                Event = new Event(),
                Categories = categoriesListItem,
                Transports = transportsListItem
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event? @event)
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
