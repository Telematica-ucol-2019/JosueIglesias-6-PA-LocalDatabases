using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite
{
    public partial class App : Application
    {

        #region Repository
       










        private static LibroRepository _LibroDb;
        public static LibroRepository LibroDb
        {
            get
            {
                if (_LibroDb == null)
                {
                    _LibroDb = new LibroRepository();
                }
                return _LibroDb;

            }
        }

        private static FechaPublicacionRepository _FechaPublicacionDb;
        public static FechaPublicacionRepository FechaPublicacionDb
        {
            get
            {
                if (_FechaPublicacionDb == null)
                {
                    _FechaPublicacionDb = new FechaPublicacionRepository();
                }
                return _FechaPublicacionDb;

            }
        }






        #endregion
        public App()
        {


            InitializeComponent();

            FechaPublicacionDb.Init();
            LibroDb.Init();
            MainPage = new NavigationPage(new inicioLibros());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
