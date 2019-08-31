namespace UniPortal.Web.BindingModels.Courses
{
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CourseJoinBindingModel : IMapFrom<Course>, IMapTo<Course>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
