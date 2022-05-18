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
    public partial class inicioLibros : ContentPage
    {
        InicioLibroViewModel vm = new InicioLibroViewModel();
        public inicioLibros()
        {
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetAll();
        }
    }
}