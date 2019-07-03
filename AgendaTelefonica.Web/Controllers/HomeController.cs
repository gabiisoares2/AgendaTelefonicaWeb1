using AgendaTelefonica.Business.Class;
using AgendaTelefonica.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace AgendaTelefonica.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Objetos
        Cliente cliente = new Cliente();
        List<Cliente> listaClientes = new List<Cliente>();
        BLL_Cliente bLL_Cliente = new BLL_Cliente();

        ClienteTelefone clienteTelefone = new ClienteTelefone();
        List<ClienteTelefone> listaClienteTelefones = new List<ClienteTelefone>();
        BLL_Cliente_Telefone bLL_Cliente_Telefone = new BLL_Cliente_Telefone();
        #endregion

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ListaClientes = bLL_Cliente.SelecionarTodos();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Nome)
        {
            ViewBag.ListaClientes = bLL_Cliente.SelecionarTodosNome(Nome);
            return View();
        }

        #endregion

        #region Gravar Clientes
        [HttpPost]
        public ActionResult GravarClientes(string Nome, string Email, string DataNascimento, string Celular, string Casa, string Trabalho)
        {
            cliente.Nome = Nome;
            cliente.Email = Email;
            cliente.DataNascimento = Convert.ToDateTime(DataNascimento);
            bLL_Cliente.AdicionarCliente(cliente);
            if (cliente.exceptionFull.StatusAtual == true)
            {
                if (!(string.IsNullOrEmpty(Celular)))
                {
                    clienteTelefone.Descricao = "Celular";
                    clienteTelefone.Numero = Celular;
                    clienteTelefone.cliente.Id = cliente.Id;
                    bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                }
                if (!(string.IsNullOrEmpty(Casa)))
                {
                    clienteTelefone.Descricao = "Casa";
                    clienteTelefone.Numero = Casa;
                    clienteTelefone.cliente.Id = cliente.Id;
                    bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                }
                if (!(string.IsNullOrEmpty(Trabalho)))
                {
                    clienteTelefone.Descricao = "Trabalho";
                    clienteTelefone.Numero = Trabalho;
                    clienteTelefone.cliente.Id = cliente.Id;
                    bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                }
                var resultado = new
                {
                    msgErro = 1,
                };
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultado = new
                {
                    msgErro = 2,
                };
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Alterar Clientes
        [HttpGet]
        public ActionResult AlterarClientes (int Id)
        {
            var idCel = 0;
            var descricaoCelular = "";
            var numeroCelular = "";
            var idCasa = 0;
            var descricaoCasa = "";
            var numeroCasa = "";
            var idTrab = 0;
            var descricaoTrabalho = "";
            var numeroTrabalho = "";
            cliente.Id = Id;
            clienteTelefone.cliente.Id = Id;
            bLL_Cliente.SelecionarCliente(cliente);
            bLL_Cliente_Telefone.SelecionarTodosPorCliente(clienteTelefone);
            foreach (var item in bLL_Cliente_Telefone.SelecionarTodosPorCliente(clienteTelefone))
            {
                if(item.Descricao == "Celular")
                {
                    idCel = item.Id;
                    descricaoCelular = item.Descricao;
                    numeroCelular = item.Numero;
                }
                if (item.Descricao == "Casa")
                {
                    idCasa = item.Id;
                    descricaoCasa = item.Descricao;
                    numeroCasa = item.Numero;
                }
                if (item.Descricao == "Trabalho")
                {
                    idTrab = item.Id;
                    descricaoTrabalho = item.Descricao;
                    numeroTrabalho = item.Numero;
                }
            }
            var resultado = new
            {
                Id = cliente.Id,
                clienteNome = cliente.Nome,
                clienteEmail = cliente.Email,
                calendario = cliente.DataNascimento.ToShortDateString(),
                Celular = numeroCelular,
                Casa = numeroCasa,
                Trabalho = numeroTrabalho,
                idCel = idCel,
                idCasa = idCasa,
                idTrab = idTrab
            };
            ViewBag.MsgErro = 0;
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AlterarClientes(int Id, string Nome, string Email, string DataNascimento, string Celular, string Casa, string Trabalho, int IdCel, int IdCasa, int IdTrab)
        {
            cliente.Id = Id;
            cliente.Nome = Nome;
            cliente.Email = Email;
            cliente.DataNascimento = Convert.ToDateTime(DataNascimento);
            bLL_Cliente.AlterarCliente(cliente);
            if (cliente.exceptionFull.StatusAtual == true)
            {
                if (!(string.IsNullOrEmpty(Celular)))
                {
                    clienteTelefone.Id = IdCel;
                    clienteTelefone.Descricao = "Celular";
                    clienteTelefone.Numero = Celular;
                    clienteTelefone.cliente.Id = cliente.Id;
                    if (IdCel == 0)
                    {
                        bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                    }
                    else
                    {
                        bLL_Cliente_Telefone.AlterarTelefone(clienteTelefone);
                    }                    
                }
                if (!(string.IsNullOrEmpty(Casa)))
                {
                    clienteTelefone.Id = IdCasa;
                    clienteTelefone.Descricao = "Casa";
                    clienteTelefone.Numero = Casa;
                    clienteTelefone.cliente.Id = cliente.Id;
                    if (IdCasa == 0)
                    {
                        bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                    }
                    else
                    {
                        bLL_Cliente_Telefone.AlterarTelefone(clienteTelefone);
                    }
                }
                if (!(string.IsNullOrEmpty(Trabalho)))
                {
                    clienteTelefone.Id = IdTrab;
                    clienteTelefone.Descricao = "Trabalho";
                    clienteTelefone.Numero = Trabalho;
                    clienteTelefone.cliente.Id = cliente.Id;
                    if (IdTrab == 0)
                    {
                        bLL_Cliente_Telefone.AdicionarClienteTelefone(clienteTelefone);
                    }
                    else
                    {
                        bLL_Cliente_Telefone.AlterarTelefone(clienteTelefone);
                    }
                }
                var resultado = new
                {
                    msgErro = 1,
                };
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resultado = new
                {
                    msgErro = 2,
                };
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Deletar Numero
        [HttpGet]
        public ActionResult DeletarNumero(int id)
        {
            clienteTelefone.Id = id;
            bLL_Cliente_Telefone.DeletarNumero(clienteTelefone.Id);
            var resultado = new
            {
                msgErro = 1,
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Deletar Cliente
        [HttpGet]
        public ActionResult DeletarCliente(int id)
        {
            cliente.Id = id;
            bLL_Cliente_Telefone.DeletarNumeroCliente(id);           
            bLL_Cliente.DeletarCliente(cliente.Id);
            var resultado = new
            {
              msgErro = 1,
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);               
        }
        #endregion

        #region Detalhes
        [HttpGet]
        public ActionResult Detalhes(int Id)
        {
            cliente.Id = Id;
            clienteTelefone.cliente.Id = Id;
            ViewBag.Id = Id;
            bLL_Cliente.SelecionarCliente(cliente);
            ViewBag.Nome = cliente.Nome;
            ViewBag.Email = cliente.Email;
            ViewBag.DataNascimento = cliente.DataNascimento.ToShortDateString();
            ViewBag.DataCadastro = cliente.DataCadastro;
            ViewBag.DataAlteracao = cliente.DataAlteracao;
            ViewBag.Telefone = bLL_Cliente_Telefone.SelecionarTodosPorCliente(clienteTelefone);
            return View();
        }
        #endregion
    }
}