using AutoMapper;
using Infrastructure.AutoMapper;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Standard.EFCore;

namespace Infrastructure.Repositories.Domain.EFCore
{
    public class CentroDeCustoRepository : DomainRepository<CentroDeCusto>, ICentroDeCustoRepository
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;

        public CentroDeCustoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            db = dbContext;
            _mapper = AutoMapperConfig.RegisterMappings();
        }
    }
}
