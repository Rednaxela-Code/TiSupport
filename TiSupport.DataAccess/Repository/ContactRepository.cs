using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class ContactRepository(AppDbContext db) : Repository<Contact>(db), IContactRepository
{
    private readonly AppDbContext _db = db;
    
    public void Update(Contact obj)
    {
        _db.Contacts.Update(obj);
    }
}