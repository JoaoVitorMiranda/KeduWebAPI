using AutoMapper;
using Domain.Models;
using Infrastructure.Domain.Entities;

namespace Infrastructure.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CobrancaModel, Cobranca>();
            CreateMap<CentroDeCustoModel, CentroDeCusto>();
            CreateMap<PlanoPagamentoModel, PlanoPagamento>();
            CreateMap<ResponsavelFinanceiroModel, ResponsavelFinanceiro>();
        }
    }
}
