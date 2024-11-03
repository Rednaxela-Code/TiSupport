using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface IContactRepository : IRepository<Contact>
{
    void Update(Contact obj);
}