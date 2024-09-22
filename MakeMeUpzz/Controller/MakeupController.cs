using MakeMeUpzz.Handler;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Controller
{
    public class MakeupController
    {
        //Check Name
        public static String CheckName(String name)
        {
            String response = "";
            if (name.Length < 1 || name.Length > 99)
            {
                response = "Name length must be between 1 - 99 characters";
            }
            return response;
        }

        //Check Price
        public static String CheckPrice(int price)
        {
            String response = "";
            if (price <= 0)
            {
                response = "Price must be greater than or equals to 1";
            }
            return response;
        }

        //Check Weight
        public static String CheckWeight(int weight)
        {
            String response = "";

            if (weight < 1)
            {
                response = "Please enter a valid weight";
            }

            if (weight > 1500)
            {
                response = "Weight cannot be greater than 1500";
            }

            return response;
        }

        //Check TypeID
        public static String CheckTypeID(int typeID)
        {
            String response = "";
            if (typeID == 0)
            {
                response = "Please enter a valid MakeupTypeID ";
            }
            else response = MakeupHandler.IsTypeAvaiable(typeID) ? "" : "MakeupType Doesn't exist";
            return response;
        }

        //Check BrandID
        public static String CheckBrandID(int brandID)
        {
            String response = "";
            if (brandID == 0)
            {
                response = "Please enter a valid MakeupBrandID"; 
            }
            else response = MakeupHandler.IsBrandAvailable(brandID) ? "" : "MakeupBrand Doesn't exist";
            return response;
        }

        //Check Rating
        public static String CheckRating(int rating)
        {
            String response = "";
            if (rating <= 1 || rating >=99)
            {
                response = "Rating must be between 0 - 100";
            }
            return response;
        }

        public static bool CheckMakeupInput(String name, int price, int weight, int typeId, int brandId)
        {
            if (CheckName(name).Equals("") && CheckPrice(price).Equals("") 
                && CheckWeight(weight).Equals("") && CheckTypeID(typeId).Equals("") 
                && CheckBrandID(brandId).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static bool CheckMakeupTypeInput(String name)
        {
            if (CheckName(name).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static bool CheckMakeupBrandInput(String name, int rating)
        {
            if (CheckName(name).Equals("") && CheckRating(rating).Equals(""))
            {
                return true;
            }
            return false;
        }

        //Create Makeup, type and Brand
        public static void CreateMakeup(String name, int price, int weight, int typeId, int brandId)
        {
            MakeupHandler.CreateNewMakeup(name, price, weight, typeId, brandId);
        }

        public static void CreateNewMakeupType(String MakeupName)
        {
            MakeupHandler.CreateNewMakeupType(MakeupName);
        }

        public static void CreateNewMakeupBrand(String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.CreatewMakeupBrand(MakeupBrandName, MakeupBrandRating);
        }

        //get Makeup
        public static List<Makeup> GetAllMakeup()
        {
            return MakeupHandler.GetAllMakeup();
        }
        public static Makeup GetMakeupById(int MakeupId)
        {
            return MakeupHandler.GetMakeupById(MakeupId);
        }

        //get Type
        public static List<MakeupType> GetAllMakeupType()
        {
            return MakeupHandler.GetAllMakeupType();
        }
        public static MakeupType GetMakeupTypeById(int MakeupTypeID)
        {
            return MakeupHandler.GetMakeupTypeById(MakeupTypeID);
        }

        //get Brand
        public static List<MakeupBrand> GetAllMakeupBrand()
        {
            return MakeupHandler.GetAllMakeupBrand();
        }
        public static MakeupBrand GetMakeupBrandById(int MakeupBrandID)
        {
            return MakeupHandler.GetMakeupBrandById(MakeupBrandID);
        }

        //Update Makeup, Type and Brand
        public static void UpdateMakeupById(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupHandler.UpdateMakeupById(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
        }
        public static void UpdateMakeupTypeById(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupHandler.UpdateMakeupTypeById(MakeupTypeID, MakeupTypeName);
        }
        public static void UpdateMakeupBrandById(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.UpdateMakeupBrandById(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }

        //Delete Makeup, type and Brand
        public static void RemoveMakeupByID(int id)
        {
            MakeupHandler.DeleteMakeupByID(id);
        }
        public static void RemoveMakeupTypeById(int id)
        {
            MakeupHandler.DeleteMakeupTypeById(id);
        }
        public static void DeleteMakeupBrandById(int id)
        {
            MakeupHandler.DeleteMakeupBrandById(id);
        }
    }
}