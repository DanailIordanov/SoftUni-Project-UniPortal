namespace UniPortal.Web.ViewModels.Courses
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CourseSemesterMenuItemViewModel : IMapFrom<Semester>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

    }
}
