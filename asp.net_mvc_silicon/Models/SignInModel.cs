using asp.net_mvc_silicon.Helpers;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.Models;

public class SignInModel
{
    [Display(Name = "Email Address", Prompt = "Enter your email address", Order = 0)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Invalid password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Remember me", Order = 2)]
    public bool RememberMe { get; set; } 
}
