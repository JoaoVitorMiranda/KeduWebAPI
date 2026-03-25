using Domain.Models;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain.Standard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories.Domain
{
    public interface IPlanoPagamentoRepository : IDomainRepository<PlanoPagamento>
    {
        Task<IEnumerable<ValorTotalPagamentoModel>> BuscarValorTotalPagamento();
        Task<IEnumerable<PlanoPagamentoModel>> BuscarPlanosPagamentoPorIdResponsavel(int idResponsavel);
    }
}
