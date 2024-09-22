using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class TransactionDetailRepository
    {
        private static MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //Create
        public void CreateTransactionDetail(int TransasctionID, int MakeupID, int Quantity)
        {
            TransactionDetail newTransactionDetail = TransactionFactory.CreateDetail(TransasctionID, MakeupID, Quantity);
            db.TransactionDetails.Add(newTransactionDetail);
            db.SaveChanges();
        }

        public List<TransactionDetail> GetTransactionDetailById(int TransactionID)
        {
            return (from td
                    in db.TransactionDetails
                    where td.TransactionID == TransactionID
                    select td).ToList();
        }
    }
}