using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelAreaTransportadora = SistemaVendas.Models.AreaTransportadora;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class AreaTransportadoraBLL : BaseCrudBLL<ModelAreaTransportadora, AreaTransportadoraDAL>
    {
        public AreaTransportadoraBLL(SistemaVendasContexto contexto) : base(contexto, new AreaTransportadoraDAL(contexto)) { }

        public ModelAreaTransportadora getArea(ModelAreaTransportadora area)
        {
            return DALBase.ExecutarQuery(x => x.AreaTransportadoraId == area.AreaTransportadoraId).SingleOrDefault();   
        }

        public List<ModelAreaTransportadora> getAreas()
        {
            List<ModelAreaTransportadora> areasRetorno = new List<ModelAreaTransportadora>();

            areasRetorno = DALBase.GetAll();

            return areasRetorno;
        }
    }
}
