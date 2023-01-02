using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Data.SqlClient.SqlDataReader;
//using Exportxls.BL;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using ShoppingCart.BL;
//using Exportxls.BL;
using Encryption.BL;
//using ChequeReturnRequest;
using System.Net.Mail;
using System.Net;

public partial class SMS_Batchwise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string Menuid = "117";
            if (Request.Cookies["MyCookiesLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                string UserID = cookie.Values["UserID"];
                string UserName = cookie.Values["UserName"];
                lblpagetitle1.Text = "Batchwise SMS";
                lblpagetitle2.Text = "Search Panel";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Batchwise SMS";
                //lilastbreadcrumb.Visible = false;
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divpendingreuesterror.Visible = false;
               
                listudentstatus.Visible = false;
                btnviewenrollment.Visible = false;
                BtnShowSearchPanel.Visible = false;
                Msg_Info.Visible = true;
                lblInfo.Text = "SMS will be sent for those students who are available";

               
                string UserCompany = "MT";
                
                lblusercompany.Text = UserCompany;
               
                divmessage.Visible = false;
                divSearch.Visible = true;
                divsearchresults.Visible = false;
                BindCompany();
                BindAcademicYear();
                BindSmsCategory();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
  
    private void BindDDL(DropDownList ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }
    private void BindSmsCategory()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllSMSCategory();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlCategory, ds, "SMSCategoryName", "CategoryID");
        ddlCategory.Items.Insert(0, "Select");
        ddlCategory.SelectedIndex = 0;
    }



    //private void StudentType()
    //{
    //    DataSet ds = ProductController.GetAllStudentType1();
    //    BindDDL(ddlcustomertypesearch, ds, "Description", "Cust_Grp");
    //    ddlcustomertypesearch.Items.Insert(0, "All");
    //    ddlcustomertypesearch.SelectedIndex = 0;
    //}
    //private void Institutetype()
    //{
    //    DataSet ds = ProductController.GetallInstituteType1();
    //    BindDDL(ddlinstitutionsearch, ds, "Description", "ID");
    //    ddlinstitutionsearch.Items.Insert(0, "All");
    //    ddlinstitutionsearch.SelectedIndex = 0;
    //}
    //private void Eventtype()
    //{
    //    DataSet ds = ProductController.GetallEventtype1();
    //    BindDDL(ddlevent, ds, "event_description", "event_type");
    //    ddlevent.Items.Insert(0, "All");
    //    ddlevent.SelectedIndex = 0;
    //}

    //protected void ddlinstitutionsearch_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    DataSet ds = ProductController.GetallCurrentStudyingin1(ddlinstitutionsearch.SelectedValue);
    //    BindDDL(ddlstandardsearch, ds, "Description", "ID");
    //    this.ddlstandardsearch.Items.Insert(0, "All");
    //    this.ddlstandardsearch.SelectedIndex = 0;
    //}
    //private void Board()
    //{
    //    DataSet ds = ProductController.GetallBoard1();
    //    BindDDL(ddlboardsearch, ds, "Short_Description", "ID");
    //    ddlboardsearch.Items.Insert(0, "All");
    //    ddlboardsearch.SelectedIndex = 0;
    //    ddlstandardsearch.Items.Insert(0, "All");
    //    ddlstandardsearch.SelectedIndex = 0;
    //}
    //private void BindProductCategory()
    //{
    //    DataSet ds = ProductController.GetallOpporProductCategory1();
    //    BindDDL(ddlproductcategory, ds, "Description", "ID");
    //    ddlproductcategory.Items.Insert(0, "All");
    //    ddlproductcategory.SelectedIndex = 0;
    //}
    //private void CountrySearch()
    //{
    //    DataSet ds = ProductController.GetallCountry1();
    //    BindDDL(ddlcountrysearch, ds, "Country_Name", "Country_Code");
    //    ddlcountrysearch.Items.Insert(0, "All");
    //    ddlcountrysearch.SelectedIndex = 0;
    //    ddlstatesearch.Items.Insert(0, "All");
    //    ddlstatesearch.SelectedIndex = 0;
    //    ddlcitysearch.Items.Insert(0, "All");
    //    ddlcitysearch.SelectedIndex = 0;
    //    ddllocationsearch.Items.Insert(0, "All");
    //    ddllocationsearch.SelectedIndex = 0;
    //}
    //protected void ddlcountrysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindStateSearch();
    //}
    //protected void ddlstatesearch_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindCitySearch();
    //}
    //protected void ddlcitysearch_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    BindLocationSearch();
    //}
    //private void BindStateSearch()
    //{
    //    DataSet ds = ProductController.GetallStatebyCountry1(ddlcountrysearch.SelectedValue);
    //    BindDDL(ddlstatesearch, ds, "State_Name", "State_Code");
    //    ddlstatesearch.Items.Insert(0, "Select");
    //    ddlstatesearch.SelectedIndex = 0;
    //}
    //private void BindCitySearch()
    //{
    //    DataSet ds = ProductController.GetallCitybyState1(ddlstatesearch.SelectedValue);
    //    BindDDL(ddlcitysearch, ds, "City_Name", "City_Code");
    //    ddlcitysearch.Items.Insert(0, "Select");
    //    ddlcitysearch.SelectedIndex = 0;
    //}
    //private void BindLocationSearch()
    //{
    //    DataSet ds = ProductController.GetallLocationbycity1(ddlcitysearch.SelectedValue);
    //    BindDDL(ddllocationsearch, ds, "Location_Name", "Location_Code");
    //    ddllocationsearch.Items.Insert(0, "All");
    //    ddllocationsearch.SelectedIndex = 0;
    //}

    /// <summary>
    /// Fill List box and assign value and Text
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="ds"></param>
    /// <param name="txtField"></param>
    /// <param name="valField"></param>
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    private void BindCompany()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center1(1, UserID, "", "", "");
        BindDDL(ddlcompany, ds, "Company_Name", "Company_Code");
        //ddlcompany.Items.Insert(0, "All")
        //ddlcompany.SelectedIndex = 1
        BindDivision();
        //ddldivision.Items.Insert(0, "All")
        //ddldivision.SelectedIndex = 0

        ddlzone.Items.Insert(0, "Select");
        ddlzone.SelectedIndex = 0;

        ddlcenter.Items.Insert(0, "Select");
        ddlcenter.SelectedIndex = 0;

        ddlCourse.Items.Insert(0, "Select");
        ddlCourse.SelectedIndex = 0;

        //ddlacademicyear.Items.Insert(0, "Select");
        //ddlacademicyear.SelectedIndex = 0;

        //ddlstream.Items.Insert(0, "All");
        //ddlstream.SelectedIndex = 0;
    }

    protected void ddlcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindDivision();
    }

    private void BindDivision()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center1(2, UserID, "", "", ddlcompany.SelectedValue);
        BindDDL(ddldivision, ds, "Division_Name", "Division_Code");
        ddldivision.Items.Insert(0, "Select");
        ddldivision.SelectedIndex = 0;
    }

    protected void ddldivision_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindZone();
        BindBatch();
        FillDDL_Standard();
        //BindCenter()
    }

    private void BindZone()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center1(3, UserID, ddldivision.SelectedValue, "", ddlcompany.SelectedValue);
        BindDDL(ddlzone, ds, "Zone_Name", "Zone_Code");
        ddlzone.Items.Insert(0, "Select");
        ddlzone.SelectedIndex = 0;
    }
    protected void ddlzone_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        BindCenter();
        BindBatch();
    }
    private void BindCenter()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];

        DataSet ds = ProductController.GetUser_Company_Division_Zone_Center1(4, UserID, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcompany.SelectedValue);
        BindDDL(ddlcenter, ds, "Center_name", "Center_Code");
        ddlcenter.Items.Insert(0, "Select");
        ddlcenter.SelectedIndex = 0;
    }
    protected void ddlcenter_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // BindAcademicYear();
        BindBatch();
    }
    private void BindAcademicYear()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetAllAcadyear1();
        //DataSet ds = ProductController.GetAcademicYearbyCenter(ddlcenter.SelectedValue);
        BindDDL(ddlacademicyear, ds, "Acad_Year", "Acad_Year");
        ddlacademicyear.Items.Insert(0, "Select");
        ddlacademicyear.SelectedIndex = 0;
    }
    protected void ddlacademicyear_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindStream();
        BindBatch();
        FillDDL_Standard();
    }
    private void BindStream()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        DataSet ds = ProductController.GetStreamby_Center_AcademicYear_All1(ddlcenter.SelectedValue, ddlacademicyear.SelectedValue);
        //BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        //ddlstream.Items.Insert(0, "All");
        //ddlstream.SelectedIndex = 0;
    }

    private void FillDDL_Standard()
    {
        string Div_Code = null;
        Div_Code = ddldivision.SelectedValue;

        string YearName = null;
        YearName = ddlacademicyear.SelectedItem.ToString();

        DataSet dsStandard = ProductController.GetAllActive_Standard_ForYear(Div_Code, YearName);
        BindDDL(ddlCourse, dsStandard, "Standard_Name", "Standard_Code");
        ddlCourse.Items.Insert(0, "Select");
        ddlCourse.SelectedIndex = 0;
    }


    /// <summary>
    /// Show Error or success box on top base on boxtype and Error code
    /// </summary>
    /// <param name="BoxType">BoxType</param>
    /// <param name="Error_Code">Error_Code</param>
    private void Show_Error_Success_Box(string BoxType, string Error_Code)
    {
        if (BoxType == "E")
        {
            divErrormessage.Visible = true;
            divSuccessmessage.Visible = false;
            lblerrormessage.Text = ProductController.Raise_Error(Error_Code);
            //UpdatePaneSMSsend.Update();
        }
        else
        {
            divSuccessmessage.Visible = true;
            divErrormessage.Visible = false;
            lblsuccessMessage.Text = ProductController.Raise_Error(Error_Code);
            //UpdatePaneSMSsend.Update();
        }
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        //BindStream();
        BindBatch();
    }

    private void BindBatch()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];
        string UserName = cookie.Values["UserName"];
        
        if ((ddldivision.SelectedIndex == 0) || (ddlcenter.SelectedIndex == 0) || (ddlacademicyear.SelectedIndex == 0)||(ddlCourse.SelectedIndex==0))
        {
            ddlBatch.Items.Clear();
        }
        else
        {
            ddlBatch.Items.Clear();
            DataSet ds = ProductController.GetBatchBy_Division_Year_Standard_Centre(ddldivision.SelectedValue, ddlacademicyear.SelectedValue,ddlCourse.SelectedValue, ddlcenter.SelectedValue, "%");
            BindListBox(ddlBatch, ds, "BatchShortName", "PKey");
        }
        //BindDDL(ddlstream, ds, "Stream_Sdesc", "Stream_Code");
        //ddlstream.Items.Insert(0, "All");
        //ddlstream.SelectedIndex = 0;
    }

    protected void btnsearch_ServerClick(object sender, System.EventArgs e)
    {
        try
        {
            divErrormessage.Visible = false;
            divSuccessmessage.Visible = false;
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];


            string Company = "";
            string Division = "";
            string Zone = "";
            string Center = "";
            string AcademicYear = "";
            string Course = "";
            string BatchCode = "";

            if (ddldivision.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Division");
                return;
            }
            if (ddlzone.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Zone");
                return;
            }
            if (ddlcenter.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Center");
                return;
            }

            if (ddlacademicyear.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Acad Year");
                return;
            }

            if (ddlCourse.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Course");
                return;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Category");
                return;
            }


            for (int cnt = 0; cnt <= ddlBatch.Items.Count - 1; cnt++)
            {
                if (ddlBatch.Items[cnt].Selected == true)
                {
                    BatchCode = BatchCode + ddlBatch.Items[cnt].Value + ",";
                }
            }
            if (BatchCode == "")
            {
                Show_Error_Success_Box("E", "Atleast one Batch should be selected");
                ddlBatch.Focus();
                return;
            }


            //StudentName = txtstudentname.Text;
            //Applicationno = txtapplicationno.Text;
            Company = ddlcompany.SelectedValue;
            Division = ddldivision.SelectedValue;
            Zone = ddlzone.SelectedValue;
            Center = ddlcenter.SelectedValue;
            AcademicYear = ddlacademicyear.SelectedValue;
            Course = ddlCourse.SelectedValue;




            DataSet ds = new DataSet();

            ds = AccountController.Get_Batchwise_Student_Results(ddlcompany.SelectedValue, ddldivision.SelectedValue, ddlzone.SelectedValue, ddlcenter.SelectedValue, ddlacademicyear.SelectedValue, ddlCourse.SelectedValue, BatchCode, UserID, "1");
                        
            if (ds.Tables[0].Rows.Count > 0)
            {
                Divsearchcriteria.Visible = false;
                lblpagetitle1.Text = "Batchwise SMS";
                lblpagetitle2.Text = "Search Results";
                //limidbreadcrumb.Visible = true;
                lblmidbreadcrumb.Text = "Batchwise SMS";
                //lilastbreadcrumb.Visible = true;
                lbllastbreadcrumb.Text = " SMS Search Results";
                divSuccessmessage.Visible = false;
                divErrormessage.Visible = false;
                divsearchresults.Visible = true;
                divmessage.Visible = false;
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
                lbltotalcount.Text = ds.Tables[0].Rows.Count.ToString();
                script1.RegisterAsyncPostBackControl(Repeater1);
                BtnShowSearchPanel.Visible = true;

            }
            else
            {
                divsearchresults.Visible = false;
                Divsearchcriteria.Visible = true;
                divmessage.Visible = true;
                lblmessage.Text = "No Records Found!";
            }
        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    public void All_Student_ChkBox_Selected_Sel(object sender, System.EventArgs e)
    {
        //Change checked status of a hidden check box
        chkStudentAllHidden_Sel.Checked = !(chkStudentAllHidden_Sel.Checked);

        //Set checked status of hidden check box to items in grid
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            chkitemck.Checked = chkStudentAllHidden_Sel.Checked;
        }

    }

    public void SMSSend(string MobNo, string Msg)
    {
        if (MobNo.Length == 10)
        {
            //MobNo = MobNo; need to chk by jayant
            WebClient client = new WebClient();
            string baseurl = "http://api.smscountry.com/SMSCwebservice_bulk.aspx?User=Sciencetr&passwd=25892846&mobilenumber=" + MobNo + "&message=" + Msg + "&sid=MTEDU&mtype=N&DR=Y";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }
    }

    protected void btnSmsSend_ServerClick(object sender, System.EventArgs e)
    {
        divErrormessage.Visible = false;
        divSuccessmessage.Visible = false;
        int i = 0;
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            if (chkitemck.Checked == true)
            {
                i = 1;
                break;
            }
        }

        if (i == 0)
        {
            Show_Error_Success_Box("E", "Select Atleast one student");
            return;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSms();", true);
        txtsmsstd.Text = "";
        //inputstd.Checked = true;
        //UpdatePaneSMSsend.Update();
    }
    protected void Linkbtnstdnm_Click(object sender, System.EventArgs e)
    {
        txtsmsstd.Text = txtsmsstd.Text + "< NAME >";
    }

    protected void Linkbtnstdfnm_Click(object sender, System.EventArgs e)
    {
        txtsmsstd.Text = txtsmsstd.Text + "< FIRSTNAME >";
    }

    protected void btnSendsmsstd_Click(object sender, System.EventArgs e)
    {

        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        int resultid = 0;
        foreach (RepeaterItem dtlItem in Repeater1.Items)
        {
            CheckBox chkitemck = (CheckBox)dtlItem.FindControl("chkStudent");
            if (chkitemck.Checked == true)
            {
                Label lblstudentmobileno = (Label)dtlItem.FindControl("lblstudentno");
                Label lblparentmobileno = (Label)dtlItem.FindControl("lblfno");
                Label lblfirststudentname = (Label)dtlItem.FindControl("lblfirststudentname");
                Label lbldlstudentname = (Label)dtlItem.FindControl("lblcustomername");
                Label lblCenterCodeSR = (Label)dtlItem.FindControl("lblCenterCodeSR");

                string msg = txtsmsstd.Text;
                string num1 = lblstudentmobileno.Text;
                string num2 = lblparentmobileno.Text;
                string fname = lblfirststudentname.Text;
                string CenterCode = lblCenterCodeSR.Text.Trim();
                string Category = ddlCategory.SelectedValue;

                string upmsg = msg.Replace("< NAME >", lbldlstudentname.Text);
                msg = upmsg;
                upmsg = msg.Replace("< FIRSTNAME >", fname).Replace("&", "%26").Replace("+", "%2D").Replace("%", "%25").Replace("#", "%23").Replace("=", "%3D").Replace("^", "%5E").Replace("~", "%7E"); 
               

                if (inputstd.Checked == true & !string.IsNullOrEmpty(num1))
                {
                    string[] nums1 = num1.Split(new char[] { ',' });
                    num1 = nums1[0].ToString();                    
                    resultid = ProductController.Insert_SMSLog(CenterCode, "008", num1, upmsg, "0", UserID, "Transactional",Category, 7);
                    
                   // SMSSend(num1, msg);
                }
                else if (inputpar.Checked == true & !string.IsNullOrEmpty(num2))
                {
                    string[] nums2 = num2.Split(new char[] { ',' });
                    num2 = nums2[0].ToString();
                   
                    resultid = ProductController.Insert_SMSLog(CenterCode, "008", num2, upmsg, "0", UserID, "Transactional",Category, 7);                   
                    //SMSSend(num2, msg);
                }
                else if (inputboth.Checked == true)
                {
                    if (!string.IsNullOrEmpty(num1))
                    {
                        string[] nums1 = num1.Split(new char[] { ',' });
                        resultid = ProductController.Insert_SMSLog(CenterCode, "008", num1, upmsg, "0", UserID, "Transactional",Category, 7);                        
                        //SMSSend(num1, msg);
                    }
                    if (!string.IsNullOrEmpty(num2))
                    {
                        string[] nums2 = num2.Split(new char[] { ',' });
                        num2 = nums2[0].ToString();
                        resultid = ProductController.Insert_SMSLog(CenterCode, "008", num2, upmsg, "0", UserID, "Transactional",Category, 7);                        
                        //SMSSend(num2, msg);
                    }
                }
            }
        }

        txtsmsstd.Text = "Dear ";
        inputstd.Checked = false;
        inputpar.Checked = false;
        inputboth.Checked = false;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "CloseModalSms();", true);
    }


    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        //Response.Redirect("SMS.aspx");
        Divsearchcriteria.Visible = true;
        lblpagetitle1.Text = "Batchwise SMS";
        lblpagetitle2.Text = "Search Panel";
        //limidbreadcrumb.Visible = true;
        lblmidbreadcrumb.Text = "SMS";
        //lilastbreadcrumb.Visible = true;
        lbllastbreadcrumb.Text = " SMS Search Panel";
        divSuccessmessage.Visible = false;
        divErrormessage.Visible = false;
        divsearchresults.Visible = false;
        divmessage.Visible = false;        
        BtnShowSearchPanel.Visible = false;

    }

    //protected void Linkbtnmxmark_Click(object sender, System.EventArgs e)
    //{
    //    txtsmsstd.Text = txtsmsstd.Text + "< MXMARK >";
    //}

    //protected void Linkbtnobtnmark_Click(object sender, System.EventArgs e)
    //{
    //    txtsmsstd.Text = txtsmsstd.Text + "< MARK >";
    //}


    //protected void Linkbtntestdt_Click(object sender, System.EventArgs e)
    //{
    //    txtsmsstd.Text = txtsmsstd.Text + "< TESTDATE >";
    //}

    //protected void Linkbtntestnm_Click(object sender, System.EventArgs e)
    //{
    //    txtsmsstd.Text = txtsmsstd.Text + "< TESTNAME >";
    //}

    //protected void Linkbtnperctg_Click(object sender, System.EventArgs e)
    //{
    //    txtsmsstd.Text = txtsmsstd.Text + "< PERCENTAGE >";
    //}
}