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
        [ValidateAntiForgeryToken]
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



        public ActionResult Details()
        {
            List<Cliente> lClientes = db.Clientes.ToList();
            return View(lClientes);
        }


        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            if (cliente.Id == null)
            {
                return HttpNotFound();
            }

            return View(cliente);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(cliente);

        }



        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            db.Clientes.Attach(cliente);

            db.Clientes.Remove(cliente);

            db.SaveChanges();

            return Content("Cliente removido com sucesso!");
        }




    }
}