

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
    public class Enrollment
    {
        public static string enrollstudent(string Student_App_No, string Student_Reg_No, string Student_Adm_No, string Student_Final_Exam_No, string Title, string student_firstname, string student_middlename, string student_lastname, System.DateTime dob, string place_birth,
        string state_birth_code, string stud_Image, string Handphone1, string Handphone2, string Landline, string Emailid, string Flatno, string BuildingName, string StreetName, string Country_Code,
        string State_Code, string City_Code, string Pincode, string nationality, string mother_tongue, string religion, string caste, string subcaste, string category, string stud_status,
        string physically_challenege, string student_from, string company_code, string division_code, string center_code, string acad_year, string stream_code, string compulsory_language, string preference_language1, string preference_language2,
        string preference_language3, string preference_Specialization1, string preference_Specialization2, string preference_Specialization3, System.DateTime enrollon, string prm_address1, string prm_address2, string prm_streetName, string prm_country_Code, string prm_state_Code,
        string prm_city_Code, string prm_pincode, string prm_Handphone1, string prm_Handphone2, string prm_Landline, string student_fathername, string father_image, string father_qualification, string father_occupation, string father_address1,
        string father_address2, string father_streetName, string father_country_Code, string father_state_Code, string father_city_Code, string father_pincode, string father_Handphone1, string father_Handphone2, string father_Landline, string father_emailid,
        string father_income, string father_office_address, string student_mothername, string mother_image, string mother_qualification, string mother_occupation, string mother_address1, string mother_address2, string mother_streetName, string mother_country_Code,
        string mother_state_Code, string mother_city_Code, string mother_pincode, string mother_Handphone1, string mother_Handphone2, string mother_Landline, string mother_emailid, string mother_income, string mother_office_address, string student_guardianname,
        string guardian_image, string guardian_qualification, string guardian_occupation, string guardian_address1, string guardian_address2, string guardian_streetName, string guardian_country_Code, string guardian_state_Code, string guardian_city_Code, string guardian_pincode,
        string guardian_Handphone1, string guardian_Handphone2, string guardian_Landline, string guardian_emailid, string guardian_income, string guardian_office_address, string last_school_name, string last_school_place, string school_locality, string medium_instructions,
        string stay_preference, string last_exam_passed, string no_attempts, string year_passing, string month_passing, string reg_no, int max_maths_marks, int maths_marks, int max_science_marks, int science_marks,
        int max_socialstudy_marks, int socialstudy_marks, int max_english_marks, int english_marks, int max_option1_marks, int option1_marks, int max_option2_marks, int option2_marks, int max_option3_marks, int option3_marks,
        int totalmarks, int marksobtained, int overall_percent, int avg_maths_sci, string state_level_activities, string state_level_activity_details, string national_level_activities, string national_level_activity_details, string ncc_scout, string ncc_scout_details,
        string createdby, string modifiedby, string opt_sub1, string opt_sub2, string opp_id, string Other_Nationality, string Other_Mothertongue, string Guardian_Title, string Exam_Pass_State)
        {

            SqlParameter[] p = new SqlParameter[150];
            p[0] = new SqlParameter("@Student_App_No", SqlDbType.VarChar);
            p[0].Value = Student_App_No;
            p[1] = new SqlParameter("@Student_Reg_No", SqlDbType.VarChar);
            p[1].Value = Student_Reg_No;
            p[2] = new SqlParameter("@Student_Adm_No", SqlDbType.VarChar);
            p[2].Value = Student_Adm_No;
            p[3] = new SqlParameter("@Student_Final_Exam_No", SqlDbType.VarChar);
            p[3].Value = Student_Final_Exam_No;
            p[4] = new SqlParameter("@Title", SqlDbType.VarChar);
            p[4].Value = Title;
            p[5] = new SqlParameter("@student_firstname", SqlDbType.VarChar);
            p[5].Value = student_firstname;
            p[6] = new SqlParameter("@student_middlename", SqlDbType.VarChar);
            p[6].Value = student_middlename;
            p[7] = new SqlParameter("@student_lastname", SqlDbType.VarChar);
            p[7].Value = student_lastname;
            p[8] = new SqlParameter("@dob", SqlDbType.DateTime);
            p[8].Value = dob;
            p[9] = new SqlParameter("@place_birth", SqlDbType.VarChar);
            p[9].Value = place_birth;
            p[10] = new SqlParameter("@state_birth_code", SqlDbType.VarChar);
            p[10].Value = state_birth_code;
            p[11] = new SqlParameter("@stud_Image", SqlDbType.VarChar);
            p[11].Value = stud_Image;
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
            p[19] = new SqlParameter("@Country_Code", SqlDbType.VarChar);
            p[19].Value = Country_Code;
            p[20] = new SqlParameter("@State_Code", SqlDbType.VarChar);
            p[20].Value = State_Code;
            p[21] = new SqlParameter("@City_Code", SqlDbType.VarChar);
            p[21].Value = City_Code;
            p[22] = new SqlParameter("@Pincode", SqlDbType.VarChar);
            p[22].Value = Pincode;
            p[23] = new SqlParameter("@nationality", SqlDbType.VarChar);
            p[23].Value = nationality;
            p[24] = new SqlParameter("@mother_tongue", SqlDbType.VarChar);
            p[24].Value = mother_tongue;
            p[25] = new SqlParameter("@religion", SqlDbType.VarChar);
            p[25].Value = religion;
            p[26] = new SqlParameter("@caste", SqlDbType.VarChar);
            p[26].Value = caste;
            p[27] = new SqlParameter("@subcaste", SqlDbType.VarChar);
            p[27].Value = subcaste;
            p[28] = new SqlParameter("@category", SqlDbType.VarChar);
            p[28].Value = category;
            p[29] = new SqlParameter("@stud_status", SqlDbType.VarChar);
            p[29].Value = stud_status;
            p[30] = new SqlParameter("@physically_challenege", SqlDbType.VarChar);
            p[30].Value = physically_challenege;
            p[31] = new SqlParameter("@student_from", SqlDbType.VarChar);
            p[31].Value = student_from;
            p[32] = new SqlParameter("@company_code", SqlDbType.VarChar);
            p[32].Value = company_code;
            p[33] = new SqlParameter("@division_code", SqlDbType.VarChar);
            p[33].Value = division_code;
            p[34] = new SqlParameter("@center_code", SqlDbType.VarChar);
            p[34].Value = center_code;
            p[35] = new SqlParameter("@acad_year", SqlDbType.VarChar);
            p[35].Value = acad_year;
            p[36] = new SqlParameter("@stream_code", SqlDbType.VarChar);
            p[36].Value = stream_code;
            p[37] = new SqlParameter("@compulsory_language", SqlDbType.VarChar);
            p[37].Value = compulsory_language;
            p[38] = new SqlParameter("@preference_language1", SqlDbType.VarChar);
            p[38].Value = preference_language1;
            p[39] = new SqlParameter("@preference_language2", SqlDbType.VarChar);
            p[39].Value = preference_language2;
            p[40] = new SqlParameter("@preference_language3", SqlDbType.VarChar);
            p[40].Value = preference_language3;
            p[41] = new SqlParameter("@preference_Specialization1", SqlDbType.VarChar);
            p[41].Value = preference_Specialization1;
            p[42] = new SqlParameter("@preference_Specialization2", SqlDbType.VarChar);
            p[42].Value = preference_Specialization2;
            p[43] = new SqlParameter("@preference_Specialization3", SqlDbType.VarChar);
            p[43].Value = preference_Specialization3;
            p[44] = new SqlParameter("@enrollon", SqlDbType.DateTime);
            p[44].Value = enrollon;
            p[45] = new SqlParameter("@prm_address1", SqlDbType.VarChar);
            p[45].Value = prm_address1;
            p[46] = new SqlParameter("@prm_address2", SqlDbType.VarChar);
            p[46].Value = prm_address2;
            p[47] = new SqlParameter("@prm_streetName", SqlDbType.VarChar);
            p[47].Value = prm_streetName;
            p[48] = new SqlParameter("@prm_country_Code", SqlDbType.VarChar);
            p[48].Value = prm_country_Code;
            p[49] = new SqlParameter("@prm_state_Code", SqlDbType.VarChar);
            p[49].Value = prm_state_Code;
            p[50] = new SqlParameter("@prm_city_Code", SqlDbType.VarChar);
            p[50].Value = prm_city_Code;
            p[51] = new SqlParameter("@prm_pincode", SqlDbType.VarChar);
            p[51].Value = prm_pincode;
            p[52] = new SqlParameter("@prm_Handphone1", SqlDbType.VarChar);
            p[52].Value = prm_Handphone1;
            p[53] = new SqlParameter("@prm_Handphone2", SqlDbType.VarChar);
            p[53].Value = prm_Handphone2;
            p[54] = new SqlParameter("@prm_Landline", SqlDbType.VarChar);
            p[54].Value = prm_Landline;
            p[55] = new SqlParameter("@student_fathername", SqlDbType.VarChar);
            p[55].Value = student_fathername;
            p[56] = new SqlParameter("@father_image", SqlDbType.VarChar);
            p[56].Value = father_image;
            p[57] = new SqlParameter("@father_qualification", SqlDbType.VarChar);
            p[57].Value = father_qualification;
            p[58] = new SqlParameter("@father_occupation", SqlDbType.VarChar);
            p[58].Value = father_occupation;
            p[59] = new SqlParameter("@father_address1", SqlDbType.VarChar);
            p[59].Value = father_address1;
            p[60] = new SqlParameter("@father_address2", SqlDbType.VarChar);
            p[60].Value = father_address2;
            p[61] = new SqlParameter("@father_streetName", SqlDbType.VarChar);
            p[61].Value = father_streetName;
            p[62] = new SqlParameter("@father_country_Code", SqlDbType.VarChar);
            p[62].Value = father_country_Code;
            p[63] = new SqlParameter("@father_state_Code", SqlDbType.VarChar);
            p[63].Value = father_state_Code;
            p[64] = new SqlParameter("@father_city_Code", SqlDbType.VarChar);
            p[64].Value = father_city_Code;
            p[65] = new SqlParameter("@father_pincode", SqlDbType.VarChar);
            p[65].Value = father_pincode;
            p[66] = new SqlParameter("@father_Handphone1", SqlDbType.VarChar);
            p[66].Value = father_Handphone1;
            p[67] = new SqlParameter("@father_Handphone2", SqlDbType.VarChar);
            p[67].Value = father_Handphone2;
            p[68] = new SqlParameter("@father_Landline", SqlDbType.VarChar);
            p[68].Value = father_Landline;
            p[69] = new SqlParameter("@father_emailid", SqlDbType.VarChar);
            p[69].Value = father_emailid;
            p[70] = new SqlParameter("@father_income", SqlDbType.VarChar);
            p[70].Value = father_income;
            p[71] = new SqlParameter("@father_office_address", SqlDbType.VarChar);
            p[71].Value = father_office_address;
            p[72] = new SqlParameter("@student_mothername", SqlDbType.VarChar);
            p[72].Value = student_mothername;
            p[73] = new SqlParameter("@mother_image", SqlDbType.VarChar);
            p[73].Value = mother_image;
            p[74] = new SqlParameter("@mother_qualification", SqlDbType.VarChar);
            p[74].Value = mother_qualification;
            p[75] = new SqlParameter("@mother_occupation", SqlDbType.VarChar);
            p[75].Value = mother_occupation;
            p[76] = new SqlParameter("@mother_address1", SqlDbType.VarChar);
            p[76].Value = mother_address1;
            p[77] = new SqlParameter("@mother_address2", SqlDbType.VarChar);
            p[77].Value = mother_address2;
            p[78] = new SqlParameter("@mother_streetName", SqlDbType.VarChar);
            p[78].Value = mother_streetName;
            p[79] = new SqlParameter("@mother_country_Code", SqlDbType.VarChar);
            p[79].Value = mother_country_Code;
            p[80] = new SqlParameter("@mother_state_Code", SqlDbType.VarChar);
            p[80].Value = mother_state_Code;
            p[81] = new SqlParameter("@mother_city_Code", SqlDbType.VarChar);
            p[81].Value = mother_city_Code;
            p[82] = new SqlParameter("@mother_pincode", SqlDbType.VarChar);
            p[82].Value = mother_pincode;
            p[83] = new SqlParameter("@mother_Handphone1", SqlDbType.VarChar);
            p[83].Value = mother_Handphone1;
            p[84] = new SqlParameter("@mother_Handphone2", SqlDbType.VarChar);
            p[84].Value = mother_Handphone2;
            p[85] = new SqlParameter("@mother_Landline", SqlDbType.VarChar);
            p[85].Value = mother_Landline;
            p[86] = new SqlParameter("@mother_emailid", SqlDbType.VarChar);
            p[86].Value = mother_emailid;
            p[87] = new SqlParameter("@mother_income", SqlDbType.VarChar);
            p[87].Value = mother_income;
            p[88] = new SqlParameter("@mother_office_address", SqlDbType.VarChar);
            p[88].Value = mother_office_address;
            p[89] = new SqlParameter("@student_guardianname", SqlDbType.VarChar);
            p[89].Value = student_guardianname;
            p[90] = new SqlParameter("@guardian_image", SqlDbType.VarChar);
            p[90].Value = guardian_image;
            p[91] = new SqlParameter("@guardian_qualification", SqlDbType.VarChar);
            p[91].Value = guardian_qualification;
            p[92] = new SqlParameter("@guardian_occupation", SqlDbType.VarChar);
            p[92].Value = guardian_occupation;
            p[93] = new SqlParameter("@guardian_address1", SqlDbType.VarChar);
            p[93].Value = guardian_address1;
            p[94] = new SqlParameter("@guardian_address2", SqlDbType.VarChar);
            p[94].Value = guardian_address2;
            p[95] = new SqlParameter("@guardian_streetName", SqlDbType.VarChar);
            p[95].Value = guardian_streetName;
            p[96] = new SqlParameter("@guardian_country_Code", SqlDbType.VarChar);
            p[96].Value = guardian_country_Code;
            p[97] = new SqlParameter("@guardian_state_Code", SqlDbType.VarChar);
            p[97].Value = guardian_state_Code;
            p[98] = new SqlParameter("@guardian_city_Code", SqlDbType.VarChar);
            p[98].Value = guardian_city_Code;
            p[99] = new SqlParameter("@guardian_pincode", SqlDbType.VarChar);
            p[99].Value = guardian_pincode;
            p[100] = new SqlParameter("@guardian_Handphone1", SqlDbType.VarChar);
            p[100].Value = guardian_Handphone1;
            p[101] = new SqlParameter("@guardian_Handphone2", SqlDbType.VarChar);
            p[101].Value = guardian_Handphone2;
            p[102] = new SqlParameter("@guardian_Landline", SqlDbType.VarChar);
            p[102].Value = guardian_Landline;
            p[103] = new SqlParameter("@guardian_emailid", SqlDbType.VarChar);
            p[103].Value = guardian_emailid;
            p[104] = new SqlParameter("@guardian_income", SqlDbType.VarChar);
            p[104].Value = guardian_income;
            p[105] = new SqlParameter("@guardian_office_address", SqlDbType.VarChar);
            p[105].Value = guardian_office_address;
            p[106] = new SqlParameter("@last_school_name", SqlDbType.VarChar);
            p[106].Value = last_school_name;
            p[107] = new SqlParameter("@last_school_place", SqlDbType.VarChar);
            p[107].Value = last_school_place;
            p[108] = new SqlParameter("@school_locality", SqlDbType.VarChar);
            p[108].Value = school_locality;
            p[109] = new SqlParameter("@medium_instructions", SqlDbType.VarChar);
            p[109].Value = medium_instructions;
            p[110] = new SqlParameter("@stay_preference", SqlDbType.VarChar);
            p[110].Value = stay_preference;
            p[111] = new SqlParameter("@last_exam_passed", SqlDbType.VarChar);
            p[111].Value = last_exam_passed;
            p[112] = new SqlParameter("@no_attempts", SqlDbType.VarChar);
            p[112].Value = no_attempts;
            p[113] = new SqlParameter("@year_passing", SqlDbType.VarChar);
            p[113].Value = year_passing;
            p[114] = new SqlParameter("@month_passing", SqlDbType.VarChar);
            p[114].Value = month_passing;
            p[115] = new SqlParameter("@reg_no", SqlDbType.VarChar);
            p[115].Value = reg_no;
            p[116] = new SqlParameter("@max_maths_marks", SqlDbType.Int);
            p[116].Value = max_maths_marks;
            p[117] = new SqlParameter("@maths_marks", SqlDbType.Int);
            p[117].Value = maths_marks;
            p[118] = new SqlParameter("@max_science_marks", SqlDbType.Int);
            p[118].Value = max_science_marks;
            p[119] = new SqlParameter("@science_marks", SqlDbType.Int);
            p[119].Value = science_marks;
            p[120] = new SqlParameter("@max_socialstudy_marks", SqlDbType.Int);
            p[120].Value = max_socialstudy_marks;
            p[121] = new SqlParameter("@socialstudy_marks", SqlDbType.Int);
            p[121].Value = socialstudy_marks;
            p[122] = new SqlParameter("@max_english_marks", SqlDbType.Int);
            p[122].Value = max_english_marks;
            p[123] = new SqlParameter("@english_marks", SqlDbType.Int);
            p[123].Value = english_marks;
            p[124] = new SqlParameter("@max_option1_marks", SqlDbType.Int);
            p[124].Value = max_option1_marks;
            p[125] = new SqlParameter("@option1_marks", SqlDbType.Int);
            p[125].Value = option1_marks;
            p[126] = new SqlParameter("@max_option2_marks", SqlDbType.Int);
            p[126].Value = max_option2_marks;
            p[127] = new SqlParameter("@option2_marks", SqlDbType.Int);
            p[127].Value = option2_marks;
            p[128] = new SqlParameter("@max_option3_marks", SqlDbType.Int);
            p[128].Value = max_option3_marks;
            p[129] = new SqlParameter("@option3_marks", SqlDbType.Int);
            p[129].Value = option3_marks;
            p[130] = new SqlParameter("@totalmarks", SqlDbType.Int);
            p[130].Value = totalmarks;
            p[131] = new SqlParameter("@marksobtained", SqlDbType.Int);
            p[131].Value = marksobtained;
            p[132] = new SqlParameter("@overall_percent", SqlDbType.Int);
            p[132].Value = overall_percent;
            p[133] = new SqlParameter("@avg_maths_sci", SqlDbType.Int);
            p[133].Value = avg_maths_sci;
            p[134] = new SqlParameter("@state_level_activities", SqlDbType.VarChar);
            p[134].Value = state_level_activities;
            p[135] = new SqlParameter("@state_level_activity_details", SqlDbType.VarChar);
            p[135].Value = state_level_activity_details;
            p[136] = new SqlParameter("@national_level_activities", SqlDbType.VarChar);
            p[136].Value = national_level_activities;
            p[137] = new SqlParameter("@national_level_activity_details", SqlDbType.VarChar);
            p[137].Value = national_level_activity_details;
            p[138] = new SqlParameter("@ncc_scout", SqlDbType.VarChar);
            p[138].Value = ncc_scout;
            p[139] = new SqlParameter("@ncc_scout_details", SqlDbType.VarChar);
            p[139].Value = ncc_scout_details;
            p[140] = new SqlParameter("@createdby", SqlDbType.VarChar);
            p[140].Value = createdby;
            p[141] = new SqlParameter("@modifiedby", SqlDbType.VarChar);
            p[141].Value = modifiedby;
            p[142] = new SqlParameter("@student_id", SqlDbType.VarChar, 30);
            p[142].Direction = ParameterDirection.Output;
            p[143] = new SqlParameter("@opt_subject1", SqlDbType.VarChar);
            p[143].Value = opt_sub1;
            p[144] = new SqlParameter("@opt_subject2", SqlDbType.VarChar);
            p[144].Value = opt_sub2;
            p[145] = new SqlParameter("@opp_id", SqlDbType.VarChar);
            p[145].Value = opp_id;
            p[146] = new SqlParameter("@Other_Nationality", SqlDbType.VarChar);
            p[146].Value = Other_Nationality;
            p[147] = new SqlParameter("@Other_Mothertongue", SqlDbType.VarChar);
            p[147].Value = Other_Mothertongue;
            p[148] = new SqlParameter("@Guardian_Title", SqlDbType.VarChar);
            p[148].Value = Guardian_Title;
            p[149] = new SqlParameter("@Exam_Pass_State", SqlDbType.VarChar);
            p[149].Value = Exam_Pass_State;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_insert_update_studentpersonaldata", p);
            return (p[142].Value.ToString());
        }

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
    }
}

