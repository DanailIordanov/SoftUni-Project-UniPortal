namespace UniPortal.Web.ViewModels.Courses
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CourseJoinViewModel : IMapFrom<Course>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string HeadTeacherTitle { get; set; }

        public string HeadTeacherFirstName { get; set; }

        public string HeadTeacherLastName { get; set; }

        public int StudentsCount { get; set; }

        public string Password { get; set; }

    }
}
