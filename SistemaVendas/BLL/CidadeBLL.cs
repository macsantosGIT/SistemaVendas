using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ModelCidade = SistemaVendas.Models.Cidade;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class CidadeBLL : BaseCrudBLL<ModelCidade, CidadeDAL>
    {
        public CidadeBLL(SistemaVendasContexto contexto) : base(contexto, new CidadeDAL(contexto)) { }

        public ModelCidade getCidade(ModelCidade cidade)
        {
            return DALBase.ExecutarQuery(x => x.CidadeId == cidade.CidadeId).SingleOrDefault();
        }

        public List<ModelCidade> getCidades()
        {
            List<ModelCidade> cidadesRetorno = new List<ModelCidade>();

            cidadesRetorno = DALBase.GetAll();

            return cidadesRetorno;
        }

        //Criar metodo para selecionar cidades por estado.
    }
}
