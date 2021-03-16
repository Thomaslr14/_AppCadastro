using System;
using System.Collections.Generic;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Interfaces;

namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositoryMovies : RepositoryBase, IPattern
    {
        public static List<Movie> KeepMovies = new List<Movie>();
        

        public void AddToList(string[] param)
        {
            int _Id = 0;
            ReturnId(ref _Id);
            AddBase<TypeMovies>(param, _Id);
            

        }

        public static void ReturnId(ref int id)
        {
            if (Convert.ToInt32(KeepMovies) <= 0)
                id = 0;
            else
                id = KeepMovies.Count;

        }
    }
}