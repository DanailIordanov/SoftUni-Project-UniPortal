namespace UniPortal.Web.ViewModels.Courses
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CourseDetailsViewModel : IMapFrom<Course>
    {
        public string Name { get; set; }

        public string Aims { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SemesterName { get; set; }

        public string Location { get; set; }

        public string Room { get; set; }

        public string Language { get; set; }

        public string ExamType { get; set; }

        public string Requirements { get; set; }

        public string Certificate { get; set; }
    }
}
