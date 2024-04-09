namespace asp.net_mvc_silicon.ViewModels.CoursesViewModles;

public class CoursInfoViewModel
{
    public string id { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string OriginalPrice { get; set; } = null!;
    public string? DiscountPrice { get; set; }
    public int Hours { get; set; }
    public string? LikesInProcent { get; set; }
    public string? NumberOfLikes { get; set; }
    public bool IsDigital { get; set; } 
    public bool IsBestseller { get; set; } 
}
