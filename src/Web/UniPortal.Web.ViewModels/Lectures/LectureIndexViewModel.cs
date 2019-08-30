namespace UniPortal.Web.ViewModels.Lectures
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class LectureIndexViewModel : IMapFrom<Lecture>, IMapTo<Lecture>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

    }
}
