using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelTransportadora = SistemaVendas.Models.Transportadora;
using DA = MySqlHelperAD.MySqlHelper;
using SistemaVendas.Models;

namespace SistemaVendas.DAL
{
    public class TransportadoraDAL : DALBase<ModelTransportadora>
    {
        private static string stringConnection = DA.StringConnection;

        public TransportadoraDAL(SistemaVendasContexto contexto) : base(contexto) { }

        public override ModelTransportadora FindById(ModelTransportadora modelEntity)
        {
            return this.ExecutarQuery(x => x.TransportadoraId == modelEntity.TransportadoraId).First();
        }

        protected override void SetUpdate(ModelTransportadora modelEntity, ModelTransportadora fromDb)
        {
            fromDb.TransportadoraId = modelEntity.TransportadoraId;
            fromDb.TransportadoraTipoPessoa = modelEntity.TransportadoraTipoPessoa;
            fromDb.TransportadoraNome = modelEntity.TransportadoraNome;
            fromDb.TransportadoraNomeFantasia = modelEntity.TransportadoraNomeFantasia;
            fromDb.TransportadoraCnpjCpf = modelEntity.TransportadoraCnpjCpf;
            fromDb.TransportadoraIeRg = modelEntity.TransportadoraIeRg;
            fromDb.TransportadoraDddTel = modelEntity.TransportadoraDddTel;
            fromDb.TransportadoraTel = modelEntity.TransportadoraTel;
            fromDb.TransportadoraDddCel = modelEntity.TransportadoraDddCel;
            fromDb.TransportadoraEmail = modelEntity.TransportadoraEmail;
            fromDb.TransportadoraCep = modelEntity.TransportadoraCel;
            fromDb.TransportadoraEndereco = modelEntity.TransportadoraEndereco;
            fromDb.TransportadoraEnderecoComp = modelEntity.TransportadoraEnderecoComp;
            fromDb.TransportadoraBairro = modelEntity.TransportadoraBairro;
            fromDb.TransportadoraObservacao = modelEntity.TransportadoraObservacao;
            fromDb.TransportadoraSite = modelEntity.TransportadoraSite;
            fromDb.TransportadoraContatoNome1 = modelEntity.TransportadoraContatoNome1;
            fromDb.TransportadoraContatoCargo1 = modelEntity.TransportadoraContatoCargo1;
            fromDb.TransportadoraContatoEmail1 = modelEntity.TransportadoraContatoEmail1;
            fromDb.TransportadoraContatoDddTel1 = modelEntity.TransportadoraContatoDddTel1;
            fromDb.TransportadoraContatoTel1 = modelEntity.TransportadoraContatoTel1;
            fromDb.TransportadoraContatoDddCel1 = modelEntity.TransportadoraContatoDddCel1;
            fromDb.TransportadoraContatoCel1 = modelEntity.TransportadoraContatoCel1;

            fromDb.TransportadoraContatoNome2 = modelEntity.TransportadoraContatoNome2;
            fromDb.TransportadoraContatoCargo2 = modelEntity.TransportadoraContatoCargo2;
            fromDb.TransportadoraContatoEmail2 = modelEntity.TransportadoraContatoEmail2;
            fromDb.TransportadoraContatoDddTel2 = modelEntity.TransportadoraContatoDddTel2;
            fromDb.TransportadoraContatoTel2 = modelEntity.TransportadoraContatoTel2;
            fromDb.TransportadoraContatoDddCel2 = modelEntity.TransportadoraContatoDddCel2;
            fromDb.TransportadoraContatoCel2 = modelEntity.TransportadoraContatoCel2;

            fromDb.Cidade = modelEntity.Cidade;

        }
    }
}
