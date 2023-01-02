<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="General_Email.aspx.cs" Inherits="Customize_SMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">

   
    function NumberandCommaOnly() {
        var AsciiValue = event.keyCode
        if ((AsciiValue >= 48 && AsciiValue <= 57) || AsciiValue == 44)
            event.returnValue = true;
        else
            event.returnValue = false;
    }

    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="#">Home</a><span class="divider"><i class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    General EMail<span class="divider"></span></h4>
            </li>
        </ul>
        
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <!--/page-header-->
        <div class="row-fluid">
            <!-- -->
            <!-- PAGE CONTENT BEGINS HERE -->
            <asp:UpdatePanel ID="UpdatePanelMsgBox" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="alert alert-block alert-success" id="Msg_Success" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-ok"></i></strong>
                            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                    <div class="alert alert-error" id="Msg_Error" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-remove"></i>Error!</strong>
                            <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>

                    <div class="alert alert-info" id="Msg_Info" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-info-sign"></i> Note !</strong>
                            <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
                        </p>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 >
                            Add Details
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate><center >
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span6" style="text-align: left" colspan="2">
                                                    <asp:Label runat="server" Text="Enter EMail ID's" Font-Bold="True" />
                                                    <span class="help-button ace-popover"
                                                     data-trigger="hover" data-placement="right" data-content="Enter multiple email id's seperated by (,) comma"
                                                                                title="Help">?</span>
                                                    <br />
                                                    <asp:TextBox ID="txtEmailId" runat="server" TextMode="MultiLine" 
                                                        Height="104px" class="span12"
                                                          Width="923px"></asp:TextBox>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td style="width: 160px" class="input-medium">
                                                <asp:Label ID="Label2" runat="server" Text="Subject " Font-Bold="True" /></td>
                                                <td>
                                                <asp:TextBox ID="txtSubject" runat="server" 
                                                             class="span12"
                                                             Width="755px"></asp:TextBox>
                                                </td>
                                            
                                            </tr>
                                            <tr>
                                                <td style="width: 160px" class="input-medium">
                                                    <asp:Label ID="Label3" runat="server" Text="Attachment " Font-Bold="True" />&nbsp
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="txtAttachment" runat="server" Width="278px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="span6" style="text-align: left" colspan="2">
                                                <asp:Label ID="Label1" runat="server" Text="Enter Your Message Here" 
                                                        Font-Bold="True" />
                                                    <br />
                                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="213px" 
                                                        class="autosize-transition span12" Width="924px"
                                                        ></asp:TextBox>
                                                </td>
                                                
                                        </table>
                                        </center>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-success btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Send" ToolTip="Search" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <%--<asp:Button class="btn btn-app btn-danger btn-mini radius-4" ID="Button1" Visible="true"
                                    runat="server" Text="Close" OnClick="BtnClearSearch_Click" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
        <!--/row-->
    </div>
</asp:Content>

