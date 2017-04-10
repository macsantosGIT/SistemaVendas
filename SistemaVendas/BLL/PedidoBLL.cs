using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelPedido = SistemaVendas.Models.Pedido;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class PedidoBLL : BaseCrudBLL<ModelPedido, PedidoDAL>
    {
        public PedidoBLL(SistemaVendasContexto contexto) : base(contexto, new PedidoDAL(contexto)) { }

        public ModelPedido getPedido(ModelPedido pedido)
        {
            return DALBase.ExecutarQuery(x => x.PedidoId == pedido.PedidoId).SingleOrDefault();
        }

        public List<ModelPedido> getPedidos()
        {
            List<ModelPedido> pedidosRetorno = new List<ModelPedido>();

            pedidosRetorno = DALBase.GetAll();

            return pedidosRetorno;
        }
    }
}
