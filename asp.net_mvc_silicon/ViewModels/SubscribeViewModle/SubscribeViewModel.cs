using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace asp.net_mvc_silicon.ViewModels.SubscribeViewModle;

public class SubscribeViewModel
{
    [Display(Prompt = "Enter your Email")]
    [Required(ErrorMessage = "Invalid email")]
    [EmailAddress]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;
    [Display(Name = "Daily Newsletter")]
    public bool DailyNewsletter { get; set; } = false;

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; } = false;

    [Display(Name = "Weekin Review")]
    public bool WeekinReview { get; set; } = false;

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; } = false;
    [Display(Name = "Startups Weekly")]
    public bool StartupsWeekly { get; set; } = false;
    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; } = false;
}
