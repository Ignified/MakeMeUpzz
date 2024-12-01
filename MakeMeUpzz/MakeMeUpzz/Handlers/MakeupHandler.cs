using MakeMeUpzz.Factories;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handlers
{
    public class MakeupHandler
    {      
        // Makeup 
        public static List<Makeup> GetAllMakeups()
        {
            return MakeupRepository.GetAllMakeups();
        }

        public static int GetLastMakeupID()
        {
            return MakeupRepository.GetLastMakeupID();
        }

        public static void InsertMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.InsertMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }

        public static Makeup FindMakeupByID(int MakeupID)
        {
            return MakeupRepository.FindMakeupByID(MakeupID);
        }

        public static void RemoveMakeupByID(int MakeupID)
        {
            MakeupRepository.RemoveMakeupByID(MakeupID);
        }

        public static void UpdateMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, 
            int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository.UpdateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, 
                MakeupBrandID);
        }
        public static int GetMakeupID(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID,
            int MakeupBrandID)
        {
            return MakeupRepository.GetMakeupID(MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID,
                MakeupBrandID);
        }

        public static Makeup GetMakeupByID(int MakeupID)
        {
            return MakeupRepository.GetMakeupByID(MakeupID);
        }

        // MakeupType 
        public static List<MakeupType> GetAllMakeupTypes()
        {
            return MakeupTypeRepository.GetAllMakeupTypes();
        }

        public static List<int> GetAllMakeupTypeIDs()
        {
            return MakeupTypeRepository.GetAllMakeupTypeIDs();
        }

        public static int GetLastMakeupTypeID()
        {
            return MakeupTypeRepository.GetLastMakeupTypeID();
        }

        public static void InsertMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository.InsertMakeupType(MakeupTypeID, MakeupTypeName);
        }

        public static MakeupType FindMakeupTypeByID(int MakeupTypeID)
        {
            return MakeupTypeRepository.FindMakeupTypeByID(MakeupTypeID);
        }

        public static void RemoveMakeupTypeByID(int MakeupTypeID)
        {
            MakeupTypeRepository.RemoveMakeupTypeByID(MakeupTypeID);
        }

        public static void updateMakeupType(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository.UpdateMakeupType(MakeupTypeID, MakeupTypeName);
        }
        public static int getMakeupTypeIDbyName(String MakeupTypeName)
        {
            return MakeupTypeRepository.GetMakeupTypeIDbyName(MakeupTypeName);
        }

        // MakeupBrand 
        public static List<MakeupBrand> GetAllMakeupBrands()
        {
            return MakeupBrandRepository.GetAllMakeupBrands();
        }

        public static List<int> GetAllMakeupBrandIDs()
        {
            return MakeupBrandRepository.GetAllMakeupBrandIDs();
        }

        public static int GetLastMakeupBrandID()
        {
            return MakeupBrandRepository.GetLastMakeupBrandID();
        }

        public static void InsertMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.InsertMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }

        public static MakeupBrand FindMakeupBrandByID(int MakeupBrandID)
        {
            return MakeupBrandRepository.FindMakeupBrandByID(MakeupBrandID);
        }

        public static void RemoveMakeupBrandByID(int MakeupBrandID)
        {
            MakeupBrandRepository.RemoveMakeupBrandByID(MakeupBrandID);
        }

        public static void UpdateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository.UpdateMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }
        public static int GetMakeupBrandIDbyName(String MakeupBrandName)
        {
            return MakeupBrandRepository.GetMakeupBrandIDbyName(MakeupBrandName);
        }
    }
}