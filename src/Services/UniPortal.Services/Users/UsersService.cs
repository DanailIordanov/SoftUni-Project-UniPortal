namespace UniPortal.Services.Data.Users
{
    using Microsoft.AspNetCore.Identity;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;
    using UniPortal.Services.Data.Users.Contracts;

    public class UsersService : IUsersService
    {
        private UserManager<UniPortalUser> userManager;

        public UsersService(UserManager<UniPortalUser> userManager)
        {
            this.userManager = userManager;
        }

        public Task<IdentityResult> AddToRoleAsync(UniPortalUser user, string role) => this.userManager.AddToRoleAsync(user, role);

        public UniPortalUser GetUser(string username) => this.userManager.Users.FirstOrDefault(u => u.UserName == username);

        public async Task<IQueryable<UniPortalUser>> GetAll() => this.userManager.Users;

    }
}
