using System;
using System.Collections.Generic;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Interfaces;


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

        public override object Create()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override List<object> List()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}