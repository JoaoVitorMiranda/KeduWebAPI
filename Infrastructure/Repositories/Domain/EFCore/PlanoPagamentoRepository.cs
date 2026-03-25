using AutoMapper;
using Domain.Models;
using Infrastructure.AutoMapper;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<IEnumerable<ValorTotalPagamentoModel>> BuscarValorTotalPagamento()
        {
            var valorTotal = await db.PlanoPagamento
                .AsNoTracking()
                .Select(x => new ValorTotalPagamentoModel
                {
                    ValorTotalPagamento = x.ValorTotalPlano,
                    IdPlanoPagamento = x.Id
                })
                .ToListAsync();

            return valorTotal;
        }

        public async Task<IEnumerable<PlanoPagamentoModel>> BuscarPlanosPagamentoPorIdResponsavel(int idResponsavel)
        {
            var planosPagamento = await db.PlanoPagamento
                .AsNoTracking()
                .Where(x => x.IdResponsavelFinanceiro == idResponsavel)
                .Include(x => x.Cobranca)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PlanoPagamentoModel>>(planosPagamento);
        }
    }
}
