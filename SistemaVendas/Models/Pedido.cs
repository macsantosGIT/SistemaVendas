using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime PedidoDatEmissao { get; set; }
        public DateTime PedidoDatAlteracao { get; set; }
        public decimal PedidoDesconto { get; set; }
        public decimal PedidoFrete { get; set; }
        public decimal PedidoValorSubTotal { get; set; }
        public decimal PedidoValor { get; set; }
        public string PedidoCondPagto { get; set; }
        public string PedidoObservacao { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public int OrcamentoPedido { get; set; }
        public virtual ICollection<PedidoDetalhe> Pdetalhes { get; set; }
    }
}
