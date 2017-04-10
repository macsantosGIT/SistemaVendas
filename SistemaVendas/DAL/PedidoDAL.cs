using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelPedido = SistemaVendas.Models.Pedido;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class PedidoDAL : DALBase<ModelPedido>
    {
        private static string stringConnection = DA.StringConnection;

        public PedidoDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelPedido FindById(ModelPedido modelEntity)
        {
            return this.ExecutarQuery(x => x.PedidoId == modelEntity.PedidoId).First();
        }

        protected override void SetUpdate(ModelPedido modelEntity, ModelPedido fromDb)
        {
            fromDb.PedidoId = modelEntity.PedidoId;
            fromDb.PedidoDatEmissao = modelEntity.PedidoDatEmissao;
            fromDb.PedidoDatAlteracao = modelEntity.PedidoDatAlteracao;
            fromDb.PedidoDesconto = modelEntity.PedidoDesconto;
            fromDb.PedidoFrete = modelEntity.PedidoFrete;
            fromDb.PedidoValorSubTotal = modelEntity.PedidoValorSubTotal;
            fromDb.PedidoValor = modelEntity.PedidoValor;
            fromDb.PedidoCondPagto = modelEntity.PedidoCondPagto;
            fromDb.Cliente = modelEntity.Cliente;
            fromDb.Vendedor = modelEntity.Vendedor;
            fromDb.Fornecedor = modelEntity.Fornecedor;
        }
    }
}
