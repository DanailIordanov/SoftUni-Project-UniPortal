namespace UniPortal.Web.BindingModels.Assignments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class AssignmentCreateBindingModel : IMapFrom<Assignment>, IMapTo<Assignment>
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }

        [Required]
        public int MaxPoints { get; set; }
        
        [Required]
        public string CourseId { get; set; }
    }
}
