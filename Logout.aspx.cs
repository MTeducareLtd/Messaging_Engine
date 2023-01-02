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
using System.Net;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string Ip = GetIpAddress();
            string Compcode = GetCompCode();
            string Browser = Request.Browser.Browser;
            string Browser_version = Request.Browser.Version;
            //UserController.Insertapplog(UserID, "Logout", "Successful Logged Out", Ip, Compcode, Browser, Browser_version);
                                
            Response.Cookies.Clear();
            Request.Cookies.Get("MyCookiesLoginInfo").Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Get("MyCookiesLoginInfo").Expires = DateTime.Now.AddDays(-1);
            Session.Abandon();
            Session.RemoveAll();


            Response.Redirect("login.aspx");
        }

    }


    public static string GetIpAddress()
    {
        // Get IP Address
        string ip = "";
        IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
        IPAddress[] addr = ipEntry.AddressList;
        ip = addr[1].ToString();
        return ip;
    }
    public static string GetCompCode()
    {
        // Get Computer Name
        string strHostName = "";
        strHostName = Dns.GetHostName();
        return strHostName;
    }

}