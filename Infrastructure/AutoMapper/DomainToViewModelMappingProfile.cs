using AutoMapper;
using Domain.Models;
using Infrastructure.Domain.Entities;

namespace Infrastructure.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<ResponsavelFinanceiro, ResponsavelFinanceiroModel>();
            CreateMap<CentroDeCusto, CentroDeCustoModel>();
            CreateMap<PlanoPagamento, PlanoPagamentoModel>();
            CreateMap<Cobranca, CobrancaModel>();
        }
    }
}
