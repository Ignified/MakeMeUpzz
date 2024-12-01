using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupTypeRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();

        public static List<MakeupType> GetAllMakeupTypes()
        {
            return db.MakeupTypes.ToList();
        }

        public static int GetLastMakeupTypeID()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList().LastOrDefault();
        }

        public static List<int> GetAllMakeupTypeIDs()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList();
        }

        public static void InsertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = MakeupTypeFactory.Create(MakeupTypeID, MakeupTypeName);
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }

        public static MakeupType FindMakeupTypeByID(int MakeupTypeID)
        {
            MakeupType makeupType = db.MakeupTypes.Find(MakeupTypeID);
            return makeupType;
        }

        public static void  RemoveMakeupTypeByID(int MakeupTypeID)
        {
            MakeupType makeupType = db.MakeupTypes.Find(MakeupTypeID);
            db.MakeupTypes.Remove(makeupType);
            db.SaveChanges();
        }

        public static void UpdateMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = FindMakeupTypeByID(MakeupTypeID);
            makeupType.MakeupTypeID = MakeupTypeID;
            makeupType.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }

        public static int GetMakeupTypeIDbyName(String MakeupTypeName)
        {
            return (from x in db.MakeupTypes where x.MakeupTypeName == MakeupTypeName select x.MakeupTypeID).FirstOrDefault();
        }
    }
}