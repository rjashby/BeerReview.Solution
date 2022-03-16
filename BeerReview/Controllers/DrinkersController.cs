using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BeerReview.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerReview.Controllers
{
  public class DrinkersController : Controller
  {
    private readonly BeerReviewContext _db;

    public DrinkersController(BeerReviewContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Drinkers.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BeerId = new SelectList(_db.Beers, "BeerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Drinker drinker, int BeerId)
    {
      _db.Drinkers.Add(drinker);
      _db.SaveChanges();
      if (BeerId != 0)
      {
        _db.BeerDrinker.Add(new BeerDrinker() { BeerId = BeerId, DrinkerId = drinker.DrinkerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisDrinker = _db.Drinkers
          .Include(drinker => drinker.JoinEntities)
          .ThenInclude(join => join.Beer)
          .FirstOrDefault(drinker => drinker.DrinkerId == id);
      return View(thisDrinker);
    }

    public ActionResult Edit(int id)
    {
      var thisDrinker = _db.Drinkers.FirstOrDefault(drinker => drinker.DrinkerId == id);
      ViewBag.BeerId = new SelectList(_db.Beers, "BeerId", "Name");
      return View(thisDrinker);
    }

    [HttpPost]
    public ActionResult Edit(Drinker drinker, int BeerId)
    {
      if (BeerId != 0)
      {
        _db.BeerDrinker.Add(new BeerDrinker() { BeerId = BeerId, DrinkerId = drinker.DrinkerId });
      }
      _db.Entry(drinker).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult AddBeer(int id)
    // {
    //   var thisDrinker = _db.Drinkers.FirstOrDefault(drinker => drinker.DrinkerId == id);
    //   ViewBag.BeerId = new SelectList(_db.Beers, "BeerId", "Name");
    //   return View(thisDrinker);
    // }

    public ActionResult AddBeer(int id)
    {
      var thisDrinker = _db.Drinkers.FirstOrDefault(drinker => drinker.DrinkerId == id);
      var thisBeerDrinker = _db.BeerDrinker.Where(beerdrinker => beerdrinker.DrinkerId == id);
      
      List<Beer> beers = _db.Beers.ToList();
      List<Beer> beerList = _db.Beers.ToList();

      foreach (BeerDrinker beerDrinker in thisBeerDrinker)
      {
        foreach(Beer beer in beers)
        {
          if (beer.BeerId == beerDrinker.BeerId)
          {
            beerList.Remove(beer);
          }
        }
      }
      ViewBag.BeerId = new SelectList(beerList, "BeerId", "Name");
      return View(thisDrinker);
    }

    [HttpPost]
    public ActionResult AddBeer(Drinker drinker, int BeerId)
    {
      if (BeerId != 0)
      {
        _db.BeerDrinker.Add(new BeerDrinker() { BeerId = BeerId, DrinkerId = drinker.DrinkerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDrinker = _db.Drinkers.FirstOrDefault(drinker => drinker.DrinkerId == id);
      return View(thisDrinker);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDrinker = _db.Drinkers.FirstOrDefault(drinker => drinker.DrinkerId == id);
      _db.Drinkers.Remove(thisDrinker);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteBeer(int joinId)
    {
      var joinEntry = _db.BeerDrinker.FirstOrDefault(entry => entry.BeerDrinkerId == joinId);
      _db.BeerDrinker.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}