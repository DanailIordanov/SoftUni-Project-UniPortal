namespace UniPortal.Web.Areas.Education.Views.Shared.Components.SubmissionCreateForm
{
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Submissions.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Submissions;

    public class SubmissionCreateFormViewComponent : ViewComponent
    {
        private readonly ISubmissionsService assignments;

        public SubmissionCreateFormViewComponent(ISubmissionsService assignments)
        {
            this.assignments = assignments;
        }

        public async Task<IViewComponentResult> InvokeAsync(string assignmentId)
        {
            return this.View("SubmissionCreateForm", new SubmissionCreateBindingModel { AssignmentId = assignmentId });
        }

    }
}
