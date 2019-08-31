namespace UniPortal.Services.Data.Assignments
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Services.Mapping;

    public class AssignmentsService : IAssignmentsService
    {
        private IRepository<Assignment> assignmentsRepository;

        public AssignmentsService(IRepository<Assignment> assignmentsRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
        }

        public async Task<IQueryable<Assignment>> GetAll()
        {
            return this.assignmentsRepository.GetAll();
        }

        public async Task<bool> Create<TBindingModel>(TBindingModel model)
        {
            try
            {
                var assignment = model.To<Assignment>();
                assignment.CreatedOn = DateTime.UtcNow;
                assignment.Status = AssignmentStatus.New;

                await this.assignmentsRepository.AddAsync(assignment);

                await this.assignmentsRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
