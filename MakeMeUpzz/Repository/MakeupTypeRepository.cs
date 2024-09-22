using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class MakeupTypeRepository
    {
        MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //Create
        public void CreateNewMakeupType(int MakeupTypeID, String MakeupName, bool isRemoved)
        {
            MakeupType newMakeupType = MakeupFactory.CreateMakeupType(MakeupTypeID, MakeupName, isRemoved);
            db.MakeupTypes.Add(newMakeupType);
            db.SaveChanges();
        }

        //Update
        public void UpdateMakeupTypeById(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType updateMakeupType = GetMakeupTypeById(MakeupTypeID);
            updateMakeupType.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }

        public MakeupType GetMakeupTypeById(int MakeupTypeID)
        {
            return db.MakeupTypes.Find(MakeupTypeID);
        }

        //Delete
        public void RemoveMakeupTypeById(int id)
        {
            MakeupType makeupType = db.MakeupTypes.Find(id);
            makeupType.IsRemoved = true;
            db.SaveChanges();
        }

        public List<MakeupType> GetAllMakeupType()
        {
            return (from mt
                    in db.MakeupTypes
                    where mt.IsRemoved == false
                    select mt).ToList();
        }

        public int GetLastMakeupTypeId()
        {
            return (from mt
                    in db.MakeupTypes
                    select mt.MakeupTypeID).ToList().LastOrDefault();
        }

        public bool IsTypeAvailable(int MakeupTypeID)
        {
            return db.MakeupTypes.Any(mb => mb.MakeupTypeID == MakeupTypeID);
        }
    }
}