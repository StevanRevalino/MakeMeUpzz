using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class MakeupBrandRepository
    {
        MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //create
        public void CreateNewMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating, bool isRemoved)
        {
            MakeupBrand newMakeupBrand = MakeupFactory.CreateMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating, isRemoved);
            db.MakeupBrands.Add(newMakeupBrand);
            db.SaveChanges();
        }

        //update
        public void UpdateMakeupBrandById(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand updateMakeupBrand = GetMakeupBrandById(MakeupBrandID);
            updateMakeupBrand.MakeupBrandName = MakeupBrandName;
            updateMakeupBrand.MakeupBrandRating = MakeupBrandRating;
            db.SaveChanges();
        }

        public MakeupBrand GetMakeupBrandById(int MakeupBrandID)
        {
            return db.MakeupBrands.Find(MakeupBrandID);
        }

        //delete
        public void DeleteMakeupBrandByID(int id)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            makeupBrand.IsRemoved = true;
            db.SaveChanges();
        }

        public bool IsBrandAvailable(int MakeupBrandID)
        {
            return db.MakeupBrands.Any(mb => mb.MakeupBrandID == MakeupBrandID);
        }
        public List<MakeupBrand> GetAllMakeupBrand()
        {
            return (from mb
                    in db.MakeupBrands
                    where mb.IsRemoved == false
                    select mb).ToList();
        }


        public int GetLastMakeupBrandID()
        {
            return (from mb
                    in db.MakeupBrands
                    select mb.MakeupBrandID).ToList().LastOrDefault();
        }
    }
}