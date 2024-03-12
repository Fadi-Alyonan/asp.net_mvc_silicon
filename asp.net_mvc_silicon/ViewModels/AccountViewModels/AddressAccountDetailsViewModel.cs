using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.ViewModels.AccountViewModels;

public class AddressAccountDetailsViewModel
{
    public int AddressId { get; set; } 

    [Display(Name = "Address Line 1", Prompt = "Enter your Address", Order = 0)]
    [Required(ErrorMessage = "Invalid address")]
    public string AddressLine1 { get; set; } = null!;


    [Display(Name = "Address Line 2", Prompt = "Enter your second address.", Order = 1)]
    public string? AddressLine2 { get; set; } 


    [Display(Name = "Postal Code", Prompt = "Enter your Postal Code", Order = 2)]
    [Required(ErrorMessage = "Invalid Postal Code")]
    public string PostalCode { get; set; } = null!;


    [Display(Name = "City", Prompt = "Enter your City", Order = 3)]
    [Required(ErrorMessage = "Invalid City")]
    public string City { get; set; } = null!;
}
