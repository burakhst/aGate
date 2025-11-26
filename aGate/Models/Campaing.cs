using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class Campaing
    {
        [Key]
        public int campaingID { get; set; }
        public string campaingName { get; set; }
        public DateTime campaingStartDate { get; set; }
        public DateTime campaingEndDate { get; set; }
        public int campaingBudget { get; set; }
        public int campaingEstimatedPrice { get; set; }
        public int campaingStatus { get; set; }

        [ValidateNever]
        public ICollection<CampaingStaff> CampaingStaffs { get; set; }


    }
}
