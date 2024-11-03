using Microsoft.EntityFrameworkCore;
using TiSupport.Shared.Models;
using System.IO;

namespace TiSupport.DataAccess.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }
    public DbSet<ContactPerson> ContactPersons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
    public DbSet<Company> Companies { get; set; }
}