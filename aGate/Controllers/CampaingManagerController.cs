using aGate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aGate.Controllers
{
    public class CampaingManagerController : Controller
    {

        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            c.clients.Add(client);
            c.SaveChanges();

            return RedirectToAction("Index"); // veya başarılı sayfası
        }
    }
}
