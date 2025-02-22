using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult<Company>> Get(int id)
    {
        try
        {
            var company = await unitOfWork.Companies.GetFirstOrDefault(t => t.Id == id);
            if (company == null) return NotFound();
            return Ok(company);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetCompanies")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var companies = await unitOfWork.Companies.GetAll();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateCompany")]
    [Authorize]
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
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateCompany")]
    [Authorize]
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
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteCompany")]
    [Authorize]
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
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}