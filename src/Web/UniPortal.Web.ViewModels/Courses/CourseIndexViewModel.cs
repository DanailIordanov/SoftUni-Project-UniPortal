namespace UniPortal.Web.ViewModels.Courses
{
    using System.Collections.Generic;
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CourseIndexViewModel : IMapFrom<Course>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool SemesterIsActive { get; set; }

        public string Location { get; set; }

        public string Room { get; set; }

        public string HeadTeacherTitle { get; set; }

        public string HeadTeacherUsername { get; set; }

        public string HeadTeacherFirstName { get; set; }

        public string HeadTeacherLastName { get; set; }

        public IList<CourseStudentIndexViewModel> Students { get; set; }

        public int StudentsCount { get; set; }

    }
}
