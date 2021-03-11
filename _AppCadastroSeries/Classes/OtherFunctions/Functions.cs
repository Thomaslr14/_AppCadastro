using System;
using _AppCadastroSeries.Classes;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.OtherFunctions
{
    public class Functions
    {
        public void Show() 
        {
            int index = 0;
            int a = Enum.GetValues(typeof(TypeSeries)).Length;
            
            
                foreach( Enums.TypeSeries series in Enum.GetValues(typeof(TypeSeries)))
                {
                    for(index = 0; index < a; index++)
                    {
                        Console.WriteLine($"#{index} - {series}");
                    }
                }
        }
    }
}