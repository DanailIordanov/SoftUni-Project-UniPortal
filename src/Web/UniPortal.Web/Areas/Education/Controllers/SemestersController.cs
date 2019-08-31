namespace UniPortal.Web.Areas.Education.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Mapping;
    using UniPortal.Services.Data.Semesters.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Web.ViewModels.Semesters;
    using System.Collections.Generic;

    [Area("Education")]
    [Authorize(Roles = "Student")]
    public class SemestersController : Controller
    {
        private readonly ISemestersService semesters;
        private readonly IUsersService users;

        public SemestersController(ISemestersService semesters, IUsersService users)
        {
            this.semesters = semesters;
            this.users = users;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var semesters = await this.semesters.GetAll();

            IList<SemesterIndexViewModel> viewModels;

            if (User.IsInRole("Administrator"))
            {
                viewModels = semesters
               .OrderByDescending(s => s.StartDate)
               .To<SemesterIndexViewModel>()
               .ToList();
            }
            else
            {
                viewModels = semesters
                .Where(s => s.IsActive)
                .OrderByDescending(s => s.StartDate)
                .To<SemesterIndexViewModel>()
                .ToList();
            }

            return this.View(viewModels);
        }


        [HttpGet]
        public async Task<IActionResult> Pay(string id)
        {
            var user = this.users.GetUser(this.User.Identity.Name);

            var result = await this.users.AddToRoleAsync(user, "Student");
            if (!result.Succeeded)
            {
                return this.BadRequest();
            }

            await this.semesters.AddUserTo(id, user);

            return this.RedirectToAction(nameof(Index));
        }
    }
}