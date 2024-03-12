using asp.net_mvc_silicon.ViewModels.AuthViewModels;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc_silicon.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [HttpGet]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email);
            if (exists)
            {
                ModelState.AddModelError("AlreadyExists", "User with the same email already exists");
                ViewData["ErrorMassage"] = "User with the same email already exists try to login";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.Form.FirstName,
                LastName = viewModel.Form.LastName,
                Email = viewModel.Form.Email,
                UserName = viewModel.Form.Email
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Form.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Auth");
            }
        }
        
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false); 
            if (result.Succeeded)
            {
                return RedirectToAction("Details","Account");
            }
            else
            {
                ModelState.AddModelError("IncorrectValues", "Incorrect email ro password");
                ViewData["ErrorMassage"] = "Incorrect email ro password";
            }
            return View(viewModel);
        }
        ModelState.AddModelError("IncorrectValues", "Incorrect email ro password");
        ViewData["ErrorMassage"] = "Incorrect email ro password";
        return View(viewModel);
    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
