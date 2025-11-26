using aGate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace aGate.Controllers
{
    public class StaffController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateNote()
        {
            ViewBag.StaffList = c.staffs
    .Select(s => new SelectListItem
    {
        Value = s.staffID.ToString(),
        Text = s.staffName
    }).ToList();
            return View();
        }

        // POST: Create Note
        [HttpPost]
        public IActionResult CreateNote(StaffNote note)
        {
            if (ModelState.IsValid)
            {
                c.StaffNotes.Add(note);
                c.SaveChanges();

                TempData["SuccessMessage"] = "Note created successfully.";
                return RedirectToAction("CreateNote");
            }

            return View(note);
        }
    }
}
