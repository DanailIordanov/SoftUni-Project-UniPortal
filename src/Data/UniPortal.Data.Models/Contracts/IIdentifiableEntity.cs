namespace UniPortal.Data.Models.Contracts
{
    using System.ComponentModel.DataAnnotations;

    public interface IIdentifiableEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }

}
