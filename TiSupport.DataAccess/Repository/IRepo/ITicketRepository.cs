using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface ITicketRepository : IRepository<Ticket>
{
    void Update(Ticket obj);
}