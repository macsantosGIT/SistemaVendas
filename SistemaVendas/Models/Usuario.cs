using System;

namespace SistemaVendas.Models
{
    [Serializable]
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
