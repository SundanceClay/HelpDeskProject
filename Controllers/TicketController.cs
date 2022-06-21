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

        [HttpGet("GetAllTicketsOderedById")]
        public IActionResult GetAllTicketsOderedById()
        {
            return Ok(_context.Tickets.OrderBy(x => x.TicketId).ToList());
        }

        [HttpPost("CreateTicket")]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return Ok();                                                                               
        }

        [HttpPost("ResolveAndCloseTicket")]
        public async Task<ActionResult<Ticket>> ResolveAndCloseTicket(int id, string resolution, bool closed)
        {
            Ticket ticket = new Ticket();
            ticket = _context.Tickets.FirstOrDefault(x => x.TicketId == id);
            ticket.Resolution = resolution;
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
        /*
        [HttpGet("GetPetById")]
        public IActionResult GetPetById(int id)
        {
            Pet pet = DB.Pets.FirstOrDefault(x => x.PetId == id);

            if(pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpGet("GetPetByName")]
        public IActionResult GetPetByName(string name)
        {
            Pet pet = DB.Pets.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpPost("AdoptPetById")]
        public IActionResult SetPetForAdoption(int id)
        {
            Pet pet = DB.Pets.FirstOrDefault(x => x.PetId == id);

            if (pet == null)
            {
                return NotFound();
            }

            pet.IsAdopted = true;

            return Ok();
        } */
    }
}
