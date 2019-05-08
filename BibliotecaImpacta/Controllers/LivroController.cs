using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Helpers;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class LivroController : Controller
    {

        private BibliotecaDB db = new BibliotecaDB();

        // GET: Livro
        public ActionResult Index()
        {
            

            return View();
        }

        // GET: Livro/Details/5
        public ActionResult Details()
        {
            List<Livro> livro = db.Livros.ToList();

            return View(livro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            
            @ViewBag.Autores = RetornaSelectListItem.Autores();                       

            @ViewBag.Categorias = RetornaSelectListItem.Categorias();

            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Create(Livro livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Livros.Add(livro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                @ViewBag.Autores = RetornaSelectListItem.Autores();
                @ViewBag.Categorias = RetornaSelectListItem.Categorias();

                return View(livro);
               
                // TODO: Add insert logic here

               
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //Quando tentar acessar uma rota que está errada
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Livro livro = db.Livros.Find(id);

            @ViewBag.Autores = RetornaSelectListItem.Autores();
            @ViewBag.Categorias = RetornaSelectListItem.Categorias();


            return View(livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Edit(Livro livro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(livro).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


                @ViewBag.Autores = RetornaSelectListItem.Autores();
                @ViewBag.Categorias = RetornaSelectListItem.Categorias();

                return View(livro);

            }
            catch
            {
                return View();
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
