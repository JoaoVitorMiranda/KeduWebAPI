using System;
using System.Collections.Generic;

namespace Domain.Models
{
    [Serializable]
    public class CentroDeCustoModel : Pagination
    {
        public string Nome { get; set; }

        public List<PlanoPagamentoModel> PlanoPagamento { get; set; }
    }
}
