using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc_silicon.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/error")]
        public IActionResult Error404(int statusCode)
        {
            return View();
        }
    }
}
