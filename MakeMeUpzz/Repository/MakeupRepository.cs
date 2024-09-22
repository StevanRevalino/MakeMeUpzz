using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class MakeupRepository
    {
        MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //Create
        public void AddNewMakeup(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID, bool isRemoved)
        {
            Makeup newMakeup = MakeupFactory.CreateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID, isRemoved);
            db.Makeups.Add(newMakeup);
            db.SaveChanges();
        }

        //Update
        public void UpdateMakeupById(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updateMakeup = GetMakeupById(MakeupID);

            updateMakeup.MakeupName = MakeupName;
            updateMakeup.MakeupPrice = MakeupPrice;
            updateMakeup.MakeupWeight = MakeupWeight;
            updateMakeup.MakeupTypeID = MakeupTypeID;
            updateMakeup.MakeupBrandID = MakeupBrandID;

            db.SaveChanges();
        }

        public Makeup GetMakeupById(int MakeupId)
        {
            return db.Makeups.Find(MakeupId);
        }

        //Delete
        public void DeleteMakeupByID(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            makeup.IsRemoved = true;
            db.SaveChanges();
        }

        public List<Makeup> GetAllMakeup()
        {
            return (from m
                    in db.Makeups
                    where m.IsRemoved == false
                    select m).ToList();
        }

        public int GetLastMakeupID()
        {
            return (from m
                    in db.Makeups
                    select m.MakeupID).ToList().LastOrDefault();
        }
    }
}