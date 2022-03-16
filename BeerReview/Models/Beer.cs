using System.Collections.Generic;

namespace BeerReview.Models
{
  public class Beer
  {
    public Beer()
    {
      this.JoinEntities = new HashSet<BeerDrinker>();
    }

    public int BeerId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BeerDrinker> JoinEntities { get; set; }
  }
}