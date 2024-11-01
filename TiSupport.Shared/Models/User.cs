using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiSupport.Shared.Models
{
    public class User
    {
        [Key]
        public required int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public required int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public required Address Address { get; set; }

        public string? Phone { get; set; }

        public List<Ticket>? Tickets { get; set; }
    }
}