using Microsoft.AspNetCore.Mvc;

namespace WorldCitiesAPI.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
