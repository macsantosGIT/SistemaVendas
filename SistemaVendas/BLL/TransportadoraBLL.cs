using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelTransportadora = SistemaVendas.Models.Transportadora;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class TransportadoraBLL : BaseCrudBLL<ModelTransportadora, TransportadoraDAL>
    {
        public TransportadoraBLL(SistemaVendasContexto contexto) : base(contexto, new TransportadoraDAL(contexto)) { }

        public ModelTransportadora getTransportadora(ModelTransportadora transportadora)
        {
            return DALBase.ExecutarQuery(x => x.TransportadoraId == transportadora.TransportadoraId).SingleOrDefault();
        }

        public List<ModelTransportadora> getTransportadoras()
        {
            List<ModelTransportadora> transpostadorasRetorno = new List<Models.Transportadora>();

            transpostadorasRetorno = DALBase.GetAll();

            return transpostadorasRetorno;
        }
    }
}
