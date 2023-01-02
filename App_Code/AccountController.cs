
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
    public class AccountController
    {
        public static DataSet GetPricingbyOppId(int Flag, string Oppor_Id, string DocumentType, string Transport)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@OPPID", Oppor_Id);
            SqlParameter p3 = new SqlParameter("@DOC_TYPE", DocumentType);
            SqlParameter p4 = new SqlParameter("@Transport", Transport);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_PDT_PROCESS", p1, p2, p3, p4));
        }
        public static DataSet GetorderdetailsbyOppidandSbentrycode(int Flag, string Cur_sb_code, string Opp_id)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@Sbentrycode", Cur_sb_code);
            SqlParameter p3 = new SqlParameter("@Oppid", Opp_id);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Order_Details", p1, p2, p3));
        }
        public static DataSet GetPricingforpromote(int Flag, string Oppor_Id, string DocumentType, string Streamcode, string Transport)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@OPPID", Oppor_Id);
            SqlParameter p3 = new SqlParameter("@DOC_TYPE", DocumentType);
            SqlParameter p4 = new SqlParameter("@Stream", Streamcode);
            SqlParameter p5 = new SqlParameter("@Transport", Transport);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_PDT_PROCESS_PROMOTE", p1, p2, p3, p4, p5));
        }

        public static SqlDataReader GetStudentDetailsbyOppid(string Oppid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Oppid", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_getstudentinfoby_oppid", p));
        }

        public static SqlDataReader GetlanguageValuebyMaterialCode(string CenterCode, string StreamCode, string MaterialCode)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@Center_Code", SqlDbType.NVarChar);
            p[0].Value = CenterCode;
            p[1] = new SqlParameter("@Stream_Code", SqlDbType.NVarChar);
            p[1].Value = StreamCode;
            p[2] = new SqlParameter("@Material_Code", SqlDbType.NVarChar);
            p[2].Value = MaterialCode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_getvoucheramountby_materialcode", p));
        }


        public static DataSet GetPricingprocedureHeaderValue(string Oppor_Id, string MaterialCode, string DocumentType, string Transport)
        {
            SqlParameter p1 = new SqlParameter("@OPPID", Oppor_Id);
            SqlParameter p2 = new SqlParameter("@material_code", MaterialCode);
            SqlParameter p3 = new SqlParameter("@doc_type", DocumentType);
            SqlParameter p4 = new SqlParameter("@Transport", Transport);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CALCULATE_FEESHEAD", p1, p2, p3, p4));
        }

        public static DataSet GetFeesComponent(int Flag,string Oppid)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@OppCode", Oppid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Fee_Component", p1,p2));
        }

        public static DataSet GetStudentreceiptbySBEntrycode(int Flag, string SBentrycode,string userid)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@sbentryCode", SBentrycode);
            SqlParameter p3 = new SqlParameter("@userid", userid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Insert_Receipt_for_Events", p1, p2, p3));
        }
        public static DataSet GetPricingprocedureHeaderValue_New(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12));
        }

        public static void InserttoGetPricingprocedurevaluebyoppid(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12);
        }

        public static void InserttoGetPricingprocedurevaluebyoppidStreamChange(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_STREAMCHANGE", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12,p13);
        }

       // public static void InserttoGetPricingprocedurevaluebyoppidStreamChange(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
       //string Doc_type, int Flag, string Stream)
       // {
       //     SqlParameter p1 = new SqlParameter("@oppid", Oppid);
       //     SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
       //     SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
       //     SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
       //     SqlParameter p5 = new SqlParameter("@UOM", Uomid);
       //     SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
       //     SqlParameter p7 = new SqlParameter("@unit", Unit);
       //     SqlParameter p8 = new SqlParameter("@qty", Quantity);
       //     SqlParameter p9 = new SqlParameter("@amount", Amount);
       //     SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
       //     SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
       //     SqlParameter p12 = new SqlParameter("@flag", Flag);
       //     SqlParameter p13 = new SqlParameter("@Stream", Stream);
       //     SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_STREAMCHANGE", p1, p2, p3, p4, p5, p6, p7,
       //     p8, p9, p10, p11, p12, p13);
       // }

        public static DataSet GetPricingprocedureHeaderValue_NewStreamChange(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_STREAMCHANGE", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12,p13));
        }
        //Public Shared Sub InserttoGetPricingprocedurevaluebyoppid_AddRemove(ByVal Oppid As String, ByVal Materialcode As String, ByVal Voucher_type As String, _
        //                                                          ByVal Voucher_Amt As String, ByVal Uomid As String, ByVal Uomname As String, _
        //                                                          ByVal Unit As String, ByVal Quantity As String, ByVal Amount As String, _
        //                                                          ByVal Remarks As String, ByVal Doc_type As String, ByVal Flag As Integer, ByVal Materialtype As String)
        //    Dim p1 As New SqlParameter("@oppid", Oppid)
        //    Dim p2 As New SqlParameter("@materialcode", Materialcode)
        //    Dim p3 As New SqlParameter("@Voucher_Typ", Voucher_type)
        //    Dim p4 As New SqlParameter("@VOUCHER_AMT", Voucher_Amt)
        //    Dim p5 As New SqlParameter("@UOM", Uomid)
        //    Dim p6 As New SqlParameter("@UOMNAME", Uomname)
        //    Dim p7 As New SqlParameter("@unit", Unit)
        //    Dim p8 As New SqlParameter("@qty", Quantity)
        //    Dim p9 As New SqlParameter("@amount", Amount)
        //    Dim p10 As New SqlParameter("@Remarks", Remarks)
        //    Dim p11 As New SqlParameter("@doc_type", Doc_type)
        //    Dim p12 As New SqlParameter("@flag", Flag)
        //    Dim p13 As New SqlParameter("@MaterialType", Materialtype)
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_AddRemove", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12)
        //End Sub
        public static void InserttoGetPricingprocedurevaluebyoppidPromote(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Promote", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13);
        }
        public static void InserttoGetPricingprocedurevaluebyoppid_AddRemove(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream, string Materialtype, string orderid)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlParameter p14 = new SqlParameter("@MaterialType", Materialtype);
            SqlParameter p15 = new SqlParameter("@Orderno", orderid);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_AddRemove", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13, p14, p15);
        }

        public static void InserttoGetPricingprocedurevaluebyoppid_Remove(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream, string Materialtype, string orderid)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlParameter p14 = new SqlParameter("@MaterialType", Materialtype);
            SqlParameter p15 = new SqlParameter("@Orderno", orderid);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Remove_Product", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13, p14, p15);
        }
        //public static void InserttoGetPricingprocedurevaluebyoppid_AddRemove(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        //string Doc_type, int Flag, string Stream, string Materialtype, string orderid)
        //{
        //    SqlParameter p1 = new SqlParameter("@oppid", Oppid);
        //    SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
        //    SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
        //    SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
        //    SqlParameter p5 = new SqlParameter("@UOM", Uomid);
        //    SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
        //    SqlParameter p7 = new SqlParameter("@unit", Unit);
        //    SqlParameter p8 = new SqlParameter("@qty", Quantity);
        //    SqlParameter p9 = new SqlParameter("@amount", Amount);
        //    SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
        //    SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
        //    SqlParameter p12 = new SqlParameter("@flag", Flag);
        //    SqlParameter p13 = new SqlParameter("@Stream", Stream);
        //    SqlParameter p14 = new SqlParameter("@MaterialType", Materialtype);
        //    SqlParameter p15 = new SqlParameter("@Orderno", orderid);
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD", p1, p2, p3, p4, p5, p6, p7,
        //    p8, p9, p10, p11, p12, p13, p14, p15);
        //}
        public static DataSet GetPricingprocedureHeaderValue_NewPromote(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Promote", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13));
        }

        public static DataSet GetStudentledger(string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string Status, string Userid, int Flag, string report)
        {
            SqlParameter p1 = new SqlParameter("@company", Company);
            SqlParameter p2 = new SqlParameter("@division", Division);
            SqlParameter p3 = new SqlParameter("@zone", Zone);
            SqlParameter p4 = new SqlParameter("@center", Center);
            SqlParameter p5 = new SqlParameter("@year", Academicyear);
            SqlParameter p6 = new SqlParameter("@stream", Stream);
            SqlParameter p7 = new SqlParameter("@status", Status);
            SqlParameter p8 = new SqlParameter("@userid", Userid);
            SqlParameter p9 = new SqlParameter("@flag", Flag);
            SqlParameter p10 = new SqlParameter("@report", report);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_LedgerReport", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10));
        }

        public static DataSet GetPricingprocedureHeaderValue_AddRemove(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
        string Doc_type, int Flag, string Stream, string Materialtype, string orderid)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlParameter p14 = new SqlParameter("@Materialtype", Materialtype);
            SqlParameter p15 = new SqlParameter("@Orderno", orderid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_AddRemove", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13, p14, p15));
        }
        public static DataSet GetPricingprocedureHeaderValue_Remove(string Oppid, string Materialcode, string Voucher_type, string Voucher_Amt, string Uomid, string Uomname, string Unit, string Quantity, string Amount, string Remarks,
       string Doc_type, int Flag, string Stream, string Materialtype, string orderid)
        {
            SqlParameter p1 = new SqlParameter("@oppid", Oppid);
            SqlParameter p2 = new SqlParameter("@materialcode", Materialcode);
            SqlParameter p3 = new SqlParameter("@Voucher_Typ", Voucher_type);
            SqlParameter p4 = new SqlParameter("@VOUCHER_AMT", Voucher_Amt);
            SqlParameter p5 = new SqlParameter("@UOM", Uomid);
            SqlParameter p6 = new SqlParameter("@UOMNAME", Uomname);
            SqlParameter p7 = new SqlParameter("@unit", Unit);
            SqlParameter p8 = new SqlParameter("@qty", Quantity);
            SqlParameter p9 = new SqlParameter("@amount", Amount);
            SqlParameter p10 = new SqlParameter("@Remarks", Remarks);
            SqlParameter p11 = new SqlParameter("@doc_type", Doc_type);
            SqlParameter p12 = new SqlParameter("@flag", Flag);
            SqlParameter p13 = new SqlParameter("@Stream", Stream);
            SqlParameter p14 = new SqlParameter("@Materialtype", Materialtype);
            SqlParameter p15 = new SqlParameter("@Orderno", orderid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Remove_Product", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13, p14, p15));
        }
        //Public Shared Function GetPricingprocedureHeaderValuePromote(ByVal Oppor_Id As String, ByVal MaterialCode As String, _
        //                                                             ByVal DocumentType As String, ByVal StreamCode As String, _
        //                                                             ByVal Transport As String) As DataSet
        //    Dim p1 As New SqlParameter("@OPPID", Oppor_Id)
        //    Dim p2 As New SqlParameter("@material_code", MaterialCode)
        //    Dim p3 As New SqlParameter("@doc_type", DocumentType)
        //    Dim p4 As New SqlParameter("@Stream", StreamCode)
        //    Dim p5 As New SqlParameter("@Transport", Transport)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CALCULATE_FEESHEAD_PROMOTE", p1, p2, p3, p4, p5))
        //End Function
        //Public Shared Function GetPricingprocedureHeaderValuePromote_New(ByVal Oppor_Id As String, ByVal MaterialCode As String, _
        //                                                            ByVal DocumentType As String, ByVal StreamCode As String, _
        //                                                            ByVal Transport As String) As DataSet
        //    Dim p1 As New SqlParameter("@OPPID", Oppor_Id)
        //    Dim p2 As New SqlParameter("@material_code", MaterialCode)
        //    Dim p3 As New SqlParameter("@doc_type", DocumentType)
        //    Dim p4 As New SqlParameter("@Stream", StreamCode)
        //    Dim p5 As New SqlParameter("@Transport", Transport)
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Promote", p1, p2, p3, p4, p5))
        //End Function
        //Public Shared Sub InserttoGetPricingprocedurevaluebyoppid_Promote(ByVal Oppid As String, ByVal Materialcode As String, ByVal Voucher_type As String, _
        //                                                          ByVal Voucher_Amt As String, ByVal Uomid As String, ByVal Uomname As String, _
        //                                                          ByVal Unit As String, ByVal Quantity As String, ByVal Amount As String, _
        //                                                          ByVal Remarks As String, ByVal Doc_type As String, ByVal Flag As Integer, ByVal Stream As String)
        //    Dim p1 As New SqlParameter("@oppid", Oppid)
        //    Dim p2 As New SqlParameter("@materialcode", Materialcode)
        //    Dim p3 As New SqlParameter("@Voucher_Typ", Voucher_type)
        //    Dim p4 As New SqlParameter("@VOUCHER_AMT", Voucher_Amt)
        //    Dim p5 As New SqlParameter("@UOM", Uomid)
        //    Dim p6 As New SqlParameter("@UOMNAME", Uomname)
        //    Dim p7 As New SqlParameter("@unit", Unit)
        //    Dim p8 As New SqlParameter("@qty", Quantity)
        //    Dim p9 As New SqlParameter("@amount", Amount)
        //    Dim p10 As New SqlParameter("@Remarks", Remarks)
        //    Dim p11 As New SqlParameter("@doc_type", Doc_type)
        //    Dim p12 As New SqlParameter("@flag", Flag)
        //    Dim p13 As New SqlParameter("@Stream", Stream)
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_CAL_FEESHEAD_Promote", p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13)
        //End Sub
        public static DataSet GetAllPayplan()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllPay_Plan"));
        }

        public static DataSet GetallChequeReturnReason()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetChequeReturnReason"));
        }

        public static DataSet Get_Account_Search_Results(string StudentName, string Applicationno, string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string Userid, string Customer_Type,
        string Institutiontype, string Boardid, string Standard, string Mobile, string Country, string State, string City, string Location, string Productcategory, string Fromdate,
        string Todate, string OrderStatus, string Sbentrycode, string Active, string Promoted)
        {
            SqlParameter p = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            p.Value = StudentName;
            SqlParameter p1 = new SqlParameter("@Applicationno", SqlDbType.NVarChar);
            p1.Value = Applicationno;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@academicyear", SqlDbType.NVarChar);
            p6.Value = Academicyear;
            SqlParameter p7 = new SqlParameter("@Stream", SqlDbType.NVarChar);
            p7.Value = Stream;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;

            SqlParameter p9 = new SqlParameter("@customer_type", SqlDbType.NVarChar);
            p9.Value = Customer_Type;
            SqlParameter p10 = new SqlParameter("@institution_type", SqlDbType.NVarChar);
            p10.Value = Institutiontype;
            SqlParameter p11 = new SqlParameter("@board_id", SqlDbType.NVarChar);
            p11.Value = Boardid;
            SqlParameter p12 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p12.Value = Standard;
            SqlParameter p13 = new SqlParameter("@MOBILE", SqlDbType.NVarChar);
            p13.Value = Mobile;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@location", SqlDbType.NVarChar);
            p17.Value = Location;

            SqlParameter P18 = new SqlParameter("@productcategory", SqlDbType.NVarChar);
            P18.Value = Productcategory;
            SqlParameter p19 = new SqlParameter("@fromdt", SqlDbType.NVarChar);
            p19.Value = Fromdate;
            SqlParameter p20 = new SqlParameter("@todt", SqlDbType.NVarChar);
            p20.Value = Todate;
            SqlParameter p21 = new SqlParameter("@orderstatus", SqlDbType.NVarChar);
            p21.Value = OrderStatus;
            SqlParameter p22 = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p22.Value = Sbentrycode;
            SqlParameter p23 = new SqlParameter("@flag", SqlDbType.NVarChar);
            p23.Value = Active;
            SqlParameter p24 = new SqlParameter("@promote", SqlDbType.NVarChar);
            p24.Value = Promoted;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Account_Search_Results", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, P18, p19, p20, p21, p22, p23, p24));
        }

        public static DataSet Get_Account_Search_Results_for_SMS(string StudentName, string Applicationno, string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string Userid, string Customer_Type,
        string Institutiontype, string Boardid, string Standard, string Mobile, string Country, string State, string City, string Location, string Productcategory, string Fromdate,
        string Todate, string OrderStatus, string Sbentrycode, string Active, string Promoted)
        {
            SqlParameter p = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            p.Value = StudentName;
            SqlParameter p1 = new SqlParameter("@Applicationno", SqlDbType.NVarChar);
            p1.Value = Applicationno;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@academicyear", SqlDbType.NVarChar);
            p6.Value = Academicyear;
            SqlParameter p7 = new SqlParameter("@Stream", SqlDbType.NVarChar);
            p7.Value = Stream;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;

            SqlParameter p9 = new SqlParameter("@customer_type", SqlDbType.NVarChar);
            p9.Value = Customer_Type;
            SqlParameter p10 = new SqlParameter("@institution_type", SqlDbType.NVarChar);
            p10.Value = Institutiontype;
            SqlParameter p11 = new SqlParameter("@board_id", SqlDbType.NVarChar);
            p11.Value = Boardid;
            SqlParameter p12 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p12.Value = Standard;
            SqlParameter p13 = new SqlParameter("@MOBILE", SqlDbType.NVarChar);
            p13.Value = Mobile;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@location", SqlDbType.NVarChar);
            p17.Value = Location;

            SqlParameter P18 = new SqlParameter("@productcategory", SqlDbType.NVarChar);
            P18.Value = Productcategory;
            SqlParameter p19 = new SqlParameter("@fromdt", SqlDbType.NVarChar);
            p19.Value = Fromdate;
            SqlParameter p20 = new SqlParameter("@todt", SqlDbType.NVarChar);
            p20.Value = Todate;
            SqlParameter p21 = new SqlParameter("@orderstatus", SqlDbType.NVarChar);
            p21.Value = OrderStatus;
            SqlParameter p22 = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p22.Value = Sbentrycode;
            SqlParameter p23 = new SqlParameter("@flag", SqlDbType.NVarChar);
            p23.Value = Active;
            SqlParameter p24 = new SqlParameter("@promote", SqlDbType.NVarChar);
            p24.Value = Promoted;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Account_Search_Results_For_SMS", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, P18, p19, p20, p21, p22, p23, p24));
        }

        public static DataSet Get_All_Receipt_Print(string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string StudentName, string Applicationno, string Userid, string Feehead,
        string Fromdate, string Todate, int Flag)
        {
            SqlParameter p = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            p.Value = StudentName;
            SqlParameter p1 = new SqlParameter("@Applicationno", SqlDbType.NVarChar);
            p1.Value = Applicationno;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@academicyear", SqlDbType.NVarChar);
            p6.Value = Academicyear;
            SqlParameter p7 = new SqlParameter("@Stream", SqlDbType.NVarChar);
            p7.Value = Stream;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;
            SqlParameter p9 = new SqlParameter("@Feehead", SqlDbType.NVarChar);
            p9.Value = Feehead;
            SqlParameter p10 = new SqlParameter("@fromdt", SqlDbType.NVarChar);
            p10.Value = Fromdate;
            SqlParameter p11 = new SqlParameter("@todt", SqlDbType.NVarChar);
            p11.Value = Todate;
            SqlParameter p12 = new SqlParameter("@flag", SqlDbType.Int);
            p12.Value = Flag;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bindstudent_payeeinfo", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12));
        }

        public static DataSet Get_All_Students_Promote(string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string StudentName, string Applicationno, string Userid, string Sbentrycode,
        string Request_type_code, string center_remarks, string Condition_type, int Flag, string Pcode)
        {
            SqlParameter p = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            p.Value = StudentName;
            SqlParameter p1 = new SqlParameter("@Applicationno", SqlDbType.NVarChar);
            p1.Value = Applicationno;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@year", SqlDbType.NVarChar);
            p6.Value = Academicyear;
            SqlParameter p7 = new SqlParameter("@Stream", SqlDbType.NVarChar);
            p7.Value = Stream;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;
            SqlParameter p9 = new SqlParameter("@SBEntrycode", SqlDbType.NVarChar);
            p9.Value = Sbentrycode;
            SqlParameter p10 = new SqlParameter("@Request_Type_Code", SqlDbType.NVarChar);
            p10.Value = Request_type_code;
            SqlParameter p11 = new SqlParameter("@Centre_Remarks", SqlDbType.NVarChar);
            p11.Value = center_remarks;
            SqlParameter p12 = new SqlParameter("@Condition_Type", SqlDbType.NVarChar);
            p12.Value = Condition_type;
            SqlParameter p13 = new SqlParameter("@flag", SqlDbType.Int);
            p13.Value = Flag;
            SqlParameter p14 = new SqlParameter("@Pcode", SqlDbType.VarChar);
            p14.Value = Pcode;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_promote_request", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14));
        }

        public static void PromoteBulkRequest(string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string StudentName, string Applicationno, string Userid, string Sbentrycode,
        string Request_type_code, string center_remarks, string Condition_type, int Flag, string Pcode)
        {
            SqlParameter p1 = new SqlParameter("@StudentName", StudentName);
            SqlParameter p2 = new SqlParameter("@Applicationno", Applicationno);
            SqlParameter p3 = new SqlParameter("@Company", Company);
            SqlParameter p4 = new SqlParameter("@Division", Division);
            SqlParameter p5 = new SqlParameter("@Zone", Zone);
            SqlParameter p6 = new SqlParameter("@Center", Center);
            SqlParameter p7 = new SqlParameter("@year", Academicyear);
            SqlParameter p8 = new SqlParameter("@Stream", Stream);
            SqlParameter p9 = new SqlParameter("@userid", Userid);
            SqlParameter p10 = new SqlParameter("@SBEntrycode", Sbentrycode);
            SqlParameter p11 = new SqlParameter("@Request_Type_Code", Request_type_code);
            SqlParameter p12 = new SqlParameter("@Centre_Remarks", center_remarks);
            SqlParameter p13 = new SqlParameter("@Condition_Type", Condition_type);
            SqlParameter p14 = new SqlParameter("@flag", Flag);
            SqlParameter p15 = new SqlParameter("@pcode", Pcode);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_promote_request", p1, p2, p3, p4, p5, p6, p7,
            p8, p9, p10, p11, p12, p13, p14, p15);
        }



        public static string Approvepromote(string request_id, string sbentrycode, string req_code, string center, string status, string remarks, string userid)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@request_id", SqlDbType.NVarChar);
            p[0].Value = request_id;
            p[1] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[1].Value = sbentrycode;
            p[2] = new SqlParameter("@req_code", SqlDbType.NVarChar);
            p[2].Value = req_code;
            p[3] = new SqlParameter("@center", SqlDbType.NVarChar);
            p[3].Value = center;
            p[4] = new SqlParameter("@status", SqlDbType.NVarChar);
            p[4].Value = status;
            p[5] = new SqlParameter("@remarks", SqlDbType.NVarChar);
            p[5].Value = remarks;
            p[6] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[6].Value = userid;
            p[7] = new SqlParameter("@MESSAGE", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_updatepromoterequest", p);
            return (p[7].Value.ToString());
        }


        //Public Shared Function Get_Contact_Search_Results(ByVal Contacttypeid As String, ByVal Studenttypeid As String, ByVal Boardid As String, _
        //                                                  ByVal year_pass_id As String, _
        //                                                  ByVal current_year_id As String, ByVal institute_type_id As String, _
        //                                                  ByVal Current_Standard_id As String, _
        //                                                  ByVal Studentname As String) As DataSet
        //    Dim p As New SqlParameter("@Contacttypeid", SqlDbType.NVarChar)
        //    p.Value = Contacttypeid
        //    Dim p1 As New SqlParameter("@studenttypeid", SqlDbType.NVarChar)
        //    p1.Value = Studenttypeid
        //    Dim p2 As New SqlParameter("@Boardid", SqlDbType.NVarChar)
        //    p2.Value = Boardid
        //    Dim p3 As New SqlParameter("@year_pass_id", SqlDbType.NVarChar)
        //    p3.Value = year_pass_id
        //    Dim p4 As New SqlParameter("@current_year_id", SqlDbType.NVarChar)
        //    p4.Value = current_year_id
        //    Dim p5 As New SqlParameter("@institute_type_id", SqlDbType.NVarChar)
        //    p5.Value = institute_type_id
        //    Dim p6 As New SqlParameter("@Current_Standard_id", SqlDbType.NVarChar)
        //    p6.Value = Current_Standard_id
        //    Dim p7 As New SqlParameter("@Studentname", SqlDbType.NVarChar)
        //    p7.Value = Studentname
        //    Return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Contact_Search_Results", p, p1, p2, p3, p4, p5, p6, p7))
        //End Function


        public static DataSet Get_Contact_Search(int flag, int stage, string Company, string Division, string Zone, string Center, string customer_type, string institution_type, string board_id, string standard,
        string name, string mobile, string country, string state, string city, string location, string acadyear, string productcategory, string stream, string application_form_no,
        string agefrom, string ageto, string boardid, string standard_id, string year, string xam_details, string scoretype, string condition, string score, string userid)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = flag;
            SqlParameter p1 = new SqlParameter("@stage", SqlDbType.Int);
            p1.Value = stage;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@customer_type", SqlDbType.NVarChar);
            p6.Value = customer_type;
            SqlParameter p7 = new SqlParameter("@institution_type", SqlDbType.NVarChar);
            p7.Value = institution_type;

            SqlParameter p8 = new SqlParameter("@board_id", SqlDbType.NVarChar);
            p8.Value = board_id;
            SqlParameter p9 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p9.Value = standard;
            SqlParameter p10 = new SqlParameter("@name", SqlDbType.NVarChar);
            p10.Value = name;
            SqlParameter p11 = new SqlParameter("@mobile", SqlDbType.NVarChar);
            p11.Value = mobile;

            SqlParameter p12 = new SqlParameter("@country", SqlDbType.NVarChar);
            p12.Value = country;
            SqlParameter p13 = new SqlParameter("@state", SqlDbType.NVarChar);
            p13.Value = state;
            SqlParameter p14 = new SqlParameter("@city", SqlDbType.NVarChar);
            p14.Value = city;
            SqlParameter p15 = new SqlParameter("@location", SqlDbType.NVarChar);
            p15.Value = location;
            SqlParameter p16 = new SqlParameter("@acadyear", SqlDbType.NVarChar);
            p16.Value = acadyear;
            SqlParameter p17 = new SqlParameter("@productcategory", SqlDbType.NVarChar);
            p17.Value = productcategory;
            SqlParameter p18 = new SqlParameter("@stream", SqlDbType.NVarChar);
            p18.Value = stream;
            SqlParameter p19 = new SqlParameter("@application_form_no", SqlDbType.NVarChar);
            p19.Value = application_form_no;
            SqlParameter p20 = new SqlParameter("@agefrom", SqlDbType.NVarChar);
            p20.Value = agefrom;
            SqlParameter p21 = new SqlParameter("@ageto", SqlDbType.NVarChar);
            p21.Value = ageto;
            SqlParameter p22 = new SqlParameter("@boardid", SqlDbType.NVarChar);
            p22.Value = boardid;

            SqlParameter p23 = new SqlParameter("@standard_id", SqlDbType.NVarChar);
            p23.Value = standard_id;
            SqlParameter p24 = new SqlParameter("@year", SqlDbType.NVarChar);
            p24.Value = year;
            SqlParameter p25 = new SqlParameter("@xam_details", SqlDbType.NVarChar);
            p25.Value = xam_details;
            SqlParameter p26 = new SqlParameter("@scoretype", SqlDbType.NVarChar);
            p26.Value = scoretype;
            SqlParameter p27 = new SqlParameter("@condition", SqlDbType.NVarChar);
            p27.Value = condition;
            SqlParameter p28 = new SqlParameter("@score", SqlDbType.NVarChar);
            p28.Value = score;
            SqlParameter p29 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p29.Value = userid;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Search_Contacts", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, p18, p19, p20, p21, p22, p23, p24, p25, p26,
            p27, p28, p29));
        }


        public static string CreateAccount(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, int flag2)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@flag2", SqlDbType.Int);
            p[5].Value = flag2;
            p[6] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[6].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables", p);
            return (p[5].Value.ToString());
        }



        public static string PromoteStudent(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, string Stream, string Accountid)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[6].Value = Stream;
            p[7] = new SqlParameter("@Acc_id", SqlDbType.NVarChar);
            p[7].Value = Accountid;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables_Promote", p);
            return (p[5].Value.ToString());
        }

        public static string StreamChange(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, string Stream, string Accountid, string CBCode)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[6].Value = Stream;
            p[7] = new SqlParameter("@Acc_id", SqlDbType.NVarChar);
            p[7].Value = Accountid;
            p[8] = new SqlParameter("@ChangeSBCode", SqlDbType.NVarChar);
            p[8].Value = CBCode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables_StreamChange", p);
            return (p[5].Value.ToString());
        }

        public static string Addevent(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, string Stream, string Accountid, string CBCode, string orderid)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[6].Value = Stream;
            p[7] = new SqlParameter("@OrderId", SqlDbType.NVarChar);
            p[7].Value = orderid ;
            p[8] = new SqlParameter("@Acc_id", SqlDbType.NVarChar);
            p[8].Value = Accountid;
            p[9] = new SqlParameter("@ChangeSBCode", SqlDbType.NVarChar);
            p[9].Value = CBCode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables_AddSubject", p);
            return (p[5].Value.ToString());
        }

        public static string Payplan(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, string Stream, string Accountid, string CBCode, int flag2)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[6].Value = Stream;
            p[7] = new SqlParameter("@Acc_id", SqlDbType.NVarChar);
            p[7].Value = Accountid;
            p[8] = new SqlParameter("@ChangeSBCode", SqlDbType.NVarChar);
            p[8].Value = CBCode;
            p[9] = new SqlParameter("@flag2", SqlDbType.NVarChar);
            p[9].Value = flag2;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables_PayPlan", p);
            return (p[5].Value.ToString());
        }

        public static string Transfer(string Oppid, string MaterialCode, string Documenttype, string Paytype, string Userid, 
            string Stream, string Accountid, string CBCode , string center)
        {
            SqlParameter[] p = new SqlParameter[10];
            p[0] = new SqlParameter("@opp_id", SqlDbType.NVarChar);
            p[0].Value = Oppid;
            p[1] = new SqlParameter("@subjectgrp", SqlDbType.NVarChar);
            p[1].Value = MaterialCode;
            p[2] = new SqlParameter("@doc_type", SqlDbType.NVarChar);
            p[2].Value = Documenttype;
            p[3] = new SqlParameter("@paytype", SqlDbType.NVarChar);
            p[3].Value = Paytype;
            p[4] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[4].Value = Userid;
            p[5] = new SqlParameter("@Account_OUT_ID", SqlDbType.NVarChar, 100);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@stream", SqlDbType.NVarChar);
            p[6].Value = Stream;
            p[7] = new SqlParameter("@Acc_id", SqlDbType.NVarChar);
            p[7].Value = Accountid;
            p[8] = new SqlParameter("@ChangeSBCode", SqlDbType.NVarChar);
            p[8].Value = CBCode;
            p[9] = new SqlParameter("@Center", SqlDbType.NVarChar);
            p[9].Value = center;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insert_Ttables_Transfer", p);
            return (p[5].Value.ToString());
        }

        public static SqlDataReader GetAccountdetailbycursbcode(int flag, string Cur_Sb_Code)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = flag;
            p[1] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[1].Value = Cur_Sb_Code;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetStudentinfoby_SBentrycode", p));
        }

        //Public Shared Function Getorderid() As SqlDataReader
        //    Dim p As SqlParameter() = New SqlParameter(0) {}
        //    Return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getorderno", p))
        //End Function
        public static string Getorderid()
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Order", SqlDbType.NVarChar, 100);
            p[0].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_getorderno", p);
            return (p[0].Value.ToString());
        }
        public static string GetLedgerbalancebysbentrycode(string Cursbcode, int Flag)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ledger", SqlDbType.NVarChar, 100);
            p[0].Direction = ParameterDirection.Output;
            p[1] = new SqlParameter("@Sbentrycode", SqlDbType.VarChar);
            p[1].Value = Cursbcode;
            p[2] = new SqlParameter("@Flag", SqlDbType.Int);
            p[2].Value = Flag;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USp_Ledgerby_sbentrycode", p);
            return (p[0].Value.ToString());
        }
        public static string Getpromoteflag(string Cursbcode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@msg", SqlDbType.NVarChar, 100);
            p[0].Direction = ParameterDirection.Output;
            p[1] = new SqlParameter("@Sbentrycode", SqlDbType.VarChar);
            p[1].Value = Cursbcode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_CheckPromote", p);
            return (p[0].Value.ToString());
        }

        public static DataSet GetStudentSubjectgroupbyCursbcode(int flag, string CurSBCode)
        {
            SqlParameter p1 = new SqlParameter("@Flag", flag);
            SqlParameter p2 = new SqlParameter("@sbentrycode", CurSBCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetStudentinfoby_SBentrycode", p1, p2));
        }

        public static DataSet GetallPaymode()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_GetAllPaymode"));
        }
        public static DataSet Getallpayee()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bindpayeeby_company"));
        }
        public static DataSet Getallpayeebycompanydivision(string Company, string Division)
        {
            SqlParameter p1 = new SqlParameter("@company_code", Company);
            SqlParameter p2 = new SqlParameter("@Division_Code", Division);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bindpayeeby_companyDivision", p1, p2));
        }
        public static DataSet GetallpayeebyCenter(int Flag, string Center)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@center", Center);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_bindpayeeby_Center", p1, p2));
        }

        public static SqlDataReader GetBanknameandAddress(string Micrcode)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@micrno", SqlDbType.NVarChar);
            p[0].Value = Micrcode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetBankdetailsby_MICRNO", p));
        }
        public static SqlDataReader Get_Feeheadvalue(string Sbentrycode, string PPgroup)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = Sbentrycode;
            p[1] = new SqlParameter("@pricingprocedure", SqlDbType.NVarChar);
            p[1].Value = PPgroup;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetFeesHead", p));
        }

        public static string InsertPayment(int Flag, string Paydate, decimal Amtinstr, string SBEntrycode, string Paymode, string Payinsnum, string PayInsDate, string PayInsbankname, string Insstatus, string Inslocation,
        string InsDepositdate, string InsBRSdate, string Userid, string MICRCode, string Payheadcode, string PayheadDesc, string Payee_id, string Chequeidno, string CardType, string Cardno)
        {
            SqlParameter[] p = new SqlParameter[21];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@pay_Date", SqlDbType.VarChar);
            p[1].Value = Paydate;
            p[2] = new SqlParameter("@Amt_Instr", SqlDbType.Decimal);
            p[2].Value = Amtinstr;
            p[3] = new SqlParameter("@sbentryCode", SqlDbType.NVarChar);
            p[3].Value = SBEntrycode;
            p[4] = new SqlParameter("@PayMode", SqlDbType.NVarChar);
            p[4].Value = Paymode;
            p[5] = new SqlParameter("@Pay_insNum", SqlDbType.NVarChar);
            p[5].Value = Payinsnum;
            p[6] = new SqlParameter("@Pay_insDate", SqlDbType.VarChar);
            p[6].Value = PayInsDate;
            p[7] = new SqlParameter("@Pay_insBankName", SqlDbType.NVarChar);
            p[7].Value = PayInsbankname;
            p[8] = new SqlParameter("@Ins_Status", SqlDbType.NVarChar);
            p[8].Value = Insstatus;
            p[9] = new SqlParameter("@ins_location", SqlDbType.NVarChar);
            p[9].Value = Inslocation;
            p[10] = new SqlParameter("@Ins_DepositeDate", SqlDbType.VarChar);
            p[10].Value = InsDepositdate;
            p[11] = new SqlParameter("@Ins_BRSDate", SqlDbType.VarChar);
            p[11].Value = InsBRSdate;
            p[12] = new SqlParameter("@userid", SqlDbType.NVarChar);
            p[12].Value = Userid;
            p[13] = new SqlParameter("@recpt_out_id", SqlDbType.NVarChar, 100);
            p[13].Direction = ParameterDirection.Output;
            p[14] = new SqlParameter("@micrno", SqlDbType.NVarChar);
            p[14].Value = MICRCode;
            p[15] = new SqlParameter("@pricing_procedure_type", SqlDbType.NVarChar);
            p[15].Value = Payheadcode;
            p[16] = new SqlParameter("@pricing_procedure_description", SqlDbType.NVarChar);
            p[16].Value = PayheadDesc;
            p[17] = new SqlParameter("@Payee_id", SqlDbType.NVarChar);
            p[17].Value = Payee_id;
            p[18] = new SqlParameter("@chkid", SqlDbType.NVarChar);
            p[18].Value = Chequeidno;
            p[19] = new SqlParameter("@CardType", SqlDbType.NVarChar);
            p[19].Value = CardType;
            p[20] = new SqlParameter("@Cardno", SqlDbType.NVarChar);
            p[20].Value = Cardno;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_Receipt_entry", p);
            return (p[13].Value.ToString());
        }


        public static DataSet GetPaymentDetailsbySBEntrycode(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETRECEIPTBYSBENTRYCODE", p1));
        }

        public static DataSet GetPaymentDetailsbySBEntrycode2(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GETRECEIPTBYSBENTRYCODEForChequeReturn", p1));
        }

        public static DataSet GetPPgroupbysbentrycode(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_allocate_cheque_display", p1));
        }
        public static DataSet GetPPGroupbySBEntrycodeAndPayeeid(string SBEntrycode, string Payeeid)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@Payeeid", Payeeid);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Allocate_ShowCheque", p1, p2));
        }

        public static DataSet Getpayallocation(int Flag, string Receiptid, string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@rcpt_id", Receiptid);
            SqlParameter p3 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_showallocatedamount", p1, p2, p3));
        }

        public static string Getppgroupnetvalue(string SBEntrycode, string PPgroupcode, int flag)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            p[2] = new SqlParameter("@ppcode", SqlDbType.NVarChar);
            p[2].Value = PPgroupcode;
            p[3] = new SqlParameter("@flag", SqlDbType.Int);
            p[3].Value = flag;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Allocate_amountby_pricingcode", p);
            return (p[1].Value.ToString());
        }

        public static string GetChequeamount(string SBEntrycode, string Chequeidno, int flag)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            p[2] = new SqlParameter("@Chequeidno", SqlDbType.NVarChar);
            p[2].Value = Chequeidno;
            p[3] = new SqlParameter("@flag", SqlDbType.Int);
            p[3].Value = flag;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_ChequeAmountbyChequeId", p);
            return (p[1].Value.ToString());
        }

        public static string GetwaiverMaxAmt(string SBEntrycode, string PPgroupcode, int flag, string type)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.VarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@amount", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            p[2] = new SqlParameter("@ppcode", SqlDbType.VarChar);
            p[2].Value = PPgroupcode;
            p[3] = new SqlParameter("@flag", SqlDbType.Int);
            p[3].Value = flag;
            p[4] = new SqlParameter("@type", SqlDbType.VarChar );
            p[4].Value = type;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Waiveramt", p);
            return (p[1].Value.ToString());
        }

        public static DataSet GetPPgroupbyreceiptcode(string Receiptcode, string flag)
        {
            SqlParameter p1 = new SqlParameter("@receiptcode", Receiptcode);
            SqlParameter p2 = new SqlParameter("@flag", flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_EditAllocate_Cheques", p1, p2));
        }
        public static DataSet GetRequestDetails(string SBEntrycode, int Flag)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            SqlParameter p2 = new SqlParameter("@flag", Flag);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayRequestby_Sbentrycode", p1, p2));
        }

        public static DataSet Getstudentledgerbysbentrycode(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@sbentrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_populate_Ledger", p1));
        }

        public static SqlDataReader GetChequeOutstanding(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_FetchChqOutstanding", p));
        }
        public static string Confirmadmission(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@recptid", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_insert_payment_NEW", p);
            return (p[1].Value.ToString());
        }
        public static string InsertP19(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@recptid", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_insert_P19", p);
            return (p[1].Value.ToString());
        }
        public static string InsertE19(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@SBENTRYCODE", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@recptid", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_insert_E19", p);
            return (p[1].Value.ToString());
        }
        //For Discount, Concession, Waiver and Refund Approval
        public static DataSet GetallDiscounttype(string Requestcode)
        {
            SqlParameter p1 = new SqlParameter("@request_Code", Requestcode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindRequest_VoucherType", p1));
        }
        public static DataSet GetallPPgroup(int Flag, string Request_Code, string Pcode)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@request_code", Request_Code);
            SqlParameter p3 = new SqlParameter("@pcode", Pcode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Display_Procedure_Item", p1, p2, p3));
        }
        public static DataSet GetallConcessiontype(string Requestcode)
        {
            SqlParameter p1 = new SqlParameter("@request_Code", Requestcode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_BindRequest_VoucherType", p1));
        }

        public static DataSet GetPayheadbySBentrycode(string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Populate_Voucher", p1));
        }

        public static string Insertrequest(int Flag, string Requesttypecode, string SBEntrycode, string Conditiontype, string CenterRemarks, decimal Amount, int Levelno, string Userid)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Request_Type_Code", SqlDbType.VarChar);
            p[1].Value = Requesttypecode;
            p[2] = new SqlParameter("@SbEntrycode", SqlDbType.VarChar);
            p[2].Value = SBEntrycode;
            p[3] = new SqlParameter("@Condition_Type", SqlDbType.VarChar);
            p[3].Value = Conditiontype;
            p[4] = new SqlParameter("@Centre_Remarks", SqlDbType.VarChar, 300);
            p[4].Value = CenterRemarks;
            p[5] = new SqlParameter("@Center_Requested_Amount", SqlDbType.Decimal);
            p[5].Value = Amount;
            p[6] = new SqlParameter("@Level_No", SqlDbType.Int);
            p[6].Value = Levelno;
            p[7] = new SqlParameter("@userid", SqlDbType.VarChar);
            p[7].Value = Userid;
            p[8] = new SqlParameter("@Req_Alert", SqlDbType.NVarChar, 100);
            p[8].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_request", p);
            return (p[8].Value.ToString());
        }

        public static string InsertChequeReturnRequest(int Flag, string Center_Code, string SBEntrycode,
            string DispatchSlipNo, string DispatchSlipEntrycode, string ChequeIdNo,string CenterChequeNo,
            decimal CenterChequeAmt, string CCChequeNo, decimal CCChequeAmount, string Changeflag, string ChangeReason, string Created_By)
        {
            SqlParameter[] p = new SqlParameter[14];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p[1].Value = Center_Code ;
            p[2] = new SqlParameter("@SBEntrycode", SqlDbType.VarChar);
            p[2].Value = SBEntrycode;
            p[3] = new SqlParameter("@DispatchSlipNo", SqlDbType.VarChar);
            p[3].Value = DispatchSlipNo ;
            p[4] = new SqlParameter("@DispatchSlipEntrycode", SqlDbType.VarChar, 300);
            p[4].Value = DispatchSlipEntrycode ;
            p[5] = new SqlParameter("@ChequeIdNo", SqlDbType.VarChar);
            p[5].Value = ChequeIdNo ;
            p[6] = new SqlParameter("@CenterChequeNo", SqlDbType.VarChar);
            p[6].Value = CenterChequeNo;
            p[7] = new SqlParameter("@CenterChequeAmt", SqlDbType.Decimal );
            p[7].Value = CenterChequeAmt;
            p[8] = new SqlParameter("@CCChequeNo", SqlDbType.VarChar);
            p[8].Value = CCChequeNo;
            p[9] = new SqlParameter("@CCChequeAmount", SqlDbType.Decimal );
            p[9].Value = CCChequeAmount;
            p[10] = new SqlParameter("@Changeflag", SqlDbType.VarChar);
            p[10].Value = Changeflag;
            p[11] = new SqlParameter("@ChangeReason", SqlDbType.VarChar);
            p[11].Value = ChangeReason;
            p[12] = new SqlParameter("@Created_By", SqlDbType.VarChar);
            p[12].Value = Created_By;
            p[13] = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
            p[13].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_ChangeChequeDetails", p);
            return (p[13].Value.ToString());
        }

        public static DataSet GetAllrequest(string Requesttype, string Requestdate, string RequestStatus, string Company, string Division, string Center, string Academicyear, string Stream, string Sbentrycode, string Userid,
        string Sname, string Appno)
        {
            SqlParameter p = new SqlParameter("@req_type", SqlDbType.NVarChar);
            p.Value = Requesttype;
            SqlParameter p1 = new SqlParameter("@req_date", SqlDbType.VarChar);
            p1.Value = Requestdate;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@center", SqlDbType.NVarChar);
            p4.Value = Center;
            SqlParameter p5 = new SqlParameter("@acad_year", SqlDbType.NVarChar);
            p5.Value = Academicyear;
            SqlParameter p6 = new SqlParameter("@stream", SqlDbType.NVarChar);
            p6.Value = Stream;
            SqlParameter p7 = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p7.Value = Sbentrycode;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;
            SqlParameter p9 = new SqlParameter("@req_status", SqlDbType.NVarChar);
            p9.Value = RequestStatus;
            SqlParameter p10 = new SqlParameter("@appno", SqlDbType.NVarChar);
            p10.Value = Appno;
            SqlParameter p11 = new SqlParameter("@sname", SqlDbType.NVarChar);
            p11.Value = Sname;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Findrequest", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11));
        }

        public static DataSet GetAllrequestformanagerequestpage(string Requesttype, string Requestdate, string RequestStatus, string Company, string Division, string Center, string Academicyear, string Stream, string Name, string Userid,
        string Sbentrycode, string Appno)
        {
            SqlParameter p = new SqlParameter("@req_type", SqlDbType.NVarChar);
            p.Value = Requesttype;
            SqlParameter p1 = new SqlParameter("@req_date", SqlDbType.VarChar);
            p1.Value = Requestdate;
            SqlParameter p2 = new SqlParameter("@company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@center", SqlDbType.NVarChar);
            p4.Value = Center;
            SqlParameter p5 = new SqlParameter("@acad_year", SqlDbType.NVarChar);
            p5.Value = Academicyear;
            SqlParameter p6 = new SqlParameter("@stream", SqlDbType.NVarChar);
            p6.Value = Stream;
            SqlParameter p7 = new SqlParameter("@name", SqlDbType.NVarChar);
            p7.Value = Name;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;
            SqlParameter p9 = new SqlParameter("@req_status", SqlDbType.NVarChar);
            p9.Value = RequestStatus;
            SqlParameter p10 = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p10.Value = Sbentrycode;
            SqlParameter p11 = new SqlParameter("@appno", SqlDbType.NVarChar);
            p11.Value = Appno;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_ManageRequest", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11));
        }
        public static DataSet GetallRequesttype()
        {
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAllRequesttype"));
        }

        public static SqlDataReader GetAllrequestasreader(string Sbentrycode, string Userid, string Requestid)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = Sbentrycode;
            p[1] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[1].Value = Userid;
            p[2] = new SqlParameter("@Request_id", SqlDbType.NVarChar);
            p[2].Value = Requestid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_Requestdetails", p));
        }
        public static SqlDataReader GetAllrequestasreaderforuser(string Sbentrycode, string Userid, string Requestid)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p[0].Value = Sbentrycode;
            p[1] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[1].Value = Userid;
            p[2] = new SqlParameter("@request_id", SqlDbType.NVarChar);
            p[2].Value = Requestid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_RequestApprovaldetails", p));
        }
        public static SqlDataReader GetAlluserbylevel(string Requestid)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@request_id", SqlDbType.NVarChar);
            p[0].Value = Requestid;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Approvername", p));
        }
        public static string UpdateRequest(string SBEntrycode, string Requesttypecode, string Center, int Status, string Appremarks, decimal Amount, string Userid, string Requestid)
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@req_code", SqlDbType.VarChar);
            p[1].Value = Requesttypecode;
            p[2] = new SqlParameter("@center", SqlDbType.VarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@status", SqlDbType.Int);
            p[3].Value = Status;
            p[4] = new SqlParameter("@remarks", SqlDbType.VarChar, 300);
            p[4].Value = Appremarks;
            p[5] = new SqlParameter("@amount", SqlDbType.Decimal);
            p[5].Value = Amount;
            p[6] = new SqlParameter("@userid", SqlDbType.VarChar);
            p[6].Value = Userid;
            p[7] = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
            p[7].Direction = ParameterDirection.Output;
            p[8] = new SqlParameter("@Request_id", SqlDbType.VarChar);
            p[8].Value = Requestid;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_UPDATEREQUEST", p);
            return (p[7].Value.ToString());
        }

        //public static string UpdateRequest_Level3(string SBEntrycode, string Requesttypecode, string Center, int Status, string Appremarks, decimal Amount, string Userid, string Requestid)
        //{
        //    SqlParameter[] p = new SqlParameter[9];
        //    p[0] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
        //    p[0].Value = SBEntrycode;
        //    p[1] = new SqlParameter("@req_code", SqlDbType.VarChar);
        //    p[1].Value = Requesttypecode;
        //    p[2] = new SqlParameter("@center", SqlDbType.VarChar);
        //    p[2].Value = Center;
        //    p[3] = new SqlParameter("@status", SqlDbType.Int);
        //    p[3].Value = Status;
        //    p[4] = new SqlParameter("@remarks", SqlDbType.VarChar, 300);
        //    p[4].Value = Appremarks;
        //    p[5] = new SqlParameter("@amount", SqlDbType.Decimal);
        //    p[5].Value = Amount;
        //    p[6] = new SqlParameter("@userid", SqlDbType.VarChar);
        //    p[6].Value = Userid;
        //    p[7] = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
        //    p[7].Direction = ParameterDirection.Output;
        //    p[8] = new SqlParameter("@Request_id", SqlDbType.VarChar);
        //    p[8].Value = Requestid;
        //    SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_updaterequest_Level3", p);
        //    return (p[7].Value.ToString());
        //}

        public static string GetUserlevel(string SBEntrycode, string Userid, string CenterCode)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Sbentrycode", SqlDbType.NVarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[1].Value = Userid;
            p[2] = new SqlParameter("@Center", SqlDbType.NVarChar);
            p[2].Value = CenterCode;
            p[3] = new SqlParameter("@Level", SqlDbType.VarChar, 5);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USp_GetUserlevel", p);
            return (p[3].Value.ToString());
        }

        public static DataSet Get_All_Pending_Receipts(int Flag, string Center, string Userid, string Slip, string Payeeid, string Paymode)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@userid", Userid);
            SqlParameter p3 = new SqlParameter("@center", Center);
            SqlParameter p4 = new SqlParameter("@slip", Slip);
            SqlParameter p5 = new SqlParameter("@Payeeid", Payeeid);
            SqlParameter p6 = new SqlParameter("@paymode", Paymode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayCMS", p1, p2, p3, p4, p5, p6));
        }

        

        public static string GetSlipno(int Flag, string Center, string Userid, string Slip, string Payeeid, string Paymode)
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Userid", SqlDbType.NVarChar);
            p[1].Value = Userid;
            p[2] = new SqlParameter("@Center", SqlDbType.NVarChar);
            p[2].Value = Center;
            p[3] = new SqlParameter("@slip", SqlDbType.VarChar, 30);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@payeeid", SqlDbType.NVarChar);
            p[4].Value = Payeeid;
            p[5] = new SqlParameter("@Paymode", SqlDbType.NVarChar);
            p[5].Value = Paymode;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayCMS", p);
            return (p[3].Value.ToString());
        }

        public static string InsertDepositSlip(string Slipno, string Chkcount, decimal TotalChkamt, string Chkdate, decimal Chkamt, string Acadyear, string chkno, string Chkid, string SBentrycode, string Center,
        string Division, string Userid, int flag, string payeeid)
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@slipno", SqlDbType.VarChar);
            p[0].Value = Slipno;
            p[1] = new SqlParameter("@chkcnt", SqlDbType.VarChar);
            p[1].Value = Chkcount;
            p[2] = new SqlParameter("@totchkamt", SqlDbType.Decimal);
            p[2].Value = TotalChkamt;
            p[3] = new SqlParameter("@chkdate", SqlDbType.VarChar);
            p[3].Value = Chkdate;
            p[4] = new SqlParameter("@chkamt", SqlDbType.Decimal);
            p[4].Value = Chkamt;
            p[5] = new SqlParameter("@acadyear", SqlDbType.VarChar);
            p[5].Value = Acadyear;
            p[6] = new SqlParameter("@chkno", SqlDbType.VarChar);
            p[6].Value = chkno;
            p[7] = new SqlParameter("@chkid", SqlDbType.VarChar);
            p[7].Value = Chkid;
            p[8] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p[8].Value = SBentrycode;
            p[9] = new SqlParameter("@center", SqlDbType.VarChar);
            p[9].Value = Center;
            p[10] = new SqlParameter("@division", SqlDbType.VarChar);
            p[10].Value = Division;
            p[11] = new SqlParameter("@userid", SqlDbType.VarChar);
            p[11].Value = Userid;
            p[12] = new SqlParameter("@slipid", SqlDbType.NVarChar, 100);
            p[12].Direction = ParameterDirection.Output;
            p[13] = new SqlParameter("@Flag", SqlDbType.Int);
            p[13].Value = flag;
            p[14] = new SqlParameter("@payeeid", SqlDbType.VarChar);
            p[14].Value = payeeid;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Insertdepositslip_details", p);
            return (p[12].Value.ToString());
        }

        

        public static DataSet Get_CMS_Search_results(string Company, string Division, string Zone, string Center, string Fromdate, string Todate, string Userid, string Payeeid, string Slipno)
        {
            SqlParameter p1 = new SqlParameter("@company", Company);
            SqlParameter p2 = new SqlParameter("@division", Division);
            SqlParameter p3 = new SqlParameter("@zone", Zone);
            SqlParameter p4 = new SqlParameter("@center", Center);
            SqlParameter p5 = new SqlParameter("@fdate", Fromdate);
            SqlParameter p6 = new SqlParameter("@tdate", Todate);
            SqlParameter p7 = new SqlParameter("@userid", Userid);
            SqlParameter p8 = new SqlParameter("@payee_id", Payeeid);
            SqlParameter p9 = new SqlParameter("@slipno", Slipno);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_SearchSlip", p1, p2, p3, p4, p5, p6, p7,
            p8, p9));
        }

        public static string GetOppidbysbentrycode(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@SBEntrycode", SqlDbType.VarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@code", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Getopportunityidby_sbentrycode", p);
            return (p[1].Value.ToString());
        }
        public static string GetAccountidbysbentrycode(string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@SBEntrycode", SqlDbType.VarChar);
            p[0].Value = SBEntrycode;
            p[1] = new SqlParameter("@code", SqlDbType.NVarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_GetAccountidby_sbentrycode", p);
            return (p[1].Value.ToString());
        }
        public static void Updateseries(string SBentrycode, string Regno, string Admnno, string Finalexamno, string admndate, string Transfer_certno)
        {
            SqlParameter p1 = new SqlParameter("@SBEntrycode", SBentrycode);
            SqlParameter p2 = new SqlParameter("@PU_Reg_No", Regno);
            SqlParameter p3 = new SqlParameter("@Adm_No", Admnno);
            SqlParameter p4 = new SqlParameter("@Student_Final_Exam_No", Finalexamno);
            SqlParameter p5 = new SqlParameter("@PU_admdate", admndate);
            SqlParameter p6 = new SqlParameter("@Transfer_certno", Transfer_certno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Update_Series", p1, p2, p3, p4, p5, p6);
        }

        public static SqlDataReader GetCMSDetailsbySlipno(int Flag, string Slipno)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Slipno", SqlDbType.NVarChar);
            p[1].Value = Slipno;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USp_Slipdetails", p));
        }

        public static DataSet Get_CMS_Search_results_Details(int Flag, string Slipno)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Slipno", Slipno);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USp_Slipdetails", p1, p2));
        }


        public static DataSet Getvaluesforreceipt1(int Flag, string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Sbentrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Print_Receipt", p1, p2));
        }

        public static SqlDataReader Getgrandtotals(int Flag, string SBEntrycode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@Sbentrycode", SqlDbType.NVarChar);
            p[1].Value = SBEntrycode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Print_Receipt", p));
        }


        //Add Product
        public static DataSet GetProducttobeaddedbySbentrycode(int Flag, string SBEntrycode)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@Sbentrycode", SBEntrycode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Display_Product", p1, p2));
        }

        //Bank Reconciliation

        public static DataSet Get_All_Open_Items(int Flag, string Company, string Division, string Center, string Payee, string Postingstatus, string Slipdatefrom, string Slipdateto, string Chequeno, string UserID,
        string Updtstatus, string bank_post_date, string bounceremarks, string bouncecharges, string Slipno)
        {
            SqlParameter p = new SqlParameter("@flag", SqlDbType.Int);
            p.Value = Flag;
            SqlParameter p1 = new SqlParameter("@company", SqlDbType.NVarChar);
            p1.Value = Company;
            SqlParameter p2 = new SqlParameter("@division", SqlDbType.NVarChar);
            p2.Value = Division;
            SqlParameter p3 = new SqlParameter("@center", SqlDbType.NVarChar);
            p3.Value = Center;
            SqlParameter p4 = new SqlParameter("@payee", SqlDbType.NVarChar);
            p4.Value = Payee;
            SqlParameter p5 = new SqlParameter("@status", SqlDbType.NVarChar);
            p5.Value = Postingstatus;
            SqlParameter p6 = new SqlParameter("@slipdatefrom", SqlDbType.NVarChar);
            p6.Value = Slipdatefrom;
            SqlParameter p7 = new SqlParameter("@slipdateto", SqlDbType.NVarChar);
            p7.Value = Slipdateto;
            SqlParameter p8 = new SqlParameter("@slipno", SqlDbType.NVarChar);
            p8.Value = Slipno;
            SqlParameter p9 = new SqlParameter("@chqno", SqlDbType.NVarChar);
            p9.Value = Chequeno;
            SqlParameter p10 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p10.Value = UserID;
            SqlParameter p11 = new SqlParameter("@updtstatus", SqlDbType.NVarChar);
            p11.Value = Updtstatus;
            SqlParameter p12 = new SqlParameter("@bank_post_date", SqlDbType.NVarChar);
            p12.Value = bank_post_date;
            SqlParameter p13 = new SqlParameter("@bounceremarks", SqlDbType.NVarChar);
            p13.Value = bounceremarks;
            SqlParameter p14 = new SqlParameter("@bouncecharges", SqlDbType.NVarChar);
            p14.Value = bouncecharges;
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_DisplayBank_Reco", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14));
        }


        //Cheque Management
        public static void Updatechequestatus(int Flag, string Userid, string Bankpostdate, string Bounceremarks, string Bouncecharges, string Sbentrycode, string Chequeid, string Slipno, string Chqno)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@userid", Userid);
            SqlParameter p3 = new SqlParameter("@bank_post_date", Bankpostdate);
            SqlParameter p4 = new SqlParameter("@bounceremarks", Bounceremarks);
            SqlParameter p5 = new SqlParameter("@bouncecharges", Bouncecharges);
            SqlParameter p6 = new SqlParameter("@sbentrycode", Sbentrycode);
            SqlParameter p7 = new SqlParameter("@chequeid", Chequeid);
            SqlParameter p8 = new SqlParameter("@slipno", Slipno);
            SqlParameter p9 = new SqlParameter("@chqno", Chqno);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Update_Chq", p1, p2, p3, p4, p5, p6, p7,
            p8, p9);
        }

        //Fee Adjustment
        public static DataSet GetallHeaderitem(int Flag, string CenterCode, string Acadyear, string StreamCode)
        {
            SqlParameter p1 = new SqlParameter("@FLAG", Flag);
            SqlParameter p2 = new SqlParameter("@center", CenterCode);
            SqlParameter p3 = new SqlParameter("@year", Acadyear);
            SqlParameter p4 = new SqlParameter("@stream", StreamCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USp_getheaderitem", p1, p2, p3, p4));
        }

        public static void UpdateMaterialvalue(int flag, string Year, string center, string stream, string material, string voucher_type, string amount)
        {
            SqlParameter p1 = new SqlParameter("@flag", flag);
            SqlParameter p2 = new SqlParameter("@Year", Year);
            SqlParameter p3 = new SqlParameter("@center", center);
            SqlParameter p4 = new SqlParameter("@stream", stream);
            SqlParameter p5 = new SqlParameter("@material", material);
            SqlParameter p6 = new SqlParameter("@voucher_type", voucher_type);
            SqlParameter p7 = new SqlParameter("@amount", amount);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "usp_update_feeadjustment", p1, p2, p3, p4, p5, p6, p7);
        }

        public static string InsertDispatchslip_details(int Flag, string DispatchSlipCode, string Center_Code, string Division_Code, string DispatchDate, int ChequeCnt,
            decimal ChequeValue, int PrintFlag, string Payeeid, string UserId, string ChequeIDNo)
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@DispatchSlipCode", SqlDbType.VarChar);
            p[1].Value = DispatchSlipCode;
            p[2] = new SqlParameter("@Center_Code", SqlDbType.VarChar);
            p[2].Value = Center_Code;
            p[3] = new SqlParameter("@Division_Code", SqlDbType.VarChar);
            p[3].Value = Division_Code;

            p[4] = new SqlParameter("@DispatchDate", SqlDbType.VarChar);
            p[4].Value = DispatchDate;
            p[5] = new SqlParameter("@ChequeCnt", SqlDbType.Int);
            p[5].Value = ChequeCnt;
            p[6] = new SqlParameter("@ChequeValue", SqlDbType.Decimal);
            p[6].Value = ChequeValue;
            p[7] = new SqlParameter("@PrintFlag", SqlDbType.Int);
            p[7].Value = PrintFlag;
            p[8] = new SqlParameter("@Payeeid", SqlDbType.VarChar);
            p[8].Value = Payeeid;
            p[9] = new SqlParameter("@CreatedBy", SqlDbType.VarChar);
            p[9].Value = UserId;
            p[10] = new SqlParameter("@ChequeIDNo", SqlDbType.VarChar);
            p[10].Value = ChequeIDNo;
            p[11] = new SqlParameter("@slipid", SqlDbType.NVarChar, 100);
            p[11].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_InsertDispatchslip_details", p);
            return (p[11].Value.ToString());
        }

        public static DataSet GetCheques_ForDispatch(int Flag, string Center, string Userid, string Slip, string Payeeid, string Paymode)
        {
            SqlParameter p1 = new SqlParameter("@flag", Flag);
            SqlParameter p2 = new SqlParameter("@userid", Userid);
            SqlParameter p3 = new SqlParameter("@center", Center);
            SqlParameter p4 = new SqlParameter("@slip", Slip);
            SqlParameter p5 = new SqlParameter("@Payeeid", Payeeid);
            SqlParameter p6 = new SqlParameter("@paymode", Paymode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCheques_ForDispatch", p1, p2, p3, p4, p5, p6));
        }

        public static DataSet GetDispatchSlip(string Company, string Division, string Zone, string Center, string Fromdate, string Todate, string Userid, string Payeeid, string Slipno)
        {
            SqlParameter p1 = new SqlParameter("@company", Company);
            SqlParameter p2 = new SqlParameter("@division", Division);
            SqlParameter p3 = new SqlParameter("@zone", Zone);
            SqlParameter p4 = new SqlParameter("@center", Center);
            SqlParameter p5 = new SqlParameter("@fdate", Fromdate);
            SqlParameter p6 = new SqlParameter("@tdate", Todate);
            SqlParameter p7 = new SqlParameter("@userid", Userid);
            SqlParameter p8 = new SqlParameter("@payee_id", Payeeid);
            SqlParameter p9 = new SqlParameter("@slipno", Slipno);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetDispatchSlip", p1, p2, p3, p4, p5, p6, p7,
            p8, p9));
        }

        public static void Resetpassword(string UserCode, string Resetpassword)
        {
            SqlParameter p1 = new SqlParameter("@UserCode", UserCode);
            SqlParameter p2 = new SqlParameter("@Password", Resetpassword);
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Reset_password", p1, p2);
        }

        //public static DataSet GetCheques_ForDispatch(int Flag, string Center, string Userid, string Slip, string Payeeid, string Paymode)
        //{
        //    SqlParameter p1 = new SqlParameter("@flag", Flag);
        //    SqlParameter p2 = new SqlParameter("@userid", Userid);
        //    SqlParameter p3 = new SqlParameter("@center", Center);
        //    SqlParameter p4 = new SqlParameter("@slip", Slip);
        //    SqlParameter p5 = new SqlParameter("@Payeeid", Payeeid);
        //    SqlParameter p6 = new SqlParameter("@paymode", Paymode);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetCheques_ForDispatch", p1, p2, p3, p4, p5, p6));
        //}

        //public static DataSet GetDispatchSlip(string Company, string Division, string Zone, string Center, string Fromdate, string Todate, string Userid, string Payeeid, string Slipno)
        //{
        //    SqlParameter p1 = new SqlParameter("@company", Company);
        //    SqlParameter p2 = new SqlParameter("@division", Division);
        //    SqlParameter p3 = new SqlParameter("@zone", Zone);
        //    SqlParameter p4 = new SqlParameter("@center", Center);
        //    SqlParameter p5 = new SqlParameter("@fdate", Fromdate);
        //    SqlParameter p6 = new SqlParameter("@tdate", Todate);
        //    SqlParameter p7 = new SqlParameter("@userid", Userid);
        //    SqlParameter p8 = new SqlParameter("@payee_id", Payeeid);
        //    SqlParameter p9 = new SqlParameter("@slipno", Slipno);
        //    return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_GetDispatchSlip", p1, p2, p3, p4, p5, p6, p7,
        //    p8, p9));
        //}

        public static SqlDataReader GetDispatchDetailsbySlipno(int Flag, string DispatchSlipCode)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Flag", SqlDbType.Int);
            p[0].Value = Flag;
            p[1] = new SqlParameter("@DispatchSlipCode", SqlDbType.NVarChar);
            p[1].Value = DispatchSlipCode;
            return (SqlHelper.ExecuteReader(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_DispatchSlipDetails", p));
        }

        public static DataSet GetDispatchDetailsbySlipno_Details(int Flag, string DispatchSlipCode)
        {
            SqlParameter p1 = new SqlParameter("@Flag", Flag);
            SqlParameter p2 = new SqlParameter("@DispatchSlipCode", DispatchSlipCode);
            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_DispatchSlipDetails", p1, p2));
        }

        public static string Verify_ChequeEntry(string SbEntrycode, decimal Instr_Amt, string Pay_InstrDate, int Flag)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@Instr_Amt", SqlDbType.Decimal);
            p[1].Value = Instr_Amt;
            p[2] = new SqlParameter("@Pay_InstrDate", SqlDbType.VarChar);
            p[2].Value = Pay_InstrDate;
            p[3] = new SqlParameter("@Flag", SqlDbType.Int);
            p[3].Value = Flag;
            p[4] = new SqlParameter("@Verify_Output", SqlDbType.VarChar, 100);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Verify_ChequeEntry", p);
            return (p[4].Value.ToString());
        }

        public static string Verify_Rule_Event_Activation(string SbEntrycode, decimal Instr_Amt, string Pay_InstrDate, int Flag)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@Instr_Amt", SqlDbType.Decimal);
            p[1].Value = Instr_Amt;
            p[2] = new SqlParameter("@Pay_InstrDate", SqlDbType.VarChar);
            p[2].Value = Pay_InstrDate;
            p[3] = new SqlParameter("@Flag", SqlDbType.Int);
            p[3].Value = Flag;
            p[4] = new SqlParameter("@Verify_Output", SqlDbType.VarChar, 100);
            p[4].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Verify_Rule_Event_Activation", p);
            return (p[4].Value.ToString());
        }

        public static string Verify_Event_Allow(string SbEntrycode,int Flag )
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@sbentrycode", SqlDbType.VarChar);
            p[0].Value = SbEntrycode;
            p[1] = new SqlParameter("@Flag", SqlDbType.Int);
            p[1].Value = Flag;
            p[2] = new SqlParameter("@Verify_Output", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Verify_EventAllowed", p);
            return (p[2].Value.ToString());
        }

        public static DataSet Get_Account_Search_Results_for_SMS1(string StudentName, string Applicationno, string Company, string Division, string Zone, string Center, string Academicyear, string Stream, string Userid, string Customer_Type,
        string Institutiontype, string Boardid, string Standard, string Mobile, string Country, string State, string City, string Location, string Productcategory, string Fromdate,
        string Todate, string OrderStatus, string Sbentrycode, string Active, string Promoted)
        {
            SqlParameter p = new SqlParameter("@StudentName", SqlDbType.NVarChar);
            p.Value = StudentName;
            SqlParameter p1 = new SqlParameter("@Applicationno", SqlDbType.NVarChar);
            p1.Value = Applicationno;
            SqlParameter p2 = new SqlParameter("@Company", SqlDbType.NVarChar);
            p2.Value = Company;
            SqlParameter p3 = new SqlParameter("@Division", SqlDbType.NVarChar);
            p3.Value = Division;
            SqlParameter p4 = new SqlParameter("@Zone", SqlDbType.NVarChar);
            p4.Value = Zone;
            SqlParameter p5 = new SqlParameter("@Center", SqlDbType.NVarChar);
            p5.Value = Center;
            SqlParameter p6 = new SqlParameter("@academicyear", SqlDbType.NVarChar);
            p6.Value = Academicyear;
            SqlParameter p7 = new SqlParameter("@Stream", SqlDbType.NVarChar);
            p7.Value = Stream;
            SqlParameter p8 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p8.Value = Userid;

            SqlParameter p9 = new SqlParameter("@customer_type", SqlDbType.NVarChar);
            p9.Value = Customer_Type;
            SqlParameter p10 = new SqlParameter("@institution_type", SqlDbType.NVarChar);
            p10.Value = Institutiontype;
            SqlParameter p11 = new SqlParameter("@board_id", SqlDbType.NVarChar);
            p11.Value = Boardid;
            SqlParameter p12 = new SqlParameter("@standard", SqlDbType.NVarChar);
            p12.Value = Standard;
            SqlParameter p13 = new SqlParameter("@MOBILE", SqlDbType.NVarChar);
            p13.Value = Mobile;
            SqlParameter p14 = new SqlParameter("@country", SqlDbType.NVarChar);
            p14.Value = Country;
            SqlParameter p15 = new SqlParameter("@state", SqlDbType.NVarChar);
            p15.Value = State;
            SqlParameter p16 = new SqlParameter("@city", SqlDbType.NVarChar);
            p16.Value = City;
            SqlParameter p17 = new SqlParameter("@location", SqlDbType.NVarChar);
            p17.Value = Location;

            SqlParameter P18 = new SqlParameter("@productcategory", SqlDbType.NVarChar);
            P18.Value = Productcategory;
            SqlParameter p19 = new SqlParameter("@fromdt", SqlDbType.NVarChar);
            p19.Value = Fromdate;
            SqlParameter p20 = new SqlParameter("@todt", SqlDbType.NVarChar);
            p20.Value = Todate;
            SqlParameter p21 = new SqlParameter("@orderstatus", SqlDbType.NVarChar);
            p21.Value = OrderStatus;
            SqlParameter p22 = new SqlParameter("@sbentrycode", SqlDbType.NVarChar);
            p22.Value = Sbentrycode;
            SqlParameter p23 = new SqlParameter("@flag", SqlDbType.NVarChar);
            p23.Value = Active;
            SqlParameter p24 = new SqlParameter("@promote", SqlDbType.NVarChar);
            p24.Value = Promoted;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Account_Search_Results_For_SMS", p, p1, p2, p3, p4, p5, p6,
            p7, p8, p9, p10, p11, p12, p13, p14, p15, p16,
            p17, P18, p19, p20, p21, p22, p23, p24));
        }

        //For Enquiry
        public static DataSet GetStudent_ForEnquiryFromOpp(string StudentName, string DivisionCode, string CenterCode, string ProductCode, string SBEntryCode, string AppNo, string UserCode, string Acad_Year)
        {
            SqlParameter p1 = new SqlParameter("@StudentName", StudentName);
            SqlParameter p2 = new SqlParameter("@DivisionCode", DivisionCode);
            SqlParameter p3 = new SqlParameter("@CenterCode", CenterCode);
            SqlParameter p4 = new SqlParameter("@ProductCode", ProductCode);
            SqlParameter p5 = new SqlParameter("@SbentryCode", SBEntryCode);
            SqlParameter p6 = new SqlParameter("@AppNo", AppNo);
            SqlParameter p7 = new SqlParameter("@UserCode", UserCode);
            SqlParameter p8 = new SqlParameter("@Acad_Year", Acad_Year);

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "Usp_Get_OppStudent_SMS_Enquiry", p1, p2, p3, p4, p5, p6, p7, p8));
        }
        //05 May 2016
        public static DataSet Get_Batchwise_Student_Results(string company,string Division,string Zone,string Center,string Acad_Year,string course,string Batch,string UserId,string flag)
        {
            SqlParameter p = new SqlParameter("@company", SqlDbType.NVarChar);
            p.Value = company;
            SqlParameter p1 = new SqlParameter("@division", SqlDbType.NVarChar);
            p1.Value = Division;
            SqlParameter p2 = new SqlParameter("@zone", SqlDbType.NVarChar);
            p2.Value = Zone;
            SqlParameter p3 = new SqlParameter("@center", SqlDbType.NVarChar);
            p3.Value = Center;
            SqlParameter p4 = new SqlParameter("@academicyear", SqlDbType.NVarChar);
            p4.Value = Acad_Year;
            SqlParameter p5 = new SqlParameter("@Batch", SqlDbType.NVarChar);
            p5.Value = Batch;
            SqlParameter p6 = new SqlParameter("@Course", SqlDbType.NVarChar);
            p6.Value = course;

            SqlParameter p7 = new SqlParameter("@userid", SqlDbType.NVarChar);
            p7.Value = UserId;
            SqlParameter p8 = new SqlParameter("@flag", SqlDbType.NVarChar);
            p8.Value = flag;

            return (SqlHelper.ExecuteDataset(ConnectionString.GetConnectionString(), CommandType.StoredProcedure, "USP_Get_Student_Search_Results_ByBatchwise_For_SMS", p, p1, p2, p3, p4, p5, p6, p7, p8));
        }
    }
}

