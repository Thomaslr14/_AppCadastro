using _AppCadastroSeries.Enums;
using System;

namespace _AppCadastroSeries.Classes
{
    public class Serie : Base
    {
        private TypeSeries _Genero {get;set;}

        public Enum Genero 
        {
            get { return _Genero;}
            set { _Genero = (TypeSeries)value;}
        }
        public Serie(int Identifier, Types TypeOfTitle, 
        Enum Gen, string Title, string Year)
        {
            Id = Identifier;
            Types = TypeOfTitle;
            Genero = (TypeSeries)Gen;
            Titulo = Title;
            Ano = Year;
        }   


    }
}

        

        
