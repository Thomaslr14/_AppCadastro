using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes
{
    public class Serie : Base
    {
        private TypeSeries _Genero {get;set;}

        public TypeSeries Genero 
        {
            get { return _Genero;}
            set { _Genero = value;}
        }
        public Serie(int Identifier, Types TypeOfTitle, 
        TypeSeries Gen, string Title, string Year)
        {
            Id = Identifier;
            Types = TypeOfTitle;
            Genero = Gen;
            Titulo = Title;
            Ano = Year;
        }   


    }
}

        

        
