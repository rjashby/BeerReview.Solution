using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BeerReview.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerReview.Controllers
{
  public class BeersController : Controller
  {
    private readonly BeerReviewContext _db;

    public BeersController(BeerReviewContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Beer> model = _db.Beers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Beer beer)
    {
      _db.Beers.Add(beer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBeer = _db.Beers
        .Include(beer => beer.JoinEntities)
        .ThenInclude(join => join.Drinker)
        .FirstOrDefault(beer => beer.BeerId == id);
      return View(thisBeer);
    }
    public ActionResult Edit(int id)
    {
      var thisBeer = _db.Beers.FirstOrDefault(beer => beer.BeerId == id);
      return View(thisBeer);
    }

    [HttpPost]
    public ActionResult Edit(Beer beer)
    {
      _db.Entry(beer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBeer = _db.Beers.FirstOrDefault(beer => beer.BeerId == id);
      return View(thisBeer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBeer = _db.Beers.FirstOrDefault(beer => beer.BeerId == id);
      _db.Beers.Remove(thisBeer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}