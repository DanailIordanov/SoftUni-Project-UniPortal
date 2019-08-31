namespace UniPortal.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using UniPortal.Data.Models;

    public class UniPortalDbContext : IdentityDbContext<UniPortalUser>
    {
        public UniPortalDbContext(DbContextOptions<UniPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<StudentSemester> StudentSemesters { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.AttendedCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentSemester>()
                .HasKey(ss => new { ss.StudentId, ss.SemesterId });

            builder.Entity<StudentSemester>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.Semesters)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentSemester>()
                .HasOne(ss => ss.Semester)
                .WithMany(s => s.Students)
                .HasForeignKey(ss => ss.SemesterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Assignment>()
                .Property(a => a.Status)
                .HasConversion<string>();

            builder.Entity<Submission>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Submissions)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Submission>()
                .HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

        }
    }
}
