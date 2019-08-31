namespace UniPortal.Web.ViewModels.Semesters
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SemesterStudentIndexViewModel : IMapFrom<StudentSemester>
    {
        string StudentId { get; set; }
    }
}
