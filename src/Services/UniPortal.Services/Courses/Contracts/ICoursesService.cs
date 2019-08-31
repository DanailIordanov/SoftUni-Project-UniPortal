namespace UniPortal.Services.Data.Courses.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;

    public interface ICoursesService
    {
        Task<IQueryable<Course>> GetAll();

        Task<bool> Create<TBindingModel>(string userId, TBindingModel serviceModel);

        Task<bool> Join(UniPortalUser user, string courseId);

        Task<Course> GetById(string courseId);

        Task<bool> Update<TBindingModel>(TBindingModel bindingModel);

        Task<bool> Delete(string id);
    }
}
