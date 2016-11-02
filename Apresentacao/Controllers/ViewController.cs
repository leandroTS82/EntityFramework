using Data;
using Data.Entity;
using Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Apresentacao.Controllers
{
    public class ViewController : Controller
    {
        
        public ActionResult ViewEmail()
        {
            DataEntity context = new DataEntity();
            AbstractData<Emails> data = new AbstractData<Emails>(context);
            ViewBag.listaEmails = data.buscarTodos();
            return View();
        }
    }
}