using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class TicketAttachmentRepository(AppDbContext db) : Repository<TicketAttachment>(db), ITicketAttachmentRepository
{
    private readonly AppDbContext _db = db;
    
    public void Update(TicketAttachment obj)
    {
        _db.TicketAttachments.Update(obj);
    }
}