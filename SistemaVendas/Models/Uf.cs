using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Uf
    {
        public int UfId { get; set; }
        public string UfNome { get; set; }
        public string UfSigla { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
        public virtual ICollection<AreaTransportadora> AreaTransportadoras { get; set; }
    }
}
