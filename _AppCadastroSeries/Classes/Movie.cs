using System.Collections.Generic;
using System;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Classes.OtherFunctions;


namespace _AppCadastroSeries.Classes
{
    public class Movie : Base
    {
        private TypeMovies _Genero {get;set;}

        // public TypeMovies Genero 
        // {
        //     get {return _Genero;}
        //     set { _Genero = value;}
        // }

        Functions func = new Functions();
        public override object Create()
        {
            Movie movie = new Movie();
            


            Console.WriteLine("Informe um Titulo:");
            movie.Titulo = Console.ReadLine();
            Console.WriteLine("Informe o Ano:");
            movie.Ano = Console.ReadLine();
            Console.WriteLine("Informe o Genero:");

            




            return movie;
        }

        public override void Delete()
        {
            throw new System.NotImplementedException();
        }

        public override List<object> List()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}