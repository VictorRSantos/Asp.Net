using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class AutorController : Controller
    {
        private BibliotecaDB db = new BibliotecaDB();
        // GET: Autor
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
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autor);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(autor);
        }


        public ActionResult Edit(int id)
        {
            Autor autor = db.Autores.Find(id);
            if (autor.Id == null)
            {
                return HttpNotFound();

            }

            return View(autor);
          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Autor autor)
        {

            if (ModelState.IsValid)
            {
                db.Entry(autor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);

        }

    }
}