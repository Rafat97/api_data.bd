using api_data_bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_data_bd.Utiles.Static
{
    public class AppDatabase
    {
        private static AppDatabase appDatabase;
        public static AppDatabase getInstence()
        {
            if (appDatabase == null)
                appDatabase = new AppDatabase();
            return appDatabase;
        }
        public ApplicationDbContext getDatabase()
        {
            var db = new ApplicationDbContext();
            return db;
        }
    }
}