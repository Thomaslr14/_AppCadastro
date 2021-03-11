using System.Collections.Generic;

namespace _AppCadastroSeries.Interfaces
{
    public interface IRepo
    {
        object Create();
        List<object> List();

        void Update();

        void Delete();
    }
}