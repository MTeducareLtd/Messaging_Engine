

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
//using Encryption.BL;

namespace ShoppingCart.BL
{
    public class ClsEnrollment
    {
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

        public static string CheckStudentApplicationidbyOpporid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@Val", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETAPPVALUE_BYOPPID", p);
            return (p[1].Value.ToString());
        }
        public static string enrollstudent1(string Enrollon, string Userid, string Opp_Id, string Student_Id)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@EnrollOn", SqlDbType.VarChar);
            p[0].Value = Enrollon;
            p[1] = new SqlParameter("@UserId", SqlDbType.VarChar);
            p[1].Value = Userid;
            p[2] = new SqlParameter("@Opp_Id", SqlDbType.VarChar);
            p[2].Value = Opp_Id;
            p[3] = new SqlParameter("@Student_Id", SqlDbType.VarChar, 30);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Update_EnrolContacts_Compact", p);
            return (p[3].Value.ToString());
        }


        public static string enrollstudent(string Student_App_No, string Student_reg_no, string Student_Adm_no, string Student_Final_exam_No, string Gender, string Title, string Student_Firstname, string student_middlename, string Student_Lastname, string Dob,
        string Country_Birth, string Place_Birth, string State_birth_Code, string City_Birth, string Stud_Image, string Handphone1, string Handphone2, string Landline, string Emailid, string Flatno,
        string Buildingname, string StreetName, string CountryCode, string Statecode, string CityCode, string Location, string Pincode, decimal Score, decimal Percentile, int Arearank,
        int Overallrank, string Score_Range_Type, string Nationality, string Mother_Tongue, string Religion, string Caste, string Subcaste, string Category, string Physically_Challenged, string Student_from,
        string Company_Code, string Division_code, string Center_Code, string Acad_Year, string Stream_Code, int Discipline_id, string Discipline_Desc, string Field_Id, string Field_Interested_desc, string Competitive_exam,
        string Category_TYpe_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_id, string Current_Standard_Desc, string Additional_Desc, string Board_Id, string Board_Desc,
        string Section_id, string Section_Desc, string Year_of_passing_id, string Year_of_Passing_Desc, string Current_Year_id, string Current_Year_Desc, string S_id, string Last_Course_Opted, string Enrollon, string Total_MS_Marks,
        string Total_Ms_Marks_Obt, ref string Prm_address1, string Prm_address2, string prm_streetname, string prm_Countrycode, string Prm_Statecode, string Prm_CityCode, string prm_location, string prm_Pincode, string prm_Handphone1,
        string prm_handphone2, string prm_landline, string Last_School_Name, string Last_School_Place, string School_Locality, string Medium_instruction, string Stay_preference, string Last_Exam_passed, string No_attempts, string Year_Passing,
        string Month_passing, string Reg_No, string User_id, string Opp_Id, string Other_Nationality, string Other_Mother_Tongue, string Other_religion, string Exam_passed_State, string Qualification, string Organization,
        string Designation, string Office_Address, string Office_Phone, string Annual_Income, string Location_id, string Occupation)
        {

            SqlParameter[] p = new SqlParameter[107];
            p[0] = new SqlParameter("@Student_App_No", SqlDbType.VarChar);
            p[0].Value = Student_App_No;
            p[1] = new SqlParameter("@Student_Reg_No", SqlDbType.VarChar);
            p[1].Value = Student_reg_no;
            p[2] = new SqlParameter("@Student_Adm_No", SqlDbType.VarChar);
            p[2].Value = Student_Adm_no;
            p[3] = new SqlParameter("@Student_Final_Exam_No", SqlDbType.VarChar);
            p[3].Value = Student_Final_exam_No;
            p[4] = new SqlParameter("@gender", SqlDbType.VarChar);
            p[4].Value = Gender;
            p[5] = new SqlParameter("@Title", SqlDbType.VarChar);
            p[5].Value = Title;
            p[6] = new SqlParameter("@student_firstname", SqlDbType.VarChar);
            p[6].Value = Student_Firstname;
            p[7] = new SqlParameter("@student_midname", SqlDbType.VarChar);
            p[7].Value = student_middlename;
            p[8] = new SqlParameter("@student_lastname", SqlDbType.VarChar);
            p[8].Value = Student_Lastname;
            p[9] = new SqlParameter("@dob", SqlDbType.VarChar);
            p[9].Value = Dob;
            p[10] = new SqlParameter("@country_birth", SqlDbType.VarChar);
            p[10].Value = Country_Birth;
            p[11] = new SqlParameter("@place_birth", SqlDbType.VarChar);
            p[11].Value = Place_Birth;
            p[12] = new SqlParameter("@state_birth_code", SqlDbType.VarChar);
            p[12].Value = State_birth_Code;
            p[13] = new SqlParameter("@city_birth", SqlDbType.VarChar);
            p[13].Value = City_Birth;
            p[14] = new SqlParameter("@stud_Image", SqlDbType.VarChar);
            p[14].Value = Stud_Image;
            p[15] = new SqlParameter("@Handphone1", SqlDbType.VarChar);
            p[15].Value = Handphone1;
            p[16] = new SqlParameter("@Handphone2", SqlDbType.VarChar);
            p[16].Value = Handphone2;

            p[17] = new SqlParameter("@Landline", SqlDbType.VarChar);
            p[17].Value = Landline;
            p[18] = new SqlParameter("@Emailid", SqlDbType.VarChar);
            p[18].Value = Emailid;

            p[19] = new SqlParameter("@Flatno", SqlDbType.VarChar);
            p[19].Value = Flatno;
            p[20] = new SqlParameter("@BuildingName", SqlDbType.VarChar);
            p[20].Value = Buildingname;
            p[21] = new SqlParameter("@StreetName", SqlDbType.VarChar);
            p[21].Value = StreetName;
            p[22] = new SqlParameter("@Country_Code", SqlDbType.VarChar);
            p[22].Value = CountryCode;
            p[23] = new SqlParameter("@State_Code", SqlDbType.VarChar);
            p[23].Value = Statecode;
            p[24] = new SqlParameter("@City_Code", SqlDbType.VarChar);
            p[24].Value = CityCode;
            p[25] = new SqlParameter("@location", SqlDbType.VarChar);
            p[25].Value = Location;
            p[26] = new SqlParameter("@Pincode", SqlDbType.VarChar);
            p[26].Value = Pincode;


            p[27] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[27].Value = Score;
            p[28] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[28].Value = Percentile;
            p[29] = new SqlParameter("@Area_rank", SqlDbType.Int);
            p[29].Value = Arearank;
            p[30] = new SqlParameter("@OverallRank", SqlDbType.Int);
            p[30].Value = Overallrank;
            p[31] = new SqlParameter("@score_Range_Type", SqlDbType.VarChar);
            p[31].Value = Score_Range_Type;

            p[32] = new SqlParameter("@nationality", SqlDbType.VarChar);
            p[32].Value = Nationality;
            p[33] = new SqlParameter("@mother_tongue", SqlDbType.VarChar);
            p[33].Value = Mother_Tongue;
            p[34] = new SqlParameter("@religion", SqlDbType.VarChar);
            p[34].Value = Religion;
            p[35] = new SqlParameter("@caste", SqlDbType.VarChar);
            p[35].Value = Caste;
            p[36] = new SqlParameter("@subcaste", SqlDbType.VarChar);
            p[36].Value = Subcaste;
            p[37] = new SqlParameter("@category", SqlDbType.VarChar);
            p[37].Value = Category;


            p[38] = new SqlParameter("@physically_challenge", SqlDbType.VarChar);
            p[38].Value = Physically_Challenged;
            p[39] = new SqlParameter("@student_from", SqlDbType.VarChar);
            p[39].Value = Student_from;
            p[40] = new SqlParameter("@company_code", SqlDbType.VarChar);
            p[40].Value = Company_Code;
            p[41] = new SqlParameter("@division_code", SqlDbType.VarChar);
            p[41].Value = Division_code;
            p[42] = new SqlParameter("@center_code", SqlDbType.VarChar);
            p[42].Value = Center_Code;
            p[43] = new SqlParameter("@acad_year", SqlDbType.VarChar);
            p[43].Value = Acad_Year;
            p[44] = new SqlParameter("@stream_code", SqlDbType.VarChar);
            p[44].Value = Stream_Code;



            p[45] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[45].Value = Discipline_id;
            p[46] = new SqlParameter("@Discipline_Desc", SqlDbType.VarChar);
            p[46].Value = Discipline_Desc;
            p[47] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[47].Value = Field_Id;
            p[48] = new SqlParameter("@Field_Interested_Desc", SqlDbType.VarChar);
            p[48].Value = Field_Interested_desc;
            p[49] = new SqlParameter("@Competitive_Exam", SqlDbType.VarChar);
            p[49].Value = Competitive_exam;
            p[50] = new SqlParameter("@category_TYpe_id", SqlDbType.VarChar);
            p[50].Value = Category_TYpe_Id;
            p[51] = new SqlParameter("@category_Type", SqlDbType.VarChar);
            p[51].Value = Category_Type;
            p[52] = new SqlParameter("@Institution_Type_Id", SqlDbType.VarChar);
            p[52].Value = Institution_Type_Id;
            p[53] = new SqlParameter("@Institution_Type_Desc", SqlDbType.VarChar);
            p[53].Value = Institution_Type_Desc;
            p[54] = new SqlParameter("@Institution_Description", SqlDbType.VarChar);
            p[54].Value = Institution_Description;


            p[55] = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p[55].Value = Current_Standard_id;
            p[56] = new SqlParameter("@Current_Standard_Desc", SqlDbType.VarChar);
            p[56].Value = Current_Standard_Desc;
            p[57] = new SqlParameter("@Additional_Desc", SqlDbType.VarChar);
            p[57].Value = Additional_Desc;
            p[58] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p[58].Value = Board_Id;
            p[59] = new SqlParameter("@Board_Desc", SqlDbType.VarChar);
            p[59].Value = Board_Desc;
            p[60] = new SqlParameter("@Section_Id", SqlDbType.VarChar);
            p[60].Value = Section_id;
            p[61] = new SqlParameter("@Section_Desc", SqlDbType.VarChar);
            p[61].Value = Section_Desc;

            p[62] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p[62].Value = Year_of_passing_id;
            p[63] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.VarChar);
            p[63].Value = Year_of_Passing_Desc;
            p[64] = new SqlParameter("@Current_Year_Id", SqlDbType.VarChar);
            p[64].Value = Current_Year_id;
            p[65] = new SqlParameter("@Current_Year_Desc", SqlDbType.VarChar);
            p[65].Value = Current_Year_Desc;
            p[66] = new SqlParameter("@S_Id", SqlDbType.VarChar);
            p[66].Value = S_id;
            p[67] = new SqlParameter("@Last_Course_Opted", SqlDbType.VarChar);
            p[67].Value = Last_Course_Opted;
            p[68] = new SqlParameter("@enrollon", SqlDbType.VarChar);
            p[68].Value = Enrollon;
            p[69] = new SqlParameter("@total_ms_marks", SqlDbType.VarChar);
            p[69].Value = Total_MS_Marks;
            p[70] = new SqlParameter("@total_ms_marks_obt", SqlDbType.VarChar);
            p[70].Value = Total_Ms_Marks_Obt;

            p[71] = new SqlParameter("@prm_address1", SqlDbType.VarChar);
            p[71].Value = Prm_address1;
            p[72] = new SqlParameter("@prm_address2", SqlDbType.VarChar);
            p[72].Value = Prm_address2;
            p[73] = new SqlParameter("@prm_streetName", SqlDbType.VarChar);
            p[73].Value = prm_streetname;
            p[74] = new SqlParameter("@prm_country_Code", SqlDbType.VarChar);
            p[74].Value = prm_Countrycode;
            p[75] = new SqlParameter("@prm_state_Code", SqlDbType.VarChar);
            p[75].Value = Prm_Statecode;
            p[76] = new SqlParameter("@prm_city_Code", SqlDbType.VarChar);
            p[76].Value = Prm_CityCode;
            p[77] = new SqlParameter("@prm_location", SqlDbType.VarChar);
            p[77].Value = prm_location;

            p[78] = new SqlParameter("@prm_pincode", SqlDbType.VarChar);
            p[78].Value = prm_Pincode;
            p[79] = new SqlParameter("@prm_Handphone1", SqlDbType.VarChar);
            p[79].Value = prm_Handphone1;
            p[80] = new SqlParameter("@prm_Handphone2", SqlDbType.VarChar);
            p[80].Value = prm_handphone2;
            p[81] = new SqlParameter("@prm_Landline", SqlDbType.VarChar);
            p[81].Value = prm_landline;


            p[82] = new SqlParameter("@last_school_name", SqlDbType.VarChar);
            p[82].Value = Last_School_Name;
            p[83] = new SqlParameter("@last_school_place", SqlDbType.VarChar);
            p[83].Value = Last_School_Place;
            p[84] = new SqlParameter("@school_locality", SqlDbType.VarChar);
            p[84].Value = School_Locality;

            p[85] = new SqlParameter("@medium_instructions", SqlDbType.VarChar);
            p[85].Value = Medium_instruction;
            p[86] = new SqlParameter("@stay_preference", SqlDbType.VarChar);
            p[86].Value = Stay_preference;

            p[87] = new SqlParameter("@last_exam_passed", SqlDbType.VarChar);
            p[87].Value = Last_Exam_passed;

            p[88] = new SqlParameter("@no_attempts", SqlDbType.VarChar);
            p[88].Value = No_attempts;
            p[89] = new SqlParameter("@year_passing", SqlDbType.VarChar);
            p[89].Value = Year_Passing;
            p[90] = new SqlParameter("@month_passing", SqlDbType.VarChar);
            p[90].Value = Month_passing;
            p[91] = new SqlParameter("@reg_no", SqlDbType.VarChar);
            p[91].Value = Reg_No;

            p[92] = new SqlParameter("@userid", SqlDbType.VarChar);
            p[92].Value = User_id;


            p[93] = new SqlParameter("@student_id", SqlDbType.VarChar, 30);
            p[93].Direction = ParameterDirection.Output;
            p[94] = new SqlParameter("@opp_id", SqlDbType.VarChar);
            p[94].Value = Opp_Id;
            p[95] = new SqlParameter("@other_nationality", SqlDbType.VarChar);
            p[95].Value = Other_Nationality;
            p[96] = new SqlParameter("@other_mother_tongue", SqlDbType.VarChar);
            p[96].Value = Other_Mother_Tongue;
            p[97] = new SqlParameter("@other_religion", SqlDbType.VarChar);
            p[97].Value = Other_religion;

            p[98] = new SqlParameter("@exam_pass_state", SqlDbType.VarChar);
            p[98].Value = Exam_passed_State;
            p[99] = new SqlParameter("@qualification", SqlDbType.VarChar);
            p[99].Value = Qualification;
            p[100] = new SqlParameter("@organization", SqlDbType.VarChar);
            p[100].Value = Organization;
            p[101] = new SqlParameter("@Designation", SqlDbType.VarChar);
            p[101].Value = Designation;
            p[102] = new SqlParameter("@Office_Address", SqlDbType.VarChar);
            p[102].Value = Office_Address;
            p[103] = new SqlParameter("@Office_phone", SqlDbType.VarChar);
            p[103].Value = Office_Phone;
            p[104] = new SqlParameter("@annual_income", SqlDbType.VarChar);
            p[104].Value = Annual_Income;
            p[105] = new SqlParameter("@Location_id", SqlDbType.VarChar);
            p[105].Value = Location_id;
            p[106] = new SqlParameter("@occupation", SqlDbType.VarChar);
            p[106].Value = Occupation;

            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_insert_update_enrolcontacts", p);
            return (p[93].Value.ToString());
        }

        public static string AddEditSecondaryContact(string Con_id, string Con_type_id, string Con_Type_desc, string Con_title, string Con_Firstname, string Con_midname, string Con_lastname, decimal Score, decimal Percentile, int Area_Rank,
        int Overall_Rank, string Score_Range_Type, string Handphone1, string Handphone2, string Landline, string Emailid, string Flatno, string BuildingName, string StreetName, string Country,
        string State, string City, string Pincode, string Category_Type_Id, string Category_Type, string Institution_Type_Id, string Institution_Type_Desc, string Institution_Description, string Current_Standard_Id, string Current_Standard_Desc,
        string Additional_Desc, string Board_Id, string Board_Desc, string Section_Id, string Section_Desc, string Year_of_Passing_ID, string Year_of_Passing_Desc, string Current_Year_Id, string Current_Year_Desc, string Student_Id,
        string Last_Course_Opted, int Discipline_Id, string Discipline_Desc, int Field_ID, string Field_Interested_Desc, string Competitive_Exam, int total_ms_marks, string total_ms_marks_obt, string primary_con_id, System.DateTime dob,
        string place_birth, string state_birth_code, string Image, string nationality, string mother_tongue, string religion, string caste, string subcaste, string prm_address1, string prm_address2,
        string prm_streetName, string prm_country_Code, string prm_state_Code, string prm_city_Code, string prm_location_id, string prm_pincode, string prm_Handphone1, string prm_Handphone2, string prm_Landline, string qualification,
        string organization, string Designation, string Office_Address, string Office_phone, string annual_income, string Location_id, string Gender, string country_birth, string userid, string city_birth,
        string occupation, string OTHER_NATIONALITY, string other_mother_tongue, string other_religion)
        {

            SqlParameter[] p = new SqlParameter[85];
            p[0] = new SqlParameter("@Con_Id", SqlDbType.VarChar);
            p[0].Value = Con_id;
            p[1] = new SqlParameter("@Con_type_id", SqlDbType.VarChar);
            p[1].Value = Con_type_id;
            p[2] = new SqlParameter("@Con_Type_desc", SqlDbType.VarChar);
            p[2].Value = Con_Type_desc;
            p[3] = new SqlParameter("@Con_title", SqlDbType.VarChar);
            p[3].Value = Con_title;
            p[4] = new SqlParameter("@Con_Firstname", SqlDbType.VarChar);
            p[4].Value = Con_Firstname;
            p[5] = new SqlParameter("@Con_midname", SqlDbType.VarChar);
            p[5].Value = Con_midname;
            p[6] = new SqlParameter("@Con_lastname", SqlDbType.VarChar);
            p[6].Value = Con_lastname;
            p[7] = new SqlParameter("@Score", SqlDbType.Decimal);
            p[7].Value = Score;
            p[8] = new SqlParameter("@Percentile", SqlDbType.Decimal);
            p[8].Value = Percentile;
            p[9] = new SqlParameter("@Area_Rank", SqlDbType.Int);
            p[9].Value = Area_Rank;
            p[10] = new SqlParameter("@Overall_Rank", SqlDbType.Int);
            p[10].Value = Overall_Rank;

            p[11] = new SqlParameter("@Score_Range_Type", SqlDbType.VarChar);
            p[11].Value = Score_Range_Type;
            p[12] = new SqlParameter("@Handphone1", SqlDbType.VarChar);
            p[12].Value = Handphone1;
            p[13] = new SqlParameter("@Handphone2", SqlDbType.VarChar);
            p[13].Value = Handphone2;
            p[14] = new SqlParameter("@Landline", SqlDbType.VarChar);
            p[14].Value = Landline;
            p[15] = new SqlParameter("@Emailid", SqlDbType.VarChar);
            p[15].Value = Emailid;
            p[16] = new SqlParameter("@Flatno", SqlDbType.VarChar);
            p[16].Value = Flatno;


            p[17] = new SqlParameter("@BuildingName", SqlDbType.VarChar);
            p[17].Value = BuildingName;
            p[18] = new SqlParameter("@StreetName", SqlDbType.VarChar);
            p[18].Value = StreetName;

            p[19] = new SqlParameter("@Country", SqlDbType.VarChar);
            p[19].Value = Country;
            p[20] = new SqlParameter("@State", SqlDbType.VarChar);
            p[20].Value = State;
            p[21] = new SqlParameter("@City", SqlDbType.VarChar);
            p[21].Value = City;
            p[22] = new SqlParameter("@Pincode", SqlDbType.VarChar);
            p[22].Value = Pincode;
            p[23] = new SqlParameter("@Category_Type_Id", SqlDbType.VarChar);
            p[23].Value = Category_Type_Id;
            p[24] = new SqlParameter("@Category_Type", SqlDbType.VarChar);
            p[24].Value = Category_Type;
            p[25] = new SqlParameter("@Institution_Type_Id", SqlDbType.VarChar);
            p[25].Value = Institution_Type_Id;
            p[26] = new SqlParameter("@Institution_Type_Desc", SqlDbType.VarChar);
            p[26].Value = Institution_Type_Desc;

            p[27] = new SqlParameter("@Institution_Description", SqlDbType.VarChar);
            p[27].Value = Institution_Description;
            p[28] = new SqlParameter("@Current_Standard_Id", SqlDbType.VarChar);
            p[28].Value = Current_Standard_Id;
            p[29] = new SqlParameter("@Current_Standard_Desc", SqlDbType.VarChar);
            p[29].Value = Current_Standard_Desc;
            p[30] = new SqlParameter("@Additional_Desc", SqlDbType.VarChar);
            p[30].Value = Additional_Desc;
            p[31] = new SqlParameter("@Board_Id", SqlDbType.VarChar);
            p[31].Value = Board_Id;
            p[32] = new SqlParameter("@Board_Desc", SqlDbType.VarChar);
            p[32].Value = Board_Desc;

            p[33] = new SqlParameter("@Section_Id", SqlDbType.VarChar);
            p[33].Value = Section_Id;
            p[34] = new SqlParameter("@Section_Desc", SqlDbType.VarChar);
            p[34].Value = Section_Desc;
            p[35] = new SqlParameter("@Year_of_Passing_ID", SqlDbType.VarChar);
            p[35].Value = Year_of_Passing_ID;
            p[36] = new SqlParameter("@Year_of_Passing_Desc", SqlDbType.VarChar);
            p[36].Value = Year_of_Passing_Desc;
            p[37] = new SqlParameter("@Current_Year_Id", SqlDbType.VarChar);
            p[37].Value = Current_Year_Id;
            p[38] = new SqlParameter("@Current_Year_Desc", SqlDbType.VarChar);
            p[38].Value = Current_Year_Desc;


            p[39] = new SqlParameter("@Student_Id", SqlDbType.VarChar);
            p[39].Value = Student_Id;
            p[40] = new SqlParameter("@Last_Course_Opted", SqlDbType.VarChar);
            p[40].Value = Last_Course_Opted;
            p[41] = new SqlParameter("@Discipline_Id", SqlDbType.Int);
            p[41].Value = Discipline_Id;
            p[42] = new SqlParameter("@Discipline_Desc", SqlDbType.VarChar);
            p[42].Value = Discipline_Desc;
            p[43] = new SqlParameter("@Field_ID", SqlDbType.Int);
            p[43].Value = Field_ID;
            p[44] = new SqlParameter("@Field_Interested_Desc", SqlDbType.VarChar);
            p[44].Value = Field_Interested_Desc;
            p[45] = new SqlParameter("@Competitive_Exam", SqlDbType.VarChar);
            p[45].Value = Competitive_Exam;



            p[46] = new SqlParameter("@total_ms_marks", SqlDbType.Int);
            p[46].Value = total_ms_marks;
            p[47] = new SqlParameter("@total_ms_marks_obt", SqlDbType.Int);
            p[47].Value = total_ms_marks_obt;
            p[48] = new SqlParameter("@primary_con_id", SqlDbType.VarChar);
            p[48].Value = primary_con_id;
            p[49] = new SqlParameter("@dob", SqlDbType.DateTime);
            p[49].Value = dob;


            p[50] = new SqlParameter("@place_birth", SqlDbType.VarChar);
            p[50].Value = place_birth;
            p[51] = new SqlParameter("@state_birth_code", SqlDbType.VarChar);
            p[51].Value = state_birth_code;
            p[52] = new SqlParameter("@Image", SqlDbType.VarChar);
            p[52].Value = Image;
            p[53] = new SqlParameter("@nationality", SqlDbType.VarChar);
            p[53].Value = nationality;
            p[54] = new SqlParameter("@mother_tongue", SqlDbType.VarChar);
            p[54].Value = mother_tongue;
            p[55] = new SqlParameter("@religion", SqlDbType.VarChar);
            p[55].Value = religion;


            p[56] = new SqlParameter("@caste", SqlDbType.VarChar);
            p[56].Value = caste;
            p[57] = new SqlParameter("@subcaste", SqlDbType.VarChar);
            p[57].Value = subcaste;
            p[58] = new SqlParameter("@prm_address1", SqlDbType.VarChar);
            p[58].Value = prm_address1;
            p[59] = new SqlParameter("@prm_address2", SqlDbType.VarChar);
            p[59].Value = prm_address2;


            p[60] = new SqlParameter("@prm_streetName", SqlDbType.VarChar);
            p[60].Value = prm_streetName;
            p[61] = new SqlParameter("@prm_country_Code", SqlDbType.VarChar);
            p[61].Value = prm_country_Code;
            p[62] = new SqlParameter("@prm_state_Code", SqlDbType.VarChar);
            p[62].Value = prm_state_Code;
            p[63] = new SqlParameter("@prm_city_Code", SqlDbType.VarChar);
            p[63].Value = prm_city_Code;
            p[64] = new SqlParameter("@prm_location_id", SqlDbType.VarChar);
            p[64].Value = prm_location_id;

            p[65] = new SqlParameter("@prm_pincode", SqlDbType.VarChar);
            p[65].Value = prm_pincode;
            p[66] = new SqlParameter("@prm_Handphone1", SqlDbType.VarChar);
            p[66].Value = prm_Handphone1;
            p[67] = new SqlParameter("@prm_Handphone2", SqlDbType.VarChar);
            p[67].Value = prm_Handphone2;
            p[68] = new SqlParameter("@prm_Landline", SqlDbType.VarChar);
            p[68].Value = prm_Landline;

            p[69] = new SqlParameter("@qualification", SqlDbType.VarChar);
            p[69].Value = qualification;
            p[70] = new SqlParameter("@organization", SqlDbType.VarChar);
            p[70].Value = organization;
            p[71] = new SqlParameter("@Designation", SqlDbType.VarChar);
            p[71].Value = Designation;
            p[72] = new SqlParameter("@Office_Address", SqlDbType.VarChar);
            p[72].Value = Office_Address;
            p[73] = new SqlParameter("@Office_phone", SqlDbType.VarChar);
            p[73].Value = Office_phone;
            p[74] = new SqlParameter("@annual_income", SqlDbType.VarChar);
            p[74].Value = annual_income;
            p[75] = new SqlParameter("@Location_id", SqlDbType.VarChar);
            p[75].Value = Location_id;
            p[76] = new SqlParameter("@Gender", SqlDbType.VarChar);
            p[76].Value = Gender;
            p[77] = new SqlParameter("@country_birth", SqlDbType.VarChar);
            p[77].Value = country_birth;
            p[78] = new SqlParameter("@userid", SqlDbType.VarChar);
            p[78].Value = userid;
            p[79] = new SqlParameter("@city_birth", SqlDbType.VarChar);
            p[79].Value = city_birth;
            p[80] = new SqlParameter("@occupation", SqlDbType.VarChar);
            p[80].Value = occupation;
            p[81] = new SqlParameter("@OTHER_NATIONALITY", SqlDbType.VarChar);
            p[81].Value = OTHER_NATIONALITY;
            p[82] = new SqlParameter("@other_mother_tongue", SqlDbType.VarChar);
            p[82].Value = other_mother_tongue;
            p[83] = new SqlParameter("@other_religion", SqlDbType.VarChar);
            p[83].Value = other_religion;
            p[84] = new SqlParameter("@CON_ID_RESPONSE", SqlDbType.VarChar, 30);
            p[84].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Add_Sec_Contact_Enrol", p);
            return (p[84].Value.ToString());
        }

        public static void Insertpreference(string Oppid, string material_Code, string material_desc, string preference, int Flag, string userid)
        {
            SqlParameter p1 = new SqlParameter("@opp_id", Oppid);
            SqlParameter p2 = new SqlParameter("@material_code", material_Code);
            SqlParameter p3 = new SqlParameter("@material_desc", material_desc);
            SqlParameter p4 = new SqlParameter("@preference", preference);
            SqlParameter p5 = new SqlParameter("@flag", Flag);
            SqlParameter p6 = new SqlParameter("@userid", userid);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_SUBJECT_PREFERENCE", p1, p2, p3, p4, p5, p6);
        }

    }
}
