namespace UniPortal.Services.Data.Users.Contracts
{
    using Microsoft.AspNetCore.Identity;

    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;

    public interface IUsersService
    {
        UniPortalUser GetUser(string username);

        Task<IQueryable<UniPortalUser>> GetAll();

        Task<IdentityResult> AddToRoleAsync(UniPortalUser user, string role);
    }
}