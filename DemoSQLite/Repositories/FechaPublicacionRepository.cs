using DemoSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class FechaPublicacionRepository
    {

        SQLiteConnection connection;

        public FechaPublicacionRepository()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<FechaPublicacion>();
        }


        public void Init()
        {
            connection.CreateTable<FechaPublicacion>();
        }
        public void InsertOrUpdate(FechaPublicacion fecha)
        {
            if (fecha.Id == 0)
            {

                connection.Insert(fecha);

            }
            else
            {

                connection.Update(fecha);

            }
        }

        public FechaPublicacion GetById(int Id)
        {
            return connection.Table<FechaPublicacion>().FirstOrDefault(item => item.Id == Id);
            //return connection.GetAllWithChildren<Contacto>(item => item.Id == Id).FirstOrDefault();



        }

        public List<FechaPublicacion> GetAll()
        {

            return connection.Table<FechaPublicacion>().ToList();
        }


        public void DeleteItem(int Id)
        {
            FechaPublicacion fecha = GetById(Id);
            connection.Delete(fecha);
        }

    }
}
