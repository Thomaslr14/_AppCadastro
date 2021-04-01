using System;
using _AppCadastroSeries.Interfaces;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Classes.Repositories;

namespace _AppCadastroSeries.Classes
{
    public abstract class Base : IRepo
    {
        public int Id { get; protected set;}
        public string Titulo { get; set;}
        public string Ano {get; set;}
        public Types Types {get; set;}
        private bool _Excluded {get;set;}
        public bool Excluded 
        {
            get { return _Excluded;}
            set { _Excluded = value;}
        }
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
        public int[] Update()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("ATUALIZAR TITULOS:");
            Console.WriteLine("-----------------\n");
            Console.WriteLine("1 - SERIES\n2 - FILMES");
            var opt = Console.ReadLine();
            List(Convert.ToInt32(opt));
            Console.WriteLine("Selecione um título para atualizar:");
            var id = Console.ReadLine();
            int[] arrInt = new int[2];
            arrInt[0] = Convert.ToInt32(opt);
            arrInt[1] = Convert.ToInt32(id);
            return arrInt;
        }
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
                    try
                    {
                        Console.WriteLine("Informe o Genero:");
                        var temp = Console.ReadLine();  
                        if (type == "1")
                        {
                            control = Functions.CheckGen<TypeSeries>(temp);
                            if (control) {arr[1] = temp;} else { throw new FormatException();}
                        }
                        else if (type == "2")
                        {
                            control = Functions.CheckGen<TypeMovies>(temp);
                            if (control) {arr[1] = temp;} else { throw new FormatException();}
                        }
                    } 
                    catch (FormatException)
                    {
                        Functions.WriteError("Informe um gênero valido!\n");
                    }
                    
                }
                Console.WriteLine("Informe o nome do Titulo:");
                arr[2] = Console.ReadLine();

                while (arr[3] == null)
                {
                    Console.WriteLine("Informe o Ano de lançamento:");
                    var year = Console.ReadLine();
                    if (Functions.CheckYear(year))
                        arr[3] = year;
                    else
                        Functions.WriteError("Informe um ano valido!\n");

                }
            }
            catch (ArgumentNullException)
            {
                Functions.WriteError("Informe uma opção valida!\n");
            }
            
            return arr;
        }
        public void List(int ctrl)
        {
            try 
            {
                if (ctrl == 1)
                {
                    if (RepositorySeries.KeepSeries.Capacity == 0)
                    {
                        Console.WriteLine("Nenhuma serie cadastrada!\n");
                    }
                    else 
                    {
                        Console.WriteLine("--------------------------------------------- SERIES ---------------------------------------------\n");
                        foreach(var item in RepositorySeries.KeepSeries)
                        {
                            if  (item.Excluded == false)
                                Console.WriteLine($"#{item.Id} | {item.Types} | GENERO: {item.Genero} | TITULO: {item.Titulo} | DATA DE LANÇAMENTO: {item.Ano}\n");
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------------------------\n");
                    }
                    
                }
                else if (ctrl == 2)
                {
                    if (RepositoryMovies.KeepMovies.Capacity == 0)
                    {
                        Console.WriteLine("Nenhuma filme cadastrado!\n");
                    }
                    else 
                    {
                        Console.WriteLine("--------------------------------------------- FILMES ---------------------------------------------\n");
                        foreach(var item in RepositoryMovies.KeepMovies)
                        {
                            if  (item.Excluded == false)
                                Console.WriteLine($"#{item.Id} | {item.Types} | GENERO: {item.Genero} | TITULO: {item.Titulo} | DATA DE LANÇAMENTO: {item.Ano}\n");
                        }
                        Console.WriteLine("--------------------------------------------------------------------------------------------------\n");
                    }

                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Functions.WriteError("Informe uma opção valida!\n");
                return;
            }
            
        }
    }
}