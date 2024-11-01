using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiSupport.Shared.Models
{
    public class TicketContent
    {
        [Key]
        public required int Id { get; set; }
        
        public string? Content { get; set; }

        // Foreign key for Ticket
        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
    }
}