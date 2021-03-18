using System;
using System.Collections.Generic;
using _AppCadastroSeries.Classes.OtherFunctions;
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
            try
            {
                KeepMovies.Add((Movie)AddBase(param, _Id));
                Console.WriteLine("\nTitulo cadastrado com sucesso!\n");
                Console.WriteLine("--------------------------------");
            }
            catch (Exception)
            {
                Functions.WriteError("\nErro ao cadastrar novo titulo!\n");
            }
        
            
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