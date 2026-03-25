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
using static Domain.Enumerados;

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

        public async Task<int> TotalDeCobrancasPorIdResposavel(int idResposavel)
        {
            var valorTotal = await db.Cobranca
                .AsNoTracking()
                 .Include(x => x.PlanoPagamento)
                 .CountAsync(x => x.PlanoPagamento.IdResponsavelFinanceiro == idResposavel);

            return valorTotal;
        }

        public async Task<IEnumerable<ListaCobrancaResponsavelModel>> ListarCobrancaResponsavel(int idResponsavel)
        {
            var cobrancas = await db.Cobranca
                .AsNoTracking()
                  .Where(x => x.PlanoPagamento.IdResponsavelFinanceiro == idResponsavel)
                 .Include(x => x.PlanoPagamento)
                   .Select(x => new ListaCobrancaResponsavelModel
                   {
                       Plano = x.PlanoPagamento.Id,
                       Valor = x.Valor,
                       DataVencimento = x.DataVencimento,
                       MetodoPagamento = (MetodoPagamento)x.MetodoPagamento,
                       Status = (StatusCobranca)x.Status,
                       CodigoPagamento = x.CodigoPagamento
                   })
                 .ToListAsync();


            return _mapper.Map<IEnumerable<ListaCobrancaResponsavelModel>>(cobrancas);
        }
    }
}
