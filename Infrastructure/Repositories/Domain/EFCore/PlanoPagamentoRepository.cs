using AutoMapper;
using Infrastructure.AutoMapper;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Standard.EFCore;

namespace Infrastructure.Repositories.Domain.EFCore
{
    public class PlanoPagamentoRepository : DomainRepository<PlanoPagamento>, IPlanoPagamentoRepository
    {
        private readonly ApplicationContext db;
        private readonly IMapper _mapper;

        public PlanoPagamentoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            db = dbContext;
            _mapper = AutoMapperConfig.RegisterMappings();
        }
    }
}
