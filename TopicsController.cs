using Microsoft.AspNetCore.Mvc;
using DotNetSkillSchool.Models;

namespace DotNetSkillSchool.Controllers
{
    public class TopicsController : Controller
    {
        public IActionResult Index(string topic)
        {
            ViewBag.SelectedTopic = topic;
            return View();
        }
    }
}
