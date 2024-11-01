using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiSupport.Shared.Models;

public class TicketAttachment
{
    [Key]
    public required int Id { get; set; }
    public byte[]? Content { get; set; }
    
    public required int TicketId { get; set; }
    [ForeignKey("TicketId")]
    public required Ticket Ticket { get; set; }
}