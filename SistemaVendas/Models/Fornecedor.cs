using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public int FornecedorTipoPessoa { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorNomeFantasia { get; set; }
        public string FornecedorCnpjCpf { get; set; }
        public string FornecedorIeRg { get; set; }
        public int FornecedorDddTel { get; set; }
        public int FornecedorTel { get; set; }
        public int FornecedorDddCel { get; set; }
        public int FornecedorCel { get; set; }
        public string FornecedorEmail { get; set; }
        public int FornecedorCep { get; set; }
        public string FornecedorEndereco { get; set; }
        public string FornecedorEnderecoComp { get; set; }
        public string FornecedorBairro { get; set; }
        public string FornecedorObservacao { get; set; }
        public string FornecedorSite { get; set; }
        public string FornecedorContatoNome1 { get; set; }
        public string FornecedorContatoCargo1 { get; set; }
        public string FornecedorContatoEmail1 { get; set; }
        public int FornecedorContatoDddTel1 { get; set; }
        public int FornecedorContatoTel1 { get; set; }
        public int FornecedorContatoDddCel1 { get; set; }
        public int FornecedorContatoCel1 { get; set; }
        public string FornecedorContatoNome2 { get; set; }
        public string FornecedorContatoCargo2 { get; set; }
        public string FornecedorContatoEmail2 { get; set; }
        public int FornecedorContatoDddTel2 { get; set; }
        public int FornecedorContatoTel2 { get; set; }
        public int FornecedorContatoDddCel2 { get; set; }
        public int FornecedorContatoCel2 { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }
}
