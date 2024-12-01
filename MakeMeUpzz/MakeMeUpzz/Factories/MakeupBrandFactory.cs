using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand Create(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand makeupBrand = new MakeupBrand();
            makeupBrand.MakeupBrandID = MakeupBrandID;
            makeupBrand.MakeupBrandName = MakeupBrandName;
            makeupBrand.MakeupBrandRating = MakeupBrandRating;
            return makeupBrand;
        }
    }
}