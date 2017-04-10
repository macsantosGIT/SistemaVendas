using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlHelperAD;
using MySql.Data;
using MySql.Data.MySqlClient;
using ModelUf = SistemaVendas.Models.Uf;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class UfDAL : DALBase<ModelUf>
    {
        private static string stringConnection = DA.StringConnection;

        public UfDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelUf FindById(ModelUf modelEntity)
        {
            return this.ExecutarQuery(x => x.UfId == modelEntity.UfId).First();
        }

        protected override void SetUpdate(ModelUf modelEntity, ModelUf fromDb)
        {
            fromDb.UfId = modelEntity.UfId;
            fromDb.UfNome = modelEntity.UfNome;
            fromDb.UfSigla = modelEntity.UfSigla;
        }
    }
}
