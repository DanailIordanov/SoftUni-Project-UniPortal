namespace UniPortal.Data.Models
{
    public class StudentCourse
    {
        public string StudentId { get; set; }

        public UniPortalUser Student { get; set; }

        public string CourseId { get; set; }

        public Course Course { get; set; }

    }
}