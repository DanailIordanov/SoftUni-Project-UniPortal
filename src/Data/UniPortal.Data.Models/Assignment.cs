namespace UniPortal.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Assignment : UniPortalEntity
    {
        public Assignment()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public int MaxPoints { get; set; }

        // Submissions

        [Required]
        public AssignmentStatus Status { get; set; }

        [Required]
        public string CourseId { get; set; }

        public Course Course { get; set; }

    }
}
