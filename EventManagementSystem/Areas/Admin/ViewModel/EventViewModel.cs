using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Areas.Admin.ViewModel
{
    public class EventViewModel
    {
        public const int MaximumTicketTypes = 10;
        public Event Event { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Transports { get; set; }
        public List<TicketType> TicketTypes { get; set; }
        public string[] SelectedTransports { get; set; }

        public EventViewModel()
        {
            var categories = Enum.GetValues(typeof(Category)).Cast<Category>();
            Categories = new SelectList(categories);

            var transports = Enum.GetValues(typeof(Transport)).Cast<Transport>();
            Transports = new SelectList(transports).ToList();

            TicketTypes = Enumerable.Repeat(new TicketType(), MaximumTicketTypes).ToList();

            SelectedTransports = new string[Enum.GetValues(typeof(Transport)).Length];
        }
    }
}

/*using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Areas.Admin.ViewModel
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Transports { get; set; }
        public List<TicketType> TicketTypes { get; set; }

        public string[] SelectedTransports { get; set; } = new string[Enum.GetValues(typeof(Transport)).Length];

        public EventViewModel()
        {
            Event = new();
            Categories = new List<SelectListItem>();
            Transports = new();
            TicketTypes = new List<TicketType>();
            SelectedTransports = new string[Enum.GetValues(typeof(Transport)).Length];
        }

        public EventViewModel(Event newEvent,
            IEnumerable<SelectListItem> categoriesListItem,
            List<SelectListItem> transportsListItem,
            int maximumTicketTypes)
        {
            Event = newEvent;
            Categories = categoriesListItem;
            Transports = transportsListItem;
            TicketTypes = Enumerable.Repeat(new TicketType(), maximumTicketTypes).ToList();
        }
    }
}*/
