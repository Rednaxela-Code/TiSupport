using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketCommentController(ILogger<TicketCommentController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<TicketCommentController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetTicketCommentById")]
    public async Task<ActionResult<TicketComment>> Get(int id)
    {
        try
        {
            var ticketComment = await unitOfWork.TicketComments.GetFirstOrDefault(t => t.Id == id);
            if (ticketComment == null) return NotFound();
            return Ok(ticketComment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetTicketComments")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var ticketComments = await unitOfWork.TicketComments.GetAll();
            return Ok(ticketComments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateTicketComment")]
    public async Task<IActionResult> Create([FromBody] TicketComment ticketComment)
    {
        try
        {
            var result = await unitOfWork.TicketComments.Add(ticketComment);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateTicketComment")]
    public async Task<IActionResult> Update([FromBody] TicketComment ticketComment)
    {
        try
        {
            unitOfWork.TicketComments.Update(ticketComment);
            await unitOfWork.Save();
            return Ok(ticketComment);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteTicketComment")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ticketComment = await unitOfWork.TicketComments.GetFirstOrDefault(t => t.Id == id);
            if (ticketComment == null) return NotFound();
            await unitOfWork.TicketComments.Remove(ticketComment);
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