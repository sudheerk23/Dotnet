using System.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    [ApiController]
    [Route("api/[controller]")] // /api/User 
    public class UsersController : ControllerBase
    {

            private readonly DataContext _context;
            public UsersController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            
            public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
            {

                var result = await _context.User.ToListAsync();
                return result;

            }

             [HttpGet("{Id}")]

             public async Task<ActionResult<AppUser>> GetUser(int id)
             {

                var result = await _context.User.FindAsync(id);
                return result;
             } 
    }

    
}