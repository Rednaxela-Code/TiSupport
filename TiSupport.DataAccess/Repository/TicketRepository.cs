using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class TicketRepository(AppDbContext db) : Repository<Ticket>(db), ITicketRepository
{
    private readonly AppDbContext _db = db;

    public void Update(Ticket obj)
    {
        _db.Tickets.Update(obj);
    }
}