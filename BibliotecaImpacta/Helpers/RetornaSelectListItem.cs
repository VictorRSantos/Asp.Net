using BibliotecaImpacta.DataContext;
using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaImpacta.Helpers
{
    public class RetornaSelectListItem
    {

        //Criar uma variavel estatica privada para bibliotecaDB
        private static BibliotecaDB db = new BibliotecaDB();


        public static List<SelectListItem> Autores()
        {
            List<Autor> lAutores = new List<Autor>();
            lAutores = db.Autores.ToList();


            List<SelectListItem> listaAutores = lAutores.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });
            return listaAutores;

        }

        public static List<SelectListItem> Categorias()
        {

            List<Categoria> lCategorias = new List<Categoria>();
            lCategorias = db.Categorias.ToList();


            List<SelectListItem> listaCategorias = lCategorias.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Nome,
                    Value = a.Id.ToString(),
                    Selected = false
                };

            });

            return listaCategorias;
        }


        public static List<SelectListItem> LivrosNaoEmprestados (int id = 0)
        {
            var livros = db.Livros.Where(l => l.Quantidade > 0).ToList();

            List<SelectListItem> item = livros.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.Nome,
                    Value = l.Id.ToString(),
                    Selected = (l.Id == id)
                };

            });

            return item;

        }


        public static List<SelectListItem> Clientes (int id = 0)
        {
            var clientes = db.Clientes.ToList();
            List<SelectListItem> item = clientes.ConvertAll(c =>
            {
                return new SelectListItem()
                {

                    Text = c.Nome,
                    Value = c.Id.ToString(),
                    Selected = (c.Id == id)                    

                };

            });
            return item;
        }

    }
}