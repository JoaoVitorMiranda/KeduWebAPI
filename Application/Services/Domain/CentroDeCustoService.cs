using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Threading.Tasks;

namespace Application.Services.Domain
{
    public class CentroDeCustoService : ServiceBase<CentroDeCusto>,
                               ICentroDeCustoService
    {
        private readonly ICentroDeCustoRepository _repository;

        public CentroDeCustoService(ICentroDeCustoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<CentroDeCusto> AddAsync(CentroDeCusto responsavel)
        {
            #region .: Validações :.

            #endregion

            var user = await _repository.AddAsync(responsavel);
            return user;
        }

        public override async Task UpdateAsync(CentroDeCusto responsavel)
        {
            #region .: Validações :.

            #endregion

            await _repository.UpdateAsync(responsavel);
        }
    }
}
