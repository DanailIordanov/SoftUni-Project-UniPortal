namespace UniPortal.Services.Data.Submissions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Services.Data.Submissions.Contracts;
    using UniPortal.Services.Mapping;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly IRepository<Submission> submissionsRepository;

        public SubmissionsService(IRepository<Submission> submissionsRepository)
        {
            this.submissionsRepository = submissionsRepository;
        }

        public async Task<IQueryable<Submission>> GetAll()
        {
            return this.submissionsRepository.GetAll();
        }

        public async Task<bool> Create<TBindingModel>(string userId, TBindingModel model)
        {
            try
            {
                var submission = model.To<Submission>();
                submission.CreatedOn = DateTime.UtcNow;
                submission.StudentId = userId;

                await this.submissionsRepository.AddAsync(submission);

                await this.submissionsRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
