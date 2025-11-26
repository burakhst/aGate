using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace aGate.Models
{
    public class AssignStaffViewModel
    {
        public int? SelectedCampaingID { get; set; }
        public int? SelectedStaffID { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CampaingList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StaffList { get; set; }
    }
}
