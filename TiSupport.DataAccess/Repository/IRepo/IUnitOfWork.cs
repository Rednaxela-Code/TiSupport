namespace TiSupport.DataAccess.Repository.IRepo;

public interface IUnitOfWork
{
    ITicketRepository Tickets { get; }
    
    ICompanyRepository Companies { get; }

    Task Save();
}