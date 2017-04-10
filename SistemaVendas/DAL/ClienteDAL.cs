using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelCliente = SistemaVendas.Models.Cliente;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class ClienteDAL : DALBase<ModelCliente>
    {
        private static string stringConnection = DA.StringConnection;

        public ClienteDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelCliente FindById(ModelCliente modelEntity)
        {
            return this.ExecutarQuery(x => x.ClienteId == modelEntity.ClienteId).First();
        }

        protected override void SetUpdate(ModelCliente modelEntity, ModelCliente fromDb)
        {
            fromDb.ClienteId = modelEntity.ClienteId;
            fromDb.ClienteTipoPessoa = modelEntity.ClienteTipoPessoa;
            fromDb.ClienteNome = modelEntity.ClienteNome;
            fromDb.ClienteNomeFantasia = modelEntity.ClienteNomeFantasia;
            fromDb.ClienteCnpjCpf = modelEntity.ClienteCnpjCpf;
            fromDb.ClienteIeRg = modelEntity.ClienteIeRg;
            fromDb.ClienteDddTel = modelEntity.ClienteDddTel;
            fromDb.ClienteTel = modelEntity.ClienteTel;
            fromDb.ClienteDddCel = modelEntity.ClienteDddCel;
            fromDb.ClienteEmail = modelEntity.ClienteEmail;
            fromDb.ClienteCep = modelEntity.ClienteCel;
            fromDb.ClienteEndereco = modelEntity.ClienteEndereco;
            fromDb.ClienteEnderecoComp = modelEntity.ClienteEnderecoComp;
            fromDb.ClienteBairro = modelEntity.ClienteBairro;
            fromDb.ClienteObservacao = modelEntity.ClienteObservacao;
            fromDb.ClienteSite = modelEntity.ClienteSite;
            fromDb.ClienteContatoNome1 = modelEntity.ClienteContatoNome1;
            fromDb.ClienteContatoCargo1 = modelEntity.ClienteContatoCargo1;
            fromDb.ClienteContatoEmail1 = modelEntity.ClienteContatoEmail1;
            fromDb.ClienteContatoDddTel1 = modelEntity.ClienteContatoDddTel1;
            fromDb.ClienteContatoTel1 = modelEntity.ClienteContatoTel1;
            fromDb.ClienteContatoDddCel1 = modelEntity.ClienteContatoDddCel1;
            fromDb.ClienteContatoCel1 = modelEntity.ClienteContatoCel1;

            fromDb.ClienteContatoNome2 = modelEntity.ClienteContatoNome2;
            fromDb.ClienteContatoCargo2 = modelEntity.ClienteContatoCargo2;
            fromDb.ClienteContatoEmail2 = modelEntity.ClienteContatoEmail2;
            fromDb.ClienteContatoDddTel2 = modelEntity.ClienteContatoDddTel2;
            fromDb.ClienteContatoTel2 = modelEntity.ClienteContatoTel2;
            fromDb.ClienteContatoDddCel2 = modelEntity.ClienteContatoDddCel2;
            fromDb.ClienteContatoCel2 = modelEntity.ClienteContatoCel2;

            fromDb.Cidade = modelEntity.Cidade;
        }
    }
}
