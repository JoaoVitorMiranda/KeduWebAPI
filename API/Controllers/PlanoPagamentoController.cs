using Application.Interfaces.Services.Domain;
using Application.Services.Domain;
using AutoMapper;
using Domain.Models;
using Infrastructure.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controller responsible for managing payment plans for financial responsibles.
    /// </summary>
    public class PlanoPagamentoController : DefaultController
    {
        private readonly IPlanoPagamentoService _planoPagamentoService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanoPagamentoController"/> class.
        /// </summary>
        /// <param name="planoPagamentoService">Service for managing payment plans.</param>
        /// <param name="mapper">AutoMapper instance for object mapping.</param>
        public PlanoPagamentoController(
            IPlanoPagamentoService planoPagamentoService,
            IMapper mapper)
        {
            _planoPagamentoService = planoPagamentoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria um novo plano de pagamento para um responsável financeiro.
        /// </summary>
        /// <param name="obj">Objeto com os dados do plano de pagamento.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(typeof(ResponseResult), 400)]
        [ProducesResponseType(500)]
        public async Task<ResponseResult> Create([FromBody] PlanoPagamentoModel obj)
        {
            var result = new ResponseResult();
            try
            {
                var entidade = _mapper.Map<PlanoPagamento>(obj);
                var PlanoPagamento = await _planoPagamentoService.AddAsync(entidade);
                result.Message = "Sucesso!";

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsError = true;
            }

            return result;
        }

        /// <summary>
        /// Busca o valor total de pagamento de todos os planos de pagamento.
        /// </summary>
        /// <returns>Uma lista de modelos contendo o valor total de pagamento para cada plano.</returns>
        [HttpGet]
        public async Task<IEnumerable<ValorTotalPagamentoModel>> BuscarValorTotalPagamento()
        {
            var planoPagamento = await _planoPagamentoService.BuscarValorTotalPagamento();
            var model = _mapper.Map<List<ValorTotalPagamentoModel>>(planoPagamento);

            return model;
        }

        /// <summary>
        /// Busca os planos de pagamento associados a um responsável financeiro específico.
        /// </summary>
        /// <param name="idResponsavel">Identificador do responsável financeiro.</param>
        /// <returns>Uma lista de modelos de planos de pagamento para o responsável informado.</returns>
        [HttpGet("{idResponsavel}")]
        public async Task<IEnumerable<PlanoPagamentoModel>> BuscarPlanosPagamentoPorIdResponsavel(int idResponsavel)
        {
            return await _planoPagamentoService.BuscarPlanosPagamentoPorIdResponsavel(idResponsavel);
        }
    }
}