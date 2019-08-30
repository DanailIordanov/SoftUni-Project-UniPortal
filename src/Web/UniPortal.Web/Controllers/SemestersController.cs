using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using UniPortal.Services.Mapping;
using UniPortal.Services.Data.Semesters.Contracts;
using UniPortal.Services.Data.Users.Contracts;
using UniPortal.Web.BindingModels.Semesters;
using UniPortal.Web.ViewModels.Semesters;

namespace UniPortal.Web.Controllers
{
    public class SemestersController : Controller
    {
        private ISemestersService semesters;
        private IUsersService users;

        public SemestersController(ISemestersService semesters, IUsersService users)
        {
            this.semesters = semesters;
            this.users = users;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var semesters = this.semesters
                .GetAll()
                .GetAwaiter()
                .GetResult()
                .To<IndexViewModel>()
                .ToList();

            return this.View(semesters);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var createIsSuccessful = await this.semesters.Create(bindingModel);
            if (!createIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var semester = await this.semesters.GetById(id);

            return this.View(semester.To<EditBindingModel>());
        }

        public async Task<IActionResult> Edit(EditBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var editIsSuccessful = await this.semesters.Update(bindingModel);
            if(!editIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Pay(string id)
        {
            var user = users.GetUser(this.User.Identity.Name);

            await this.semesters.AddUserTo(id, user);
            
            //TODO if successful add user to role Student

            return this.RedirectToAction(nameof(Index));
        }
    }
}