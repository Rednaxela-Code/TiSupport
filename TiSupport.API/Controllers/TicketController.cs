using Microsoft.AspNetCore.Mvc;
using TiSupport.DataAccess.Repository.IRepo;
using TiSupport.Shared.Models;

namespace TiSupport.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly IRepository<Ticket> _ticketRepo;

    public TicketController(ILogger<TicketController> logger, IRepository<Ticket> ticketRepo)
    {
        _logger = logger;
        _ticketRepo = ticketRepo;
    }

    [HttpGet(Name = "GetTickets")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var tickets = await _ticketRepo.GetAll();
            return Ok(tickets);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
}