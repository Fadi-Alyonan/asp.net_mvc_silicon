using asp.net_mvc_silicon.Models;

namespace asp.net_mvc_silicon.ViewModels.AuthViewModels;

public class SignInViewModel
{
    public string Title { get; set; } = "Sign in";
    public SignInModel Form { get; set; } = new SignInModel();
}
