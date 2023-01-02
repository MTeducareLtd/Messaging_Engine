using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShoppingCart.BL;
using System.IO;
using System.Drawing;

public partial class Master_Notification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //Page_Validation();
            ControlVisibility("Search");
            ddladdnotificationtype.Items.Insert(0, "Select");
            ddladdnotificationtype.Items.Insert(1, "Manual");
            ddladdnotificationtype.Items.Insert(2, "Link");

            ddlsearchnotificationtype.Items.Insert(0, "Select");
            ddlsearchnotificationtype.Items.Insert(1, "Manual");
            ddlsearchnotificationtype.Items.Insert(2, "Link");


            ddladdsendinglevel.Items.Insert(0, "Select");
            ddladdsendinglevel.Items.Insert(1, "Company");
            ddladdsendinglevel.Items.Insert(2, "Acad Year");
            ddladdsendinglevel.Items.Insert(3, "Division");
            ddladdsendinglevel.Items.Insert(4, "Center");
            ddladdsendinglevel.Items.Insert(5, "Batch");
            ddladdsendinglevel.Items.Insert(6, "Student");


            ddlsearchsendinglevel.Items.Insert(0, "Select");
            ddlsearchsendinglevel.Items.Insert(1, "Company");
            ddlsearchsendinglevel.Items.Insert(2, "Acad Year");
            ddlsearchsendinglevel.Items.Insert(3, "Division");
            ddlsearchsendinglevel.Items.Insert(4, "Center");
            ddlsearchsendinglevel.Items.Insert(5, "Batch");
            ddlsearchsendinglevel.Items.Insert(6, "Student");

            FillDDL_AcadYear();
        }
    }

    private void ControlVisibility(string Mode)
    {
        Clear_Error_Success_Box();
        if (Mode == "Search")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = true;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = false;

        }
        else if (Mode == "Result")
        {
            DivAddPanel.Visible = false;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = true;
            DivResultPanel.Visible = true;

        }
        else if (Mode == "Add")
        {
            DivAddPanel.Visible = true;
            DivSearchPanel.Visible = false;
            BtnAdd.Visible = false;
            DivResultPanel.Visible = false;
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
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Add");

    }
    protected void ddladdsendinglevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (ddladdsendinglevel.SelectedIndex == 0)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tdacadyear.Visible = false;
            tdacadyear1.Visible = false;

            //tr3.Visible = false;
        }

        if (ddladdsendinglevel.SelectedIndex == 1)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            tdacadyear.Visible = false;
            tdacadyear1.Visible = false;
            //tr3.Visible = false;
        }

        if (ddladdsendinglevel.SelectedIndex == 2)
        {
            tr1.Visible = false;
            tr2.Visible = false;
            //tr3.Visible = false;
            tdacadyear.Visible = true;
            tdacadyear1.Visible = true;
        }

        if (ddladdsendinglevel.SelectedIndex == 3)
        {
            tr1.Visible = true;
            tr2.Visible = false;
            //tr3.Visible = false;
            tdacadyear.Visible = true;
            tdacadyear1.Visible = true;
            tddivision.Visible = true;
            tddivision1.Visible = true;
            tdcenter.Visible = false;
            tdcenter1.Visible = false;
            tdbatch.Visible = false;
            tdbatch1.Visible = false;
        }

        if (ddladdsendinglevel.SelectedIndex == 4)
        {
            tr1.Visible = true;
            tr2.Visible = false;
            //tr3.Visible = false;
            tdacadyear.Visible = true;
            tdacadyear1.Visible = true;
            tddivision.Visible = true;
            tddivision1.Visible = true;
            tdcenter.Visible = true;
            tdcenter1.Visible = true;
            tdbatch.Visible = false;
            tdbatch1.Visible = false;
        }

        if (ddladdsendinglevel.SelectedIndex == 5)
        {
            tr1.Visible = true;
            tr2.Visible = false;
            //tr3.Visible = false;
            tdacadyear.Visible = true;
            tdacadyear1.Visible = true;
            tddivision.Visible = true;
            tddivision1.Visible = true;
            tdcenter.Visible = true;
            tdcenter1.Visible = true;
            tdbatch.Visible = true;
            tdbatch1.Visible = true;

        }

        if (ddladdsendinglevel.SelectedIndex == 6)
        {
            tr1.Visible = true;
            tr2.Visible = true;
            //tr3.Visible = false;
            tdacadyear.Visible = true;
            tdacadyear1.Visible = true;
            tddivision.Visible = true;
            tddivision1.Visible = true;
            tdcenter.Visible = true;
            tdcenter1.Visible = true;
            tdbatch.Visible = true;
            tdbatch1.Visible = true;
            tdstudent.Visible = true;
            tdstudent1.Visible = true;

        }
    }

    private void FillDDL_AcadYear()
    {
        try
        {
            DataSet dsAcadYear = SIP_Controller.GetAllActiveUser_AcadYear();
            BindDDL(ddladdacadyear, dsAcadYear.Tables[0], "Description", "Id");
            ddladdacadyear.Items.Insert(0, "Select");
            ddladdacadyear.SelectedIndex = 0;
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



    protected void ddladdnotificationtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        if (ddladdnotificationtype.SelectedIndex == 2)
        {

            tdurlheader.Visible = true;
            tdurlheader1.Visible = true;
        }

        else
        {

            tdurlheader.Visible = false;
            tdurlheader1.Visible = false;
        }
    }
    protected void ddladdacadyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        FillDDL_Division();
    }

    private void BindDDL(DropDownList ddl, DataTable dt, string txtField, string valField)
    {
        ddl.DataSource = dt;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
    }

    protected void FillDDL_Division()
    {
        try
        {

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            DataSet ds = SIP_Controller.GetAllActiveUser_Company_Division_Zone_Center(UserID, "MT", "", "", "2", "");
            BindDDL(ddladddivision, ds.Tables[0], "Division_Name", "Division_Code");
            ddladddivision.Items.Insert(0, "Select");
            ddladddivision.SelectedIndex = 0;
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
    protected void ddladddivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        FillDDL_Centre();
    }
    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        try
        {
            ddl.DataSource = ds;
            ddl.DataTextField = txtField;
            ddl.DataValueField = valField;
            ddl.DataBind();
        }
        catch (Exception ex)
        {

            Show_Error_Success_Box("E", ex.ToString());
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
    private void FillDDL_Centre()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        string UserID = cookie.Values["UserID"];

        string divisionCode = ddladddivision.SelectedValue;

        DataSet dsCentre = SIP_Controller.GetAllActiveUser_Company_Division_Zone_Center(UserID, "", divisionCode, "", "5", "");

        DataSet ds = new DataSet();


        BindListBox(lstaddcenter, dsCentre, "Center_Name", "Center_Code");


    }
    protected void lstaddcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        FillDDL_Batch();
    }

    private void FillDDL_Batch()
    {
        string divisionCode = ddladddivision.SelectedValue;
        //string centercode = ddlCenter.SelectedValue;

        string acadYr = ddladdacadyear.SelectedValue;



        string Center_Code = "";
        string Center_Name = "";
        int CenterCnt = 0;
        int CenterSelCnt = 0;

        for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
        {
            if (lstaddcenter.Items[CenterCnt].Selected == true)
            {
                Center_Code = Center_Code + lstaddcenter.Items[CenterCnt].Value + ",";
                //Center_Name = Center_Name + lstaddcenter.Items[CenterCnt].Text + ",";
            }
        }
        Center_Code = Common.RemoveComma(Center_Code);
        //Center_Name = Common.RemoveComma(Center_Name);

        DataSet ds = SIP_Controller.GetBatchByDivisionCenterAcadYr(divisionCode, Center_Code, acadYr);
        BindListBox(lstaddbatch, ds, "BatchName", "PKey");

    }

    protected void lstaddbatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
        FillStudent();
    }

    private void FillStudent()
    {
        try
        {
            string Center_Code = "";
            string Center_Name = "";
            int CenterCnt = 0;


            for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
            {
                if (lstaddcenter.Items[CenterCnt].Selected == true)
                {
                    Center_Code = Center_Code + lstaddcenter.Items[CenterCnt].Value + ",";
                    //Center_Name = Center_Name + lstaddcenter.Items[CenterCnt].Text + ",";
                }
            }
            Center_Code = Common.RemoveComma(Center_Code);



            string Batch_Code = "";

            int CenterCnt1 = 0;


            for (CenterCnt1 = 0; CenterCnt1 <= lstaddbatch.Items.Count - 1; CenterCnt1++)
            {
                if (lstaddbatch.Items[CenterCnt1].Selected == true)
                {
                    Batch_Code = Batch_Code + lstaddbatch.Items[CenterCnt1].Value + ",";
                    //Center_Name = Center_Name + lstaddcenter.Items[CenterCnt].Text + ",";
                }
            }
            Batch_Code = Common.RemoveComma(Batch_Code);

            DataSet ds = SIP_Controller.bindStudent(6, ddladdacadyear.SelectedValue, ddladddivision.SelectedValue, Center_Code, Batch_Code);

            BindListBox(lstaddstudents, ds, "Name", "StudentCode");


        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = ex.ToString();
        }
    }

    protected void BtnSaveAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddladdnotificationtype.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Notification Type");
                ddladdnotificationtype.Focus();
                return;
            }

            if (ddladdsendinglevel.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Sending Level");
                ddladdsendinglevel.Focus();
                return;
            }


            //for notificationtye manual and sending level company
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 1)
            {
                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }
                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", "", "", "", "", UserID, "", ddladdnotificationtype.SelectedValue, "");
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }

            //for notificationtye link and sending level company
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 1)
            {
                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }
                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", "", "", "", "", UserID, "", ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }

            //for notificationtye manual and sending level acad year
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 2)
            {

                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }
                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", "", "", "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, "");
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }



            //for notificationtye link and sending level acad year
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 2)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }




                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }
                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", "", "", "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }



            //for notificationtye manual and sending level division
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 3)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }
                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, "");
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }


            //for notificationtye link and sending level division
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 3)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }

                else
                {
                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());
                    if (ds.Tables[0].Rows[0]["ErrorSaveID"].ToString() == "1")
                    {
                        Show_Error_Success_Box("S", "Record Saved Sucessfully");
                    }
                    else
                    {
                        Show_Error_Success_Box("E", "Record Already Exists");
                    }

                    return;
                }
            }



            //for notificationtye manual and sending level center
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 4)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;




                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }



                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                else
                {
                    for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddcenter.Items[CenterCnt].Selected == true)
                        {
                            Center_Code = Center_Code + lstaddcenter.Items[CenterCnt].Value + ",";

                        }
                    }
                    Center_Code = Common.RemoveComma(Center_Code);








                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, Center_Code, "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, "");

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }




            //for notificationtye link and sending level center
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 4)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;




                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }



                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }

                else
                {
                    for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddcenter.Items[CenterCnt].Selected == true)
                        {
                            Center_Code = Center_Code + lstaddcenter.Items[CenterCnt].Value + ",";

                        }
                    }
                    Center_Code = Common.RemoveComma(Center_Code);








                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, Center_Code, "", "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }





            //for notificationtye manual and sending level batch
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 5)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;

                string Batch_Code = "";



                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }





                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }
                CenterCnt = 0;
                CenterSelCnt = 0;


                for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddbatch.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Batch");
                    lstaddbatch.Focus();
                    return;

                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                else
                {


                    for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddbatch.Items[CenterCnt].Selected == true)
                        {
                            Batch_Code = Batch_Code + lstaddbatch.Items[CenterCnt].Value + ",";

                        }
                    }
                    Batch_Code = Common.RemoveComma(Batch_Code);








                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", Batch_Code, "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, "");

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }


            //for notificationtye link and sending level batch
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 5)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;

                string Batch_Code = "";



                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }





                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }
                CenterCnt = 0;
                CenterSelCnt = 0;


                for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddbatch.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Batch");
                    lstaddbatch.Focus();
                    return;

                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }
                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }

                else
                {
                    for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddbatch.Items[CenterCnt].Selected == true)
                        {
                            Batch_Code = Batch_Code + lstaddbatch.Items[CenterCnt].Value + ",";

                        }
                    }
                    Batch_Code = Common.RemoveComma(Batch_Code);








                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", Batch_Code, "", UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }




            //for notificationtye manual and sending level student
            if (ddladdnotificationtype.SelectedIndex == 1 && ddladdsendinglevel.SelectedIndex == 6)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;

                string Batch_Code = "";
                string Student_Code = "";


                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }





                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }
                CenterCnt = 0;
                CenterSelCnt = 0;


                for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddbatch.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Batch");
                    lstaddbatch.Focus();
                    return;

                }




                CenterCnt = 0;
                CenterSelCnt = 0;


                for (CenterCnt = 0; CenterCnt <= lstaddstudents.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddstudents.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Student");
                    lstaddstudents.Focus();
                    return;

                }

                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }

                else
                {


                    for (CenterCnt = 0; CenterCnt <= lstaddstudents.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddstudents.Items[CenterCnt].Selected == true)
                        {
                            Student_Code = Student_Code + lstaddstudents.Items[CenterCnt].Value + ",";

                        }
                    }
                    Student_Code = Common.RemoveComma(Student_Code);








                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", "", Student_Code, UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, "");

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }





            //for notificationtye link and sending level student
            if (ddladdnotificationtype.SelectedIndex == 2 && ddladdsendinglevel.SelectedIndex == 6)
            {


                if (ddladdacadyear.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Acad Year");
                    ddladdacadyear.Focus();
                    return;
                }

                if (ddladddivision.SelectedIndex == 0)
                {
                    Show_Error_Success_Box("E", "Select Division");
                    ddladddivision.Focus();
                    return;
                }


                string Center_Code = "";

                int CenterCnt = 0;
                int CenterSelCnt = 0;

                string Batch_Code = "";



                for (CenterCnt = 0; CenterCnt <= lstaddcenter.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddcenter.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }





                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Center");
                    lstaddcenter.Focus();
                    return;

                }
                CenterCnt = 0;
                CenterSelCnt = 0;


                for (CenterCnt = 0; CenterCnt <= lstaddbatch.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddbatch.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Batch");
                    lstaddbatch.Focus();
                    return;

                }


                CenterCnt = 0;
                CenterSelCnt = 0;
                string Student_Code = "";

                for (CenterCnt = 0; CenterCnt <= lstaddstudents.Items.Count - 1; CenterCnt++)
                {
                    if (lstaddstudents.Items[CenterCnt].Selected == true)
                    {
                        CenterSelCnt = CenterSelCnt + 1;
                    }
                }


                if (CenterSelCnt == 0)
                {
                    //When all is selected   
                    Show_Error_Success_Box("E", "Select At Least One Student");
                    lstaddstudents.Focus();
                    return;

                }



                if (txtaddnotification.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Notification");
                    txtaddnotification.Focus();
                    return;
                }
                if (txtaddurlheader.Text.Trim() == "")
                {
                    Show_Error_Success_Box("E", "Enter Url Header");
                    txtaddurlheader.Focus();
                    return;
                }

                else
                {
                    for (CenterCnt = 0; CenterCnt <= lstaddstudents.Items.Count - 1; CenterCnt++)
                    {
                        if (lstaddstudents.Items[CenterCnt].Selected == true)
                        {
                            Student_Code = Student_Code + lstaddstudents.Items[CenterCnt].Value + ",";

                        }
                    }
                    Student_Code = Common.RemoveComma(Student_Code);







                    HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
                    string StudentID = cookie.Values["StudentID"];
                    string UserID = cookie.Values["UserID"];
                    DataSet ds = new DataSet();
                    ds = SIP_Controller.InsertNotification(1, txtaddnotification.Text.Trim(), ddladdsendinglevel.SelectedValue, "MT", ddladddivision.SelectedValue, "", "", Student_Code, UserID, ddladdacadyear.SelectedValue, ddladdnotificationtype.SelectedValue, txtaddurlheader.Text.Trim());

                    Show_Error_Success_Box("S", ds.Tables[0].Rows[0]["ErrorSaveLog"].ToString());


                    return;
                }
            }





        }
        catch (Exception ex)
        {
            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        lblSuccess.Text = "";
        lblerror.Text = "";
        UpdatePanelMsgBox.Update();
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            Clear_Error_Success_Box();
            if (id_date_range_picker_1.Value == "")
            {
                Show_Error_Success_Box("E", "Select Date Range");
                return;
            }

            if (ddlsearchsendinglevel.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Sending Level");
                ddlsearchsendinglevel.Focus();
                return;
            }
            string DateRange = "";
            DateRange = id_date_range_picker_1.Value;
            DateTime fromdate, todate;
            string From_Date = "";
            string To_Date = "";

            fromdate = Convert.ToDateTime(DateRange.Substring(0, 10));
            todate = Convert.ToDateTime(DateRange.Substring(DateRange.Length - 10));

            From_Date = fromdate.ToString("dd MMM yyyy");
            To_Date = todate.ToString("dd MMM yyyy");



            dlGridReport1.DataSource = null;
            dlGridReport1.DataBind();
            dlGridReport1.Columns.Clear();


            DataSet ds = new DataSet();
            ds = SIP_Controller.GetNotificationDetails(ddlsearchsendinglevel.SelectedIndex, ddlsearchnotificationtype.SelectedValue, From_Date, To_Date);
            int ColCnt = 0;
            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                //Declare the bound field and allocate memory for the bound field.
                BoundField bfield = new BoundField();

                //Initalize the DataField value.
                bfield.DataField = col.ColumnName;
                bfield.HeaderText = col.ColumnName;

                if (ColCnt == 0)
                {
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                    bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Left;
                    bfield.ItemStyle.Width = Unit.Pixel(390); //"390";
                }
                else
                {
                    bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
                    bfield.ItemStyle.Width = Unit.Pixel(80);// "80";
                }

                //Add the newly created bound field to the GridView.
                dlGridReport1.Columns.Add(bfield);
                ColCnt = ColCnt + 1;
            }

            //Initialize the DataSource

            dlGridReport1.DataSource = ds.Tables[0];

            //Bind the datatable with the GridView.
            dlGridReport1.DataBind();

            lbltotalcount.Text = Convert.ToString(dlGridReport1.Rows.Count);
            if (Convert.ToInt32(lbltotalcount.Text) > 0)
            {
                ControlVisibility("Result");
            }
            else
            {
                ControlVisibility("Search");
                Show_Error_Success_Box("E", "No Records Found");

            }
        }
        catch (Exception ex)
        {

            Show_Error_Success_Box("E", ex.ToString());
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void HLExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Notification"+DateTime.Now+".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            dlGridReport1.AllowPaging = false;
            //this.BindGrid();

            dlGridReport1.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in dlGridReport1.HeaderRow.Cells)
            {
                cell.BackColor = dlGridReport1.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in dlGridReport1.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = dlGridReport1.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = dlGridReport1.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            dlGridReport1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


    }
    protected void BtnShowSearchPanel_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }
    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        id_date_range_picker_1.Value = "";
        ddlsearchnotificationtype.SelectedIndex = 0;
        ddlsearchsendinglevel.SelectedIndex = 0;
    }
    protected void BtnCloseAdd_Click(object sender, EventArgs e)
    {
        ControlVisibility("Search");
    }
    protected void ddlsearchsendinglevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
    }
    protected void ddlsearchnotificationtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
    }
    protected void lstaddstudents_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear_Error_Success_Box();
    }
}