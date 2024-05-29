using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Detail { get; set; } = string.Empty;

        [ForeignKey("TicketType")]
        public int TicketTypeId { get; set; }
        [Required]
        public TicketType? TicketType { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public User User { get; set; } = default!;
    }
}