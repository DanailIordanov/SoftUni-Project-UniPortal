namespace UniPortal.Web.Areas.Internal.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using UniPortal.Services.Mapping;
    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Web.BindingModels.Courses;

    [Area("Internal")]
    [Authorize(Roles = "Teacher")]
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
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateBindingModel bindingModel)
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

            return this.RedirectToAction("Index", "Courses", new { area = "Education" });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var course = await this.courses.GetById(id);

            return this.View(course.To<CourseEditBindingModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseEditBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            bool editIsSuccessful = await this.courses.Update(bindingModel);
            if (!editIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction("Index", "Courses", new { area = "Education" });
        }

        public async Task<IActionResult> Delete(string id, string returnUrl = null)
        {
            var isSuccessful = await this.courses.Delete(id);
            if (!isSuccessful)
            {
                return this.BadRequest();
            }

            returnUrl = returnUrl ?? this.HttpContext.Request.Headers["Referer"];

            return Redirect(returnUrl);
        }

    }
}