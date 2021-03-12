using _AppCadastroSeries.Classes.Repositories;

namespace _AppCadastroSeries.Classes
{
    public class Catalog : Base
    {
        
        
        public static void CreateTitle()
        {
            string[] received = new string[5];

            Catalog catalog = new Catalog();
            received = catalog.Create();
            
            RepositoryMovies repositoryMovies = new RepositoryMovies();
            if (Enums.Types.Movie.Equals(received[0]))
            {
                repositoryMovies.AddToList(received);
            }
            else if(Enums.Types.Serie.Equals(received[0]))
            {
                
            }
                
        }
    }
}