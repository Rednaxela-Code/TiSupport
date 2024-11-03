namespace TiSupport.DataAccess.Repository.IRepo;

public interface IUnitOfWork
{
    ITicketRepository Tickets { get; }
    
    ICompanyRepository Companies { get; }
    
    IContactRepository Contacts { get; }
    
    IAddressRepository Addresses { get; }
    
    ITicketAttachmentRepository TicketAttachments { get; }
    
    ITicketCommentRepository TicketComments { get; }

    Task Save();
}