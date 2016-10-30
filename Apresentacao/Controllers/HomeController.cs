using System;
using System.Web.Mvc;
using Models;
using Data;
using Data.Entity;

namespace Apresentacao.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(FormCollection form)
        {
           DataEntity context = new DataEntity();
            
            string nome = form["Nome"];
            string email = form["Email"];
            Emails emails = new Emails();
            emails.Nome = nome;
            emails.Email = email;            
            AbstractData<Emails> data = new AbstractData<Emails>(context);
            data.inserir(emails);

            return View();
        }
    }
}