using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using ShoppingCart.BL;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI;

public partial class SMS_Log_Report_Contactwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Page_Validation();
            FillDDL_Division();
            FillDDL_MessageStatus();
            Msg_Info.Visible = true;
            lblInfo.Text = "For Quick results, use filters below";
        }

    }

    private void Page_Validation()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        System.IO.FileInfo Info = new System.IO.FileInfo(Path);
        string pageName = Info.Name;

        int ResultId = 0;

        ResultId = ProductController.Chk_Page_Validation(pageName, UserID, "DB00");

        if (ResultId >= 1)
        {
            //Allow
        }
        else
        {
            Response.Redirect("~/Homepage.aspx", false);
        }

    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        lblSuccess.Text = "";
        UpdatePanelMsgBox.Update();
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            //DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            
            DivResultPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
           // DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            
            DivResultPanel.Visible = true;

        }
        else if (Mode == "Add")
        {
           // DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Edit")
        {
           // DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            

        }
        else if (Mode == "TopSearch")
        {
           // DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
           
            DivResultPanel.Visible = false;

        }

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            fill_grid_message();
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }

    }

    private void fill_grid_message()
    {
        Clear_Error_Success_Box();
        if (ddlDivision.SelectedIndex ==0)
        {
            Show_Error_Success_Box("E", "Select Division");
            ddlDivision.Focus();
            return;
        }
        if (ddlCentre.SelectedIndex == 0)
        {
            Show_Error_Success_Box("E", "Select Centre");
            ddlCentre.Focus();
            return;
        }


        //if (ddlStatus.SelectedItem.ToString() == "Select")
        //{
        //    Show_Error_Success_Box("E", "Select Status");
        //    ddlStatus.Focus();
        //    return;
        //}

        if (id_date_range_picker_2.Value == "")
        {
            Show_Error_Success_Box("E", "Select Date Range");
            id_date_range_picker_2.Focus();
            return;
        }


        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        ControlVisibility("Result");

        string Div_Code = null;
        Div_Code = ddlDivision.SelectedValue;

        string CentreCode = null;
        CentreCode = ddlCentre.SelectedValue;

        int Status = 0;
       // Status = Convert .ToInt32(ddlStatus.SelectedValue.ToString ().Trim ());

        string DateRange = "";
        DateRange = id_date_range_picker_2.Value;

        string FromDate, ToDate;
        FromDate = DateRange.Substring(0, 10);
        ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

        DataSet dsGrid = new DataSet();
        dsGrid = ProductController.GetSMS_Log_Report_Contactwise(ddlDivision.SelectedValue, CentreCode, FromDate, ToDate, txtMobileNo.Text.Trim(), UserID, 1);

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {

                dlMessageDetail.DataSource = dsGrid;
                dlMessageDetail.DataBind();


                lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();
            }
            else
            {
                dlMessageDetail.DataSource = null;
                dlMessageDetail.DataBind();
                
                lbltotalcount.Text = "0";
            }
        }
        else
        {
            dlMessageDetail.DataSource = null;
            dlMessageDetail.DataBind();


            lbltotalcount.Text = "0";
        }
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Field();
        ddlCentre.Items.Clear();
        id_date_range_picker_2.Value = "";
        txtMobileNo.Text = "";
        //ddlStatus.SelectedIndex = 0;
    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("TopSearch");
        Clear_Error_Success_Box();
    }
    

    private void Clear_Field()
    {
        ddlDivision.SelectedIndex = 0;
        //ddlCentre.Items.Clear();
        //id_date_range_picker_2.Value = "";
        //ddlStatus.SelectedIndex = 0;
        //lblslotid.Text = "";
        //lbldelCode.Text = "";

    }

    protected void btnClear_Add_Click(object sender, EventArgs e)
    {
        Clear_Field();
        ControlVisibility("Result");
        fill_grid_message();
        Clear_Error_Success_Box();
    }
    
   
    protected void btnExport_Click(object sender, EventArgs e)
    {

        string mobileno = "All Contacts";
        if(txtMobileNo.Text.Trim()!="")
        {
            mobileno = txtMobileNo.Text.Trim();
        }
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "SMS_Log_Report_Contactwise_" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='5'>SMS-Log Report Contactwise</b></TD></TR><TR><TD><b>Division : " + ddlDivision.SelectedItem.ToString() + "</b></TD><TD><b>Centre : " + ddlCentre.SelectedItem.ToString() + "</b></TD><TD Colspan='2'><b>Period : " + id_date_range_picker_2.Value + "<b></TD><TD><b>Mobile No : " + mobileno + "</b></TD></TR><TR></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        dlMessageDetail.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

    }





    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
        else
        {
            Msg_Success.Visible = true;
            Msg_Error.Visible = false;
            lblSuccess.Text = ProductController.Raise_Error(Error_Code);
            UpdatePanelMsgBox.Update();
        }
    }


    private void FillDDL_Division()
    {

        try
        {

            Clear_Error_Success_Box();
            ddlDivision.Items.Clear();

            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
            BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
            ddlDivision.Items.Insert(0, "Select");
            ddlDivision.SelectedIndex = 0;

            
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }

    private void FillDDL_MessageStatus()
    {

        try
        {

            Clear_Error_Success_Box();
            //ddlStatus.Items.Clear();

            //DataSet dsStatus = ProductController.GetAllMessage_Status(4);
            //BindDDL(ddlStatus, dsStatus, "Description", "id");
            //ddlStatus.Items.Insert(0, "Select");
            //ddlStatus.SelectedIndex = 0;


        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }

    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }


    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDDL_Centre();
    }


    private void FillDDL_Centre()
    {
        try
        {
            //Label lblHeader_Company_Code = default(Label);
            //lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

            //Label lblHeader_User_Code = default(Label);
            //lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

            //Label lblHeader_DBName = default(Label);
            //lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");

            string Company_Code = "MT";
            string DBname = "CDB";

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];

            DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code,ddlDivision.SelectedValue .ToString (), "", "5", DBname);
            BindDDL(ddlCentre, dsCentre, "Center_Name", "Center_Code");
            ddlCentre.Items.Insert(0, "Select");
            ddlCentre.Items.Insert(1, "General SMS");
            ddlCentre.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
            UpdatePanelMsgBox.Update();
            return;
        }
    }

   
}