namespace UniPortal.Web.Areas.Internal.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using UniPortal.Services.Data.Lectures.Contracts;
    using UniPortal.Web.BindingModels.Lectures;

    [Area("Internal")]
    [Authorize(Roles = "Teacher")]
    public class LecturesController : Controller
    {
        private readonly ILecturesService lectures;

        public LecturesController(ILecturesService lectures)
        {
            this.lectures = lectures;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            return this.View(new LectureCreateBindingModel { CourseId = courseId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(LectureCreateBindingModel bindingModel)
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

            return this.RedirectToAction("Index", "Courses", new { area = "Education" });
        }

    }
}