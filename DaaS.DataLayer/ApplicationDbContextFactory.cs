using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DaaS.DataLayer
{
    public class ApplicationDbContextFactory:IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../DaaS.Presentation/appsettings.json").Build(); 
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>(); 
            var connectionString = configuration.GetConnectionString("DefaultConnection"); 
            builder.UseNpgsql(connectionString); 
            return new ApplicationDbContext(builder.Options); 
        }
    }
}