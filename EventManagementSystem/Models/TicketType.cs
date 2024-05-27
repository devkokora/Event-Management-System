using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class TicketType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; } = string.Empty;
        [StringLength(400)]
        public string? Detail { get; set; }
        public float Price { get; set; } = default;
        public int? MaxCapital { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; } = default!;
    }
}