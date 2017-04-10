using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Util;
using ModelUsuario = SistemaVendas.Models.Usuario;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class UsuarioBLL : BaseCrudBLL<ModelUsuario, UsuarioDAL>
    {
        public UsuarioBLL(SistemaVendasContexto contexto) : base(contexto, new UsuarioDAL(contexto)) { }

        public ModelUsuario getUsuario(ModelUsuario usuario) {

            return DALBase.ExecutarQuery(x => x.Codigo == usuario.Codigo).SingleOrDefault();
        }

        public List<ModelUsuario> getUsuarios() {

            List<ModelUsuario> usuariosRetorno = new List<ModelUsuario>();

            usuariosRetorno = DALBase.GetAll();

            return usuariosRetorno;
        }

        public bool AutenticarUsuario(ModelUsuario usuario) {
            bool retorno = false;

            ModelUsuario usuarioRetorno = new ModelUsuario();

            usuarioRetorno = DALBase.ExecutarQuery(x => x.Login == usuario.Login && x.Senha == usuario.Senha).SingleOrDefault();
            
            if (usuarioRetorno != null)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
