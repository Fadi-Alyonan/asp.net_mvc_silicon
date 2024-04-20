using asp.net_mvc_silicon.ViewModels.AccountViewModels;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp.net_mvc_silicon.Controllers;

public class AccountController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AddressManager addressManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly AddressManager _addressManager = addressManager;

    [HttpGet]
    public async Task<IActionResult> Details() 
    {
        var viewModel = new AccountDetailsViewModel();
        try
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("SignIn", "Auth");
            }
            viewModel.basic ??= await PopulateBasicInfoFormAsync();
            viewModel.address ??= await PopulateAddressInfoFormAsync();

            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        try
        {
            if (viewModel.basic != null)
            {
                if (viewModel.basic.FirstName != null && viewModel.basic.LastName != null && viewModel.basic.Email != null)
                {
                    var userToUpdate = await _userManager.GetUserAsync(User);
                    if (userToUpdate != null)
                    {
                        userToUpdate.FirstName = viewModel.basic.FirstName;
                        userToUpdate.LastName = viewModel.basic.LastName;
                        userToUpdate.Email = viewModel.basic.Email;
                        userToUpdate.PhoneNumber = viewModel.basic.PhoneNumber;
                        userToUpdate.Bio = viewModel.basic.Biography;

                        var result = await _userManager.UpdateAsync(userToUpdate);
                        if (!result.Succeeded)
                        {
                            ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                            ViewData["ErrorMassage"] = "Something went wrong! Unable to save data.";
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                        ViewData["ErrorMassage"] = "Something went wrong! Unable to save data.";
                    }
                }
            }
            if (viewModel.address != null)
            {
                if (viewModel.address.AddressLine1 != null && viewModel.address.PostalCode != null && viewModel.address.City != null)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        var address = await _addressManager.GetAddressAsync(user.Id);
                        if (address != null)
                        {
                            address.AddressLine1 = viewModel.address.AddressLine1;
                            address.AddressLine2 = viewModel.address.AddressLine2;
                            address.PostalCode = viewModel.address.PostalCode;
                            address.City = viewModel.address.City;

                            var result = await _addressManager.UpdateAddressAsync(address);
                            if (!result)
                            {
                                ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                                ViewData["ErrorMassage"] = "Something went wrong! Unable to save data.";
                            }
                        }
                        else
                        {
                            address = new AddressEntity
                            {
                                UserId = user.Id,
                                AddressLine1 = viewModel.address.AddressLine1,
                                AddressLine2 = viewModel.address.AddressLine2,
                                PostalCode = viewModel.address.PostalCode,
                                City = viewModel.address.City,
                            };

                            var result = await _addressManager.CreateAddressAsync(address);
                            if (!result)
                            {
                                ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                                ViewData["ErrorMassage"] = "Something went wrong! Unable to save data.";
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("IncorrectValues", "Something went wrong! Unable to save data.");
                        ViewData["ErrorMassage"] = "Something went wrong! Unable to save data.";
                    }
                }
            }
            viewModel.basic = await PopulateBasicInfoFormAsync();
            viewModel.address = await PopulateAddressInfoFormAsync();
            return View(viewModel);
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return View(viewModel);
    }

    private async Task<BasicAccountDetailsViewModel> PopulateBasicInfoFormAsync()
    {
        try
        {
            var userEntity = await _userManager.GetUserAsync(User);
            if (userEntity != null)
            {
                return new BasicAccountDetailsViewModel
                {
                    UserId = userEntity.Id,
                    FirstName = userEntity.FirstName,
                    LastName = userEntity.LastName,
                    Email = userEntity.Email!,
                    PhoneNumber = userEntity.PhoneNumber,
                    Biography = userEntity.Bio
                };
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
    private async Task<AddressAccountDetailsViewModel> PopulateAddressInfoFormAsync()
    {
        try
        {
            var userEntity = await _userManager.GetUserAsync(User);
            if (userEntity != null)
            {
                var address = await _addressManager.GetAddressAsync(userEntity.Id);
                if (address != null)
                {
                    return new AddressAccountDetailsViewModel
                    {
                        AddressLine1 = address.AddressLine1,
                        AddressLine2 = address.AddressLine2,
                        PostalCode = address.PostalCode,
                        City = address.City
                    };
                }
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return new AddressAccountDetailsViewModel();
    }
}
