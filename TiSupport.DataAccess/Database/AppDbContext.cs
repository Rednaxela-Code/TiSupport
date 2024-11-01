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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Content)
            .WithOne(tc => tc.Ticket)
            .HasForeignKey<TicketContent>(tc => tc.TicketId);
        
        // Ticket and User (Many-to-One relationship)
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId);

        // Ticket and TicketComment (One-to-Many relationship)
        modelBuilder.Entity<TicketComment>()
            .HasOne(tc => tc.Ticket)
            .WithMany(t => t.Comments)
            .HasForeignKey(tc => tc.TicketId);

        // Ticket and TicketAttachment (One-to-Many relationship)
        modelBuilder.Entity<TicketAttachment>()
            .HasOne(ta => ta.Ticket)
            .WithMany(t => t.Attachments)
            .HasForeignKey(ta => ta.TicketId);

        // User and Address (One-to-One relationship)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<User>(u => u.AddressId);


        base.OnModelCreating(modelBuilder);
    }
    
}