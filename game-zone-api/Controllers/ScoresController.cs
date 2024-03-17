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
    public class ScoresController : ControllerBase
    {
        private readonly BidNestContext _context;

        public ScoresController(BidNestContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
        {
            return await _context.Scores.ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<List<Score?>> GetScore(int id)
        {
            var score = await _context.Scores.Where(x=>x.GamerId == id).ToListAsync();

            if (score == null)
            {
                return score;
            }

            return score;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            var existingScore = _context.Scores.FirstOrDefault(s => s.GamerId == score.GamerId && s.Game == score.Game);

            if (existingScore != null)
            {
                existingScore.GameScore = score.GameScore;
                _context.Scores.Update(existingScore);
            }
            else
            {
                _context.Scores.Add(score);
            }

            await _context.SaveChangesAsync();

            return Ok(score);
        }


        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            var score = await _context.Scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _context.Scores.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreExists(int id)
        {
            return _context.Scores.Any(e => e.Id == id);
        }
    }
}
