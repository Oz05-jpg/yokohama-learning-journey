using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EFCorePractice.Models;

namespace EFCorePractice.Data
{
    public class AppDbContext : IdentityDbContext //เดิม : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        //migrate Db ใหม่เพื่อเก็บ Department
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=EFCorePracticeDB;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}