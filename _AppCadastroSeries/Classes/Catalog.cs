using _AppCadastroSeries.Classes.Repositories;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes
{
    public class Catalog : Base
    {
        
        public static void CreateTitle()
        {
            Catalog catalog = new Catalog();
            string[] received = new string[5];
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
    }
}