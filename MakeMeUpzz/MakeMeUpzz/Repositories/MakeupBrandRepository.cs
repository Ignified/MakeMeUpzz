using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repositories
{
    public class MakeupBrandRepository
    {
        private static MakeMeUpzzDatabaseEntities1 db = DatabaseSingleton.getInstance();
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return db.MakeupBrands.ToList();
        }

        public static List<int> GetAllMakeupBrandIDs()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList();
        }

        public static int GetLastMakeupBrandID()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList().LastOrDefault();
        }

        public static void InsertMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand makeupBrand = MakeupBrandFactory.Create(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
        }

        public static MakeupBrand FindMakeupBrandByID(int MakeupBrandID)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(MakeupBrandID);
            return makeupBrand;
        }

        public static void RemoveMakeupBrandByID(int MakeupBrandID)
        {
            MakeupBrand makeupBrand = FindMakeupBrandByID(MakeupBrandID);
            db.MakeupBrands.Remove(makeupBrand);
            db.SaveChanges();
        }

        public static void UpdateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand makeupBrand = FindMakeupBrandByID(MakeupBrandID);
            makeupBrand.MakeupBrandID = MakeupBrandID;
            makeupBrand.MakeupBrandName = MakeupBrandName;
            makeupBrand.MakeupBrandRating = MakeupBrandRating;
            db.SaveChanges();
        }

        public static int GetMakeupBrandIDbyName(String MakeupBrandName)
        {
            return (from x in db.MakeupBrands where x.MakeupBrandName == MakeupBrandName select x.MakeupBrandID).FirstOrDefault();
        }
    }
}