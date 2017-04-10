using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int ClienteTipoPessoa { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteNomeFantasia { get; set; }
        public string ClienteCnpjCpf { get; set; }
        public string ClienteIeRg { get; set; }
        public int ClienteDddTel { get; set; }
        public int ClienteTel { get; set; }
        public int ClienteDddCel { get; set; }
        public int ClienteCel { get; set; }
        public string ClienteEmail { get; set; }
        public int ClienteCep { get; set; }
        public string ClienteEndereco { get; set; }
        public string ClienteEnderecoComp { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteObservacao { get; set; }
        public string ClienteSite { get; set; }
        public string ClienteContatoNome1 { get; set; }
        public string ClienteContatoCargo1 { get; set; }
        public string ClienteContatoEmail1 { get; set; }
        public int ClienteContatoDddTel1 { get; set; }
        public int ClienteContatoTel1 { get; set; }
        public int ClienteContatoDddCel1 { get; set; }
        public int ClienteContatoCel1 { get; set; }
        public string ClienteContatoNome2 { get; set; }
        public string ClienteContatoCargo2 { get; set; }
        public string ClienteContatoEmail2 { get; set; }
        public int ClienteContatoDddTel2 { get; set; }
        public int ClienteContatoTel2 { get; set; }
        public int ClienteContatoDddCel2 { get; set; }
        public int ClienteContatoCel2 { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        //public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
