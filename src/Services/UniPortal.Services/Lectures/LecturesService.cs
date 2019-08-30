namespace UniPortal.Services.Data.Lectures
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Services.Data.Lectures.Contracts;
    using UniPortal.Services.Mapping;

    public class LecturesService : ILecturesService
    {
        private IRepository<Lecture> lecturesRepository;

        public LecturesService(IRepository<Lecture> lecturesRepository)
        {
            this.lecturesRepository = lecturesRepository;
        }

        public async Task<IQueryable<Lecture>> GetAll()
        {
            return this.lecturesRepository.GetAll();
        }

        public async Task<bool> Create<TBindingModel>(TBindingModel model)
        {
            try
            {
                var lecture = model.To<Lecture>();
                lecture.CreatedOn = DateTime.UtcNow;

                await this.lecturesRepository.AddAsync(lecture);

                await this.lecturesRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
