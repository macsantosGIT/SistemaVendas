using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelOrcamento = SistemaVendas.Models.Orcamento;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class OrcamentoDAL : DALBase<ModelOrcamento>
    {
        private static string stringConnection = DA.StringConnection;

        public OrcamentoDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelOrcamento FindById(ModelOrcamento modelEntity)
        {
            return this.ExecutarQuery(x => x.OrcamentoId == modelEntity.OrcamentoId).First();
        }

        protected override void SetUpdate(ModelOrcamento modelEntity, ModelOrcamento fromDb)
        {
            fromDb.OrcamentoId = modelEntity.OrcamentoId;
            fromDb.OrcamentoDatEmissao = modelEntity.OrcamentoDatEmissao;
            fromDb.OrcamentoDatAlteracao = modelEntity.OrcamentoDatAlteracao;
            fromDb.OrcamentoDesconto = modelEntity.OrcamentoDesconto;
            fromDb.OrcamentoFrete = modelEntity.OrcamentoFrete;
            fromDb.OrcamentoValorSubTotal = modelEntity.OrcamentoValorSubTotal;
            fromDb.OrcamentoValor = modelEntity.OrcamentoValor;
            fromDb.OrcamentoCondPagto = modelEntity.OrcamentoCondPagto;
            fromDb.Cliente = modelEntity.Cliente;
            fromDb.Vendedor = modelEntity.Vendedor;
        }
    }
}
