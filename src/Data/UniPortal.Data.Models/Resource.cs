using System.ComponentModel.DataAnnotations;

namespace UniPortal.Data.Models
{
    public class Resource : UniPortalEntity
    {
        public Resource()
            : base()
        {
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required]
        public string LectureId { get; set; }

        public Lecture Lecture { get; set; }
    }
}