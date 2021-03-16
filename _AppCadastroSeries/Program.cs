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
                        break;
                        
                        case "3":
                        break;
                        
                        case "4":
                        break;
                        
                        default:
                            throw new ArgumentNullException();
                    }
                
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Informe uma opção valida!");
                    option = ChooseOption();
                }

                option = ChooseOption();
            }
            Functions.Exit();
        }

        static string ChooseOption()
        {
            Console.WriteLine("Bem vindo ao DIO Stream!");
            Console.WriteLine("1 - Inserir série");
            Console.WriteLine("2 - Listar séries");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("Escolha a opção desejada");
            string opt = Console.ReadLine();
            return opt;
        }
    }
}
