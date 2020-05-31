using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WhaleEcommerce.Infrastructure.Context;

namespace WhaleEcommerce.API.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<WhaleECommerceAppContext>
    {

        WhaleECommerceAppContext IDesignTimeDbContextFactory<WhaleECommerceAppContext>.CreateDbContext(string[] args)
        {
            var migrations = new Info
            {
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=WhaleECommerceDB;Trusted_Connection=True;MultipleActiveResultSets=true"
            };

            var optionsBuilder = new DbContextOptionsBuilder<WhaleECommerceAppContext>();
            optionsBuilder.UseSqlServer(migrations.ConnectionString);
            return new WhaleECommerceAppContext(optionsBuilder.Options);
        }
    }

    public class Info
    {
        public string ConnectionString { get; set; }
    }
}