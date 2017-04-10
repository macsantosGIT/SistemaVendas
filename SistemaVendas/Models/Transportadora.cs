using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Transportadora
    {
        public int TransportadoraId { get; set; }
        public int TransportadoraTipoPessoa { get; set; }
        public string TransportadoraNome { get; set; }
        public string TransportadoraNomeFantasia { get; set; }
        public string TransportadoraCnpjCpf { get; set; }
        public string TransportadoraIeRg { get; set; }
        public int TransportadoraDddTel { get; set; }
        public int TransportadoraTel { get; set; }
        public int TransportadoraDddCel { get; set; }
        public int TransportadoraCel { get; set; }
        public string TransportadoraEmail { get; set; }
        public int TransportadoraCep { get; set; }
        public string TransportadoraEndereco { get; set; }
        public string TransportadoraEnderecoComp { get; set; }
        public string TransportadoraBairro { get; set; }
        public string TransportadoraObservacao { get; set; }
        public string TransportadoraSite { get; set; }
        public string TransportadoraContatoNome1 { get; set; }
        public string TransportadoraContatoCargo1 { get; set; }
        public string TransportadoraContatoEmail1 { get; set; }
        public int TransportadoraContatoDddTel1 { get; set; }
        public int TransportadoraContatoTel1 { get; set; }
        public int TransportadoraContatoDddCel1 { get; set; }
        public int TransportadoraContatoCel1 { get; set; }
        public string TransportadoraContatoNome2 { get; set; }
        public string TransportadoraContatoCargo2 { get; set; }
        public string TransportadoraContatoEmail2 { get; set; }
        public int TransportadoraContatoDddTel2 { get; set; }
        public int TransportadoraContatoTel2 { get; set; }
        public int TransportadoraContatoDddCel2 { get; set; }
        public int TransportadoraContatoCel2 { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual ICollection<AreaTransportadora> AreaTransportadoras { get; set; }
    }
}
