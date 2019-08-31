namespace UniPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Assignments;
    using UniPortal.Web.ViewModels.Assignments;

    public class AssignmentsController : Controller
    {
        private IAssignmentsService assignments;

        public AssignmentsController(IAssignmentsService assignments)
        {
            this.assignments = assignments;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string courseId)
        {
            var assignments = await this.assignments.GetAll();

            var viewModels = assignments
                .Where(a => a.CourseId == courseId)
                .Include(l => l.Course)
                .To<AssignmentIndexViewModel>();

            return this.View(viewModels);
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

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var assignments = await this.assignments.GetAll();

            var viewModel = assignments
                .Where(a => a.Id == id)
                .Include(a => a.Course)
                .FirstOrDefault()
                .To<AssignmentDetailsViewModel>();

            return this.View(viewModel);
        }

    }
}