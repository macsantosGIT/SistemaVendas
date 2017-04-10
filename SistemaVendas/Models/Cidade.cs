using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string CidadeNome { get; set; }
        public virtual Uf Uf { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
        public virtual ICollection<Transportadora> Transportadoras { get; set; }
    }
}
