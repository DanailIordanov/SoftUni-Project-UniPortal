namespace UniPortal.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System;

    using UniPortal.Data.Models.Contracts;

    public class UniPortalUser : IdentityUser, IIdentifiableEntity<string>, IAuditInfo
    {
        public UniPortalUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
