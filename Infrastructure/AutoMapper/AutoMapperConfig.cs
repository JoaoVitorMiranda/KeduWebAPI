using AutoMapper;
using AutoMapper.Internal;

namespace Infrastructure.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.Internal().MethodMappingEnabled = false;
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });

            return config.CreateMapper();
        }
    }
}
