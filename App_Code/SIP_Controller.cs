using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using ShoppingCart.DAL;
using System.Data.SqlClient;
using ShoppingCart.BL;
using System.Configuration;
using LMSIntegration;
/// <summary>
/// Summary description for SIP_Controller
/// </summary>
namespace ShoppingCart.BL
{
    public class SIP_Controller
    {
        public static DataSet GetAllActiveUser_AcadYear()
        {
            return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "USP_GetallCurrentYear"));
        }

        public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        {
            SqlParameter p1 = new SqlParameter("@user_id", User_ID);
            SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
            SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);

            if (DBName == "MTEducare")
            {
                return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_MTEducare", p1, p2, p3, p4, p5));
            }
            else
            {
                return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));
            }
        }


        public static DataSet GetBatchByDivisionCenterAcadYr(string divisioncode, string centercode, string acadyr)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p2 = new SqlParameter("@centercode", centercode);
            SqlParameter p3 = new SqlParameter("@acadyr", acadyr);
            return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "USP_SIP_BatchDetails", p1, p2, p3));
        }

        public static DataSet bindStudent(int flag, string acadYr, string divisioncode, string centercode, string @batchcode)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@acadYr", acadYr);
            SqlParameter p3 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p4 = new SqlParameter("@centercode", centercode);
            SqlParameter p5 = new SqlParameter("@batchcode", batchcode);

            return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "USP_SIP_StudentNotification", p1, p2, p3, p4, p5));
        }


        public static DataSet InsertNotification(int flag, string notification, string sendinglevel, string companycode, string divisioncode, string centercode, string batchcode, string spid, string userId, string acadYr, string notificationType,string UrlHedaer)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@notification", notification);
            SqlParameter p3 = new SqlParameter("@sendinglevel", sendinglevel);
            SqlParameter p4 = new SqlParameter("@companycode", companycode);
            SqlParameter p5 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p6 = new SqlParameter("@centercode", centercode);
            SqlParameter p7 = new SqlParameter("@batchcode", batchcode);
            SqlParameter p8 = new SqlParameter("@spid", spid);
            SqlParameter p9 = new SqlParameter("@userId", userId);
            SqlParameter p10 = new SqlParameter("@acadYr", acadYr);
            SqlParameter p11 = new SqlParameter("@notificationType", notificationType);
            SqlParameter p12 = new SqlParameter("@urlheader", UrlHedaer);

            return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "USP_INSERT_NOTIFICATION_ME", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
        }

        public static DataSet GetNotificationDetails(int Flag, string Notification_Type, string From_Date, string To_Date)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Notification_Type", Notification_Type);
            SqlParameter p3 = new SqlParameter("@From_Date", From_Date);
            SqlParameter p4 = new SqlParameter("@To_Date", To_Date);


            return (SqlHelper.ExecuteDataset(DBConnection.connStringSIP, CommandType.StoredProcedure, "USP_SIP_GET_NOTIFICATIONS", p1, p2, p3, p4));
        }

    }
}