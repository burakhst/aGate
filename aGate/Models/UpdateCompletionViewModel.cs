using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class UpdateCompletionViewModel
{
    [Required(ErrorMessage = "Please select an advert")]
    public int SelectedAdvertID { get; set; }

    [Required]
    [Range(0, 100, ErrorMessage = "Completion must be between 0 and 100")]
    public int StateOfCompletion { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem> AdvertList { get; set; }
}
