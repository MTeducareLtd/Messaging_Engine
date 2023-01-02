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
/// Summary description for Reporting
/// </summary>
/// 
namespace ShoppingCart.BL
{
    public class Reporting
    {
       public static DataSet GetUser_Company_Division_Zone_Center(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Zone_code", SqlDbType.VarChar);
            p3.Value = Zonecode;
            SqlParameter p4 = new SqlParameter("@Company_Code", SqlDbType.VarChar);
            p4.Value = Companycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_GetUser_Company_Division_Zone_Center", p, p1, p2, p3, p4));
        }

       public static DataSet GetAllAcadyear()
       {
           return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAcadyear"));
       }

       public static DataSet GetStreamby_Center_AcademicYear_All(string CenterCode, string AcademicYear)
       {
           SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
           p.Value = CenterCode;
           SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
           p1.Value = AcademicYear;
           return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_All", p, p1));
       }
       public static DataSet GetAdmissionCount(string Reporttype, string Flag, string CompanyCode, string DivisionCode, 
           string ZoneCode, string centerCode, string Acadyear, string fdate, string tdate, string userid)
       {
           SqlParameter p = new SqlParameter("@Reporttype", SqlDbType.VarChar);
           p.Value = Reporttype ;
           SqlParameter p1 = new SqlParameter("@flag", SqlDbType.VarChar);
           p1.Value = Flag;
           SqlParameter p2 = new SqlParameter("@CompanyCode", SqlDbType.VarChar);
           p2.Value = CompanyCode ;
           SqlParameter p3 = new SqlParameter("@DivisionCode", SqlDbType.VarChar);
           p3.Value = DivisionCode ;
           SqlParameter p4 = new SqlParameter("@ZoneCode", SqlDbType.VarChar);
           p4.Value = ZoneCode ;
           SqlParameter p5 = new SqlParameter("@CentreCode", SqlDbType.VarChar);
           p5.Value = centerCode ;
           SqlParameter p6 = new SqlParameter("@Acadyear", SqlDbType.VarChar);
           p6.Value = Acadyear;
           SqlParameter p7 = new SqlParameter("@fdate", SqlDbType.VarChar);
           p7.Value = fdate;
           SqlParameter p8 = new SqlParameter("@tdate", SqlDbType.VarChar);
           p8.Value = tdate;
           SqlParameter p9 = new SqlParameter("@userid", SqlDbType.VarChar);
           p9.Value = userid;
           return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Rpt_AdmissionCount_Annual", p, p1, p2, p3, p4,p5,p6,p7,p8,p9));
        
       }

       public static DataSet GetBankDetails(string flag, string city, string bank, string branch)
       {
           SqlParameter p = new SqlParameter("@flag", SqlDbType.VarChar);
           p.Value = flag;
           SqlParameter p1 = new SqlParameter("@city", SqlDbType.VarChar);
           p1.Value = city;
           SqlParameter p2 = new SqlParameter("@bank", SqlDbType.VarChar);
           p2.Value = bank;
           SqlParameter p3 = new SqlParameter("@branch", SqlDbType.VarChar);
           p3.Value = branch;
           return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetBankDetails", p, p1, p2, p3));
       }
       public static DataSet Insert_Update_BankDetails(string flag, string citycode, string bankcode, string branchcode, string bankbranch, string bankname, string micrno)
       {
           SqlParameter p = new SqlParameter("@flag", SqlDbType.VarChar);
           p.Value = flag;
           SqlParameter p1 = new SqlParameter("@citycode", SqlDbType.VarChar);
           p1.Value = citycode;
           SqlParameter p2 = new SqlParameter("@bankcode", SqlDbType.VarChar);
           p2.Value = bankcode;
           SqlParameter p3 = new SqlParameter("@branchcode", SqlDbType.VarChar);
           p3.Value = branchcode;
           SqlParameter p4 = new SqlParameter("@bankname", SqlDbType.VarChar);
           p4.Value = bankname;
           SqlParameter p5 = new SqlParameter("@bankbranch", SqlDbType.VarChar);
           p5.Value = bankbranch;
           SqlParameter p6 = new SqlParameter("@micrno", SqlDbType.VarChar);
           p6.Value = micrno;

           return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_BankDetails", p, p1, p2, p3, p4, p5, p6));

       }

    }
}