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
        public string Titulo {get; protected set;}
        protected string Ano {get;set;}
        protected Types Types {get;set;}
        public void Delete() 
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("EXCLUIR TITULOS:");
            Console.WriteLine("-----------------\n");
            Console.WriteLine("1 - SERIES\n2 - FILMES");
            var ctrl = Convert.ToInt32(Console.ReadLine());
            List(ctrl);
            Console.WriteLine("\nInforme o Id do titulo que deseja excluir:");
            var IdTitle = Console.ReadLine();
            switch(ctrl)
            {
                case 1:
                    RepositorySeries repositorySerie = new RepositorySeries();
                    repositorySerie.DelFromList(Convert.ToInt32(IdTitle));
                break;

                case 2:
                    RepositoryMovies repositoryMovie = new RepositoryMovies();
                    repositoryMovie.DelFromList(Convert.ToInt32(IdTitle));
                break;
            }
        }
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
                        if (control) {arr[1] = temp;} else { Functions.WriteError("Informe um Gênero valido!\n");}
                    }
                    else if (type == "2")
                    {
                        control = Functions.CheckGen<TypeMovies>(temp);
                        if (control) {arr[1] = temp;} else { Functions.WriteError("Informe um Gênero valido!\n");}
                    }
                }
                
                Console.WriteLine("Informe o nome do Titulo:");
                arr[2] = Console.ReadLine();
                Console.WriteLine("Informe o Ano de lançamento:");
                arr[3] = Console.ReadLine();
            }
            catch (ArgumentNullException)
            {
            Functions.WriteError("Informe uma opção valida!");
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
                        Console.WriteLine("--------------------------------------------- SERIES ---------------------------------------------\n");
                            foreach(var item in RepositorySeries.KeepSeries)
                            {
                                Console.WriteLine($"#{item.Id} | {item.Types} | GENERO: {item.Genero} | TITULO: {item.Titulo} | DATA DE LANÇAMENTO: {item.Ano}\n");
                            }
                    break;
                    case 2:
                        Console.WriteLine("--------------------------------------------- FILMES ---------------------------------------------\n");
                            foreach(var item in RepositoryMovies.KeepMovies)
                            {
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