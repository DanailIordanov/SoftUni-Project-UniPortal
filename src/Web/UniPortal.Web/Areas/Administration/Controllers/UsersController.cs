namespace UniPortal.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Mapping;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Web.ViewModels.Users;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public async Task<IActionResult> Manage()
        {
            var users = await this.users.GetAll();

            var viewModel = users
                .Where(u => u.UserName != this.User.Identity.Name)
                .To<UserManageViewModel>();

            return View();
        }
    }
}