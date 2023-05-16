using Microsoft.EntityFrameworkCore;

namespace JobSearch.Models
{
    public class JobSearchDbContext : DbContext 
    {
        public JobSearchDbContext(DbContextOptions<JobSearchDbContext> Options) : base(Options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<JobSearch> jobSearches { get; set; }
    }
}
