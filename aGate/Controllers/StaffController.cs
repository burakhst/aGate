using aGate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace aGate.Controllers
{
    [Authorize(Roles = "Staff")]
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

        [HttpGet]
        public IActionResult AddAdvert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdvert(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                return View(advert);
            }

            c.Add(advert);
            c.SaveChanges();

            TempData["Success"] = "Advert successfully added.";
            return RedirectToAction("AddAdvert");
        }
        [HttpGet]
        public IActionResult UpdateCompletion()
        {
            var vm = new UpdateCompletionViewModel
            {
                AdvertList = c.Adverts
                    .Select(a => new SelectListItem
                    {
                        Value = a.AdvertID.ToString(),
                        Text = a.AdvertName
                    })
                    .ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult UpdateCompletion(UpdateCompletionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AdvertList = c.Adverts
                    .Select(a => new SelectListItem
                    {
                        Value = a.AdvertID.ToString(),
                        Text = a.AdvertName
                    })
                    .ToList();

                return View(vm);
            }

            var advert = c.Adverts.FirstOrDefault(a => a.AdvertID == vm.SelectedAdvertID);

            if (advert == null)
            {
                ModelState.AddModelError("", "Advert not found.");
                return View(vm);
            }

            advert.RecordCompletion = vm.StateOfCompletion;
            c.SaveChanges();

            TempData["SuccessMessage"] = "Completion updated successfully.";

            return RedirectToAction("UpdateCompletion");
        }
        public IActionResult GetCompletionByAdvert(int advertId)
        {
            var advert = c.Adverts
                .Where(a => a.AdvertID == advertId)
                .Select(a => a.RecordCompletion)
                .FirstOrDefault();

            return Json(advert);
        }
    }
}
