using UniPortal.Data.Models;
using UniPortal.Services.Mapping.Contracts;

namespace UniPortal.Web.ViewModels.Courses
{
    public class CourseStudentIndexViewModel : IMapFrom<StudentCourse>
    {
        public string StudentUsername { get; set; }
    }
}
