using AgendaTelefonica.Business.Class;
using AgendaTelefonica.DAO.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AgendaTelefonica.Web.Api
{
    public class ClientesController : Controller
    {
        #region Objetos
        Cliente cliente = new Cliente();
        List<Cliente> listaClientes = new List<Cliente>();
        BLL_Cliente bLL_Cliente = new BLL_Cliente();
        #endregion
        [HttpGet]
        public ActionResult ListarTodos()
        {
            return Json(bLL_Cliente.SelecionarTodos(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            bLL_Cliente.AdicionarCliente(cliente);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
        [HttpPut]
        public ActionResult Alterar(Cliente cliente)
        {
            bLL_Cliente.AlterarCliente(cliente);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult Remover(int id)
        {
            bLL_Cliente.DeletarCliente(id);
            return Json("Deletado com sucesso", JsonRequestBehavior.AllowGet);
        }
    }
}