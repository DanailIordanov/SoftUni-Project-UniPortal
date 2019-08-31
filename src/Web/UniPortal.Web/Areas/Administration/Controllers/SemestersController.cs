namespace UniPortal.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using UniPortal.Services.Data.Semesters.Contracts;
    using UniPortal.Services.Mapping;
    using UniPortal.Web.BindingModels.Semesters;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class SemestersController : Controller
    {
        private readonly ISemestersService semesters;

        public SemestersController(ISemestersService semesters)
        {
            this.semesters = semesters;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SemesterCreateBindingModel bindingModel)
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

            return this.RedirectToAction("Index", "Semesters", new { area = "Education" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var semester = await this.semesters.GetById(id);

            return this.View(semester.To<SemesterEditBindingModel>());
        }

        public async Task<IActionResult> Edit(SemesterEditBindingModel bindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel);
            }

            var editIsSuccessful = await this.semesters.Update(bindingModel);
            if (!editIsSuccessful)
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong...");

                return this.View(bindingModel);
            }

            return this.RedirectToAction("Index", "Semesters", new { area = "Education" });
        }

        [HttpGet]
        public async Task<IActionResult> Activate(string id, string returnUrl = null)
        {
            var isSuccessful = await this.semesters.Activate(id);
            if (!isSuccessful)
            {
                return this.BadRequest();
            }

            returnUrl = returnUrl ?? this.HttpContext.Request.Headers["Referer"];

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Delete(string id, string returnUrl = null)
        {
            var isSuccessful = await this.semesters.Delete(id);
            if (!isSuccessful)
            {
                return this.BadRequest();
            }

            returnUrl = returnUrl ?? this.HttpContext.Request.Headers["Referer"];

            return Redirect(returnUrl);
        }

    }
}