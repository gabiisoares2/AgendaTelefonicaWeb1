using AgendaTelefonica.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.DAO.Interfaces
{
    public interface IBaseCRUD<T>
    {
        ExceptionFull VerificaConexao();

        ExceptionFull Add(T Entidade);

        ExceptionFull Update(T Entidade);

        ExceptionFull Delete(T Entidade);

        IQueryable<T> Search(Expression<Func<T, bool>> where);

        IQueryable<T> SelectAll();

        ExceptionFull SaveChanges();

        ExceptionFull Erro(ExceptionFull ExceptionFull);
    }
}
