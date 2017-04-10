using SistemaVendas.DAL;

namespace SistemaVendas.BLL
{
    public abstract class BaseCrudBLL<K,T> where T : DALBase<K> where K :class
    {
        protected SistemaVendasContexto contexto;
        protected DALBase<K> DALBase;

        public BaseCrudBLL(SistemaVendasContexto contexto, DALBase<K> dalBase)
        {
            this.contexto = contexto;
            DALBase = dalBase;
        }

        public int Incluir(K model)
        {

            DALBase.AddToSave(model);
            return contexto.SaveChanges();
        }

        public int Atualizar(K model)
        {
            DALBase.Update(model);
            return contexto.SaveChanges();
        }

        public int Excluir(K model)
        {
            DALBase.Remove(model);
            return contexto.SaveChanges();
        }

        public K GetById(K model)
        {
            return DALBase.FindById(model);
        }
    }
}
