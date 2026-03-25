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
    public class CentroDeCustoController : DefaultController
    {
        private readonly ICentroDeCustoService _centroDeCustoService;
        private readonly IMapper _mapper;

        public CentroDeCustoController(
            ICentroDeCustoService centroDeCustoService,
            IMapper mapper)
        {
            _centroDeCustoService = centroDeCustoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CentroDeCustoModel>> GetAll()
        {
            var CentroDeCusto = await _centroDeCustoService.GetAllListAsync();
            var model = _mapper.Map<List<CentroDeCustoModel>>(CentroDeCusto);

            return model;
        }
    }
}