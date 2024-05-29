using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; } = string.Empty;

        public DateTime Create_at { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }

        public ICollection<Event>? Events { get; set; }

        [ForeignKey("UserAddress")]
        public int? UserAddressId { get; set; }
        public UserAddress? UserAddress { get; set; }
    }
}