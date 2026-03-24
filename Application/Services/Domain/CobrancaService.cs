using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Threading.Tasks;

namespace Application.Services.Domain
{
    public class CobrancaService : ServiceBase<Cobranca>,
                               ICobrancaService
    {
        private readonly ICobrancaRepository _repository;

        public CobrancaService(ICobrancaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<Cobranca> AddAsync(Cobranca responsavel)
        {
            #region .: Validações :.

            #endregion

            var user = await _repository.AddAsync(responsavel);
            return user;
        }

        public override async Task UpdateAsync(Cobranca responsavel)
        {
            #region .: Validações :.

            #endregion

            await _repository.UpdateAsync(responsavel);
        }
    }
}
