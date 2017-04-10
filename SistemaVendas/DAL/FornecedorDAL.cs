using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelFornecedor = SistemaVendas.Models.Fornecedor;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class FornecedorDAL : DALBase<ModelFornecedor>
    {
        private static string stringConnection = DA.StringConnection;

        public FornecedorDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelFornecedor FindById(ModelFornecedor modelEntity)
        {
            return this.ExecutarQuery(x => x.FornecedorId == modelEntity.FornecedorId).First();
        }

        protected override void SetUpdate(ModelFornecedor modelEntity, ModelFornecedor fromDb)
        {
            fromDb.FornecedorId = modelEntity.FornecedorId;
            fromDb.FornecedorTipoPessoa = modelEntity.FornecedorTipoPessoa;
            fromDb.FornecedorNome = modelEntity.FornecedorNome;
            fromDb.FornecedorNomeFantasia = modelEntity.FornecedorNomeFantasia;
            fromDb.FornecedorCnpjCpf = modelEntity.FornecedorCnpjCpf;
            fromDb.FornecedorIeRg = modelEntity.FornecedorIeRg;
            fromDb.FornecedorDddTel = modelEntity.FornecedorDddTel;
            fromDb.FornecedorTel = modelEntity.FornecedorTel;
            fromDb.FornecedorDddCel = modelEntity.FornecedorDddCel;
            fromDb.FornecedorEmail = modelEntity.FornecedorEmail;
            fromDb.FornecedorCep = modelEntity.FornecedorCel;
            fromDb.FornecedorEndereco = modelEntity.FornecedorEndereco;
            fromDb.FornecedorEnderecoComp = modelEntity.FornecedorEnderecoComp;
            fromDb.FornecedorBairro = modelEntity.FornecedorBairro;
            fromDb.FornecedorObservacao = modelEntity.FornecedorObservacao;
            fromDb.FornecedorSite = modelEntity.FornecedorSite;
            fromDb.FornecedorContatoNome1 = modelEntity.FornecedorContatoNome1;
            fromDb.FornecedorContatoCargo1 = modelEntity.FornecedorContatoCargo1;
            fromDb.FornecedorContatoEmail1 = modelEntity.FornecedorContatoEmail1;
            fromDb.FornecedorContatoDddTel1 = modelEntity.FornecedorContatoDddTel1;
            fromDb.FornecedorContatoTel1 = modelEntity.FornecedorContatoTel1;
            fromDb.FornecedorContatoDddCel1 = modelEntity.FornecedorContatoDddCel1;
            fromDb.FornecedorContatoCel1 = modelEntity.FornecedorContatoCel1;

            fromDb.FornecedorContatoNome2 = modelEntity.FornecedorContatoNome2;
            fromDb.FornecedorContatoCargo2 = modelEntity.FornecedorContatoCargo2;
            fromDb.FornecedorContatoEmail2 = modelEntity.FornecedorContatoEmail2;
            fromDb.FornecedorContatoDddTel2 = modelEntity.FornecedorContatoDddTel2;
            fromDb.FornecedorContatoTel2 = modelEntity.FornecedorContatoTel2;
            fromDb.FornecedorContatoDddCel2 = modelEntity.FornecedorContatoDddCel2;
            fromDb.FornecedorContatoCel2 = modelEntity.FornecedorContatoCel2;

            fromDb.Cidade = modelEntity.Cidade;
        }
    }
}
