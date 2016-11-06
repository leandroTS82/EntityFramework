using System;
using System.Web.Mvc;
using Models;
using Data;
using Data.Entity;

namespace Apresentacao.Controllers
{
    public class CRUDController : Controller
    {

        public ActionResult Read()
        {
            DataEntity context = new DataEntity();
            EntityGeneric<Emails> data = new EntityGeneric<Emails>(context);
            ViewBag.listaEmails = data.buscar();
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            DataEntity context = new DataEntity();

            string nome = form["Nome"];
            string email = form["Email"];
            Emails emails = new Emails();
            emails.Nome = nome;
            emails.Email = email;
            EntityGeneric<Emails> data = new EntityGeneric<Emails>(context);
            data.inserir(emails);

            return RedirectToAction("Read");
        }

        public ActionResult Delete(string ID)
        {
            DataEntity context = new DataEntity();
            EntityGeneric<Emails> data = new EntityGeneric<Emails>(context);
            data.deletar(Convert.ToInt32(ID));
            return RedirectToAction("Read");
        }

        public ActionResult Edit(string ID)
        {
            DataEntity context = new DataEntity();
            EntityGeneric<Emails> data = new EntityGeneric<Emails>(context);
            Emails email = data.buscar(Convert.ToInt32(ID));
            return View(email);
        }

        public ActionResult Update(FormCollection formUpdate)
        {
            DataEntity context = new DataEntity();
            EntityGeneric<Emails> data = new EntityGeneric<Emails>(context);
            Emails email = new Emails();
            email.Id = Convert.ToInt32(formUpdate["Id"]);
            email.Nome = formUpdate["Nome"];
            email.Email = formUpdate["Email"];

            data.atualizar(email);
            return RedirectToAction("Read");
        }

    }
}