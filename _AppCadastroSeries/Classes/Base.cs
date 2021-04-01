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
            try 
            {
                bool IsEmpty = false;
                IsEmpty = List(ctrl);
                if (IsEmpty)
                {
                    throw new Exception();
                }
                
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

                default:
                    throw new ArgumentNullException();
                
                }
            }
            catch (ArgumentNullException)
            {
                Functions.WriteError("Informe uma opção valida!\n");
            }
            catch (Exception)
            {
                return;
            }
            
        }
        public void Update(out int SelectedOption, out int SelectedId)
        {
            SelectedOption = 0;
            SelectedId = 0;
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("ATUALIZAR TITULOS:");
            Console.WriteLine("-----------------\n");
            Console.WriteLine("1 - SERIES\n2 - FILMES");
            var opt = Console.ReadLine();
            try
            {   
                bool IsEmpty = false;
                IsEmpty = List(Convert.ToInt32(opt));
                if (IsEmpty)
                {
                    throw new Exception();
                }
                else
                {
                    Console.WriteLine("Selecione um título para atualizar:");
                    var id = Console.ReadLine();
                    SelectedOption = Convert.ToInt32(opt);
                    SelectedId = Convert.ToInt32(id);
                }
            }
            catch(NullReferenceException)
            {
                return;
            }
            catch (FormatException)
            {
                Functions.WriteError("Informe uma opção valida!\n");
                return;
            }
            catch (Exception)
            {
                return;
            }
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
        public bool List(int ctrl)
        {
            try 
            {
                if (ctrl == 1)
                {
                    int count = 0;
                    for (int i = 0; i < RepositorySeries.KeepSeries.Count; i++)
                    {
                        
                        if (RepositorySeries.KeepSeries[i]._Excluded == true)
                            count = count + 1;
                    }
                    if (count == RepositorySeries.KeepSeries.Count)
                    {
                        Functions.WriteError("Nenhuma serie cadastrada!");
                        return true;
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
                        return false;
                    }
                    
                }
                else if (ctrl == 2)
                {
                    int count = 0;
                    for (int i = 0; i < RepositoryMovies.KeepMovies.Count; i++)
                    {
                        
                        if (RepositoryMovies.KeepMovies[i]._Excluded == true)
                            count = count + 1;
                    }
                    if (count == RepositoryMovies.KeepMovies.Count)
                    {
                        Functions.WriteError("Nenhuma serie cadastrada!");
                        return true;
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
                        return false;
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
                return true;
            }
            
        }
    }
}