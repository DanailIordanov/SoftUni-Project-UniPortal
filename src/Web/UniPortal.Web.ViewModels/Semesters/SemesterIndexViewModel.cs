namespace UniPortal.Web.ViewModels.Semesters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class SemesterIndexViewModel : IMapFrom<Semester>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Fee { get; set; }

        public DateTime? OpenFrom { get; set; }

        public DateTime? OpenUntil { get; set; }

        public IList<SemesterStudentIndexViewModel> Students { get; set; }

        public bool IsActive { get; set; }

        public bool IsOpen => this.OpenFrom != null 
            ? DateTime.Compare(this.OpenFrom.Value, DateTime.UtcNow) >= 0 
                && DateTime.Compare(this.OpenFrom.Value, DateTime.UtcNow) <= 0
            : false;

    }
}
