using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController(ILogger<TicketController> logger, IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly ILogger<TicketController> _logger = logger;

    [HttpGet("{id:int}", Name = "GetTicketById")]
    [Authorize]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        try
        {
            var ticket = await unitOfWork.Tickets.GetFirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetTickets")]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value });
            var tickets = await unitOfWork.Tickets.GetAll();
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateTicket")]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Ticket ticket)
    {
        try
        {
            var result = await unitOfWork.Tickets.Add(ticket);
            await unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateTicket")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] Ticket ticket)
    {
        try
        {
            unitOfWork.Tickets.Update(ticket);
            await unitOfWork.Save();
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteTicket")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ticket = await unitOfWork.Tickets.GetFirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            await unitOfWork.Tickets.Remove(ticket);
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