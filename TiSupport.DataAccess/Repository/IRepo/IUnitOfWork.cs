namespace TiSupport.DataAccess.Repository.IRepo;

public interface IUnitOfWork
{
    ITicketRepository Tickets { get; }

    Task Save();
}