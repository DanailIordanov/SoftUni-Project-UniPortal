namespace UniPortal.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Semester : UniPortalEntity
    {
        public Semester()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Fee { get; set; }

        public DateTime? OpenFrom { get; set; }

        public DateTime? OpenUntil { get; set; }

        public IList<StudentSemester> Students { get; set; }

        public bool IsActive { get; set; }

        public IList<Course> Courses { get; set; }

    }
}
