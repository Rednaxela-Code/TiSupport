using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController(ILogger<AddressController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<AddressController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetAddressById")]
    [Authorize]
    public async Task<ActionResult<Address>> Get(int id)
    {
        try
        {
            var address = await unitOfWork.Addresses.GetFirstOrDefault(t => t.Id == id);
            if (address == null) return NotFound();
            return Ok(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetAddresses")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var address = await unitOfWork.Addresses.GetAll();
            return Ok(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateAddress")]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Address address)
    {
        try
        {
            var result = await unitOfWork.Addresses.Add(address);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateAddress")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] Address address)
    {
        try
        {
            unitOfWork.Addresses.Update(address);
            await unitOfWork.Save();
            return Ok(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteAddress")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var address = await unitOfWork.Addresses.GetFirstOrDefault(t => t.Id == id);
            if (address == null) return NotFound();
            await unitOfWork.Addresses.Remove(address);
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