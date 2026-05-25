using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using YokohamaEF.Models;

namespace YokohamaEF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }

    // ✅ เพิ่มตรงนี้
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-K9M6MAU\\SQLEXPRESS01;Database=YokohamaEFDB;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}