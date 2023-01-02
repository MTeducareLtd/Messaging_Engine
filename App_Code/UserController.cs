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

namespace ShoppingCart.BL
{
    public class UserController
    {

        //Function of MT Online
        public static SqlDataReader GetCredentials(string Username, string Password)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@usrid", SqlDbType.NVarChar);
            p[0].Value = Username;
            p[1] = new SqlParameter("@pwd", SqlDbType.NVarChar);
            p[1].Value = Password;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_USER_LOGIN", p));
        }

        public static SqlDataReader Getuserrights(string Userid, string Menuid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_id", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@menu_code", SqlDbType.NVarChar);
            p[1].Value = Menuid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUserRights", p));
        }
        public static SqlDataReader GetCompanyby_Userid(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCompanyBy_Userid", p));
        }


        public static DataSet Get_Opportunity_Search_Results_New(string Company, string Division, string Zone, string Center, string Customertype, string Institutiontype, string Boardid, string Standard, string Name, string Mobile,
        string Country, string State, string City, string Location, string Acadyear, string Productcategory, string Stream, string Applicationno, string Salesstage, string opp_from,
        string opp_to, string Followup_from, string Followup_to, string Followupoverdue, string Last_Followupoverdays, string Joining_from, string Joining_to, string Boardid1, string Year, string Agg_score,
        int Area_rank, int Overall_Rank, string Userid, string Scoretype, string Condition, string Score, string agefrom, string ageto, string Blocked, string xam_details,
        string Stage, string gender, string Orderby)
        {
            SqlParameter p = new SqlParameter("@Company", SqlDbType.NVarChar);
            p.Value = Company;
            SqlParameter p1 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p1.Value = Division;
            SqlParameter p2 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p2.Value = Zone;
            SqlParameter p3 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p3.Value = Center;
            SqlParameter p4 = new SqlParameter("@customer_type", SqlDbType.NVarChar);
            p4.Value = Customertype;
            SqlParameter p5 = new SqlParameter("@institution_type", SqlDbType.NVarChar);
            p5.Value = Institutiontype;
            SqlParameter p6 = new SqlParameter("@board_id", SqlDbType.NVarChar);
            p6.Value = Boardid;
            SqlParameter p7 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p7.Value = Standard;
            SqlParameter p8 = new SqlParameter("@name", SqlDbType.NVarChar);
            p8.Value = Name;
            SqlParameter p9 = new SqlParameter("@mobile", SqlDbType.NVarChar);
            p9.Value = Mobile;
            SqlParameter p10 = new SqlParameter("@country", SqlDbType.NVarChar);
            p10.Value = Country;
            SqlParameter p11 = new SqlParameter("@state", SqlDbType.NVarChar);
            p11.Value = State;
            SqlParameter p12 = new SqlParameter("@city", SqlDbType.NVarChar);
            p12.Value = City;
            SqlParameter p13 = new SqlParameter("@location", SqlDbType.NVarChar);
            p13.Value = Location;
            SqlParameter p14 = new SqlParameter("@acadyear", SqlDbType.NVarChar);
            p14.Value = Acadyear;
            SqlParameter p15 = new SqlParameter("@productcategory", SqlDbType.NVarChar);
            p15.Value = Productcategory;
            SqlParameter p16 = new SqlParameter("@stream", SqlDbType.NVarChar);
            p16.Value = Stream;
            SqlParameter p17 = new SqlParameter("@application_form_no", SqlDbType.NVarChar);
            p17.Value = Applicationno;
            SqlParameter p18 = new SqlParameter("@salesstage", SqlDbType.NVarChar);
            p18.Value = Salesstage;
            SqlParameter p19 = new SqlParameter("@opp_from", SqlDbType.NVarChar);
            p19.Value = opp_from;
            SqlParameter p20 = new SqlParameter("@opp_to", SqlDbType.NVarChar);
            p20.Value = opp_to;
            SqlParameter p21 = new SqlParameter("@followup_from", SqlDbType.NVarChar);
            p21.Value = Followup_from;
            SqlParameter p22 = new SqlParameter("@followup_to", SqlDbType.NVarChar);
            p22.Value = Followup_to;
            SqlParameter p23 = new SqlParameter("@followup_overdue", SqlDbType.NVarChar);
            p23.Value = Followupoverdue;
            SqlParameter p24 = new SqlParameter("@last_followupoverdays", SqlDbType.NVarChar);
            p24.Value = Last_Followupoverdays;
            SqlParameter p25 = new SqlParameter("@joining_from", SqlDbType.NVarChar);
            p25.Value = Joining_from;
            SqlParameter p26 = new SqlParameter("@joining_to", SqlDbType.NVarChar);
            p26.Value = Joining_to;
            SqlParameter p27 = new SqlParameter("@boardid", SqlDbType.NVarChar);
            p27.Value = Boardid1;
            SqlParameter p28 = new SqlParameter("@year", SqlDbType.NVarChar);
            p28.Value = Year;
            SqlParameter p29 = new SqlParameter("@agg_score", SqlDbType.NVarChar);
            p29.Value = Agg_score;
            SqlParameter p30 = new SqlParameter("@area_rank", SqlDbType.Int);
            p30.Value = Area_rank;
            SqlParameter p31 = new SqlParameter("@overall_rank", SqlDbType.Int);
            p31.Value = Overall_Rank;
            SqlParameter p32 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p32.Value = Userid;

            SqlParameter p33 = new SqlParameter("@scoretype", SqlDbType.NVarChar);
            p33.Value = Scoretype;
            SqlParameter p34 = new SqlParameter("@Condition", SqlDbType.NVarChar);
            p34.Value = Condition;
            SqlParameter p35 = new SqlParameter("@Score", SqlDbType.NVarChar);
            p35.Value = Score;

            SqlParameter p36 = new SqlParameter("@agefrom", SqlDbType.NVarChar);
            p36.Value = agefrom;
            SqlParameter p37 = new SqlParameter("@ageto", SqlDbType.NVarChar);
            p37.Value = ageto;
            SqlParameter p38 = new SqlParameter("@blocked", SqlDbType.NVarChar);
            p38.Value = Blocked;
            SqlParameter p39 = new SqlParameter("@xam_details", SqlDbType.NVarChar);
            p39.Value = xam_details;
            SqlParameter p40 = new SqlParameter("@stage", SqlDbType.NVarChar);
            p40.Value = Stage;
            SqlParameter p41 = new SqlParameter("@gender", SqlDbType.NVarChar);
            p41.Value = gender;
            //Dim p42 As New SqlParameter("@orderby", SqlDbType.NVarChar)
            //p42.Value = Orderby
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetOpportunity_SearchResults", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19, p20, p21, p22, p23, p24, p25, p26,
            p27, p28, p29, p30, p31, p32, p33, p34, p35, p36,
            p37, p38, p39, p40, p41));
        }

        public static void Insertapplog(string Userid, string Module_Name, string Description, string Ip_address, string IP_Name, string Browser, string Browser_Version)
        {
            SqlParameter p1 = new SqlParameter("@User_id", Userid);
            SqlParameter p2 = new SqlParameter("@Module_Name", Module_Name);
            SqlParameter p3 = new SqlParameter("@Description", Description);
            SqlParameter p4 = new SqlParameter("@Ip_address", Ip_address);
            SqlParameter p5 = new SqlParameter("@IP_Name", IP_Name);
            SqlParameter p6 = new SqlParameter("@Browser", Browser);
            SqlParameter p7 = new SqlParameter("@Browser_Version", Browser_Version);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Application_Log", p1, p2, p3, p4, p5,p6,p7);
        }

        public static DataSet ResetPassword(string CompanyCode, string Divisioncode)
        {
            SqlParameter p1 = new SqlParameter("@company_code", CompanyCode);
            SqlParameter p2 = new SqlParameter("@division_code", Divisioncode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Resetpassword", p1, p2));
        }

        public static DataSet GetallRoles()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRoles"));
        }

        public static DataSet GetRolesbyRoleid(int Role_id)
        {
            SqlParameter p = new SqlParameter("@Roleid", Role_id);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetRolesbyRoleid", p));
        }

        public static DataSet getALLUsers()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetALLUsers"));
        }

        public static DataSet Getusersbyuserid(int UserID)
        {
            SqlParameter p = new SqlParameter("@UserID", UserID);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetUsersbyuserid", p));
        }

        public static DataSet getallactivedepartment()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetALLactivedeppart"));
        }

        public static void UpdateUserDetails(string p_username, string p_fname, string p_lname, System.DateTime p_dob, string p_no, string p_gender, string p_email, string p_address, int p_country, int p_state,
        int p_city, string p_zcode, int AddrID, int UID)
        {
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@username", SqlDbType.NVarChar);
            p[0].Value = p_username;
            p[1] = new SqlParameter("@fname", SqlDbType.NVarChar);
            p[1].Value = p_fname;
            p[2] = new SqlParameter("@lname", SqlDbType.NVarChar);
            p[2].Value = p_lname;
            p[3] = new SqlParameter("@dob", SqlDbType.DateTime);
            p[3].Value = p_dob;
            p[4] = new SqlParameter("@ContactNo", SqlDbType.NVarChar);
            p[4].Value = p_no;
            p[5] = new SqlParameter("@gender", SqlDbType.NVarChar);
            p[5].Value = p_gender;
            p[6] = new SqlParameter("@emailId", SqlDbType.NVarChar);
            p[6].Value = p_email;
            p[7] = new SqlParameter("@Address", SqlDbType.NVarChar);
            p[7].Value = p_address;
            p[8] = new SqlParameter("@Country", SqlDbType.BigInt);
            p[8].Value = p_country;
            p[9] = new SqlParameter("@state", SqlDbType.BigInt);
            p[9].Value = p_state;
            p[10] = new SqlParameter("@City", SqlDbType.BigInt);
            p[10].Value = p_city;
            p[11] = new SqlParameter("@ZipCode", SqlDbType.VarChar);
            p[11].Value = p_zcode;
            p[12] = new SqlParameter("@AddressID", SqlDbType.Int);
            p[12].Value = AddrID;
            p[13] = new SqlParameter("@UserID", SqlDbType.Int);
            p[13].Value = UID;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "spUpdateUserDetails", p);
        }

        public static void DeleteUserByUserID(int UserID)
        {
            SqlParameter p = new SqlParameter("@UserID", UserID);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "spDeleteUserByUserID", p);
        }


        //// PC for SMS on 8 July 2015

        public static SqlDataReader Getuserrights1(string Userid, string Menuid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@user_id", SqlDbType.NVarChar);
            p[0].Value = Userid;
            p[1] = new SqlParameter("@menu_code", SqlDbType.NVarChar);
            p[1].Value = Menuid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUserRights", p));
        }

        public static SqlDataReader GetCompanyby_Userid1(string Userid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[0].Value = Userid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCompanyBy_Userid", p));
        }


    }
}