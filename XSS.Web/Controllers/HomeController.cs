using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XSS.Web.Models;

namespace XSS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CommentAdd()
        {
            HttpContext.Response.Cookies.Append("email", "ahmetsahin@gmail.com");
            HttpContext.Response.Cookies.Append("password", "asdasd1A.");

            if (System.IO.File.Exists("comment.txt"))
            {
                ViewBag.comments=System.IO.File.ReadAllLines("comment.txt");
            }

            return View();
        }
        [HttpPost]
        public IActionResult CommentAdd(string name,string comment)
        {
            ViewBag.Name = name;
            ViewBag.Comment = comment;

            System.IO.File.AppendAllText("comment.txt",$"{name}-{comment}\n");
            return Redirect("CommentAdd");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}