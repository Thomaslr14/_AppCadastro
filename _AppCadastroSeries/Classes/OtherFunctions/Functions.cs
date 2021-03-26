using System;
using System.Text.RegularExpressions;
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

        public static bool CheckGen<TEnum>(string i)
        {
            foreach (var series in Enum.GetValues(typeof(TEnum)))
            {   
                if (Convert.ToInt32(i) == Convert.ToInt32(series))
                return true;
            }
            return false;   
        }

        public static void Exit()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Até mais jovem Padawan!");
            Console.WriteLine("Que a força esteja com você!");
            Console.WriteLine("------------------------------");
            Environment.Exit(0);
        }

        public static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    
        public static bool CheckYear(string year)
        {
            var pattern = @"^(19|20)\d{2}$"; 
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(year))
            {
                return true;
            }
            return false;
        }
    
    }
}