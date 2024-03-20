using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using game_zone_api.Models;

namespace game_zone_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TictactoeSessionsController : ControllerBase
    {
        private readonly BidNestContext _context;

        public TictactoeSessionsController(BidNestContext context)
        {
            _context = context;
        }

        // GET: api/TictactoeSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TictactoeSession>>> GetTictactoeSessions()
        {
            return await _context.TictactoeSessions.ToListAsync();
        }

        // GET: api/TictactoeSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TictactoeSession>> GetTictactoeSession(int id)
        {
            var tictactoeSession = await _context.TictactoeSessions.FindAsync(id);

            if (tictactoeSession == null)
            {
                return NotFound();
            }

            return tictactoeSession;
        }

        // PUT: api/TictactoeSessions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTictactoeSession(int id, TictactoeSession tictactoeSession)
        {
            if (id != tictactoeSession.SessionId)
            {
                return BadRequest();
            }

            _context.Entry(tictactoeSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TictactoeSessionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tictactoeSession);
        }

        // POST: api/TictactoeSessions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TictactoeSession>> PostTictactoeSession(TictactoeSession tictactoeSession)
        {
            _context.TictactoeSessions.Add(tictactoeSession);
            await _context.SaveChangesAsync();

            return Ok(tictactoeSession);
        }

        // DELETE: api/TictactoeSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTictactoeSession(int id)
        {
            var tictactoeSession = await _context.TictactoeSessions.FindAsync(id);
            if (tictactoeSession == null)
            {
                return NotFound();
            }

            _context.TictactoeSessions.Remove(tictactoeSession);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TictactoeSessionExists(int id)
        {
            return _context.TictactoeSessions.Any(e => e.SessionId == id);
        }
    }
}
