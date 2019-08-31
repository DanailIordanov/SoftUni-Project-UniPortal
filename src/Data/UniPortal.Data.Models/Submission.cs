namespace UniPortal.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Submission : UniPortalEntity
    {
        [Required]
        public string Name { get; set; }

        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required]
        public string AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        [Required]
        public string StudentId { get; set; }

        public UniPortalUser Student { get; set; } 

    }
}
