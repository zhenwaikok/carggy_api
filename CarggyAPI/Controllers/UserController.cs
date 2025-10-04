using CarggyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarggyAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly CarggyDBContext _context;

        public UserController(CarggyDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var userList = await _context.User.ToListAsync();
            return userList;
        }

        //GET: api/User/{firebaseUserId}
        [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUserWithUserId(string UserId)
        {
            var user = await _context.User.FindAsync(UserId);

            if (user == null)
            {
                return NotFound(new { status = 404, message = "User not found" });
            }

            return user;

        }

        //POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserWithUserId", new { UserId = user.UserId }, user);
        }

        //PUT: api/User/{firebaseUserId}
        [HttpPut("{UserId}")]
        public async Task<IActionResult> PutUser(string UserId, User user)
        {

            if (UserId != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(UserId))
                {
                    return NotFound(new { status = 404, message = "User not found" });
                }
                else
                {
                    throw;
                }
            }

            return Ok(new { status = 200, message = "Account updated successfully." });
        }

        //DELETE: api/User/{firebaseUserId}
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            var user = await _context.User.FindAsync(UserId);
            if(user == null)
            {
                return NotFound(new { status = 404, message = "User not found" });
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { status = 200, message = "User deleted successfully."});
        }

        private bool UserExists(string UserId) =>
            _context.User.Any(e => e.UserId == UserId);
    }
}
