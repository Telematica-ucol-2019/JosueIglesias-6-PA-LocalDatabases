﻿
using DemoSQLite.Model;
using DemoSQLite.ViewMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MattoLibros : ContentPage
    {
        public MattoLibros(Libro libro)
        {
            InitializeComponent();
            BindingContext = new MattoLibrosViewModel(libro);
        }
    }
}