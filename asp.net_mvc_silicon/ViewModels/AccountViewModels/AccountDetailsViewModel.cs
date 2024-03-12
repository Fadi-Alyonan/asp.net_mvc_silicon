using Microsoft.AspNetCore.Authorization;

namespace asp.net_mvc_silicon.ViewModels.AccountViewModels;

[Authorize]
public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";
    public string? ProfileImage { get; set; }
    public AddressAccountDetailsViewModel? address {  get; set; }
    public BasicAccountDetailsViewModel? basic { get; set; }
}
