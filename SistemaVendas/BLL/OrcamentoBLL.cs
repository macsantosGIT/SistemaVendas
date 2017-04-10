using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelOrcamento = SistemaVendas.Models.Orcamento;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class OrcamentoBLL : BaseCrudBLL<ModelOrcamento, OrcamentoDAL>
    {
        public OrcamentoBLL(SistemaVendasContexto contexto) : base(contexto, new OrcamentoDAL(contexto)) { }

        public ModelOrcamento getOrcamento(ModelOrcamento orcamento)
        {
            return DALBase.ExecutarQuery(x => x.OrcamentoId == orcamento.OrcamentoId).SingleOrDefault();
        }

        public List<ModelOrcamento> getOrcamentos()
        {
            List<ModelOrcamento> orcamentosRetorno = new List<ModelOrcamento>();

            orcamentosRetorno = DALBase.GetAll();

            return orcamentosRetorno;
        }

    }
}
