namespace UniPortal.Web.Areas.Education.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Services.Data.Submissions.Contracts;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Web.BindingModels.Submissions;

    [Area("Education")]
    [Authorize(Roles = "Student")]
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissions;
        private readonly IUsersService users;
        private readonly IAssignmentsService assignments;

        public SubmissionsController(ISubmissionsService submissions, IUsersService users, IAssignmentsService assignments)
        {
            this.submissions = submissions;
            this.users = users;
            this.assignments = assignments;
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

            returnUrl = returnUrl ?? this.HttpContext.Request.Headers["Referer"];

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