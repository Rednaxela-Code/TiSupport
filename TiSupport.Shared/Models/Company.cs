using TiSupport.Shared.Enums;

namespace TiSupport.Shared.Models;

public class Company
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public CompanyType? CompanyType { get; set; }
    public List<int>? Employees { get; set; }
}