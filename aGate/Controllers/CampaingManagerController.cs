using aGate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult ListClient()
        {
            var clients = c.clients.ToList();  // Db'den tüm clientları çek
            return View(clients);
        }
        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                c.clients.Add(client);
                c.SaveChanges();

                // Başarılı mesajı TempData ile gönder
                TempData["SuccessMessage"] = "Client added successfully!";
                return RedirectToAction("AddClient");
            }

            // Hata varsa formu tekrar göster
            return View(client);
        }
        public IActionResult AddCampaing()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCampaing(Campaing campaing)
        {
            if (ModelState.IsValid)
            {
                c.campaings.Add(campaing);
                c.SaveChanges();
                TempData["SuccessMessage"] = "Campaing added successfully!";
            }
            return View(campaing);
        }
        [HttpGet]
        public IActionResult AssignStaff()
        {
            var vm = new AssignStaffViewModel
            {
                CampaingList = c.campaings
                    .Select(c => new SelectListItem { Value = c.campaingID.ToString(), Text = c.campaingName })
                    .ToList(),
                StaffList = c.staffs
                    .Select(s => new SelectListItem { Value = s.staffID.ToString(), Text = s.staffName })
                    .ToList()
            };
            return View(vm);
        }


        [HttpPost]
        public IActionResult AssignStaff(AssignStaffViewModel vm)
        {
            // --- VALIDATION ---
            if (vm.SelectedCampaingID == null || vm.SelectedCampaingID == 0)
                ModelState.AddModelError("SelectedCampaingID", "Please select a campaign.");

            if (vm.SelectedStaffID == null || vm.SelectedStaffID == 0)
                ModelState.AddModelError("SelectedStaffID", "Please select a staff.");


            // --- VALIDATION FAILED: RETURN VIEW WITH DROPDOWNS ---
            if (!ModelState.IsValid)
            {
                vm.CampaingList = c.campaings
                    .Select(c => new SelectListItem
                    {
                        Value = c.campaingID.ToString(),
                        Text = c.campaingName
                    })
                    .ToList();

                vm.StaffList = c.staffs
                    .Select(s => new SelectListItem
                    {
                        Value = s.staffID.ToString(),
                        Text = s.staffName
                    })
                    .ToList();

                return View(vm);
            }


            // --- SAVE NEW RELATION ---
            c.CampaingStaffs.Add(new CampaingStaff
            {
                CampaingID = vm.SelectedCampaingID.Value,
                StaffID = vm.SelectedStaffID.Value
            });

            c.SaveChanges();


            // --- SUCCESS MESSAGE ---
            TempData["SuccessMessage"] = "Staff assigned successfully.";

            return RedirectToAction("AssignStaff");
        }
        public IActionResult ListStaff()
        {
            var staff = c.staffs.ToList(); 
            return View(staff);
        }
        public IActionResult ListCampaing()
        {
            var campaigns = c.campaings.ToList();
            return View(campaigns);
        }
    }
}
