using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelOrcamentoDetalhe = SistemaVendas.Models.OrcamentoDetalhe;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class OrcamentoDetalheBLL : BaseCrudBLL<ModelOrcamentoDetalhe, OrcamentoDetalheDAL>
    {
        public OrcamentoDetalheBLL(SistemaVendasContexto contexto) : base(contexto, new OrcamentoDetalheDAL(contexto)) { }

        public ModelOrcamentoDetalhe getOrcamentoDetalhe(ModelOrcamentoDetalhe orcDetalhe)
        {
            return DALBase.ExecutarQuery(x => x.Orcamento.OrcamentoId == orcDetalhe.Orcamento.OrcamentoId).SingleOrDefault();
        }

        public List<ModelOrcamentoDetalhe> getOrcDetalhes()
        {
            List<ModelOrcamentoDetalhe> orcDetalhesRetorno = new List<ModelOrcamentoDetalhe>();

            orcDetalhesRetorno = DALBase.GetAll();

            return orcDetalhesRetorno;
        }
    }
}
