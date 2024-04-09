using asp.net_mvc_silicon.ViewModels.SubscribeViewModle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace asp.net_mvc_silicon.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;

    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/")]
    [HttpPost]
    public async Task<IActionResult> Index(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                var res = await _httpClient.PostAsync("https://localhost:7068/api/Subscrib", content);
                if (res.IsSuccessStatusCode)
                {
                    ViewData["status"] = "Success";
                }else if (res.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    ViewData["status"] = "AlreadyExists";
                }
            }
            catch
            {
                ViewData["status"] = "ConnectionFailed";
            }
        }else
        {
            ViewData["status"] = "Invalid";
        }
        return View();
    }


    [Route("/error")]
    public IActionResult Error404(int statusCode)
    {
        return View();
    }
}
