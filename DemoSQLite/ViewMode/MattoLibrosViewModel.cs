using DemoSQLite.Model;
using DemoSQLite.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class MattoLibrosViewModel
    {

        public Libro Libro { get; set; }


        public ICommand cmdGrabaLibro { get; set; }
        public MattoLibrosViewModel(Libro libro)
        {

            Libro = libro;

            cmdGrabaLibro = new Command<Libro>((item) => cmdGrabaLibroMetodo(item));


        }

        private void cmdGrabaLibroMetodo(Libro libro)
        {
            App.LibroDb.InsertOrUpdate(libro);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
