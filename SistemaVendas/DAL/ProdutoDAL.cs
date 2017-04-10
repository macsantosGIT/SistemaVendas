using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProduto = SistemaVendas.Models.Produto;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class ProdutoDAL : DALBase<ModelProduto> 
    {
        private static string stringConnection = DA.StringConnection;

        public ProdutoDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelProduto FindById(ModelProduto modelEntity)
        {
            return this.ExecutarQuery(x => x.ProdutoId == modelEntity.ProdutoId).First();  
        }

        protected override void SetUpdate(ModelProduto modelEntity, ModelProduto fromDb)
        {
            fromDb.ProdutoId = modelEntity.ProdutoId;
            fromDb.ProdutoNome = modelEntity.ProdutoNome;
            fromDb.ProdutoObservacao = modelEntity.ProdutoObservacao;
            fromDb.ProdutoUnidade = modelEntity.ProdutoUnidade;
            fromDb.ProdutoImagem = modelEntity.ProdutoImagem;
            fromDb.ProdutoIpi = modelEntity.ProdutoIpi;
            fromDb.ProdutoSubsTributaria = modelEntity.ProdutoSubsTributaria;
            fromDb.ProdutoPrecoCompra = modelEntity.ProdutoPrecoCompra;
            fromDb.ProdutoPctVenda = modelEntity.ProdutoPctVenda;
            fromDb.ProdutoPrecoSugerido = modelEntity.ProdutoPrecoSugerido;
            fromDb.ProdutoMoeda = modelEntity.ProdutoMoeda;
            fromDb.ProdutoEstoque = modelEntity.ProdutoEstoque;
            fromDb.ProdutoQtdEstoque = modelEntity.ProdutoQtdEstoque;
            fromDb.ProdutoQtdMinEstoque = modelEntity.ProdutoQtdMinEstoque;
            fromDb.ProdutoCodOrigem = modelEntity.ProdutoCodOrigem;
            fromDb.Fornecedor = modelEntity.Fornecedor;
            fromDb.Categoria = modelEntity.Categoria;
        }
    }
}
