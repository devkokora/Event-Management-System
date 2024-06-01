using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Models.ViewModels
{
    public class EventViewModel
    {
        public const int MaximumTicketTypes = 10;
        public Event Event { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Transports { get; set; }
        public List<TicketType>? TicketTypes { get; set; }
        public IFormFile? ImagePath { get; set; } = default!;

        public EventViewModel()
        {
            var categories = Enum.GetValues(typeof(Category)).Cast<Category>();
            Categories = new SelectList(categories);

            var transports = Enum.GetValues(typeof(Transport)).Cast<Transport>();
            Transports = new SelectList(transports).ToList();

            TicketTypes = [.. Enumerable.Repeat(new TicketType(), MaximumTicketTypes)];
        }
    }
}
