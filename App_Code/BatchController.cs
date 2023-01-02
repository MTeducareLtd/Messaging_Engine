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
/// Summary description for BatchController
/// </summary>
public class BatchController
{
	public BatchController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet GetBatchBy_Division_Year_Standard_Centre_Cross_Batch(string Division_Code, string YearName, string StandardCode, string CentreCode, string BatchName)
    {
        SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        SqlParameter p2 = new SqlParameter("@YearName", YearName);
        SqlParameter p3 = new SqlParameter("@Standard_Code", StandardCode);
        SqlParameter p4 = new SqlParameter("@Centre_Code", CentreCode);
        SqlParameter p5 = new SqlParameter("@BatchName", BatchName);
        SqlParameter p6 = new SqlParameter("@Flag", 1);

        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatchBy_Division_Year_Standard_Centre_Cross_Batch", p1, p2, p3, p4, p5, p6));
    }
    public static DataSet GetAllActiveLMSProductBy_Stream_Cross_Division(string Stream_Code, int Flag)
    {
        SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
        SqlParameter p2 = new SqlParameter("@Flag", Flag);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllLMSProductBy_Stream__Cross_Division", p1, p2));
    }

    public static DataSet GetAllActive_AllStandard(string Division_Code)
    {
        SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStandard_New", p1));
    }

    public static DataSet GetAllActiveStreamsBy_Division_Year_Cross_Division(string Division_Code, string Acad_Year, string AAG, string Flag)
    {
        SqlParameter p1 = new SqlParameter("@division_code", Division_Code);
        SqlParameter p2 = new SqlParameter("@Acad_Year", Acad_Year);
        SqlParameter p3 = new SqlParameter("@AAG", AAG);
        SqlParameter p4 = new SqlParameter("@Flag", Flag);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllStreamsBy_Division_Year_AAG_Cross_Division", p1, p2, p3, p4));
    }

    public static DataSet GetAllActiveSubjectsBy_Stream_AAG(string Stream_Code, string AAG, int Flag)
    {
        SqlParameter p1 = new SqlParameter("@stream_code", Stream_Code);
        SqlParameter p2 = new SqlParameter("@AAG", AAG);
        SqlParameter p3 = new SqlParameter("@Flag", Flag);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllSubjectsBy_Stream_AAG_New", p1, p2, p3));
    }


    public static DataSet GetAllActiveUser_Company_Division_Zone_Center(string User_ID, string Company_Code, string Division_Code, string Zone_Code, string Flag, string DBName)
    {
        SqlParameter p1 = new SqlParameter("@user_id", User_ID);
        SqlParameter p2 = new SqlParameter("@company_code", Company_Code);
        SqlParameter p3 = new SqlParameter("@division_code", Division_Code);
        SqlParameter p4 = new SqlParameter("@Zone_Code", Zone_Code);
        SqlParameter p5 = new SqlParameter("@Flag", Flag);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetUser_Company_Division_Zone_Center", p1, p2, p3, p4, p5));

    }

    public static DataSet GetAllActiveUser_AcadYear()
    {
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetallCurrentYear"));
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

    public static DataSet GetAllActive_Standard_ForYear(string Division_Code, string YearName)
    {
        SqlParameter p1 = new SqlParameter("@divisioncode", Division_Code);
        SqlParameter p2 = new SqlParameter("@YearName", YearName);
        SqlParameter p3 = new SqlParameter("@Flag", 1);
        return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetStandard_New", p1, p2, p3));
    }


    public static int Insert_Batches_Cross_Division(string DivisionCode, string YearName, string StandardCode, string ProductCode, string SubjectCode, string CentreCode, int MaxBatchStrength, string CreatedBy, string LMS_ProductCode, string Dest_Center_Code)
    {
        SqlParameter[] p = new SqlParameter[11];
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
        p[10] = new SqlParameter("@Dest_Center_Code", Dest_Center_Code);
        p[8].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_InsertBatch_Cross_Division", p);
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

    public static DataSet GetBatchBY_PKey_Cross_Batch(string PKey)
    {
        //Try
        SqlParameter p1 = new SqlParameter("@PKey", PKey);
        SqlParameter p2 = new SqlParameter("@DBSource", "CDB");
        SqlParameter p3 = new SqlParameter("@Flag", 1);
        DataSet XYZ = SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetBatch_ByPKey_Cross_Batch", p1, p2, p3);
        return (XYZ);
    }







}