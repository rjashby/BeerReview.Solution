using System;
using System.Collections.Generic;

namespace BeerReview.Models
{
  public class Beer
  {
    public Beer()
    {
      this.JoinEntities = new HashSet<BeerDrinker>();
      this.Reviews = new HashSet<Review>();
    }

    public int BeerId { get; set; }
    public string Name { get; set; }
    public int ABV { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<BeerDrinker> JoinEntities { get; set; }
  }
}