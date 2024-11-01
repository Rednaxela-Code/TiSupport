using System.ComponentModel.DataAnnotations;

namespace TiSupport.Shared.Models
{
    public class Address
    {
        [Key]
        public required int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? HomeNumber { get; set; }

        // Navigation property back to User
        public User? User { get; set; }
    }
}