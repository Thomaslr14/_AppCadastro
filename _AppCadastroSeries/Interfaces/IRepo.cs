using System.Collections.Generic;

namespace _AppCadastroSeries.Interfaces
{
    public interface IRepo
    {
        string[] Create();
        bool List(int ctrl);
        void Update(out int SelectedOption, out int SelectedId);
        void Delete();
    }
}