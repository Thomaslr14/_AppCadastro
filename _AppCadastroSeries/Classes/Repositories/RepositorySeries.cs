using System.Collections.Generic;
using _AppCadastroSeries.Enums;
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
            
            KeepSeries.Add((Serie)AddBase(param, _Id));
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