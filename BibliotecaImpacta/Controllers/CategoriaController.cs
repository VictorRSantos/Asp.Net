using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
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
            return View(db.Autores.ToList());
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

    }
}