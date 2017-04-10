using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelStatusPedido = SistemaVendas.Models.StatusPedido;

namespace SistemaVendas.BLL
{
    public class StatusPedidoBLL
    {
        public List<ModelStatusPedido> getStatusPedido()
        {
            List<ModelStatusPedido> statusRetorno = new List<ModelStatusPedido>();

            statusRetorno.Add(new ModelStatusPedido(0, "Selecione"));
            statusRetorno.Add(new ModelStatusPedido(1, "Orcamento"));
            statusRetorno.Add(new ModelStatusPedido(2, "Emitido"));
            statusRetorno.Add(new ModelStatusPedido(3, "Cancelado"));

            return statusRetorno;
        }
    }
}
