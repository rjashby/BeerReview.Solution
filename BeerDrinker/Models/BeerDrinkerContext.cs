using Microsoft.EntityFrameworkCore;

namespace BeerDrinker.Models
{
  public class BeerDrinkerContext : DbContext
  {
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Drinker> Drinkers { get; set; }
    public DbSet<BeerDrinker> BeerDrinkers { get; set; }

    public BeerDrinkerContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}