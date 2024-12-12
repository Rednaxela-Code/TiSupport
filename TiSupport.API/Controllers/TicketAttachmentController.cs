using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketAttachmentController(ILogger<TicketAttachmentController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<TicketAttachmentController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetTicketAttachmentById")]
    [Authorize]
    public async Task<ActionResult<TicketAttachment>> Get(int id)
    {
        try
        {
            var ticketAttachment = await unitOfWork.TicketAttachments.GetFirstOrDefault(t => t.Id == id);
            if (ticketAttachment == null) return NotFound();
            return Ok(ticketAttachment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetTicketAttachments")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var ticketAttachments = await unitOfWork.TicketAttachments.GetAll();
            return Ok(ticketAttachments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateTicketAttachment")]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] TicketAttachment ticketAttachment)
    {
        try
        {
            var result = await unitOfWork.TicketAttachments.Add(ticketAttachment);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateTicketAttachment")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] TicketAttachment ticketAttachment)
    {
        try
        {
            unitOfWork.TicketAttachments.Update(ticketAttachment);
            await unitOfWork.Save();
            return Ok(ticketAttachment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteTicketAttachment")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ticketAttachment = await unitOfWork.TicketAttachments.GetFirstOrDefault(t => t.Id == id);
            if (ticketAttachment == null) return NotFound();
            await unitOfWork.TicketAttachments.Remove(ticketAttachment);
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