using Microsoft.EntityFrameworkCore;

namespace BeerReview.Models
{
  public class BeerReviewContext : DbContext
  {
    public DbSet<Beer> Beers { get; set; }
    public DbSet<Drinker> Drinkers { get; set; }
    public DbSet<BeerDrinker> BeerDrinker { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public BeerReviewContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}