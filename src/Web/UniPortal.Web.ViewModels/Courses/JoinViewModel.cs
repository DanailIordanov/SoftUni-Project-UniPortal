namespace UniPortal.Web.ViewModels.Courses
{
    using System;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class JoinViewModel : IMapFrom<Course>, IMapTo<Course>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public string Location { get; set; }

        public string Room { get; set; }

        public string HeadTeacherTitle { get; set; }

        public string HeadTeacherFirstName { get; set; }

        public string HeadTeacherLastName { get; set; }

        public int StudentsCount { get; set; }

        public string Password { get; set; }

    }
}
