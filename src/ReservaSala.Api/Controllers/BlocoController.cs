using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaSala.Api.Data;
using ReservaSala.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaSala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlocoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlocoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bloco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bloco>>> GetBloco()
        {
            return await _context.Bloco.ToListAsync();
        }

        // GET: api/Bloco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bloco>> GetBloco(int id)
        {
            var bloco = await _context.Bloco.FindAsync(id);

            if (bloco == null)
            {
                return NotFound();
            }

            return bloco;
        }

        // PUT: api/Bloco/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloco(int id, Bloco bloco)
        {
            if (id != bloco.BlocoId)
            {
                return BadRequest();
            }

            _context.Entry(bloco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlocoExists(id))
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

        // POST: api/Bloco
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bloco>> PostBloco(Bloco bloco)
        {
            _context.Bloco.Add(bloco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloco", new { id = bloco.BlocoId }, bloco);
        }

        // DELETE: api/Bloco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bloco>> DeleteBloco(int id)
        {
            var bloco = await _context.Bloco.FindAsync(id);
            if (bloco == null)
            {
                return NotFound();
            }

            _context.Bloco.Remove(bloco);
            await _context.SaveChangesAsync();

            return bloco;
        }

        private bool BlocoExists(int id)
        {
            return _context.Bloco.Any(e => e.BlocoId == id);
        }
    }
}
