using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateHeader(int TransactionID, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();

            transactionHeader.TransactionID = TransactionID;
            transactionHeader.UserID = UserID;
            transactionHeader.TransactionDate = TransactionDate;
            transactionHeader.Status = Status;

            return transactionHeader;
        }

        public static TransactionDetail CreateDetail(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();

            transactionDetail.TransactionID = TransactionID;
            transactionDetail.MakeupID = MakeupID;
            transactionDetail.Quantity = Quantity;

            return transactionDetail;
        }


    }
}