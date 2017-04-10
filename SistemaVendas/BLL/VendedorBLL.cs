using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelVendedor = SistemaVendas.Models.Vendedor;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class VendedorBLL : BaseCrudBLL<ModelVendedor, VendedorDAL>
    {
        public VendedorBLL(SistemaVendasContexto contexto) : base(contexto, new VendedorDAL(contexto)) { }

        public ModelVendedor getVendedor(ModelVendedor vendedor)
        {
            return DALBase.ExecutarQuery(x => x.VendedorId == vendedor.VendedorId).SingleOrDefault();
        }

        public List<ModelVendedor> getVendedores()
        {
            List<ModelVendedor> vendedoresRetorno = new List<ModelVendedor>();

            vendedoresRetorno = DALBase.GetAll();

            return vendedoresRetorno;
        }
    }
}
