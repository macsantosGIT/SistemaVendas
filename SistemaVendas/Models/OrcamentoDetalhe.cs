using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class OrcamentoDetalhe
    {
        public int OrcamentoDetalheItem { get; set; }
        public int OrcamentoDetalheQtd { get; set; }
        public decimal OrcamentoDetalhePctDesc { get; set; }
        public decimal OrcamentoDetalhePrecoUnit { get; set; }
        public decimal OrcamentoDetalhePrecoTotal { get; set; }
        public virtual Orcamento Orcamento { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
