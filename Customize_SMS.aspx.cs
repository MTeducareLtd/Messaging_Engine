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

public partial class Customize_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Clear_Error_Success_Box();
            Msg_Info.Visible = true;
            lblInfo.Text = "Enter 10 digit phone no(s) seperated by (,) comma";
            BindSmsCategory();
        }

    }

    private void BindListBox(ListBox ddl, DataSet ds, string txtField, string valField)
    {
        ddl.DataSource = ds;
        ddl.DataTextField = txtField;
        ddl.DataValueField = valField;
        ddl.DataBind();
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
    private void Clear_Error_Success_Box()
    {
        Msg_Error.Visible = false;
        Msg_Success.Visible = false;
        Msg_Info.Visible = false;
        lblInfo.Text = "";
        lblSuccess.Text = "";
        lblerror.Text = "";
        lblSuccess.Text = "";
        UpdatePanelMsgBox.Update();
    }
    private void ControlVisibility(string Mode)
    {
        if (Mode == "Search")
        {
            
            DivSearchPanel.Visible = true;
            
            
        }
        
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtMobileNo.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Mobile No");
                txtMobileNo.Focus();
                return;
            }

            if (txtMobileNo.Text.Trim().Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Mobile No");
                txtMobileNo.Focus();
                return;
            }

            if (txtMessage.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Message");
                txtMessage.Focus();
                return;
            }

            if (txtMessage.Text.Trim().Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Message");
                txtMessage.Focus();
                return;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                Show_Error_Success_Box("E", "Select Category");
                
                return;
            }

            int resultid = 0,count=0;

            string strMobileNo = txtMobileNo.Text.Trim();
            string[] strMobNoArray = strMobileNo.Split(',');

            string[] distinctArray = RemoveDuplicates(strMobNoArray);

            string Message = txtMessage.Text.Trim();
            string AltMessage = Message.Replace("&", "%26").Replace("+", "%2D").Replace("%", "%25").Replace("#", "%23").Replace("=", "%3D").Replace("^", "%5E").Replace("~", "%7E"); 


            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string Category = ddlCategory.SelectedValue;


            foreach (string MobNum in distinctArray)
            {
                if (MobNum.Length == 10)
                {
                    resultid = ProductController.Insert_SMSLog("General SMS", "008", MobNum, AltMessage, "0", UserID, "Promotional", Category, 7);
                    count = count + 1;
                }
                else
                {
                    resultid = ProductController.Insert_SMSLog("General SMS", "008", MobNum, AltMessage, "11", UserID, "Promotional", Category, 7);
                }
            }

            if (count > 0)
            {
                Msg_Error.Visible = false;
                Msg_Success.Visible = true;
                lblSuccess.Text = "Message Sent Successfully!!";
                Clear_Field();
            }

        }
        catch (Exception ex)
        {
        }
                
    }

    public string[] RemoveDuplicates(string[] inputArray)
    {

        int length = inputArray.Length;
        for (int i = 0; i < length; i++)
        {
            for (int j = (i + 1); j < length; )
            {
                if (inputArray[i] == inputArray[j])
                {
                    for (int k = j; k < length - 1; k++)
                        inputArray[k] = inputArray[k + 1];
                    length--;
                }
                else
                    j++;
            }
        }

        string[] distinctArray = new string[length];
        for (int i = 0; i < length; i++)
            distinctArray[i] = inputArray[i];

        return distinctArray;

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


    

    protected void BtnClearSearch_Click(object sender, EventArgs e)
    {
        Clear_Field();
        
    }
    

    private void Clear_Field()
    {
        txtMobileNo.Text = "";
        txtMessage.Text = "";
    }

   
   
}