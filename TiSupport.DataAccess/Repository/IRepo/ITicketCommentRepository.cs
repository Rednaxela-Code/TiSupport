using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface ITicketCommentRepository : IRepository<TicketComment>
{
    void Update(TicketComment obj);
}