using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class TicketCommentRepository(AppDbContext db) : Repository<TicketComment>(db), ITicketCommentRepository
{
    private readonly AppDbContext _db = db;
    
    public void Update(TicketComment obj)
    {
        _db.TicketComments.Update(obj);
    }
}