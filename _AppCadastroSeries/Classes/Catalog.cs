using System;
using _AppCadastroSeries.Classes.Repositories;

namespace _AppCadastroSeries.Classes
{
    public class Catalog : Base
    {
        
        public static void CreateTitle()
        {
            Catalog catalog = new Catalog();
            string[] received = new string[4];
            received = catalog.Create();
            
            if (Enums.Types.Movie.ToString() == received[0])
            {
                RepositoryMovies repositoryMovies = new RepositoryMovies();
                repositoryMovies.AddToList(received);
            }
            else if(Enums.Types.Serie.ToString() == received[0])
            {
                RepositorySeries repositorySeries = new RepositorySeries();
                repositorySeries.AddToList(received);
            }
        }

        public static void ListTitles()
        {
            Console.Clear();
            Console.WriteLine("------------------");
            Console.WriteLine("LISTAR TITULOS:");
            Console.WriteLine("------------------\n");
            Console.WriteLine("1 - SERIES\n2 - FILMES");
            var ctrl = Convert.ToInt32(Console.ReadLine());
            Catalog catalog = new Catalog();
            catalog.List(ctrl);
        }
    }
}