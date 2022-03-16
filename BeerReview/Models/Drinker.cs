using System.Collections.Generic;

namespace BeerReview.Models
{
  public class Drinker
  {
    public Drinker()
    {
      this.JoinEntities = new HashSet<BeerDrinker>();
    }
    public int DrinkerId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<BeerDrinker> JoinEntities { get;}
  }
}