namespace UniPortal.Services.Data.Users.Contracts
{
    using UniPortal.Data.Models;

    public interface IUsersService
    {
        UniPortalUser GetUser(string username);
    }
}