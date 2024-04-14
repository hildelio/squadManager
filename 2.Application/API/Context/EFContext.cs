using Microsoft.EntityFrameworkCore;
using Common;


namespace API.Context
{
    public class EFContext : DbContext
    {
      private const string connectionString = "Server=localhost,1433;Database=squadmanagerdb;User Id=sa;Password=MinhaSenha@123;TrustServerCertificate=true;";

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<UserDBModel> Users { get; set; }
    }
}