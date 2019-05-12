using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class ClienteController : Controller
    {
        
        private  BibliotecaDB db = new BibliotecaDB();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
       
        public ActionResult Create(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();

                return RedirectToAction("Index");
                
            }

            return View(cliente);



        }

    }
}