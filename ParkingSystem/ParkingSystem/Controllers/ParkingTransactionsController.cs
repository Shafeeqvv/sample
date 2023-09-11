using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ParkingSystem.Model;
using System;
using System.Collections.Generic;

namespace ParkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingTransactionsController : ControllerBase
    {
        private readonly ParkingContext _context;
        public ParkingTransactionsController(ParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingTransactions>>> GetParkingPt()
        {
            var pT = _context.ParkingTransactions.Where(p => p.Active == "A");
            if (pT == null)
            {
                return NotFound();
            }
            else
            {
                return await pT.ToListAsync();
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ParkingTransactions>>> GetParkingPt(int id)
        {
            var pT = _context.ParkingTransactions.Where(p => id == p.TransactionId && p.Active == "A");
            if (pT == null)
            {
                return NotFound();
            }
            else
            {
                return await pT.ToListAsync();
            }

        }
        [HttpPost]
        public async Task<ActionResult<ParkingTransactions>> PostPt(ParkingTransactions pT)
        {
            pT.Active = "A";
            var d1 =pT.ExitTimestamp;
            var d2 = pT.EntryTimestamp;
            pT.Duration = pT.ExitTimestamp - pT.EntryTimestamp;
            _context.ParkingTransactions.Add(pT);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParkingPt), new { id = pT.TransactionId }, pT);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ParkingTransactions>> PutPt(int id, ParkingTransactions pT)

        {
            if (id != pT.TransactionId)
            {
                return BadRequest();
            }
            pT.Active = "A";
            pT.Duration = pT.ExitTimestamp - pT.EntryTimestamp;
            _context.Entry(pT).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pTAvailable(id))
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
        private bool pTAvailable(int id)
        {
            return (_context.ParkingTransactions?.Any(x => x.TransactionId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ParkingTransactions>> DeletePt(int id, ParkingTransactions pT)
        {
            if (id != pT.TransactionId)
            {
                return BadRequest();
            }
            pT.Active = "D";
            _context.Entry(pT).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pTAvailable(id))
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
