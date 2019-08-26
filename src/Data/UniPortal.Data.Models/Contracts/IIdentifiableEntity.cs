namespace UniPortal.Data.Models.Contracts
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public interface IIdentifiableEntity
    {
    }

    public interface IIdentifiableEntity<TKey> : IIdentifiableEntity
    {
        [Key]
        TKey Id { get; set; }
    }

}
