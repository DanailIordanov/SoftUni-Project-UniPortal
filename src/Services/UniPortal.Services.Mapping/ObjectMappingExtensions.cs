namespace UniPortal.Services.Mapping
{
    using UniPortal.Data.Common;

    public static class ObjectMappingExtensions
    {
        public static TModel To<TModel>(this object source)
        {
            Validator.ThrowIfNull(source, nameof(source));

            return AutoMapperConfig.MapperInstance.Map<TModel>(source);
        }
    }
}
