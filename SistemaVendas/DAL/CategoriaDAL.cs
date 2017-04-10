using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlHelperAD;
using MySql.Data;
using MySql.Data.MySqlClient;
using ModelCategoria = SistemaVendas.Models.Categoria;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class CategoriaDAL : DALBase<ModelCategoria>
    {
        private static string stringConnection = DA.StringConnection;

        public CategoriaDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelCategoria FindById(ModelCategoria modelEntity)
        {
            return this.ExecutarQuery(x => x.CategoriaId == modelEntity.CategoriaId).First();
        }

        protected override void SetUpdate(ModelCategoria modelEntity, ModelCategoria fromDb)
        {
            fromDb.CategoriaId = modelEntity.CategoriaId;
            fromDb.CategoriaNome = modelEntity.CategoriaNome;
        }
    }
}
