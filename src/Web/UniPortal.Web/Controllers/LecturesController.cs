namespace UniPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Mapping;
    using UniPortal.Services.Data.Lectures.Contracts;
    using UniPortal.Web.BindingModels.Lectures;
    using UniPortal.Web.ViewModels.Lectures;
    using UniPortal.Services.Data.Courses.Contracts;

    public class LecturesController : Controller
    {
        private ICoursesService courses;
        private ILecturesService lectures;

        public LecturesController(ICoursesService courses, ILecturesService lectures)
        {
            this.courses = courses;
            this.lectures = lectures;
        }

        public async Task<IActionResult> Index(string courseId)
        {
            var lectures = await this.lectures.GetAll();

            var viewModels = lectures
                .Where(l => l.CourseId == courseId)
                .Include(l => l.Course)
                .To<LectureIndexViewModel>();

            return this.View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            return this.View(new CreateBindingModel { CourseId = courseId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var createIsSuccessful = await this.lectures.Create(bindingModel);
            if (!createIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction(nameof(Index));
        }
    }
}