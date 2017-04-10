using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFornecedor = SistemaVendas.Models.Fornecedor;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class FornecedorBLL : BaseCrudBLL<ModelFornecedor, FornecedorDAL>
    {
        public FornecedorBLL(SistemaVendasContexto contexto) : base(contexto, new FornecedorDAL(contexto)) { }

        public ModelFornecedor getFornecedor(ModelFornecedor fornecedor)
        {
            return DALBase.ExecutarQuery(x => x.FornecedorId == fornecedor.FornecedorId).SingleOrDefault();
        }

        public List<ModelFornecedor> getFornecedores()
        {
            List<ModelFornecedor> fornecedoresRetorno = new List<ModelFornecedor>();

            fornecedoresRetorno = DALBase.GetAll();

            return fornecedoresRetorno;
        }
    }
}
