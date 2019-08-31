namespace UniPortal.Web.ViewModels.Courses
{
    using System.Collections.Generic;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;
    using UniPortal.Web.ViewModels.Assignments;

    public class CourseAssignmentIndexViewModel : IMapFrom<Course>
    {
        public string Id { get; set; }

        public IList<AssignmentIndexViewModel> Assignments { get; set; }
    }
}
