using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string Detail { get; set; } = string.Empty;

        [ForeignKey("TicketType")]
        public int TicketTypeId { get; set; }
        [Required]
        public int TicketType { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; } = default!;
    }
}