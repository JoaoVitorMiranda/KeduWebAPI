using Application.Interfaces.Services.Standard;
using Domain.Models;
using Infrastructure.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Domain
{
    public interface ICobrancaService : IServiceBase<Cobranca>
    {
        Task RegistrarPagamentoPorIdCobranca(RegistrarPagamentoModel obj);
        Task<int> TotalDeCobrancasPorIdResposavel(int idResposavel);
        Task<IEnumerable<ListaCobrancaResponsavelModel>> ListarCobrancaResponsavel(int idResponsavel);
    }
}
