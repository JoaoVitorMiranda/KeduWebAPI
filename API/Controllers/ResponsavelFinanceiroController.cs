using Application.Interfaces.Services.Domain;
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
    /// Controller responsible for managing financial responsibles.
    /// </summary>
    public class ResponsavelFinanceiroController : DefaultController
    {
        private readonly IResponsavelFinanceiroService _responsavelFinanceiroService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsavelFinanceiroController"/> class.
        /// </summary>
        /// <param name="responsavelFinanceiroService">Service for managing financial responsibles.</param>
        /// <param name="mapper">AutoMapper instance for model mapping.</param>
        public ResponsavelFinanceiroController(
            IResponsavelFinanceiroService responsavelFinanceiroService,
            IMapper mapper)
        {
            _responsavelFinanceiroService = responsavelFinanceiroService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtém todos os responsáveis financeiros.
        /// </summary>
        /// <returns>Uma lista de modelos de responsáveis financeiros.</returns>
        [HttpGet]
        public async Task<IEnumerable<ResponsavelFinanceiroModel>> GetAll()
        {
            var responsavelFinanceiro = await _responsavelFinanceiroService.GetAllListAsync();
            var model = _mapper.Map<List<ResponsavelFinanceiroModel>>(responsavelFinanceiro);

            return model;
        }


        /// <summary>
        /// Cria um novo responsável financeiro.
        /// </summary>
        /// <param name="obj">Objeto com os dados do responsável financeiro.</param>
        /// <returns>Resultado da operação.</returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(typeof(ResponseResult), 400)]
        [ProducesResponseType(500)]
        public async Task<ResponseResult> Create([FromBody] ResponsavelFinanceiroModel obj)
        {
            var result = new ResponseResult();
            try
            {
                var entidade = _mapper.Map<ResponsavelFinanceiro>(obj);
                var responsavelFinanceiro = await _responsavelFinanceiroService.AddAsync(entidade);
                result.Message = "Sucesso!";

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsError = true;
            }

            return result;
        }
    }
}