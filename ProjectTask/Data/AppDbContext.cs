using Microsoft.EntityFrameworkCore;
using ProjectTask.Data.Entities;

namespace ProjectTask.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<SubDepartment> SubDepartments { get; set; }
    }
}
