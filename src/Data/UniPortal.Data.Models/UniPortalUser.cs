namespace UniPortal.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class UniPortalUser : IdentityUser
    {
        public UniPortalUser()
        {
        }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
