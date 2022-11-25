using Microsoft.EntityFrameworkCore;
using RealEstateApi.Models;

namespace RealEstateApi.Data
{
    public class ApiDbContext :  DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-J076A4M;Database=RealEstateDb;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;user id=sa;Password=123456");
        }
    }
}
