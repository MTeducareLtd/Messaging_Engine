using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Net.Mail;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!IsPostBack)
        {
            diverror.Visible = false;
            LoginPanel.Visible = true;
            resetpassword.Visible = false;
        }
    }
    protected void btnreset_ServerClick(object sender, EventArgs e)
    {
            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];
            string UserName = cookie.Values["UserName"];
            string newpassword = txtresetpassword.Text;
            AccountController.Resetpassword(UserID, newpassword);
            LoginPanel.Visible = true;
            resetpassword.Visible = false; 
     
    }


    protected void btnsubmit_ServerClick(object sender, EventArgs e)
    {
        Login_Service.LoginServiceSoapClient client = new Login_Service.LoginServiceSoapClient();
        try
        {
            HttpCookie LoginInfo = new HttpCookie("MyCookiesLoginInfo");
            string Username = txtusername.Text;
            string password = Request.Form["password"];
            resetpassword.Visible = false;
            if (!string.IsNullOrEmpty(Username))
            {
                if (!String.IsNullOrEmpty(password))
                {
                    object obj = client.ValidateUser(Username, password, "01");
                    Login_Service.LoginData Login = (Login_Service.LoginData)obj;
                    String ReturnMessage = Login.Message;
                    String Displayname = Login.DisplayName;
                    String passwordreset = Login.Passwordreset;
                    String userid = Login.UserId ;
                    if (ReturnMessage == "Success")
                    {

                        string role = client.CheckUserRole(Login.UserId);
                        //Response.Redirect("Homepage.aspx",false );
                        if (!string.IsNullOrEmpty(role))
                        {
                            if (passwordreset == "0")
                            {
                                LoginPanel.Visible = false;
                                resetpassword.Visible = true;
                                LoginInfo["UserID"] = userid;
                                LoginInfo["UserName"] = Displayname;
                                LoginInfo["Expired"] = "1Day";
                                string user_id = userid;
                                Response.Cookies.Add(LoginInfo);
                                LoginInfo.Expires = DateTime.Now.AddDays(1);
                            }
                            else
                            {
                                LoginPanel.Visible = true;
                                resetpassword.Visible = false;
                                LoginInfo["UserID"] = userid;
                                LoginInfo["UserName"] = Displayname;
                                LoginInfo["Expired"] = "1Day";
                                string user_id = userid;
                                Response.Cookies.Add(LoginInfo);
                                LoginInfo.Expires = DateTime.Now.AddDays(1);
                                //string Ip = GetIpAddress();
                                //string Compcode = GetCompCode();
                                string Browser = Request.Browser.Browser ;
                                string Browser_version = Request.Browser.Version;
                                //UserController.Insertapplog(userid, "Login", "Successful Logged In", Ip, Compcode,Browser ,Browser_version );
                                Response.Redirect("~/Homepage.aspx", false);
                            }
                        }
                        else 
                        {
                            diverror.Visible = true;
                            LoginPanel.Visible = true;
                            resetpassword.Visible = false; 
                            lblerrormsg.Text = "Role Not Assigned. Contact Administrator";

                        }
                    }
                    else
                    {
                        diverror.Visible = true;
                        LoginPanel.Visible = true;
                        resetpassword.Visible = false; 
                        lblerrormsg.Text = "Invalid Username or Password";

                    }
                       
                }
            }
              
        }
        catch (Exception Ex)
        {
            diverror.Visible = true;
            LoginPanel.Visible = true;
            resetpassword.Visible = false;
            lblerrormsg.Text = "Connection Unavailable";
        }
    }

    public class LoginData
    {
        public bool IsValid { get; set; }
        public string SessionId { get; set; }
        public List<string> MenuName { get; set; }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string Passwordreset { get; set; }
    }


    protected void btnback_ServerClick(object sender, System.EventArgs e)
    {
        Response.Redirect("login.aspx");
    }

    public static string GetIpAddress()
    {
        // Get IP Address
        string ip = "";
        IPHostEntry ipEntry = Dns.GetHostEntry(GetCompCode());
        IPAddress[] addr = ipEntry.AddressList;
        ip = addr[2].ToString();
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