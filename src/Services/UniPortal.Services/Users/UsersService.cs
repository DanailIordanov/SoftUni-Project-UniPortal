namespace UniPortal.Services.Data.Users
{
    using Microsoft.AspNetCore.Identity;

    using System.Linq;

    using UniPortal.Data.Models;
    using UniPortal.Services.Data.Users.Contracts;

    public class UsersService : IUsersService
    {
        private UserManager<UniPortalUser> userManager;

        public UsersService(UserManager<UniPortalUser> userManager)
        {
            this.userManager = userManager;
        }

        public UniPortalUser GetUser(string username) => userManager.Users.FirstOrDefault(u => u.UserName == username);
    }
}
