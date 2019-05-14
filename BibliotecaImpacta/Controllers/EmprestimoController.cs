using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Helpers;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Controllers
{
    public class EmprestimoController : Controller
    {
        private BibliotecaDB db = new BibliotecaDB();

        // GET: Emprestimo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            @ViewBag.Clientes = RetornaSelectListItem.Clientes();
            @ViewBag.Livros = RetornaSelectListItem.LivrosNaoEmprestados();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                emprestimo.CadastrarEmprestimo(emprestimo);
                return RedirectToAction("Index");
            }
            @ViewBag.Clientes = RetornaSelectListItem.Clientes();
            @ViewBag.Livros = RetornaSelectListItem.LivrosNaoEmprestados();

            return View(emprestimo);

        }


        public ActionResult Details()
        {

            List<Emprestimo> lEmprestimoNaoDevolvido = db.Emprestimos.Where(e => e.LivroFoiDevolvido.Equals(false)).ToList();

            return View(lEmprestimoNaoDevolvido);

        }

        public ActionResult Edit(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);

            if (emprestimo == null)
            {
                return HttpNotFound();

            }

            return View(emprestimo);

        }

        [HttpPost]        
        public ActionResult Edit(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {

                emprestimo.CadastrarDevolucao(emprestimo);
                return RedirectToAction("Extrato", emprestimo);
            }
            return View(emprestimo);
        }


    }
}