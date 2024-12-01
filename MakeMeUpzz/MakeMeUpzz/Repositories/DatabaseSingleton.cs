using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class DatabaseSingleton
    {
        private static MakeMeUpzzDatabaseEntities1 db = null;

        public static MakeMeUpzzDatabaseEntities1 getInstance()
        {
            if (db == null)
            {
                db = new MakeMeUpzzDatabaseEntities1();
            }
            return db;
        }
    }
}