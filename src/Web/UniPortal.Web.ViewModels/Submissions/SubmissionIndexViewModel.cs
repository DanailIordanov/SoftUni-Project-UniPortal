namespace UniPortal.Web.ViewModels.Submissions
{
    using System;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SubmissionIndexViewModel : IMapFrom<Submission>
    {
        public string Name { get; set; }

        public string Comment { get; set; }

        public string Url { get; set; }

        public DateTime CreatedOn { get; set; }

        public string StudentId { get; set; }
        
        public string StudentTitle { get; set; }
        
        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

    }
}
