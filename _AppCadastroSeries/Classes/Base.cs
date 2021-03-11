using System.Collections.Generic;
using _AppCadastroSeries.Interfaces;

namespace _AppCadastroSeries.Classes
{
    public abstract class Base : IRepo
    {
        protected int Id {get;set;}
        protected string Titulo {get;set;}
        protected string Ano {get;set;}

        public abstract object Create();
        public abstract void Delete();
        public abstract List<object> List();
        public abstract void Update();
    }
}