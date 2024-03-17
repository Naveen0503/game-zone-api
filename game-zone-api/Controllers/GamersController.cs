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
    public class GamersController : ControllerBase
    {
        private readonly BidNestContext _context;

        public GamersController(BidNestContext context)
        {
            _context = context;
        }

        // GET: api/Gamers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gamer>>> GetGamers()
        {
            return await _context.Gamers.ToListAsync();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(Login gamer)
        {
            var user = _context.Gamers.Where(u=>u.Name == gamer.Name).Include(g=>g.Scores).FirstOrDefault();
            
            if(user == null)
            {
                return BadRequest("user doesnot exist");
            }
            else if(user.Password != gamer.Password)
            {
                return BadRequest("incorrect password");
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Gamer>> PostGamer(Gamer gamer)
        {
            Gamer gamers = await _context.Gamers.Where(x=>x.Name.ToLower() == gamer.Name.ToLower()).FirstOrDefaultAsync();
            if (gamers == null)
            {
                _context.Gamers.Add(gamer);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGamer", new { id = gamer.Id }, gamer);
            }
            else {
                return Ok("username already exists");
            }
        }
    }
}
