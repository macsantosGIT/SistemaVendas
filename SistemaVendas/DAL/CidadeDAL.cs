using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlHelperAD;
using MySql.Data;
using MySql.Data.MySqlClient;
using ModelCidade = SistemaVendas.Models.Cidade;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class CidadeDAL : DALBase<ModelCidade>
    {
        private static string stringConnection = DA.StringConnection;

        public CidadeDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelCidade FindById(ModelCidade modelEntity)
        {
            return this.ExecutarQuery(x => x.CidadeId == modelEntity.CidadeId).First();
        }

        protected override void SetUpdate(ModelCidade modelEntity, ModelCidade fromDb)
        {
            fromDb.CidadeId = modelEntity.CidadeId;
            fromDb.CidadeNome = modelEntity.CidadeNome;
            fromDb.Uf = modelEntity.Uf;
        }

        //Criar metodo para selecionar cidades por estado.
    }
}
