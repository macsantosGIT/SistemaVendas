using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ModelCategoria = SistemaVendas.Models.Categoria;
using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public class CategoriaBLL : BaseCrudBLL<ModelCategoria, CategoriaDAL>
    {
        public CategoriaBLL(SistemaVendasContexto contexto) : base(contexto, new CategoriaDAL(contexto)) { }

        public ModelCategoria getCategoria(ModelCategoria categoria)
        {
            return DALBase.ExecutarQuery(x => x.CategoriaId == categoria.CategoriaId).SingleOrDefault();
        }

        public List<ModelCategoria> getCategorias()
        {
            List<ModelCategoria> categoriasRetorno = new List<ModelCategoria>();

            categoriasRetorno = DALBase.GetAll();

            return categoriasRetorno;
        }
                
    }
}
