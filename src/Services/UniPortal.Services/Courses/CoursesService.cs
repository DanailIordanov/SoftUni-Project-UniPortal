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
        private IRepository<Course> coursesRepository;
        private IRepository<StudentCourse> studentCoursesRepository;

        public CoursesService(IRepository<Course> coursesRepository, IRepository<StudentCourse> studentCourses)
        {
            this.coursesRepository = coursesRepository;
            this.studentCoursesRepository = studentCourses;
        }

        public async Task<IQueryable<Course>> GetAll()
        {
            return this.coursesRepository.GetAll();
        }

        public async Task<Course> GetById(string id)
        {
            return this.coursesRepository.GetById(id);
        }

        public async Task<bool> Create<TBindingModel>(string userId, TBindingModel bindingModel)
        {
            try
            {
                var course = bindingModel.To<Course>();
                course.HeadTeacherId = userId;
                course.CreatedOn = DateTime.UtcNow;

                await this.coursesRepository.AddAsync(course);

                await this.coursesRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Join(UniPortalUser user, string courseId)
        {
            var course = this.coursesRepository.GetById(courseId);

            try
            {
                await studentCoursesRepository.AddAsync(new StudentCourse
                {
                    StudentId = user.Id,
                    CourseId = courseId,
                });

                await studentCoursesRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update<TBindingModel>(TBindingModel bindingModel)
        {
            try
            {
                var course = bindingModel.To<Course>();
                course.ModifiedOn = DateTime.UtcNow;

                this.coursesRepository.Update(course);

                await this.coursesRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var course = this.coursesRepository.GetById(id);

            this.coursesRepository.Delete(course);

            try
            {
                await this.coursesRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
