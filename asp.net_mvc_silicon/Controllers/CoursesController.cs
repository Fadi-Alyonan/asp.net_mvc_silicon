using asp.net_mvc_silicon.ViewModels.CoursesViewModles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace asp.net_mvc_silicon.Controllers;
[Authorize]
public class CoursesController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var viewModel = new CoursesListViewModel();
        var res = await _httpClient.GetAsync("https://localhost:7068/api/Courses");
        var json = await res.Content.ReadAsStringAsync();  
        viewModel.Courses = JsonConvert.DeserializeObject<IEnumerable<CoursInfoViewModel>>(json)!;

        return View(viewModel);
    }
}
