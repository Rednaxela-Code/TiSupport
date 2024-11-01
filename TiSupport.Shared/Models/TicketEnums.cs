namespace TiSupport.Shared.Models;

public enum TicketCategory
{
    General = 0,
    Technical = 1,
    Maintenance = 2,
    Administration = 3,
}

public enum TicketPriority
{
    Low = 0,
    Medium = 1,
    High = 2,
    Critical = 3,
}

public enum TicketStatus
{
    New = 0,
    InProgress = 1,
    Closed = 2,
}