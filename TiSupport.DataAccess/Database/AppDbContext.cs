using Microsoft.EntityFrameworkCore;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<TicketContent> TicketContents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
}