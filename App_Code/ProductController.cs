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
////using Encryption.BL;
namespace ShoppingCart.BL
{
    public class ProductController
    {
        //All Functions for MT College Project

        //'Function to get Menu
        public static DataSet GetMenu(int Flag, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_U002_Get_Master_Menu_Detail", p1, p2));
        }
        public static DataSet Getleadoppsummary(int Flag, string Userid, string Company)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            SqlParameter p3 = new SqlParameter("@company", Company);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_lead_opp_summary", p1, p2, p3));
        }

        public static DataSet Get_Menu_Items(int Flag, string Menu_Id, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Menu_id", Menu_Id);
            SqlParameter p3 = new SqlParameter("@userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Menu_Items", p1, p2, p3));
        }

        public static string GerrolebyUserid(string Userid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@roleid", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", p);
            return (p[1].Value.ToString());
        }

        public static string GetUserAction(string Userid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@UserCode", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@ActionCode", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_User_Action", p);
            return (p[1].Value.ToString());
        }

        public static DataSet GetCenterbyUserid(string Username)
        {
            SqlParameter P = new SqlParameter("@usr_id", SqlDbType.VarChar);
            P.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCentreby_Userid", P));
        }

        public static void Block(string userid, string Leadid, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@userid", userid);
            SqlParameter p2 = new SqlParameter("@blockid", Leadid);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Block", p1, p2, p3);
        }
        public static void Removerecordsifexists(string Oppid, int Flag, string Materialtype, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@Oppid", Oppid);
            SqlParameter P2 = new SqlParameter("@flag", Flag);
            SqlParameter P3 = new SqlParameter("@material_type", Materialtype);
            SqlParameter P4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_delete_material", p1, P2, P3, P4);
        }

        //Public Shared Sub InsertAddandRemoveItem(ByVal SBEntrycode As String, ByVal Subjectgrp As String, ByVal Flag As Integer)
        //    Dim p1 As New SqlParameter("@sbentrycode", SBENtrycode)
        //    Dim p2 As New SqlParameter("@subjectgrp", Subjectgrp)
        //    Dim p3 As New SqlParameter("@flag", Flag)
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E02_P02", p1, p2, p3)
        //End Sub
        public static void InsertAddandRemoveItem(string SBEntrycode, string Stream, int Flag, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@Stream", Stream);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlParameter p4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E02_P02", p1, p2, p3, p4);
        }

        public static void InsertRemoveItem(string SBEntrycode, string Stream, int Flag, string Orderno)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@Stream", Stream);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            SqlParameter p4 = new SqlParameter("@Orderno", Orderno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_Event_E03_P03", p1, p2, p3, p4);
        }

        public static void Insertchequeallocation(string PPCode, string AMt, string sbentrycode, string Chqno, int Flag, string payeeid, string rcptid)
        {
            SqlParameter p1 = new SqlParameter("@ppcode", PPCode);
            SqlParameter p2 = new SqlParameter("@amt", AMt);
            SqlParameter p3 = new SqlParameter("@sbentrycode", sbentrycode);
            SqlParameter p4 = new SqlParameter("@chqno", Chqno);
            SqlParameter p5 = new SqlParameter("@flag", Flag);
            SqlParameter p6 = new SqlParameter("@payee_id", payeeid);
            SqlParameter p7 = new SqlParameter("@rcpt_id", rcptid);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_cheque_entry", p1, p2, p3, p4, p5, p6, p7);
        }
        //Public Shared Function GerrolebyUserid(ByVal userid As String) As DataSet
        //    Dim P As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    P.Value = userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", P))
        //End Function

        public static string CheckDuplicateAppno(string Company, string Division, string Center, string Stream, string Appno)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@company", SqlDbType.NVarChar);
            p[0].Value = Company;
            p[1] = new SqlParameter("@division", SqlDbType.NVarChar);
            p[1].Value = Division;
            p[2] = new SqlParameter("@center", SqlDbType.NVarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[3].Value = Stream;
            p[4] = new SqlParameter("@app_no", SqlDbType.NVarChar);
            p[4].Value = Appno;
            p[5] = new SqlParameter("@flag", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckAppNo", p);
            return (p[5].Value.ToString());
        }

        public static string CheckDuplicateAppnoreturnoppid(string Company, string Division, string Center, string Stream, string Appno)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@company", SqlDbType.NVarChar);
            p[0].Value = Company;
            p[1] = new SqlParameter("@division", SqlDbType.NVarChar);
            p[1].Value = Division;
            p[2] = new SqlParameter("@center", SqlDbType.NVarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[3].Value = Stream;
            p[4] = new SqlParameter("@app_no", SqlDbType.NVarChar);
            p[4].Value = Appno;
            p[5] = new SqlParameter("@flag", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckAppNo_Return_Oppid", p);
            return (p[5].Value.ToString());
        }

        public static string CheckPrintValue(string SbEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@str", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_printcollegefee", p);
            return (p[1].Value.ToString());
        }

        public static string Checkispromote(string SbEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@promote", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Ispromote", p);
            return (p[1].Value.ToString());
        }

        public static DataSet Getallfellowupdetails(int Flag, string Userid)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Userid", Userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetFollowupDetails", p1, p2));
        }



        // Get All Users 


        public static DataSet Getallusers(int Flag, string Userid, string Password, string Emailid, int Status, string Username)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@userid", SqlDbType.VarChar);
            p1.Value = Userid;
            SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
            p2.Value = Password;
            SqlParameter p3 = new SqlParameter("@Status", SqlDbType.Int);
            p3.Value = Status;
            SqlParameter p4 = new SqlParameter("@Emailid", SqlDbType.VarChar);
            p4.Value = Emailid;
            SqlParameter p5 = new SqlParameter("@Username", SqlDbType.VarChar);
            p5.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsers", P, p1, p2, p3, p4, p5));
        }

        public static SqlDataReader GetUserdetailsbyuserid(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@usrid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UserdetailsbyUserid", p));
        }


        public static DataSet GetallRoles(int Flag, string Roleid, string Rolename, string Roledesc, int Status, string Userid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Roleid", SqlDbType.VarChar);
            p1.Value = Roleid;
            SqlParameter p2 = new SqlParameter("@RoleName", SqlDbType.VarChar);
            p2.Value = Rolename;
            SqlParameter p3 = new SqlParameter("@Roledesc", SqlDbType.VarChar);
            p3.Value = Roledesc;
            SqlParameter p4 = new SqlParameter("@Status", SqlDbType.Int);
            p4.Value = Status;
            SqlParameter p5 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p5.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRoleAction", P, p1, p2, p3, p4, p5));
        }

        public static SqlDataReader GetRoledetailsbyRoleid(string Roleid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Roleid", SqlDbType.NVarChar);
            p[0].Value = Roleid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_RoledetailsbyRoleid", p));
        }

        public static string InsertRole(int Flag, string Roleid, string Rolename, string Roledesc, int Status, string Userid)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Roleid", SqlDbType.NVarChar);
            p[1].Value = Roleid;
            p[2] = new SqlParameter("@RoleName", SqlDbType.VarChar);
            p[2].Value = Rolename;
            p[3] = new SqlParameter("@Roledesc", SqlDbType.NVarChar);
            p[3].Value = Roledesc;
            p[4] = new SqlParameter("@Status", SqlDbType.Int);
            p[4].Value = Status;
            p[5] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[5].Value = Userid;
            p[6] = new SqlParameter("@Roleiddd", SqlDbType.NVarChar, 100);
            p[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertRole", p);
            return (p[6].Value.ToString());
        }

        public static DataSet GetAllMenuItems()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMenuItems"));
        }
        public static DataSet GetAllFeehead()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_getall_pricinginfo"));
        }

        public static DataSet GetAllChequeStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_chkstatus"));
        }
        public static DataSet GetallUom(int flag, string Uomid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = flag;
            SqlParameter p1 = new SqlParameter("@UOMID", SqlDbType.VarChar);
            p1.Value = Uomid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindUnitOfMeasurement", P, p1));
        }
        public static SqlDataReader GetallUomReader(int Flag, string Uomid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@UOMID", SqlDbType.NVarChar);
            p[1].Value = Uomid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindUnitOfMeasurement", p));
        }

        public static DataSet GetallBouncecharge(int flag, string Bounceid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = flag;
            SqlParameter p1 = new SqlParameter("@bounceid", SqlDbType.VarChar);
            p1.Value = Bounceid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bouncedcharges", P, p1));
        }
        public static DataSet GetallMenubyRoles(string Roleid)
        {
            SqlParameter P = new SqlParameter("@Roleid", SqlDbType.VarChar);
            P.Value = Roleid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSelectedMenuItems", P));
        }
        public static DataSet GetallUnselectedMenubyRoles(string Roleid)
        {
            SqlParameter P = new SqlParameter("@Roleid", SqlDbType.VarChar);
            P.Value = Roleid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetMenuitemsUnselected", P));
        }
        public static DataSet InsertRolemenu(int Flag, string Userid, string Roleid, string Menuname, string Menuid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Roleid", SqlDbType.VarChar);
            p1.Value = Roleid;
            SqlParameter p2 = new SqlParameter("@MenuName", SqlDbType.VarChar);
            p2.Value = Menuname;
            SqlParameter p3 = new SqlParameter("@MenuId", SqlDbType.VarChar);
            p3.Value = Menuid;
            SqlParameter p4 = new SqlParameter("@userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertRoleMenu", P, p1, p2, p3, p4));
        }

        public static DataSet GetallCollege(int Flag, string CollegeCode, string Collegename, string Collegeaddress, int Countryid, int Stateid, int Cityid, string Collegepincode, string Website, string Collegeemail,
        string Collegephone, string CollegeContactPerson, string ContactPersonMail, string CollegeContactMobile, int Status, string Userid, int Compnyid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@C_Name", SqlDbType.VarChar);
            p1.Value = Collegename;
            SqlParameter p2 = new SqlParameter("@C_Code", SqlDbType.VarChar);
            p2.Value = CollegeCode;
            SqlParameter p3 = new SqlParameter("@C_Address", SqlDbType.VarChar);
            p3.Value = Collegeaddress;
            SqlParameter p4 = new SqlParameter("@C_CountyId", SqlDbType.Int);
            p4.Value = Countryid;
            SqlParameter p5 = new SqlParameter("@C_StateId", SqlDbType.Int);
            p5.Value = Stateid;
            SqlParameter p6 = new SqlParameter("@C_CityId", SqlDbType.Int);
            p6.Value = Cityid;
            SqlParameter p7 = new SqlParameter("@C_pin", SqlDbType.VarChar);
            p7.Value = Collegepincode;
            SqlParameter p8 = new SqlParameter("@C_Website", SqlDbType.VarChar);
            p8.Value = Website;
            SqlParameter p9 = new SqlParameter("@C_Email", SqlDbType.VarChar);
            p9.Value = Collegeemail;
            SqlParameter p10 = new SqlParameter("@C_phone", SqlDbType.VarChar);
            p10.Value = Collegephone;
            SqlParameter p11 = new SqlParameter("@C_person", SqlDbType.VarChar);
            p11.Value = CollegeContactPerson;
            SqlParameter p12 = new SqlParameter("@c_person_mail", SqlDbType.VarChar);
            p12.Value = ContactPersonMail;
            SqlParameter p13 = new SqlParameter("@c_person_mobile", SqlDbType.VarChar);
            p13.Value = CollegeContactMobile;
            SqlParameter p14 = new SqlParameter("@c_status", SqlDbType.Int);
            p14.Value = Status;
            SqlParameter p15 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p15.Value = Userid;
            SqlParameter p16 = new SqlParameter("@C_Compid", SqlDbType.Int);
            p16.Value = Compnyid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Config_College", P, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
        }

        //Company, Division, Zone, Center'

        //Public Shared Function GetAllActiveCompany() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveCompany"))
        //End Function
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
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p, p1, p2, p3, p4));
        }
        public static DataSet Get_Center_By_Company_Division_Stream( string Companycode,string Divisioncode,  string Stream_Code,int Flag)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@company_code", SqlDbType.VarChar);
            p1.Value = Companycode;
            SqlParameter p2 = new SqlParameter("@division_code", SqlDbType.VarChar);
            p2.Value = Divisioncode;
            SqlParameter p3 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p3.Value = Stream_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Center_by_Company_Division_Stream", p, p1, p2, p3));
        }

        public static DataSet GetAllAcadyear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAcadyear"));
        }

        public static DataSet GetAcademicYearbyCenter(string Centercode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = Centercode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getAcadyear_byCenter", p));
        }

        public static DataSet GetAcademicYearbyCenter_Promote(string Centercode, string CurrentAyString)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = Centercode;
            SqlParameter p1 = new SqlParameter("@CurrentayString", SqlDbType.VarChar);
            p1.Value = CurrentAyString;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getAcadyear_byCenter_Promote", p, p1));
        }

        public static DataSet GetTaxValue(int flag,string Sbentrycode,float vouchervalue, string Centercode)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p1.Value = Sbentrycode ;
            SqlParameter p2 = new SqlParameter("@VoucherValue", SqlDbType.Float);
            p2.Value = vouchervalue ;
            SqlParameter p3 = new SqlParameter("@CenterCode", SqlDbType.VarChar);
            p3.Value = Centercode ;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Tax_Value_by_Amt", p, p1,p2,p3));
        }

        public static DataSet GetStreamby_Center_AcademicYear(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear", p, p1));
        }
        public static DataSet GetStreambyAcadyear_Division(string Division, string AcademicYear, int Flag, string Company)
        {
            SqlParameter p = new SqlParameter("@division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@year", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@flag", SqlDbType.Int);
            p2.Value = Flag;
            SqlParameter p3 = new SqlParameter("@company", SqlDbType.VarChar);
            p3.Value = Company;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllStreambyAcadyear", p, p1, p2, p3));
        }
        public static DataSet GetStreamby_Center_AcademicYear_All(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_All", p, p1));
        }

        public static DataSet GetStreamby_Center_AcademicYear_Dest(string CenterCode, string AcademicYear, string StreamCode)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@StreamCode", SqlDbType.VarChar);
            p2.Value = StreamCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_fordesccenter", p, p1, p2));
        }

        public static DataSet GetStreamby_Center_AcademicYear_Promote(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_Promote", p, p1));
        }
        public static DataSet GetRequestReason(int Flag, string Company, string Division, string Requestid, string Promote_type)
        {
            SqlParameter p = new SqlParameter("@Company", SqlDbType.VarChar);
            p.Value = Company;
            SqlParameter p1 = new SqlParameter("@Division", SqlDbType.VarChar);
            p1.Value = Division;
            SqlParameter p2 = new SqlParameter("@Request_code", SqlDbType.VarChar);
            p2.Value = Requestid;
            SqlParameter p3 = new SqlParameter("@Promote_type", SqlDbType.VarChar);
            p3.Value = Promote_type;
            SqlParameter p4 = new SqlParameter("@flag", SqlDbType.VarChar);
            p4.Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_promoteapproval", p, p1, p2, p3, p4));
        }

        public static SqlDataReader GetMandatesubjectsbyStream(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Stream_Code", SqlDbType.NVarChar);
            p[1].Value = Stream_Code;
            p[2] = new SqlParameter("@Center_Code", SqlDbType.NVarChar);
            p[2].Value = Center_Code;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p));
        }
        public static DataSet GetMandatesubjectsbyStreamds(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p, p1, p2));
        }
        public static DataSet GetMandatesubjectsbyStreamforedit(int flag, string Opp_Id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@oppid", SqlDbType.VarChar);
            p1.Value = Opp_Id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSub_Preference", p, p1));
        }

        public static DataSet GetSubjectsbyStreamCode(int flag, string Stream_Code, string Center_Code)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetSubjectby_CenterStream", p, p1, p2));
        }
        public static DataSet Getproductsforremove(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Remove_Material", p, p1, p2, p3, p4));
        }

        public static DataSet GetproductsforAdd(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Add_material", p, p1, p2, p3, p4));
        }

        public static DataSet GetproductsforPayplan(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Customer_Material", p, p1, p2, p3, p4));
        }

        public static DataSet Getorder(int flag, string Stream_Code, string Center_Code, string Sbentrycode, string Userid)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Stream_Code", SqlDbType.VarChar);
            p1.Value = Stream_Code;
            SqlParameter p2 = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p2.Value = Center_Code;
            SqlParameter p3 = new SqlParameter("@SBentrycode", SqlDbType.VarChar);
            p3.Value = Sbentrycode;
            SqlParameter p4 = new SqlParameter("@Userid", SqlDbType.VarChar);
            p4.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayOrder", p, p1, p2, p3, p4));
        }


        public static SqlDataReader GetContactsbyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetcontactsbyOppid", p));
        }
        public static SqlDataReader GetEnrollmentbyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetEnrollDetailsby_Oppid", p));
        }
        //Public Shared Function GetAllActiveDivision(ByVal CompanyCode As String) As DataSet
        //    Dim P As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P.Value = CompanyCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveviDivision", P))
        //End Function
        //Public Shared Function GetAllActiveDivision(ByVal CompanyCode As String, ByVal Userid As String) As DataSet
        //    Dim P As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P.Value = CompanyCode
        //    Dim P1 As New SqlParameter("@Company_Code", SqlDbType.NVarChar)
        //    P1.Value = Userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveviDivision", P, P1))
        //End Function

        public static DataSet GetAllSubjectMarks(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Subject", SqlDbType.VarChar);
            p2.Value = Subject;
            SqlParameter p3 = new SqlParameter("@max_marks", SqlDbType.VarChar);
            p3.Value = Maxmarks;
            SqlParameter p4 = new SqlParameter("@Marks_Obtained", SqlDbType.VarChar);
            p4.Value = Marksobtained;
            SqlParameter p5 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p5.Value = Userid;
            SqlParameter p6 = new SqlParameter("@id", SqlDbType.BigInt);
            p6.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p, p1, p2, p3, p4, p5, p6));
        }
        public static SqlDataReader GetSubjectdetailsbyid(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Opp_id", SqlDbType.NVarChar);
            p[1].Value = Oppid;
            p[2] = new SqlParameter("@Subject", SqlDbType.NVarChar);
            p[2].Value = Subject;
            p[3] = new SqlParameter("@max_marks", SqlDbType.NVarChar);
            p[3].Value = Maxmarks;
            p[4] = new SqlParameter("@Marks_Obtained", SqlDbType.NVarChar);
            p[4].Value = Marksobtained;
            p[5] = new SqlParameter("@User_id", SqlDbType.NVarChar);
            p[5].Value = Userid;
            p[6] = new SqlParameter("@id", SqlDbType.BigInt);
            p[6].Value = id;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p));
        }

        public static void InsertMarks(int flag, string Oppid, string Subject, string Maxmarks, string Marksobtained, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Subject", Subject);
            SqlParameter p4 = new SqlParameter("@max_marks", Maxmarks);
            SqlParameter p5 = new SqlParameter("@Marks_Obtained", Marksobtained);
            SqlParameter p6 = new SqlParameter("@User_id", Userid);
            SqlParameter p7 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertSubjectMarks", p1, p2, p3, p4, p5, p6, p7);
        }

        public static DataSet GetAllScore(int flag, string Oppid, string Scoretypeid, string Score, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Scoretypeid", SqlDbType.VarChar);
            p2.Value = Scoretypeid;
            SqlParameter p3 = new SqlParameter("@Score", SqlDbType.VarChar);
            p3.Value = Score;
            SqlParameter p4 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p4.Value = Userid;
            SqlParameter p5 = new SqlParameter("@id", SqlDbType.BigInt);
            p5.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ScoreAll", p, p1, p2, p3, p4, p5));
        }
        public static void InsertScore(int flag, string Oppid, string Scoretypeid, string Score, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Scoretypeid", Scoretypeid);
            SqlParameter p4 = new SqlParameter("@Score", Score);
            SqlParameter p5 = new SqlParameter("@User_id", Userid);
            SqlParameter p6 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ScoreAll", p1, p2, p3, p4, p5, p6);
        }
        public static void InsertUserSettings(string userid, string acadyear, string yeareducation, string leadsource, string leadstatus, string createdfrom, string createdto)
        {
            SqlParameter p1 = new SqlParameter("@userid", userid);
            SqlParameter p2 = new SqlParameter("@acadyear", acadyear);
            SqlParameter p3 = new SqlParameter("@yeareducation", yeareducation);
            SqlParameter p4 = new SqlParameter("@leadsource", leadsource);
            SqlParameter p5 = new SqlParameter("@leadstatus", leadstatus);
            SqlParameter p6 = new SqlParameter("@createdfrom", createdfrom);
            SqlParameter p7 = new SqlParameter("@createdto", createdto);

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_configure_usersettings", p1, p2, p3, p4, p5, p6, p7);

        }
        public static DataSet Extracurricular(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter p = new SqlParameter("@Flag", SqlDbType.SmallInt);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@Opp_id", SqlDbType.VarChar);
            p1.Value = Oppid;
            SqlParameter p2 = new SqlParameter("@Curricular_Activity_id", SqlDbType.BigInt);
            p2.Value = Curricular_Activity_id;
            SqlParameter p3 = new SqlParameter("@Description", SqlDbType.VarChar);
            p3.Value = Description;
            SqlParameter p4 = new SqlParameter("@User_id", SqlDbType.VarChar);
            p4.Value = Userid;
            SqlParameter p5 = new SqlParameter("@id", SqlDbType.BigInt);
            p5.Value = id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p, p1, p2, p3, p4, p5));
        }
        public static SqlDataReader Getextracurricularbyid(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Opp_id", SqlDbType.NVarChar);
            p[1].Value = Oppid;
            p[2] = new SqlParameter("@Curricular_Activity_id", SqlDbType.BigInt);
            p[2].Value = Curricular_Activity_id;
            p[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
            p[3].Value = Description;
            p[4] = new SqlParameter("@User_id", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@id", SqlDbType.BigInt);
            p[5].Value = id;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p));
        }

        public static void InsertExtraactivity(int flag, string Oppid, int Curricular_Activity_id, string Description, string Userid, int id)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@Opp_id", Oppid);
            SqlParameter p3 = new SqlParameter("@Curricular_Activity_id", Curricular_Activity_id);
            SqlParameter p4 = new SqlParameter("@Description", Description);
            SqlParameter p5 = new SqlParameter("@User_id", Userid);
            SqlParameter p6 = new SqlParameter("@id", id);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ExtraCurricular", p1, p2, p3, p4, p5, p6);
        }




        //Country, State, City, Nationality
        public static DataSet GetallCountry()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCountry"));
        }

        public static DataSet GetallStatebyCountry(int Countrycode)
        {
            SqlParameter P = new SqlParameter("@Cid", SqlDbType.Int);
            P.Value = Countrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllStatebyCountryId", P));
        }

        public static DataSet GetallCitybyState(int StateCode)
        {
            SqlParameter P = new SqlParameter("@Sid", SqlDbType.Int);
            P.Value = StateCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCityByStateId", P));
        }

        public static DataSet GetallCity(int Flag, int Countryid, int Stateid, string Cityname, string CityCode, int Status, string Userid)
        {
            SqlParameter P = new SqlParameter("@flag", SqlDbType.Int);
            P.Value = Flag;
            SqlParameter p1 = new SqlParameter("@C_CountryId", SqlDbType.Int);
            p1.Value = Countryid;
            SqlParameter p2 = new SqlParameter("@C_StateId", SqlDbType.Int);
            p2.Value = Stateid;
            SqlParameter p3 = new SqlParameter("@C_CityName", SqlDbType.VarChar);
            p3.Value = Cityname;
            SqlParameter p4 = new SqlParameter("@C_CityCode", SqlDbType.VarChar);
            p4.Value = CityCode;
            SqlParameter p5 = new SqlParameter("@c_status", SqlDbType.Int);
            p5.Value = Status;
            SqlParameter p6 = new SqlParameter("@user_id", SqlDbType.VarChar);
            p6.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Config_City", P, p1, p2, p3, p4, p5, p6));
        }

        public static SqlDataReader GetCityDetailsbyCityid(string Citycode)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@code", SqlDbType.VarChar);
            p[0].Value = Citycode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCityByCode", p));
        }

        public static DataSet GetallNationality()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllNationality"));
        }

        public static DataSet GetallMothertongue()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMotherTongue"));
        }

        public static DataSet GetallReligion()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllReligion"));
        }

        public static DataSet GetallCaste()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCasteNew"));
        }
        public static DataSet GetallCardtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCardType"));
        }


        //Public Shared Function GetallCastebyreligion(ByVal Religionid As String) As DataSet
        //    Dim P As New SqlParameter("@religionid", SqlDbType.VarChar)
        //    P.Value = Religionid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCaste", P))
        //End Function

        public static DataSet GetallStudentcastegroup()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStudentGroup"));
        }

        public static DataSet GetallMediumofInstruction()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllMediumofInstruction"));
        }

        public static DataSet GetallStay()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStay"));
        }

        public static DataSet GetallMonthofpassing()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllPassingmonth"));
        }

        public static DataSet GetallSportlevel()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSportlevel"));
        }

        //College details
        public static SqlDataReader GetCollegeDetailsbyCollegeid(int Collegeid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@cid", SqlDbType.Int);
            p[0].Value = Collegeid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCollegebyId", p));
        }
















        //Old Functions used for LMS


        //public static string Validatefilename(string Filename)
        //{
        //    SqlParameter p = new SqlParameter("@Import_File_Name", Filename);
        //    return (int.Parse(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckExcelFile", p).ToString()));
        //}


        public static int FindliastnumusedS006(string tblname)
        {
            SqlParameter p = new SqlParameter("@Table_Name", tblname);
            return (int.Parse(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_find_last_num_S006", p).ToString()));
        }


        public static string InsertT009(string flag, string Import_Run_No, DateTime Import_Date, string Import_File_Name, string tag_name, string record_count, string tag_desc, string Created_by)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@Flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@Import_Run_No", SqlDbType.NVarChar);
            p[1].Value = Import_File_Name;
            p[2] = new SqlParameter("@Import_Date", SqlDbType.DateTime);
            p[2].Value = Import_Date;
            p[3] = new SqlParameter("@Import_File_Name", SqlDbType.NVarChar);
            p[3].Value = Import_File_Name;
            p[4] = new SqlParameter("@Tag_Name", SqlDbType.NVarChar);
            p[4].Value = tag_name;
            p[5] = new SqlParameter("@Record_Count", SqlDbType.NVarChar);
            p[5].Value = record_count;
            p[6] = new SqlParameter("@TagDescription", SqlDbType.NVarChar);
            p[6].Value = tag_desc;
            p[7] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[7].Value = Created_by;
            p[8] = new SqlParameter("@Run_Number", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Import_T009_Lead_Import", p);
            return (p[8].Value.ToString());
        }

        public static string InsertLeadContact(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal Percentile, int AreaRank,
        int OverallRank, string Score_Range_Type, string Handphone1, string handphone2, string landline, string Emailid, string Flatno, string Buildingname, string Streetname, string Country,
        string State, string City, string Pincode, string Lead_Code, string Lead_Source_Code, string lead_src_desc, string Lead_Type_Code, string Lead_Status_Code, string lead_status_desc, string lead_campgn_id,
        string prod_interest, string time_join, string Lead_Contact_Code, string Contact_Source_Company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_role, string Contact_assignto, string last_modified_by,
        string Created_By, string Import_Run_No, string Stream_code, string MTStudentNotes, string Contact_Target_Company, string Contact_Target_Division, string Contact_Target_Zone, string Contact_Target_Center, string Discipline_Desc, string Field_Interested,
        string Competitive_exam, string lead_Type_Desc, string Category_Type, string InstitutionTypedesc, string Institutiondesc, string Current_Standard_desc, string AdditionalDesc, string Boarddesc, string Sectiondesc, string Yearofpassingdesc,
        string CurrentYeardesc, string Studentid, string Lastcourseopted, DateTime expectedtimejoin)
        {
            SqlParameter[] p = new SqlParameter[64];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            p[8] = new SqlParameter("@score", SqlDbType.Decimal);
            p[8].Value = Score;
            p[9] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[9].Value = Percentile;
            p[10] = new SqlParameter("@Area_Rank", SqlDbType.Int);
            p[10].Value = AreaRank;
            p[11] = new SqlParameter("@Overall_Rank", SqlDbType.Int);
            p[11].Value = OverallRank;
            p[12] = new SqlParameter("@Score_Range_Type", SqlDbType.NVarChar);
            p[12].Value = Score_Range_Type;
            p[13] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[13].Value = Handphone1;
            p[14] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[14].Value = handphone2;
            p[15] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[15].Value = landline;
            p[16] = new SqlParameter("@Emailid", SqlDbType.NVarChar);
            p[16].Value = Emailid;

            p[17] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[17].Value = Flatno;
            p[18] = new SqlParameter("@BuildingName", SqlDbType.NVarChar);
            p[18].Value = Buildingname;
            p[19] = new SqlParameter("@StreetName", SqlDbType.NVarChar);
            p[19].Value = Streetname;
            p[20] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[20].Value = Country;
            p[21] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[21].Value = State;
            p[22] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[22].Value = City;
            p[23] = new SqlParameter("@Pincode", SqlDbType.NVarChar);
            p[23].Value = Pincode;



            p[24] = new SqlParameter("@Lead_Code", SqlDbType.NVarChar);
            p[24].Value = Lead_Code;
            p[25] = new SqlParameter("@Lead_Source_Code", SqlDbType.NVarChar);
            p[25].Value = Lead_Source_Code;
            p[26] = new SqlParameter("@lead_Src_desc", SqlDbType.NVarChar);
            p[26].Value = lead_src_desc;
            p[27] = new SqlParameter("@Lead_Type_Code", SqlDbType.NVarChar);
            p[27].Value = Lead_Type_Code;
            p[28] = new SqlParameter("@Lead_Status_Code", SqlDbType.NVarChar);
            p[28].Value = Lead_Status_Code;
            p[29] = new SqlParameter("@lead_status_desc", SqlDbType.NVarChar);
            p[29].Value = lead_status_desc;
            p[30] = new SqlParameter("@lead_campgn_id", SqlDbType.NVarChar);
            p[30].Value = lead_campgn_id;
            p[31] = new SqlParameter("@prod_interest", SqlDbType.NVarChar);
            p[31].Value = prod_interest;
            //p(32) = New SqlParameter("@time_join", SqlDbType.NVarChar)
            //p(32).Value = time_join
            p[32] = new SqlParameter("@Lead_Contact_Code", SqlDbType.NVarChar);
            p[32].Value = Lead_Contact_Code;
            p[33] = new SqlParameter("@Contact_Source_Company", SqlDbType.NVarChar);
            p[33].Value = Contact_Source_Company;

            p[34] = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p[34].Value = Contact_Source_Division;
            p[35] = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p[35].Value = Contact_Source_Center;
            p[36] = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p[36].Value = Contact_Source_Zone;
            p[37] = new SqlParameter("@contact_role", SqlDbType.NVarChar);
            p[37].Value = Contact_role;
            p[38] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[38].Value = Contact_assignto;
            p[39] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[39].Value = last_modified_by;
            p[40] = new SqlParameter("@createdby", SqlDbType.NVarChar);
            p[40].Value = Created_By;
            p[41] = new SqlParameter("@import_run_no", SqlDbType.NVarChar);
            p[41].Value = Import_Run_No;

            p[42] = new SqlParameter("@stream_code", SqlDbType.NVarChar);
            p[42].Value = Stream_code;
            p[43] = new SqlParameter("@MTStudentNotes", SqlDbType.NVarChar);
            p[43].Value = MTStudentNotes;

            p[44] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[44].Value = Contact_Target_Company;
            p[45] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[45].Value = Contact_Target_Division;
            p[46] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[46].Value = Contact_Target_Zone;
            p[47] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[47].Value = Contact_Target_Center;

            p[48] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[48].Value = Discipline_Desc;
            p[49] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[49].Value = Field_Interested;
            p[50] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[50].Value = Competitive_exam;

            p[51] = new SqlParameter("@Lead_Type_Desc", SqlDbType.NVarChar);
            p[51].Value = lead_Type_Desc;

            p[52] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[52].Value = Category_Type;

            p[53] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[53].Value = InstitutionTypedesc;
            p[54] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[54].Value = Institutiondesc;
            p[55] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[55].Value = Current_Standard_desc;
            p[56] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[56].Value = AdditionalDesc;
            p[57] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[57].Value = Boarddesc;
            p[58] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[58].Value = Sectiondesc;
            p[59] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[59].Value = Yearofpassingdesc;
            p[60] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[60].Value = CurrentYeardesc;
            p[61] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[61].Value = Studentid;
            p[62] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[62].Value = Lastcourseopted;
            p[63] = new SqlParameter("@time_join", SqlDbType.DateTime);
            p[63].Value = expectedtimejoin;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Import_Lead_Contact", p);
            return (p[7].Value.ToString());
        }


        //Public Shared Function GetMenu(ByVal Flag As Integer, ByVal Userid As String) As DataSet
        //    Dim p1 As New SqlParameter("@FLAG", Flag)
        //    Dim p2 As New SqlParameter("@Userid", Userid)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_U002_Get_Master_Menu_Detail", p1, p2))
        //End Function



        //Public Shared Function Get_Menu_Items(ByVal Flag As Integer, ByVal Menu_Id As String, ByVal Userid As String) As DataSet
        //    Dim p1 As New SqlParameter("@FLAG", Flag)
        //    Dim p2 As New SqlParameter("@Menu_id", Menu_Id)
        //    Dim p3 As New SqlParameter("@userid", Userid)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Menu_Items", p1, p2, p3))
        //End Function

        //Public Shared Function GerrolebyUserid(ByVal userid As String) As DataSet
        //    Dim P As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    P.Value = userid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", P))
        //End Function

        //Public Shared Function GerrolebyUserid(ByVal Userid As String) As String
        //    Dim p As SqlParameter() = New SqlParameter(1) {}
        //    p(0) = New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p(0).Value = Userid
        //    p(1) = New SqlParameter("@roleid", SqlDbType.NVarChar, 100)
        //    p(1).Direction = ParameterDirection.Output
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolebyUserid", p)
        //    Return (p(1).Value.ToString())
        //End Function

        //Public Shared Function Getleadcount() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLeadCount"))
        //End Function
        public static DataSet GetallOpporProductCategory()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"));
        }

        public static DataSet GetAllSalesChannel()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllSalesChannel"));
        }
        //Public Shared Function GetallOpporSalesStage() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"))
        //End Function
        public static DataSet GetAllOpporStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"));
        }


        public static SqlDataReader Getleadcount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLeadCount", p));
        }
        public static SqlDataReader GetOpportunitycount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetOpportunityCount", p));
        }
        public static SqlDataReader GetAccountcount(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", SqlDbType.VarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAccountCount", p));
        }

        public static SqlDataReader Get_SecondaryContactbyLeadidforfield(string Leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Leadid", SqlDbType.VarChar);
            p[0].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyleadid", p));
        }
        public static SqlDataReader Get_SecondaryContactbyLeadidforfield1(string Conid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Conid", SqlDbType.VarChar);
            p[0].Value = Conid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_SecContactdetailsbyConid", p));
        }
        public static SqlDataReader Get_ContactbyLeadidforfield(int Flag, string Leadid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@lead_opp_id", SqlDbType.VarChar);
            p[1].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETCONID", p));
        }
        public static SqlDataReader Get_ContactbyOppuridforfield(int Flag, string Leadid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@lead_opp_id", SqlDbType.VarChar);
            p[1].Value = Leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETCONID", p));
        }

        public static SqlDataReader Get_SecondaryContactbyOppididforfield(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.VarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyOppid", p));
        }
        //Public Shared Function Get_ContactbyOppididforSecondaryCon(ByVal Flag As String, ByVal Oppid As String) As SqlDataReader
        //    Dim p As SqlParameter() = New SqlParameter(1) {}
        //    p(0) = New SqlParameter("@Flag", SqlDbType.VarChar)
        //    p(0).Value = Flag
        //    p(1) = New SqlParameter("@Oppid", SqlDbType.VarChar)
        //    p(1).Value = Oppid
        //    Return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_getsecondaryinfo", p))
        //End Function
        public static DataSet Getallactiveleadtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllActiveLeadTYpe"));
        }


        public static DataSet GetallactiveleadSource()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveLeadSource"));
        }

        public static DataSet GetallactiveleadStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveLeadstatus"));
        }

        public static DataSet GetallInteractedwith()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInteractedWith"));
        }


        public static DataSet GetallProductCategory()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductCategory"));
        }

        public static DataSet GetallSalesStage()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSalesStage"));
        }

        public static DataSet GetallactiveContactType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllContactTYpe"));
        }
        public static DataSet GetallactiveContactTypeinrelation()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllContactTYpe_Allrelation"));
        }
        public static DataSet GetallactiveContactTypeSecondary()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSecondaryContactType"));
        }
        //USP_GetAllSContactTYpebyPContactTYpe

        public static DataSet GetAllSContactTypebyPContactType(string Primary_Contact_Type)
        {
            SqlParameter P = new SqlParameter("@Primary_Contact_ID", SqlDbType.VarChar);
            P.Value = Primary_Contact_Type;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSContactTYpebyPContactTYpe", P));
        }

        public static DataSet GetallResidenceType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllResidencetype"));
        }
        public static DataSet GetallQualification()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllQualification"));
        }
        //Public Shared Function GetallCountry() As DataSet
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCountry"))
        //End Function

        public static DataSet GetAllDivisionSection()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallDivisionSection"));
        }

        public static DataSet GetAllCurrentyear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentYear"));
        }
        public static DataSet GetAllCurrentyearEducation()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Getall_CurrentYearEducation"));
        }
        public static DataSet GetallInstituteType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstituteType"));
        }
        public static DataSet GetallEventtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DispEvents"));
        }
        public static DataSet GetallBoard()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallBoard"));
        }
        public static DataSet GetallBoardbyinstitutetype(string InstituteTypeid)
        {
            SqlParameter P = new SqlParameter("@Insid", SqlDbType.VarChar);
            P.Value = InstituteTypeid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Getboardby_INSID", P));
        }
        public static DataSet GetallYearofpassing()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallYearofpassing"));
        }

        public static DataSet GetallCurrentStudyingin(string InstituteTypeid)
        {
            SqlParameter P = new SqlParameter("@Institute_Type_Id", SqlDbType.VarChar);
            P.Value = InstituteTypeid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentStudyingin", P));
        }

        public static DataSet GetallDiscipline()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDiscipline"));
        }

        public static DataSet GetAllFieldInterestedByDisciplineid(int Discipline_Id)
        {
            SqlParameter P = new SqlParameter("@DisciplineId", SqlDbType.Int);
            P.Value = Discipline_Id;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllFieldbyDiscipline", P));
        }

        public static DataSet GetallStatebyCountry(string Countrycode)
        {
            SqlParameter P = new SqlParameter("@Countrycode", SqlDbType.NVarChar);
            P.Value = Countrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStatebyCountry", P));
        }

        public static DataSet GetallCitybyState(string StateCode)
        {
            SqlParameter P = new SqlParameter("@Statecode", SqlDbType.NVarChar);
            P.Value = StateCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCitybyState", P));
        }
        

        public static DataSet GetAllZones()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllZone"));
        }

        public static DataSet GetallZonebyDivision(string DivisionCode, int Flag)
        {
            SqlParameter P1 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter P2 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ZoneDetails", P1, P2));
        }




        public static DataSet GetAllProductbyDivision(string DivisionCode)
        {
            SqlParameter P = new SqlParameter("@DivisionCode", SqlDbType.NVarChar);
            P.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductbyDivision", P));
        }

        //Public Shared Function GetAllProductbyCenter(ByVal DivisionCode As String) As DataSet
        //    Dim P As New SqlParameter("@DivisionCode", SqlDbType.NVarChar)
        //    P.Value = DivisionCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllProductbyDivision", P))
        //End Function

        public static DataSet GetallCentersByDivision(string DivsionCode)
        {
            SqlParameter P = new SqlParameter("@divisioncode", SqlDbType.NVarChar);
            P.Value = DivsionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetCentersbyDivisionCode", P));
        }

        public static DataSet GetAllDivision()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllDivision"));
        }

        public static DataSet GetallZonebyDivision(string CompanyCode, string DivisonCode)
        {
            SqlParameter P = new SqlParameter("@Company_Code", SqlDbType.NVarChar);
            P.Value = CompanyCode;
            SqlParameter p1 = new SqlParameter("@Source_Division_Code", SqlDbType.NVarChar);
            p1.Value = DivisonCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallZonebyDivision", P, p1));
        }

        public static DataSet GetAllCenterbyZone(string ZoneCode)
        {
            SqlParameter P = new SqlParameter("@Zone_Code", SqlDbType.NVarChar);
            P.Value = ZoneCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCenterbyZone", P));
        }

        public static DataSet GetAllLeadfeedbackbyLeadid(string Leadid)
        {
            SqlParameter P = new SqlParameter("@leadid", SqlDbType.NVarChar);
            P.Value = Leadid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllfeedbackbyLeadid", P));
        }

        public static DataSet GetAllOpporfeedbackbyOpporid(string Opporid)
        {
            SqlParameter P = new SqlParameter("@oppor_id", SqlDbType.NVarChar);
            P.Value = Opporid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllfeedbackbyOpporid", P));
        }

        public static DataSet GetAllStudentType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallStudentType"));
        }

        public static DataSet GetSalesStage(int Flag)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@flag", SqlDbType.VarChar);
            p[0].Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetSalesStage", p));
        }


        public static DataSet GetScorerange()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetScorerange"));
        }

        public static DataSet GetallRoles()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRoles"));
        }

        public static DataSet GetallLeadtype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadtype"));
        }

        public static DataSet GetallLeadSource()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadSource"));
        }

        public static DataSet GetallLeadStatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallLeadStatus"));
        }

        public static DataSet GetallContactType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallGContactType"));
        }

        public static DataSet GetallScorerangetype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallScorerangeType"));
        }

        public static DataSet Getallusers()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsers"));
        }

        public static DataSet Getallusersbyusername(string Username)
        {
            SqlParameter P = new SqlParameter("@Username", SqlDbType.NVarChar);
            P.Value = Username;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllUsersbyusername", P));

        }

        public static void InsertLeadType(string Leaddesc)
        {
            SqlParameter p1 = new SqlParameter("@description", Leaddesc);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadtype", p1);
        }


        public static void InsertLeadSource(string LeadStatus)
        {
            SqlParameter p1 = new SqlParameter("@description", LeadStatus);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadSource", p1);
        }


        public static void InsertLeadStatus(string Leadstatus)
        {
            SqlParameter p1 = new SqlParameter("@description", Leadstatus);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadStatus", p1);
        }

        public static void InsertReceiptforevent(int flag,string sbentrycode, string userid, string newsbentrycode, float Zrefamt)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@sbentryCode", sbentrycode);
            SqlParameter p3 = new SqlParameter("@userid", userid);
            SqlParameter p4 = new SqlParameter("@NewSbentrycode", newsbentrycode);
            SqlParameter p5 = new SqlParameter("@Zref_amt", Zrefamt);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Receipt_for_Events", p1,p2,p3,p4,p5);
        }



        public static void InsertContactType(string Contactype)
        {
            SqlParameter p1 = new SqlParameter("@description", Contactype);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertContactType", p1);
        }

        public static void InsertScorerangeType(string Scorerangetype)
        {
            SqlParameter p1 = new SqlParameter("@description", Scorerangetype);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertScorerangetype", p1);
        }


        public static DataSet Getuserbyuserid(string Userid)
        {
            SqlParameter P = new SqlParameter("@Userid", SqlDbType.NVarChar);
            P.Value = Userid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetUsersbyuserid", P));
        }

        public static DataSet Get_SecondaryContactbyLeadid(string Leadid)
        {
            SqlParameter P = new SqlParameter("@Leadid", SqlDbType.NVarChar);
            P.Value = Leadid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyleadid", P));
        }
        public static DataSet Get_SecondaryContactbyOpporid(string Opporid)
        {
            SqlParameter P = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            P.Value = Opporid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_SecContactdetailsbyOppid", P));
        }
        //for Chart

        public static DataSet GetOpportunityCountbySalesstage()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetOpportunityCountbySalesstage"));
        }

        public static DataSet GetLeadCountbyleadstatus()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetLeadCountbyleadstatus"));
        }

        public static DataSet GetTotalPipelinebySalesStage()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetTotalPipelinebySalesStage"));
        }

        public static DataSet GetConvertedLeadsMonthlyStatistics()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetConvertedLeadsMonthlyStatistics"));
        }

        public static DataSet GetConvertedOpportunityMonthlyStatistics()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "GetConvertedOpportunityMonthlyStatistics"));
        }

        //end Chart
        public static DataSet GetFileNameForAttachment(int flag, string ProcessNum, string ProcessType, string UserID, string DocNotes, string DocumentName)
        {

            SqlParameter p = new SqlParameter("@ProcessNumber", SqlDbType.NVarChar);
            p.Value = ProcessNum;
            SqlParameter p1 = new SqlParameter("@ProcessType", SqlDbType.NVarChar);
            p1.Value = ProcessType;
            SqlParameter p2 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p2.Value = UserID;
            SqlParameter p3 = new SqlParameter("@DocNotes", SqlDbType.NVarChar);
            p3.Value = DocNotes;
            SqlParameter p4 = new SqlParameter("@flagID", SqlDbType.Int);
            p4.Value = flag;
            SqlParameter p5 = new SqlParameter("@DocumentName", SqlDbType.VarChar);
            p5.Value = DocumentName;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "isp_AttachDocument", p, p1, p2, p3, p4, p5));
        }

        public static DataSet GetSelectedSubjectGroupsInLeadByStreamCode(string LeadID, string StreamID)
        {
            SqlParameter p = new SqlParameter("@OppCode", SqlDbType.NVarChar);
            p.Value = LeadID;
            SqlParameter p1 = new SqlParameter("@OppCode", SqlDbType.NVarChar);
            p1.Value = StreamID;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "vsp_FetchSubjectgroupCodeByID", p));
        }



        public static void AssignroletoUser(string userid, string roleid, string Createdby)
        {
            SqlParameter p1 = new SqlParameter("@Userid", userid);
            SqlParameter p2 = new SqlParameter("@Roleid", roleid);
            SqlParameter p3 = new SqlParameter("@createdby", Createdby);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_AssignUseridtoRoleid", p1, p2, p3);
        }

        public static void AssignCenterstoZone(string CenterCode, string ZoneCode)
        {
            SqlParameter p1 = new SqlParameter("@ZoneCode", ZoneCode);
            SqlParameter p2 = new SqlParameter("@CenterCode", CenterCode);

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_AssignCenterstoZone", p1, p2);
        }

        public static void CreateZones(string CompanyCode, string DivisionCode, string Zonename)
        {
            SqlParameter p1 = new SqlParameter("@CompanyCode", CompanyCode);
            SqlParameter p2 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter p3 = new SqlParameter("@Zonename", Zonename);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CreateZones", p1, p2, p3);
        }


        //Subject Add, Remove and Change
        public static DataSet GetSubjectgroupbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_fill_newsubgrp", p));
        }

        public static DataSet ManageSubjectgroupbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "vsp_ManageSubjectGroup", p));
        }

        public static DataSet GetSubjectgroupToberemovedbysbentrycode(string Bid)
        {
            SqlParameter p = new SqlParameter("@SbentryCode", SqlDbType.NVarChar);
            p.Value = Bid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_Fill_Remove_SG", p));
        }

        public static DataSet GetCentersbyDivision(string DivisionCode)
        {
            SqlParameter p = new SqlParameter("@division_code", SqlDbType.NVarChar);
            p.Value = DivisionCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CenterbyDivision", p));
        }


        //Public Shared Function GetUserRoleid(ByVal UserID As String, ByVal inp As Integer, ByVal RoleID As String, ByVal MenuCode As String) As DataSet
        //    Dim p As New SqlParameter("@flag", SqlDbType.Int)
        //    p.Value = inp
        //    Dim p1 As New SqlParameter("@UserID", SqlDbType.NVarChar)
        //    p1.Value = UserID
        //    Dim p2 As New SqlParameter("@RoleID", SqlDbType.NVarChar)
        //    p2.Value = RoleID
        //    Dim p3 As New SqlParameter("@MenuCode", SqlDbType.NVarChar)
        //    p3.Value = MenuCode
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "User_Authorization", p, p1, p2, p3))
        //End Function

        public static SqlDataReader GetUserRoleid(string UserID, int inp, string RoleID, string MenuCode)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = inp;
            p[1] = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p[1].Value = UserID;
            p[2] = new SqlParameter("@RoleID", SqlDbType.NVarChar);
            p[2].Value = RoleID;
            p[3] = new SqlParameter("@MenuCode", SqlDbType.NVarChar);
            p[3].Value = MenuCode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "User_Authorization", p));
        }



        public static string GetNewSbntrycodebyOldSbnetrycode( int flag,string sbentrycode)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@sbentryCode", SqlDbType.NVarChar);
            p[1].Value = sbentrycode  ;
            p[2] = new SqlParameter("@NewSbentrycode", SqlDbType.NVarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Newsbentrycodebyoldsbentrycode", p);
            return (p[2].Value.ToString());
        }



        public static string InsertAddManualLeadContact(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank,
        int Overallrank, string Scorerange, string Lead_Code, string Lead_Source_Code, string lead_src_desc, string Lead_Type_Code, string Lead_Status_Code, string lead_status_desc, string lead_campgn_id, string prod_interest,
        string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_role, string Contact_assignto, string last_modified_by, string Created_By, string Import_Run_No,
        string Stream_code, string MTStudentNotes, string Contact_Target_Company, string Contact_Target_Division, string Contact_Target_Zone, string Contact_Target_Center, string Handphone1, string handphone2, string landline, string emailid,
        string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode, int discipline_id, string Discipline_desc, int Field_Id,
        string Field_Desc, string Competitive_Exam, string Lead_Type_Desc, string Category_Type_Id, string Category_Type, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc,
        string AdditionalDesc, string Boardid, string Boarddesc, string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string Studentid,
        string LastCourseOpted, DateTime Timejoin, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline,
        string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity, string Secpincode, string SecContactDesc, int Totalmsmarks,
        int Totalmsmarksobt, string Leadsourcedesc, string Dob, string Examination, string Location, string Gender, int C_Year_Education)
        {
            SqlParameter[] p = new SqlParameter[98];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[7].Value = Score;
            p[8] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[8].Value = percentile;
            p[9] = new SqlParameter("@Area_rank", SqlDbType.Int);
            p[9].Value = Area_rank;
            p[10] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[10].Value = Overallrank;
            p[11] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[11].Value = Scorerange;
            p[12] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[12].Direction = ParameterDirection.Output;


            p[13] = new SqlParameter("@lead_no", SqlDbType.NVarChar);
            p[13].Value = Lead_Code;
            p[14] = new SqlParameter("@lead_src_id", SqlDbType.NVarChar);
            p[14].Value = Lead_Source_Code;
            p[15] = new SqlParameter("@lead_Src_desc", SqlDbType.NVarChar);
            p[15].Value = lead_src_desc;
            p[16] = new SqlParameter("@Lead_Type_Id", SqlDbType.NVarChar);
            p[16].Value = Lead_Type_Code;
            p[17] = new SqlParameter("@lead_status_id", SqlDbType.NVarChar);
            p[17].Value = Lead_Status_Code;
            p[18] = new SqlParameter("@lead_status_desc", SqlDbType.NVarChar);
            p[18].Value = lead_status_desc;
            p[19] = new SqlParameter("@lead_campgn_id", SqlDbType.NVarChar);
            p[19].Value = lead_campgn_id;
            p[20] = new SqlParameter("@prod_interest", SqlDbType.NVarChar);
            p[20].Value = prod_interest;
            p[21] = new SqlParameter("@lead_Con_id", SqlDbType.NVarChar);
            p[21].Value = Lead_Contact_Code;
            p[22] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[22].Value = Contact_Source_company;

            p[23] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[23].Value = Contact_Source_Division;
            p[24] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[24].Value = Contact_Source_Center;
            p[25] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[25].Value = Contact_Source_Zone;
            p[26] = new SqlParameter("@contact_role", SqlDbType.NVarChar);
            p[26].Value = Contact_role;
            p[27] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[27].Value = Contact_assignto;
            p[28] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[28].Value = last_modified_by;
            p[29] = new SqlParameter("@createdby", SqlDbType.NVarChar);
            p[29].Value = Created_By;
            p[30] = new SqlParameter("@import_run_no", SqlDbType.NVarChar);
            p[30].Value = Import_Run_No;

            p[31] = new SqlParameter("@stream_code", SqlDbType.NVarChar);
            p[31].Value = Stream_code;
            p[32] = new SqlParameter("@MTStudentNotes", SqlDbType.NVarChar);
            p[32].Value = MTStudentNotes;

            p[33] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[33].Value = Contact_Target_Company;
            p[34] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[34].Value = Contact_Target_Division;
            p[35] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[35].Value = Contact_Target_Zone;
            p[36] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[36].Value = Contact_Target_Center;

            p[37] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[37].Value = Handphone1;
            p[38] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[38].Value = handphone2;
            p[39] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[39].Value = landline;
            p[40] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[40].Value = emailid;
            p[41] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[41].Value = Flatno;
            p[42] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[42].Value = buildingname;
            p[43] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[43].Value = streetname;
            p[44] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[44].Value = Countryname;
            p[45] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[45].Value = State;
            p[46] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[46].Value = City;
            p[47] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[47].Value = pincode;

            p[48] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[48].Value = discipline_id;
            p[49] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[49].Value = Discipline_desc;
            p[50] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[50].Value = Field_Id;
            p[51] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[51].Value = Field_Desc;
            p[52] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[52].Value = Competitive_Exam;

            p[53] = new SqlParameter("@Lead_Type_Desc", SqlDbType.NVarChar);
            p[53].Value = Lead_Type_Desc;

            p[54] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[54].Value = Category_Type_Id;
            p[55] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[55].Value = Category_Type;

            p[56] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[56].Value = InstituteTypeid;
            p[57] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[57].Value = InstituteTypeDesc;
            p[58] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[58].Value = Institute_desc;
            p[59] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[59].Value = Current_Standardid;
            p[60] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[60].Value = Current_StandardDesc;
            p[61] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[61].Value = AdditionalDesc;
            p[62] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[62].Value = Boardid;
            p[63] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[63].Value = Boarddesc;
            p[64] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[64].Value = Sectionid;
            p[65] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[65].Value = Sectiondesc;
            p[66] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[66].Value = Yearofpassingid;
            p[67] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[67].Value = Yearofpassingdesc;
            p[68] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[68].Value = CurrentYearid;
            p[69] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[69].Value = CurrentYeardesc;
            p[70] = new SqlParameter("@Studentid", SqlDbType.NVarChar);
            p[70].Value = Studentid;
            p[71] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[71].Value = LastCourseOpted;
            p[72] = new SqlParameter("@Time_join", SqlDbType.DateTime);
            p[72].Value = Timejoin;

            p[73] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[73].Value = SecContactType;
            p[74] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[74].Value = SecTitle;
            p[75] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[75].Value = Secfname;
            p[76] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[76].Value = SecMname;
            p[77] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[77].Value = SecLname;
            p[78] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[78].Value = Sechphone1;
            p[79] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[79].Value = Sechphone2;
            p[80] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[80].Value = Seclandline;
            p[81] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[81].Value = Secemail;
            p[82] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[82].Value = SecAdd1;
            p[83] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[83].Value = Secadd2;
            p[84] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[84].Value = SecStreetname;
            p[85] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[85].Value = SecCountryname;
            p[86] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[86].Value = SecState;
            p[87] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[87].Value = SecCity;
            p[88] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[88].Value = Secpincode;
            p[89] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[89].Value = SecContactDesc;
            p[90] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[90].Value = Totalmsmarks;
            p[91] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[91].Value = Totalmsmarksobt;
            p[92] = new SqlParameter("@Lead_Source_Desc", SqlDbType.NVarChar);
            p[92].Value = Leadsourcedesc;
            p[93] = new SqlParameter("@DOB", SqlDbType.NVarChar);
            p[93].Value = Dob;
            p[94] = new SqlParameter("@Last_Exam", SqlDbType.NVarChar);
            p[94].Value = Examination;
            p[95] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[95].Value = Location;
            p[96] = new SqlParameter("@gender", SqlDbType.NVarChar);
            p[96].Value = Gender;
            p[97] = new SqlParameter("@C_Year_Education", SqlDbType.Int);
            p[97].Value = C_Year_Education;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Lead_Contact", p);
            return (p[12].Value.ToString());
        }

        public static string InsertSecondaryLeadContact(string PrimaryConId, string Conid, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc, string AdditionalDesc, string Boardid, string Boarddesc,
        string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string SecContactTypeid, string SecContactDesc, string SecTitle, string Secfname,
        string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname,
        string SecState, string SecCity, string Secpincode, string location, string Gender, string Dob)
        {
            SqlParameter[] p = new SqlParameter[37];
            p[0] = new SqlParameter("@primary_con_id", SqlDbType.NVarChar);
            p[0].Value = PrimaryConId;
            p[1] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[1].Value = Conid;
            p[2] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[2].Value = InstituteTypeid;
            p[3] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[3].Value = InstituteTypeDesc;
            p[4] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[4].Value = Institute_desc;
            p[5] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[5].Value = Current_Standardid;
            p[6] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[6].Value = Current_StandardDesc;
            p[7] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[7].Value = AdditionalDesc;
            p[8] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[8].Value = Boardid;
            p[9] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[9].Value = Boarddesc;
            p[10] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[10].Value = Sectionid;
            p[11] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[11].Value = Sectiondesc;
            p[12] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[12].Value = Yearofpassingid;
            p[13] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[13].Value = Yearofpassingdesc;
            p[14] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[14].Value = CurrentYearid;
            p[15] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[15].Value = CurrentYeardesc;
            p[16] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[16].Value = SecContactTypeid;
            p[17] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[17].Value = SecContactDesc;
            p[18] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[18].Value = SecTitle;
            p[19] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[19].Value = Secfname;
            p[20] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[20].Value = SecMname;
            p[21] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[21].Value = SecLname;
            p[22] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[22].Value = Sechphone1;
            p[23] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[23].Value = Sechphone2;
            p[24] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[24].Value = Seclandline;
            p[25] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[25].Value = Secemail;
            p[26] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[26].Value = SecAdd1;
            p[27] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[27].Value = Secadd2;
            p[28] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[28].Value = SecStreetname;
            p[29] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[29].Value = SecCountryname;
            p[30] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[30].Value = SecState;
            p[31] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[31].Value = SecCity;
            p[32] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[32].Value = Secpincode;
            p[33] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[33].Direction = ParameterDirection.Output;
            p[34] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[34].Value = location;
            p[35] = new SqlParameter("@gender", SqlDbType.NVarChar);
            p[35].Value = Gender;
            p[36] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[36].Value = Dob;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Sec_Contact", p);
            return (p[33].Value.ToString());
        }



        public static string UpdateManualLeadContact(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Lead_Code, string Lead_Contact_Code, string Contact_Source_company, string Contact_Source_Division, string Contact_Source_Center, string Contact_Source_Zone, string Contact_assignto, string last_modified_by, string Contact_Target_Company, string Contact_Target_Division,
        string Contact_Target_Zone, string Contact_Target_Center, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, string Category_Type_Id, string Category_Type, string Institution_Type_Id,
        string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc, string Section_Id, string Section_Desc, string Year_of_Passing_ID,
        string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int TotalMSmarks, int TotalMSmarksobt, string Sourcedesc, string dob, string Examination, string Location)
        {
            SqlParameter[] p = new SqlParameter[79];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[9].Direction = ParameterDirection.Output;
            p[10] = new SqlParameter("@Lead_No", SqlDbType.NVarChar);
            p[10].Value = Lead_Code;

            p[11] = new SqlParameter("@Lead_Con_id", SqlDbType.NVarChar);
            p[11].Value = Lead_Contact_Code;
            p[12] = new SqlParameter("@contact_Source_company", SqlDbType.NVarChar);
            p[12].Value = Contact_Source_company;
            p[13] = new SqlParameter("@contact_Source_Division", SqlDbType.NVarChar);
            p[13].Value = Contact_Source_Division;
            p[14] = new SqlParameter("@contact_Source_Center", SqlDbType.NVarChar);
            p[14].Value = Contact_Source_Center;
            p[15] = new SqlParameter("@contact_Source_zone", SqlDbType.NVarChar);
            p[15].Value = Contact_Source_Zone;

            p[16] = new SqlParameter("@contact_assignto", SqlDbType.NVarChar);
            p[16].Value = Contact_assignto;
            p[17] = new SqlParameter("@Last_modified_by", SqlDbType.NVarChar);
            p[17].Value = last_modified_by;


            p[18] = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p[18].Value = Contact_Target_Company;
            p[19] = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p[19].Value = Contact_Target_Division;
            p[20] = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p[20].Value = Contact_Target_Zone;
            p[21] = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p[21].Value = Contact_Target_Center;

            p[22] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[22].Value = Handphone1;
            p[23] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[23].Value = handphone2;
            p[24] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[24].Value = landline;
            p[25] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[25].Value = emailid;
            p[26] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[26].Value = Flatno;
            p[27] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[27].Value = buildingname;
            p[28] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[28].Value = streetname;
            p[29] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[29].Value = Countryname;
            p[30] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[30].Value = State;
            p[31] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[31].Value = City;
            p[32] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[32].Value = pincode;

            p[33] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[33].Value = discipline_id;
            p[34] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[34].Value = Discipline_desc;
            p[35] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[35].Value = Field_Id;
            p[36] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[36].Value = Field_Desc;
            p[37] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[37].Value = Competitive_Exam;

            p[38] = new SqlParameter("@category_TYpe_id", SqlDbType.NVarChar);
            p[38].Value = Category_Type_Id;
            p[39] = new SqlParameter("@category_Type", SqlDbType.NVarChar);
            p[39].Value = Category_Type;
            p[40] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[40].Value = Institution_Type_Id;
            p[41] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[41].Value = Institution_Type_Desc;
            p[42] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[42].Value = Institution_Description;
            p[43] = new SqlParameter("@Current_Standard_Id", SqlDbType.NVarChar);
            p[43].Value = Current_Standard_Id;
            p[44] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[44].Value = Current_Standard_Desc;
            p[45] = new SqlParameter("@Additional_Desc", SqlDbType.NVarChar);
            p[45].Value = Additional_Desc;
            p[46] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[46].Value = Board_Id;
            p[47] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[47].Value = Board_Desc;
            p[48] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[48].Value = Section_Id;
            p[49] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[49].Value = Section_Desc;
            p[50] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.NVarChar);
            p[50].Value = Year_of_Passing_ID;
            p[51] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[51].Value = Year_of_Passing_Desc;
            p[52] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[52].Value = Current_Year_Id;
            p[53] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[53].Value = Current_Year_Desc;
            p[54] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[54].Value = Student_Id;
            p[55] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[55].Value = Last_Course_Opted;

            p[56] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[56].Value = SecContactType;
            p[57] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[57].Value = SecTitle;
            p[58] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[58].Value = Secfname;
            p[59] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[59].Value = SecMname;
            p[60] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[60].Value = SecLname;
            p[61] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[61].Value = Sechphone1;
            p[62] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[62].Value = Sechphone2;
            p[63] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[63].Value = Seclandline;
            p[64] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[64].Value = Secemail;
            p[65] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[65].Value = SecAdd1;
            p[66] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[66].Value = Secadd2;
            p[67] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[67].Value = SecStreetname;
            p[68] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[68].Value = SecCountryname;
            p[69] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[69].Value = SecState;
            p[70] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[70].Value = SecCity;
            p[71] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[71].Value = Secpincode;
            p[72] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[72].Value = SecContactDesc;
            p[73] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[73].Value = TotalMSmarks;
            p[74] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[74].Value = TotalMSmarksobt;
            p[75] = new SqlParameter("@lead_Source_desc", SqlDbType.NVarChar);
            p[75].Value = Sourcedesc;
            p[76] = new SqlParameter("@dob", SqlDbType.NVarChar);
            p[76].Value = dob;
            p[77] = new SqlParameter("@last_exam", SqlDbType.NVarChar);
            p[77].Value = Examination;
            p[78] = new SqlParameter("@location", SqlDbType.NVarChar);
            p[78].Value = Location;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Lead_Contact", p);
            return (p[9].Value.ToString());
        }

        public static DataSet Get_center_target_analysis(string flag, string UserID, string source, string category, string company, string division, string zone, string center, string year, string product,
        string fromdate, string todate, string yeareducation)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p1.Value = UserID;
            SqlParameter p2 = new SqlParameter("@source", SqlDbType.NVarChar);
            p2.Value = source;
            SqlParameter p3 = new SqlParameter("@category", SqlDbType.NVarChar);
            p3.Value = category;
            SqlParameter p4 = new SqlParameter("@company", SqlDbType.NVarChar);
            p4.Value = company;
            SqlParameter p5 = new SqlParameter("@division", SqlDbType.NVarChar);
            p5.Value = division;
            SqlParameter p6 = new SqlParameter("@zone", SqlDbType.NVarChar);
            p6.Value = zone;
            SqlParameter p7 = new SqlParameter("@center", SqlDbType.NVarChar);
            p7.Value = center;
            SqlParameter p8 = new SqlParameter("@year", SqlDbType.NVarChar);
            p8.Value = year;
            SqlParameter p9 = new SqlParameter("@product", SqlDbType.NVarChar);
            p9.Value = product;
            SqlParameter p10 = new SqlParameter("@fromdate", SqlDbType.NVarChar);
            p10.Value = fromdate;
            SqlParameter p11 = new SqlParameter("@todate", SqlDbType.NVarChar);
            p11.Value = todate;
            SqlParameter p12 = new SqlParameter("@yeareducation", SqlDbType.NVarChar);
            p12.Value = yeareducation;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Analysis_Source_Target_Center", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12));
        }
        public static DataSet ShowImportData(string flag, string Acadyear, string yeareducation, string userid, string LeadSource, string Leadstatus, string createdfrom, string createdto, string response)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@year1", SqlDbType.NVarChar);
            p1.Value = Acadyear;
            SqlParameter p2 = new SqlParameter("@yr_education", SqlDbType.NVarChar);
            p2.Value = yeareducation;
            SqlParameter p3 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p3.Value = userid;
            SqlParameter p4 = new SqlParameter("@source", SqlDbType.NVarChar);
            p4.Value = LeadSource;
            SqlParameter p5 = new SqlParameter("@status", SqlDbType.NVarChar);
            p5.Value = Leadstatus;
            SqlParameter p6 = new SqlParameter("@from", SqlDbType.NVarChar);
            p6.Value = createdfrom;
            SqlParameter p7 = new SqlParameter("@to", SqlDbType.NVarChar);
            p7.Value = createdto;
            SqlParameter p8 = new SqlParameter("@responseid", SqlDbType.NVarChar);
            p8.Value = response;


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p, p1, p2, p3, p4, p5, p6,
            p7, p8));
        }
        public static string ImportData(string flag, string Acadyear, string yeareducation, string userid, string LeadSource, string Leadstatus, string createdfrom, string createdto, string response)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@flag", SqlDbType.NVarChar);
            p[0].Value = flag;
            p[1] = new SqlParameter("@year1", SqlDbType.NVarChar);
            p[1].Value = Acadyear;
            p[2] = new SqlParameter("@yr_education", SqlDbType.NVarChar);
            p[2].Value = yeareducation;
            p[3] = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p[3].Value = userid;
            p[4] = new SqlParameter("@source", SqlDbType.NVarChar);
            p[4].Value = LeadSource;
            p[5] = new SqlParameter("@status", SqlDbType.NVarChar);
            p[5].Value = Leadstatus;
            p[6] = new SqlParameter("@from", SqlDbType.NVarChar);
            p[6].Value = createdfrom;
            p[7] = new SqlParameter("@to", SqlDbType.NVarChar);
            p[7].Value = createdto;
            p[8] = new SqlParameter("@responseid", SqlDbType.NVarChar, 10);
            p[8].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p);
            return (p[8].Value.ToString());
            //Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Import_LeadContacts", p, p1, p2, p3, p4, p5, p6, p7, p8))
        }

        public static DataSet Get_Score_analysis(string flag, string UserID, string source, string category, string company, string division, string zone, string center, string year, string product,
        string fromdate, string todate, string scoref1, string scoret1, string scoref2, string scoret2, string scoref3, string scoret3, string scoref4, string scoret4)
        {

            SqlParameter p = new SqlParameter("@flag", SqlDbType.NVarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@UserID", SqlDbType.NVarChar);
            p1.Value = UserID;
            SqlParameter p2 = new SqlParameter("@source", SqlDbType.NVarChar);
            p2.Value = source;
            SqlParameter p3 = new SqlParameter("@category", SqlDbType.NVarChar);
            p3.Value = category;
            SqlParameter p4 = new SqlParameter("@company", SqlDbType.NVarChar);
            p4.Value = company;
            SqlParameter p5 = new SqlParameter("@division", SqlDbType.NVarChar);
            p5.Value = division;
            SqlParameter p6 = new SqlParameter("@zone", SqlDbType.NVarChar);
            p6.Value = zone;
            SqlParameter p7 = new SqlParameter("@center", SqlDbType.NVarChar);
            p7.Value = center;
            SqlParameter p8 = new SqlParameter("@year", SqlDbType.NVarChar);
            p8.Value = year;
            SqlParameter p9 = new SqlParameter("@product", SqlDbType.NVarChar);
            p9.Value = product;
            SqlParameter p10 = new SqlParameter("@fromdate", SqlDbType.NVarChar);
            p10.Value = fromdate;
            SqlParameter p11 = new SqlParameter("@todate", SqlDbType.NVarChar);
            p11.Value = todate;
            SqlParameter p12 = new SqlParameter("@scoref1", SqlDbType.NVarChar);
            p12.Value = scoref1;
            SqlParameter p13 = new SqlParameter("@scoret1", SqlDbType.NVarChar);
            p13.Value = scoret1;
            SqlParameter p14 = new SqlParameter("@scoref2", SqlDbType.NVarChar);
            p14.Value = scoref2;
            SqlParameter p15 = new SqlParameter("@scoret2", SqlDbType.NVarChar);
            p15.Value = scoret2;
            SqlParameter p16 = new SqlParameter("@scoref3", SqlDbType.NVarChar);
            p16.Value = scoref3;
            SqlParameter p17 = new SqlParameter("@scoret3", SqlDbType.NVarChar);
            p17.Value = scoret3;
            SqlParameter p18 = new SqlParameter("@scoref4", SqlDbType.NVarChar);
            p18.Value = scoref4;
            SqlParameter p19 = new SqlParameter("@scoret4", SqlDbType.NVarChar);
            p19.Value = scoret4;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Score_Analysis", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19));
        }
        public static DataSet Get_Lead_Contact_Search_Results(string leadtypeid, string leadstatusid, string leadsourceid, string Userid, string Contact_Company, string Contact_Source_Division, string Contact_Source_Zone, string Contact_Source_Center, string Contact_Target_Division, string Contact_Target_Zone,
        string Contact_Target_Center, string Studentname, string Leadcreatedonfrom, string Leadcreatedonto, string Country, string State, string City, string Customertype, string Institutiontype, string Board,
        string Standard, string Year, string Courseinterested, string Followupfrom, string Followupto, int Overdue, string agefrom, string ageto, string Blocked, string Examinationdetails,
        string Scoretype, string Conditiontype, string Score, string Gender, string acadyear, string yeareducation)
        {
            SqlParameter p = new SqlParameter("@Leadtypeid", SqlDbType.NVarChar);
            p.Value = leadtypeid;
            SqlParameter p1 = new SqlParameter("@leadsourceid", SqlDbType.NVarChar);
            p1.Value = leadsourceid;
            SqlParameter p2 = new SqlParameter("@leadstatusid", SqlDbType.NVarChar);
            p2.Value = leadstatusid;
            SqlParameter p3 = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p3.Value = Userid;
            SqlParameter p4 = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p4.Value = Contact_Company;
            SqlParameter p5 = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p5.Value = Contact_Source_Division;
            SqlParameter p6 = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p6.Value = Contact_Source_Zone;
            SqlParameter p7 = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p7.Value = Contact_Source_Center;
            SqlParameter p8 = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p8.Value = Contact_Target_Division;
            SqlParameter p9 = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p9.Value = Contact_Target_Zone;
            SqlParameter p10 = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p10.Value = Contact_Target_Center;
            SqlParameter p11 = new SqlParameter("@Studentname", SqlDbType.NVarChar);
            p11.Value = Studentname;

            SqlParameter p12 = new SqlParameter("@leadcreatedon_from", SqlDbType.NVarChar);
            p12.Value = Leadcreatedonfrom;
            SqlParameter p13 = new SqlParameter("@leadcreatedon_to", SqlDbType.NVarChar);
            p13.Value = Leadcreatedonto;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@customertype", SqlDbType.NVarChar);
            p17.Value = Customertype;
            SqlParameter p18 = new SqlParameter("@institutiontype", SqlDbType.NVarChar);
            p18.Value = Institutiontype;
            SqlParameter p19 = new SqlParameter("@board", SqlDbType.NVarChar);
            p19.Value = Board;
            SqlParameter p20 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p20.Value = Standard;
            SqlParameter p21 = new SqlParameter("@year", SqlDbType.NVarChar);
            p21.Value = Year;

            SqlParameter p22 = new SqlParameter("@course_interest", SqlDbType.NVarChar);
            p22.Value = Courseinterested;
            SqlParameter p23 = new SqlParameter("@followup_from", SqlDbType.NVarChar);
            p23.Value = Followupfrom;
            SqlParameter p24 = new SqlParameter("@followup_to", SqlDbType.NVarChar);
            p24.Value = Followupto;
            SqlParameter p25 = new SqlParameter("@overdue", SqlDbType.Int);
            p25.Value = Overdue;

            SqlParameter p26 = new SqlParameter("@agefrom", SqlDbType.NVarChar);
            p26.Value = agefrom;
            SqlParameter p27 = new SqlParameter("@ageto", SqlDbType.NVarChar);
            p27.Value = ageto;
            SqlParameter p28 = new SqlParameter("@blocked", SqlDbType.NVarChar);
            p28.Value = Blocked;
            SqlParameter p29 = new SqlParameter("@xam_details", SqlDbType.NVarChar);
            p29.Value = Examinationdetails;

            SqlParameter p30 = new SqlParameter("@scoretype", SqlDbType.NVarChar);
            p30.Value = Scoretype;
            SqlParameter p31 = new SqlParameter("@condition", SqlDbType.NVarChar);
            p31.Value = Conditiontype;
            SqlParameter p32 = new SqlParameter("@score", SqlDbType.NVarChar);
            p32.Value = Score;
            SqlParameter p33 = new SqlParameter("@gender", SqlDbType.NVarChar);
            p33.Value = Gender;
            SqlParameter p34 = new SqlParameter("@acadyear", SqlDbType.NVarChar);
            p34.Value = acadyear;
            SqlParameter p35 = new SqlParameter("@yeareducation", SqlDbType.NVarChar);
            p35.Value = yeareducation;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19, p20, p21, p22, p23, p24, p25, p26,
            p27, p28, p29, p30, p31, p32, p33, p34, p35));
        }

        //Public Shared Function Get_Opportunity_Search_Results(ByVal Productcategory As String, ByVal Salesstage As String, _
        //                                                       ByVal OpporStatus As String, ByVal Userid As String, ByVal isadmin As String, _
        //                                                       ByVal Contact_Company As String, _
        //                                                       ByVal Contact_Division As String, ByVal Contact_Zone As String, _
        //                                                       ByVal Contact_Center As String, ByVal Studentname As String) As DataSet
        //    Dim p As New SqlParameter("@Productcategory", SqlDbType.NVarChar)
        //    p.Value = Productcategory
        //    Dim p1 As New SqlParameter("@Salesstage", SqlDbType.NVarChar)
        //    p1.Value = Salesstage
        //    Dim p2 As New SqlParameter("@OpporStatus", SqlDbType.NVarChar)
        //    p2.Value = OpporStatus
        //    Dim p3 As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p3.Value = Userid
        //    Dim p4 As New SqlParameter("@is_admin", SqlDbType.NVarChar)
        //    p4.Value = isadmin

        //    Dim p5 As New SqlParameter("@Contact_Company", SqlDbType.NVarChar)
        //    p5.Value = Contact_Company
        //    Dim p6 As New SqlParameter("@Contact_Division", SqlDbType.NVarChar)
        //    p6.Value = Contact_Division
        //    Dim p7 As New SqlParameter("@Contact_Zone", SqlDbType.NVarChar)
        //    p7.Value = Contact_Zone
        //    Dim p8 As New SqlParameter("@Contact_Center", SqlDbType.NVarChar)
        //    p8.Value = Contact_Center
        //    Dim p9 As New SqlParameter("@Studentname", SqlDbType.NVarChar)
        //    p9.Value = Studentname
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Opportunity_Search_Results", p, p1, p2, p3, p4, p5, p6, p7, p8, p9))
        //End Function

        //Public Shared Function Get_Opportunity_Search_Results(ByVal Productcategory As String, ByVal Salesstage As String, _
        //                                                       ByVal OpporStatus As String, ByVal Userid As String, _
        //                                                       ByVal Contact_Company As String, _
        //                                                       ByVal Contact_Division As String, ByVal Contact_Zone As String, _
        //                                                       ByVal Contact_Center As String, ByVal Studentname As String) As DataSet
        //    Dim p As New SqlParameter("@Productcategory", SqlDbType.NVarChar)
        //    p.Value = Productcategory
        //    Dim p1 As New SqlParameter("@Salesstage", SqlDbType.NVarChar)
        //    p1.Value = Salesstage
        //    Dim p2 As New SqlParameter("@OpporStatus", SqlDbType.NVarChar)
        //    p2.Value = OpporStatus
        //    Dim p3 As New SqlParameter("@Userid", SqlDbType.NVarChar)
        //    p3.Value = Userid
        //    Dim p4 As New SqlParameter("@Contact_Company", SqlDbType.NVarChar)
        //    p4.Value = Contact_Company
        //    Dim p5 As New SqlParameter("@Contact_Division", SqlDbType.NVarChar)
        //    p5.Value = Contact_Division
        //    Dim p6 As New SqlParameter("@Contact_Zone", SqlDbType.NVarChar)
        //    p6.Value = Contact_Zone
        //    Dim p7 As New SqlParameter("@Contact_Center", SqlDbType.NVarChar)
        //    p7.Value = Contact_Center
        //    Dim p8 As New SqlParameter("@Studentname", SqlDbType.NVarChar)
        //    p8.Value = Studentname
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Opportunity_Search_Results", p, p1, p2, p3, p4, p5, p6, p7, p8))
        //End Function



        public static DataSet Get_Contact_Search_Results(string leadtypeid, string leadstatusid, string leadsourceid, string Userid, string Contact_Company, string Contact_Source_Division, string Contact_Source_Zone, string Contact_Source_Center, string Contact_Target_Division, string Contact_Target_Zone,
        string Contact_Target_Center, string Studentname)
        {
            SqlParameter p = new SqlParameter("@Leadtypeid", SqlDbType.NVarChar);
            p.Value = leadtypeid;
            SqlParameter p1 = new SqlParameter("@leadsourceid", SqlDbType.NVarChar);
            p1.Value = leadsourceid;
            SqlParameter p2 = new SqlParameter("@leadstatusid", SqlDbType.NVarChar);
            p2.Value = leadstatusid;
            SqlParameter p3 = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p3.Value = Userid;
            SqlParameter p4 = new SqlParameter("@Contact_Target_Company", SqlDbType.NVarChar);
            p4.Value = Contact_Company;
            SqlParameter p5 = new SqlParameter("@Contact_Source_Division", SqlDbType.NVarChar);
            p5.Value = Contact_Source_Division;
            SqlParameter p6 = new SqlParameter("@Contact_Source_Zone", SqlDbType.NVarChar);
            p6.Value = Contact_Source_Zone;
            SqlParameter p7 = new SqlParameter("@Contact_Source_Center", SqlDbType.NVarChar);
            p7.Value = Contact_Source_Center;
            SqlParameter p8 = new SqlParameter("@Contact_Target_Division", SqlDbType.NVarChar);
            p8.Value = Contact_Target_Division;
            SqlParameter p9 = new SqlParameter("@Contact_Target_Zone", SqlDbType.NVarChar);
            p9.Value = Contact_Target_Zone;
            SqlParameter p10 = new SqlParameter("@Contact_Target_Center", SqlDbType.NVarChar);
            p10.Value = Contact_Target_Center;
            SqlParameter p11 = new SqlParameter("@Studentname", SqlDbType.NVarChar);
            p11.Value = Studentname;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11));
        }



        //Public Shared Function Getleaddetailsbyleadid(ByVal leadid As String) As DataSet
        //    Dim p As New SqlParameter("@Leadtypeid", SqlDbType.NVarChar)
        //    p.Value = leadid
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Lead_Contact_Search_Results", p, p1, p2))
        //End Function

        public static SqlDataReader Getleaddetailsbyleadid(string leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@leadid", SqlDbType.NVarChar);
            p[0].Value = leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_LeadContactdetailsbyleadid", p));
        }

        public static SqlDataReader GetProbabiltyPercent(string SalesStageid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@SalesStageid", SqlDbType.NVarChar);
            p[0].Value = SalesStageid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetProbabilityPercentbySalesStageid", p));
        }

        public static SqlDataReader Getreceiptdetailsbyreceiptid(string Receiptid, int Flag)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@receiptcode", SqlDbType.NVarChar);
            p[0].Value = Receiptid;
            p[1] = new SqlParameter("@flag", SqlDbType.Int);
            p[1].Value = Flag;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_EditAllocate_Cheques", p));
        }

        public static SqlDataReader GetOppordetailsbyOpporid(string leadid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Opporid", SqlDbType.NVarChar);
            p[0].Value = leadid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_OpporContactdetailsbyOpporid", p));
        }


        public static string InsertFeedback(string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string NextFollowupdate)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@Lead_id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[11].Value = NextFollowupdate;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedback", p);
            return (p[8].Value.ToString());
        }

        public static string InsertFeedbackOpportunity(string Feedbackid, string Taskid, string Leadid, string Interacted_With, string Interacted_Relation, string Interacted_On, string Feedback, string Feedback_Status, string Updatedby, string SeminarStatus,
        string Oppor_Sales_Stage, string Oppor_Sales_Stage_id, string NextFollowupdate, string Appno)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@feedbackid", SqlDbType.NVarChar);
            p[0].Value = Feedbackid;
            p[1] = new SqlParameter("@task_id", SqlDbType.NVarChar);
            p[1].Value = Taskid;
            p[2] = new SqlParameter("@lead_Id", SqlDbType.NVarChar);
            p[2].Value = Leadid;
            p[3] = new SqlParameter("@Interactedwith", SqlDbType.NVarChar);
            p[3].Value = Interacted_With;
            p[4] = new SqlParameter("@InteractedRelation", SqlDbType.NVarChar);
            p[4].Value = Interacted_Relation;
            p[5] = new SqlParameter("@Interacted_On", SqlDbType.NVarChar);
            p[5].Value = Interacted_On;
            p[6] = new SqlParameter("@feedback", SqlDbType.NVarChar);
            p[6].Value = Feedback;
            p[7] = new SqlParameter("@Feedback_Status", SqlDbType.NVarChar);
            p[7].Value = Feedback_Status;
            p[8] = new SqlParameter("@feedback_Out", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            p[9] = new SqlParameter("@Updated_By", SqlDbType.NVarChar);
            p[9].Value = Updatedby;
            p[10] = new SqlParameter("@SeminarStatus", SqlDbType.NVarChar);
            p[10].Value = SeminarStatus;
            p[11] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[11].Value = Oppor_Sales_Stage;
            p[12] = new SqlParameter("@Sales_Stage_id", SqlDbType.NVarChar);
            p[12].Value = Oppor_Sales_Stage_id;
            p[13] = new SqlParameter("@NextFollowupDate", SqlDbType.NVarChar);
            p[13].Value = NextFollowupdate;
            p[14] = new SqlParameter("@AppNo", SqlDbType.NVarChar, 10);
            p[14].Value = Appno;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertLeadfeedbackOpportunity", p);
            return (p[8].Value.ToString());
        }

        public static string InsertOpportunity(string Opportunity_id, string Opp_TYpe_Id, string Opp_Name, string Leadid, string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent,
        string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_AssignTo, string Created_By,
        string last_Modified_By, string Opp_Status, string Opp_Status_id, string Oppor_product, string Oppor_Product_id, string Acad_Year, string App_no, string SalesChannel_Id, string SalesChannel, string Disc_remark)
        {
            SqlParameter[] p = new SqlParameter[31];
            p[0] = new SqlParameter("@Oppur_Id", SqlDbType.NVarChar);
            p[0].Value = Opportunity_id;
            p[1] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[1].Value = Opp_TYpe_Id;
            p[2] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[2].Value = Opp_Name;
            p[3] = new SqlParameter("@Lead_Id", SqlDbType.NVarChar);
            p[3].Value = Leadid;
            p[4] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[4].Value = Product_Category;
            p[5] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[5].Value = Product_Code;
            p[6] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[6].Value = Sales_Stage;
            p[7] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[7].Value = Opp_Join_Date;

            p[8] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[8].Value = Opp_Expected_Close_Date;
            p[9] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[9].Value = Opp_Probability_Percent;
            p[10] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[10].Value = Opp_Next_Step;
            p[11] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[11].Value = Opp_Value;
            p[12] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[12].Value = Opp_Disc;

            p[13] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[13].Value = Opp_Contact_Company;
            p[14] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[14].Value = Opp_Contact_Division;
            p[15] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[15].Value = Opp_Contact_Center;
            p[16] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[16].Value = Opp_Contact_Zone;

            p[17] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[17].Value = Opp_Contact_Role;
            p[18] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[18].Value = Opp_Contact_AssignTo;
            p[19] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[19].Value = Created_By;
            p[20] = new SqlParameter("@last_Modified_By", SqlDbType.NVarChar);
            p[20].Value = last_Modified_By;

            p[21] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[21].Value = Opp_Status;
            p[22] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[22].Value = Opp_Status_id;

            p[23] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[23].Value = Oppor_product;
            p[24] = new SqlParameter("@Oppor_Product_Id", SqlDbType.VarChar, 50);
            p[24].Value = Oppor_Product_id;

            p[25] = new SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100);
            p[25].Direction = ParameterDirection.Output;

            p[26] = new SqlParameter("@Acad_year", SqlDbType.NVarChar);
            p[26].Value = Acad_Year;
            p[27] = new SqlParameter("@App_no", SqlDbType.NVarChar);
            p[27].Value = App_no;

            p[28] = new SqlParameter("@SalesStage_Id", SqlDbType.NVarChar);
            p[28].Value = SalesChannel_Id;
            p[29] = new SqlParameter("@SalesStage_Desc", SqlDbType.NVarChar);
            p[29].Value = SalesChannel;

            p[30] = new SqlParameter("@Disc_Remark", SqlDbType.NVarChar);
            p[30].Value = Disc_remark;


            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertOpportunity", p);
            return (p[25].Value.ToString());
        }
        public static string UpdateOpportunityContact(string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank, int Overallrank, string Scorerange, string Handphone1,
        string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname, string State, string City, string pincode,
        string Category_Type_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc,
        string Section_Id, string Section_Desc, string Year_of_Passing_ID, string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id, string Last_Course_Opted, string Opp_Type_ID, string Opp_Name,
        string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date, string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, decimal Opp_Disc, string Opp_Contact_Company,
        string Opp_ContactSource_Division, string Opp_ContactSource_Center, string Opp_ContactSource_Zone, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_Assignto, string Last_Modified_By, string Opp_Status,
        string Opp_Status_Id, string Oppor_Product, string Oppor_Product_Id, string oppid, string appno, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname,
        string Sechphone1, string Sechphone2, string Seclandline, string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity,
        string Secpincode, string SecContactDesc, int discipline_id, string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_target_Company,
        string dob, string last_exam, string location, string gender, string discountnotes)
        {
            SqlParameter[] p = new SqlParameter[96];
            p[0] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[0].Value = CON_TITLE;
            p[1] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[1].Value = CON_FIRSTNAME;
            p[2] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[2].Value = CON_MNAME;
            p[3] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[3].Value = CON_LNAME;
            p[4] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[4].Value = Score;
            p[5] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[5].Value = percentile;
            p[6] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[6].Value = Area_rank;
            p[7] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[7].Value = Overallrank;
            p[8] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[8].Value = Scorerange;
            p[9] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[9].Value = Handphone1;
            p[10] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[10].Value = handphone2;
            p[11] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[11].Value = landline;
            p[12] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[12].Value = emailid;
            p[13] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[13].Value = Flatno;
            p[14] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[14].Value = buildingname;
            p[15] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[15].Value = streetname;
            p[16] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[16].Value = Countryname;
            p[17] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[17].Value = State;
            p[18] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[18].Value = City;
            p[19] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[19].Value = pincode;
            p[20] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[20].Value = Category_Type_Id;
            p[21] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[21].Value = Category_Type;

            p[22] = new SqlParameter("@Institution_Type_Id", SqlDbType.NVarChar);
            p[22].Value = Institution_Type_Id;
            p[23] = new SqlParameter("@Institution_Type_Desc", SqlDbType.NVarChar);
            p[23].Value = Institution_Type_Desc;
            p[24] = new SqlParameter("@Institution_Description", SqlDbType.NVarChar);
            p[24].Value = Institution_Description;
            p[25] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[25].Value = Current_Standard_Id;
            p[26] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[26].Value = Current_Standard_Desc;
            p[27] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[27].Value = Additional_Desc;
            p[28] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p[28].Value = Board_Id;
            p[29] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[29].Value = Board_Desc;
            p[30] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[30].Value = Section_Id;
            p[31] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[31].Value = Section_Desc;
            p[32] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[32].Value = Year_of_Passing_ID;
            p[33] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[33].Value = Year_of_Passing_Desc;
            p[34] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[34].Value = Current_Year_Id;
            p[35] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[35].Value = Current_Year_Desc;
            p[36] = new SqlParameter("@Student_Id", SqlDbType.NVarChar);
            p[36].Value = Student_Id;
            p[37] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[37].Value = Last_Course_Opted;

            p[38] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[38].Value = Opp_Type_ID;
            p[39] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[39].Value = Opp_Name;

            p[40] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[40].Value = Product_Category;
            p[41] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[41].Value = Product_Code;
            p[42] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[42].Value = Sales_Stage;
            p[43] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[43].Value = Opp_Join_Date;

            p[44] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[44].Value = Opp_Expected_Close_Date;
            p[45] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[45].Value = Opp_Probability_Percent;
            p[46] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[46].Value = Opp_Next_Step;
            p[47] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[47].Value = Opp_Value;
            p[48] = new SqlParameter("@Opp_Disc", SqlDbType.Decimal);
            p[48].Value = Opp_Disc;

            p[49] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[49].Value = Opp_Contact_Company;
            p[50] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
            p[50].Value = Opp_ContactSource_Division;
            p[51] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
            p[51].Value = Opp_ContactSource_Center;
            p[52] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
            p[52].Value = Opp_ContactSource_Zone;

            p[53] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[53].Value = Opp_Contact_Division;
            p[54] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[54].Value = Opp_Contact_Center;
            p[55] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[55].Value = Opp_Contact_Zone;

            p[56] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[56].Value = Opp_Contact_Role;
            p[57] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[57].Value = Opp_Contact_Assignto;

            p[58] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[58].Value = Last_Modified_By;
            p[59] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[59].Value = Opp_Status;
            p[60] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[60].Value = Opp_Status_Id;
            p[61] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[61].Value = Oppor_Product;
            p[62] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
            p[62].Value = Oppor_Product_Id;
            p[63] = new SqlParameter("@oppid", SqlDbType.NVarChar);
            p[63].Value = oppid;
            p[64] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.NVarChar, 100);
            p[64].Direction = ParameterDirection.Output;
            p[65] = new SqlParameter("@appno", SqlDbType.NVarChar);
            p[65].Value = appno;

            p[66] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[66].Value = SecContactType;
            p[67] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[67].Value = SecTitle;
            p[68] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[68].Value = Secfname;
            p[69] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[69].Value = SecMname;
            p[70] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[70].Value = SecLname;
            p[71] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[71].Value = Sechphone1;
            p[72] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[72].Value = Sechphone2;
            p[73] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[73].Value = Seclandline;
            p[74] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[74].Value = Secemail;
            p[75] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[75].Value = SecAdd1;
            p[76] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[76].Value = Secadd2;
            p[77] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[77].Value = SecStreetname;
            p[78] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[78].Value = SecCountryname;
            p[79] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[79].Value = SecState;
            p[80] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[80].Value = SecCity;
            p[81] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[81].Value = Secpincode;
            p[82] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[82].Value = SecContactDesc;
            p[83] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[83].Value = discipline_id;
            p[84] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[84].Value = Discipline_desc;
            p[85] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[85].Value = Field_Id;
            p[86] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[86].Value = Field_Desc;
            p[87] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[87].Value = Competitive_Exam;
            p[88] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
            p[88].Value = Totalmsmarks;
            p[89] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
            p[89].Value = Totalmsmarksobt;
            p[90] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
            p[90].Value = Opp_Contact_target_Company;

            p[91] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[91].Value = dob;
            p[92] = new SqlParameter("@xam_details", SqlDbType.VarChar);
            p[92].Value = last_exam;
            p[93] = new SqlParameter("@location", SqlDbType.VarChar);
            p[93].Value = location;
            p[94] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[94].Value = gender;
            p[95] = new SqlParameter("@discnotes", SqlDbType.VarChar);
            p[95].Value = discountnotes;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Opp_Contact", p);
            return (p[64].Value.ToString());
        }
        public static SqlDataReader GetOppdetailsbyoppid(string oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_OppurtunityContactdetails_byOppid", p));
        }
        //USP_Add_Opportunity

        //Public Shared Function InsertAddOpportunity(
        //                                                 ByVal CON_ID As String, ByVal CON_TYPE_ID As String, _
        //                                        ByVal CON_TYPE_DESC As String, ByVal CON_TITLE As String, ByVal CON_FIRSTNAME As String, _
        //                                        ByVal CON_MNAME As String, ByVal CON_LNAME As String, _
        //                                        ByVal Score As Integer, ByVal percentile As Integer, _
        //                                        ByVal Area_rank As Integer, ByVal Overallrank As Integer, _
        //                                        ByVal Scorerange As String, ByVal Handphone1 As String, ByVal handphone2 As String, _
        //                                        ByVal landline As String, ByVal emailid As String, ByVal Flatno As String, ByVal buildingname As String, _
        //                                        ByVal streetname As String, ByVal Countryname As String, ByVal State As String, ByVal City As String, _
        //                                        ByVal pincode As String, _
        //                                        ByVal Category_Type_Id As String, ByVal Category_Type As String, _
        //                                        ByVal InstituteTypeid As String, ByVal InstituteTypeDesc As String, ByVal Institute_desc As String, _
        //                                        ByVal Current_Standardid As String, ByVal Current_StandardDesc As String, ByVal AdditionalDesc As String, _
        //                                        ByVal Boardid As String, ByVal Boarddesc As String, ByVal Sectionid As String, ByVal Sectiondesc As String, _
        //                                        ByVal Yearofpassingid As String, ByVal Yearofpassingdesc As String, ByVal CurrentYearid As String, _
        //                                        ByVal CurrentYeardesc As String, ByVal Studentid As String, ByVal LastCourseOpted As String, _
        //                                        ByVal Opportunity_id As String, ByVal Opp_TYpe_Id As String, ByVal Opp_Name As String, ByVal Leadid As String, _
        //                                        ByVal Product_Category As String, ByVal Product_Code As String, ByVal Sales_Stage As String, _
        //                                        ByVal Opp_Join_Date As Date, ByVal Opp_Expected_Close_Date As Date, ByVal Opp_Probability_Percent As String, _
        //                                        ByVal Opp_Next_Step As String, ByVal Opp_Value As Decimal, ByVal Opp_Disc As Decimal, ByVal Opp_Contact_Company As String, _
        //                                        ByVal Opp_Contact_Division As String, ByVal Opp_Contact_Center As String, ByVal Opp_Contact_Zone As String, ByVal Opp_Contact_Role As String, _
        //                                        ByVal Opp_Contact_AssignTo As String, ByVal Created_By As String, ByVal last_Modified_By As String, ByVal Opp_Status As String, ByVal Opp_Status_id As String,
        //                                        ByVal Oppor_product As String, ByVal Oppor_Product_id As String) As String
        //    Dim p As SqlParameter() = New SqlParameter(66) {}
        //    p(0) = New SqlParameter("@CON_ID", SqlDbType.NVarChar)
        //    p(0).Value = CON_ID
        //    p(1) = New SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar)
        //    p(1).Value = CON_TYPE_ID
        //    p(2) = New SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar)
        //    p(2).Value = CON_TYPE_DESC
        //    p(3) = New SqlParameter("@CON_TITLE", SqlDbType.NVarChar)
        //    p(3).Value = CON_TITLE
        //    p(4) = New SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar)
        //    p(4).Value = CON_FIRSTNAME
        //    p(5) = New SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar)
        //    p(5).Value = CON_MNAME
        //    p(6) = New SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar)
        //    p(6).Value = CON_LNAME
        //    p(7) = New SqlParameter("@Score", SqlDbType.NVarChar)
        //    p(7).Value = Score
        //    p(8) = New SqlParameter("@Percentile", SqlDbType.NVarChar)
        //    p(8).Value = percentile
        //    p(9) = New SqlParameter("@Area_rank", SqlDbType.NVarChar)
        //    p(9).Value = Area_rank
        //    p(10) = New SqlParameter("@OverallRank", SqlDbType.NVarChar)
        //    p(10).Value = Overallrank
        //    p(11) = New SqlParameter("@score_Range_Type", SqlDbType.NVarChar)
        //    p(11).Value = Scorerange
        //    p(12) = New SqlParameter("@Handphone1", SqlDbType.NVarChar)
        //    p(12).Value = Handphone1
        //    p(13) = New SqlParameter("@Handphone2", SqlDbType.NVarChar)
        //    p(13).Value = handphone2
        //    p(14) = New SqlParameter("@Landline", SqlDbType.NVarChar)
        //    p(14).Value = landline
        //    p(15) = New SqlParameter("@emailid", SqlDbType.NVarChar)
        //    p(15).Value = emailid
        //    p(16) = New SqlParameter("@Flatno", SqlDbType.NVarChar)
        //    p(16).Value = Flatno
        //    p(17) = New SqlParameter("@buildingname", SqlDbType.NVarChar)
        //    p(17).Value = buildingname
        //    p(18) = New SqlParameter("@streetname", SqlDbType.NVarChar)
        //    p(18).Value = streetname
        //    p(19) = New SqlParameter("@Country", SqlDbType.NVarChar)
        //    p(19).Value = Countryname
        //    p(20) = New SqlParameter("@State", SqlDbType.NVarChar)
        //    p(20).Value = State
        //    p(21) = New SqlParameter("@City", SqlDbType.NVarChar)
        //    p(21).Value = City
        //    p(22) = New SqlParameter("@pincode", SqlDbType.NVarChar)
        //    p(22).Value = pincode
        //    p(23) = New SqlParameter("@Category_Type_Id", SqlDbType.NVarChar)
        //    p(23).Value = Category_Type_Id
        //    p(24) = New SqlParameter("@Category_Type", SqlDbType.NVarChar)
        //    p(24).Value = Category_Type

        //    p(25) = New SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar)
        //    p(25).Value = InstituteTypeid
        //    p(26) = New SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar)
        //    p(26).Value = InstituteTypeDesc
        //    p(27) = New SqlParameter("@Institution_Desc", SqlDbType.NVarChar)
        //    p(27).Value = Institute_desc
        //    p(28) = New SqlParameter("@Current_Standard_id", SqlDbType.NVarChar)
        //    p(28).Value = Current_Standardid
        //    p(29) = New SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar)
        //    p(29).Value = Current_StandardDesc
        //    p(30) = New SqlParameter("@Additional_desc", SqlDbType.NVarChar)
        //    p(30).Value = AdditionalDesc
        //    p(31) = New SqlParameter("@Board_Id", SqlDbType.NVarChar)
        //    p(31).Value = Boardid
        //    p(32) = New SqlParameter("@Board_Desc", SqlDbType.NVarChar)
        //    p(32).Value = Boarddesc
        //    p(33) = New SqlParameter("@Section_Id", SqlDbType.NVarChar)
        //    p(33).Value = Sectionid
        //    p(34) = New SqlParameter("@Section_Desc", SqlDbType.NVarChar)
        //    p(34).Value = Sectiondesc
        //    p(35) = New SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar)
        //    p(35).Value = Yearofpassingid
        //    p(36) = New SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar)
        //    p(36).Value = Yearofpassingdesc
        //    p(37) = New SqlParameter("@Current_Year_Id", SqlDbType.NVarChar)
        //    p(37).Value = CurrentYearid
        //    p(38) = New SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar)
        //    p(38).Value = CurrentYeardesc
        //    p(39) = New SqlParameter("@Studentid", SqlDbType.NVarChar)
        //    p(39).Value = Studentid
        //    p(40) = New SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar)
        //    p(40).Value = LastCourseOpted

        //    p(41) = New SqlParameter("@Opportunity_Code", SqlDbType.NVarChar)
        //    p(41).Value = Opportunity_id
        //    p(42) = New SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar)
        //    p(42).Value = Opp_TYpe_Id
        //    p(43) = New SqlParameter("@Opp_Name", SqlDbType.NVarChar)
        //    p(43).Value = Opp_Name
        //    p(44) = New SqlParameter("@Lead_Code", SqlDbType.NVarChar)
        //    p(44).Value = Leadid
        //    p(45) = New SqlParameter("@Product_Category", SqlDbType.NVarChar)
        //    p(45).Value = Product_Category
        //    p(46) = New SqlParameter("@Product_Code", SqlDbType.NVarChar)
        //    p(46).Value = Product_Code
        //    p(47) = New SqlParameter("@Sales_Stage", SqlDbType.NVarChar)
        //    p(47).Value = Sales_Stage
        //    p(48) = New SqlParameter("@Opp_Join_Date", SqlDbType.DateTime)
        //    p(48).Value = Opp_Join_Date

        //    p(49) = New SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime)
        //    p(49).Value = Opp_Expected_Close_Date
        //    p(50) = New SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar)
        //    p(50).Value = Opp_Probability_Percent
        //    p(51) = New SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar)
        //    p(51).Value = Opp_Next_Step
        //    p(52) = New SqlParameter("@Opp_Value", SqlDbType.Decimal)
        //    p(52).Value = Opp_Value
        //    p(53) = New SqlParameter("@Opp_Disc", SqlDbType.Decimal)
        //    p(53).Value = Opp_Disc

        //    p(54) = New SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar)
        //    p(54).Value = Opp_Contact_Company
        //    p(55) = New SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar)
        //    p(55).Value = Opp_Contact_Division
        //    p(56) = New SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar)
        //    p(56).Value = Opp_Contact_Center
        //    p(57) = New SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar)
        //    p(57).Value = Opp_Contact_Zone
        //    p(58) = New SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar)
        //    p(58).Value = Opp_Contact_Role
        //    p(59) = New SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar)
        //    p(59).Value = Opp_Contact_AssignTo
        //    p(60) = New SqlParameter("@Created_By", SqlDbType.NVarChar)
        //    p(60).Value = Created_By
        //    p(61) = New SqlParameter("@last_Modified_By", SqlDbType.NVarChar)
        //    p(61).Value = last_Modified_By
        //    p(62) = New SqlParameter("@Opp_Status", SqlDbType.NVarChar)
        //    p(62).Value = Opp_Status
        //    p(63) = New SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar)
        //    p(63).Value = Opp_Status_id
        //    p(64) = New SqlParameter("@Oppor_Product", SqlDbType.NVarChar)
        //    p(64).Value = Oppor_product
        //    p(65) = New SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar)
        //    p(65).Value = Oppor_Product_id
        //    p(66) = New SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100)
        //    p(66).Direction = ParameterDirection.Output
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Opportunity", p)
        //    Return (p(66).Value.ToString())
        //End Function

        public static string InsertAddOpportunity(string CON_ID, string CON_TYPE_ID, string CON_TYPE_DESC, string CON_TITLE, string CON_FIRSTNAME, string CON_MNAME, string CON_LNAME, decimal Score, decimal percentile, int Area_rank,
        int Overallrank, string Scorerange, string Handphone1, string handphone2, string landline, string emailid, string Flatno, string buildingname, string streetname, string Countryname,
        string State, string City, string pincode, string Category_Type_Id, string Category_Type, string InstituteTypeid, string InstituteTypeDesc, string Institute_desc, string Current_Standardid, string Current_StandardDesc,
        string AdditionalDesc, string Boardid, string Boarddesc, string Sectionid, string Sectiondesc, string Yearofpassingid, string Yearofpassingdesc, string CurrentYearid, string CurrentYeardesc, string Studentid,
        string LastCourseOpted, string Opportunity_id, string Opp_TYpe_Id, string Opp_Name, string Leadid, string Product_Category, string Product_Code, string Sales_Stage, System.DateTime Opp_Join_Date, System.DateTime Opp_Expected_Close_Date,
        string Opp_Probability_Percent, string Opp_Next_Step, decimal Opp_Value, int Opp_Disc, string Opp_Contact_Company, string Opp_Contact_Division, string Opp_Contact_Center, string Opp_Contact_Zone, string Opp_Contact_Role, string Opp_Contact_AssignTo,
        string Created_By, string last_Modified_By, string Opp_Status, string Opp_Status_id, string Opp_Contact_SDivision, string Opp_Contact_SCenter, string Opp_Contact_SZone, string Oppor_product, string Oppor_Product_id, string App_No,
        string SalesChannel_Id, string SalesChannel, string SecContactType, string SecTitle, string Secfname, string SecMname, string SecLname, string Sechphone1, string Sechphone2, string Seclandline,
        string Secemail, string SecAdd1, string Secadd2, string SecStreetname, string SecCountryname, string SecState, string SecCity, string Secpincode, string SecContactDesc, int discipline_id,
        string Discipline_desc, int Field_Id, string Field_Desc, string Competitive_Exam, int Totalmsmarks, int Totalmsmarksobt, string Opp_Contact_Target_Company, string Dob, string Examination, string location,
        string Gender)
        {
            SqlParameter[] p = new SqlParameter[102];
            p[0] = new SqlParameter("@CON_ID", SqlDbType.NVarChar);
            p[0].Value = CON_ID;
            p[1] = new SqlParameter("@CON_TYPE_ID", SqlDbType.NVarChar);
            p[1].Value = CON_TYPE_ID;
            p[2] = new SqlParameter("@CON_TYPE_DESC", SqlDbType.NVarChar);
            p[2].Value = CON_TYPE_DESC;
            p[3] = new SqlParameter("@CON_TITLE", SqlDbType.NVarChar);
            p[3].Value = CON_TITLE;
            p[4] = new SqlParameter("@CON_FIRSTNAME", SqlDbType.NVarChar);
            p[4].Value = CON_FIRSTNAME;
            p[5] = new SqlParameter("@CON_MIDNAME", SqlDbType.NVarChar);
            p[5].Value = CON_MNAME;
            p[6] = new SqlParameter("@CON_LASTNAME", SqlDbType.NVarChar);
            p[6].Value = CON_LNAME;
            p[7] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[7].Value = Score;
            p[8] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[8].Value = percentile;
            p[9] = new SqlParameter("@Area_rank", SqlDbType.NVarChar);
            p[9].Value = Area_rank;
            p[10] = new SqlParameter("@OverallRank", SqlDbType.NVarChar);
            p[10].Value = Overallrank;
            p[11] = new SqlParameter("@score_Range_Type", SqlDbType.NVarChar);
            p[11].Value = Scorerange;
            p[12] = new SqlParameter("@Handphone1", SqlDbType.NVarChar);
            p[12].Value = Handphone1;
            p[13] = new SqlParameter("@Handphone2", SqlDbType.NVarChar);
            p[13].Value = handphone2;
            p[14] = new SqlParameter("@Landline", SqlDbType.NVarChar);
            p[14].Value = landline;
            p[15] = new SqlParameter("@emailid", SqlDbType.NVarChar);
            p[15].Value = emailid;
            p[16] = new SqlParameter("@Flatno", SqlDbType.NVarChar);
            p[16].Value = Flatno;
            p[17] = new SqlParameter("@buildingname", SqlDbType.NVarChar);
            p[17].Value = buildingname;
            p[18] = new SqlParameter("@streetname", SqlDbType.NVarChar);
            p[18].Value = streetname;
            p[19] = new SqlParameter("@Country", SqlDbType.NVarChar);
            p[19].Value = Countryname;
            p[20] = new SqlParameter("@State", SqlDbType.NVarChar);
            p[20].Value = State;
            p[21] = new SqlParameter("@City", SqlDbType.NVarChar);
            p[21].Value = City;
            p[22] = new SqlParameter("@pincode", SqlDbType.NVarChar);
            p[22].Value = pincode;
            p[23] = new SqlParameter("@Category_Type_Id", SqlDbType.NVarChar);
            p[23].Value = Category_Type_Id;
            p[24] = new SqlParameter("@Category_Type", SqlDbType.NVarChar);
            p[24].Value = Category_Type;

            p[25] = new SqlParameter("@Institute_Type_Id", SqlDbType.NVarChar);
            p[25].Value = InstituteTypeid;
            p[26] = new SqlParameter("@institute_Type_Desc", SqlDbType.NVarChar);
            p[26].Value = InstituteTypeDesc;
            p[27] = new SqlParameter("@Institution_Desc", SqlDbType.NVarChar);
            p[27].Value = Institute_desc;
            p[28] = new SqlParameter("@Current_Standard_id", SqlDbType.NVarChar);
            p[28].Value = Current_Standardid;
            p[29] = new SqlParameter("@Current_Standard_Desc", SqlDbType.NVarChar);
            p[29].Value = Current_StandardDesc;
            p[30] = new SqlParameter("@Additional_desc", SqlDbType.NVarChar);
            p[30].Value = AdditionalDesc;
            p[31] = new SqlParameter("@Board_Id", SqlDbType.NVarChar);
            p[31].Value = Boardid;
            p[32] = new SqlParameter("@Board_Desc", SqlDbType.NVarChar);
            p[32].Value = Boarddesc;
            p[33] = new SqlParameter("@Section_Id", SqlDbType.NVarChar);
            p[33].Value = Sectionid;
            p[34] = new SqlParameter("@Section_Desc", SqlDbType.NVarChar);
            p[34].Value = Sectiondesc;
            p[35] = new SqlParameter("@Year_of_Passing_Id", SqlDbType.NVarChar);
            p[35].Value = Yearofpassingid;
            p[36] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.NVarChar);
            p[36].Value = Yearofpassingdesc;
            p[37] = new SqlParameter("@Current_Year_Id", SqlDbType.NVarChar);
            p[37].Value = CurrentYearid;
            p[38] = new SqlParameter("@Current_Year_Desc", SqlDbType.NVarChar);
            p[38].Value = CurrentYeardesc;
            p[39] = new SqlParameter("@Studentid", SqlDbType.NVarChar);
            p[39].Value = Studentid;
            p[40] = new SqlParameter("@Last_Course_Opted", SqlDbType.NVarChar);
            p[40].Value = LastCourseOpted;

            p[41] = new SqlParameter("@Oppur_Id", SqlDbType.NVarChar);
            p[41].Value = Opportunity_id;
            p[42] = new SqlParameter("@Opp_Type_Id", SqlDbType.NVarChar);
            p[42].Value = Opp_TYpe_Id;
            p[43] = new SqlParameter("@Opp_Name", SqlDbType.NVarChar);
            p[43].Value = Opp_Name;
            p[44] = new SqlParameter("@Lead_id", SqlDbType.NVarChar);
            p[44].Value = Leadid;
            p[45] = new SqlParameter("@Product_Category", SqlDbType.NVarChar);
            p[45].Value = Product_Category;
            p[46] = new SqlParameter("@Product_Code", SqlDbType.NVarChar);
            p[46].Value = Product_Code;
            p[47] = new SqlParameter("@Sales_Stage", SqlDbType.NVarChar);
            p[47].Value = Sales_Stage;
            p[48] = new SqlParameter("@Opp_Join_Date", SqlDbType.DateTime);
            p[48].Value = Opp_Join_Date;

            p[49] = new SqlParameter("@Opp_Expected_Close_Date", SqlDbType.DateTime);
            p[49].Value = Opp_Expected_Close_Date;
            p[50] = new SqlParameter("@Opp_Probability_Percent", SqlDbType.NVarChar);
            p[50].Value = Opp_Probability_Percent;
            p[51] = new SqlParameter("@Opp_Next_Step", SqlDbType.NVarChar);
            p[51].Value = Opp_Next_Step;
            p[52] = new SqlParameter("@Opp_Value", SqlDbType.Decimal);
            p[52].Value = Opp_Value;
            p[53] = new SqlParameter("@Opp_Disc", SqlDbType.Int);
            p[53].Value = Opp_Disc;

            p[54] = new SqlParameter("@Opp_Contact_Company", SqlDbType.NVarChar);
            p[54].Value = Opp_Contact_Company;
            p[55] = new SqlParameter("@Opp_Contact_Division", SqlDbType.NVarChar);
            p[55].Value = Opp_Contact_Division;
            p[56] = new SqlParameter("@Opp_Contact_Center", SqlDbType.NVarChar);
            p[56].Value = Opp_Contact_Center;
            p[57] = new SqlParameter("@Opp_Contact_Zone", SqlDbType.NVarChar);
            p[57].Value = Opp_Contact_Zone;
            p[58] = new SqlParameter("@Opp_Contact_Role", SqlDbType.NVarChar);
            p[58].Value = Opp_Contact_Role;
            p[59] = new SqlParameter("@Opp_Contact_AssignTo", SqlDbType.NVarChar);
            p[59].Value = Opp_Contact_AssignTo;
            p[60] = new SqlParameter("@Created_By", SqlDbType.NVarChar);
            p[60].Value = Created_By;
            p[61] = new SqlParameter("@last_Modified_By", SqlDbType.NVarChar);
            p[61].Value = last_Modified_By;
            p[62] = new SqlParameter("@Opp_Status", SqlDbType.NVarChar);
            p[62].Value = Opp_Status;
            p[63] = new SqlParameter("@Opp_Status_Id", SqlDbType.NVarChar);
            p[63].Value = Opp_Status_id;
            p[64] = new SqlParameter("@Oppor_Product", SqlDbType.NVarChar);
            p[64].Value = Oppor_product;

            p[65] = new SqlParameter("@Opp_ContactSource_Division", SqlDbType.NVarChar);
            p[65].Value = Opp_Contact_SDivision;
            p[66] = new SqlParameter("@Opp_ContactSource_Center", SqlDbType.NVarChar);
            p[66].Value = Opp_Contact_SCenter;
            p[67] = new SqlParameter("@Opp_ContactSource_Zone", SqlDbType.NVarChar);
            p[67].Value = Opp_Contact_SZone;

            p[68] = new SqlParameter("@Oppor_Product_Id", SqlDbType.NVarChar, 100);
            p[68].Value = Oppor_Product_id;
            p[69] = new SqlParameter("@Oppor_Id_Out", SqlDbType.NVarChar, 100);
            p[69].Direction = ParameterDirection.Output;
            p[70] = new SqlParameter("@appno", SqlDbType.NVarChar);
            p[70].Value = App_No;
            p[71] = new SqlParameter("@SalesStage_Id", SqlDbType.NVarChar);
            p[71].Value = SalesChannel_Id;
            p[72] = new SqlParameter("@SalesStage_Desc", SqlDbType.NVarChar);
            p[72].Value = SalesChannel;

            p[73] = new SqlParameter("@SEC_CON_TYPE_ID", SqlDbType.NVarChar);
            p[73].Value = SecContactType;
            p[74] = new SqlParameter("@SEC_CON_TITLE", SqlDbType.NVarChar);
            p[74].Value = SecTitle;
            p[75] = new SqlParameter("@SEC_CON_FIRSTNAME", SqlDbType.NVarChar);
            p[75].Value = Secfname;
            p[76] = new SqlParameter("@SEC_CON_MIDNAME", SqlDbType.NVarChar);
            p[76].Value = SecMname;
            p[77] = new SqlParameter("@SEC_CON_LASTNAME", SqlDbType.NVarChar);
            p[77].Value = SecLname;
            p[78] = new SqlParameter("@SEC_Handphone1", SqlDbType.NVarChar);
            p[78].Value = Sechphone1;
            p[79] = new SqlParameter("@SEC_Handphone2", SqlDbType.NVarChar);
            p[79].Value = Sechphone2;
            p[80] = new SqlParameter("@SEC_Landline", SqlDbType.NVarChar);
            p[80].Value = Seclandline;
            p[81] = new SqlParameter("@SEC_emailid", SqlDbType.NVarChar);
            p[81].Value = Secemail;
            p[82] = new SqlParameter("@SEC_Flatno", SqlDbType.NVarChar);
            p[82].Value = SecAdd1;
            p[83] = new SqlParameter("@SEC_buildingname", SqlDbType.NVarChar);
            p[83].Value = Secadd2;
            p[84] = new SqlParameter("@SEC_streetname", SqlDbType.NVarChar);
            p[84].Value = SecStreetname;
            p[85] = new SqlParameter("@SEC_Country", SqlDbType.NVarChar);
            p[85].Value = SecCountryname;
            p[86] = new SqlParameter("@SEC_State", SqlDbType.NVarChar);
            p[86].Value = SecState;
            p[87] = new SqlParameter("@SEC_City", SqlDbType.NVarChar);
            p[87].Value = SecCity;
            p[88] = new SqlParameter("@SEC_pincode", SqlDbType.NVarChar);
            p[88].Value = Secpincode;
            p[89] = new SqlParameter("@SEC_CON_TYPE_DESC", SqlDbType.NVarChar, 50);
            p[89].Value = SecContactDesc;
            p[90] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[90].Value = discipline_id;
            p[91] = new SqlParameter("@Discipline_Desc", SqlDbType.NVarChar);
            p[91].Value = Discipline_desc;
            p[92] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[92].Value = Field_Id;
            p[93] = new SqlParameter("@Field_Interested_Desc", SqlDbType.NVarChar);
            p[93].Value = Field_Desc;
            p[94] = new SqlParameter("@Competitive_Exam", SqlDbType.NVarChar);
            p[94].Value = Competitive_Exam;
            p[95] = new SqlParameter("@Total_ms_Marks", SqlDbType.Int);
            p[95].Value = Totalmsmarks;
            p[96] = new SqlParameter("@Total_ms_Marks_obt", SqlDbType.Int);
            p[96].Value = Totalmsmarksobt;
            p[97] = new SqlParameter("@Opp_Contact_Target_Company", SqlDbType.VarChar);
            p[97].Value = Opp_Contact_Target_Company;

            p[98] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[98].Value = Dob;
            p[99] = new SqlParameter("@last_exam", SqlDbType.VarChar);
            p[99].Value = Examination;
            p[100] = new SqlParameter("@location", SqlDbType.VarChar);
            p[100].Value = location;
            p[101] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[101].Value = Gender;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Opportunity", p);
            return (p[69].Value.ToString());
        }

        public static string InsertAccount(string Accountid, string Opporid, string Sbentrycode, System.DateTime Account_ConvertDate, string Notes, string Createdby, string Modifiedby)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@Accountid", SqlDbType.NVarChar);
            p[0].Value = Accountid;
            p[1] = new SqlParameter("@Oppor_id", SqlDbType.NVarChar);
            p[1].Value = Opporid;
            p[2] = new SqlParameter("@Sbentrycode", SqlDbType.NVarChar);
            p[2].Value = Sbentrycode;
            p[3] = new SqlParameter("@Account_Convert_Date", SqlDbType.DateTime);
            p[3].Value = Account_ConvertDate;
            p[4] = new SqlParameter("@Notes", SqlDbType.NVarChar);
            p[4].Value = Notes;
            p[5] = new SqlParameter("@Createdby", SqlDbType.NVarChar);
            p[5].Value = Createdby;
            p[6] = new SqlParameter("@modifiedby", SqlDbType.NVarChar);
            p[6].Value = Modifiedby;
            p[7] = new SqlParameter("@Account_Id_Out", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertAccount", p);
            return (p[7].Value.ToString());
        }

        public static string InsertFeesAdjustment(string Sbentrycode, string Vouchertype, string VoucherDate,
            float  Amount, string Pricing_Procedure_Code, string Material_Code, string User_Code)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p[0].Value = Sbentrycode ;
            p[1] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
            p[1].Value = Vouchertype;
            p[2] = new SqlParameter("@VoucherDate", SqlDbType.VarChar);
            p[2].Value = VoucherDate;
            p[3] = new SqlParameter("@Amount", SqlDbType.Float );
            p[3].Value = Amount;
            p[4] = new SqlParameter("@Pricing_Procedure_Code", SqlDbType.VarChar);
            p[4].Value = Pricing_Procedure_Code;
            p[5] = new SqlParameter("@Material_Code", SqlDbType.VarChar);
            p[5].Value = Material_Code;
            p[6] = new SqlParameter("@User_Code", SqlDbType.VarChar);
            p[6].Value = User_Code;
            p[7] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
            p[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Student_Voucher", p);
            return (p[7].Value.ToString());
        }

        public static string GetVoucherValuebySbentrycode(int flag,string Sbentrycode, string Vouchertype )
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@flag", SqlDbType.Int );
            p[0].Value = flag;
            p[1] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p[1].Value = Sbentrycode;
            p[2] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
            p[2].Value = Vouchertype;
            p[3] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_CRF_ValuebySBENtrycode", p);
            return (p[3].Value.ToString());
        }

        //public static string InsertDifferentialCRF(string Sbentrycode, string Vouchertype, string VoucherDate,
        //    float Amount, string Pricing_Procedure_Code, string Material_Code, string User_Code)
        //{
        //    SqlParameter[] p = new SqlParameter[8];
        //    p[0] = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
        //    p[0].Value = Sbentrycode;
        //    p[1] = new SqlParameter("@VoucherType", SqlDbType.VarChar);
        //    p[1].Value = Vouchertype;
        //    p[2] = new SqlParameter("@VoucherDate", SqlDbType.VarChar);
        //    p[2].Value = VoucherDate;
        //    p[3] = new SqlParameter("@Amount", SqlDbType.Float);
        //    p[3].Value = Amount;
        //    p[4] = new SqlParameter("@Pricing_Procedure_Code", SqlDbType.VarChar);
        //    p[4].Value = Pricing_Procedure_Code;
        //    p[5] = new SqlParameter("@Material_Code", SqlDbType.VarChar);
        //    p[5].Value = Material_Code;
        //    p[6] = new SqlParameter("@User_Code", SqlDbType.VarChar);
        //    p[6].Value = User_Code;
        //    p[7] = new SqlParameter("@Account_OUT_ID", SqlDbType.VarChar, 100);
        //    p[7].Direction = ParameterDirection.Output;

        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Student_Voucher", p);
        //    return (p[7].Value.ToString());
        //}

        //Enrollment Check 
        public static string CheckStudentInfobyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@Val", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETVALUE_BYOPPID", p);
            return (p[1].Value.ToString());
        }
        public static DataSet UpdateImagePath(string SBEntrycode, string fileext)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@fileext", fileext);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateImagePath", p1, p2));

        }


        //For Batch Creation
        #region "Batch Creation"
        
        //public static DataSet GetAllActive_Standard_ForYear(string Division_Code, string YearName)
        //{
        //    SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@YearName", YearName);
        //    SqlParameter p3 = new SqlParameter("@Flag", 1);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStandard", p1, p2, p3));
        //}

        public static DataSet GetAllActive_Standard_ForYear(string Division_Code, string YearName)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStandard_New", p1, p2, p3));
        }
        public static int Get_Update_Role_Synch(int flag)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);

            return Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1));
        }
        public static int Chk_Page_Validation(string Pagename, string userid, string ApplicationNo)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Pagename", Pagename);
            p[1] = new SqlParameter("@User_id", userid);
            p[2] = new SqlParameter("@ApplicationNo", ApplicationNo);

            p[3] = new SqlParameter("@count", SqlDbType.VarChar, 10);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Check_PageValidation", p);
            return Convert.ToInt32(p[3].Value.ToString());
        }


        public static DataSet GetAllActiveUser_AcadYear()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentYear"));
        }

        public static DataSet GetBatchBy_Division_Year_Standard_Centre(string Division_Code, string YearName, string StandardCode, string CentreCode, string BatchName)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p5 = new SqlParameter("@BatchName", BatchName);
            SqlParameter p6 = new SqlParameter("@Flag", 1);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchBy_Division_Year_Standard_Centre", p1, p2, p3, p4, p5, p6));
        }

        public static DataSet GetallSubjectGroupbyStreamCode(string streamcode)
        {
            SqlParameter p1 = new SqlParameter("@Stream_Code", streamcode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetSubjectGroup_StreamCode", p1));
        }

        public static DataSet GetallInstitutename()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstitution"));
        }


        public static DataSet GetAllCenters_Filled_For_User(int Flag, string DivisionCode, string user)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p3 = new SqlParameter("@User_Code", user);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1, p2, p3));

        }
        public static DataSet GetBatchBY_PKey(string PKey)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey", p1, p2, p3);
            return (XYZ);
        }


        public static DataSet GetConfigTable(string flag, string TableId)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@TableId", TableId);


            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_ConfigTable", p1, p2));
        }

        public static int Insert_Update_ConfigTables(string TableID, string ID, string Description, string Activeflag, string Createdby, string ShortDescription, string Percentage)
        {
            SqlParameter p1 = new SqlParameter("@TableID", TableID);
            SqlParameter p2 = new SqlParameter("@ID", ID);
            SqlParameter p3 = new SqlParameter("@Description", Description);
            SqlParameter p4 = new SqlParameter("@IsActive", Activeflag);
            SqlParameter p5 = new SqlParameter("@Created_By", Createdby);
            SqlParameter p6 = new SqlParameter("@ShortDescription", ShortDescription);
            SqlParameter p7 = new SqlParameter("@Percentage", Percentage);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ConfigTables", p1, p2, p3, p4, p5, p6, p7));
        }
        public static DataSet GetBatchBY_PKey_SubjectGrp(string PKey, string subjectgrpup, string institute, string StreamCode)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            SqlParameter p4 = new SqlParameter("@SubjectGroup", subjectgrpup);
            SqlParameter p5 = new SqlParameter("@InstituteName", institute);
            SqlParameter p6 = new SqlParameter("@StreamCode", StreamCode);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Subjectgroup", p1, p2, p3,p4,p5,p6);
            return (XYZ);
        }

        public static DataSet GetAllClassroomProduct_ByPKEY(string PKey)
        {
            //Try
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
            SqlParameter p3 = new SqlParameter("@Flag", 1);
            DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Classroom", p1, p2, p3);
            return (XYZ);
        }

        //public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        //{
        //    SqlParameter p1 = new SqlParameter("@user_id", User_ID);
        //    SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
        //    SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
        //    SqlParameter p5 = new SqlParameter("@Flag", Flag);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));
            
        //}

        public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        {
            SqlParameter p1 = new SqlParameter("@user_id", User_ID);
            SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
            SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);

            if (DBName == "MTEducare")
            {
                return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_MTEducare", p1, p2, p3, p4, p5));
            }
            else
            {
                return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));
            }

        }

        //public static DataSet GetAllActive_AllStandard(string Division_Code)
        //{
        //    SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard", p1));
        //}

        public static DataSet GetAllActive_AllStandard(string Division_Code)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard_New", p1));
        }


        public static DataSet GetAllStandard_ByDivisionCode(string Division_Code)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard_ByDivisionCode", p1));
        }
        
        public static string Raise_Error(string Error_Code)
        {
            string Error_Desc = null;

            switch (Error_Code)
            {
                case "0000":
                    Error_Desc = "Record saved successfully";
                    break;
                case "0001":
                    Error_Desc = "Select Division";
                    break;
                case "0002":
                    Error_Desc = "Select Academic Year";
                    break;
                case "0003":
                    Error_Desc = "Select Course";
                    break;
                case "0004":
                    Error_Desc = "Select Product";
                    break;
                case "0005":
                    Error_Desc = "Select Subject";
                    break;
                case "0006":
                    Error_Desc = "Select Centre";
                    break;
                case "0007":
                    Error_Desc = "Select Student(s)";
                    break;
                case "0008":
                    Error_Desc = "Number of Students selected is more than Maximum Batch Strength";
                    break;
                case "0009":
                    Error_Desc = "Enter New Batch Count";
                    break;
                case "0010":
                    Error_Desc = "Select Chapter(s)";
                    break;
                case "0011":
                    Error_Desc = "Select Test Mode";
                    break;
                case "0012":
                    Error_Desc = "Select Test Category";
                    break;
                case "0013":
                    Error_Desc = "Select Test Type";
                    break;
                case "0014":
                    Error_Desc = "Select Test Duration";
                    break;
                case "0015":
                    Error_Desc = "Select Batch";
                    break;
                case "0016":
                    Error_Desc = "Select Test Name";
                    break;
                case "0017":
                    Error_Desc = "Enter Maximum Marks";
                    break;
                case "0018":
                    Error_Desc = "Invalid Start Time";
                    break;
                case "0019":
                    Error_Desc = "Invalid End Time";
                    break;
                case "0020":
                    Error_Desc = "Start Time can't be after End Time";
                    break;
                case "0021":
                    Error_Desc = "Select Entity Type";
                    break;
                case "0022":
                    Error_Desc = "Select CSV File that you want to upload using Browse button";
                    break;
                case "0023":
                    Error_Desc = "File with the same name already processed for this test";
                    break;
                case "0024":
                    Error_Desc = "Invalid file format";
                    break;
                case "0025":
                    Error_Desc = "Enter Name of the column where Student ID is stored";
                    break;
                case "0026":
                    Error_Desc = "Invalid ID Column name";
                    break;
                case "0027":
                    Error_Desc = "No records found for importing";
                    break;
                case "0028":
                    Error_Desc = "Select Conduct Number";
                    break;
                case "0029":
                    Error_Desc = "Duplicate Test Name";
                    break;
                case "0030":
                    Error_Desc = "Select Student";
                    break;
                case "0031":
                    Error_Desc = "Attendance Authorisation can't be done as attendance of few Students is not marked";
                    break;
                case "0032":
                    Error_Desc = "Attendance Authorisation done successfully";
                    break;
                case "0033":
                    Error_Desc = "Attendance Authorisation removed successfully";
                    break;
                case "0034":
                    Error_Desc = "Marks Authorisation done successfully";
                    break;
                case "0035":
                    Error_Desc = "Marks Authorisation removed successfully";
                    break;
                case "0036":
                    Error_Desc = "Marks Authorisation can't be done as marks of few students are not entered";
                    break;
                case "0037":
                    Error_Desc = "File not found";
                    break;
                case "0038":
                    Error_Desc = "Test names matching with search options not found";
                    break;
                case "0039":
                    Error_Desc = "Student Answers reprocessed successfully";
                    break;
                case "0040":
                    Error_Desc = "Select Country";
                    break;
                case "0041":
                    Error_Desc = "Select State";
                    break;
                case "0042":
                    Error_Desc = "Select City";
                    break;
                case "0043":
                    Error_Desc = "Select Company";
                    break;
                case "0044":
                    Error_Desc = "Select Location";
                    break;
                case "0045":
                    Error_Desc = "Select Classroom Type";
                    break;
                case "0046":
                    Error_Desc = "Enter Classroom Length (in feet)";
                    break;
                case "0047":
                    Error_Desc = "Enter Classroom Width (in feet)";
                    break;
                case "0048":
                    Error_Desc = "Enter Classroom Height (in feet)";
                    break;
                case "0049":
                    Error_Desc = "Duplicate Classroom name";
                    break;
                case "0050":
                    Error_Desc = "Select Primary Owner Centre for the Classroom";
                    break;
                case "0051":
                    Error_Desc = "Select only 1 Centre as Primary Owner Centre for the Classroom";
                    break;
                case "0052":
                    Error_Desc = "Select Unit of Measurement for Classroom Capacity";
                    break;
                case "0053":
                    Error_Desc = "Select Title";
                    break;
                case "0054":
                    Error_Desc = "Enter First Name";
                    break;
                case "0055":
                    Error_Desc = "Enter Hand Phone number (1)";
                    break;
                case "0056":
                    Error_Desc = "Select Gender";
                    break;
                case "0057":
                    Error_Desc = "Select Activity";
                    break;
                case "0058":
                    Error_Desc = "Duplicate Partner details";
                    break;
                case "0059":
                    Error_Desc = "Invalid Hand Phone number (1)";
                    break;
                case "0060":
                    Error_Desc = "Invalid Hand Phone number (2)";
                    break;
                case "0061":
                    Error_Desc = "Enter Size of Premises in Sq. Feet";
                    break;
                case "0062":
                    Error_Desc = "Duplicate Premises name";
                    break;
                case "0063":
                    Error_Desc = "Select Premises Type";
                    break;
                case "0064":
                    Error_Desc = "Test Removal Request Approved successfully.";
                    break;
                case "0065":
                    Error_Desc = "Test Removal Request Rejected successfully";
                    break;
                case "0066":
                    Error_Desc = "Select Action";
                    break;
                case "0067":
                    Error_Desc = "Record deleted successfully";
                    break;
                case "0068":
                    Error_Desc = "Select Issuer Type";
                    break;
                case "0069":
                    Error_Desc = "Select Receiver Type";
                    break;
                case "0070":
                    Error_Desc = "Select Date Range";
                    break;
                case "0096":
                    Error_Desc = "select Course Name";
                    break;
                case "0097":
                    Error_Desc = "Enter Topic Name";
                    break;
                case "0098":
                    Error_Desc = "Enter Topic description Name";
                    break;
                case "0099":
                    Error_Desc = "Enter Sequence No";
                    break;
                case "00100":
                    Error_Desc = "Select Medium";
                    break;
                case "0090":
                    Error_Desc = "Enter Board Name";
                    break;
                case "0091":
                    Error_Desc = "Enter Board Display Name";
                    break;
                case "0092":
                    Error_Desc = "Select Course Category Name";
                    break;
                case "0093":
                    Error_Desc = "Select Reference Course Name";
                    break;
                case "0094":
                    Error_Desc = "Select Reference Subject Name";
                    break;
                case "0095":
                    Error_Desc = "Enter Subject Name";
                    break;
                default:
                    Error_Desc = Error_Code;
                    break;
            }
            return Error_Desc;
        }

        //public static DataSet GetAllActiveSubjectsBy_Stream_AAG(string Stream_Code, string AAG, int Flag)
        //{
        //    SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
        //    SqlParameter p2 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p3 = new SqlParameter("@Flag", Flag);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Stream_AAG", p1, p2, p3));
        //}

        public static DataSet GetAllActiveSubjectsBy_Stream_AAG(string Stream_Code, string AAG, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
            SqlParameter p2 = new SqlParameter("@AAG", AAG);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Stream_AAG_New", p1, p2, p3));
        }

        public static DataSet GetAllActiveLMSProductBy_Stream(string Stream_Code, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[USP_GetAllLMSProductBy_Stream]", p1, p2));
        }

        public static int Insert_Batches(string DivisionCode, string YearName, string StandardCode, string ProductCode, string SubjectCode, string CentreCode, int MaxBatchStrength, string CreatedBy, string LMS_ProductCode)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@ProductCode", ProductCode);
            p[4] = new SqlParameter("@SubjectCode", SubjectCode);
            p[5] = new SqlParameter("@CentreCode", CentreCode);
            p[6] = new SqlParameter("@MaxBatchStrength", MaxBatchStrength);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[9] = new SqlParameter("@LMS_ProductCode", LMS_ProductCode);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch", p);
            return (int.Parse(p[8].Value.ToString()));
        }

        public static int Insert_Batches_LikeExistingBatch(string PKey, string CentreCode, int NewBatchCount, string CreatedBy, string LMS_ProductCode)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@CentreCode", CentreCode);
            p[2] = new SqlParameter("@NewBatchCount", NewBatchCount);
            p[3] = new SqlParameter("@CreatedBy", CreatedBy);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[5] = new SqlParameter("@LMS_ProductCode", LMS_ProductCode);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_LikeExistingBatch", p);
            return (int.Parse(p[4].Value.ToString()));
        }

        public static int Update_Batch(string PKey, string ProductCode, string SubjectCode, int MaxBatchStrength, string BatchShortName, int IsActiveFlag, string AlteredBy)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@ProductCode", ProductCode);
            p[2] = new SqlParameter("@SubjectCode", SubjectCode);
            p[3] = new SqlParameter("@MaxBatchStrength", MaxBatchStrength);
            p[4] = new SqlParameter("@BatchShortName", BatchShortName);
            p[5] = new SqlParameter("@IsActiveFlag", IsActiveFlag);
            p[6] = new SqlParameter("@AlteredBy", AlteredBy);
            p[7] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[7].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateBatch", p);
            return (int.Parse(p[7].Value.ToString()));
        }

        public static int Insert_Batch_Students(string PKey, string SBEntryCode, int ActionFlag, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@SBEntryCode", SBEntryCode);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@ActionFlag", ActionFlag);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_Student", p);
            return (int.Parse(p[4].Value.ToString()));
        }

        public static int Update_Batch_ShortName(string PKey, string BatchShortName, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@BatchShortName", BatchShortName);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Batch_ShortName", p);
            return (int.Parse(p[3].Value.ToString()));
        }

        public static int Update_Batch_Student_RollNo(string PKey, string SBEntryCode, string NewRollNo, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@SBEntryCode", SBEntryCode);
            p[2] = new SqlParameter("@CreatedBy", CreatedBy);
            p[3] = new SqlParameter("@NewRollNo", NewRollNo);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Batch_Student_RollNo", p);
            return (int.Parse(p[4].Value.ToString()));
        }
        public static int Update_Test(string TestCode, string DivisionCode, string YearName, string StandardCode, string TestModeCode, string TestCategoryCode, string TestTypeCode, string SubjectCode, string CentreCode, string ChapterCode,
        double MaxMarks, int TestDuration, int QPSetCount, int QuestionCount, string TestName, string TestDescription, string Remarks, int NegativeMarkingFlag, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@TestModeCode", TestModeCode);
            p[4] = new SqlParameter("@TestCategoryCode", TestCategoryCode);
            p[5] = new SqlParameter("@TestTypeCode", TestTypeCode);
            p[6] = new SqlParameter("@TestName", TestName);
            p[7] = new SqlParameter("@TestDescription", TestDescription);
            p[8] = new SqlParameter("@Remarks", Remarks);
            p[9] = new SqlParameter("@SubjectCode", SubjectCode);
            p[10] = new SqlParameter("@CentreCode", CentreCode);
            p[11] = new SqlParameter("@ChapterCode", ChapterCode);
            p[12] = new SqlParameter("@QPSetCnt", QPSetCount);
            p[13] = new SqlParameter("@MaxMarks", MaxMarks);
            p[14] = new SqlParameter("@TestDuration", TestDuration);
            p[15] = new SqlParameter("@CreatedBy", CreatedBy);
            p[16] = new SqlParameter("@QuestionCount", QuestionCount);
            //
            p[17] = new SqlParameter("@NegativeMarkingFlag", NegativeMarkingFlag);
            p[18] = new SqlParameter("@TestCode", TestCode);
            p[19] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[19].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateTest", p);
            return (int.Parse(p[19].Value.ToString()));
        }


        /////////
        public static DataSet GetAllActiveStreamsBy_Division_Year(string Division_Code, string Acad_Year, string AAG, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p3 = new SqlParameter("@AAG", AAG);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4));
        }

        ///New One
        //public static DataSet GetAllActiveStreamsBy_Division_Year(string Division_Code, string Acad_Year, string AAG, string Flag, string CenterCode)
        //{
        //    SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
        //    SqlParameter p3 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p4 = new SqlParameter("@Flag", Flag);
        //    SqlParameter p5 = new SqlParameter("@CenterCode", CenterCode);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4, p5));
        //}

        //public static DataSet Getallsubjectgroupbystreams(string flag, string stream)
        //{
        //    SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
        //    SqlParameter p3 = new SqlParameter("@AAG", AAG);
        //    SqlParameter p4 = new SqlParameter("@Flag", Flag);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG", p1, p2, p3, p4));
        //}

        public static int Insert_Chapter(string DivisionCode, string YearName, string StandardCode, string SubjectCode, string ChapterName, string Chapter_DisplayName, double LectureCount, int LectureDuration, string ChapterShortName, string ChapterCodeForEdit, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@SubjectCode", SubjectCode);
            p[4] = new SqlParameter("@ChapterName", ChapterName);
            p[5] = new SqlParameter("@Chapter_DisplayName", Chapter_DisplayName);
            p[6] = new SqlParameter("@LectureCount", LectureCount);
            p[7] = new SqlParameter("@LectureDuration", LectureDuration);
            p[8] = new SqlParameter("@ChapterShortName", ChapterShortName);
            p[9] = new SqlParameter("@ChapterCodeForEdit", ChapterCodeForEdit);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertChapter", p);
            return (int.Parse(p[11].Value.ToString()));
        }

        public static DataSet GetAllSubjectsBy_Division_Year_Standard(string Division_Code, string Acad_Year, string Standard_Code)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p3 = new SqlParameter("@Standard_Code", Standard_Code);
            
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Division_Year_Standard_New", p1, p2, p3));

        }

        public static string Insert_Partner(string CompanyCode, string Title, string FirstName, string MiddleName, string LastName, string Gender, System.DateTime DOB, System.DateTime DOJ, string Qualification, string HandPhone1,
        string HandPhone2, string Landline, string EmailId, string FlatNo, string BuildingName, string StreetName, string Country_Code, string State_Code, string City_Code, string Location_Code,
        string Pincode, int IsActive, string CreatedBy, string ActivityCode, string DivisionCode, string EmployeeNo, string Area_Name, string Remarks, string AccountNumber, string BranchName, string PanNumber, string IFSCCode)
        {

            SqlParameter[] p = new SqlParameter[33];
            p[0] = new SqlParameter("@CompanyCode", CompanyCode);
            p[1] = new SqlParameter("@Title", Title);
            p[2] = new SqlParameter("@FirstName", FirstName);
            p[3] = new SqlParameter("@MiddleName", MiddleName);
            p[4] = new SqlParameter("@LastName", LastName);
            p[5] = new SqlParameter("@Gender", Gender);
            p[6] = new SqlParameter("@DOB", DOB);
            p[7] = new SqlParameter("@DOJ", DOJ);
            p[8] = new SqlParameter("@Qualification", Qualification);
            p[9] = new SqlParameter("@HandPhone1", HandPhone1);
            p[10] = new SqlParameter("@HandPhone2", HandPhone2);
            p[11] = new SqlParameter("@Landline", Landline);
            p[12] = new SqlParameter("@EmailId", EmailId);
            p[13] = new SqlParameter("@FlatNo", FlatNo);
            p[14] = new SqlParameter("@BuildingName", BuildingName);
            p[15] = new SqlParameter("@StreetName", StreetName);
            p[16] = new SqlParameter("@Country_Code", Country_Code);
            p[17] = new SqlParameter("@State_Code", State_Code);
            p[18] = new SqlParameter("@City_Code", City_Code);
            p[19] = new SqlParameter("@Location_Code", Location_Code);
            p[20] = new SqlParameter("@Pincode", Pincode);
            p[21] = new SqlParameter("@IsActive", IsActive);
            p[22] = new SqlParameter("@CreatedBy", CreatedBy);
            p[23] = new SqlParameter("@ActivityCode", ActivityCode);
            p[24] = new SqlParameter("@DivisionCode", DivisionCode);
            p[25] = new SqlParameter("@EmployeeNo", EmployeeNo);
            p[26] = new SqlParameter("@Area_Name", Area_Name);
            p[27] = new SqlParameter("@Remarks", Remarks);
            p[28] = new SqlParameter("@BankACNo", AccountNumber);

            p[29] = new SqlParameter("@BankBranch", BranchName);
            p[30] = new SqlParameter("@PANNo", PanNumber);
            p[31] = new SqlParameter("@BankIFSECode", IFSCCode);
            p[32] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[32].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertPartner", p);
            return (p[32].Value.ToString());
        }

        public static int Insert_Standard_Subject(string PKey, string Subject_ShortName, string Subject_ShortCode, string CreatedBy)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@PKey", PKey);
            p[1] = new SqlParameter("@Subject_ShortName", Subject_ShortName);
            p[2] = new SqlParameter("@Subject_ShortCode", Subject_ShortCode);
            p[3] = new SqlParameter("@CreatedBy", CreatedBy);
            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertStandardSubject", p);
            return (int.Parse(p[4].Value.ToString()));
        }



        public static DataSet GetAllSubjectsByStandard(string Standard_Code)
        {

            SqlParameter p1 = new SqlParameter("@Standard_Code", Standard_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLMSSubjectByStandard", p1));

        }

       
      
        
        #endregion

        #region "Classroom Creation"
        public static DataSet GetPremisesMasterBy_Country_State_City(string Country_Code, string State_Code, string City_Code, string Location_Code, string PremisesName, string PremisesType_Id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Country_Code", Country_Code);
            SqlParameter p2 = new SqlParameter("@State_Code", State_Code);
            SqlParameter p3 = new SqlParameter("@City_Code", City_Code);
            SqlParameter p4 = new SqlParameter("@Location_Code", Location_Code);
            SqlParameter p5 = new SqlParameter("@PremisesName", PremisesName);
            SqlParameter p6 = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            SqlParameter p7 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPremisesMasterBy_Country_State_City", p1, p2, p3, p4, p5, p6, p7));
        }
               public static DataSet GetPremisesMaster_ByPKey(string PKey, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPremisesMaster_ByPKey", p1, p2));
        }
                public static DataSet GetClassroomMaster_ByPKey(string PKey, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetClassroomMaster_ByPKey", p1, p2));
        }
                public static DataSet GetAllActivePremisesType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActivePremisesType"));
        }
                public static DataSet GetAllActiveClassroomType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveClassroomType"));
        }
                //public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
        //{
        //    SqlParameter p1 = new SqlParameter("@user_id", User_ID);
        //    SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
        //    SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
        //    SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
        //    SqlParameter p5 = new SqlParameter("@Flag", Flag);

        //    if (DBName == "MTEducare")
        //    {
        //        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center_MTEducare", p1, p2, p3, p4, p5));
        //    }
        //    else
        //    {
        //        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));
        //    }

        //}
                public static DataSet GetAllActiveState(string Country_Code)
        {
            SqlParameter p1 = new SqlParameter("@Countrycode", Country_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStatebyCountry", p1));
        }
                public static DataSet GetAllActiveCity(string State_Code)
        {
            SqlParameter p1 = new SqlParameter("@Statecode", State_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCitybyState", p1));
        }
                public static DataSet GetAllActiveLocation(string City_Code)
        {
            SqlParameter p1 = new SqlParameter("@CityCode", City_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLocationByCity", p1));
        }
                public static string Insert_Premises(string CompanyCode, string Country_Code, string State_Code, string City_Code, string Location_Code, string Premises_LName, string Premises_SName, double Area_inSQFeet, string PremisesType_Id, int IsActive,
                string Premises_Address, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@CompanyCode", CompanyCode);
            p[1] = new SqlParameter("@Country_Code", Country_Code);
            p[2] = new SqlParameter("@State_Code", State_Code);
            p[3] = new SqlParameter("@City_Code", City_Code);
            p[4] = new SqlParameter("@Location_Code", Location_Code);
            p[5] = new SqlParameter("@Premises_LName", Premises_LName);
            p[6] = new SqlParameter("@Premises_SName", Premises_SName);
            p[7] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[8] = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@Premises_Address", Premises_Address);
            p[12] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertPremises", p);
            return (p[12].Value.ToString());
        }
                public static string Update_Premises(string Premises_Code, string Location_Code, string Premises_LName, string Premises_SName, double Area_inSQFeet, string PremisesType_Id, int IsActive, string Premises_Address, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@Premises_Code", Premises_Code);
            p[1] = new SqlParameter("@Location_Code", Location_Code);
            p[2] = new SqlParameter("@Premises_LName", Premises_LName);
            p[3] = new SqlParameter("@Premises_SName", Premises_SName);
            p[4] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[5] = new SqlParameter("@PremisesType_Id", PremisesType_Id);
            p[6] = new SqlParameter("@IsActive", IsActive);
            p[7] = new SqlParameter("@CreatedBy", CreatedBy);
            p[8] = new SqlParameter("@Premises_Address", Premises_Address);
            p[9] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[9].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdatePremises", p);
            return (p[9].Value.ToString());
        }
                public static DataSet GetAllActiveActivity(string ClassroomType_Id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllActiveActivityType", p1, p2));
        }
                public static DataSet GetAllActiveUnitOfMeasurement()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActiveUnitOfMeasurement"));
        }
                public static string Insert_Classroom(string Classroom_LName, string Classroom_SName, double Length_inFeet, double Width_inFeet, double Height_inFeet, double Area_inSQFeet, string ClassroomType_Id, int IsActive, string Premises_Code, string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@Classroom_LName", Classroom_LName);
            p[1] = new SqlParameter("@Classroom_SName", Classroom_SName);
            p[2] = new SqlParameter("@Length_inFeet", Length_inFeet);
            p[3] = new SqlParameter("@Width_inFeet", Width_inFeet);
            p[4] = new SqlParameter("@Height_inFeet", Height_inFeet);
            p[5] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[6] = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            p[7] = new SqlParameter("@IsActive", IsActive);
            p[8] = new SqlParameter("@Premises_Code", Premises_Code);
            p[9] = new SqlParameter("@CreatedBy", CreatedBy);
            p[10] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[10].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom", p);
            return (p[10].Value.ToString());
        }
                public static int Insert_ClassroomCentre(string Classroom_Code, string Primary_Centre_Code, string Centre_Code, string Created_By)
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Primary_Centre_Code", Primary_Centre_Code);
            p[2] = new SqlParameter("@Centre_Code", Centre_Code);
            p[3] = new SqlParameter("@Created_By", Created_By);

            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Centre", p);
            return (int.Parse(p[4].Value.ToString()));
        }
                public static int Insert_ClassroomCapacity(string Classroom_Code, string Activity_Id, int Capacity, string UOM)
        {

            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Activity_Id", Activity_Id);
            p[2] = new SqlParameter("@Capacity", Capacity);
            p[3] = new SqlParameter("@UOM", UOM);

            p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Capacity", p);
            return (int.Parse(p[4].Value.ToString()));
        }
                public static string Update_Classroom(string Classroom_Code, string Premises_Code, string Classroom_LName, string Classroom_SName, double Length_inFeet, double Width_inFeet, double Height_inFeet, double Area_inSQFeet, string ClassroomType_Id, int IsActive,
                string CreatedBy)
        {

            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
            p[1] = new SqlParameter("@Premises_Code", Premises_Code);
            p[2] = new SqlParameter("@Classroom_LName", Classroom_LName);
            p[3] = new SqlParameter("@Classroom_SName", Classroom_SName);
            p[4] = new SqlParameter("@Length_inFeet", Length_inFeet);
            p[5] = new SqlParameter("@Width_inFeet", Width_inFeet);
            p[6] = new SqlParameter("@Height_inFeet", Height_inFeet);
            p[7] = new SqlParameter("@Area_inSQFeet", Area_inSQFeet);
            p[8] = new SqlParameter("@ClassroomType_Id", ClassroomType_Id);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdateClassroom", p);
            return (p[11].Value.ToString());
        }
                public static DataSet GetAllActiveCountry()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCountry"));
        }
                //public static int Insert_ClassroomCentre(string Classroom_Code, string Primary_Centre_Code, string Centre_Code, string Created_By)
        //{

        //    SqlParameter[] p = new SqlParameter[5];
        //    p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
        //    p[1] = new SqlParameter("@Primary_Centre_Code", Primary_Centre_Code);
        //    p[2] = new SqlParameter("@Centre_Code", Centre_Code);
        //    p[3] = new SqlParameter("@Created_By", Created_By);

        //    p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
        //    p[4].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Centre", p);
        //    return (int.Parse(p[4].Value.ToString()));
        //}




        //public static int Insert_ClassroomCapacity(string Classroom_Code, string Activity_Id, int Capacity, string UOM)
        //{

        //    SqlParameter[] p = new SqlParameter[5];
        //    p[0] = new SqlParameter("@Classroom_Code", Classroom_Code);
        //    p[1] = new SqlParameter("@Activity_Id", Activity_Id);
        //    p[2] = new SqlParameter("@Capacity", Capacity);
        //    p[3] = new SqlParameter("@UOM", UOM);

        //    p[4] = new SqlParameter("@Result", SqlDbType.BigInt);
        //    p[4].Direction = ParameterDirection.Output;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertClassroom_Capacity", p);
        //    return (int.Parse(p[4].Value.ToString()));
        //}
        #endregion  

        public static DataSet GetStudentDetailsBySBEntrycode(string SBEntrycode, int flag)
        {
            SqlParameter p1 = new SqlParameter("@SBEntryCode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStudentDetailsBySBEntryCode", p1, p2));
        }

        /// <summary>
        /// LMS Integration
        /// </summary>
        /// <param name="Pkey"></param>
        /// <returns></returns>
        public static DataSet LMS_PassAllStudentdetailstoLMSApp(string Pkey)
        {
            SqlParameter p1 = new SqlParameter("@PKey", Pkey);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_LMS_PassAllStudentdetailstoLMSApp", p1));
        }

        public static DataSet LMS_PassAllStudentdetailstoLMSApponConfirmation(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_LMS_PassAllStudentdetails", p1));
        }

        public static DataSet GetAllChaptersBy_Division_Year_Standard_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@SubjectCode", SubjectCode);
                       
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllChaptersBy_Division_Year_Standard_Subject_New", p1, p2, p3, p4));
        }

        public static DataSet GetAllActivePartnerTitle()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllActivePartnerTitle"));
        }

        public static DataSet GetPartnerMaster_ByPKey(string PKey, string User_ID, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);
            SqlParameter p2 = new SqlParameter("@User_ID", User_ID);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPartnerMaster_ByPKey", p1, p2, p3));
        }
        public static DataSet GetPartnerMasterBy_Country_State_City(string Country_Code, string State_Code, string City_Code, string Location_Code, string PartnerName, string HandPhoneNo, int ActiveStatus, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Country_Code", Country_Code);
            SqlParameter p2 = new SqlParameter("@State_Code", State_Code);
            SqlParameter p3 = new SqlParameter("@City_Code", City_Code);
            SqlParameter p4 = new SqlParameter("@Location_Code", Location_Code);
            SqlParameter p5 = new SqlParameter("@PartnerName", PartnerName);
            SqlParameter p6 = new SqlParameter("@HandPhone", HandPhoneNo);
            SqlParameter p7 = new SqlParameter("@ActiveStatus", ActiveStatus);
            SqlParameter p8 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetPartnerMasterBy_Country_State_City", p1, p2, p3, p4, p5, p6, p7, p8));
        }


        public static string Update_Partner(string Partner_Code, string CompanyCode, string Title, string FirstName, string MiddleName, string LastName, string Gender, System.DateTime DOB, System.DateTime DOJ, string Qualification,
        string HandPhone1, string HandPhone2, string Landline, string EmailId, string FlatNo, string BuildingName, string StreetName, string Country_Code, string State_Code, string City_Code,
        string Location_Code, string Pincode, int IsActive, string CreatedBy, string ActivityCode, string DivisionCode, string EmployeeNo, string Area_Name, string Remarks, string AccountNumber, string IFSCCode, string BranchName, string PanNumber)
        {

            SqlParameter[] p = new SqlParameter[34];
            p[0] = new SqlParameter("@CompanyCode", CompanyCode);
            p[1] = new SqlParameter("@Title", Title);
            p[2] = new SqlParameter("@FirstName", FirstName);
            p[3] = new SqlParameter("@MiddleName", MiddleName);
            p[4] = new SqlParameter("@LastName", LastName);
            p[5] = new SqlParameter("@Gender", Gender);
            p[6] = new SqlParameter("@DOB", DOB);
            p[7] = new SqlParameter("@DOJ", DOJ);
            p[8] = new SqlParameter("@Qualification", Qualification);
            p[9] = new SqlParameter("@HandPhone1", HandPhone1);
            p[10] = new SqlParameter("@HandPhone2", HandPhone2);
            p[11] = new SqlParameter("@Landline", Landline);
            p[12] = new SqlParameter("@EmailId", EmailId);
            p[13] = new SqlParameter("@FlatNo", FlatNo);
            p[14] = new SqlParameter("@BuildingName", BuildingName);
            p[15] = new SqlParameter("@StreetName", StreetName);
            p[16] = new SqlParameter("@Country_Code", Country_Code);
            p[17] = new SqlParameter("@State_Code", State_Code);
            p[18] = new SqlParameter("@City_Code", City_Code);
            p[19] = new SqlParameter("@Location_Code", Location_Code);
            p[20] = new SqlParameter("@Pincode", Pincode);
            p[21] = new SqlParameter("@IsActive", IsActive);
            p[22] = new SqlParameter("@CreatedBy", CreatedBy);
            p[23] = new SqlParameter("@ActivityCode", ActivityCode);
            p[24] = new SqlParameter("@DivisionCode", DivisionCode);
            p[25] = new SqlParameter("@EmployeeNo", EmployeeNo);
            p[26] = new SqlParameter("@Area_Name", Area_Name);
            p[27] = new SqlParameter("@Remarks", Remarks);
            p[28] = new SqlParameter("@Partner_Code", Partner_Code);
            p[29] = new SqlParameter("@BankACNo", AccountNumber);
            p[30] = new SqlParameter("@BankIFSECode", IFSCCode);
            p[31] = new SqlParameter("@BankBranch", BranchName);
            p[32] = new SqlParameter("@PANNo", PanNumber);
            p[33] = new SqlParameter("@Result", SqlDbType.VarChar, 10);
            p[33].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UpdatePartner", p);
            return (p[33].Value.ToString());
        }




        public static DataSet GetAcademic_YearByPkey(string Academic_Year, string ID, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Academic_Year", Academic_Year);
            SqlParameter p2 = new SqlParameter("@ID", ID);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Academic_Year", p1, p2, p3));
        }
        public static int InsertUpdateAcademic_Year(string Id, string Description, int Is_Active, string Created_By, int flag)
        {
            SqlParameter p1 = new SqlParameter("@ID", Id);
            SqlParameter p2 = new SqlParameter("@Description", Description);
            SqlParameter p3 = new SqlParameter("@Is_Active", Is_Active);     
            SqlParameter p4 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p5 = new SqlParameter("@Flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_UpdateAcademic_Year", p1, p2, p3,p4,p5));
        }

        public static int InsertUpdateMedium(string Id, string MediumName, int Is_Active, string DisplayName, string ShortName, string Description, string Created_By, string flag)
        {
            SqlParameter p1 = new SqlParameter("@Id", Id);
            SqlParameter p2 = new SqlParameter("@MediumName", MediumName);
            SqlParameter p3 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p4 = new SqlParameter("@DisplayName", DisplayName);
            SqlParameter p5 = new SqlParameter("@ShortName", ShortName);
            SqlParameter p6 = new SqlParameter("@Description", Description);
            SqlParameter p7 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p8 = new SqlParameter("@flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Medium", p1, p2, p3, p4, p5, p6, p7, p8));
        }

        public static DataSet Get_Medium_Details(string MediumName)
        {
            SqlParameter p1 = new SqlParameter("@MediumName", MediumName);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetMediumDetail", p1));
        }

        public static DataSet Get_Medium_DetailsByPKey(string PKeyId)
        {
            SqlParameter p1 = new SqlParameter("@Id", PKeyId);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetMediumDetailByPKey", p1));
        }



        public static int Insert_Board(string boardname, string boarddisplayname, string boardshortname, string boarddescription, string boardsequenceno, string createdby, int Active, string flag, string id)
        {
            SqlParameter p1 = new SqlParameter("@BoardName", boardname);
            SqlParameter p2 = new SqlParameter("@BoardDisplayName", boarddisplayname);
            SqlParameter p3 = new SqlParameter("@BoardShortName", boardshortname);
            SqlParameter p4 = new SqlParameter("@BoardDescription", boarddescription);
            SqlParameter p5 = new SqlParameter("@BoardSequenceno", boardsequenceno);
            SqlParameter p6 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p7 = new SqlParameter("@Active", Active);
            SqlParameter p8 = new SqlParameter("@Flag", flag);
            SqlParameter p9 = new SqlParameter("@id", id);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Board", p1, p2, p3, p4, p5, p6, p7, p8, p9));

        }
        // GET BOARD DETAILS FROM CONFIGURATION ENGINE
        public static DataSet GetBoardDetails(string boardname, string id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@boardname", boardname);
            SqlParameter p2 = new SqlParameter("@id", id);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_BoardDetails", p1, p2, p3));
        }


        public static int InsertUpdateCourseCategory(string Id, string CCName, int Is_Active, string CCDisplayName, string CCSequenceNo, string CCDescription, string Created_By, string flag)
        {
            SqlParameter p1 = new SqlParameter("@CCId", Id);
            SqlParameter p2 = new SqlParameter("@CCName", CCName);
            SqlParameter p3 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p4 = new SqlParameter("@CCDisplayName", CCDisplayName);
            SqlParameter p5 = new SqlParameter("@CCSequenceNo", CCSequenceNo);
            SqlParameter p6 = new SqlParameter("@CCDescription", CCDescription);
            SqlParameter p7 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p8 = new SqlParameter("@flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_CourseCategory", p1, p2, p3, p4, p5, p6, p7, p8));
        }

        public static DataSet Get_CourseCategory(string CourseCategoryName, int flag)
        {
            SqlParameter p1 = new SqlParameter("@CCName", CourseCategoryName);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetCourseCategory", p1, p2));
        }

        public static DataSet Get_CourseCategoryByPKey(string PKeyId)
        {
            SqlParameter p1 = new SqlParameter("@PKeyId", PKeyId);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetCourseCategoryByPKey", p1));
        }

        public static int InsertUpdateCourseDetail(string Course_Code, string CourseCateogryId, string Board_ID, string Medium_ID, string Division_Code, string Course_Name, string Course_Display_Name, string Course_Short_Name, string Course_Description, string CourseSequenceNo, int Is_Active, string Created_By, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Course_Code", Course_Code);
            SqlParameter p2 = new SqlParameter("@CourseCateogryId", CourseCateogryId);
            SqlParameter p3 = new SqlParameter("@Board_ID", Board_ID);
            SqlParameter p4 = new SqlParameter("@Medium_ID", Medium_ID);
            SqlParameter p5 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p6 = new SqlParameter("@Course_Name", Course_Name);
            SqlParameter p7 = new SqlParameter("@Course_Display_Name", Course_Display_Name);
            SqlParameter p8 = new SqlParameter("@Course_Short_Name", Course_Short_Name);
            SqlParameter p9 = new SqlParameter("@Course_Description", Course_Description);
            SqlParameter p10 = new SqlParameter("@CourseSequenceNo", CourseSequenceNo);
            SqlParameter p11 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p12 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p13 = new SqlParameter("@flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_CourseDetail", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
        }

        public static DataSet Get_CourseDetail(string CourseName, string CourseCateogryId, string Board_ID, string Medium_ID, string Division_Code, string Course_Code, string flag, string user_id)
        {
            SqlParameter p1 = new SqlParameter("@Course_Name", CourseName);
            SqlParameter p2 = new SqlParameter("@CourseCateogryId", CourseCateogryId);
            SqlParameter p3 = new SqlParameter("@Board_ID", Board_ID);
            SqlParameter p4 = new SqlParameter("@Medium_ID", Medium_ID);
            SqlParameter p5 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p6 = new SqlParameter("@Course_Code", Course_Code);
            SqlParameter p7 = new SqlParameter("@flag", flag);
            SqlParameter p8 = new SqlParameter("@user_id", user_id);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetCourseDetail", p1, p2, p3, p4, p5, p6, p7, p8));
        }



        public static DataSet GetCourseName(string coursecategoryid, string board, string medium, string flag)
        {
            SqlParameter p1 = new SqlParameter("@CourseCateogryId", coursecategoryid);
            SqlParameter p2 = new SqlParameter("@BOARD", board);
            SqlParameter p3 = new SqlParameter("@MEDIUM", medium);
            SqlParameter p4 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Course", p1, p2, p3, p4));
        }
        public static DataSet GetSubject_ByCourse(string coursecategoryid, string subjectcode, string recordnumber, string flag)
        {
            SqlParameter p1 = new SqlParameter("@coursecode", coursecategoryid);
            SqlParameter p2 = new SqlParameter("@subjectcode", subjectcode);
            SqlParameter p3 = new SqlParameter("@recordnumber", recordnumber);
            SqlParameter p4 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Subject", p1, p2, p3, p4));
        }

        public static int Insert_Update_Subject(string subjectname, string coursecode, string coursename, string createdby, string subjectdisplayname, string isactive, string flag, string subjectcode, string coursesequencno, string RefferenceCourseCode, int IsRefference, string recordnumber)
        {
            SqlParameter p1 = new SqlParameter("@SubjectName", subjectname);
            SqlParameter p2 = new SqlParameter("@Course_Code", coursecode);
            SqlParameter p3 = new SqlParameter("@Course_Name", coursename);
            SqlParameter p4 = new SqlParameter("@Created_By", createdby);
            SqlParameter p5 = new SqlParameter("@SubjectDisplayName", subjectdisplayname);
            SqlParameter p6 = new SqlParameter("@Is_Active", isactive);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            SqlParameter p8 = new SqlParameter("@SubjectCode", subjectcode);
            SqlParameter p9 = new SqlParameter("@coursesequenceno", coursesequencno);
            SqlParameter p10 = new SqlParameter("@RefferenceCourseCode", RefferenceCourseCode);
            SqlParameter p11 = new SqlParameter("@recordnumber", recordnumber);
            SqlParameter p12 = new SqlParameter("@IsReference", IsRefference);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_Subject", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

        }


        public static DataSet GetAllTopicsBy_Division_Year_Standard_Subject_Chapter(string Division_Code, string Standard_Code, string SubjectCode, string  ChapterCode ,string flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllTopicsBy_Division_Year_Standard_Subject_Chapter", p1, p2, p3, p4,p5));
        }

        public static DataSet GetAllSubTopicsBy_Division_Year_Standard_Subject_Chapter_Topic(string Division_Code, string Standard_Code, string SubjectCode, string ChapterCode,string TopicCode , string flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@TopicCode", TopicCode);            
            SqlParameter p6 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubTopicsBy_Division_Year_Standard_Subject_Chapter_Topic", p1, p2, p3, p4, p5,p6));
        }


        public static DataSet GetAllModuleBy_Division_Year_Standard_Subject_Chapter_Topic_SubTopic(string Division_Code, string Standard_Code, string SubjectCode, string ChapterCode, string TopicCode, string SubTopicCode ,string flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@TopicCode", TopicCode);
            SqlParameter p6 = new SqlParameter("@SubTopic_Code", SubTopicCode);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllModuleBy_Division_Year_Standard_Subject_Chapter_Topic_SubTopic", p1, p2, p3, p4, p5, p6,p7));
        }


        public static DataSet GetAcademiceYear(string Academic_Year, string id, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Academic_Year", Academic_Year);
            SqlParameter p2 = new SqlParameter("@ID", id);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Academic_Year", p1, p2, p3));
        }

        public static DataSet GetClassroomProducts(string Division_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetClassroomProducts", p1, p2));
        }

        public static DataTable GetProductCatTable()
        {
            // Here we create a DataTable with two columns.
            DataTable table = new DataTable();

            table.Columns.Add("Product_Category_ID", typeof(string));
            table.Columns.Add("Product_Category", typeof(string));


            // Here we add Two DataRows.            
            table.Rows.Add("LMS", "LMS");
            table.Rows.Add("NONLMS", "NONLMS");

            return table;
        }

        public static DataSet Get_Medium_DetailsMaster(string MediumName, string flag)
        {
            SqlParameter p1 = new SqlParameter("@MediumName", MediumName);
            SqlParameter p2 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetMediumDetail", p1, p2));
        }

        public static int InsertUpdateLMSProduct(string ProductCode, string CourseCateogryCode, string BoardCode, string MediumCode, string CourseCode, string AcademicYearCode, string DivisionCode, string ClassRoomProductCode, string ProductCatCode, string SKUCode, string ProductName, string ProductDescription, string Price, string BucketName, string ExamMonth, string ExamYear, string FromDate, string ToDate, int MarketFlag, string ProductDeliveryModeCode, int Is_Active, string Created_By, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter p2 = new SqlParameter("@CourseCateogryCode", CourseCateogryCode);
            SqlParameter p3 = new SqlParameter("@BoardCode", BoardCode);
            SqlParameter p4 = new SqlParameter("@MediumCode", MediumCode);
            SqlParameter p5 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p6 = new SqlParameter("@AcademicYearCode", AcademicYearCode);
            SqlParameter p7 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter p8 = new SqlParameter("@ClassRoomProductCode", ClassRoomProductCode);
            SqlParameter p9 = new SqlParameter("@ProductCatCode", ProductCatCode);
            SqlParameter p10 = new SqlParameter("@SKUCode", SKUCode);
            SqlParameter p11 = new SqlParameter("@ProductName", ProductName);
            SqlParameter p12 = new SqlParameter("@ProductDescription", ProductDescription);
            SqlParameter p13 = new SqlParameter("@Price", Price);
            SqlParameter p14 = new SqlParameter("@BucketName", BucketName);
            SqlParameter p15 = new SqlParameter("@ExamMonth", ExamMonth);
            SqlParameter p16 = new SqlParameter("@ExamYear", ExamYear);
            SqlParameter p17 = new SqlParameter("@FromDate", FromDate);
            SqlParameter p18 = new SqlParameter("@ToDate", ToDate);
            SqlParameter p19 = new SqlParameter("@MarketFlag", MarketFlag);
            SqlParameter p20 = new SqlParameter("@ProductDeliveryModeCode", ProductDeliveryModeCode);
            SqlParameter p21 = new SqlParameter("@IsActive", Is_Active);
            SqlParameter p22 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p23 = new SqlParameter("@flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_LMSProductMaster", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23));
        }


        public static DataSet Get_LMSProduct(string ProductCode, string CourseCategoryCode, string @BoardCode, string Medium_ID, string CourseCode, string AcademicYearCode, string DivisionCode, string flag)
        {
            SqlParameter p1 = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter p2 = new SqlParameter("@CourseCategoryCode", CourseCategoryCode);
            SqlParameter p3 = new SqlParameter("@BoardCode", BoardCode);
            SqlParameter p4 = new SqlParameter("@MediumCode", Medium_ID);
            SqlParameter p5 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p6 = new SqlParameter("@AcademicYearCode", AcademicYearCode);
            SqlParameter p7 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter p8 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_LMSProduct", p1, p2, p3, p4, p5, p6, p7, p8));
        }

