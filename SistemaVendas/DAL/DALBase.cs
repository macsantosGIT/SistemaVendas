using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SistemaVendas.DAL
{
    public abstract class DALBase<T> where T : class
    {
        private SistemaVendasContexto contexto;

        public DALBase(SistemaVendasContexto contexto)
        {
            this.contexto = contexto;
        }

        public void AddToSave(T modelEntity)
        {
            contexto.Set<T>().Add(modelEntity);
        }
        public void Remove(T modelEntity)
        {
            modelEntity = FindById(modelEntity);
            contexto.Set<T>().Remove(modelEntity);
        }

        public void Update(T modelEntity)
        {
            var fromDb = FindById(modelEntity);
            SetUpdate(modelEntity, fromDb);
            contexto.Entry(fromDb).State = EntityState.Modified;
        }

        protected abstract void SetUpdate(T modelEntity, T fromDb);


        public abstract T FindById(T modelEntity);
        

        public IQueryable<T> ExecutarQuery(Expression<Func<T, bool>> qry)
        {
            return contexto.Set<T>().Where(qry);
        }

        public List<T> GetAll()
        {
            return contexto.Set<T>().ToList();
        }

    }
}
