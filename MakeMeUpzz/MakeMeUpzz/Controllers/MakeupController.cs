using MakeMeUpzz.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controllers
{
    public class MakeupController
    {
        public Boolean ValidTypeID(int typeID)
        {
            List<int> IDs = MakeupHandler.GetAllMakeupTypeIDs();
            for (int i = 0; i < IDs.Count; i++)
            {
                if (typeID.Equals(IDs[i])) { return true; }
            }
            return false;
        }

        public Boolean ValidBrandID(int BrandID)
        {
            List<int> IDs = MakeupHandler.GetAllMakeupBrandIDs();
            for (int i = 0; i < IDs.Count; i++)
            {
                if (BrandID.Equals(IDs[i])) { return true; }
            }
            return false;
        }

        public String MakeupValidation(String MakeupName, int MakeupPrice, int MakeupWeight,
            int MakeupTypeID, int MakeupBrandID)
        {
            String space = "";

            if (MakeupName.Length < 1 || MakeupName.Length > 99)
            {
                space = "MakeupName must be between 1 and 99 characters";
                return space;
            }
            else if (MakeupName == null || MakeupName.Length == 0)
            {
                space = "Makeup Name must be written";
                return space;
            }
           
            if (MakeupPrice < 1)
            {
                space = "Makeup Price must be < or = to 1";
                return space;
            }          

            if (MakeupWeight < 1 || MakeupWeight > 1500)
            {
                space = "MakeupWeight cannot be more than 1500 or less than 1";
                return space;
            }            

            int? MakeupTypeIDNullable = MakeupTypeID;
            if (!ValidTypeID(MakeupTypeID) || MakeupTypeIDNullable == null)
            {
                space = "MakeupType ID can't be empty or invalid";
                return space;
            }

            int? MakeupBrandIDNullable = MakeupBrandID;
            if (!ValidBrandID(MakeupBrandID) || MakeupBrandIDNullable == null)
            {
                space = "MakeupBrand ID cannot be empty or invalid";
                return space;
            }
            space = "Actions have been done";
            return space;
        }

        public String MakeupTypeValidation(String MakeupTypeName)
        {
            String space = "";

            if (MakeupTypeName.Length < 1 || MakeupTypeName.Length > 99)
            {
                space = "MakeupType Name must be between 1 and 99 characters";
                return space;
            }

            space = "Actions have been done";
            return space;
        }

        public String MakeupBrandValidation(String MakeupBrandName, int MakeupBrandRating)
        {
            String space = "";

            if (MakeupBrandName.Length < 1 || MakeupBrandName.Length > 99)
            {
                space = "MakeupBrand Name must be between 1 and 99 characters";
                return space;
            }

            if (MakeupBrandRating < 0 || MakeupBrandRating > 100)
            {
                space = "Makeup Brand Rating must be between 0 and 100";
                return space;
            }

            space = "Operation Successful!";
            return space;
        }
    }
}