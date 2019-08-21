namespace UniPortal.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using UniPortal.Data.Common.Models.Contracts;

    public abstract class UniPortalEntity : IIdentifiableEntity<string>, IAuditInfo
    {
        protected UniPortalEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
