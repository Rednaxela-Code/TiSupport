using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public TicketController(ILogger<TicketController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet("{id:int}", Name = "GetTicketById")]
    public async Task<ActionResult<Ticket>> Get(int id)
    {
        try
        {
            var ticket = await _unitOfWork.Tickets.GetFirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet(Name = "GetTickets")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var tickets = await _unitOfWork.Tickets.GetAll();
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost(Name = "CreateTicket")]
    public async Task<IActionResult> Create([FromBody] Ticket ticket)
    {
        try
        {
            var result = await _unitOfWork.Tickets.Add(ticket);
            await _unitOfWork.Save();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut(Name = "UpdateTicket")]
    public async Task<IActionResult> Update([FromBody] Ticket ticket)
    {
        try
        {
            _unitOfWork.Tickets.Update(ticket);
            await _unitOfWork.Save();
            return Ok(ticket);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}", Name = "DeleteTicket")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ticket = await _unitOfWork.Tickets.GetFirstOrDefault(t => t.Id == id);
            if (ticket == null) return NotFound();
            await _unitOfWork.Tickets.Remove(ticket);
            await _unitOfWork.Save();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}