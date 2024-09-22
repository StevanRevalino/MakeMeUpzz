using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class DatabaseSingleton
    {
        private static MakeMeUpzzDBEntities2 db = null;
        public static MakeMeUpzzDBEntities2 GetInstance()
        {
            if (db == null)
            {
                db = new MakeMeUpzzDBEntities2();
            }
            return db;
        }
    }
}