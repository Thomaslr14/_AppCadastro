using System.Collections.Generic;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Interfaces;
using System;

namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositorySeries : RepositoryBase, IPattern
    {
        public static List<Serie> KeepSeries = new List<Serie>();
        
        public void AddToList(string[] param)
        {
            int _Id = 0;
            ReturnId(ref _Id);
            AddBase(param, _Id);
            
            try
            {
                KeepSeries.Add((Serie)AddBase(param, _Id));
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
            if (KeepSeries.Count == 0)
                return;
            else
                id = KeepSeries.Count;

        }
    }
}