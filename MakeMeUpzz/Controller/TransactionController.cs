using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TransactionHandler = MakeMeUpzz.Handler.TransactionHandler;

namespace MakeMeUpzz.Controller
{
    public class TransactionController
    {
        public static void CreateTransactionHeader(int UserID)
        {
            TransactionHandler.CreateTransactionHeader(UserID);
        }

        public static int GenerateTransactionHeaderId()
        {
            return TransactionHandler.GenerateTransactionHeaderId();
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            return TransactionHandler.GetAllTransactionHeader();
        }

        public static List<TransactionHeader> GetUserTransactionHeader(int UserID)
        {
            return TransactionHandler.GetUserTransactionHeader(UserID);
        }

        public static TransactionHeader GetTransactionHeaderById(int TransactionID)
        {
            return TransactionHandler.GetTransactionHeaderById(TransactionID);
        }


        //Detail
        public static void CreateTransactionDetail(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionHandler.CreateransactionDetail(TransactionID, MakeupID, Quantity);
        }

        public static List<TransactionDetail> GetTransactionDetailById(int TransactionID)
        {
            return TransactionHandler.GetTransactionDetailById(TransactionID);
        }

        public static void HandleTransaction(int TransactionID)
        {
            TransactionHandler.HandleTransaction(TransactionID);
        }
    }
}