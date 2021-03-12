using System;
using System.Collections.Generic;
using _AppCadastroSeries.Interfaces;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Classes.OtherFunctions;

namespace _AppCadastroSeries.Classes
{
    public abstract class Base : IRepo
    {
        public int Id {get; protected set;}
        protected string Titulo {get;set;}
        protected string Ano {get;set;}
        protected Types Types {get;set;}
        public void Delete() {}
        public List<object> List() {return null;}
        public void Update(){}

        public string[] Create()
        {
            string[] arr = new string[4];
            Serie s = new Serie();

            try 
            {
                Console.Clear();
                Console.WriteLine("#####################");
                Console.WriteLine("ADICIONAR NOVO TITULO:");
                Console.WriteLine("#####################\n");
                Console.WriteLine("Qual o tipo do Titulo?");
                Console.WriteLine("1 - SERIE\n2 - FILME");
                var type = Convert.ToInt32(Console.ReadLine());
                    if (type == 1) 
                    {
                        arr[0] = Convert.ToString(Enums.Types.Serie);
                        Functions.ShowEnums<TypeSeries>();
                    }   
                    else if (type == 2)
                    {
                        arr[0] = Convert.ToString(Enums.Types.Movie);
                        Functions.ShowEnums<TypeMovies>();
                    }
                Console.WriteLine("\nInforme o Genero:");
                arr[1] = Console.ReadLine();
                Console.WriteLine("Informe o nome do Titulo:");
                arr[2] = Console.ReadLine();
                Console.WriteLine("Informe o Ano de lançamento:");
                arr[3] = Console.ReadLine();

                // do
                // {
                //     if (!(contains = (bool).KeepSeries.Exists(x => x.Id == j)))
                //     {
                //         arr[0] = Convert.ToString(j);
                //         break;
                //     } else 
                //     {
                //         j++;
                //     }
                // } while(contains);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Informe uma opção valida!");
            }
            
            return arr;
        }
    }
}