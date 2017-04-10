using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public string EmpresaNomeFantasia { get; set; }
        public string EmpresaCnpj { get; set; }
        public string EmpresaIe { get; set; }
        public int EmpresaDddTel { get; set; }
        public int EmpresaTel { get; set; }
        public int EmpresaDddCel { get; set; }
        public int EmpresaCel { get; set; }
        public string EmpresaEmail { get; set; }
        public int EmpresaCep { get; set; }
        public string EmpresaEndereco { get; set; }
        public string EmpresaEnderecoComp { get; set; }
        public string EmpresaBairro { get; set; }
        public string EmpresaObservacao { get; set; }
        public string EmpresaSite { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
