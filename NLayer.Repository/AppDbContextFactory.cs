using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NLayer.Repository
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Server=localhost;Port=3306;Database=NLayerDb;User=root;Password=sena13579;";
        
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 26)),
                b => b.MigrationsAssembly("NLayer.Repository"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}