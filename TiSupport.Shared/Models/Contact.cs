using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiSupport.Shared.Models
{
    public class Contact
    {
        [Key]
        public required int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? AddressId { get; set; }

        public string? Phone { get; set; }

        public List<int>? TicketIds { get; set; }
        public List<int>? CompanyIds { get; set; }
    }
}