using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    [Serializable]
    public class PlanoPagamentoModel : Pagination
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Responsavel Financeiro deve ser informado")]
        public int IdResponsavelFinanceiro { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Centro De Custo deve ser informado")]
        public int IdCentroDeCusto { get; set; }

        public decimal ValorTotalPlano { get; set; }

        public List<CobrancaModel> Cobranca { get; set; }

        [JsonIgnore]
        public ResponsavelFinanceiroModel ResponsavelFinanceiro { get; set; }

        [JsonIgnore]
        public CentroDeCustoModel CentroDeCusto { get; set; }
    }
}
