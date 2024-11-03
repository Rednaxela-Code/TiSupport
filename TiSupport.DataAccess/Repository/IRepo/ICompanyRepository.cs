using TiSupport.Shared.Models;

namespace TiSupport.DataAccess.Repository.IRepo;

public interface ICompanyRepository : IRepository<Company>
{
    void Update(Company obj);
}