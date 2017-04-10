using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ModelUf = SistemaVendas.Models.Uf;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class UfBLL : BaseCrudBLL<ModelUf, UfDAL>
    {
        public UfBLL(SistemaVendasContexto contexto) : base(contexto, new UfDAL(contexto)) { }

        public ModelUf getUf(ModelUf uf)
        {
            return DALBase.ExecutarQuery(x => x.UfId == uf.UfId).SingleOrDefault();
        }

        public List<ModelUf> getUfs()
        {
            List<ModelUf> ufsRetorno = new List<ModelUf>();

            ufsRetorno = DALBase.GetAll();

            return ufsRetorno;
        }
    }
}
