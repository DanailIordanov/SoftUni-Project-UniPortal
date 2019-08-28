namespace UniPortal.Services.Data.Courses
{
    using System.Threading.Tasks;
    using System.Linq;

    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Mapping;
    using System;
    using System.Collections.Generic;

    public class CoursesService : ICoursesService
    {
        private IRepository<Course> repository;

        public CoursesService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<IQueryable<Course>> GetAll()
        {
            return this.repository.GetAll();
        }

        public async Task<Course> GetById(string id)
        {
            return this.repository.GetById(id);
        }

        public async Task<bool> Create<TBindingModel>(string userId, TBindingModel bindingModel)
        {
            try
            {
                var course = bindingModel.To<Course>();
                course.HeadTeacherId = userId;
                course.CreatedOn = DateTime.UtcNow;

                await this.repository.AddAsync(course);

                await this.repository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Join(UniPortalUser user, string courseId)
        {
            var course = this.repository.GetById(courseId);

            course.Students.Add(new StudentCourse
            {
                StudentId = user.Id,
                CourseId = courseId,
            });

            return true;
        }
    }
}
