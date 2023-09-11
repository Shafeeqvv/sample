using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Model;

namespace ParkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ParkingContext _context;
        public ParkingLotsController(ParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingLots>>> GetParkingLots()
        {
            var lots = _context.ParkingLots.Where(p => p.Active == "A");
            if (lots == null)
            {
                return NotFound();
            }
            else
            {
                return await lots.ToListAsync();
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ParkingLots>>> GetParkingLotsSingle(int id)
        {
            var lots = _context.ParkingLots.Where(p =>id==p.LotId&&p.Active == "A");
            if (lots == null)
            {
                return NotFound();
            }
            else
            {
                return await lots.ToListAsync();
            }

        }
        [HttpPost]
        public async Task<ActionResult<ParkingLots>> PostLots(ParkingLots lots)
        {
            lots.Active = "A";
            _context.ParkingLots.Add(lots);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParkingLots), new { id = lots.LotId }, lots);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingLots>> PutLots(int id, ParkingLots lots)
        {
            if (id != lots.LotId)
            {
                return BadRequest();
            }
            lots.Active = "A";
            _context.Entry(lots).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lotsAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool lotsAvailable(int id)
        {
            return (_context.ParkingLots?.Any(x => x.LotId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingLots>> DeleteLots(int id, ParkingLots lots)
        {
            if (id != lots.LotId)
            {
                return BadRequest();
            }
            lots.Active = "D";
            _context.Entry(lots).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lotsAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

    }
}
