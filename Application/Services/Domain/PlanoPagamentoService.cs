using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Threading.Tasks;

namespace Application.Services.Domain
{
    public class PlanoPagamentoService : ServiceBase<PlanoPagamento>,
                               IPlanoPagamentoService
    {
        private readonly IPlanoPagamentoRepository _repository;

        public PlanoPagamentoService(IPlanoPagamentoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PlanoPagamento> AddAsync(PlanoPagamento responsavel)
        {
            #region .: Validações :.

            #endregion

            var user = await _repository.AddAsync(responsavel);
            return user;
        }

        public override async Task UpdateAsync(PlanoPagamento responsavel)
        {
            #region .: Validações :.

            #endregion

            await _repository.UpdateAsync(responsavel);
        }
    }
}
