using System;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Enums;

namespace _AppCadastroSeries.Classes.Repositories
{   
    public class RepositoryBase : Base
    {


        protected static bool PassInformation = false;
        protected object AddBase(string[] param, int id)
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

        protected void UpdateBase(ref Enum newGenTitle,
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
                Console.WriteLine("1 - GENERO");
                Console.WriteLine("2 - NOME DO TITULO");
                Console.WriteLine("3 - ANO DE LANÇAMENTO");
                Console.WriteLine("S - SALVAR");
                Console.WriteLine("X - SAIR");
                Console.WriteLine("Informe o que deseja atualizar:");
                option = Console.ReadLine();
                try
                {
                    switch(option.ToUpper())
                    {
                    case "1":
                        Console.WriteLine("\nNOVO GENERO:");
                        Console.WriteLine("------------");
                        if (newGenTitle.GetType().Name == "TypeSeries")
                        {
                            Functions.ShowEnums<TypeSeries>();
                            Console.WriteLine("Informe o novo gênero:");
                            var tmp = Console.ReadLine();
                            if(Functions.CheckGen<TypeSeries>(tmp))
                                newGenTitle = (TypeSeries) Enum.Parse(typeof(TypeSeries), tmp);
                            else
                                throw new ArgumentOutOfRangeException();
                        }
                        else if(newGenTitle.GetType().Name == "TypeMovies")
                        {
                            Functions.ShowEnums<TypeMovies>();
                            Console.WriteLine("Informe o novo gênero:");
                            var tmp = Console.ReadLine();
                            if(Functions.CheckGen<TypeMovies>(tmp))
                                newGenTitle = (TypeMovies) Enum.Parse(typeof(TypeMovies), tmp);
                            else
                                throw new ArgumentOutOfRangeException(); 
                        }
                        else
                            throw new NullReferenceException(); 
                            
                    break;

                    case "2":
                        Console.WriteLine("\nNOVO NOME:");
                        Console.WriteLine("------------");
                        var temp = Console.ReadLine();
                        if (!string.IsNullOrEmpty(temp))
                            newNameTitle = temp;
                        else
                            throw new ArgumentNullException();
                    break;

                    case "3":
                        Console.WriteLine("\nNOVO ANO DE LANÇAMENTO:");
                        Console.WriteLine("------------");
                        temp = Console.ReadLine();
                        if (Functions.CheckYear(temp))
                            newYearTitle = temp;
                        else
                            throw new ArgumentNullException();
                    break;

                    case "S":
                        PassInformation = true;
                        return;


                    case "X":
                        
                    break;
                    

                    default:
                        throw new Exception();
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
                catch (NullReferenceException)
                {
                    Functions.WriteError("Opção Inválida!\n");
                }

                catch (Exception)
                {
                    Functions.WriteError("Houve um erro ao processar a solicitação!\n");
                }
                
                
            } while (option.ToUpper() != "X");
            

        }
    
    }
}