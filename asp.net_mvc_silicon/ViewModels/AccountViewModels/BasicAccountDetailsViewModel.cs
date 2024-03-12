using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.ViewModels.AccountViewModels;

public class BasicAccountDetailsViewModel
{

    public string UserId { get; set; } = null!;

    [Display(Name = "First Name", Prompt = "Enter your first name.", Order = 0)]
    [Required(ErrorMessage = "Invalid first name")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last Name", Prompt = "Enter your last name.", Order = 1)]
    [Required(ErrorMessage = "Invalid last name.")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Email Address", Prompt = "Enter your email address", Order = 2)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Invalid email address.")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;


    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone (Option)", Prompt = "Enter your Phone.", Order = 3)]
    public string? PhoneNumber { get; set; }


    [DataType(DataType.MultilineText)]
    [Display(Name = "Bio (Option)", Prompt = "Enter your Bio.", Order = 4)]
    public string? Biography { get; set; }
}
