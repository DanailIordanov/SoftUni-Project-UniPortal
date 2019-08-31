namespace UniPortal.Web.ViewModels.Resources
{
    using UniPortal.Data.Models;
    using UniPortal.Services.Mapping.Contracts;

    public class ResourceIndexViewModel : IMapFrom<Resource>
    {
        public string Name { get; set; }

        public string Url { get; set; }

    }
}
