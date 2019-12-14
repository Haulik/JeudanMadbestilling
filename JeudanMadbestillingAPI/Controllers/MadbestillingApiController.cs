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
    public class MadbestillingApiController : ControllerBase
    {
        private readonly MadbestillingAPIContext _context;
        private readonly IMapper _mapper;

        public MadbestillingApiController(MadbestillingAPIContext context, IMapper mapper) //Convention over Configuration: The program knows to omit Controller from the name
        {
            _mapper = mapper;
            _context = context;
        }


        // GET: api/MadbestillingApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MadbestillingVM>>> GetMadbestilling()
        {
            var madbestillings = await _context.Madbestillings.ToListAsync();
            return _mapper.Map<List<JeudanMadbestilling.Models.Madbestillings>, List<MadbestillingVM>>(madbestillings);
        }

        // GET: api/MadbestillingApi/5
        [HttpGet("{id:int}")] //If you have multiple GET methods you need to give one of them an attribute with a type like this
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> GetMadbestilling(int id)
        {
            var madbestillings = await _context.Madbestillings.FindAsync(id);

            if (madbestillings == null)
            {
                return NotFound();
            }

            return madbestillings;
        }

        // PUT: api/MadbestillingApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMadbestilling(int id, JeudanMadbestilling.Models.Madbestillings madbestillings)
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
                if (!MadbestillingExists(id))
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

        // POST: api/MadbestillingApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> PostMadbestilling(JeudanMadbestilling.Models.Madbestillings madbestillings)
        {
            _context.Madbestillings.Add(madbestillings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMadbestilling", new { id = madbestillings.MadbestillingId }, madbestillings);
        }

        // DELETE: api/MadbestillingApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JeudanMadbestilling.Models.Madbestillings>> DeleteMadbestilling(int id)
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

        private bool MadbestillingExists(int id)
        {
            return _context.Madbestillings.Any(e => e.MadbestillingId == id);
        }
    }
}
