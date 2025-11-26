using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class Staff
    {
        [Key]
        public int staffID { get; set; }
        public string? staffName { get; set; }
        public string? staffLastName { get; set; }
        public string staffContent { get; set; }
        public ICollection<CampaingStaff> CampaingStaffs { get; set; }
        public ICollection<StaffNote> Notes { get; set; }

    }
}
