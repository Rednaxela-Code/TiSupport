using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace TiSupport.Shared.Models;

public class Ticket
{
    [Key]
    public required int Id { get; set; }
    public required string Name { get; set; }
    public TicketStatus Status { get; set; }
    public TicketPriority Priority { get; set; }
    public TicketCategory Category { get; set; }
    public DateTime Created { get; set; }

    public TicketContent? Content { get; set; }  // Navigation property to TicketContent

    public List<TicketAttachment>? Attachments { get; set; }

    public required int UserId { get; set; }
    [ForeignKey("UserId")]
    public required User User { get; set; }

    public List<TicketComment>? Comments { get; set; }
}
