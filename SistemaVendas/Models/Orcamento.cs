using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Orcamento
    {
        public int OrcamentoId { get; set; }
        public DateTime OrcamentoDatEmissao { get; set; }
        public DateTime OrcamentoDatAlteracao { get; set; }
        public decimal OrcamentoDesconto { get; set; }
        public decimal OrcamentoFrete { get; set; }
        public decimal OrcamentoValorSubTotal { get; set; }
        public decimal OrcamentoValor { get; set; }
        public string OrcamentoCondPagto { get; set; }
        public string OrcamentoObservacao { get; set; }
        public int OrcamentoStatus { get; set; }
        public DateTime OrcamentoDataEntrega { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<OrcamentoDetalhe> Odetalhes { get; set; }
    }
}
