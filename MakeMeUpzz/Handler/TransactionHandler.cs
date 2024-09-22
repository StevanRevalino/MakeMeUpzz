using MakeMeUpzz.Models;
using MakeMeUpzz.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Handler
{
    public class TransactionHandler
    {

        //Create
        public static void CreateTransactionHeader(int UserID)
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();

            // default value
            DateTime Created = DateTime.UtcNow;
            TimeZoneInfo gmtPlus7Zone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime transactionDate = TimeZoneInfo.ConvertTimeFromUtc(Created, gmtPlus7Zone);

            String Status = "unHandled";

            transactionHeaderRepository.CreateTransactionHeader(GenerateTransactionHeaderId(), UserID, transactionDate, Status);
        }

        public static int GenerateTransactionHeaderId()
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();
            int lastId = transactionHeaderRepository.GetLastTransactionHeaderId();
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

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();
            return transactionHeaderRepository.GetAllTransactionHeader();
        }

        public static List<TransactionHeader> GetUserTransactionHeader(int UserID)
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();
            return transactionHeaderRepository.GetUserTransactionHeader(UserID);
        }

        public static TransactionHeader GetTransactionHeaderById(int TransactionID)
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();
            return transactionHeaderRepository.GetTransactionHeaderById(TransactionID);
        }


        //Detail
        public static void CreateransactionDetail(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetailRepository transactionDetailRepository = new TransactionDetailRepository();
            transactionDetailRepository.CreateTransactionDetail(TransactionID, MakeupID, Quantity);
        }

        public static List<TransactionDetail> GetTransactionDetailById(int TransactionID)
        {
            TransactionDetailRepository transactionDetailRepository = new TransactionDetailRepository();
            return transactionDetailRepository.GetTransactionDetailById(TransactionID);
        }

        public static void HandleTransaction(int TransactionID)
        {
            TransactionHeaderRepository transactionHeaderRepository = new TransactionHeaderRepository();
            transactionHeaderRepository.HandleTransaction(TransactionID);
        }
    }
}