using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobSearch;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSearchDatasController : ControllerBase
    {
        private readonly JobSearchDbContext _context;

        public JobSearchDatasController(JobSearchDbContext context)
        {
            _context = context;
        }

        // GET: api/JobSearchDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSearchData>>> GetJobSearches()
        {
          if (_context.JobSearches == null)
          {
              return NotFound();
          }
            return await _context.JobSearches.ToListAsync();
        }

        // GET: api/JobSearchDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSearchData>> GetJobSearchData(int id)
        {
          if (_context.JobSearches == null)
          {
              return NotFound();
          }
            var jobSearchData = await _context.JobSearches.FindAsync(id);

            if (jobSearchData == null)
            {
                return NotFound();
            }

            return jobSearchData;
        }

        // PUT: api/JobSearchDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSearchData(int id, JobSearchData jobSearchData)
        {
            if (id != jobSearchData.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobSearchData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSearchDataExists(id))
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

        // POST: api/JobSearchDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobSearchData>> PostJobSearchData(JobSearchData jobSearchData)
        {
          if (_context.JobSearches == null)
          {
              return Problem("Entity set 'JobSearchDbContext.JobSearches'  is null.");
          }
            _context.JobSearches.Add(jobSearchData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobSearchData", new { id = jobSearchData.Id }, jobSearchData);
        }

        // DELETE: api/JobSearchDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSearchData(int id)
        {
            if (_context.JobSearches == null)
            {
                return NotFound();
            }
            var jobSearchData = await _context.JobSearches.FindAsync(id);
            if (jobSearchData == null)
            {
                return NotFound();
            }

            _context.JobSearches.Remove(jobSearchData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobSearchDataExists(int id)
        {
            return (_context.JobSearches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
