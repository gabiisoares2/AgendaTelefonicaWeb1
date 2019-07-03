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
    public class BLL_Cliente_Telefone : AbstractCrud<tbl_cliente_telefone>
    {
        #region Objetos
        ClienteTelefone clienteTelefone = new ClienteTelefone();
        List<ClienteTelefone> listaClienteTelefone = new List<ClienteTelefone>();
        tbl_cliente_telefone tbl_Cliente_Telefone = new tbl_cliente_telefone();
        #endregion

        #region Adicionar Telefone
        public ClienteTelefone AdicionarClienteTelefone(ClienteTelefone clienteTelefone)
        {
            try
            {
                tbl_Cliente_Telefone.IdCliente = clienteTelefone.cliente.Id;
                tbl_Cliente_Telefone.Descricao = clienteTelefone.Descricao;
                tbl_Cliente_Telefone.Numero = clienteTelefone.Numero;
                Add(tbl_Cliente_Telefone);
                SaveChanges();
                clienteTelefone.exceptionFull.StatusAtual = true;

                return clienteTelefone;
            }
            catch (Exception ex)
            {
                clienteTelefone.exceptionFull.StatusAtual = false;
                clienteTelefone.exceptionFull.Message = "Não foi possível realizar o cadastro";

                return clienteTelefone;
            }
        }
        #endregion

        #region Alterar Telefone
        public ClienteTelefone AlterarTelefone(ClienteTelefone clienteTelefone)
        {
            var Selecionar = Search(x => x.Id == clienteTelefone.Id).FirstOrDefault();
            Selecionar.Descricao = clienteTelefone.Descricao;
            Selecionar.Numero = clienteTelefone.Numero;
            Update(Selecionar);
            SaveChanges();
            clienteTelefone.exceptionFull.StatusAtual = true;
            return clienteTelefone;

        }
        #endregion

        #region Selecionar Todos Telefones Por Cliente
        public List<ClienteTelefone> SelecionarTodosPorCliente(ClienteTelefone clienteTelefone)
        {
            try
            {
                var selecionarClientes = SelectAll().Where(x => x.IdCliente == clienteTelefone.cliente.Id)
                    .Select(x => new ClienteTelefone
                    {
                        Id = x.Id,
                        Descricao = x.Descricao,
                        Numero = x.Numero
                    });
                return selecionarClientes.ToList();
            }
            catch (Exception ex)
            {
                clienteTelefone.exceptionFull.StatusAtual = false;
                clienteTelefone.exceptionFull.Message = "Não foi possível listar os telefones";
                listaClienteTelefone.Add(clienteTelefone);
                return listaClienteTelefone;
            }
        }
        #endregion

        #region Deletar Número
        public ClienteTelefone DeletarNumero(int id)
        {
            try
            {
                var Selecionar = Search(x => x.Id == id).FirstOrDefault();
                if (Selecionar != null)
                {
                    Delete(Selecionar);
                    SaveChanges();
                    clienteTelefone.exceptionFull.StatusAtual = true;
                }
                return clienteTelefone;

            }
            catch (Exception ex)
            {
                clienteTelefone.exceptionFull.StatusAtual = false;
                clienteTelefone.exceptionFull.Message = ex.ToString();
                return clienteTelefone;
            }
        }
        #endregion

        #region Deletar Numero por Cliente
        public ClienteTelefone DeletarNumeroCliente(int id)
        {
            try
            {
                var Selecionar = Search(x => x.IdCliente == id).ToList();
                if (Selecionar != null)
                {
                    foreach (var item in Selecionar)
                    {
                        Delete(item);
                        SaveChanges();
                    }                    
                }
                clienteTelefone.exceptionFull.StatusAtual = true;
                return clienteTelefone;

            }
            catch (Exception ex)
            {
                clienteTelefone.exceptionFull.StatusAtual = false;
                clienteTelefone.exceptionFull.Message = ex.ToString();
                return clienteTelefone;
            }
        }
        #endregion
    }
}
