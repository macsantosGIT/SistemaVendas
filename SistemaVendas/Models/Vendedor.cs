using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string VendedorNome { get; set; }
        public int VendedorDddTel { get; set; }
        public int VendedorTel { get; set; }
        public int VendedorDddCel { get; set; }
        public int VendedorCel { get; set; }
        public string VendedorEmail { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        //public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
