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
    public class ReservaController : ControllerBase
    {
        private readonly AppDataContext _context;

        public ReservaController(AppDataContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            return await _context.Reserva.ToListAsync();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.ReservaId)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.ReservaId }, reserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ReservaId == id);
        }
    }
}
