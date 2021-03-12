using System.Collections.Generic;
using System;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Classes.OtherFunctions;


namespace _AppCadastroSeries.Classes
{
    public class Movie 
    {
        private TypeMovies _Genero {get;set;}

        public TypeMovies Genero 
        {
            get {return _Genero;}
            set { _Genero = value;}
        }
        
        
    }
}

