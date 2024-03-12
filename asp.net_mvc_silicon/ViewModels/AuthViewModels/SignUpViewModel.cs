using asp.net_mvc_silicon.Models;

namespace asp.net_mvc_silicon.ViewModels.AuthViewModels;

public class SignUpViewModel
{
    public string Title { get; set; } = "Sign up";
    public SignUpModel Form { get; set; } = new SignUpModel();
}
