using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelOrcamentoDetalhe = SistemaVendas.Models.OrcamentoDetalhe;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class OrcamentoDetalheDAL : DALBase<Models.OrcamentoDetalhe>
    {
        public static string stringConnection = DA.StringConnection;

        public OrcamentoDetalheDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelOrcamentoDetalhe FindById(ModelOrcamentoDetalhe modelEntity)
        {
            return this.ExecutarQuery(x => x.Orcamento.OrcamentoId == modelEntity.Orcamento.OrcamentoId).First();
        }

        protected override void SetUpdate(ModelOrcamentoDetalhe modelEntity, ModelOrcamentoDetalhe fromDb)
        {
            fromDb.OrcamentoDetalheItem = modelEntity.OrcamentoDetalheItem;
            fromDb.OrcamentoDetalheQtd = modelEntity.OrcamentoDetalheQtd;
            fromDb.OrcamentoDetalhePctDesc = modelEntity.OrcamentoDetalhePctDesc;
            fromDb.OrcamentoDetalhePrecoUnit = modelEntity.OrcamentoDetalhePrecoUnit;
            fromDb.OrcamentoDetalhePrecoTotal = modelEntity.OrcamentoDetalhePrecoTotal;
            fromDb.Orcamento = modelEntity.Orcamento;
            fromDb.Produto = modelEntity.Produto;
        } 

    }
}
