using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserDashBoard1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string FromDate = null;
            string ToDate = null;
            ToDate = System.DateTime.Now.ToString("dd MMM yyyy");
            FromDate = System.DateTime.Now.AddMonths(-1).ToString("dd MMM yyyy");
            lblReportPeriod.Text = "Period: " + FromDate + " - " + ToDate;
            FillAbsentRelatedItems(false);

          
        }

        
        
    }

    private void FillAbsentRelatedItems(bool ReloadFlag)
    {
        //Check if data exists in session variable
        //Load from session 
        //string a = Session["dtCentreSummary"].ToString().Trim();
        DataTable dtDivSummary = (DataTable)Session["dtDivSummary_1"];
        DataTable dtDivMailSummary = (DataTable)Session["dtDivMailSummary_1"];
        DataTable dtCentreRank = (DataTable)Session["dtSMSCentreRank_1"];
        
        string CurrentCentreCode = (string)Session["CurrentCentreCode_1"];

        if (dtCentreRank == null | dtDivSummary==null | dtDivMailSummary==null | ReloadFlag == true)
        {
            //If not exits then retrieve from database

            string FromDate = null;
            string ToDate = null;
            string Todate1 = null;
            Todate1 = System.DateTime.Now.AddDays(1).ToString("dd MMM yyyy");
            ToDate = System.DateTime.Now.ToString("dd MMM yyyy");
            FromDate = System.DateTime.Now.AddMonths(-1).ToString("dd MMM yyyy");
            lblReportPeriod.Text = "Period: " + FromDate + " - " + ToDate;

            Label lblHeader_User_Code = default(Label);
            lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            Label lblHeader_Company_Code = default(Label);
            lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

            Label lblHeader_DBName = default(Label);
            lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            try
            {


                DataSet dsGrid = ProductController.Dashboard_MessagingEngine(UserID, FromDate, Todate1, "MTEducare", "1");
                if (dsGrid != null)
                {
                    if (dsGrid.Tables.Count != 0)
                    {
                        Session["dtDivSummary_1"] = dsGrid.Tables[1];
                        Session["dtDivMailSummary_1"] = dsGrid.Tables[2];
                        Session["dtSMSCentreRank_1"] = dsGrid.Tables[0];

                        dlGrid_CentreAbsent.DataSource = dsGrid.Tables[1];
                        dlGrid_CentreAbsent.DataBind();

                        dlGrid_StudentAbsent.DataSource = dsGrid.Tables[2];
                        dlGrid_StudentAbsent.DataBind();

                        string CentreCode = "";
                        FillCentreRankBoard(dsGrid.Tables[0], CentreCode);
                       

                    }
                }
            }
            catch (Exception ex)
            {
            }


        }
        else
        {

            dlGrid_CentreAbsent.DataSource = dtDivSummary;
            dlGrid_CentreAbsent.DataBind();

            dlGrid_StudentAbsent.DataSource = dtDivMailSummary;
            dlGrid_StudentAbsent.DataBind();


            FillCentreRankBoard(dtCentreRank, CurrentCentreCode);
            //FillTodaysLecture();
        }

    }

    

    private void FillCentreRankBoard(DataTable dt, string CentreCode)
    {
        try
        {
            //Label lblHeader_Notification_TodaysLecture = default(Label);
            //lblHeader_Notification_TodaysLecture = (Label)Master.FindControl("lblHeader_Notification_TodaysLecture");
            //lblHeader_Notification_TodaysLecture.Text = "";


            //If centrecode is blank then show data of first centre that is available
            if (string.IsNullOrEmpty(CentreCode))
            {
                if (dt != null)
                {
                    if (dt.Rows.Count != 0)
                    {
                        CentreCode = Convert.ToString(dt.Rows[0]["Source_Center_Code"]);
                        lblCentreDashboard_CentreNumber.Text = "0";

                    }
                    else
                    {
                        lblCentreDashboard_CentreNumber.Text = "0";
                    }

                }
                else
                {
                    lblCentreDashboard_CentreNumber.Text = "0";
                }

            }

            int RowCnt = 0;
            foreach (DataRow dtitem in dt.Rows)
            {
                if (dtitem["Source_Center_Code"] == CentreCode)
                {
                    lblCentreDashboard_CentreName.Text = Convert.ToString(dtitem["Centre_Name"]);
                    lblCentreDashboard_PendingSMSCount.Text = Convert.ToString(dtitem["Pending_SMS"]);
                    lblCentreDashboard_SentSMSCount.Text = Convert.ToString(dtitem["Sent_SMS"]);
                    lblpendingEmails_Count.Text = Convert.ToString(dtitem["Pending_Mail"]);
                    lblSentEmails_Count.Text = Convert.ToString(dtitem["Sent_Mail"]);
                    //lblCentreDashboard_AttendPending.Text = Convert.ToString(dtitem["Pending_Attendance"]);

                                       

                    lblCentreDashboard_CentreNumber.Text = RowCnt.ToString();
                    break; // TODO: might not be correct. Was : Exit For
                }
                RowCnt = RowCnt + 1;
            }

            Session["CurrentCentreCode_1"] = CentreCode;
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btn_PreviousCentre_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            DataTable dtCentreRank = (DataTable)Session["dtSMSCentreRank_1"];
            if (dtCentreRank != null)
            {
                int NewCentreNo = 0;
                NewCentreNo = Convert.ToInt32(lblCentreDashboard_CentreNumber.Text) - 1;
                string CentreCode = null;

                if (NewCentreNo >= 0)
                {
                    CentreCode = Convert.ToString(dtCentreRank.Rows[NewCentreNo]["Source_Center_Code"]);
                    FillCentreRankBoard(dtCentreRank, CentreCode);
                    
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btn_NextCentre_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            DataTable dtCentreRank = (DataTable)Session["dtSMSCentreRank_1"];

            int NewCentreNo = 0;
            NewCentreNo = Convert.ToInt32(lblCentreDashboard_CentreNumber.Text) + 1;
            string CentreCode = null;

            if (NewCentreNo < dtCentreRank.Rows.Count)
            {
                CentreCode = Convert.ToString(dtCentreRank.Rows[NewCentreNo]["Source_Center_Code"]);
                FillCentreRankBoard(dtCentreRank, CentreCode);
                
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    
}