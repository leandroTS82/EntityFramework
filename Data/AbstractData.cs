using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Entity;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Collections.Generic;

namespace Data
{
    public class AbstractData<T> where T : class
    {        

        internal DataEntity context;
        internal DbSet<T> dbSet;

        public AbstractData(DataEntity context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public void atualizar(T pEntity)
        {
            dbSet.Attach(pEntity);
            context.Entry(pEntity).State = EntityState.Modified;
            SaveChange();
        }

        public void buscar(Expression<Func<T, bool>> where)
        {
            var db = dbSet.ToList();
        }
        public T buscar(int id)
        {
            var item = dbSet.Find(id);
            return item;
        }

        public List<T> buscar()
        {
            List<T> dbList = dbSet.ToList();
            return dbList;
        }
 

        public void deletar(T pEntity)
        {
            dbSet.Remove(pEntity);
            SaveChange();
        }
        public void deletar(int id)
        {
            var item = dbSet.Find(id);
            dbSet.Remove(item);
            SaveChange();
        }

        public void inserir(T pEntity)
        {
            dbSet.Add(pEntity);
            SaveChange();            
        }

        public void SaveChange()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
