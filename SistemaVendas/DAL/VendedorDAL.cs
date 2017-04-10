using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelVendedor = SistemaVendas.Models.Vendedor;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class VendedorDAL : DALBase<ModelVendedor>
    {
        private static string stringConnection = DA.StringConnection;

        public VendedorDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelVendedor FindById(ModelVendedor modelEntity)
        {
            return this.ExecutarQuery(x => x.VendedorId == modelEntity.VendedorId).First();
        }

        protected override void SetUpdate(ModelVendedor modelEntity, ModelVendedor fromDb)
        {
            fromDb.VendedorId = modelEntity.VendedorId;
            fromDb.VendedorNome = modelEntity.VendedorNome;
            fromDb.VendedorDddTel = modelEntity.VendedorDddTel;
            fromDb.VendedorTel = modelEntity.VendedorTel;
            fromDb.VendedorDddCel = modelEntity.VendedorDddCel;
            fromDb.VendedorCel = modelEntity.VendedorCel;
            fromDb.VendedorEmail = modelEntity.VendedorEmail;
        }
    }
}
