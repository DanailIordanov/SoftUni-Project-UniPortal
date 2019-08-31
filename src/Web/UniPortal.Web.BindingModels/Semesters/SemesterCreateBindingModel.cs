namespace UniPortal.Web.BindingModels.Semesters
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SemesterCreateBindingModel : IMapTo<Semester>, IMapFrom<Semester>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Fee { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OpenFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? OpenUntil { get; set; }

    }
}
