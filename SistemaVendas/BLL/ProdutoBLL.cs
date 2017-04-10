using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProduto = SistemaVendas.Models.Produto;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class ProdutoBLL : BaseCrudBLL<ModelProduto, ProdutoDAL>
    {
        public ProdutoBLL(SistemaVendasContexto contexto) : base(contexto, new ProdutoDAL(contexto)) { }

        public ModelProduto getProduto(ModelProduto produto)
        {
            return DALBase.ExecutarQuery(x => x.ProdutoId == produto.ProdutoId).SingleOrDefault();
        }

        public List<ModelProduto> getProdutos()
        {
            List<ModelProduto> produtosRetorno = new List<ModelProduto>();

            produtosRetorno = DALBase.GetAll();

            return produtosRetorno;
        }
        
    }
}
