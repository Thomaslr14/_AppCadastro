using System;
using System.Linq;
using System.Collections.Generic;
using _AppCadastroSeries.Classes.OtherFunctions;
using _AppCadastroSeries.Interfaces;
using _AppCadastroSeries.Enums;


namespace _AppCadastroSeries.Classes.Repositories
{
    public class RepositorySeries : RepositoryBase, IPattern
    {
        public static List<Serie> KeepSeries = new List<Serie>();
        
        public void AddToList(string[] param)
        {
            int _Id = 0;
            ReturnId(ref _Id);
            AddBase(param, _Id);
            try
            {
                KeepSeries.Add((Serie)AddBase(param, _Id));
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
            
            if (KeepSeries.Exists(x => x.Id == IdTitle))
            {
                
                Console.WriteLine($"O Titulo '#{IdTitle} - {KeepSeries[IdTitle].Titulo}' foi excluido!\n");
                KeepSeries[IdTitle].Excluded = true;
            }
            else
            {
                Functions.WriteError("O Id informado não existe!\n");
            }
            
        }
        
        public void UpdateFromList(int SelectedId)
        {
            Types newTypeTitle = KeepSeries.Find(x => x.Id == SelectedId).Types;
            Enum newGenTitle = KeepSeries.Find(x => x.Id == SelectedId).Genero;
            var newNameTitle = KeepSeries.Find(x => x.Id == SelectedId).Titulo;
            var newYearTitle = KeepSeries.Find(x => x.Id == SelectedId).Ano;

            UpdateBase(ref newTypeTitle, ref newGenTitle,
                        ref newNameTitle, ref newYearTitle);    

            try 
            {
                if (PassInformation)
                {
                    var UpdateCtrl = KeepSeries.FirstOrDefault(x => x.Id == SelectedId);
                    UpdateCtrl.Types = newTypeTitle;
                    UpdateCtrl.Genero = newGenTitle;
                    UpdateCtrl.Titulo = newNameTitle;
                    UpdateCtrl.Ano = newYearTitle;
                    System.Threading.Thread.Sleep(10);
                    Console.WriteLine("\nTitulo atualizado com sucesso!");
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
            if (KeepSeries.Count == 0)
                return;
            else
                id = KeepSeries.Count;

        }
    }
}