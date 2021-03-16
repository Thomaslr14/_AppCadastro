using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes
{
    public class Movie : Base
    {
        private TypeMovies _Genero {get;set;}

        public TypeMovies Genero 
        {
            get {return _Genero;}
            set { _Genero = value;}
        }
        
        
        public Movie(int Identifier, Types TypeOfTitle, 
        TypeMovies Gen, string Title, string Year)
        {
            Id = Identifier;
            Types = TypeOfTitle;
            Genero = Gen;
            Titulo = Title;
            Ano = Year;
        }
    }
}

