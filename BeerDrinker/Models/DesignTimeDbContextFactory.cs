using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BeerDrinker
{
  public class BeerDrinkerContextFactory : IDesignTimeDbContextFactory<BeerDrinkerContext>
  {

    BeerDrinkerContext IDesignTimeDbContextFactory<BeerDrinkerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<BeerDrinkerContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new BeerDrinkerContext(builder.Options);
    }
  }
}