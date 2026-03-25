using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    [Serializable]
    public class ResponsavelFinanceiroModel : Pagination
    {
        [Required(ErrorMessage = "O nome do responsavel financeiro deve ser informado.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do responsavel financeiro deve ter entre {1} e {0} caracteres.")]
        public string NomeResponsavel { get; set; }

        [JsonIgnore]
        public List<PlanoPagamentoModel> PlanoPagamento { get; set; }
    }
}
