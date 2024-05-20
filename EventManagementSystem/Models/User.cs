using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime Create_at { get; set; } = DateTime.Now;
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Event>? Events { get; set; }

        [ForeignKey("UserAddress")]
        public int UserAddressId { get; set; }
        public UserAddress? UserAddress { get; set; }
    }
}