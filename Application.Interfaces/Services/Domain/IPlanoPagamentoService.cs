using Application.Interfaces.Services.Standard;
using Domain.Models;
using Infrastructure.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Domain
{
    public interface IPlanoPagamentoService : IServiceBase<PlanoPagamento>
    {
        Task<IEnumerable<ValorTotalPagamentoModel>> BuscarValorTotalPagamento();
        Task<IEnumerable<PlanoPagamentoModel>> BuscarPlanosPagamentoPorIdResponsavel(int idResponsavel);
    }
}