#region Functions_SchedulingEngine

        public static DataSet GetFaculty_Subject(string PKeyId, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKeyId", PKeyId);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Get_Faculty_Subject", p1, p2));
        }

        public static int DeleteFaculty_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode, string FacultyCode)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Subject_Code", SubjectCode);
            SqlParameter p5 = new SqlParameter("@Partner_Code", FacultyCode);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Delete_Faculty_Subject", p1, p2, p3, p4, p5));


            //return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Delete_Faculty_Subject", p1, p2,p3,p4,p5));
        }

        public static DataSet GetFacultyByDivisionCode(string DivisionCode)
        {

            SqlParameter p1 = new SqlParameter("@DivisionCode", DivisionCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetFaculty_By_DivisionCode", p1));
        }

        public static int InsertFaculty_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode, string FacultyCode, string Created_By, string ColorCode, string PaymentRate, string ShortName)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Subject_Code", SubjectCode);
            SqlParameter p5 = new SqlParameter("@Partner_Code", FacultyCode);
            SqlParameter p6 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p7 = new SqlParameter("@ColorCode", ColorCode);
            SqlParameter p8 = new SqlParameter("@PaymentRate", PaymentRate);
            SqlParameter p9 = new SqlParameter("@ShortName", ShortName);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Insert_Faculty_Subject", p1, p2, p3, p4, p5, p6, p7, p8, p9));
        }

        public static int UpdateFaculty_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode, string FacultyCode, string Altered_By, string ColorCode, string PaymentRate, string ShortName)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Subject_Code", SubjectCode);
            SqlParameter p5 = new SqlParameter("@Partner_Code", FacultyCode);
            SqlParameter p6 = new SqlParameter("@Altered_By", Altered_By);
            SqlParameter p7 = new SqlParameter("@ColorCode", ColorCode);
            SqlParameter p8 = new SqlParameter("@PaymentRate", PaymentRate);
            SqlParameter p9 = new SqlParameter("@ShortName", ShortName);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Update_Faculty_Subject", p1, p2, p3, p4, p5, p6, p7, p8, p9));
        }


        public static int DeleteSchedule_Horizon(string PKey)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKey);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Delete_Schedule_Horizon", p1));

        }


        public static DataSet Get_Schedule_Horizon(string PKeyId, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@PKey", PKeyId);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Get_Schedule_Horizon", p1, p2));
        }


        public static DataSet GetLMSProductByCourse_AcadYear(string CourseCode, string AcademicYear)
        {

            SqlParameter p1 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p2 = new SqlParameter("@AcademicYear", AcademicYear);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLMSProductByCourse_AcadYear", p1, p2));
        }

        public static DataSet GetActivityType()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_GetActivityType"));
        }

        public static DataSet GetSchedule_Horizon_Type()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_GetSchedule_Horizon_Type"));
        }





        public static int InsertSchedule_Horizon(string Division_Code, string YearName, string StandardCode, string Schedule_Horizon_Type_Code, string Activity_Id, string Created_By, string Start_Date, string End_Date, string Schedule_Horizon_Name, int WeekDay_Count, int WeekDay_Session_Count_PerDay, int Holiday_Count, int Holiday_Session_Count_PerDay, int Total_Session_Count, int Session_Duration, string LMSProductCode)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", YearName);
            SqlParameter p3 = new SqlParameter("@Stream_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Schedule_Horizon_Type_Code", Schedule_Horizon_Type_Code);
            SqlParameter p5 = new SqlParameter("@Activity_Id", Activity_Id);
            SqlParameter p6 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p7 = new SqlParameter("@Start_Date", Start_Date);
            SqlParameter p8 = new SqlParameter("@End_Date", End_Date);
            SqlParameter p9 = new SqlParameter("@Schedule_Horizon_Name", Schedule_Horizon_Name);
            SqlParameter p10 = new SqlParameter("@WeekDay_Count", WeekDay_Count);
            SqlParameter p11 = new SqlParameter("@WeekDay_Session_Count_PerDay", WeekDay_Session_Count_PerDay);
            SqlParameter p12 = new SqlParameter("@Holiday_Count", Holiday_Count);
            SqlParameter p13 = new SqlParameter("@Holiday_Session_Count_PerDay", Holiday_Session_Count_PerDay);
            SqlParameter p14 = new SqlParameter("@Total_Session_Count", Total_Session_Count);
            SqlParameter p15 = new SqlParameter("@Session_Duration", Session_Duration);
            SqlParameter p16 = new SqlParameter("@LMSProductCode", LMSProductCode);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Insert_Schedule_Horizon", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
        }

        public static int UpdateSchedule_Horizon(string Division_Code, string YearName, string StandardCode, string Schedule_Horizon_Type_Code, string Activity_Id, string Created_By, string Start_Date, string End_Date, string Schedule_Horizon_Name, int WeekDay_Count, int WeekDay_Session_Count_PerDay, int Holiday_Count, int Holiday_Session_Count_PerDay, int Total_Session_Count, int Session_Duration, string LMSProductCode)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", YearName);
            SqlParameter p3 = new SqlParameter("@Stream_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@Schedule_Horizon_Type_Code", Schedule_Horizon_Type_Code);
            SqlParameter p5 = new SqlParameter("@Activity_Id", Activity_Id);
            SqlParameter p6 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p7 = new SqlParameter("@Start_Date", Start_Date);
            SqlParameter p8 = new SqlParameter("@End_Date", End_Date);
            SqlParameter p9 = new SqlParameter("@Schedule_Horizon_Name", Schedule_Horizon_Name);
            SqlParameter p10 = new SqlParameter("@WeekDay_Count", WeekDay_Count);
            SqlParameter p11 = new SqlParameter("@WeekDay_Session_Count_PerDay", WeekDay_Session_Count_PerDay);
            SqlParameter p12 = new SqlParameter("@Holiday_Count", Holiday_Count);
            SqlParameter p13 = new SqlParameter("@Holiday_Session_Count_PerDay", Holiday_Session_Count_PerDay);
            SqlParameter p14 = new SqlParameter("@Total_Session_Count", Total_Session_Count);
            SqlParameter p15 = new SqlParameter("@Session_Duration", Session_Duration);
            SqlParameter p16 = new SqlParameter("@LMSProductCode", LMSProductCode);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SE_Update_Schedule_Horizon", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
        }

        public static DataSet GetYearDistributionsheetBy_Division_Year_Standard_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode, string Center_Code)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p5 = new SqlParameter("@Center_Code", Center_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetYearDistributionsheetBy_Division_Year_Standard_Subject", p1, p2, p3, p4, p5));
        }

        public static int Insert_YearDistribution(string Division_Code, string Acad_Year, string Standard_Code, string LMSProductCode, string SchedulHorizonTypeCode, string CenterCode, string SubjectCode, string ChapterCode, string TeacherShortName, string Created_By)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
            SqlParameter p3 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p4 = new SqlParameter("@LMSProductCode", LMSProductCode);
            SqlParameter p5 = new SqlParameter("@SchedulHorizonTypeCode", SchedulHorizonTypeCode);
            SqlParameter p6 = new SqlParameter("@CenterCode", CenterCode);
            SqlParameter p7 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p8 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p9 = new SqlParameter("@TeacherShortName", TeacherShortName);
            SqlParameter p10 = new SqlParameter("@Created_By", Created_By);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_SE_Insert_YearDistribution", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10));
        }

        public static DataSet GetYearDistributionsheetBy_Division_Year_Standard_Subject_Center(string Division_Code, string YearName, string SubjectCode, string Center_Code, string Stream_Code, string Scheduling_Horizon_TypeCode)
        {

            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p5 = new SqlParameter("@Stream_Code", Stream_Code);
            SqlParameter p6 = new SqlParameter("@Scheduling_Horizon_TypeCode", Scheduling_Horizon_TypeCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetYearDistributionsheetBy_Division_Year_Standard_Subject_Center", p1, p2, p3, p4, p5, p6));
        }
#endregion




        public static string Insert_UpdateLessonPlanHeader(string DivisionCode, string CourseCode, string SubjectCode, string ChapterCode, string TopicCode, string SubTopicCode, string LessonPlanCode, string LessonPlanName, string LessonPlanDisplayName, string LessonPlanDescription, bool EOC, int Is_Active, string Created_By, string Pkey, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p2 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@TopicCode", TopicCode);
            SqlParameter p6 = new SqlParameter("@SubTopicCode", SubTopicCode);
            SqlParameter p7 = new SqlParameter("@LessonPlanCode", LessonPlanCode);
            SqlParameter p8 = new SqlParameter("@LessonPlanName", LessonPlanName);
            SqlParameter p9 = new SqlParameter("@LessonPlanDisplayName", LessonPlanDisplayName);
            SqlParameter p10 = new SqlParameter("@LessonPlanDescription", LessonPlanDescription);
            SqlParameter p11 = new SqlParameter("@EOC", EOC);
            SqlParameter p12 = new SqlParameter("@IsActive", Is_Active);
            SqlParameter p13 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p14 = new SqlParameter("@PKey", Pkey);
            SqlParameter p15 = new SqlParameter("@flag", Flag);
            return Convert.ToString(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_LessonPlanHeader", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15));
        }

        public static string Insert_LessonPlanContent(string DivisionCode, string CourseCode, string SubjectCode, string ChapterCode, string TopicCode, string SubTopicCode,
            string ModuleCode, string LessonPlanCode, string ProductContentCode, string VersionId, string ProductContentName, string ProductContentDisplayName,
            string ProductContentDescription, string ProductCode, string ProductContentFileUrl, string ProductContentImageUrl, string KeyPath, string LocationCode,
            string ContentTypeCode,string TestCode,string Dimension1,string Dimension1Unit,string Dimension1Value,string Dimension2,string Dimension2Unit,string Dimension2Value,
            string Dimension3,string Dimension3Unit,string Dimension3Value,string Dimension4,string Dimension4Unit,string Dimension4Value,string Dimension5,string Dimension5Unit,string Dimension5Value,
            int Is_Active, string Created_By, 
            string Pkey, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p2 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@TopicCode", TopicCode);
            SqlParameter p6 = new SqlParameter("@SubTopicCode", SubTopicCode);
            SqlParameter p7 = new SqlParameter("@ModuleCode", ModuleCode);
            SqlParameter p8 = new SqlParameter("@LessonPlanCode", LessonPlanCode);
            SqlParameter p9 = new SqlParameter("@ProductContentCode", ProductContentCode);
            SqlParameter p10 = new SqlParameter("@VersionId", VersionId);
            SqlParameter p11 = new SqlParameter("@ProductContentName", ProductContentName);
            SqlParameter p12 = new SqlParameter("@ProductContentDisplayName", ProductContentDisplayName);
            SqlParameter p13 = new SqlParameter("@ProductContentDescription", ProductContentDescription);
            SqlParameter p14 = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter p15 = new SqlParameter("@ProductContentFileUrl", ProductContentFileUrl);
            SqlParameter p16 = new SqlParameter("@ProductContentImageUrl", ProductContentImageUrl);
            SqlParameter p17 = new SqlParameter("@KeyPath", KeyPath);
            SqlParameter p18 = new SqlParameter("@LocationCode", LocationCode);
            SqlParameter p19 = new SqlParameter("@ContentTypeCode", ContentTypeCode);
            SqlParameter p20 = new SqlParameter("@TestCode", TestCode);
            SqlParameter p21 = new SqlParameter("@Dimension1", Dimension1);
            SqlParameter p22 = new SqlParameter("@Dimension1Unit", Dimension1Unit);
            SqlParameter p23 = new SqlParameter("@Dimension1Value", Dimension1Value);
            SqlParameter p24 = new SqlParameter("@Dimension2", Dimension2);
            SqlParameter p25 = new SqlParameter("@Dimension2Unit", Dimension2Unit);
            SqlParameter p26 = new SqlParameter("@Dimension2Value", Dimension2Value);
            SqlParameter p27 = new SqlParameter("@Dimension3", Dimension3);
            SqlParameter p28 = new SqlParameter("@Dimension3Unit", Dimension3Unit);
            SqlParameter p29 = new SqlParameter("@Dimension3Value", Dimension3Value);
            SqlParameter p30 = new SqlParameter("@Dimension4", Dimension4);
            SqlParameter p31 = new SqlParameter("@Dimension4Unit", Dimension4Unit);
            SqlParameter p32 = new SqlParameter("@Dimension4Value", Dimension4Value);
            SqlParameter p33 = new SqlParameter("@Dimension5", Dimension5);
            SqlParameter p34 = new SqlParameter("@Dimension5Unit", Dimension5Unit);
            SqlParameter p35 = new SqlParameter("@Dimension5Value", Dimension5Value);
            SqlParameter p36 = new SqlParameter("@IsActive", Is_Active);
            SqlParameter p37 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p38 = new SqlParameter("@PKey", Pkey);
            SqlParameter p39 = new SqlParameter("@flag", Flag);

            return Convert.ToString(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_LessonPlanContent", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15,
                p16,p17,p18,p19,p20,p21,p22,p23,p24,p25,p26,p27,p28,p29,p30,p31,p32,p33,p34,p35,p36,p37,p38,p39));
        }

        


        public static DataSet GetLessonPlanHeader(string Pkey, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Pkey", Pkey);
            SqlParameter p2 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLessonPlanHeader", p1, p2));
        }

        public static DataSet GetLessonPlanContent(string Pkey,int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Pkey", Pkey);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);  
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLessonPlanContent", p1,p2));
        }


        public static DataSet GetTopicDetails(string division, string standard, string subject, string chapter, string topic, string flag)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", division);
            SqlParameter p2 = new SqlParameter("@standard", standard);
            SqlParameter p3 = new SqlParameter("@subject", subject);
            SqlParameter p4 = new SqlParameter("@chatper", chapter);
            SqlParameter p5 = new SqlParameter("@topic", topic);
            SqlParameter p6 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Topic", p1, p2, p3, p4, p5, p6));
        }

        public static int Insert_Update_Topic(string divisioncode, string standardcode, string subjectcode, string chaptercode, string topicname, string topicdisplayname, string topicsequenceno, string isactive, string createdby, string flag, string topiccode, string Topic_Description)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", divisioncode);
            SqlParameter p2 = new SqlParameter("@Standard_Code", standardcode);
            SqlParameter p3 = new SqlParameter("@Subject_Code", subjectcode);
            SqlParameter p4 = new SqlParameter("@Chapter_Code", chaptercode);
            SqlParameter p5 = new SqlParameter("@Topic_Name", topicname);
            SqlParameter p6 = new SqlParameter("@Topic_DisplayName", topicdisplayname);
            SqlParameter p7 = new SqlParameter("@Topic_SequenceNo", topicsequenceno);
            SqlParameter p8 = new SqlParameter("@IsActive", isactive);
            SqlParameter p9 = new SqlParameter("@Created_By", createdby);
            SqlParameter p10 = new SqlParameter("@flag", flag);
            SqlParameter p11 = new SqlParameter("@topiccode", topiccode);
            SqlParameter p12 = new SqlParameter("@Topic_Description", Topic_Description);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Topic", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));

        }


        public static int InsertUpdateSubTopic(string SubTopic_Code, string Division_Code, string Standard_Code, string Subject_Code, string Chapter_Code, string Topic_Code, string SubTopic_Name, string SubTopic_DisplayName, string SubTopic_Description, string SubTopic_SequenceNo, int Is_Active, string Created_By, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p3 = new SqlParameter("@Subject_Code", Subject_Code);
            SqlParameter p4 = new SqlParameter("@Chapter_Code", Chapter_Code);
            SqlParameter p5 = new SqlParameter("@Topic_Code", Topic_Code);
            SqlParameter p6 = new SqlParameter("@SubTopic_Code", SubTopic_Code);
            SqlParameter p7 = new SqlParameter("@SubTopic_Name", SubTopic_Name);
            SqlParameter p8 = new SqlParameter("@SubTopic_DisplayName", SubTopic_DisplayName);
            SqlParameter p9 = new SqlParameter("@SubTopic_Description", SubTopic_Description);
            SqlParameter p10 = new SqlParameter("@SubTopic_SequenceNo", SubTopic_SequenceNo);
            SqlParameter p11 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p12 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p13 = new SqlParameter("@flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_SubTopic", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
        }

        public static DataSet Get_SubTopicDetail(string SubTopic_Code, string Division_Code, string Standard_Code, string Subject_Code, string Chapter_Code, string Topic_Code, string flag)
        {
            SqlParameter p1 = new SqlParameter("@SubTopic_Code", SubTopic_Code);
            SqlParameter p2 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p3 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p4 = new SqlParameter("@Subject_Code", Subject_Code);
            SqlParameter p5 = new SqlParameter("@Chapter_Code", Chapter_Code);
            SqlParameter p6 = new SqlParameter("@Topic_Code", Topic_Code);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_SubTopic", p1, p2, p3, p4, p5, p6, p7));
        }
               

        public static DataSet Get_ModuleDetail(string Module_Code, string Division_Code, string Standard_Code, string Subject_Code, string Chapter_Code, string Topic_Code, string SubTopic_Code, string flag)
        {
            SqlParameter p0 = new SqlParameter("@Module_Code", Module_Code);
            SqlParameter p1 = new SqlParameter("@SubTopic_Code", SubTopic_Code);
            SqlParameter p2 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p3 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p4 = new SqlParameter("@Subject_Code", Subject_Code);
            SqlParameter p5 = new SqlParameter("@Chapter_Code", Chapter_Code);
            SqlParameter p6 = new SqlParameter("@Topic_Code", Topic_Code);
            SqlParameter p7 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Module", p0, p1, p2, p3, p4, p5, p6, p7));
        }
       
        public static int InsertUpdateModule(string Module_Code, string Division_Code, string Standard_Code, string Subject_Code, string Chapter_Code, string Topic_Code, string SubTopic_Code, string Module_Name, string Module_DisplayName, string Module_Description, string Module_SequenceNo, int Is_Active, string Created_By, string Flag)
        {
            SqlParameter p0 = new SqlParameter("@Module_Code", Module_Code);
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p3 = new SqlParameter("@Subject_Code", Subject_Code);
            SqlParameter p4 = new SqlParameter("@Chapter_Code", Chapter_Code);
            SqlParameter p5 = new SqlParameter("@Topic_Code", Topic_Code);
            SqlParameter p6 = new SqlParameter("@SubTopic_Code", SubTopic_Code);
            SqlParameter p7 = new SqlParameter("@Module_Name", Module_Name);
            SqlParameter p8 = new SqlParameter("@module_DisplayName", Module_DisplayName);
            SqlParameter p9 = new SqlParameter("@Module_Description", Module_Description);
            SqlParameter p10 = new SqlParameter("@Module_SequenceNo", Module_SequenceNo);
            SqlParameter p11 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p12 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p13 = new SqlParameter("@flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Module", p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13));
        }

        public static DataSet GetContentLocation(int Flag)        
        {            
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetContentLocation", p1));
        }


        public static DataSet GetContentType(string ContentLocation, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Content_Location_Type", ContentLocation);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetContentType", p1,p2));
        }


        public static DataSet GetLessonPlanTest(string ModuleCode, int Flag, string TestCode)
        {
            SqlParameter p1 = new SqlParameter("@ModuleCode", ModuleCode);
            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            SqlParameter p3 = new SqlParameter("@TestCode", TestCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetLessonPlanTest", p1, p2,p3));
        }

        public static DataSet GetDivision(string divisioncode, string divisiondescription, string flag)
        {
            SqlParameter p1 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p2 = new SqlParameter("@divisionlongdesc", divisiondescription);
            SqlParameter p3 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Division", p1, p2, p3));
        }

        public static int Insert_Update_Division(string divisioncode, string divisionshortdesc, string divisionlongdesc, int status, string createdby, string flag)
        {
            SqlParameter p0 = new SqlParameter("@DivisionCode", divisioncode);
            SqlParameter p1 = new SqlParameter("@DivisionShortDesc", divisionshortdesc);
            SqlParameter p2 = new SqlParameter("@DivisionLongDesc", divisionlongdesc);
            SqlParameter p3 = new SqlParameter("@Status", status);
            SqlParameter p4 = new SqlParameter("@Created_By", createdby);
            SqlParameter p5 = new SqlParameter("@flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Division", p0, p1, p2, p3, p4, p5));
        }


        public static DataSet GetallLocationbycity(string Citycode)
        {
            SqlParameter P = new SqlParameter("@Citycode", SqlDbType.NVarChar);
            P.Value = Citycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllLocation_City", P));
        }

        public static int Insert_Update_Center(string country, string citycode, string cityname, string locationcode, string locationname, string divisioncode, string centercode, string centername, string building, string room, string floor, string area, int status, string userid, string flag, string Statecode, string zonecode)
        {
            SqlParameter p1 = new SqlParameter("@country", country);
            SqlParameter p2 = new SqlParameter("@citycode", citycode);
            SqlParameter p3 = new SqlParameter("@cityname", cityname);
            SqlParameter p4 = new SqlParameter("@locationcode", locationcode);
            SqlParameter p5 = new SqlParameter("@locationname", locationname);
            SqlParameter p6 = new SqlParameter("@divisioncode", divisioncode);
            SqlParameter p7 = new SqlParameter("@centercode", centercode);
            SqlParameter p8 = new SqlParameter("@centername", centername);
            SqlParameter p9 = new SqlParameter("@building", building);
            SqlParameter p10 = new SqlParameter("@room", room);
            SqlParameter p11 = new SqlParameter("@floor", floor);
            SqlParameter p12 = new SqlParameter("@area", area);
            SqlParameter p13 = new SqlParameter("@status", status);
            SqlParameter p14 = new SqlParameter("@userid", userid);
            SqlParameter p15 = new SqlParameter("@flag", flag);
            SqlParameter p16 = new SqlParameter("@StateCode", Statecode);
            SqlParameter p17 = new SqlParameter("@ZoneCode", zonecode);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Center", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17));
        }



        public static DataSet GetCenter(string centername, string Source_Division_Code, int flag)
        {
            SqlParameter p1 = new SqlParameter("@centername", centername);
            SqlParameter p2 = new SqlParameter("@Source_Division_Code", Source_Division_Code);
            SqlParameter p3 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Centers", p1, p2, p3));
        }


       

        public static string Insert_UpdateLessonPlanHeader(string DivisionCode, string CourseCode, string SubjectCode, string ChapterCode, string TopicCode, string SubTopicCode, string LessonPlanCode, string LessonPlanName, string LessonPlanDisplayName, string LessonPlanDescription, bool EOC, int Is_Active, string Created_By, string Pkey, string Flag, string ModuleCode)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", DivisionCode);
            SqlParameter p2 = new SqlParameter("@CourseCode", CourseCode);
            SqlParameter p3 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p4 = new SqlParameter("@ChapterCode", ChapterCode);
            SqlParameter p5 = new SqlParameter("@TopicCode", TopicCode);
            SqlParameter p6 = new SqlParameter("@SubTopicCode", SubTopicCode);
            SqlParameter p7 = new SqlParameter("@LessonPlanCode", LessonPlanCode);
            SqlParameter p8 = new SqlParameter("@LessonPlanName", LessonPlanName);
            SqlParameter p9 = new SqlParameter("@LessonPlanDisplayName", LessonPlanDisplayName);
            SqlParameter p10 = new SqlParameter("@LessonPlanDescription", LessonPlanDescription);
            SqlParameter p11 = new SqlParameter("@EOC", EOC);
            SqlParameter p12 = new SqlParameter("@IsActive", Is_Active);
            SqlParameter p13 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p14 = new SqlParameter("@PKey", Pkey);
            SqlParameter p15 = new SqlParameter("@flag", Flag);
            SqlParameter p16 = new SqlParameter("@ModuleCode", ModuleCode);

            return Convert.ToString(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_LessonPlanHeader", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16));
        }

        public static DataSet Get_Fill_AddMenu(int flag, string role)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@roleid", role);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_AddMenu", p1, p2));
        }

        public static string Usp_Insert_RoleNew(string Role_Name, int IsActive, string UserCode, int Flag, string Rollcode, string MenuCode, string MenuName, int Active2)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@Role_Name", Role_Name);
            p[1] = new SqlParameter("@IsActive", IsActive);
            p[2] = new SqlParameter("@Created_by", UserCode);
            p[3] = new SqlParameter("@Flag", Flag);
            p[4] = new SqlParameter("@RoleCode", Rollcode);
            p[5] = new SqlParameter("@Menu_Code", MenuCode);
            p[6] = new SqlParameter("@Menu_Name", MenuName);
            p[7] = new SqlParameter("@Active2", Active2);
            p[8] = new SqlParameter("@Results", SqlDbType.VarChar, 10);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_RoleNew", p);
            return (p[8].Value.ToString());

        }

        public static DataSet Fill_Role_SearchPanel(string rolename, int active)
        {
            SqlParameter p1 = new SqlParameter("@Role_name", rolename);
            SqlParameter p2 = new SqlParameter("@IsActive", active);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Fill_Role_SearchPanel", p1, p2));
        }

        public static DataSet Get_Role_Details(string Role_Id, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Role_Id", Role_Id);
            SqlParameter p2 = new SqlParameter("@Flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_get_Role_Details", p1, p2));
        }

        public static string Usp_Insert_RoleUser(string usercode, string rolecode, int active, int flag, string createdby)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@Usercode", usercode);
            p[1] = new SqlParameter("@RoleCode", rolecode);
            p[2] = new SqlParameter("@IsActive", active);
            p[3] = new SqlParameter("@Flag", flag);
            p[4] = new SqlParameter("@Created_by", createdby);
            p[5] = new SqlParameter("@Results", SqlDbType.VarChar, 10);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_RoleUser", p);
            return (p[5].Value.ToString());
        }





        public static DataSet Usp_Get_Fill_ParentMenu(int Flag)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p1));

        }

        public static int Insert_Menu_Details(int flag, string Application_code, string Menu_Name, string Menu_Css, string Menu_Parent_code, int menu_type, string menu_link, string Menu_Discription, int display_order, int IsActive, string createdby, string application_no)
        {
            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@flag", flag);
            p[1] = new SqlParameter("@Application_Code", Application_code);
            p[2] = new SqlParameter("@Menu_Name", Menu_Name);
            p[3] = new SqlParameter("@Menu_CSS", Menu_Css);
            p[4] = new SqlParameter("@Menu_Parent_Code", Menu_Parent_code);
            p[5] = new SqlParameter("@Menu_Type", menu_type);
            p[6] = new SqlParameter("@Menu_Link", menu_link);
            p[7] = new SqlParameter("@Menu_Description", Menu_Discription);
            p[8] = new SqlParameter("@Display_Order_No", display_order);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@Created_by", createdby);
            p[11] = new SqlParameter("@Application_No", application_no);

            p[12] = new SqlParameter("@Results", SqlDbType.VarChar, 10);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p);
            return Convert.ToInt32(p[12].Value.ToString());
        }

        public static DataSet Get_Fill_MenuSearch(int Flag, string Application_no)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@Application_No", Application_no);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p1, p2));
        }

        public static DataSet Get_Edit_MenuSearch(int Flag, string MenuCode)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@Menu_codeV", MenuCode);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p1, p2));
        }

        public static int Update_Menu_Details(int flag, string Application_code, string Menu_Name, string Menu_Css, string Menu_Parent_code, int menu_type, string menu_link, string Menu_Discription, int display_order, int IsActive, string createdby, string application_no, string Menu_code)
        {
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@flag", flag);
            p[1] = new SqlParameter("@Application_Code", Application_code);
            p[2] = new SqlParameter("@Menu_Name", Menu_Name);
            p[3] = new SqlParameter("@Menu_CSS", Menu_Css);
            p[4] = new SqlParameter("@Menu_Parent_Code", Menu_Parent_code);
            p[5] = new SqlParameter("@Menu_Type", menu_type);
            p[6] = new SqlParameter("@Menu_Link", menu_link);
            p[7] = new SqlParameter("@Menu_Description", Menu_Discription);
            p[8] = new SqlParameter("@Display_Order_No", display_order);
            p[9] = new SqlParameter("@IsActive", IsActive);
            p[10] = new SqlParameter("@Created_by", createdby);
            p[11] = new SqlParameter("@Application_No", application_no);
            p[12] = new SqlParameter("@Menu_codeV", Menu_code);

            p[13] = new SqlParameter("@Results", SqlDbType.VarChar, 10);
            p[13].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p);
            return Convert.ToInt32(p[13].Value.ToString());
        }

        public static int CopySubject_Chapter_Topic_SubTopic_Module_LessonPlan(string Standard_Code, string Subject_Code, string NewStandard_Code, string NewSubject_Code, string Created_By, string DivisionCode)
        {
            SqlParameter p1 = new SqlParameter("@Standard_Code", Standard_Code);
            SqlParameter p2 = new SqlParameter("@Subject_Code", Subject_Code);
            SqlParameter p3 = new SqlParameter("@NewStandard_Code", NewStandard_Code);
            SqlParameter p4 = new SqlParameter("@NewSubject_Code", NewSubject_Code);
            SqlParameter p5 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p6 = new SqlParameter("@Division_Code", DivisionCode);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CopySubject_Chapter_Topic_SubTopic_Module_LessonPlan", p1, p2, p3, p4, p5,p6));
        }

        public static DataSet Usp_Get_ManageSync(int Flag, string dbcode, string ColumnName)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@SyncDBCode", dbcode);
            SqlParameter p3 = new SqlParameter("@SPName", "");
            SqlParameter p4 = new SqlParameter("@ColumnName", ColumnName);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ManageSync", p1, p2, p3, p4));
        }

        public static int Usp_Get_UpdateanageSync(string flag, string Procedures, int value)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@flag", flag);
            p[1] = new SqlParameter("@Result", value);

            return SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, Procedures, p);
        }


        public static string Usp_Get_SyncSpName(string dbcode, int flag)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@SyncDBCode", dbcode);
            p[1] = new SqlParameter("@flag", flag);

            p[2] = new SqlParameter("@SPName", SqlDbType.VarChar, 50);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ManageSync", p);
            return p[2].Value.ToString();
        }



        public static int Insert_UPdate_SubjectNEW(string Course_Code, string Course_Name, string SubjectName, string IsReference, string RefferenceCourseCode, string RefferenceSubjectCode, string SubjectDisplayName, string SubjectSequenceno, string Created_By, string Is_Active, string Flag, string recordnumber)
        {
            SqlParameter p1 = new SqlParameter("@Course_Code", Course_Code);
            SqlParameter p2 = new SqlParameter("@Course_Name", Course_Name);
            SqlParameter p3 = new SqlParameter("@SubjectName", SubjectName);
            SqlParameter p4 = new SqlParameter("@IsReference", IsReference);
            SqlParameter p5 = new SqlParameter("@RefferenceCourseCode", RefferenceCourseCode);
            SqlParameter p6 = new SqlParameter("@RefferenceSubjectCode", RefferenceSubjectCode);
            SqlParameter p7 = new SqlParameter("@SubjectDisplayName", SubjectDisplayName);
            SqlParameter p8 = new SqlParameter("@SubjectSequenceno", SubjectSequenceno);
            SqlParameter p9 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p10 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p11 = new SqlParameter("@Flag", Flag);
            SqlParameter p12 = new SqlParameter("@recordnumber", recordnumber);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_SubjectNEW", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12));
        }

        public static DataSet Get_RFID_Centre_Div(string flag)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_RFID_Centers_Division", p1));
        }

        public static int InsertUpdateRFID_Device(string Device_Code, string Device_Name, int Is_Active, string Created_By, string Center_Code, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Device_Code", Device_Code);
            SqlParameter p2 = new SqlParameter("@Device_Name", Device_Name);
            SqlParameter p3 = new SqlParameter("@Created_By", Created_By);
            SqlParameter p4 = new SqlParameter("@Is_Active", Is_Active);
            SqlParameter p5 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p6 = new SqlParameter("@Flag", Flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_RFID_Device", p1, p2, p3, p4, p5, p6));
        }

        public static DataSet GetRFIDDevice(string DeviceCode, string DeviceName, string ActiveFlag, string flag)
        {
            SqlParameter p1 = new SqlParameter("@Device_Code", DeviceCode);
            SqlParameter p2 = new SqlParameter("@DeviceName", DeviceName);
            SqlParameter p3 = new SqlParameter("@ActiveFlag", ActiveFlag);
            SqlParameter p4 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_RFID_Device", p1, p2, p3, p4));
        }

        public static DataSet GetCountry(string countryname, string countrycode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@countryname", countryname);
            SqlParameter p2 = new SqlParameter("@countrycode", countrycode);
            SqlParameter p3 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Country", p1, p2, p3));
        }
        public static int Insert_Update_Country(string countrycode, string countryname, string createdby, int Active, string flag)
        {
            SqlParameter p1 = new SqlParameter("@Countrycode", countrycode);
            SqlParameter p2 = new SqlParameter("@Countryname", countryname);
            SqlParameter p3 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p4 = new SqlParameter("@Active", Active);
            SqlParameter p5 = new SqlParameter("@Flag", flag);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Country", p1, p2, p3, p4, p5));

        }
        public static DataSet GetState(string countrycode, string statename, string statecode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@country", countrycode);
            SqlParameter p2 = new SqlParameter("@statename", statename);
            SqlParameter p3 = new SqlParameter("@statecode", statecode);
            SqlParameter p4 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_State", p1, p2, p3, p4));
        }

        public static int Insert_Update_State(string statecode, string countryname, string statename, string createdby, int Active, string flag)
        {
            SqlParameter p1 = new SqlParameter("@statecode", statecode);
            SqlParameter p2 = new SqlParameter("@Countryname", countryname);
            SqlParameter p3 = new SqlParameter("@statename", statename);
            SqlParameter p4 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p5 = new SqlParameter("@Active", Active);
            SqlParameter p6 = new SqlParameter("@Flag", flag);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_State", p1, p2, p3, p4, p5, p6));

        }
        public static DataSet GetCity(string countrycode, string statecode, string cityname, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@countrycode", countrycode);
            SqlParameter p2 = new SqlParameter("@statecode", statecode);
            SqlParameter p3 = new SqlParameter("@cityname", cityname);
            SqlParameter p4 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_City", p1, p2, p3, p4));
        }
        public static int Insert_Update_City(string country, string state, string city, string createdby, int Active, string flag, string citycode)
        {
            SqlParameter p1 = new SqlParameter("@Country", country);
            SqlParameter p2 = new SqlParameter("@State", state);
            SqlParameter p3 = new SqlParameter("@City", city);
            SqlParameter p4 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p5 = new SqlParameter("@Active", Active);
            SqlParameter p6 = new SqlParameter("@Flag", flag);
            SqlParameter p7 = new SqlParameter("@city_code", citycode);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_City", p1, p2, p3, p4, p5, p6, p7));

        }
        public static DataSet GetLocation(string countrycode, string statecode, string cityname, string location, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@countrycode", countrycode);
            SqlParameter p2 = new SqlParameter("@statecode", statecode);
            SqlParameter p3 = new SqlParameter("@cityname", cityname);
            SqlParameter p4 = new SqlParameter("@locationname", location);
            SqlParameter p5 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Location", p1, p2, p3, p4, p5));
        }

        public static int Insert_Update_Location(string locationcode, string country, string state, string city, string locationname, string createdby, int Active, string flag)
        {
            SqlParameter p1 = new SqlParameter("@locationcode", locationcode);
            SqlParameter p2 = new SqlParameter("@Country", country);
            SqlParameter p3 = new SqlParameter("@State", state);
            SqlParameter p4 = new SqlParameter("@City", city);
            SqlParameter p5 = new SqlParameter("@location", locationname);
            SqlParameter p6 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p7 = new SqlParameter("@Active", Active);
            SqlParameter p8 = new SqlParameter("@Flag", flag);


            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_Location", p1, p2, p3, p4, p5, p6, p7, p8));

        }
        public static DataSet GetZone(string divisioncode, string zonename, string zonecode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@DivisionCode", divisioncode);
            SqlParameter p2 = new SqlParameter("@zonename", zonename);
            SqlParameter p3 = new SqlParameter("@Zoneid", zonecode);
            SqlParameter p4 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ZoneDetails", p1, p2, p3, p4));
        }

        public static int Insert_Update_Zone(string zonename, string zonecode, string division, int status, string createdby, string flag)
        {
            SqlParameter p0 = new SqlParameter("@Zonename", zonename);
            SqlParameter p1 = new SqlParameter("@Zonecode", zonecode);
            SqlParameter p2 = new SqlParameter("@Division", division);
            SqlParameter p3 = new SqlParameter("@Active", status);
            SqlParameter p4 = new SqlParameter("@CreatedBy", createdby);
            SqlParameter p5 = new SqlParameter("@flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Zone", p0, p1, p2, p3, p4, p5));
        }



        public static DataSet GetBankDetails(string flag, string micrno, string bankname)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.VarChar);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@micrno", SqlDbType.VarChar);
            p1.Value = micrno;
            SqlParameter p2 = new SqlParameter("@bankname", SqlDbType.VarChar);
            p2.Value = bankname;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetBankDetails", p, p1, p2));
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


        public static DataSet GetAllDivisionName_ForUserCreation(int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1));

        }

        public static DataSet GetAllRoleCode_ForUserCreation(int Flag)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1));

        }

        public static DataSet GetUserDetails_ByPKey(string PKey, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@User_Code", PKey);

            SqlParameter p2 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1, p2));
        }

        public static DataSet GetAllCenters_DivisionWise_ForUserCreation(int Flag, string DivisionCode)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Division_Code", DivisionCode);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1, p2));

        }

        public static string Insert_User(string EMPCode, string DispName, string Emailid, string MobileNo, string typecode, int IsActive, string createdby, int Flag, string role)
        {

            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@User_Name", EMPCode);
            p[1] = new SqlParameter("@User_Display_Name", DispName);
            p[2] = new SqlParameter("@User_Email_Id", Emailid);
            p[3] = new SqlParameter("@User_Mobile_No", MobileNo);
            p[4] = new SqlParameter("@User_Type_Code", typecode);
            p[5] = new SqlParameter("@IsActive", IsActive);
            p[6] = new SqlParameter("@Created_by", createdby);
            p[7] = new SqlParameter("@Flag", Flag);
            p[8] = new SqlParameter("@RoleID", role);

            p[9] = new SqlParameter("@Results", SqlDbType.VarChar, 50);
            p[9].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p);
            return (p[9].Value.ToString());
        }

        public static string Insert_Role_User_CenterAss(string RoleCenterId, string RoleID, string CenterCode, string UserCode, int Flag)
        {

            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@RollCenterID", RoleCenterId);
            p[1] = new SqlParameter("@RoleID", RoleID);
            p[2] = new SqlParameter("@CenterCode", CenterCode);
            p[3] = new SqlParameter("@UserCode", UserCode);
            p[4] = new SqlParameter("@Flag", Flag);

            p[5] = new SqlParameter("@Results", SqlDbType.VarChar, 50);
            p[5].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p);
            return (p[5].Value.ToString());
        }

        public static string InsertUpdate_User(string EMPCode, string DispName, string Emailid, string MobileNo, string typecode, int IsActive, string createdby, int Flag, string User_Code, string Roleid)
        {

            SqlParameter[] p = new SqlParameter[11];
            p[0] = new SqlParameter("@User_Name", EMPCode);
            p[1] = new SqlParameter("@User_Display_Name", DispName);
            p[2] = new SqlParameter("@User_Email_Id", Emailid);
            p[3] = new SqlParameter("@User_Mobile_No", MobileNo);
            p[4] = new SqlParameter("@User_Type_Code", typecode);
            p[5] = new SqlParameter("@IsActive", IsActive);
            p[6] = new SqlParameter("@Created_by", createdby);
            p[7] = new SqlParameter("@Flag", Flag);
            p[8] = new SqlParameter("@User_Code", User_Code);
            p[9] = new SqlParameter("@RoleID", Roleid);
            p[10] = new SqlParameter("@Results", SqlDbType.VarChar, 50);
            p[10].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p);
            return (p[10].Value.ToString());
        }
        public static string Usp_DelUpdate_RoleMenuCode(string MenuCode, string RoleCode, int Flag)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Menu_codeV", MenuCode);
            p[1] = new SqlParameter("Role_Code", RoleCode);
            p[2] = new SqlParameter("@flag", Flag);
            p[3] = new SqlParameter("@Results1", SqlDbType.VarChar, 50);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p);
            return (p[3].Value.ToString());

        }

        public static string Insertupdatedelrole_User(string User_Code, int flag)
        {

            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@User_Code", User_Code);
            p[1] = new SqlParameter("@flag", flag);

            p[2] = new SqlParameter("@Results", SqlDbType.VarChar, 50);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p);
            return (p[2].Value.ToString());
        }

        public static DataSet GetAllUsersBy_Search(string UserDispName, string Usercode, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@User_Display_Name", UserDispName);
            SqlParameter p2 = new SqlParameter("@User_Name", Usercode);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p1, p2, p3));
        }


        public static DataSet GetUserByNameOrCode(string UserName, string UserCode, string flag)
        {
            SqlParameter p1 = new SqlParameter("@UserName", UserName);
            SqlParameter p2 = new SqlParameter("@UserCode", UserCode);
            SqlParameter p3 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_UserByNameOrCode", p1, p2, p3));
        }

        public static DataSet GetRequestType(string Flag)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_RequestType", p1));

        }

        public static DataSet Get_RequestLevelByUserCode(string User_Code, string flag, string Request_Code)
        {
            SqlParameter p1 = new SqlParameter("@User_Code", User_Code);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            SqlParameter p3 = new SqlParameter("@Request_Code", Request_Code);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_RequestLevelByUserCode", p1, p2, p3));
        }

        public static int Insert_Update_RequestLevel(string Request_Code, string Level_No, string User_Id, string Center_Code, string flag)
        {
            SqlParameter p1 = new SqlParameter("@Request_Code", Request_Code);
            SqlParameter p2 = new SqlParameter("@Level_No", Level_No);
            SqlParameter p3 = new SqlParameter("@User_Id", User_Id);
            SqlParameter p4 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p5 = new SqlParameter("@Flag", flag);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Update_RequestLevel", p1, p2, p3, p4, p5));
        }



        public static string Insertupdatedelrole_UserSync(int flag)
        {

            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@flag", flag);

            p[1] = new SqlParameter("@Results", SqlDbType.VarChar, 50);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertUpdate_UserCreation", p);
            return (p[1].Value.ToString());
        }


        public static string Change_Password_Chk(string user_code, string oldpassword, int flag)
        {

            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@user_Code", user_code);
            p[1] = new SqlParameter("@oldPasword", oldpassword);
            p[2] = new SqlParameter("@flag", flag);


            p[3] = new SqlParameter("@Results", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Change_Password", p);
            return (p[3].Value.ToString());
        }

        public static int Insert_Chapter(string DivisionCode, string YearName, string StandardCode, string SubjectCode, string ChapterName, string Chapter_DisplayName, double LectureCount, int LectureDuration, string ChapterShortName, string ChapterCodeForEdit, string CreatedBy, string IsActive)
        {

            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@DivisionCode", DivisionCode);
            p[1] = new SqlParameter("@YearName", YearName);
            p[2] = new SqlParameter("@StandardCode", StandardCode);
            p[3] = new SqlParameter("@SubjectCode", SubjectCode);
            p[4] = new SqlParameter("@ChapterName", ChapterName);
            p[5] = new SqlParameter("@Chapter_DisplayName", Chapter_DisplayName);
            p[6] = new SqlParameter("@LectureCount", LectureCount);
            p[7] = new SqlParameter("@LectureDuration", LectureDuration);
            p[8] = new SqlParameter("@ChapterShortName", ChapterShortName);
            p[9] = new SqlParameter("@ChapterCodeForEdit", ChapterCodeForEdit);
            p[10] = new SqlParameter("@CreatedBy", CreatedBy);
            p[11] = new SqlParameter("@IsActive", IsActive);
            p[12] = new SqlParameter("@Result", SqlDbType.BigInt);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertChapter", p);
            return (int.Parse(p[12].Value.ToString()));
        }
        public static DataSet Usp_Get_Fill_ParentMenu2(int Flag, string Application)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@Application_No", Application);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Fill_ParentMenu", p1, p2));

        }

        public static DataSet GetAllChaptersBy_Division_Year_Standard_Subject(string Division_Code, string YearName, string StandardCode, string SubjectCode, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
            SqlParameter p4 = new SqlParameter("@SubjectCode", SubjectCode);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllChaptersBy_Division_Year_Standard_Subject_New", p1, p2, p3, p4, p5));
        }

        public static DataSet Get_ClassRoomCourse(string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ClassroomCourse", p1));
        }

        public static DataSet Get_ClassroomProduct(string Division_Code, string Acd_Year, string Stream_Code, string Stream_Name, string IsActive, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@Division_Code", Division_Code);
            SqlParameter p2 = new SqlParameter("@Acd_Year", Acd_Year);
            SqlParameter p3 = new SqlParameter("@Stream_Code", Stream_Code);
            SqlParameter p4 = new SqlParameter("@Stream_Name", Stream_Name);
            SqlParameter p5 = new SqlParameter("@IsActive", IsActive);
            SqlParameter p6 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_ClassroomProductHeader", p1, p2, p3, p4, p5, p6));
        }

        public static string Insert_Update_ClassRoomProduct(string Stream_Code, string Acad_Year, string ClassrromCourseCode, string ProductName, string ProductDesc, string Fee_Zone, string Crs_SDate, string Crs_EDate, string Adm_SDate, string Adm_EDate, string AllowDPInTwoInstallmentFlag, string AllowDPInTwoInstallmentTillDate, string AllowChequeTillDateFlag, string AllowChequeTillDate, string MaxNoOfChequesInFullDP, string MaxDayGapInChequesInFullDP, string Centers, string Created_By, string flag)
        {

            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@Acad_Year", Acad_Year);
            p[1] = new SqlParameter("@Mat_Num", ClassrromCourseCode);
            p[2] = new SqlParameter("@Stream_SDesc", ProductName);
            p[3] = new SqlParameter("@Stream_LDesc", ProductDesc);
            p[4] = new SqlParameter("@Fee_Zone", Fee_Zone);
            p[5] = new SqlParameter("@Crs_SDate", Crs_SDate);
            p[6] = new SqlParameter("@Crs_EDate", Crs_EDate);
            p[7] = new SqlParameter("@Adm_SDate", Adm_SDate);
            p[8] = new SqlParameter("@Adm_EDate", Adm_EDate);
            p[9] = new SqlParameter("@Stream_Code", Stream_Code);
            p[10] = new SqlParameter("@AllowDPInTwoInstallmentFlag", AllowDPInTwoInstallmentFlag);
            p[11] = new SqlParameter("@AllowDPInTwoInstallmentTillDate", AllowDPInTwoInstallmentTillDate);
            p[12] = new SqlParameter("@AllowChequeTillDateFlag", AllowChequeTillDateFlag);
            p[13] = new SqlParameter("@AllowChequeTillDate", AllowChequeTillDate);
            p[14] = new SqlParameter("@MaxNoOfChequesInFullDP", MaxNoOfChequesInFullDP);
            p[15] = new SqlParameter("@MaxDayGapInChequesInFullDP", MaxDayGapInChequesInFullDP);
            p[16] = new SqlParameter("@Centers", Centers);
            p[17] = new SqlParameter("@Created_By", Created_By);
            p[18] = new SqlParameter("@flag", flag);

            p[19] = new SqlParameter("@Result", SqlDbType.VarChar, 50);
            p[19].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ClassroomProduct", p);
            return (p[19].Value.ToString());
        }

        public static string Insert_Update_ClassRoomSubjectGroup(string Stream_Code, string Sgr_Material, string Validity_SDate, string Validity_EDate, string Stream_SDesc, string SGR_Desc, string Acad_Year, string Voucher_Amt, string UOM, string Min_Order_Qty, string Sub_Material, string SUB_DESC, string Created_By, string flag)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@Stream_Code", Stream_Code);
            p[1] = new SqlParameter("@Sgr_Material", Sgr_Material);
            p[2] = new SqlParameter("@Validity_SDate", Validity_SDate);
            p[3] = new SqlParameter("@Validity_EDate", Validity_EDate);
            p[4] = new SqlParameter("@Stream_SDesc", Stream_SDesc);
            p[5] = new SqlParameter("@SGR_Desc", SGR_Desc);
            p[6] = new SqlParameter("@Acad_Year", Acad_Year);
            p[7] = new SqlParameter("@Voucher_Amt", Voucher_Amt);
            p[8] = new SqlParameter("@UOM", UOM);
            p[9] = new SqlParameter("@Min_Order_Qty", Min_Order_Qty);
            p[10] = new SqlParameter("@Sub_Material", Sub_Material);
            p[11] = new SqlParameter("@SUB_DESC", SUB_DESC);
            p[12] = new SqlParameter("@Created_By", Created_By);
            p[13] = new SqlParameter("@flag", flag);

            p[14] = new SqlParameter("@Result", SqlDbType.VarChar, 50);
            p[14].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_SubjectGroup", p);
            return (p[14].Value.ToString());
        }

        public static string Insert_Update_ClassRoomItemLevelPricing(string Stream_Code, string Sgr_Material, string Voucher_type, string Validity_StartDate, string Validity_EndDate, string Pay_Plan, string Voucher_Amt, string Division, string Stream_SDesc, string PKey, string Created_By, string flag)
        {
            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@Stream_Code", Stream_Code);
            p[1] = new SqlParameter("@Sgr_Material", Sgr_Material);
            p[2] = new SqlParameter("@Voucher_type", Voucher_type);
            p[3] = new SqlParameter("@Validity_StartDate", Validity_StartDate);
            p[4] = new SqlParameter("@Validity_EndDate", Validity_EndDate);
            p[5] = new SqlParameter("@Pay_Plan", Pay_Plan);
            p[6] = new SqlParameter("@Voucher_Amt", Voucher_Amt);
            p[7] = new SqlParameter("@Division", Division);
            p[8] = new SqlParameter("@Stream_SDesc", Stream_SDesc);
            p[9] = new SqlParameter("@PKey", PKey);
            p[10] = new SqlParameter("@Created_By", Created_By);
            p[11] = new SqlParameter("@flag", flag);

            p[12] = new SqlParameter("@Result", SqlDbType.VarChar, 50);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ItemLevel_Pricing", p);
            return (p[12].Value.ToString());
        }

        public static string Insert_Update_ClassRoomItemPricingHeader(string Stream_Code, string Voucher_type, string Validity_StartDate, string Validity_EndDate, string Voucher_Amt, string Mat_ROB, string UOM, string Min_Order_Qty, string Division, string PKey, string Created_By, string flag)
        {
            SqlParameter[] p = new SqlParameter[13];
            p[0] = new SqlParameter("@Stream_Code", Stream_Code);
            p[1] = new SqlParameter("@Voucher_Typ", Voucher_type);
            p[2] = new SqlParameter("@Validity_SDate", Validity_StartDate);
            p[3] = new SqlParameter("@Validity_EDate", Validity_EndDate);
            p[4] = new SqlParameter("@Voucher_Amt", Voucher_Amt);
            p[5] = new SqlParameter("@Mat_ROB", Mat_ROB);
            p[6] = new SqlParameter("@UOM", UOM);
            p[7] = new SqlParameter("@Min_Order_Qty", Min_Order_Qty);
            p[8] = new SqlParameter("@Division", Division);
            p[9] = new SqlParameter("@PKey", PKey);
            p[10] = new SqlParameter("@Created_By", Created_By);
            p[11] = new SqlParameter("@flag", flag);

            p[12] = new SqlParameter("@Result", SqlDbType.VarChar, 50);
            p[12].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_ItemPricing_Header", p);
            return (p[12].Value.ToString());
        }


        // PC for LOG-SMS on 26 Jun

        public static DataSet GetLogSMS_SearchField(string Centre_Code, string fromdate, string todate,string status,int flag)
        {
            SqlParameter p1 = new SqlParameter("@Centre_Code", Centre_Code);
            SqlParameter p2 = new SqlParameter("@FromDate", fromdate);
            SqlParameter p3 = new SqlParameter("@ToDate", todate);
            SqlParameter p4 = new SqlParameter("@SendStatus", status);
            SqlParameter p5 = new SqlParameter("@flag", flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Check_SMSLOG", p1, p2, p3, p4,p5));

        }

        public static DataSet GetLogSMS_Details(string Pkey,string status, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Pkey", Pkey);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            SqlParameter p3 = new SqlParameter("@SendStatus", status);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Check_SMSLOG", p1, p2,p3));

        }
        public static DataSet GetAllStudentType1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallStudentType"));
        }
        public static DataSet GetallInstituteType1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllInstituteType"));
        }
        public static DataSet GetallEventtype1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DispEvents"));
        }

        public static DataSet GetallCurrentStudyingin1(string InstituteTypeid)
        {
            SqlParameter P = new SqlParameter("@Institute_Type_Id", SqlDbType.VarChar);
            P.Value = InstituteTypeid;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentStudyingin", P));
        }

        public static DataSet GetallBoard1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallBoard"));
        }

        public static DataSet GetallOpporProductCategory1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllOpporProductCategory"));
        }

        public static DataSet GetallCountry1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCountry1"));
        }

        public static DataSet GetallStatebyCountry1(string Countrycode)
        {
            SqlParameter P = new SqlParameter("@Countrycode", SqlDbType.NVarChar);
            P.Value = Countrycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStatebyCountry1", P));
        }
        public static DataSet GetallCitybyState1(string StateCode)
        {
            SqlParameter P = new SqlParameter("@Statecode", SqlDbType.NVarChar);
            P.Value = StateCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllCitybyState1", P));
        }

        public static DataSet GetallLocationbycity1(string Citycode)
        {
            SqlParameter P = new SqlParameter("@Citycode", SqlDbType.NVarChar);
            P.Value = Citycode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLocationbyCity1", P));
        }

        public static DataSet GetUser_Company_Division_Zone_Center1(int Flag, string Userid, string Divisioncode, string Zonecode, string Companycode)
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
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center1", p, p1, p2, p3, p4));
        }

        public static DataSet GetAllAcadyear1()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAcadyear"));
        }

        public static DataSet GetStreamby_Center_AcademicYear_All1(string CenterCode, string AcademicYear)
        {
            SqlParameter p = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p.Value = CenterCode;
            SqlParameter p1 = new SqlParameter("@AcadYear", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getstream_byCenter_Acadyear_All", p, p1));
        }
        public static int Insert_SMSLog(string Centre_Code, string Message_Code, string MobileNo, string SMSText, string SendStatus, string Sendby, string SMSType, string Category, int flag)
        {
            SqlParameter p0 = new SqlParameter("@Center_Code", Centre_Code);
            SqlParameter p1 = new SqlParameter("@Message_code", Message_Code);
            SqlParameter p2 = new SqlParameter("@MobileNo", MobileNo);
            SqlParameter p3 = new SqlParameter("@NewMessagetemplate", SMSText);
            SqlParameter p4 = new SqlParameter("@SendStatus", SendStatus);
            SqlParameter p5 = new SqlParameter("@CreatedBy", Sendby);
            SqlParameter p6 = new SqlParameter("@SMSType", SMSType);
            SqlParameter p7 = new SqlParameter("@SMSCategory", Category);
            SqlParameter p8 = new SqlParameter("@flag", flag);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_MessageSetup", p0, p1, p2, p3, p4, p5, p6,p7,p8));
        }


        //// PC for Dashboard

        public static DataSet Dashboard_MessagingEngine(string UserCode, string FromDate, string ToDate, string DBName, string Flag)
        {
            SqlParameter p1 = new SqlParameter("@UserCode", UserCode);
            SqlParameter p2 = new SqlParameter("@FromDate", FromDate);
            SqlParameter p3 = new SqlParameter("@ToDate", ToDate);
            SqlParameter p4 = new SqlParameter("@DBName", DBName);
            SqlParameter p5 = new SqlParameter("@Flag", Flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_DashboardMessagingEngine", p1, p2, p3, p4, p5));

        }

        //PC for DDLStatus

        public static DataSet GetAllMessage_Status(int Flag)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Check_SMSLOG", p1));

        }


        //PC for Email Log on 27 july

        public static DataSet GetLogMail_SearchField(string Centre_Code, string fromdate, string todate, int status, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Centre_Code", Centre_Code);
            SqlParameter p2 = new SqlParameter("@FromDate", fromdate);
            SqlParameter p3 = new SqlParameter("@ToDate", todate);
            SqlParameter p4 = new SqlParameter("@SendStatus", status);
            SqlParameter p5 = new SqlParameter("@flag", flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Check_MailLOG", p1, p2, p3, p4, p5));

        }

        public static DataSet GetLogMail_Details(string Pkey, string status, int flag)
        {
            SqlParameter p1 = new SqlParameter("@Pkey", Pkey);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            SqlParameter p3 = new SqlParameter("@SendStatus", status);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Check_MailLOG", p1, p2, p3));

        }

        public static DataSet GetMailDetails_ByCenter(string MailType)
        {
            
            SqlParameter p2 = new SqlParameter("@MailType", MailType);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_MailDetails", p2));
        }

        public static int Insert_Mailog(string Mail_To, string Subject, string Body, int Att_Flag, string Att_FileName, string sendstatus, string sendby, int flag, string Center_Code, string MailType)
        {
            SqlParameter p0 = new SqlParameter("@Mail_To", Mail_To);
            SqlParameter p1 = new SqlParameter("@Subject", Subject);
            SqlParameter p2 = new SqlParameter("@Body", Body);
            SqlParameter p3 = new SqlParameter("@Att_Flag", Att_Flag);
            SqlParameter p4 = new SqlParameter("@Att_FileName", Att_FileName);
            SqlParameter p5 = new SqlParameter("@SendStatus", sendstatus);
            SqlParameter p6 = new SqlParameter("@SendBy", sendby);
            SqlParameter p7 = new SqlParameter("@flag", flag);
            SqlParameter p8 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p9 = new SqlParameter("@MailType", MailType);

            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_MailLog", p0, p1, p2, p3, p4, p5, p6, p7, p8, p9));
        }

        // 05 april 2016
         public static DataSet GetBatchBy_Division_Year_Centre(string Division_Code, string YearName,  string CentreCode, string flag)
        {
            SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
            SqlParameter p2 = new SqlParameter("@YearName", YearName);
            SqlParameter p3 = new SqlParameter("@Centre_Code", CentreCode);
            SqlParameter p4 = new SqlParameter("@Flag", flag);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchBy_Division_Year_Standard_Centre", p1, p2, p3, p4));
        }

         public static DataSet GetSMS_Log_Report_Contactwise(string Division_Code, string Centre_Code, string fromdate, string todate, string Mobile, string userid, int flag)
         {

             SqlParameter p0 = new SqlParameter("@division", Division_Code);
             SqlParameter p1 = new SqlParameter("@center", Centre_Code);
             SqlParameter p2 = new SqlParameter("@FromDate", fromdate);
             SqlParameter p3 = new SqlParameter("@ToDate", todate);
             SqlParameter p4 = new SqlParameter("@Mobile", Mobile);
             SqlParameter p5 = new SqlParameter("@userid", userid);
             SqlParameter p6 = new SqlParameter("@flag", flag);

             return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_SMSDetail_ByCenterandMobile", p0, p1, p2, p3, p4, p5, p6));

         }


         // added by sujeer 22-02-2018
         public static DataSet GetAllSMSCategory()
         {
             return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "[Usp_GetSMSSMSCategoryName]"));
         }

    
    
    }
}
