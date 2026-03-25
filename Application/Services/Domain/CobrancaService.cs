using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Domain.Models;
using Infrastructure.Domain.Entities;
using Infrastructure.Interfaces.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Domain.Enumerados;

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

        public async Task RegistrarPagamentoPorIdCobranca(RegistrarPagamentoModel obj)
        {
            var cobranca = await _repository.GetByIdAsync(obj.IdCobranca);

            if (cobranca.Valor == obj.Valor)
            {
                cobranca.DataVencimento = obj.Data;
                cobranca.Status = (int)StatusCobranca.PAGA;
                await _repository.UpdateAsync(cobranca);
            }

            string msgerror = $"Valor do pagamento ({obj.Valor}) não corresponde ao valor da cobrança ({cobranca.Valor}).";
            throw new ArgumentException(msgerror);
        }

        public async Task<int> TotalDeCobrancasPorIdResposavel(int idResposavel) 
        { 
            return await _repository.TotalDeCobrancasPorIdResposavel(idResposavel);
        }

        public async Task<IEnumerable<ListaCobrancaResponsavelModel>> ListarCobrancaResponsavel(int idResponsavel) 
        {
            return await _repository.ListarCobrancaResponsavel(idResponsavel);
        }
    }
}
