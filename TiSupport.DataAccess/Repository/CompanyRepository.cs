using TiSupport.DataAccess.Database;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository;

public class CompanyRepository(AppDbContext db) : Repository<Company>(db), ICompanyRepository
{
    private readonly AppDbContext _db = db;

    public void Update(Company obj)
    {
        _db.Companies.Update(obj);
    }
}