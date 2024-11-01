using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TiSupport.Shared.Enums;

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
    public string Content { get; set; }
    public List<string>? Attachments { get; set; }

    public required int UserId { get; set; }
    public List<int>? CommentIds { get; set; }
}
