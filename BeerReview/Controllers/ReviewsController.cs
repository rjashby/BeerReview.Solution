using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BeerReview.Models;
using System.Collections.Generic;
using System.Linq;

namespace BeerReview.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly BeerReviewContext _db;

    public ReviewsController(BeerReviewContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Reviews.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.BeerId = new SelectList(_db.Beers, "BeerId", "Name");
      ViewBag.DrinkerId = new SelectList(_db.Drinkers, "DrinkerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Review review, int BeerId, int DrinkerId, string Title, string Description)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisReview = _db.Reviews
          .Include(review => review.Drinker)
          .Include(review => review.Beer)
          .FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    public ActionResult Edit(int id)
    {
      var thisReview = _db.Reviews
      .FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost]
    public ActionResult Edit(Review review)
    {
      _db.Entry(review).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      _db.Reviews.Remove(thisReview);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}