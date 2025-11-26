using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class CampaingStaff
    {
        [Key]
        public int CampaingStaffID { get; set; }   
        public int CampaingID { get; set; }
        public Campaing Campaing { get; set; }

        public int StaffID { get; set; }
        public Staff Staff { get; set; }
    }
}
