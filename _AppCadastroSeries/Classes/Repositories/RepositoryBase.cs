using System;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.Repositories
{   
    public class RepositoryBase 
    {
        protected static bool PassInformation = false;
        protected static object AddBase(string[] param, int id)
        {
            int _id = id;
            Types _TypeOfTitle = (Types)Types.Parse(typeof(Types), param[0]);
            string _Title = param[2];
            string _Year = param[3];
            if (Convert.ToInt32(_TypeOfTitle) == 0)
            {
                var _TypeOfGen = (TypeMovies) Enum.Parse(typeof(TypeMovies),param[1]);
                Movie movie = new Movie(_id, _TypeOfTitle, _TypeOfGen, _Title, _Year);
                return movie;
            }
            else if (Convert.ToInt32(_TypeOfTitle) == 1)
            {
                var _TypeOfGen = (TypeSeries) Enum.Parse(typeof(TypeSeries),param[1]);
                Serie serie = new Serie(_id, _TypeOfTitle, _TypeOfGen, _Title, _Year);
                return serie;
            }
            else
            {
                throw new Exception();
            }
        }

        protected static void UpdateBase(ref Types newTypeTitle,
                                        ref Enum newGenTitle,
                                        ref string newNameTitle,
                                        ref string newYearTitle)
        {
            string option;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------");
                Console.WriteLine("ATUALIZANDO TITULO");
                Console.WriteLine("-------------------");
                Console.WriteLine("1 - TIPO");
                Console.WriteLine("2 - GENERO");
                Console.WriteLine("3 - NOME DO TITULO");
                Console.WriteLine("4 - DATA DE LANÇAMENTO");
                Console.WriteLine("S - SALVAR");
                Console.WriteLine("X - SAIR");
                Console.WriteLine("Informe o que deseja atualizar:");
                option = Console.ReadLine();
                try
                {
                    switch(option.ToUpper())
                    {
                    case "1":
                        Console.WriteLine("\nNOVO TIPO:");
                        Console.WriteLine("---------");
                        Console.WriteLine("1 - SERIE");
                        Console.WriteLine("2 - FILME");
                        var temp = Console.ReadLine();
                        if (temp == "1" || temp == "2")
                            newTypeTitle = (Types) Enum.Parse(typeof(Types), temp);
                        else
                            throw new ArgumentNullException();
                    break;

                    case "2":
                       
                        if (Convert.ToInt32(newTypeTitle) == 1)
                        {
                            Console.WriteLine("\nNOVO GENERO:");
                            Console.WriteLine("---------");
                            Functions.ShowEnums<TypeSeries>();
                            var tmp = Console.ReadLine();
                            if(Functions.CheckGen<TypeSeries>(tmp))
                                newGenTitle = (TypeSeries) Enum.Parse(typeof(TypeSeries), tmp);
                            else
                                throw new ArgumentOutOfRangeException();

                        }
                        else if (Convert.ToInt32(newTypeTitle) == 2)
                        {
                            Console.WriteLine("\nNOVO GENERO:");
                            Console.WriteLine("---------");
                            Functions.ShowEnums<TypeMovies>();  
                            var tmp = Console.ReadLine();
                            if(Functions.CheckGen<TypeMovies>(tmp))
                                newGenTitle = (TypeMovies) Enum.Parse(typeof(TypeMovies), tmp);
                            else
                                throw new ArgumentOutOfRangeException(); 

                        }
                    break;

                    case "3":
                        Console.WriteLine("\nNOVO NOME:");
                        Console.WriteLine("---------");
                        temp = Console.ReadLine();
                        if (!string.IsNullOrEmpty(temp))
                            newNameTitle = temp;
                        else
                            throw new ArgumentNullException();
                    break;

                    case "4":
                        Console.WriteLine("\nNOVA DATA DE LANÇAMENTO:");
                        Console.WriteLine("---------");
                        temp = Console.ReadLine();
                        if (Functions.CheckYear(temp))
                            newYearTitle = temp;
                        else
                            throw new ArgumentNullException();
                    break;

                    case "S":
                        PassInformation = true;
                        return;
                    

                    default:
                    break;
                    }

                }
                catch (ArgumentNullException)
                {
                    Functions.WriteError("Informe uma opção valida!\n");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Functions.WriteError("Informe um gênero valido!\n");
                }
                
                
            } while (option.ToUpper() != "X");
            
        }
    
    }
}