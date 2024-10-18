using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Server.Data;
using TestProject.Server.Models;


namespace TestProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController: ControllerBase
    {
        private readonly JobContext _context;
        public JobsController(JobContext context)
        {
            _context = context;
        }

        // Fetch all jobs
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Job>>> GetAllJobs()
        {
            var jobs = await _context.Jobs
                .Include(j => j.Bids) // Include related bids
                .ToListAsync();

            return Ok(jobs);
        }

        // Fetch the 10 most recent jobs
        [HttpGet("recent")]
        public async Task<ActionResult<IEnumerable<Job>>> GetRecentJobs()
        {
            return await _context.Jobs
                .OrderByDescending(j => j.CreatedAt)
                .Take(10)
                .Include(j => j.Bids)
                .ToListAsync();
        }

        // Fetch the top 10 most active jobs (by number of bids)
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Job>>> GetActiveJobs()
        {
            return await _context.Jobs
                .OrderByDescending(j => j.Bids.Count)
                .Take(10)
                .Include(j => j.Bids)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return Ok(job);
        }
    }
}
