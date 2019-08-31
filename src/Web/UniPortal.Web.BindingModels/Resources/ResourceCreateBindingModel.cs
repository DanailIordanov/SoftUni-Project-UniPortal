namespace UniPortal.Web.BindingModels.Resources
{
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class ResourceCreateBindingModel : IMapFrom<Resource>, IMapTo<Resource>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Required]
        public string LectureId { get; set; }
    }
}
