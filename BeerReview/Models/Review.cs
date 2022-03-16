using System;
using System.Collections.Generic;

namespace BeerReview.Models
{
  public class Review
  {
    // public Review()
    // {
    //   this.Reviews = new HashSet<Review>();
    // }
    public int ReviewId { get; set; }
    public int BeerId { get; set; }
    public int DrinkerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual Drinker Drinker { get; set; }
    public virtual Beer Beer { get; set; }
  }
}