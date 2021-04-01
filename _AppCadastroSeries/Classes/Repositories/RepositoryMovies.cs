using System;
using System.Collections.Generic;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Enums;
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
                KeepMovies.Add((Movie)AddBase(param, _Id));
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
                Console.WriteLine($"O Titulo '#{IdTitle} - {KeepMovies[IdTitle].Titulo}' foi excluido!\n");
                KeepMovies[IdTitle].Excluded = true;
            }
            else
            {
                Functions.WriteError("O Id informado não existe!\n");
            }
            
        }
        
        public void UpdateFromList(int SelectedId)
        {
            Types newTypeTitle = KeepMovies.Find(x => x.Id == SelectedId).Types;
            Enum newGenTitle = KeepMovies.Find(x => x.Id == SelectedId).Genero;
            var newNameTitle = KeepMovies.Find(x => x.Id == SelectedId).Titulo;
            var newYearTitle = KeepMovies.Find(x => x.Id == SelectedId).Ano;

            UpdateBase(ref newTypeTitle, ref newGenTitle,
                        ref newNameTitle, ref newYearTitle); 

            try 
            {
                if (PassInformation)
                {
                    var UpdateCtrl = KeepMovies.FirstOrDefault(x => x.Id == SelectedId);
                    UpdateCtrl.Types = newTypeTitle;
                    UpdateCtrl.Genero = newGenTitle;
                    UpdateCtrl.Titulo = newNameTitle;
                    UpdateCtrl.Ano = newYearTitle;
                    System.Threading.Thread.Sleep(10);
                    Console.WriteLine("Titulo atualizado com sucesso!\n");
                    Console.WriteLine("------------------------------");
                }
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