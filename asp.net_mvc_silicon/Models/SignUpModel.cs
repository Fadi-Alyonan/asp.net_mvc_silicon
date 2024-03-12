using asp.net_mvc_silicon.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.Models;

public class SignUpModel
{
    [Display (Name = "First Name", Prompt ="Enter your first name.", Order = 0)]
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

    [Display(Name = "Password", Prompt = "Enter your password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Invalid password")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$", ErrorMessage = "The password does not meet the requirements. It must contain at least one uppercase letter, one digit, one non-alphanumeric character, and be at least 8 characters long.")]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password", Prompt = "Confirm your password", Order = 4)]
    [Compare(nameof(Password), ErrorMessage = "Your password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & conditions.", Prompt = "Enter your first name", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "You need to agree the Terms & conditions.")]
    public bool TermsAndConditions { get; set;} = false;
}

