namespace TiSupport.DataAccess.Repository.IRepo;

public interface IUnitOfWork
{
    ITicketRepository Tickets { get; }
    
    ICompanyRepository Companies { get; }
    
    IContactRepository Contacts { get; }
    
    IAddressRepository Addresses { get; }

    Task Save();
}