using Microsoft.EntityFrameworkCore;
using TestProject.Server.Models;

namespace TestProject.Server.Data
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Bid> Bids { get; set; }

    }
}
