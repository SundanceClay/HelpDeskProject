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

        [HttpGet("GetTicketsById")]
        public IActionResult GetTicketsById()
        {
            return Ok(_context.Tickets.OrderBy(x => x.TicketId).ToList());
        }

        [HttpGet("GetTicketsByTitle")]
        public IActionResult GetTicketsByTitle()
        {
            return Ok(_context.Tickets.OrderBy(x => x.Title).ToList());
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket(string title, string contents)
        {
            Ticket ticket = new Ticket();

            if ((title == null) || (contents == null))
            {
                return BadRequest();
            }
            ticket.Title = title;
            ticket.Contents = contents;
            ticket.Closed = false;

            if (ModelState.IsValid)
            {
                _context.AddAsync(4,title,contents,0);
                await _context.SaveChangesAsync();
                return Ok();
            }
            
            return BadRequest();
            
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
