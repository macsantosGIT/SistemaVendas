using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class AreaTransportadora
    {
        public int AreaTransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }
        public virtual Uf Uf { get; set; }
    }
}
