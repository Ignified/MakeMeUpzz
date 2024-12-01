using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType Create(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType makeupType = new MakeupType();
            makeupType.MakeupTypeID = MakeupTypeID;
            makeupType.MakeupTypeName = MakeupTypeName;
            return makeupType;
        }
    }
}