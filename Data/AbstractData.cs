using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Entity;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Data
{
    public class AbstractData<T> : IBaseCrudData<T> where T : class
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
            throw new NotImplementedException();
            
        }

        public IQueryable<T> buscar(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> buscarTodos()
        {
            throw new NotImplementedException();
        }

        public void deletar(T pEntity)
        {
            throw new NotImplementedException();
        }

        public void inserir(T pEntity)
        {
            dbSet.Add(pEntity);
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

        public void SaveChange()
        {
            throw new NotImplementedException();
        }
    }
}
