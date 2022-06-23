using HelpDeskProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookMarkController : ControllerBase
    {
        private readonly HelpDeskDBContext _context;

        public BookMarkController(HelpDeskDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetBookMarksById")]
        public IActionResult GetBookMarksById()
        {
            return Ok(_context.BookMark.OrderBy(x => x.BookMarkId).ToList());
        }
    }
}
