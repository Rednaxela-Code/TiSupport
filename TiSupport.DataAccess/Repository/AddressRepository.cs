using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class AddressRepository(AppDbContext db) : Repository<Address>(db), IAddressRepository
{
    private readonly AppDbContext _db = db;
    
    public void Update(Address obj)
    {
        _db.Addresses.Update(obj);
    }
}