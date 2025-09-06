using OrmTest.Entity;
using OrmTest.Repository;
using System;
using System.Data.Common;
using J3d.Domain.Entity;
using J3d.Orm.Repository;

namespace OrmTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //TestarPagina();
                //TestarImage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void TestarImage()
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connectionString = @"Data Source=JOMAR\OBJETIVA2005;Initial Catalog=J3d;User ID=sa;Password=123456";
            var repositorio = new ImageRepository(factory, connectionString);

            var image01 = new Image("Teste 01", @"D:\Images\Image01.png");

            var image02 = new Image("Teste 02", @"D:\Images\Image02.png");
            image02.SetAlt("Teste de texto alternativo...");

            repositorio.Add(image01);
            repositorio.Add(image02);

            var imagem03 = repositorio.Find(3);
            var imagem04 = repositorio.Find(5);

            if (imagem03 != null)
            {
                imagem03.Change("Imagem 03", @"D:\Images\Image03.png");
                imagem03.SetAlt(null);
                repositorio.Update(imagem03);
            }
        }

        private static void TestarPagina()
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connectionString = @"Data Source=JOMAR\OBJETIVA2005;Initial Catalog=J3d;User ID=sa;Password=123456";
            var repositorio = new PaginaRepository(factory, connectionString);

            var pagina01 = new Pagina
            {
                Title = "Pagina 01",
                Text = "Exemplo de texto curto da página 01",
            };
            pagina01.SetName(nameof(pagina01));
            repositorio.Add(pagina01);

            var pagina02 = new Pagina
            {
                Title = "Pagina 02",
                Text = "Exemplo de texto curto da página 02",
            };
            pagina02.SetName(nameof(pagina02));
            repositorio.Add(pagina02);

            foreach (var pagina in repositorio.SelectAll())
            {
                Console.WriteLine($"Página: {pagina.Id} - {pagina.Title}\n");
                Console.WriteLine($"Texto: {pagina.Text}\n");
                Console.WriteLine($"Data: {pagina.Date}\n");
                Console.WriteLine("========================================\n");
            }

            pagina02.Title = pagina02.Title + " - alterado...";

            repositorio.Update(pagina02);

            repositorio.Delete(pagina01);

            foreach (var pagina in repositorio.SelectAll())
            {
                Console.WriteLine($"Página: {pagina.Id} - {pagina.Title}\n");
                Console.WriteLine($"Texto: {pagina.Text}\n");
                Console.WriteLine($"Data: {pagina.Date}\n");
                Console.WriteLine("========================================\n");
            }
        }
    }
}
