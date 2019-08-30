namespace UniPortal.Services.Data.Semesters
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Services.Data.Semesters.Contracts;
    using UniPortal.Services.Mapping;

    public class SemestersService : ISemestersService
    {
        private IRepository<Semester> semestersRepository;
        private IRepository<StudentSemester> studentCoursesRepository;

        public SemestersService(IRepository<Semester> semestersRepository, IRepository<StudentSemester> studentCoursesRepository)
        {
            this.semestersRepository = semestersRepository;
            this.studentCoursesRepository = studentCoursesRepository;
        }

        public async Task<IQueryable<Semester>> GetAll()
        {
            return this.semestersRepository.GetAll();
        }

        public async Task<Semester> GetById(string id)
        {
            return this.semestersRepository.GetById(id);
        }

        public async Task<bool> Create<TBindingModel>(TBindingModel bindingModel)
        {
            try
            {
                var semester = bindingModel.To<Semester>();
                semester.CreatedOn = DateTime.UtcNow;

                await this.semestersRepository.AddAsync(semester);

                await this.semestersRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update<TBindingModel>(TBindingModel model)
        {
            try
            {
                var semester = model.To<Semester>();
                semester.ModifiedOn = DateTime.UtcNow;

                this.semestersRepository.Update(semester);

                await this.semestersRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddUserTo(string semesterId, UniPortalUser user)
        {
            try
            {
                await this.studentCoursesRepository.AddAsync(new StudentSemester
                {
                    StudentId = user.Id,
                    SemesterId = semesterId,
                    PaidOn = DateTime.UtcNow
                });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
