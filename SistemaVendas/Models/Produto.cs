using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoObservacao { get; set; }
        public string ProdutoUnidade { get; set; }
        public byte[] ProdutoImagem { get; set; }
        public decimal ProdutoIpi { get; set; }
        public decimal ProdutoSubsTributaria { get; set; }
        public decimal ProdutoPrecoCompra { get; set; }
        public decimal ProdutoPctVenda { get; set; }
        public decimal ProdutoPrecoSugerido { get; set; }
        public string ProdutoMoeda { get; set; }
        public bool ProdutoEstoque { get; set; }
        public int ProdutoQtdEstoque { get; set; }
        public int ProdutoQtdMinEstoque { get; set; }
        public string ProdutoCodOrigem { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public virtual ICollection<OrcamentoDetalhe> Odetalhes { get; set; }
        //public virtual ICollection<PedidoDetalhe> Pdetalhes { get; set; }
        
    }
}
