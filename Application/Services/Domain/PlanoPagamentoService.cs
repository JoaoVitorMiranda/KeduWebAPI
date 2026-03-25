using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Domain.Models;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                #region .: Validações :.
                decimal valorTotal = responsavel.Cobranca.Sum(x => x.Valor);
                responsavel.ValorTotalPlano = valorTotal;
                #endregion

                var user = await _repository.AddAsync(responsavel);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ValorTotalPagamentoModel>> BuscarValorTotalPagamento()
        {
            return await _repository.BuscarValorTotalPagamento();
        }

        public async Task<IEnumerable<PlanoPagamentoModel>> BuscarPlanosPagamentoPorIdResponsavel(int idResponsavel)
        {
            return await _repository.BuscarPlanosPagamentoPorIdResponsavel(idResponsavel);
        }
    }
}
