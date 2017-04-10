using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class PedidoDetalhe
    {
        public int PedidoDetalheItem { get; set; }
        public int PedidoDetalheQtd { get; set; }
        public decimal PedidoDetalhePctDesc { get; set; }
        public decimal PedidoDetalhePrecoUnit { get; set; }
        public decimal PedidoDetalhePrecoTotal { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
