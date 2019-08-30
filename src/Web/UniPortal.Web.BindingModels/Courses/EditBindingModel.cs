using System.Collections.Generic;
using UniPortal.Data.Models;
using UniPortal.Services.Mapping.Contracts;

namespace UniPortal.Web.BindingModels.Courses
{
    public class EditBindingModel : IMapFrom<Course>, IMapTo<Course>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Aims { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string SemesterId { get; set; }

        public string Location { get; set; }

        public string Room { get; set; }

        public string Language { get; set; }

        public string ExamType { get; set; }

        public string Requirements { get; set; }

        public string Certificate { get; set; }

        public string HeadTeacherId { get; set; }

    }
}
