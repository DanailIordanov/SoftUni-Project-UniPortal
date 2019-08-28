namespace UniPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Courses;
    using UniPortal.Web.ViewModels.Courses;

    public class CoursesController : Controller
    {
        private ICoursesService courses;
        private IUsersService users;

        public CoursesController(ICoursesService courses, IUsersService users)
        {
            this.courses = courses;
            this.users = users;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = this.courses
                .GetAll()
                .GetAwaiter()
                .GetResult()
                .To<IndexViewModel>()
                .ToList();

            return this.View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var user = this.users.GetUser(this.User.Identity.Name);

            var createIsSuccessful = await this.courses.Create(user.Id, bindingModel);
            if (!createIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "There is such course already!");

                return this.View(bindingModel);
            }

            return this.RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Join(string id)
        {
            var viewModel = this.courses
                .GetAll()
                .GetAwaiter()
                .GetResult()
                .Where(c => c.Id == id)
                .Include(c => c.HeadTeacher)
                .FirstOrDefault()
                .To<JoinViewModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Join(JoinBindingModel bindingModel)
        {
            var course = await this.courses.GetById(bindingModel.Id);

            if (bindingModel.Password != course.Password)
            {
                this.ModelState.AddModelError("Password", "The password is invalid. Please try again!");

                return this.View(course.To<JoinViewModel>());
            }

            var user = this.users.GetUser(this.User.Identity.Name);

            await courses.Join(user, bindingModel.Id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = this.courses
                .GetById(id)
                .GetAwaiter()
                .GetResult()
                .To<DetailsViewModel>();

            return this.View(viewModel);
        }

    }
}