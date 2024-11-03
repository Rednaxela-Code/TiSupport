using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController(ILogger<CompanyController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<CompanyController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetCompanyById")]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        try
        {
            var ticket = await unitOfWork.Companies.GetFirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetCompanies")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var companies = await unitOfWork.Companies.GetAll();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateCompany")]
    public async Task<IActionResult> Create([FromBody] Company company)
    {
        try
        {
            var result = await unitOfWork.Companies.Add(company);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateCompany")]
    public async Task<IActionResult> Update([FromBody] Company company)
    {
        try
        {
            unitOfWork.Companies.Update(company);
            await unitOfWork.Save();
            return Ok(company);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteCompany")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var company = await unitOfWork.Companies.GetFirstOrDefault(t => t.Id == id);
            if (company == null) return NotFound();
            await unitOfWork.Companies.Remove(company);
            await unitOfWork.Save();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}