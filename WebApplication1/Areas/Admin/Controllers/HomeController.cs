using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_TCO.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
