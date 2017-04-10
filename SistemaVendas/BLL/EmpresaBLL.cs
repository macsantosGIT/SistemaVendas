using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEmpresa = SistemaVendas.Models.Empresa;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class EmpresaBLL : BaseCrudBLL<ModelEmpresa, EmpresaDAL>
    {
        public EmpresaBLL(SistemaVendasContexto contexto) : base(contexto, new EmpresaDAL(contexto)) { }

        public ModelEmpresa getEmpresa(ModelEmpresa empresa)
        {
            return DALBase.ExecutarQuery(x => x.EmpresaId == empresa.EmpresaId).SingleOrDefault();
        }

        public List<ModelEmpresa> getEmpresas()
        {
            List<ModelEmpresa> empresasRetorno = new List<ModelEmpresa>();

            empresasRetorno = DALBase.GetAll();

            return empresasRetorno;
        }
    }
}
