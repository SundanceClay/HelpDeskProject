using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskProject.Data;
using HelpDeskProject.Models;

namespace HelpDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly HelpDeskDBContext _context;

        public TicketController(HelpDeskDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllTicketsOrderedById")]
        public IActionResult GetAllTicketsOrderedById()
        {
            return Ok(_context.Tickets.OrderBy(x => x.TicketId).ToList());
        }

        [HttpGet("GetTicketById")]
        public IActionResult GetTicketById(int id)
        {
            return Ok(_context.Tickets.Where(x => x.TicketId == id).FirstOrDefault());
        }

        [HttpPost("CreateTicket")]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok();                                                                               
        }

        [HttpPost("ResolveAndCloseTicket")]
        public async Task<ActionResult<Ticket>> ResolveAndCloseTicket(int id, string resolution, string resolvedBy, bool closed)
        {
            Ticket ticket = new Ticket();
            ticket = _context.Tickets.FirstOrDefault(x => x.TicketId == id);
            ticket.Resolution = resolution;
            ticket.ResolvedBy = resolvedBy;
            ticket.Closed = closed;

            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();

            return Ok(ticket);
        }

        [HttpPost("BookMarkTicket")]
        public async Task<ActionResult<Ticket>> BookMarkTicket(int ticketId, int userId)
        {
            Ticket ticket = new Ticket();
            BookMark bookMark= new BookMark();

            ticket = _context.Tickets.FirstOrDefault(x => x.TicketId == ticketId);
            bookMark.TicketId = ticketId;
            bookMark.UserId = userId;

            _context.BookMark.Add(bookMark);
            await _context.SaveChangesAsync();

            return Ok(bookMark);
        }        
    }
}
