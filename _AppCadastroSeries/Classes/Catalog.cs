using System;
using _AppCadastroSeries.Classes.Repositories;
using _AppCadastroSeries.Classes.OtherFunctions;

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
            Console.WriteLine("-----------------");
            Console.WriteLine("LISTAR TITULOS:");
            Console.WriteLine("-----------------\n");
            Console.WriteLine("1 - SERIES\n2 - FILMES");
            try
            {
                var ctrl = Convert.ToInt32(Console.ReadLine());
                Catalog catalog = new Catalog();
                catalog.List(ctrl);
            }
            catch (FormatException)
            {
                Functions.WriteError("Informe uma opção valida!\n");
            }
        }
        public static void DeleteTitle()
        {
            Catalog catalog = new Catalog();
            catalog.Delete();
        }
        public static void UpdateTitle()
        {
            Catalog catalog = new Catalog();
            int[] param = new int[2];
            param = catalog.Update();
            if (param[0] == 1)
            {
                RepositorySeries repositorySeries = new RepositorySeries();
                bool cond = RepositorySeries.KeepSeries.Find(x => x.Id == param[1]).Excluded;
                if (!cond)
                {
                    // verdadeira
                }
                else 
                {
                    Functions.WriteError("");
                }
            }
            else if (param[0] == 2)
            {
                RepositoryMovies repositoryMovies = new RepositoryMovies();
            }
            else 
            {

            }
            
        }
        
    }
}