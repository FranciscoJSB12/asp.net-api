using Microsoft.EntityFrameworkCore;
using rest_api_dotnet.Models.Entities;

namespace rest_api_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
