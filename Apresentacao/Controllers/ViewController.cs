using Data;
using Data.Entity;
using Models;
using System;
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
            ViewBag.listaEmails = data.buscar();
            return View();
        }

        public ActionResult Delete(string ID)
        {
            DataEntity context = new DataEntity();
            AbstractData<Emails> data = new AbstractData<Emails>(context);
            data.deletar(Convert.ToInt32(ID));
            return RedirectToAction("ViewEmail");
        }

        public ActionResult BuscaID(string ID)
        {
            DataEntity context = new DataEntity();
            AbstractData<Emails> data = new AbstractData<Emails>(context);
            Emails email = data.buscar(Convert.ToInt32(ID));
            return View(email);
        }
        [HttpPost]
        public ActionResult Update(Emails email)
        {
            DataEntity context = new DataEntity();
            AbstractData<Emails> data = new AbstractData<Emails>(context);
            data.atualizar(email);
            return RedirectToAction("ViewEmail");
        }
    }
}