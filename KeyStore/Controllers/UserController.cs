using KeyStore.Data;
using KeyStore.Models;
using KeyStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly KeyStoreDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository context)
        {
           _userRepository = context;
        }

        // GET: api/Users
        [HttpGet("GetAll")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllUser();
        }

        // GET: api/Users/5
        [HttpGet("GetById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetSingleUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost("Add")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _userRepository.CreateUser(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("Update")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
