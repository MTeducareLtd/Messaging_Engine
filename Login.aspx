<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Login</title>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
    <meta content="" name="description"/>
    <meta content="" name="author"/>
    <meta name="MobileOptimized" content="320" />
    <link rel="shortcut icon" href="favicon.ico"/>
    <!-- basic styles -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <!-- page specific plugin styles -->
    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-responsive.min.css" />
    <!--[if lt IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
</head>
<!-- BEGIN BODY -->
<body class="login-layout">
    <form runat="server" id="frm1main">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>


    <div class="container-fluid" id="main-container">
        <div id="main-content">
            <div class="row-fluid">
                <div class="span12">
                    <div class="login-container">
                        <div class="row-fluid">
                            <div class="center">
                                <img src="images/logo.jpg" alt="MT Educare" />
                                <h4 class="blue">
                                    MT Educare - Messaging Engine
                                    <br />
                                    <asp:Label ID="Label4" Font-Size="X-Small" runat="server" Text="V1.0"></asp:Label>
                                </h4>
                            </div>
                        </div>
                        <div class="space-6">
                        </div>
                        <div class="row-fluid">
                            <div class="position-relative">
                                <div id="login-box" class="visible widget-box no-border">
                                    <div class="widget-body">
                                        <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="widget-main" id="LoginPanel" runat ="server">
                                                    <h4 class="header lighter bigger white">
                                                        <i class="icon-bookmark"></i> Please Enter Your Information</h4>
                                                    <div class="space-6">
                                                    </div>
                                                    <%--  <form runat= "server" id ="FormLogin">--%>
                                                    <fieldset>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <asp:TextBox ID="txtusername" runat="server" CssClass="span12" 
                                                                    placeholder="Username" onKeypress="if (event.keyCode &lt; 44 || event.keyCode &gt; 57 || event.keyCode==45 || event.keyCode==47) event.returnValue = false;"></asp:TextBox>
                                                                <i class="icon-user"></i></span>
                                                            <asp:RequiredFieldValidator ID="r2" ControlToValidate="txtusername" ForeColor="White" runat="server"
                                                            ValidationGroup="uservalidation" SetFocusOnError="True" ErrorMessage="Enter UserName" />
                                                        </label>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <input class="span12" type="password" autocomplete="off" 
                                                                    placeholder="Password" name="password" id="password" runat="server" />
                                                                <i class="icon-lock"></i></span>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="White" ControlToValidate="password"  runat="server"
                                                            ValidationGroup="uservalidation" SetFocusOnError="True" ErrorMessage="Enter Password" />
                                                        </label>
                                                        <div class="space">
                                                        </div>
                                                        <div class="row-fluid">
                                                            <!-- <label class="span8">
							                                    <input type="checkbox" /><span class="lbl"> Remember Me</span>
						                                    </label> -->
                                                            <asp:Button class="span6 btn-app btn btn-mini btn-warning" ID="btnsubmit" runat="server"
                                                                Text="Login" onclick="btnsubmit_ServerClick" ValidationGroup="uservalidation"/>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False"
                                                    ValidationGroup="uservalidation" ShowSummary="False" />
                                                        </div>
                                                    </fieldset>
                                                    <%--</form>--%>
                                                </div>
                                                <!--/widget-main-->
                                                <div class="widget-main" id="resetpassword" runat ="server">
                                                    <h4 class="header lighter bigger white">
                                                        <i class="icon-bookmark"></i> Please Reset Your Passowrd</h4>
                                                    <div class="space-6">
                                                    </div>
                                                    <%--  <form runat= "server" id ="FormLogin">--%>
                                                    <fieldset>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                <asp:TextBox ID="txtresetpassword" runat="server" CssClass="span12" TextMode="Password"></asp:TextBox>
                                                                
                                                        </label>
                                                        <label>
                                                            <span class="block input-icon input-icon-right">
                                                                
                                                        </label>
                                                        <div class="space">
                                                        </div>
                                                        <div class="row-fluid">
                                                            <!-- <label class="span8">
							                                    <input type="checkbox" /><span class="lbl"> Remember Me</span>
						                                    </label> -->
                                                            <asp:Button class="span6 btn-app btn btn-mini btn-warning" ID="btnreset" runat="server"
                                                                Text="Reset" onclick="btnreset_ServerClick"/>
                                                        </div>
                                                    </fieldset>
                                                    <%--</form>--%>
                                                </div>
                                                <div class="alert alert-error" id="diverror" visible="false" runat="server">
                                                    <button type="button" class="close" data-dismiss="alert">
                                                        <i class="icon-remove"></i>
                                                    </button>
                                                    <p>
                                                        <strong><i class="icon-remove"></i>Error!</strong>
                                                        <asp:Label ID="lblerrormsg" runat="server" Text="Label"></asp:Label>
                                                    </p>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                   

                                    </div>
                                    <!--/widget-body-->
                                </div>
                                <!--/login-box-->

                            </div>
                            <!--/position-relative-->

                                

                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
    </div>















    <!-- basic scripts -->
    <script src="assets/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.jQuery || document.write("<script src='assets/js/jquery-1.9.1.min.js'>\x3C/script>");
    </script>
    <!-- page specific plugin scripts -->
    <!-- inline scripts related to this page -->
    <script type="text/javascript">
        function show_box(id) {
            $('.widget-box.visible').removeClass('visible');
            $('#' + id).addClass('visible');
        }
    </script>
    </form>
</body>
</html>
