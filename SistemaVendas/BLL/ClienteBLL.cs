using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCliente = SistemaVendas.Models.Cliente;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class ClienteBLL : BaseCrudBLL<ModelCliente, ClienteDAL>
    {
        public ClienteBLL(SistemaVendasContexto contexto) : base(contexto, new ClienteDAL(contexto)) { }

        public ModelCliente getCliente(ModelCliente cliente)
        {
            return DALBase.ExecutarQuery(x => x.ClienteId == cliente.ClienteId).SingleOrDefault();
        }

        public List<ModelCliente> getClientes()
        {
            List<ModelCliente> clientesRetorno = new List<ModelCliente>();

            clientesRetorno = DALBase.GetAll();

            return clientesRetorno;
        }
    }
}
