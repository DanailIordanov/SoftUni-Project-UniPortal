namespace UniPortal.Services.Data.Submissions.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using UniPortal.Data.Models;

    public interface ISubmissionsService
    {
        Task<IQueryable<Submission>> GetAll();

        Task<bool> Create<TBindingModel>(string userId, TBindingModel model);

    }
}
