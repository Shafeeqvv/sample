using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Model;

namespace ParkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {
        private readonly ParkingContext _context;
        public ParkingSpaceController(ParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingSpace>>> GetParkingSpace()
        {
            var space = _context.ParkingSpaces.Where(p => p.Active == "A");
            if (space == null)
            {
                return NotFound();
            }
            else
            {
                return await space.ToListAsync();
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ParkingSpace>>> GetParkingSpaceSingle(int id)
        {
            var space = _context.ParkingSpaces.Where(p => id == p.SpaceId && p.Active == "A");
            if (space == null)
            {
                return NotFound();
            }
            else
            {
                return await space.ToListAsync();
            }

        }
        [HttpPost]
        public async Task<ActionResult<ParkingSpace>> PostSpace(ParkingSpace space)
        {
            space.Active = "A";
            _context.ParkingSpaces.Add(space);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParkingSpace), new { id = space.SpaceId }, space);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingSpace>> PutSpace(int id, ParkingSpace space)
        {
            if (id != space.LotId)
            {
                return BadRequest();
            }
            space.Active = "A";
            _context.Entry(space).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceAvailable(id))
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
        private bool SpaceAvailable(int id)
        {
            return (_context.ParkingSpaces?.Any(x => x.SpaceId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingSpace>> DeleteSpace(int id, ParkingSpace space)
        {
            if (id != space.LotId)
            {
                return BadRequest();
            }
            space.Active = "D";
            _context.Entry(space).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceAvailable(id))
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
