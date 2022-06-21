using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelpDeskProject.Data;
using HelpDeskProject.Models;

namespace HelpDeskProject.Controllers
{
    public class UserController : Controller
    {
        private readonly HelpDeskDBContext _context;

        public UserController(HelpDeskDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsersById")]
        public IActionResult GetUsersById()
        {
            return Ok(_context.Users.OrderBy(x => x.UserId).ToList());
        }
    }
}
