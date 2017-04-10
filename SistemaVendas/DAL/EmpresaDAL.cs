using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEmpresa = SistemaVendas.Models.Empresa;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class EmpresaDAL : DALBase<ModelEmpresa>
    {
        private static string stringConnection = DA.StringConnection;

        public EmpresaDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelEmpresa FindById(ModelEmpresa modelEntity)
        {
            return this.ExecutarQuery(x => x.EmpresaId == modelEntity.EmpresaId).First();
        }

        protected override void SetUpdate(ModelEmpresa modelEntity, ModelEmpresa fromDb)
        {
            fromDb.EmpresaId = modelEntity.EmpresaId;
            fromDb.EmpresaNome = modelEntity.EmpresaNome;
            fromDb.EmpresaNomeFantasia = modelEntity.EmpresaNomeFantasia;
            fromDb.EmpresaCnpj = modelEntity.EmpresaCnpj;
            fromDb.EmpresaIe = modelEntity.EmpresaIe;
            fromDb.EmpresaDddTel = modelEntity.EmpresaDddTel;
            fromDb.EmpresaTel = modelEntity.EmpresaTel;
            fromDb.EmpresaDddCel = modelEntity.EmpresaDddCel;
            fromDb.EmpresaEmail = modelEntity.EmpresaEmail;
            fromDb.EmpresaCep = modelEntity.EmpresaCel;
            fromDb.EmpresaEndereco = modelEntity.EmpresaEndereco;
            fromDb.EmpresaEnderecoComp = modelEntity.EmpresaEnderecoComp;
            fromDb.EmpresaBairro = modelEntity.EmpresaBairro;
            fromDb.EmpresaObservacao = modelEntity.EmpresaObservacao;
            fromDb.EmpresaSite = modelEntity.EmpresaSite;

            fromDb.Cidade = modelEntity.Cidade;
        }
    }
}
