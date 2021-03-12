using System.Collections.Generic;

namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositoryMovies : Base
    {
        public static List<Serie> KeepMovies {get;set;}

        //metodo para inserir as informaões na Collection acima

        public void AddToList(string[] param)
        {
            bool contains = true;
            int j = 0;
            while (contains)
            {
                if (!(contains = (bool) KeepMovies.Exists(x => x.Id == j)))
                    break;
                else
                    j++;
            }

        }
    }
}