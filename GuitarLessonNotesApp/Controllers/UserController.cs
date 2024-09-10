using GuitarLessonNotesApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuitarLessonNotesApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarLessonNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        //POST api/User
        public async Task<IActionResult> Post(User user)
        {
            if (string.IsNullOrEmpty(user.Role))
            {
                return BadRequest("User role is required.");
            }
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User added successfully.");
        }

        //DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User removed.");
        }

        //Adding the admin user
        [HttpPost("add-admin")]
        public async Task<IActionResult> AddAdmin(User adminUser)
        {
            adminUser.Role = "Admin";

            _context.Users.Add(adminUser);
            await _context.SaveChangesAsync();

            return Ok("Admin user created.");
        }
    }
}
