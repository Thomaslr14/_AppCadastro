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
            
            KeepMovies.Add((Movie)AddBase(param, _Id));
        }

        private void ReturnId(ref int id)
        {
            if (KeepMovies.Count == 0)
                return;
            else
                id = KeepMovies.Count;

        }
    }
}