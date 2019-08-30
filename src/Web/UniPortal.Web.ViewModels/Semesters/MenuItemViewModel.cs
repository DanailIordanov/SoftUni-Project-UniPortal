using UniPortal.Data.Models;
using UniPortal.Services.Mapping.Contracts;

namespace UniPortal.Web.ViewModels.Semesters
{
    public class MenuItemViewModel : IMapFrom<Semester>, IMapTo<Semester>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }

    }
}
