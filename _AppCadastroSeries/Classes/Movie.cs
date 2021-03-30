using _AppCadastroSeries.Enums;
using System;

namespace _AppCadastroSeries.Classes
{
    public class Movie : Base
    {
        private TypeMovies _Genero {get;set;}

        public Enum Genero 
        {
            get {return _Genero;}
            set { _Genero = (TypeMovies)value;}
        }
        public Movie(int Identifier, Types TypeOfTitle, 
        Enum Gen, string Title, string Year)
        {
            Id = Identifier;
            Types = TypeOfTitle;
            Genero = (TypeMovies)Gen;
            Titulo = Title;
            Ano = Year;
        }
    }
}

