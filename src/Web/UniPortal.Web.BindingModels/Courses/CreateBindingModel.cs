namespace UniPortal.Web.BindingModels.Courses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class CreateBindingModel : IMapFrom<Course>, IMapTo<Course>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Aims { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

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
    }
}
