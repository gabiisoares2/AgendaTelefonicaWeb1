using AgendaTelefonica.DAO.Abstracts;
using AgendaTelefonica.DAO.Model;
using AgendaTelefonica.DAO.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Business.Class
{
    public class BLL_Cliente : AbstractCrud<tbl_cliente>
    {
        #region Objetos
        Cliente cliente = new Cliente();
        List<Cliente> listaCliente = new List<Cliente>();
        tbl_cliente tbl_Cliente = new tbl_cliente();
        #endregion

        #region Adicionar Cliente
        public Cliente AdicionarCliente(Cliente cliente)
        {
            try
            {
                tbl_Cliente.Nome = cliente.Nome;
                tbl_Cliente.Email = cliente.Email;
                tbl_Cliente.DataNascimento = cliente.DataNascimento;
                tbl_Cliente.DataCadastro = DateTime.Now;
                tbl_Cliente.DataAlteracao = DateTime.Now;
                Add(tbl_Cliente);
                SaveChanges();
                cliente.Id = tbl_Cliente.Id;
                cliente.exceptionFull.StatusAtual = true;

                return cliente;
            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = "Não foi possível realizar o cadastro";

                return cliente;
            }
        }
        #endregion

        #region Alterar Cliente
        public Cliente AlterarCliente(Cliente cliente)
        {
            try
            {
                var Selecionar = Search(x => x.Id == cliente.Id).FirstOrDefault();
                Selecionar.Nome = cliente.Nome;
                Selecionar.Email = cliente.Email;
                Selecionar.DataNascimento = cliente.DataNascimento;
                Selecionar.DataAlteracao = DateTime.Now;
                Update(Selecionar);
                SaveChanges();
                cliente.exceptionFull.StatusAtual = true;
                return cliente;
            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = ex.ToString();

                return cliente;
            }
        }
        #endregion

        #region Deletar Cliente
        public Cliente DeletarCliente(int id)
        {
            try
            {
                var Selecionar = Search(x => x.Id == id).FirstOrDefault();
                if (Selecionar != null)
                {
                    Delete(Selecionar);
                    SaveChanges();
                    cliente.exceptionFull.StatusAtual = true;
                }
                return cliente;

            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = ex.ToString();
                return cliente;
            }
        }
        #endregion

        #region Selecionar Cliente por ID
        public Cliente SelecionarCliente(Cliente cliente)
        {
            try
            {
                var model = Search(x => x.Id == cliente.Id).FirstOrDefault();
                if (model != null)
                {
                    cliente.Id = model.Id;
                    cliente.Nome = model.Nome;
                    cliente.Email = model.Email;
                    cliente.DataNascimento = model.DataNascimento;
                    cliente.DataCadastro = model.DataCadastro;
                    cliente.DataAlteracao = model.DataAlteracao;
                    cliente.exceptionFull.StatusAtual = true;
                    return cliente;
                }
                else
                {
                    cliente.exceptionFull.Message = "Cliente Não encontrado";
                    return cliente;
                }
            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = ex.ToString();

                return cliente;
            }
        }
        #endregion

        #region Selecionar todos os clientes
        public List<Cliente> SelecionarTodos()
        {
            try
            {
                var selecionarClientes = SelectAll().OrderBy(x => x.Id)
                    .Select(x => new Cliente
                    {
                        Id = x.Id,                       
                        Nome = x.Nome,
                        Email = x.Email,
                        DataNascimento = x.DataNascimento,
                        DataCadastro = x.DataCadastro,
                        DataAlteracao = x.DataAlteracao
                    });
                return selecionarClientes.ToList();
            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = "Não foi possível listar os clientes";
                listaCliente.Add(cliente);
                return listaCliente;
            }
        }
        #endregion

        #region Selecionar todos os clientes Por nome
        public List<Cliente> SelecionarTodosNome(string Nome)
        {
            try
            {
                var selecionarClientes = SelectAll().Where(x => x.Nome.Contains(Nome)).OrderBy(x => x.Id)
                    .Select(x => new Cliente
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        DataNascimento = x.DataNascimento,
                        DataCadastro = x.DataCadastro
                    });
                return selecionarClientes.ToList();
            }
            catch (Exception ex)
            {
                cliente.exceptionFull.StatusAtual = false;
                cliente.exceptionFull.Message = "Não foi possível listar os clientes";
                listaCliente.Add(cliente);
                return listaCliente;
            }
        }
        #endregion
    }
}
