namespace UniPortal.Data.Models
{
    using System;
    using UniPortal.Data.Models.Contracts;

    public class StudentSemester : IIdentifiableEntity
    {
        public string StudentId { get; set; }
        
        public UniPortalUser Student { get; set; }

        public string SemesterId { get; set; }

        public Semester Semester { get; set; }

        public DateTime PaidOn { get; set; }

    }
}