using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Tickets = new TicketRepository(_db);
    }

    public ITicketRepository Tickets { get; private set; }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}