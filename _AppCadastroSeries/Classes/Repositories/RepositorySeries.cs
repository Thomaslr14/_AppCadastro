using System.Collections.Generic;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Interfaces;
using System;

namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositorySeries : RepositoryBase, IPattern
    {
        public static List<Serie> KeepSeries = new List<Serie>();
        Serie ss = new Serie();

        public void AddToList(string[] param)
        {
            int id = 0;
            ReturnId(ref id);
            AddBase<TypeSeries>(param, id);
            
            
            KeepSeries.Add(ss);
            

        }

        

        public static void ReturnId(ref int id)
        {
            if (KeepSeries.Count == 0)
                return;
            else
                id = KeepSeries.Count;

        }
    }
}