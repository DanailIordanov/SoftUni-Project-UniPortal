namespace UniPortal.Web.Areas.Education.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Courses;
    using UniPortal.Web.ViewModels.Courses;

    [Area("Education")]
    [Authorize(Roles = "Student")]
    public class CoursesController : Controller
    {
        private readonly ICoursesService courses;
        private readonly IUsersService users;

        public CoursesController(ICoursesService courses, IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await this.courses.GetAll();

            var viewModels = courses
                .Include(c => c.Semester)
                .Include(c => c.Students)
                .Include(c => c.HeadTeacher)
                .To<CourseIndexViewModel>()
                .ToList();

            return this.View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var courses = await this.courses.GetAll();

            var viewModel = courses
                .Where(c => c.Id == id)
                .Include(c => c.Semester)
                .FirstOrDefault()
                .To<CourseDetailsViewModel>();

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Join(string id)
        {
            var courses = await this.courses.GetAll();

            var viewModel = courses
                .Where(c => c.Id == id)
                .Include(c => c.HeadTeacher)
                .FirstOrDefault()
                .To<CourseJoinViewModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Join(CourseJoinBindingModel bindingModel)
        {
            var course = await this.courses.GetById(bindingModel.Id);

            if (bindingModel.Password != course.Password)
            {
                this.ModelState.AddModelError("Password", "The password is invalid. Please try again!");

                return this.View(course.To<CourseJoinViewModel>());
            }

            var user = this.users.GetUser(this.User.Identity.Name);

            await courses.Join(user, bindingModel.Id);

            return this.RedirectToAction("Index");
        }

    }
}