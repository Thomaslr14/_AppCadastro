using System;
using System.Collections.Generic;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Interfaces;
using System.Linq;

namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositoryMovies : RepositoryBase, IPattern
    {
        public static List<Movie> KeepMovies = new List<Movie>();        
        public void AddToList(string[] param)
        {
            int _Id = 0;
            ReturnId(ref _Id);
            try
            {
                KeepMovies.Add((Movie)base.AddBase(param, _Id));
                Console.WriteLine("\nTitulo cadastrado com sucesso!\n");
                Console.WriteLine("--------------------------------");
            }
            catch (Exception)
            {
                Functions.WriteError("\nErro ao cadastrar novo titulo!\n");
            }
            
        }
        public void DelFromList(int IdTitle)
        {
            
            if (KeepMovies.Exists(x => x.Id == IdTitle))
            {
                try 
                {
                    if (KeepMovies[IdTitle].Excluded is true)
                    {
                        Functions.WriteError("O Id informado não existe!\n");
                    }
                    else
                    {
                        KeepMovies[IdTitle].Excluded = true;
                        Console.WriteLine($"O Titulo '#{IdTitle} - {KeepMovies[IdTitle].Titulo}' foi excluido!");
                        Console.WriteLine("-----------------------------------\n");
                    }
                    
                }
                catch (Exception)
                {
                    Functions.WriteError("Erro ao excluir Titulo!\n");
                }
            }
            else
            {
                Functions.WriteError("O Id informado não existe!\n");
            }
            
        }
        public void UpdateFromList(int SelectedId)
        {
            try 
            {
                if (KeepMovies.Find(x => x.Id == SelectedId).Excluded)
                {
                    throw new NullReferenceException();
                }
                Enum newGenTitle = KeepMovies.Find(x => x.Id == SelectedId).Genero;
                var newNameTitle = KeepMovies.Find(x => x.Id == SelectedId).Titulo;
                var newYearTitle = KeepMovies.Find(x => x.Id == SelectedId).Ano;

                base.UpdateBase(ref newGenTitle,
                            ref newNameTitle, ref newYearTitle); 

            
                if (PassInformation)
                {
                    var UpdateCtrl = KeepMovies.FirstOrDefault(x => x.Id == SelectedId);
                    UpdateCtrl.Genero = newGenTitle;
                    UpdateCtrl.Titulo = newNameTitle;
                    UpdateCtrl.Ano = newYearTitle;
                    System.Threading.Thread.Sleep(10);
                    Console.WriteLine("\nTitulo atualizado com sucesso!");
                    Console.WriteLine("------------------------------");
                }
            }
            catch (NullReferenceException)
            {
                Functions.WriteError("O Id informado não existe!\n");
            }
            catch (ArgumentException)
            {
                Functions.WriteError("Erro ao atualizar titulo!\n");
            }

        } 
        private void ReturnId(ref int id)
        {
            if (KeepMovies.Count == 0)
                return;
            else
                id = KeepMovies.Count;

        }
    }
}