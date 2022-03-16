using Microsoft.AspNetCore.Mvc;

namespace BeerReview.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}