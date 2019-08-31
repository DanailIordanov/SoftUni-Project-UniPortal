namespace UniPortal.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Submissions.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Web.BindingModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissions;
        private readonly IUsersService users;

        public SubmissionsController(ISubmissionsService submissions, IUsersService users)
        {
            this.submissions = submissions;
            this.users = users;
        }

        public async Task<IActionResult> Index(string assignmentId)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubmissionCreateBindingModel bindingModel, string returnUrl = null)
        {
            if (!this.ModelState.IsValid)
            {
                this.TempData["error"] = "Something went wrong...";
                return this.LocalRedirect(returnUrl);
            }

            var user = users.GetUser(this.User.Identity.Name);

            var createIsSuccessful = await this.submissions.Create(user.Id, bindingModel);
            if (!createIsSuccessful)
            {
                this.TempData["error"] = "Something went wrong...";
            }
            else
            {
                this.TempData["success"] = "You have successfully submitted your solution";
            }

            return this.LocalRedirect(returnUrl);
        }
    }
}