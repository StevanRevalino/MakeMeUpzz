using MakeMeUpzz.Factory;
using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Repository
{
    public class TransactionHeaderRepository
    {
        private static MakeMeUpzzDBEntities2 db = DatabaseSingleton.GetInstance();

        //create
        public void CreateTransactionHeader(int TransactionID, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader newTransactionHeader = TransactionFactory.CreateHeader(TransactionID, UserID, TransactionDate, Status);
            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();
        }

        public void HandleTransaction(int TransactionID)
        {
            TransactionHeader updateTransaction = GetTransactionHeaderById(TransactionID);
            updateTransaction.Status = "Handled";
            db.SaveChanges();
        }

        public int GetLastTransactionHeaderId()
        {
            return (from th
                    in db.TransactionHeaders
                    select th.TransactionID).ToList().LastOrDefault();
        }

        public List<TransactionHeader> GetAllTransactionHeader()
        {
            return (from th
                    in db.TransactionHeaders
                    select th).ToList();
        }
        public TransactionHeader GetTransactionHeaderById(int TransactionID)
        {
            return (from th
                    in db.TransactionHeaders
                    where th.TransactionID == TransactionID
                    select th).FirstOrDefault();
        }

        public List<TransactionHeader> GetUserTransactionHeader(int UserID)
        {
            return (from th
                    in db.TransactionHeaders
                    where th.UserID == UserID
                    select th).ToList();
        }

        
    }
}