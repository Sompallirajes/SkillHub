using Microsoft.AspNetCore.Mvc;
using DotNetSkillSchool.Models;

namespace DotNetSkillSchool.Controllers
{
    public class VideosController : Controller
    {
        private static List<Video> videos = new()
{
    new Video
    {
        Id = 1,
        Title = "ASP.NET Core MVC Introduction",
        YouTubeUrl = "https://www.youtube.com/embed/C5cnZ-gZy2I",
        Description = "Learn basics of MVC with a working video."
    } };
//        new Video
//    {
//        Id = 2,
//        Title = "Entity Framework Core Tutorial",
//        YouTubeUrl = "https://www.youtube.com/watch?v=lX9v7QCbKJY",
//        Description = "Step-by-step EF Core tutorial."
//    }
//};


public IActionResult Index()
        {
            return View(videos);
        }

    }
}
