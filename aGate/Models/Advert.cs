using System;
using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class Advert
    {
        [Key]
        public int AdvertID { get; set; }

        [Required(ErrorMessage = "Advert name is required")]
        public string AdvertName { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Completion must be between 0 and 100")]
        public int RecordCompletion { get; set; }
    }
}
