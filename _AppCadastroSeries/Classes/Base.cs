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
            bool control = false;
            string type;
            Console.Clear();
            try
            {
                do
                {
                Console.WriteLine("----------------------");
                Console.WriteLine("ADICIONAR NOVO TITULO:");
                Console.WriteLine("----------------------\n");
                Console.WriteLine("Qual o tipo do Titulo?");
                Console.WriteLine("1 - SERIE\n2 - FILME");
                type = Console.ReadLine();
                    try 
                    {   
                        switch (type)
                        {
                            case "1":
                                Console.WriteLine("####### Gêneros #######");
                                arr[0] = Convert.ToString(Enums.Types.Serie);
                                Functions.ShowEnums<TypeSeries>();
                                control = true;
                            break;

                            case "2":
                                Console.WriteLine("####### Gêneros #######");
                                arr[0] = Convert.ToString(Enums.Types.Movie);
                                Functions.ShowEnums<TypeMovies>();
                                control = true;
                            break;

                            default:
                                throw new ArgumentException();
                            
                        }
                    }
                    catch(ArgumentException)
                    {
                        Console.WriteLine("Informe uma opção valida!\n");
                    }
                    
                } while (!control);
                
                
                bool ctrl = false;
                while (!ctrl)
                {
                    Console.WriteLine("\nInforme o Genero:");
                    var temp = Console.ReadLine();  
                    if (type == "1")
                    {
                        ctrl = Functions.CheckGen<TypeSeries>(temp);
                        if (ctrl) {arr[1] = temp;} else { Console.WriteLine("Informe um Gênero valido!");}
                    }
                    else if (type == "2")
                    {
                        ctrl = Functions.CheckGen<TypeMovies>(temp);
                        if (ctrl) {arr[1] = temp;} else { Console.WriteLine("Informe um Gênero valido!");}
                    }
                }
                
                Console.WriteLine("Informe o nome do Titulo:");
                arr[2] = Console.ReadLine();
                Console.WriteLine("Informe o Ano de lançamento:");
                arr[3] = Console.ReadLine();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Informe uma opção valida!");
            }
            
            return arr;
        }
    }
}