namespace UniPortal.Web.Areas.Internal.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Web.BindingModels.Assignments;

    [Area("Internal")]
    [Authorize(Roles = "Teacher")]
    public class AssignmentsController : Controller
    {
        private IAssignmentsService assignments;

        public AssignmentsController(IAssignmentsService assignments)
        {
            this.assignments = assignments;
        }

        [HttpGet]
        public async Task<IActionResult> Create(string courseId)
        {
            return this.View(new AssignmentCreateBindingModel { CourseId = courseId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignmentCreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var createIsSuccessful = await this.assignments.Create(bindingModel);
            if (!createIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction("Index", "Courses", new { area = "Education" });
        }

    }
}