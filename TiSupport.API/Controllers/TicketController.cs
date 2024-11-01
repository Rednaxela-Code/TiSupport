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
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}