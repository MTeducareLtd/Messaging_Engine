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

public partial class Log_SMS : System.Web.UI.Page
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
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
            
            DivResultPanel.Visible = false;
        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            
            DivResultPanel.Visible = true;

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnShowSearchPanel.Visible = true;
            
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Edit")
        {
            DivAddPanel.Visible = true;
            DivResultPanel.Visible = false;
            DivSearchPanel.Visible = false;
            

        }
        else if (Mode == "TopSearch")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnShowSearchPanel.Visible = false;
           
            DivResultPanel.Visible = false;

        }

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        
        
        fill_grid_message();

    }

    private void fill_grid_message()
    {
        Clear_Error_Success_Box();
        string Div_Code = "", Div_Name = "";
        for (int DivCnt = 0; DivCnt <= ddlDivision.Items.Count - 1; DivCnt++)
        {
            if (ddlDivision.Items[DivCnt].Selected == true)
            {
                Div_Code = Div_Code + ddlDivision.Items[DivCnt].Value + ",";
                Div_Name = Div_Name + ddlDivision.Items[DivCnt].Text + ",";
            }
        }

        if (Div_Code == "")
        {
            Show_Error_Success_Box("E", "Select atleast one division");
            return;
        }

        string Center_Code = "";
        string Center_Name = "";
        int CenterCnt = 0;
        int CenterSelCnt = 0;

        for (CenterCnt = 0; CenterCnt <= ddlCenter.Items.Count - 1; CenterCnt++)
        {
            if (ddlCenter.Items[CenterCnt].Selected == true)
            {
                CenterSelCnt = CenterSelCnt + 1;
            }
        }


        if (CenterSelCnt == 0)
        {
            //When all is selected   
            Show_Error_Success_Box("E", "0006");
            ddlCenter.Focus();
            return;
        }
        else
        {
            for (CenterCnt = 0; CenterCnt <= ddlCenter.Items.Count - 1; CenterCnt++)
            {
                if (ddlCenter.Items[CenterCnt].Selected == true)
                {
                    Center_Code = Center_Code + ddlCenter.Items[CenterCnt].Value + ",";
                    Center_Name = Center_Name + ddlCenter.Items[CenterCnt].Text + ",";
                }
            }
            Center_Code = Common.RemoveComma(Center_Code);
            Center_Name = Common.RemoveComma(Center_Name);
        }
        

        if (id_date_range_picker_2.Value == "")
        {
            Show_Error_Success_Box("E", "Select Date Range");
            id_date_range_picker_2.Focus();
            return;
        }

        string Status = "";
        for (int cnt = 0; cnt <= lststatus.Items.Count - 1; cnt++)
        {
            if (lststatus.Items[cnt].Selected == true)
            {
                Status = Status + lststatus.Items[cnt].Value + ",";
            }
        }
        if (Status == "")
        {
            Show_Error_Success_Box("E", "Select at least One Status");
            UpdatePanelMsgBox.Focus();
            //ddlAddClassRoomProduct.Focus();
            return;
        }

        Status = Status.Substring(0, Status.Length - 1);




        ControlVisibility("Result");

        //string Div_Code = null;
        //Div_Code = ddlDivision.SelectedValue;

        //string CentreCode = null;
        //CentreCode = ddlCentre.SelectedValue;

        //int Status = 0;
        //Status = Convert .ToInt32(ddlStatus.SelectedValue.ToString ().Trim ());

        string DateRange = "";
        DateRange = id_date_range_picker_2.Value;

        string FromDate, ToDate;
        FromDate = DateRange.Substring(0, 10);
        ToDate = (DateRange.Length > 9) ? DateRange.Substring(DateRange.Length - 10, 10) : DateRange;

        DataSet dsGrid = new DataSet();

        dsGrid = ProductController.GetLogSMS_SearchField(Center_Code, FromDate, ToDate, Status, 1);

        if (dsGrid != null)
        {
            if (dsGrid.Tables.Count != 0)
            {

                dlDivision.DataSource = dsGrid;
                dlDivision.DataBind();

                DataList1.DataSource = dsGrid;
                DataList1.DataBind();

                lbltotalcount.Text = dsGrid.Tables[0].Rows.Count.ToString();
            }
            else
            {
                dlDivision.DataSource = null;
                dlDivision.DataBind();

                DataList1.DataSource = null ;
                DataList1.DataBind();

                lbltotalcount.Text = "0";
            }
        }
        else
        {
            dlDivision.DataSource = null;
            dlDivision.DataBind();

            DataList1.DataSource = null;
            DataList1.DataBind();

            lbltotalcount.Text = "0";
        }
    }

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Field();
        //ddlCentre.Items.Clear();
        id_date_range_picker_2.Value = "";
        //ddlStatus.SelectedIndex = 0;
        lststatus.Items.Clear();
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
        lblslotid.Text = "";
        lbldelCode.Text = "";

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
        DataList1.Visible = true;

        string Status = "";
        for (int cnt = 0; cnt <= lststatus.Items.Count - 1; cnt++)
        {
            if (lststatus.Items[cnt].Selected == true)
            {
                Status = Status + lststatus.Items[cnt].Text + ",";
            }
        }
        
        Status = Status.Substring(0, Status.Length - 1);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        string filenamexls1 = "Log_SMS" + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "inline;filename=" + filenamexls1);
        HttpContext.Current.Response.Charset = "utf-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //sets font
        HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
        HttpContext.Current.Response.Write("<BR><BR><BR>");
        HttpContext.Current.Response.Write("<Table border='1'  borderColor='#000000' cellSpacing='0' cellPadding='0' style='font-size:10.0pt; font-family:Calibri; text-align:center;'> <TR style='color: #fff; background: black;text-align:center;'><TD Colspan='5'>Log-SMS</b></TD></TR><TR><TD Colspan='2'><b>Period : " + id_date_range_picker_2.Value + "<b></TD><TD Colspan='3'><b>Status : " + Status + "</b></TD></TR><TR></TR>");
        Response.Charset = "";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter1 = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(oStringWriter1);
        //this.ClearControls(dladmissioncount)
        DataList1.RenderControl(oHtmlTextWriter1);
        Response.Write(oStringWriter1.ToString());
        Response.Flush();
        Response.End();

        DataList1.Visible = false;
    }

    protected void dlDivision_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ControlVisibility("Add");
        Clear_Error_Success_Box();
        if (e.CommandName == "comOpen")
        {
            ControlVisibility("Add");

            lbldelCode.Text = e.CommandArgument.ToString();
            FilDivision(lbldelCode.Text);
            
        }
    }


    private void FilDivision(string PKey)
    {

        try
        {
            string Status = "";
            for (int cnt = 0; cnt <= lststatus.Items.Count - 1; cnt++)
            {
                if (lststatus.Items[cnt].Selected == true)
                {
                    Status = Status + lststatus.Items[cnt].Value + ",";
                }
            }
            if (Status == "")
            {
                Show_Error_Success_Box("E", "Select at least One Status");
                UpdatePanelMsgBox.Focus();
                //ddlAddClassRoomProduct.Focus();
                return;
            }

            Status = Status.Substring(0, Status.Length - 1);
             DataSet dsData = ProductController.GetLogSMS_Details(PKey, Status, 2);

            if (dsData.Tables[0].Rows.Count > 0)
            {
                lblDate.Text = dsData.Tables[0].Rows[0]["date"].ToString();
                lblModule.Text = dsData.Tables[0].Rows[0]["Message_Name"].ToString();
                lblSMSCount.Text = dsData.Tables[0].Rows[0]["SMS_Count"].ToString();
                lblUsername.Text = dsData.Tables[0].Rows[0]["SendBy"].ToString();
                               
                lblHeader_Add.Text = "Log Details";
                DataSet dsGrid = ProductController.GetLogSMS_Details(PKey, Status, 3);

                if (dsGrid.Tables[0].Rows.Count > 0)
                {
                    dlDivision0.DataSource = dsGrid;
                    dlDivision0.DataBind();
                }
                else
                {
                    dlDivision0.DataSource =null;
                    dlDivision0.DataBind();
                }

            }


        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
            return;
        }
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


    //private void FillDDL_Division()
    //{

    //    try
    //    {

    //        Clear_Error_Success_Box();
    //        ddlDivision.Items.Clear();

    //        string Company_Code = "MT";
    //        string DBname = "CDB";

    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        string UserID = cookie.Values["UserID"];
    //        string UserName = cookie.Values["UserName"];

    //        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
    //        BindDDL(ddlDivision, dsDivision, "Division_Name", "Division_Code");
    //        ddlDivision.Items.Insert(0, "Select");
    //        ddlDivision.SelectedIndex = 0;

            
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}

    private void FillDDL_Division()
    {
        string Company_Code = "MT";
        string DBname = "CDB";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet dsDivision = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, "", "", "2", DBname);
        BindListBox(ddlDivision, dsDivision, "Division_Name", "Division_Code");
    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void FillDDL_MessageStatus()
    {

        try
        {

            Clear_Error_Success_Box();
            lststatus.Items.Clear();

            DataSet dsStatus = ProductController.GetAllMessage_Status(4);
            BindListBox(lststatus, dsStatus, "Description", "id");
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
        ddlCenter.Items.Clear();
        string Company_Code = "MT";
        string DBname = "CDB";
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        string Div_Code = "";
        //Div_Code = ddlDivision.SelectedValue;
        for (int DivCnt = 0; DivCnt <= ddlDivision.Items.Count - 1; DivCnt++)
        {
            if (ddlDivision.Items[DivCnt].Selected == true)
            {
                Div_Code = Div_Code + ddlDivision.Items[DivCnt].Value + ",";
            }
        }
        DataSet dsCenter = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code, Div_Code, "", "5", DBname);
        BindListBox(ddlCenter, dsCenter, "Center_Name", "Center_Code");
        ddlCenter.Items.Insert(0, "All");
    }

    //private void FillDDL_Centre()
    //{
    //    try
    //    {
    //        //Label lblHeader_Company_Code = default(Label);
    //        //lblHeader_Company_Code = (Label)Master.FindControl("lblHeader_Company_Code");

    //        //Label lblHeader_User_Code = default(Label);
    //        //lblHeader_User_Code = (Label)Master.FindControl("lblHeader_User_Code");

    //        //Label lblHeader_DBName = default(Label);
    //        //lblHeader_DBName = (Label)Master.FindControl("lblHeader_DBName");

    //        string Company_Code = "MT";
    //        string DBname = "CDB";

    //        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
    //        string UserID = cookie.Values["UserID"];
    //        string UserName = cookie.Values["UserName"];

    //        DataSet dsCentre = ProductController.GetAllActiveUser_Company_Division_Zone_Center(UserID, Company_Code,ddlDivision.SelectedValue .ToString (), "", "5", DBname);
    //        BindDDL(ddlCentre, dsCentre, "Center_Name", "Center_Code");
    //        ddlCentre.Items.Insert(0, "Select");
    //        ddlCentre.Items.Insert(1, "General SMS");
    //        ddlCentre.SelectedIndex = 0;
    //    }
    //    catch (Exception ex)
    //    {
    //        Msg_Error.Visible = true;
    //        Msg_Success.Visible = false;
    //        lblerror.Text = ex.ToString();
    //        UpdatePanelMsgBox.Update();
    //        return;
    //    }
    //}

   
}