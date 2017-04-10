using System.Linq;
using ModelUsuario = SistemaVendas.Models.Usuario;
using DA = MySqlHelperAD.MySqlHelper;

namespace SistemaVendas.DAL
{
    public class UsuarioDAL : DALBase<ModelUsuario>
    {

        private static string stringConnection = DA.StringConnection;

        public UsuarioDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelUsuario FindById(ModelUsuario modelEntity)
        {
            return this.ExecutarQuery(x => x.Codigo == modelEntity.Codigo).First();
        }
        
        protected override void SetUpdate(ModelUsuario modelEntity, ModelUsuario fromDb)
        {
            fromDb.Codigo = modelEntity.Codigo;
            fromDb.Login = modelEntity.Login;
            fromDb.Senha = modelEntity.Senha;
            fromDb.Nome = modelEntity.Nome;
        }

    }
}
