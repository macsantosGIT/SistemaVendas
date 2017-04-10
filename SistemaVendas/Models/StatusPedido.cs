using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    [Serializable]
    public class StatusPedido
    {
        private int Codigo { get; set; }
        private string Descricao { get; set; }

        public StatusPedido() { }

        public StatusPedido(int cod, string desc)
        {
            this.Codigo = cod;
            this.Descricao = desc;
        }       
    }
}
