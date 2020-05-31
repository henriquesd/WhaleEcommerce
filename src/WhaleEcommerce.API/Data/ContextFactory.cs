using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WhaleEcommerce.API.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            var migrations = new Info
            {
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=WhaleECommerceDB;Trusted_Connection=True;MultipleActiveResultSets=true"
            };

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(migrations.ConnectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    public class Info
    {
        public string ConnectionString { get; set; }
    }
}