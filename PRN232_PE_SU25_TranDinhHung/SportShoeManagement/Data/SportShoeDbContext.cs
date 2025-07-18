using Microsoft.EntityFrameworkCore;
using SportShoeManagement.Models;

namespace SportShoeManagement.Data
{
    public class SportShoeDbContext : DbContext
    {
        public SportShoeDbContext(DbContextOptions<SportShoeDbContext> options) : base(options)
        {
        }

        public DbSet<SportShoe> SportShoes { get; set; }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:MyCnn"];

            return strConn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(GetConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SportShoe>().HasData(
                new SportShoe { Id = 1, Name = "Nike Air Zoom Pegasus", Price = 120, Category = "Running", IsDeleted = false },
                new SportShoe { Id = 2, Name = "Adidas Ultraboost", Price = 150, Category = "Running", IsDeleted = false },
                new SportShoe { Id = 3, Name = "Puma Future Rider", Price = 90, Category = "Casual", IsDeleted = false }
            );
        }
    }
}
