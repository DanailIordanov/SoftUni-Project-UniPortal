namespace UniPortal.Web.Areas.Education.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Mapping;
    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Web.ViewModels.Courses;

    [Area("Education")]
    [Authorize(Roles = "Student")]
    public class LecturesController : Controller
    {
        private readonly ICoursesService courses;

        public LecturesController(ICoursesService courses)
        {
            this.courses = courses;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            var courses = await this.courses.GetAll();

            var viewModels = courses
                .Where(c => c.Id == courseId)
                .Include(c => c.Lectures)
                .FirstOrDefault()
                .To<CourseLectureIndexViewModel>();

            return this.View(viewModels);
        }

    }
}