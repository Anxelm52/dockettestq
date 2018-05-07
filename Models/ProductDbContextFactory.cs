using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExampleApp.Models
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<ProductDbContext>();

            var host = configuration["DBHOST"] ?? "localhost";
            var port = configuration["DBPORT"] ?? "3306";
            var password = configuration["DBPASSWORD"] ?? "mysecret";

            var connectionStr = $"server={host};userid=root;pwd={password};"
                                + $"port={port};database=products";

            var connectionString = connectionStr;

            builder.UseMySQL(connectionString);

            return new ProductDbContext(builder.Options);
        }
    }
}