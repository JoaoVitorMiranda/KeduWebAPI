using Domain.Models;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain.Standard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories.Domain
{
    public interface ICobrancaRepository : IDomainRepository<Cobranca>
    {
        Task<int> TotalDeCobrancasPorIdResposavel(int idResposavel);
        Task<IEnumerable<ListaCobrancaResponsavelModel>> ListarCobrancaResponsavel(int idResposavel);
    }
}
