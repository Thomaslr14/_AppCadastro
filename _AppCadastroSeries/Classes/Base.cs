using System;
using _AppCadastroSeries.Interfaces;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Classes.Repositories;

namespace _AppCadastroSeries.Classes
{
    public abstract class Base : IRepo
    {
        public int Id {get; protected set;}
        protected string Titulo {get;set;}
        protected string Ano {get;set;}
        protected Types Types {get;set;}
        public void Delete() {}
        public void Update(){}

        public string[] Create()
        {
            string[] arr = new string[4];
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
                                Console.WriteLine("\nGêneros");
                                Console.WriteLine("-------\n");
                                arr[0] = Convert.ToString(Enums.Types.Serie);
                                Functions.ShowEnums<TypeSeries>();
                                control = true;
                            break;

                            case "2":
                                Console.WriteLine("\nGêneros");
                                Console.WriteLine("-------\n");
                                arr[0] = Convert.ToString(Enums.Types.Movie);
                                Functions.ShowEnums<TypeMovies>();
                                control = true;
                            break;

                            default:
                                throw new ArgumentNullException();
                            
                        }
                    }
                    catch(ArgumentNullException)
                    {
                        Functions.WriteError("Informe uma opção valida!\n");
                    }
                    
                } while (!control);
                
                
                control = false;
                while (!control)
                {
                    Console.WriteLine("Informe o Genero:");
                    var temp = Console.ReadLine();  
                    if (type == "1")
                    {
                        control = Functions.CheckGen<TypeSeries>(temp);
                        if (control) {arr[1] = temp;} else { Console.WriteLine("Informe um Gênero valido!");}
                    }
                    else if (type == "2")
                    {
                        control = Functions.CheckGen<TypeMovies>(temp);
                        if (control) {arr[1] = temp;} else { Console.WriteLine("Informe um Gênero valido!");}
                    }
                }
                
                Console.WriteLine("Informe o nome do Titulo:");
                arr[2] = Console.ReadLine();
                Console.WriteLine("Informe o Ano de lançamento:");
                arr[3] = Console.ReadLine();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Informe uma opção valida!");
            }
            
            return arr;
        }
        public void List(int ctrl)
        {
            try 
            {
                switch(ctrl)
                {
                    case 1:
                        foreach(var item in RepositorySeries.KeepSeries)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"#{item.Id} | {item.Types} | GENERO: {item.Genero} | TITULO: {item.Titulo} | DATA DE LANÇAMENTO: {item.Ano}\n");
                        }
                    break;
                    case 2:
                        foreach(var item in RepositoryMovies.KeepMovies)
                        {
                            Console.WriteLine("");
                            Console.WriteLine($"#{item.Id} | {item.Types} | GENERO: {item.Genero} | TITULO: {item.Titulo} | DATA DE LANÇAMENTO: {item.Ano}\n");
                        }
                    break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();        
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Functions.WriteError("Informe uma opção valida!");
                return;
            }
            
        }
    }
}