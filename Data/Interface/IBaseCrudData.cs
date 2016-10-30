using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Data
{
    public interface IBaseCrudData<T>
    {
        void inserir(T pEntity);
        void deletar(T pEntity);
        void atualizar(T pEntity);
        IQueryable<T> buscarTodos();
        IQueryable<T> buscar(Expression<Func<T,bool>> where);
        void SaveChange();
    }
}
