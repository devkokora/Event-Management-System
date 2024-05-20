using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Comment { get; set; } = string.Empty;
        public ushort Star { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}