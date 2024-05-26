using EventManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Areas.Admin.ViewModel
{
    public class EventViewModel
    {
        public Event Event { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; } = default!;
        public IEnumerable<SelectListItem> Transports { get; set; } = default!;
    }
}
