using Microsoft.AspNetCore.Mvc;

namespace BeerDrinker.Controllers
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