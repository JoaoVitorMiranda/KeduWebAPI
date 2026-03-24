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
    public class ResponsavelFinanceiroController : DefaultController
    {
        private readonly IResponsavelFinanceiroService _responsavelFinanceiroService;
        private readonly IMapper _mapper;

        public ResponsavelFinanceiroController(
            IResponsavelFinanceiroService responsavelFinanceiroService,
            IMapper mapper)
        {
            _responsavelFinanceiroService = responsavelFinanceiroService;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IEnumerable<ResponsavelFinanceiroModel>> GetAll()
        {
            var responsavelFinanceiro = await _responsavelFinanceiroService.GetAllListAsync();
            var model = _mapper.Map<List<ResponsavelFinanceiroModel>>(responsavelFinanceiro);

            return model;
        }

        [HttpGet()]
        public async Task<ActionResult<ResponsavelFinanceiroModel>> GetById(int id)
        {
            var responsavelFinanceiro = await _responsavelFinanceiroService.GetByIdAsync(id);

            if (responsavelFinanceiro == null)
                return NotFound();

            var model = _mapper.Map<ResponsavelFinanceiroModel>(responsavelFinanceiro);

            return model;
        }

        [HttpPost]
        public async Task<ResponseResult> Create(ResponsavelFinanceiroModel obj)
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

        [HttpPut()]
        public async Task<ResponseResult> Update(ResponsavelFinanceiroModel obj)
        {
            var result = new ResponseResult();
            try
            {
                if (obj == null || obj.Id == 0)
                    throw new ArgumentException("BadRequest");

                var entidade = _mapper.Map<ResponsavelFinanceiro>(obj);
                await _responsavelFinanceiroService.UpdateAsync(entidade);
                result.Message = "Sucesso!";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.IsError = true;
            }
            return result;
        }

        [HttpDelete()]
        public async Task<ResponseResult> Delete(int id)
        {
            var result = new ResponseResult();
            try
            {
                await _responsavelFinanceiroService.RemoveAsync(id);
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