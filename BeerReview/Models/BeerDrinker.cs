namespace BeerReview.Models
{
  public class BeerDrinker
    {       
        public int BeerDrinkerId { get; set; }
        public int BeerId { get; set; }
        public int DrinkerId { get; set; }
        public virtual Drinker Drinker { get; set; }
        public virtual Beer Beer { get; set; }
    }
}