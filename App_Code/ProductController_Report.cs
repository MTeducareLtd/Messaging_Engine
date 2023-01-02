

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
    public class ProductController_Report
    {
        public static DataSet GetPayeeBy_Company(string Company_Code)
        {
            SqlParameter p1 = new SqlParameter("@Company_Code", Company_Code);
            SqlParameter p2 = new SqlParameter("@Flag", 1);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetPayeeBy_Company", p1, p2));
        }

        public static DataSet GetCheque_Status_Master()
        {
            SqlParameter p1 = new SqlParameter("@Flag", 1);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetCheque_Status_Master", p1));
        }

        public static DataSet GetBankBy_Payee_Center(string Center_Code, string Payee_Id)
        {
            int Flag = 0;
            if (Center_Code == "All")
                Center_Code = "";

            if ((string.IsNullOrEmpty(Center_Code) | Center_Code == "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 1;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 2;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 3;
            }

            SqlParameter p1 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p2 = new SqlParameter("@Payee_Id", Payee_Id);
            SqlParameter p3 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetBankBy_Payee_Center", p1, p2, p3));
        }

        public static DataSet GetBankBranchBy_Bank_Payee_Center(string Center_Code, string Payee_Id, string BankCode)
        {
            int Flag = 0;
            if (Center_Code == "All")
                Center_Code = "";
            if (Payee_Id == "All")
                Payee_Id = "";

            if ((string.IsNullOrEmpty(Center_Code) | Center_Code == "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 1;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 2;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 3;
            }

            SqlParameter p1 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p2 = new SqlParameter("@Payee_Id", Payee_Id);
            SqlParameter p3 = new SqlParameter("@Bank_Code", BankCode);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetBankBranchBy_Bank_Payee_Center", p1, p2, p3, p4));
        }

        public static DataSet GetBankAccountBy_Branch_Bank_Payee_Center(string Center_Code, string Payee_Id, string BankCode, string BranchCode)
        {
            string BankBranchCode = null;
            BankBranchCode = BankCode + BranchCode;

            int Flag = 0;
            if (Center_Code == "All")
                Center_Code = "";
            if (Payee_Id == "All")
                Payee_Id = "";

            if ((string.IsNullOrEmpty(Center_Code) | Center_Code == "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 1;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 2;
            }
            else if ((!string.IsNullOrEmpty(Center_Code) & Center_Code != "All") & !string.IsNullOrEmpty(Payee_Id))
            {
                Flag = 3;
            }

            SqlParameter p1 = new SqlParameter("@Center_Code", Center_Code);
            SqlParameter p2 = new SqlParameter("@Payee_Id", Payee_Id);
            SqlParameter p3 = new SqlParameter("@BankBranch_Code", BankBranchCode);
            SqlParameter p4 = new SqlParameter("@Flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetBankAccountBy_Branch_Bank_Payee_Center", p1, p2, p3, p4));
        }

        public static DataSet GetCourseby_Center_AcademicYear_All(string Division, string AcademicYear, int Flag, string Company)
        {
            SqlParameter p = new SqlParameter("@division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@year", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@flag", SqlDbType.Int);
            p2.Value = Flag;
            SqlParameter p3 = new SqlParameter("@company", SqlDbType.VarChar);
            p3.Value = Company;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllCoursebyAcadyear", p, p1, p2, p3));
        }

        public static DataSet GetStreambyAcadyear_Division_Course(string Division, string AcademicYear, int Flag, string Company, string CourseCode)
        {
            SqlParameter p = new SqlParameter("@division", SqlDbType.VarChar);
            p.Value = Division;
            SqlParameter p1 = new SqlParameter("@year", SqlDbType.VarChar);
            p1.Value = AcademicYear;
            SqlParameter p2 = new SqlParameter("@flag", SqlDbType.Int);
            p2.Value = Flag;
            SqlParameter p3 = new SqlParameter("@company", SqlDbType.VarChar);
            p3.Value = Company;
            SqlParameter p4 = new SqlParameter("@Material_Code", SqlDbType.VarChar);
            p4.Value = CourseCode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllStreambyAcadyearCourse", p, p1, p2, p3, p4));
        }

        public static DataSet GetAllSpecialisationbyStream(string StreamCode, string AcademicYear, int Flag)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@Streamcode", SqlDbType.VarChar);
            p1.Value = StreamCode;
            SqlParameter p2 = new SqlParameter("@year", SqlDbType.VarChar);
            p2.Value = AcademicYear;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetAllSpecialisationbyStream", p, p1, p2));
        }

        public static DataSet GetStudentPrintReceipt(string SBEntryCode, string Pricing_Procedure_Code, int Flag)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@SBEntryCode", SqlDbType.VarChar);
            p1.Value = SBEntryCode;
            SqlParameter p2 = new SqlParameter("@Pricing_Procedure_Code", SqlDbType.VarChar);
            p2.Value = Pricing_Procedure_Code;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Report_ReceiptPrint", p1, p2, p));
        }
    }
}
