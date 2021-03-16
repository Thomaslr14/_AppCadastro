using System;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.Repositories
{   
    public class RepositoryBase
    {
        
        protected static void AddBase<T>(string[] param, int id)
        {
            int _id = id;
            Types _TypeOfTitle = (Types)Types.Parse(typeof(Types), param[0]);
            T _TypeOfGen = (T) Enum.Parse(typeof(T),param[1]);
            string _Title = param[2];
            string _Year = param[3];

            

        }
    }
}