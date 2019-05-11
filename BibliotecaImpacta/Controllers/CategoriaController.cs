using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class CategoriaController : Controller
    {
        //Variavel para o context do Entity FrameWork
        private BibliotecaDB db = new BibliotecaDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();

        }
        
        [HttpPost]
        //verificar se o MVC esta enviando uma requisição para o servidor
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            /*Verificar se a Model é válida, vai verificar se a nossa categoria está recebendo no nosso formulario,
             * está preenchida com as informações se precisa criar uma categoria nova, caso não esteja vai retornar
             * para essa mesma página com as informações já preenchidas
            */
            if (ModelState.IsValid)
            {
                //Adiciona uma nova categoria
                db.Categorias.Add(categoria);
                //Salva a categoria no banco
                db.SaveChanges();
                //Redireciona para página index
                return RedirectToAction("Index");

            }
            //Senão volta para página categoria com as informações já preenchidas
            return View(categoria);


        }

        public ActionResult Details()
        {
            List<Categoria> listaCategoria = db.Categorias.ToList();

            return View(listaCategoria);


        }

       
        public ActionResult Edit (int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {

                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(categoria);

        }


        public ActionResult Delete(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Attach(categoria);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            return Content("Remoção realizada");

        }
        

    }
}