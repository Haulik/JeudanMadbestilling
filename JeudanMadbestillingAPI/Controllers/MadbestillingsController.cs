using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeudanMadbestilling.Models;
using JeudanMadbestillingAPI.Models;
using JeudanMadbestilling.Models.ViewModels;
using AutoMapper;

namespace JeudanMadbestillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MadbestillingsController : ControllerBase
    {
        private readonly MadbestillingAPIContext _context;
        private readonly IMapper _mapper;

        public MadbestillingsController(MadbestillingAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Madbestillings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MadbestillingVM>>> GetMadbestilling()
        {
            var madbestillings = await _context.Madbestillings.ToListAsync();
            return _mapper.Map<List<JeudanMadbestilling.Models.Madbestillings>, List<MadbestillingVM>>(madbestillings);
        }

        // GET: api/Madbestillings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> GetMadbestillings(int id)
        {
            var madbestillings = await _context.Madbestillings.FindAsync(id);

            if (madbestillings == null)
            {
                return NotFound();
            }

            return madbestillings;
        }

        // PUT: api/Madbestillings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMadbestillings(int id, JeudanMadbestilling.Models.Madbestillings madbestillings)
        {
            if (id != madbestillings.MadbestillingId)
            {
                return BadRequest();
            }

            _context.Entry(madbestillings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MadbestillingsExists(id))
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

        // POST: api/Madbestillings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> PostMadbestillings(JeudanMadbestilling.Models.Madbestillings madbestillings)
        {
            _context.Madbestillings.Add(madbestillings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMadbestillings", new { id = madbestillings.MadbestillingId }, madbestillings);
        }

        // DELETE: api/Madbestillings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> DeleteMadbestillings(int id)
        {
            var madbestillings = await _context.Madbestillings.FindAsync(id);
            if (madbestillings == null)
            {
                return NotFound();
            }

            _context.Madbestillings.Remove(madbestillings);
            await _context.SaveChangesAsync();

            return madbestillings;
        }

        private bool MadbestillingsExists(int id)
        {
            return _context.Madbestillings.Any(e => e.MadbestillingId == id);
        }
    }
}
