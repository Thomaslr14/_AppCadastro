using System;
using _AppCadastroSeries.Classes;
using _AppCadastroSeries.Classes.OtherFunctions;

namespace _AppCadastroSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            var option = ChooseOption();
           
            while (option.ToUpper() != "X")
            {
                try 
                {
                    switch(option)
                    {
                        case "1":
                        Catalog.CreateTitle();
                        break;

                        case "2":
                        Catalog.ListTitles();
                        break;
                        
                        case "3":
                        Catalog.DeleteTitle();
                        break;
                        
                        case "4":
                        Catalog.UpdateTitle();
                        break;
                        
                        default:
                            throw new ArgumentNullException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Functions.WriteError("Informe uma opção valida!\n");
                }
                option = ChooseOption();
            }
            Functions.Exit();
        }

        static string ChooseOption()
        {
            Console.WriteLine("\nDIO Stream!");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Inserir novo título");
            Console.WriteLine("2 - Listar títulos");
            Console.WriteLine("3 - Excluir título");
            Console.WriteLine("4 - Atualizar título");
            Console.WriteLine("X - SAIR\n");
            Console.WriteLine("Escolha a opção desejada:");
            string opt = Console.ReadLine();
            return opt;
        }
    }
}
