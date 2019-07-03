using AgendaTelefonica.DAO.Interfaces;
using AgendaTelefonica.DAO.Model;
using AgendaTelefonica.DAO.ModelDB;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AgendaTelefonica.DAO.Abstracts
{
    public class AbstractCrud<T> : IBaseCRUD<T> where T : class
    {
        #region Entidade
      
        public agendatelefonicaEntities data = new agendatelefonicaEntities();

        ExceptionFull exceptionFull = new ExceptionFull();

        #endregion

        #region Teste de Conexao
        public ExceptionFull VerificaConexao()
        {
            try
            {
                data.Configuration.AutoDetectChangesEnabled = false;

                data.Configuration.LazyLoadingEnabled = false;

                if (data.Database.Connection.State == System.Data.ConnectionState.Closed)
                {
                    data.Database.Connection.Open();
                    exceptionFull.StatusAtual = true;

                }

                return exceptionFull;
            }
            catch (Exception ex)
            {
                exceptionFull.StatusAtual = false;
                exceptionFull.Message = ex.Message;
                return exceptionFull;
            }
        }
        #endregion

        #region Adicionar     
        public ExceptionFull Add(T Entidade)
        {
            try
            {
                data.Set<T>().Add(Entidade);
                exceptionFull.StatusAtual = true;
                return exceptionFull;
            }
            catch (Exception ex)
            {
                exceptionFull.StatusAtual = false;
                exceptionFull.Message = ex.Message;
                return exceptionFull;
            }
        }
        #endregion

        #region Atualizar     
        public ExceptionFull Update(T Entidade)
        {
            try
            {
                data.Set<T>().AddOrUpdate(Entidade);
                exceptionFull.StatusAtual = true;
                return exceptionFull;
            }
            catch (Exception ex)
            {
                exceptionFull.StatusAtual = false;
                exceptionFull.Message = ex.Message;
                return exceptionFull;
            }
        }

        #endregion

        #region Deletar
        public ExceptionFull Delete(T Entidade)
        {
            try
            {
                data.Set<T>().Remove(Entidade);
                exceptionFull.StatusAtual = true;
                return exceptionFull;
            }
            catch (Exception ex)
            {
                exceptionFull.StatusAtual = false;
                exceptionFull.Message = ex.Message;
                return exceptionFull;
            }
        }
        #endregion

        #region Seleciona com Filtro
        public IQueryable<T> Search(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            return data.Set<T>().Where(where).AsQueryable();
        }
        #endregion

        #region SelecionaTodos
        public IQueryable<T> SelectAll()
        {
            return data.Set<T>().AsQueryable();
        }
        #endregion

        #region Salvar
        public ExceptionFull SaveChanges()
        {
            try
            {
                data.SaveChanges();
                exceptionFull.StatusAtual = true;
                return exceptionFull;
            }
            catch (Exception ex)
            {
                exceptionFull.StatusAtual = false;
                exceptionFull.Message = ex.InnerException.InnerException.ToString();
                return exceptionFull;
            }
        }
        ExceptionFull IBaseCRUD<T>.Erro(ExceptionFull ExceptionFull)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
