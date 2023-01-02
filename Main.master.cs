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

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {
            Generate_Menu();
            lblHeader_User_Name.Text = cookie.Values["UserName"];
        }
        else
        {
            Response.Redirect("Logout.aspx", false);
        }

    }
    protected void BtnLogOut_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
    }

    private void Generate_Menu()
    {
        HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
        Login_Service.LoginServiceSoapClient client = new Login_Service.LoginServiceSoapClient();
        if (Request.Cookies["MyCookiesLoginInfo"] != null)
        {

            DataTable dtApplicatUrl = new DataTable();
            //dtApplicatUrl = client.GetApplication_Url();

            //lblPath1.Text = dtApplicatUrl.Rows[0]["Homepage_Path"].ToString();
            //lblPath2.Text = dtApplicatUrl.Rows[1]["Homepage_Path"].ToString();
            //lblPath3.Text = dtApplicatUrl.Rows[2]["Homepage_Path"].ToString();
            //lblPath4.Text = dtApplicatUrl.Rows[3]["Homepage_Path"].ToString();
            //lblPath5.Text = dtApplicatUrl.Rows[4]["Homepage_Path"].ToString();
            //lblPath6.Text = dtApplicatUrl.Rows[5]["Homepage_Path"].ToString();

            string Userid = cookie.Values["UserID"];
            string lstr = "";
            lstr = Convert.ToString(("<ul class='nav nav-list'>"));
            DataTable dt = client.GetMenuList("1", Userid, "");
           
            
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                string Application_no = Convert.ToString(dt.Rows[i]["Application_No"]);
                if (Application_no=="05")
                {
                    lstr += Convert.ToString(("<li> <a href=' " + dt.Rows[i]["Menu_link"] + "'><i class='" + dt.Rows[i]["Menu_CSS"] + "'></i><span>"));
                    //lstr += Convert.ToString(("<li class=''> <a href='#' class='dropdown-toggle'><i class='" + dt.Rows[i]["Menu_CSS"] + "'></i><span>"));
                    lstr += (Convert.ToString(dt.Rows[i]["Menu_Name"]));
                    DataTable dt1 = client.GetMenuList("2", Userid, dt.Rows[i]["Menu_Code"].ToString());
                    if (dt1.Rows.Count > 0)
                    {
                        lstr += Convert.ToString(("</span><b class='arrow icon-angle-down'></b>"));
                        lstr += Convert.ToString(("</a><ul class='submenu'>"));
                        for (int j = 0; j <= dt1.Rows.Count - 1; j++)
                        {
                            lstr += Convert.ToString((((" <li><a href='") + dt1.Rows[j]["Menu_Link"] + "'><i></i>") + dt1.Rows[j]["Menu_Name"] + "</a>"));
                        }
                        lstr += Convert.ToString(("</ul></li>"));
                    }
                    lstr += Convert.ToString(("</span></a></li>"));
                    lblHeaderMenu.Text = lstr;
                }
            }
            lstr += Convert.ToString(("</ul>"));

        }

    }

    protected void btnShortCut_CMDM_Engine_ServerClick(object sender, System.EventArgs e)
    {
        string Path = lblPath1.Text.Trim();
        int lenPath = Path.Length;

        if (lenPath == 0)
        {
        }
        else
        {
            Response.Redirect(Path, false);
        }


    }

    protected void btnShortCut_Order_Engine_ServerClick(object sender, System.EventArgs e)
    {
        string Path = lblPath2.Text.Trim();
        int lenPath = Path.Length;

        if (lenPath == 0)
        {
        }
        else
        {
            Response.Redirect(Path, false);
        }
        //Response.Redirect(lblPath2.Text.Trim(), false);
    }

    protected void btnShortCut_Scheduling_Engine_ServerClick(object sender, System.EventArgs e)
    {
        string Path = lblPath3.Text.Trim();
        int lenPath = Path.Length;

        if (lenPath == 0)
        {
        }
        else
        {
            Response.Redirect(Path, false);
        }
        //Response.Redirect(lblPath3.Text.Trim(), false);
    }

    protected void btnShortCut_Test_Engine_ServerClick(object sender, System.EventArgs e)
    {
        string Path = lblPath4.Text.Trim();
        int lenPath = Path.Length;

        if (lenPath == 0)
        {
        }
        else
        {
            Response.Redirect(Path, false);
        }
        // Response.Redirect(lblPath4.Text.Trim(), false);
    }

    protected void btnShortCut_Messaging_Engine_ServerClick(object sender, System.EventArgs e)
    {
        string Path = lblPath5.Text.Trim();
        int lenPath = Path.Length;

        if (lenPath == 0)
        {
        }
        else
        {
            Response.Redirect(Path, false);
        }
        //Response.Redirect(lblPath5.Text.Trim(), false);
    }

    protected void btnShortCut_Engine_ServerClick(object sender, System.EventArgs e)
    {
        //Response.Redirect(lblPath5.Text.Trim(), false);
    }
}
