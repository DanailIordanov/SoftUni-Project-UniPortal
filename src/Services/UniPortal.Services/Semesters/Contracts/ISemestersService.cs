namespace UniPortal.Services.Data.Semesters.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using UniPortal.Data.Models;

    public interface ISemestersService
    {
        Task<IQueryable<Semester>> GetAll();

        Task<Semester> GetById(string id);

        Task<bool> Create<TBindingModel>(TBindingModel model);

        Task<bool> Update<TBindingModel>(TBindingModel model);

        Task<bool> AddUserTo(string id, UniPortalUser user);

    }
}
