using BibliotecaImpacta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaImpacta.DataContext
{
    //DbContext é implementada pelo Entity Framework
    public class BibliotecaDB:DbContext
    {

        // DbSet -  Vai mapear uma classe para uma tabela dentro do banco de dados.
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Categoria> Categorias { get; set;}

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }
        /*
         * Depois vamos em tools, gerenciamento pacotes Nuget e vamos abrir console.
         * Dentro do console vamos dgitar: enable-migrations, vai habilitar a migrations do nosso projeto
         * primeira coisa vai verificar se existe uma banco de dados.
         *  
         * */

    }
}