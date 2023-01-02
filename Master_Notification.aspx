<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Master_Notification.aspx.cs" Inherits="Master_Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">Notification Master<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search">
            <!-- /btn-group -->
            <asp:Button class="btn  btn-app btn-success btn-mini radius-4" runat="server" ID="BtnAdd"
                Text="Add" OnClick="BtnAdd_Click" />
            <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true"
                runat="server" ID="BtnShowSearchPanel" Text="Search" OnClick="BtnShowSearchPanel_Click" />
        </div>
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
                </ContentTemplate>
            </asp:UpdatePanel>

            <div id="DivSearchPanel" runat="server">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5>Search Options
                        </h5>
                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelSearch" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">
                                            <tr>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none;" class="table-hover" width="100%">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label9" CssClass="red">Period</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <input readonly="readonly" runat="server" class="id_date_range_picker_1 span10" name="date-range-picker"
                                                                    id="id_date_range_picker_1" width="14%" placeholder="Date Search" data-placement="bottom"
                                                                    data-original-title="Date Range" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 122%;"
                                                        class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label10" CssClass="red">Sending Level</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlsearchsendinglevel" Width="215px" ToolTip="Sending Level"
                                                                    data-placeholder="Select Sending Level" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchsendinglevel_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span4" style="text-align: left">
                                                    <table cellpadding="0" style="border-style: none; width: 122%;"
                                                        class="table-hover">
                                                        <tr>
                                                            <td style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label runat="server" ID="Label6">Notification Type</asp:Label>
                                                            </td>
                                                            <td style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddlsearchnotificationtype" Width="215px" ToolTip="Notification Type"
                                                                    data-placeholder="Select Notification Type" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddlsearchnotificationtype_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="widget-main alert-block alert-info" style="text-align: center;">
                                <!--Button Area -->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="BtnSearch"
                                    Text="Search" ToolTip="Search" ValidationGroup="UcValidateSearch" OnClick="BtnSearch_Click" />
                                <asp:Button class="btn btn-app btn-grey btn-mini radius-4" ID="BtnClearSearch" Visible="true"
                                    runat="server" Text="Clear" OnClick="BtnClearSearch_Click" />
                                <asp:ValidationSummary ID="ValidationSummary2" ShowSummary="false" DisplayMode="List"
                                    ShowMessageBox="true" ValidationGroup="UcValidateSearch" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivResultPanel" runat="server" class="dataTables_wrapper" visible="false">
                <div class="widget-box">
                    <div class="table-header">
                        <table width="100%">
                            <tr>
                                <td class="span10">Total No of Records:
                            <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                </td>
                                <td style="text-align: right" class="span2">
                                    <asp:LinkButton runat="server" ID="HLExport" ToolTip="Export" class="btn-small btn-danger icon-2x icon-download-alt"
                                                Height="25px" OnClick="HLExport_Click"  />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="DivResult_MCQ" runat="server" style="overflow-x: scroll; overflow-y: auto">
                    <asp:GridView ID="dlGridReport1" runat="server" AutoGenerateColumns="False" Width="100%">
                        <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <RowStyle HorizontalAlign="Left"></RowStyle>

                    </asp:GridView>
                </div>
            </div>
            <div id="DivAddPanel" runat="server" visible="false">
                <div class="widget-box">
                    <div class="widget-header widget-header-small header-color-dark">
                        <h5 class="modal-title">Add Notification
                            <asp:Label runat="server" ID="lblPkey" Visible="false"></asp:Label>
                        </h5>

                    </div>
                    <div class="widget-body">
                        <div class="widget-body-inner">
                            <div class="widget-main">
                                <asp:UpdatePanel ID="UpdatePanelAdd" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table cellpadding="3" class="table table-striped table-bordered table-condensed">

                                            <tr>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label22" runat="server" CssClass="red">Notification Type</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddladdnotificationtype" Width="215px" ToolTip="Notification Type"
                                                                    data-placeholder="Select Notification Type" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddladdnotificationtype_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label1" runat="server" CssClass="red">Sending Level</asp:Label>
                                                            </td>
                                                            <td class="span4" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddladdsendinglevel" Width="215px" ToolTip="Sending Level"
                                                                    data-placeholder="Select Sending Level" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddladdsendinglevel_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdacadyear" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label2" runat="server" CssClass="red">Acad Year</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdacadyear1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddladdacadyear" Width="215px" ToolTip="Acad Year"
                                                                    data-placeholder="Select Acad Year" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddladdacadyear_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server" visible="false">

                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tddivision" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label3" runat="server" CssClass="red">Division</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tddivision1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:DropDownList runat="server" ID="ddladddivision" Width="215px" ToolTip="Division"
                                                                    data-placeholder="Select Division" CssClass="chzn-select" AutoPostBack="True" OnSelectedIndexChanged="ddladddivision_SelectedIndexChanged" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdcenter" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label4" runat="server" CssClass="red">Center</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdcenter1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="lstaddcenter" data-placeholder="Select Center(s)" Width="215px"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lstaddcenter_SelectedIndexChanged"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdbatch" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label5" runat="server" CssClass="red">Batch</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdbatch1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="lstaddbatch" data-placeholder="Select Batch(es)" Width="215px"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lstaddbatch_SelectedIndexChanged"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr id="tr2" runat="server" visible="false">

                                                <td class="span6" style="text-align: left">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdstudent" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label7" runat="server" CssClass="red">Student</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdstudent1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:ListBox runat="server" ID="lstaddstudents" data-placeholder="Select Student(s)" Width="215px"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lstaddstudents_SelectedIndexChanged"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>


                                                <td class="span6" style="text-align: left"></td>

                                                <td class="span6" style="text-align: left"></td>
                                            </tr>



                                            <tr id="tr3" runat="server" visible="true">


                                                <td class="span6" style="text-align: left" colspan="2">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdnotification" runat="server" visible="true" style="border-style: none; text-align: left; width: 17%;">
                                                                <asp:Label ID="lblnotification" runat="server" CssClass="red">Notification</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdnotification1" runat="server" visible="true" style="border-style: none; text-align: left; width: 70%;">
                                                                <asp:TextBox ID="txtaddnotification" runat="server" Text="" Width="571px" TextMode="MultiLine" Height="140px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="span6" style="text-align: left" colspan="1">
                                                    <table cellpadding="0" class="table-hover" style="border-style: none;"
                                                        width="100%">
                                                        <tr>
                                                            <td class="span2" id="tdurlheader" runat="server" visible="false" style="border-style: none; text-align: left; width: 40%;">
                                                                <asp:Label ID="Label8" runat="server" CssClass="red">Url Header</asp:Label>
                                                            </td>
                                                            <td class="span4" id="tdurlheader1" runat="server" visible="false" style="border-style: none; text-align: left; width: 60%;">
                                                                <asp:TextBox ID="txtaddurlheader" runat="server" Text="" Width="205px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>


                                            </tr>

                                        </table>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="widget-main alert-block alert-success  alert- " style="text-align: center;">
                            <!--Button Area -->
                            <asp:Label runat="server" ID="lblErrorBatch" Text="" ForeColor="Red" />
                            <asp:Button class="btn btn-app btn-success btn-mini radius-4" ID="BtnSaveAdd" runat="server"
                                Text="Save" ValidationGroup="UcValidate" OnClick="BtnSaveAdd_Click" />
                            <asp:Button class="btn btn-app btn-primary btn-mini radius-4" ID="BtnCloseAdd" Visible="true"
                                runat="server" Text="Close" OnClick="BtnCloseAdd_Click" />
                            <asp:ValidationSummary ID="ValidationSummary3" ShowSummary="false" DisplayMode="List"
                                ShowMessageBox="true" ValidationGroup="UcValidate" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>

