using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactController(ILogger<ContactController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<ContactController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetContactById")]
    public async Task<ActionResult<Contact>> Get(int id)
    {
        try
        {
            var contact = await unitOfWork.Contacts.GetFirstOrDefault(t => t.Id == id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetContacts")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var contacts = await unitOfWork.Contacts.GetAll();
            return Ok(contacts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateContact")]
    public async Task<IActionResult> Create([FromBody] Contact contact)
    {
        try
        {
            var result = await unitOfWork.Contacts.Add(contact);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateContact")]
    public async Task<IActionResult> Update([FromBody] Contact contact)
    {
        try
        {
            unitOfWork.Contacts.Update(contact);
            await unitOfWork.Save();
            return Ok(contact);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteContact")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var contact = await unitOfWork.Contacts.GetFirstOrDefault(t => t.Id == id);
            if (contact == null) return NotFound();
            await unitOfWork.Contacts.Remove(contact);
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