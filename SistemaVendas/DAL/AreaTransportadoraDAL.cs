using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelAreaTransportadora = SistemaVendas.Models.AreaTransportadora;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class AreaTransportadoraDAL : DALBase<ModelAreaTransportadora>
    {
        private static string stringConnection = DA.StringConnection;

        public AreaTransportadoraDAL(SistemaVendasContexto contexto) : base(contexto) { }
        
        public override ModelAreaTransportadora FindById(ModelAreaTransportadora modelEntity)
        {
            return this.ExecutarQuery(x => x.AreaTransportadoraId == modelEntity.AreaTransportadoraId).First();
        }

        protected override void SetUpdate(ModelAreaTransportadora modelEntity, ModelAreaTransportadora fromDb)
        {
            fromDb.AreaTransportadoraId = modelEntity.AreaTransportadoraId;
            fromDb.Transportadora = modelEntity.Transportadora;
            fromDb.Uf = fromDb.Uf;
        }
    }
}
