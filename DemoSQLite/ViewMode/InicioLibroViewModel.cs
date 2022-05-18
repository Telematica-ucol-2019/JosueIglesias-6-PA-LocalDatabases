using Bogus;
using DemoSQLite.Model;
using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class InicioLibroViewModel : BaseViewModel
    {

        public ObservableCollection<Libro> Libros { get; set; }

        public ICommand cmdAgregaLibro { get; set; }
        public ICommand cmdModifcaLibro { get; set; }

        public InicioLibroViewModel()
        {
            Libros = new ObservableCollection<Libro>();
            cmdAgregaLibro = new Command(() => cmdAgregaLibroMetodo());
            cmdModifcaLibro = new Command<Libro>((item) => cmdModifcaLibroMetodo(item));

        }

        private void cmdModifcaLibroMetodo(Libro libro)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoLibros(libro));
        }

        private void cmdAgregaLibroMetodo()
        {

            Libro libro = new Faker<Libro>()
                //.RuleFor(c => c.Avatar, f => f.Person.Avatar)
                .RuleFor(c => c.Titulo, f => f.Name.FirstName())
                .RuleFor(c => c.Editorial, f => f.Name.LastName())
                .RuleFor(c => c.Descripcion, f => f.Name.LastName())
                .RuleFor(c => c.Autor, (f, c) => f.Name.FirstName());

            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;

            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 31);

            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);

            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");

            libro.FechaPublicacion = new FechaPublicacion() { Fecha = generateDate };




            App.Current.MainPage.Navigation.PushAsync(new MattoLibros(libro));

        }

        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                App.LibroDb.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Libro>(App.LibroDb.GetAll());

            }
            OnPropertyChanged();
        }


    }
}
