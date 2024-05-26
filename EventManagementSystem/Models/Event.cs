using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace EventManagementSystem.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(150)]
        public string ShortDescription { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("User")]
        public string? UserId{ get; set; }
        [Required]
        public User User { get; set; } = default!;

        public DateTime Create_at { get; set; } = DateTime.Now;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(100)]
        public string VenueName { get; set; } = string.Empty;
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        [StringLength(60)]
        public string Country { get; set; } = string.Empty;
        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<Transport>? Transports { get; set; }

        [Required]
        public Category Category { get; set; }
        public ICollection<TicketType>? TicketTypes { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
