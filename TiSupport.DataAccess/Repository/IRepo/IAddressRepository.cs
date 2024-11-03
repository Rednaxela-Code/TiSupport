using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface IAddressRepository : IRepository<Address>
{
    void Update(Address obj);
}