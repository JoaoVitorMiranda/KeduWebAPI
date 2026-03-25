using Application.Interfaces.Services.Domain;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controller responsible for managing payment plans for financial responsibles.
    /// </summary>
    public class CobrancaController : DefaultController
    {
        private readonly ICobrancaService _cobrancaService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CobrancaController"/> class.
        /// </summary>
        /// <param name="cobrancaService">The service for managing charges.</param>
        /// <param name="mapper">The mapper for object transformations.</param>
        public CobrancaController(
            ICobrancaService cobrancaService,
            IMapper mapper)
        {
            _cobrancaService = cobrancaService;
            _mapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(typeof(ResponseResult), 400)]
        [ProducesResponseType(500)]
        /// <summary>
        /// Registers a payment for a specific charge by its identifier.
        /// </summary>
        /// <param name="obj">The payment registration model containing charge ID, value, and date.</param>
        /// <returns>A <see cref="ResponseResult"/> indicating the result of the operation.</returns>
        public async Task<ResponseResult> RegistrarPagamentoPorIdCobranca([FromBody] RegistrarPagamentoModel obj)
        {
            var result = new ResponseResult();
            try
            {
                await _cobrancaService.RegistrarPagamentoPorIdCobranca(obj);
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
        /// Gets the total number of charges for a specific responsible party by their identifier.
        /// </summary>
        /// <param name="idResposavel">The identifier of the responsible party.</param>
        /// <returns>The total number of charges associated with the specified responsible party.</returns>
        [HttpGet("total-cobrancas/{idResposavel}")]
        public async Task<int> TotalDeCobrancasPorIdResposavel(int idResposavel)
        {
            return await _cobrancaService.TotalDeCobrancasPorIdResposavel(idResposavel);
        }

        /// <summary>
        /// Lists all charges associated with a specific responsible party by their identifier.
        /// </summary>
        /// <param name="idResponsavel">The identifier of the responsible party.</param>
        /// <returns>A collection of <see cref="ListaCobrancaResponsavelModel"/> representing the charges for the responsible party.</returns>
        [HttpGet("listar-cobrancas-responsavel/{idResponsavel}")]
        public async Task<IEnumerable<ListaCobrancaResponsavelModel>> ListarCobrancaResponsavel(int idResponsavel)
        {
            return await _cobrancaService.ListarCobrancaResponsavel(idResponsavel);
        }
    }
}