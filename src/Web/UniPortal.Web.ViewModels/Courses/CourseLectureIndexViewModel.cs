namespace UniPortal.Web.ViewModels.Courses
{
    using System.Collections.Generic;

    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;
    using UniPortal.Web.ViewModels.Lectures;

    public class CourseLectureIndexViewModel : IMapFrom<Course>
    {
        public string Id { get; set; }

        public IList<LectureIndexViewModel> Lectures { get; set; }
    }
}
