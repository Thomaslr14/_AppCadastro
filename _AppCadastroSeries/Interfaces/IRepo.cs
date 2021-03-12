using System.Collections.Generic;

namespace _AppCadastroSeries.Interfaces
{
    public interface IRepo
    {
        string[] Create();
        List<object> List();

        void Update();

        void Delete();
    }
}