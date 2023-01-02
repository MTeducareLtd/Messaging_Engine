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
using System.Net.Mail;
using System.Net;

public partial class Customize_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Clear_Error_Success_Box();
            Msg_Info.Visible = true;
            lblInfo.Text = "Enter multiple EmailId's seperated by (,) comma";
        }

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

            if (txtEmailId.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Email Id");
                txtEmailId.Focus();
                return;
            }

            if (txtEmailId.Text.Trim().Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Email Id");
                txtEmailId.Focus();
                return;
            }


            if (txtSubject.Text == "")
            {
                Show_Error_Success_Box("E", "Enter Subject");
                txtEmailId.Focus();
                return;
            }

            if (txtSubject.Text.Trim().Length == 0)
            {
                Show_Error_Success_Box("E", "Enter Subject");
                txtEmailId.Focus();
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

            int resultid = 0, count = 0;

            string strEmailIds = txtEmailId.Text.Trim();
            string[] strEmailArray = strEmailIds.Split(',');

            string[] distinctArray = RemoveDuplicates(strEmailArray);

            HttpCookie cookie = Request.Cookies.Get("MyCookiesLoginInfo");
            string UserID = cookie.Values["UserID"];

            string strFileName = "";
            string Att_Name = "";

            MailMessage Msg = new MailMessage();
            




            foreach (string MailId in distinctArray)
            {
                string userid = "", Password = "", Host = "", SSL = "", MailType = "";
                int Port = 0;
                DataSet dsCRoom = ProductController.GetMailDetails_ByCenter("Promotional");


                if (dsCRoom.Tables[0].Rows.Count > 0)
                {

                    userid = Convert.ToString(dsCRoom.Tables[0].Rows[0]["UserId"]);
                    Password = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Password"]);
                    Host = Convert.ToString(dsCRoom.Tables[0].Rows[0]["Host"]);
                    Port = Convert.ToInt32(Convert.ToString(dsCRoom.Tables[0].Rows[0]["Port"]));
                    SSL = Convert.ToString(dsCRoom.Tables[0].Rows[0]["EnableSSl"]);
                    MailType = Convert.ToString(dsCRoom.Tables[0].Rows[0]["MailType"]);

                    //////
                    try
                    {
                        Msg = new MailMessage(userid, MailId);


                        if (txtAttachment.PostedFile != null)
                        {
                            try
                            {
                                strFileName = System.IO.Path.GetFileName(txtAttachment.PostedFile.FileName);
                                //Attachment attachFile =new Attachment(txtAttachment.PostedFile.InputStream, strFileName);
                                //mm.Attachments.Add(attachFile);
                            }
                            catch
                            {

                            }
                        }


                        if (strFileName.Length == 0)
                        {
                        }
                        else
                        {
                            Att_Name = strFileName;
                            Msg.Attachments.Add(new Attachment(txtAttachment.PostedFile.InputStream, Att_Name));

                        }

                    }
                    catch (Exception ex)
                    {
                    }


                    string CurTimeFrame = null;
                    CurTimeFrame = System.DateTime.Now.ToString("ddMMyyyyhhmmss");

                    // Subject of e-mail
                    Msg.Subject = txtSubject.Text.Trim();
                    Msg.Body += txtMessage.Text.Trim();



                    Msg.IsBodyHtml = true;


                    bool value = System.Convert.ToBoolean(SSL);
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = Host;
                    smtp.EnableSsl = value;
                    NetworkCredential NetworkCred = new NetworkCredential(userid, Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = Port;

                    int resultid1 = 0;
                    try
                    {
                        smtp.Timeout = 20000;
                        smtp.Send(Msg);
                        
                        txtAttachment.PostedFile.InputStream.Position = 0;
                        resultid = ProductController.Insert_Mailog(MailId, Msg.Subject.ToString().Trim(), Msg.Body.ToString().Trim(), 1, Att_Name, "1", UserID, 1, "General Email", MailType);
                        count = count + 1;
                    }
                    catch (Exception ex)
                    {
                        resultid = ProductController.Insert_Mailog(MailId, Msg.Subject.ToString().Trim(), Msg.Body.ToString().Trim(), 1, Att_Name, "2", UserID, 1, "General Email", MailType);
                    }


                    //
                }
                else
                {

                }
            }

            if (count > 0)
            {
                Msg_Error.Visible = false;
                Msg_Success.Visible = true;
                lblSuccess.Text = count + " Email Sent Successfully!!";
                Clear_Field();
            }

        }
        catch (Exception ex)
        {
            Msg_Error.Visible = true;
            Msg_Success.Visible = false;
            lblerror.Text = "Please enter correct EmailId";
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
        Clear_Error_Success_Box();
    }


    private void Clear_Field()
    {
        txtEmailId.Text = "";
        txtSubject.Text = "";
        txtMessage.Text = "";
    }



}