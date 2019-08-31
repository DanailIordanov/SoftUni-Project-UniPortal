namespace UniPortal.Web.Areas.Internal.Views.Courses.Components.SemestersDropdown
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Services.Data.Semesters.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.ViewModels.Courses;

    public class SemestersDropdownViewComponent : ViewComponent
    {
        private ISemestersService semesters;

        public SemestersDropdownViewComponent(ISemestersService semesters)
        {
            this.semesters = semesters;
        }

        public async Task<IViewComponentResult> InvokeAsync(string semesterId)
        {
            var semesterEntities = await this.semesters.GetAll();

            var viewModels = semesterEntities.To<CourseSemesterMenuItemViewModel>().ToList();

            if (semesterId != "null")
            {
                viewModels.Where(vm => vm.Id == semesterId).FirstOrDefault().IsSelected = true;
            }

            return this.View("SemestersDropdown", viewModels);
        }

    }
}
