namespace UniPortal.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using UniPortal.Data.Models.Contracts;

    public class UniPortalUser : IdentityUser, IIdentifiableEntity<string>, IAuditInfo
    {
        public UniPortalUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        public IList<StudentCourse> AttendedCourses { get; set; }

        public IList<Course> ToughtCourses { get; set; }
        
        public IList<StudentSemester> Semesters { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
