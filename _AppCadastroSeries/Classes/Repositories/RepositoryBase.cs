using System;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.Repositories
{   
    public class RepositoryBase
    {        
        protected static object AddBase(string[] param, int id)
        {
            int _id = id;
            Types _TypeOfTitle = (Types)Types.Parse(typeof(Types), param[0]);
            string _Title = param[2];
            string _Year = param[3];
            if (Convert.ToInt32(_TypeOfTitle) == 0)
            {
                var _TypeOfGen = (TypeMovies) Enum.Parse(typeof(TypeMovies),param[1]);
                Movie movie = new Movie(_id, _TypeOfTitle, _TypeOfGen, _Title, _Year);
                return movie;
            }
            else if (Convert.ToInt32(_TypeOfTitle) == 1)
            {
                var _TypeOfGen = (TypeSeries) Enum.Parse(typeof(TypeSeries),param[1]);
                Serie serie = new Serie(_id, _TypeOfTitle, _TypeOfGen, _Title, _Year);
                return serie;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}