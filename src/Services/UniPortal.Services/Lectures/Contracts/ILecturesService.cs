namespace UniPortal.Services.Data.Lectures.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using UniPortal.Data.Models;

    public interface ILecturesService
    {
        Task<IQueryable<Lecture>> GetAll();

        Task<bool> Create<TBindingModel>(TBindingModel model);
    }
}
