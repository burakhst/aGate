using Microsoft.AspNetCore.Mvc;

namespace aGate.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
