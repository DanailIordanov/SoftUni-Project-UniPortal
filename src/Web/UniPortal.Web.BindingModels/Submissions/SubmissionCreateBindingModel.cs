namespace UniPortal.Web.BindingModels.Submissions
{
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SubmissionCreateBindingModel : IMapFrom<Submission>, IMapTo<Submission>
    {
        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required]
        public string AssignmentId { get; set; }

    }
}
