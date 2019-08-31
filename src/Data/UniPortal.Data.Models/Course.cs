namespace UniPortal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course : UniPortalEntity
    {
        public Course()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Aims { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        public string SemesterId { get; set; }

        public Semester Semester { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string ExamType { get; set; }

        public string Requirements { get; set; }

        public string Certificate { get; set; }

        public string Password { get; set; }

        [Required]
        public string HeadTeacherId { get; set; }

        public UniPortalUser HeadTeacher { get; set; }

        public IList<StudentCourse> Students { get; set; }

        public IList<Lecture> Lectures { get; set; }

        public IList<Assignment> Assignments { get; set; }

    }
}
