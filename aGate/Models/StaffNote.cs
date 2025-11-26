using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace aGate.Models
{
    public class StaffNote
    {
        [Key]
        public int NoteID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string NoteText { get; set; }

        [Required]
        public int StaffID { get; set; }

        [ValidateNever]
        public Staff Staff { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
