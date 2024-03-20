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
    public class KeyController : ControllerBase
    {
        private readonly KeyStoreDbContext _context;
        private readonly IKeyRepository _keyRepository;
        public KeyController(IKeyRepository context)
        {
            _keyRepository = context;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Key>> GetKeys()
        {
            return await _keyRepository.GetAllKeys();
        }
        [HttpGet("GetById")]
        public async Task<ActionResult<Key>> GetKey(int id)
        {
            var key = await _keyRepository.GetSingleKey(id);
            if(key == null)
            {
                return NotFound();
            }
            return Ok(key);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Key>> PostKey(Key key)
        {
            _keyRepository.CreateKey(key);
            return CreatedAtAction("GetKey", new { id = key.Id }, key);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> PutKey(int id, Key key)
        {
            if (id != key.Id)
            {
                return BadRequest();
            }

            await _keyRepository.UpdateKey(key);

            return NoContent();
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteKey(int id)
        {
            _keyRepository.DeleteKey(id);
            return NoContent();
        }
    }
}
