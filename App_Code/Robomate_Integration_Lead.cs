using System.Linq;
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

/// <summary>
/// Summary description for Robomate_Integration_Lead
/// </summary>
/// 
namespace ShoppingCart.BL
{
    public class Robomate_Integration_Lead
    {
        public static DataSet GetAllDeviceType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDeviceType"));
        }

        public static DataSet GetAllProvider()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProvider"));
        }

        public static DataSet GetAllOwnedby()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllOwner"));
        }

        public static DataSet GetAllPlatform()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllPlatform"));
        }

        public static DataSet GetAllDeviceBrand()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDeviceBrand"));
        }

        public static DataSet GetAllAccessMode()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllAccessMode"));
        }

        public static DataSet GetAllStorageMediaType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStorageMediaType"));
        }
        public static DataSet GetAllInstallationType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstallationStatus"));
        }

        public static string Insert_Robomate_Dtls(
        string Robomate_Detail_Id,string Company_Code, string Division_Code, string Center_Code, string Lead_Type ,
        string Conid ,string User_Device_Id ,string Provided_By_id ,string Owned_By_Id,
        string Platform_Id ,string Device_Brand_Id ,string Device_Brand_Addl_Text, string Device_Model,
        string Device_Config,string Access_Mode_Id,string Storage_Media_type_Id,
        string Capacity ,string HDD_Free_Space ,string No_of_Storage_Media ,string Special_Instruction_1 ,
        string Special_Instruction_2 ,string Special_Instruction_3,string Created_On ,
        string Created_By ,string Modified_On ,string Modified_By,
        string Installation_Location, string Appointment_Date, string Appointment_Time,
        string Installation_Date, string Installation_Time, string Installation_Status_Id,
        string Rescheduled_Date, string Rescheduled_Time, string Engineer_Name, string Contact_Number,
        string Email_Id, string Engineer_Company
        )
        {
            SqlParameter[] p = new SqlParameter[37];
            p[0] = new SqlParameter("@Robomate_Detail_Id", SqlDbType.NVarChar);
            p[0].Value = Robomate_Detail_Id;
            p[1] = new SqlParameter("@Company_Code", SqlDbType.NVarChar);
            p[1].Value = Company_Code ;
            p[2] = new SqlParameter("@Division_Code", SqlDbType.NVarChar);
            p[2].Value = Division_Code;
            p[3] = new SqlParameter("@Center_Code", SqlDbType.NVarChar);
            p[3].Value = Center_Code ;
            p[4] = new SqlParameter("@Lead_Type", SqlDbType.NVarChar);
            p[4].Value = Lead_Type ;
            p[5] = new SqlParameter("@Conid", SqlDbType.NVarChar);
            p[5].Value = Conid ;
            p[6] = new SqlParameter("@User_Device_Id", SqlDbType.NVarChar);
            p[6].Value = User_Device_Id ;
            p[7] = new SqlParameter("@Provided_By_id", SqlDbType.NVarChar);
            p[7].Value = Provided_By_id ;
            p[8] = new SqlParameter("@Owned_By_Id", SqlDbType.NVarChar);
            p[8].Value = Owned_By_Id ;
            p[9] = new SqlParameter("@Platform_Id", SqlDbType.NVarChar);
            p[9].Value = Platform_Id ;
            p[10] = new SqlParameter("@Device_Brand_Id", SqlDbType.NVarChar);
            p[10].Value = Device_Brand_Id ;
            p[11] = new SqlParameter("@Device_Brand_Addl_Text", SqlDbType.NVarChar);
            p[11].Value = Device_Brand_Addl_Text ;
            p[12] = new SqlParameter("@Device_Model", SqlDbType.NVarChar);
            p[12].Value = Device_Model ;
            p[13] = new SqlParameter("@Device_Config", SqlDbType.NVarChar);
            p[13].Value = Device_Config ;
            p[14] = new SqlParameter("@Access_Mode_Id", SqlDbType.NVarChar);
            p[14].Value = Access_Mode_Id ;
            p[15] = new SqlParameter("@Storage_Media_type_Id", SqlDbType.NVarChar);
            p[15].Value = Storage_Media_type_Id ;
            p[16] = new SqlParameter("@Capacity", SqlDbType.NVarChar);
            p[16].Value = Capacity ;
            p[17] = new SqlParameter("@HDD_Free_Space", SqlDbType.NVarChar);
            p[17].Value = HDD_Free_Space ;
            p[18] = new SqlParameter("@No_of_Storage_Media", SqlDbType.NVarChar);
            p[18].Value = No_of_Storage_Media ;
            p[19] = new SqlParameter("@Special_Instruction_1", SqlDbType.NVarChar);
            p[19].Value = Special_Instruction_1 ;
            p[20] = new SqlParameter("@Special_Instruction_2", SqlDbType.NVarChar);
            p[20].Value = Special_Instruction_2 ;
            p[21] = new SqlParameter("@Special_Instruction_3", SqlDbType.NVarChar);
            p[21].Value = Special_Instruction_3 ;
            p[22] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[22].Value = Created_By ;
            p[23] = new SqlParameter("@Modified_By", SqlDbType.NVarChar);
            p[23].Value = Modified_By ;
            p[24] = new SqlParameter("@Robomate_Detail_Id_Out", SqlDbType.NVarChar, 100);
            p[24].Direction = ParameterDirection.Output;
            p[25] = new SqlParameter("@Installation_Location", SqlDbType.NVarChar);
            p[25].Value = Installation_Location;
            p[26] = new SqlParameter("@Appointment_Date", SqlDbType.NVarChar);
            p[26].Value = Appointment_Date ;
            p[27] = new SqlParameter("@Appointment_Time", SqlDbType.NVarChar);
            p[27].Value = Appointment_Time ;
            p[28] = new SqlParameter("@Installation_Date", SqlDbType.NVarChar);
            p[28].Value = Installation_Date ;
            p[29] = new SqlParameter("@Installation_Time", SqlDbType.NVarChar);
            p[29].Value = Installation_Time ;

            p[30] = new SqlParameter("@Installation_Status_Id", SqlDbType.NVarChar);
            p[30].Value = Installation_Status_Id ;
            p[31] = new SqlParameter("@Rescheduled_Date", SqlDbType.NVarChar);
            p[31].Value = Rescheduled_Date ;
            p[32] = new SqlParameter("@Rescheduled_Time", SqlDbType.NVarChar);
            p[32].Value = Rescheduled_Time ;
            p[33] = new SqlParameter("@Engineer_Name", SqlDbType.NVarChar);
            p[33].Value = Engineer_Name ;
            p[34] = new SqlParameter("@Contact_Number", SqlDbType.NVarChar);
            p[34].Value = Contact_Number ;
            p[35] = new SqlParameter("@Email_Id", SqlDbType.NVarChar);
            p[35].Value = Email_Id ;
            p[36] = new SqlParameter("@Engineer_Company", SqlDbType.NVarChar);
            p[36].Value = Engineer_Company ;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Robomate_Details", p);
            return (p[24].Value.ToString());
        }

        public static SqlDataReader GetRobomatedetailsbyLeadid(string leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@leadCode", SqlDbType.NVarChar);
            p[0].Value = leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Robomatedetails", p));
        }

    }
}