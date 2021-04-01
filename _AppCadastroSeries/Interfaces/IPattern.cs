using System;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Interfaces
{
    public interface IPattern
    {
        void AddToList(string[] param);
        void DelFromList(int IdTitle);
        void UpdateFromList(int SelectedId);
        
    }
}