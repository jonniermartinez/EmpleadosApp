using backendDotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace backendDotNet.Data
{
    public class backendDbContext : DbContext
    {
        public backendDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
