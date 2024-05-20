using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagementSystem.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Street { get; set; } = string.Empty;
        [StringLength(100)]
        public string Address1 { get; set; } = string.Empty;
        [StringLength(100)]
        public string Address2 { get; set; } = string.Empty;
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        [StringLength(5)]
        public string Zipcode { get; set; } = string.Empty;

        [ForeignKey("User")]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public User? User { get; set; }
    }
}