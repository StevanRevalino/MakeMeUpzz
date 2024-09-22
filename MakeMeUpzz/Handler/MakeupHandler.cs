using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class MakeupHandler
    {
        //create
        public static void CreateNewMakeup(String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository makeupRepository = new MakeupRepository();
            makeupRepository.AddNewMakeup(GenerateMakeUpID(), MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID, false);
        }

        public static int GenerateMakeUpID()
        {
            MakeupRepository makeupRepository = new MakeupRepository();
            int lastId = makeupRepository.GetLastMakeupID();
            if (lastId == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId++;
            }

            return lastId;
        }

        //Update
        public static void UpdateMakeupById(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupRepository makeupRepository = new MakeupRepository();
            makeupRepository.UpdateMakeupById(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
        }

        //Delete
        public static void DeleteMakeupByID(int id)
        {
            MakeupRepository makeupRepo = new MakeupRepository();
            makeupRepo.DeleteMakeupByID(id);
        }

        public static List<Makeup> GetAllMakeup()
        {
            MakeupRepository makeupRepository = new MakeupRepository();
            return makeupRepository.GetAllMakeup();
        }

        public static Makeup GetMakeupById(int MakeupId)
        {
            MakeupRepository makeupRepository = new MakeupRepository();
            return makeupRepository.GetMakeupById(MakeupId);
        }









        //TYPE
        //Create
        public static void CreateNewMakeupType(String MakeupName)
        {
            MakeupTypeRepository makeupTypeRepository = new MakeupTypeRepository();
            makeupTypeRepository.CreateNewMakeupType(GenerateMakeUpTypeID(), MakeupName, false);
        }

        public static int GenerateMakeUpTypeID()
        {
            MakeupTypeRepository makeupTypeRepository = new MakeupTypeRepository();
            int lastId = makeupTypeRepository.GetLastMakeupTypeId();
            if (lastId == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId++;
            }
            return lastId;
        }

        //Update
        public static void UpdateMakeupTypeById(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupTypeRepository makeupTypeRepository = new MakeupTypeRepository();
            makeupTypeRepository.UpdateMakeupTypeById(MakeupTypeID, MakeupTypeName);
        }

        //Delete
        public static void DeleteMakeupTypeById(int id)
        {
            MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
            makeupTypeRepo.RemoveMakeupTypeById(id);
        }

        public static List<MakeupType> GetAllMakeupType()
        {
            MakeupTypeRepository makeupTypeRepo = new MakeupTypeRepository();
            return makeupTypeRepo.GetAllMakeupType();
        }

        public static MakeupType GetMakeupTypeById(int MakeupTypeID)
        {
            MakeupTypeRepository makeupTypeRepository = new MakeupTypeRepository();
            return makeupTypeRepository.GetMakeupTypeById(MakeupTypeID);
        }

        public static bool IsTypeAvaiable(int MakeupTypeID)
        {
            MakeupTypeRepository makeupTypeRepository = new MakeupTypeRepository();
            return makeupTypeRepository.IsTypeAvailable(MakeupTypeID);
        }

        








        //BRAND
        //Create
        public static void CreatewMakeupBrand(String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository makeupTypeRepository = new MakeupBrandRepository();
            makeupTypeRepository.CreateNewMakeupBrand(GenerateMakeupBrandId(), MakeupBrandName, MakeupBrandRating, false);
        }

        public static int GenerateMakeupBrandId()
        {
            MakeupBrandRepository makeupBrandRepository = new MakeupBrandRepository();
            int lastId = makeupBrandRepository.GetLastMakeupBrandID();
            if (lastId == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId++;
            }
            return lastId;
        }

        //Update
        public static void UpdateMakeupBrandById(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrandRepository makeupBrandRepository = new MakeupBrandRepository();
            makeupBrandRepository.UpdateMakeupBrandById(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }

        //Delete
        public static void DeleteMakeupBrandById(int id)
        {
            MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
            makeupBrandRepo.DeleteMakeupBrandByID(id);
        }

        public static List<MakeupBrand> GetAllMakeupBrand()
        {
            MakeupBrandRepository makeupBrandRepo = new MakeupBrandRepository();
            return makeupBrandRepo.GetAllMakeupBrand();
        }

        public static MakeupBrand GetMakeupBrandById(int MakeupBrandID)
        {
            MakeupBrandRepository makeupBrandRepository = new MakeupBrandRepository();
            return makeupBrandRepository.GetMakeupBrandById(MakeupBrandID);
        }

        public static bool IsBrandAvailable(int MakeupBrandID)
        {
            MakeupBrandRepository makeupBrandRepository = new MakeupBrandRepository();
            return makeupBrandRepository.IsBrandAvailable(MakeupBrandID);
        }
    }
}