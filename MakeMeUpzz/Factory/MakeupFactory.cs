using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MakeMeUpzz.Factory
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup(int MakeupId, string MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID, bool isRemoved)
        {
            Makeup makeup = new Makeup();

            makeup.MakeupID = MakeupId;
            makeup.MakeupName = MakeupName;
            makeup.MakeupPrice = MakeupPrice;
            makeup.MakeupWeight = MakeupWeight;
            makeup.MakeupTypeID = MakeupTypeID;
            makeup.MakeupBrandID = MakeupBrandID;
            makeup.IsRemoved = isRemoved;

            return makeup;
        }

        public static MakeupType CreateMakeupType(int MakeupTypeID, String MakeupTypeName, bool isRemoved)
        {
            MakeupType makeupType = new MakeupType();

            makeupType.MakeupTypeID = MakeupTypeID;
            makeupType.MakeupTypeName = MakeupTypeName;
            makeupType.IsRemoved = isRemoved;

            return makeupType;
        }

        public static MakeupBrand CreateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating, bool isRemoved)
        {
            MakeupBrand makeupBrand = new MakeupBrand();

            makeupBrand.MakeupBrandID = MakeupBrandID;
            makeupBrand.MakeupBrandName = MakeupBrandName;
            makeupBrand.MakeupBrandRating = MakeupBrandRating;
            makeupBrand.IsRemoved = isRemoved;

            return makeupBrand;
        }
    }
}