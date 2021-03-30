using System;
using System.Collections.Generic;
using System.Linq;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Enums;
using _AppCadastroSeries.Interfaces;

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

            
            if (PassInformation)
            {                    
                var ctrlMovie = KeepMovies.FirstOrDefault(x => x.Id == SelectedId);
                ctrlMovie.Genero = newGenTitle;
                ctrlMovie.Titulo = newNameTitle;
                ctrlMovie.Ano = newYearTitle;
                ctrlMovie.Types = newTypeTitle;


                
            }
            else
            {
                Functions.WriteError("DEu ruim!");
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