using JobSearch.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSearch
{
    public class JobSearchDbContext : DbContext
    {
        public JobSearchDbContext(DbContextOptions<JobSearchDbContext> Options) : base(Options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<JobSearchData> JobSearches { get; set; }
    }
}
