namespace UniPortal.Web.BindingModels.Lectures
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;
    using UniPortal.Web.BindingModels.Resources;

    public class LectureCreateBindingModel : IMapFrom<Lecture>, IMapTo<Lecture>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        //public IList<ResourceCreateBindingModel> Resources { get; set; }

        [Required]
        public string CourseId { get; set; }

    }
}
