using System;
using System.Collections.Generic;
using _AppCadastroSeries.Classes;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.OtherFunctions
{
    public class Functions
    {
        public static void ShowEnums<TEnum>() 
        {
            foreach ( var series in Enum.GetValues(typeof(TEnum)))
            {   
                Console.WriteLine($"{Convert.ToInt32(series)} - {series}");
            }
        }
    }
}