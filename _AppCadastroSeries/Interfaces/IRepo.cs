using System.Collections.Generic;

namespace _AppCadastroSeries.Interfaces
{
    public interface IRepo
    {
        string[] Create();
        void List(int ctrl);
        void Update();
        void Delete();
    }
}