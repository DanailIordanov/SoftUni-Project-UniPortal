namespace UniPortal.Services.Data.Assignments.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;

    public interface IAssignmentsService
    {
        Task<IQueryable<Assignment>> GetAll();

        Task<bool> Create<TBindingModel>(TBindingModel model);
    }
}
