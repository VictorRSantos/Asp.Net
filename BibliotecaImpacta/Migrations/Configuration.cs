namespace BibliotecaImpacta.Migrations
{
    using BibliotecaImpacta.DataContext;
    using BibliotecaImpacta.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BibliotecaImpacta.DataContext.BibliotecaDB>
    {
        /*Vamos deixar configuration como True para sempre atualizar o banco de dados*/
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        //Vai inserir valores definidos como padrão
        protected override void Seed(BibliotecaDB context)
        {

            context.Categorias.AddOrUpdate( c => c.Nome,
                new Categoria {Nome = "Ficção" },
                new Categoria {Nome = "Outros" });



            context.Autores.AddOrUpdate(l => l.Nome,
                new Autor { Nome = "J.K. Rowling" },
                new Autor { Nome = "Autor Inicial" });


        }
    }
}
