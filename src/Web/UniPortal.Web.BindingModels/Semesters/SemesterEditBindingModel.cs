namespace UniPortal.Web.BindingModels.Semesters
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SemesterEditBindingModel : IMapFrom<Semester>, IMapTo<Semester>
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal? Fee { get; set; }

        public DateTime? OpenFrom { get; set; }

        public DateTime? OpenUntil { get; set; }

    }
}
