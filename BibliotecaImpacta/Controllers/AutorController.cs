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
            return View(db.Autores.ToList());
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


        public ActionResult Details()
        {
            List<Autor> lAutores = db.Autores.ToList();
            return View(lAutores);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //Vai pesquisar autor conforme com a id, esse id vai estar preenchido na nossa lista de autores.
            Autor autor = db.Autores.Find(id);
            //Vamos anexar autor
            db.Autores.Attach(autor);
            //Vamos remover autor
            db.Autores.Remove(autor);
            //Entity framework vai salvar essa informações no banco de dados
            db.SaveChanges();
            //Retornar um string
            return Content("Autor foi removido com sucesso!");
        }

    }
}