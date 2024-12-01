using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();

        public static List<Makeup> GetAllMakeups()
        {
            return db.Makeups.ToList();
        }

        public static int GetLastMakeupID()
        {
            return(from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();
        }

        public static void InsertMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID) 
        {
            Makeup makeup = MakeupFactory.Create(MakeupID, MakeupName, MakeupPrice, MakeupWeight,
                MakeupTypeID, MakeupBrandID);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }
        
        public static void RemoveMakeupByID(int MakeupID)
        {
            Makeup makeup = db.Makeups.Find(MakeupID);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }

        public static Makeup FindMakeupByID(int MakeupID)
        {
            Makeup makeup = db.Makeups.Find(MakeupID);
            return makeup;
        }


        public static void UpdateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight
            , int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updateMakeup = FindMakeupByID(MakeupID);
            updateMakeup.MakeupName = MakeupName;
            updateMakeup.MakeupPrice = MakeupPrice;
            updateMakeup.MakeupWeight = MakeupWeight;
            updateMakeup.MakeupTypeID = MakeupTypeID;
            updateMakeup.MakeupBrandID = MakeupBrandID;
            db.SaveChanges();
        }

        public static int GetMakeupID(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID,
            int MakeupBrandID) 
        { 
            return (from x in db.Makeups where x.MakeupName == MakeupName && x.MakeupPrice == MakeupPrice && x.MakeupWeight == MakeupWeight && x.MakeupTypeID == MakeupTypeID && x.MakeupBrandID == MakeupBrandID select x.MakeupID).FirstOrDefault();
        }

        public static Makeup GetMakeupByID(int MakeupID)
        {
            return (from x in db.Makeups where x.MakeupID == MakeupID select x).FirstOrDefault();
        }
    }
}