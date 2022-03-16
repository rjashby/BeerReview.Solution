using System;
using System.Collections.Generic;

namespace BeerReview.Models
{
  public class Drinker
  {
    public Drinker()
    {
      this.JoinEntities = new HashSet<BeerDrinker>();
      this.Reviews = new HashSet<Review>();
    }
    public int DrinkerId { get; set; }
    public string Name { get; set; }
    public DateTime SignUp { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<BeerDrinker> JoinEntities { get; set; }
  }
}