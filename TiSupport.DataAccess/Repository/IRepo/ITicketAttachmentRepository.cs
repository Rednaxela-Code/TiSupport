using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface ITicketAttachmentRepository : IRepository<TicketAttachment>
{
    void Update(TicketAttachment obj);
}