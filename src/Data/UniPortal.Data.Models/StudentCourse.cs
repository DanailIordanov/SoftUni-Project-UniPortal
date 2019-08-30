using UniPortal.Data.Models.Contracts;

namespace UniPortal.Data.Models
{
    public class StudentCourse : IIdentifiableEntity
    {
        public string StudentId { get; set; }

        public UniPortalUser Student { get; set; }

        public string CourseId { get; set; }

        public Course Course { get; set; }

        //public string GradeId { get; set; }

        //public Grade Grade { get; set; }

    }
}