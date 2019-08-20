namespace UniPortal.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Aims { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public string Location { get; set; }

        public string Room { get; set; }

        public string Language { get; set; }

        public string Requirements { get; set; }

        public string ExamType { get; set; }

        public string Certificate { get; set; }

        public UniPortalUser HeadTeacher { get; set; }

        public IList<UniPortalUser> Students { get; set; }

    }
}
