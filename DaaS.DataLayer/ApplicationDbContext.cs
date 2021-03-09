using DaaS.DataLayer.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DaaS.DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Agent> Agents { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }
        
        
    }
}