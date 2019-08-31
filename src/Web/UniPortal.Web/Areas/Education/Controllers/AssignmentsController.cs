namespace UniPortal.Web.Areas.Education.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.ViewModels.Assignments;
    using UniPortal.Web.ViewModels.Courses;

    [Area("Education")]
    [Authorize(Roles = "Student")]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentsService assignments;
        private readonly ICoursesService courses;

        public AssignmentsController(IAssignmentsService assignments, ICoursesService courses)
        {
            this.assignments = assignments;
            this.courses = courses;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string courseId)
        {
            var courses = await this.courses.GetAll();

            var viewModel = courses
                .Where(c => c.Id == courseId)
                .Include(c => c.Assignments)
                .FirstOrDefault()
                .To<CourseAssignmentIndexViewModel>();

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var assignments = await this.assignments.GetAll();

            var viewModel = assignments
                .Where(a => a.Id == id)
                .Include(a => a.Course)
                .Include(a => a.Submissions)
                .ThenInclude(s => s.Student)
                .FirstOrDefault()
                .To<AssignmentDetailsViewModel>();

            return this.View(viewModel);
        }

    }
}