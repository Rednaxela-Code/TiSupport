using System.ComponentModel.DataAnnotations;

namespace TiSupport.Shared.Models;

public class TicketContent
{
    [Key]
    public required int Id { get; set; }
    public string? Content { get; set; }
}