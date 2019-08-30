namespace UniPortal.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Lecture : UniPortalEntity
    {
        public Lecture()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public IList<Resource> Resources { get; set; }

        [Required]
        public string CourseId { get; set; }

        public Course Course { get; set; }

    }
}
