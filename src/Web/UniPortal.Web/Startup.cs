namespace UniPortal.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using UniPortal.Data;
    using UniPortal.Data.Models;
    using UniPortal.Data.Repositories;
    using UniPortal.Data.Repositories.Contracts;
    using UniPortal.Data.Seeding;
    using UniPortal.Services.Data.Assignments;
    using UniPortal.Services.Data.Assignments.Contracts;
    using UniPortal.Services.Data.Courses;
    using UniPortal.Services.Data.Courses.Contracts;
    using UniPortal.Services.Data.Lectures;
    using UniPortal.Services.Data.Lectures.Contracts;
    using UniPortal.Services.Data.Semesters;
    using UniPortal.Services.Data.Semesters.Contracts;
    using UniPortal.Services.Data.Submissions;
    using UniPortal.Services.Data.Submissions.Contracts;
    using UniPortal.Services.Data.Users;
    using UniPortal.Services.Data.Users.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Courses;
    using UniPortal.Web.ViewModels;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<UniPortalDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UniPortalUser, IdentityRole>()
                .AddEntityFrameworkStores<UniPortalDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI(UIFramework.Bootstrap4);

            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            //Data Repositories
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            //Application services
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<ISemestersService, SemestersService>();
            services.AddTransient<ILecturesService, LecturesService>();
            services.AddTransient<IAssignmentsService, AssignmentsService>();
            services.AddTransient<ISubmissionsService, SubmissionsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ErrorViewModel).Assembly,
                typeof(CourseCreateBindingModel).Assembly);

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<UniPortalDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new UniPortalDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            // app.UseExceptionHandler("/Home/Error");
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();

            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "createSubmission",
                    template: "{area:exists}/Assignments/{assignmentId}/{controller=Submissions}/{action=Create}"
                );

                routes.MapRoute(
                    name: "assignmentChildren",
                    template: "{area:exists}/Courses/{courseId}/Assignments/{assignmentId}/{controller}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "courseChildren",
                    template: "{area:exists}/Courses/{courseId}/{controller}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
