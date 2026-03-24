using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Threading.Tasks;

namespace Application.Services.Domain
{
    public class ResponsavelFinanceiroService : ServiceBase<ResponsavelFinanceiro>,
                               IResponsavelFinanceiroService
    {
        private readonly IResponsavelFinanceiroRepository _repository;

        public ResponsavelFinanceiroService(IResponsavelFinanceiroRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<ResponsavelFinanceiro> AddAsync(ResponsavelFinanceiro responsavel)
        {
            #region .: Validações :.

            #endregion

            var user = await _repository.AddAsync(responsavel);
            return user;
        }

        public override async Task UpdateAsync(ResponsavelFinanceiro responsavel)
        {
            #region .: Validações :.

            #endregion

            await _repository.UpdateAsync(responsavel);
        }
    }
}
