using AutoMapper;
using Infrastructure.AutoMapper;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Standard.EFCore;

namespace Infrastructure.Repositories.Domain.EFCore
{
    public class CobrancaRepository : DomainRepository<Cobranca>, ICobrancaRepository
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;

        public CobrancaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            db = dbContext;
            _mapper = AutoMapperConfig.RegisterMappings();
        }
    }
}
