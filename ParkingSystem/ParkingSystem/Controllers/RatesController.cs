using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingSystem.Model;

namespace ParkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {

        private readonly ParkingContext _context;
        public RatesController(ParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rates>>> GetRates()
        {
            var rates = _context.Rates.Where(p => p.Active == "A");
            if (rates == null)
            {
                return NotFound();
            }
            else
            {
                return await rates.ToListAsync();
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Rates>>> GetRates(int id)
        {
            var rate = _context.Rates.Where(p => id == p.RateId && p.Active == "A");
            if (rate == null)
            {
                return NotFound();
            }
            else
            {
                return await rate.ToListAsync();
            }

        }
        [HttpPost]
        public async Task<ActionResult<Rates>> PostRates(Rates rate)
        {
            rate.Active = "A";
            _context.Rates.Add(rate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRates), new { id = rate.RateId }, rate);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Rates>> PutRates(int id, Rates rate)

        {
            if (id != rate.RateId)
            {
                return BadRequest();
            }
            rate.Active = "A";
            _context.Entry(rate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateAvailable(id))
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
        private bool RateAvailable(int id)
        {
            return (_context.Rates?.Any(x => x.RateId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingTransactions>> DeleteRates(int id, Rates rate)
        {
            if (id != rate.RateId)
            {
                return BadRequest();
            }
            rate.Active = "D";
            _context.Entry(rate).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateAvailable(id))
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
