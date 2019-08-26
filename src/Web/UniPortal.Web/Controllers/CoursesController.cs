namespace UniPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CoursesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}