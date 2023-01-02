<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeFile="UserDashBoard.aspx.cs" Inherits="UserDashBoard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="breadcrumbs" class="position-relative" style="height: 53px">
        <ul class="breadcrumb" style="height: 15px">
            <li><i class="icon-home"></i><a href="UserDashboard.aspx">Home</a><span class="divider"><i
                class="icon-angle-right"></i></span></li>
            <li>
                <h4 class="blue">
                    Dashboard<span class="divider"></span></h4>
            </li>
        </ul>
        <div id="nav-search" class="middle">
            <asp:Label ID="lblReportPeriod" runat="server"></asp:Label>
        </div>
        <!--#nav-search-->
    </div>
    <div id="page-content" class="clearfix">
        <asp:Panel ID="pnlTemp" runat="server" Visible="true">
            <div class="space-6">
            </div>
            <asp:UpdatePanel ID="UpdatePanel_CentreDashboard" runat="server">
                <ContentTemplate>
                    <div class="row-fluid span12" style="margin-left :218px">
                        
                        <button id="btn_PreviousCentre" runat="server" class="btn btn-mini btn-grey radius-4"
                            data-rel="tooltip" data-placement="top" title="previous centre" onserverclick="btn_PreviousCentre_ServerClick">
                            <i class="icon-chevron-left icon-2x icon-only"></i>
                        </button>
                        <button id="btn_NextCentre" runat="server" class="btn btn-mini btn-grey radius-4"
                            data-rel="tooltip" data-placement="top" title="next centre" onserverclick="btn_NextCentre_ServerClick">
                            <i class="icon-chevron-right icon-2x icon-only"></i>
                        </button>
                        <small>Centre:
                            <asp:Label ID="lblCentreDashboard_CentreName" runat="server"></asp:Label></small>
                        <asp:Label ID="lblCentreDashboard_CentreNumber" runat="server" Visible="false"></asp:Label></small>
                    </div>
                    <div class="space-6">
                    </div>
                    <div class="row-fluid">
                        <div class="span12 infobox-container">
                            <div class="infobox infobox-green">
                                <div class="infobox-icon">
                                    <i class="icon-envelope-alt"></i>
                                </div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">
                                        <asp:Label ID="lblCentreDashboard_PendingSMSCount" runat="server" Text ="0"></asp:Label></span>
                                    <span class="infobox-content">Pending SMS</span>
                                </div>
                                
                            </div>
                            <div class="infobox infobox-blue">
                                <div class="infobox-icon">
                                    <i class="icon-envelope"></i>
                                </div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">
                                        <asp:Label ID="lblCentreDashboard_SentSMSCount" runat="server" Text="0"></asp:Label></span>
                                    <span class="infobox-content">Sent SMS</span>
                                </div>
                                
                            </div>
                            <div class="infobox infobox-orange">
                                <div class="infobox-icon">
                                    <i class="icon-folder-close"></i>
                                </div>
                                <div class="infobox-data">
                                <span class="infobox-data-number">
                                        <asp:Label ID="lblpendingEmails_Count" runat="server" Text ="0"></asp:Label></span>
                                    <span class="infobox-data-number"></span> <span class="infobox-content">Pending EMail</span>
                                </div>
                                
                            </div>
                            <div class="infobox infobox-red">
                                <div class="infobox-icon">
                                    <%--<i class="icon-check"></i>--%>
                                    <i class="icon-folder-close-alt"></i>
                                </div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number">
                                        <asp:Label ID="lblSentEmails_Count" runat="server" Text ="0"></asp:Label></span>
                                    <span class="infobox-content">Sent Email</span>
                                </div>
                                
                            </div>
                            <%--<div class="infobox infobox-pink">
                                <div class="infobox-icon">
                                   
                                    <i class="icon-bell"></i>
                                </div>
                                <div class="infobox-data">
                                    <span class="infobox-data-number"><asp:Label ID="lbltodayslectures" runat="server" Text ="0"></asp:Label></span> 
                                    <span class="infobox-content">Todays Lectures</span>
                                </div>
                            </div>--%>
                            
                                                        
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="hr hr32 hr-dotted">
            </div>
        </asp:Panel>
        <div class="row-fluid">
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="lighter">
                            <i class="icon-bullhorn green"></i>Divisionwise SMS Summary</h4>
                        <div class="widget-toolbar">
                            <a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                            <asp:DataList ID="dlGrid_CentreAbsent" CssClass="table table-bordered table-striped"
                                runat="server" Width="100%">
                                <HeaderTemplate>
                                    <b><span class="green" style="vertical-align: middle; text-align: left"><i class="icon-caret-right blue">
                                    </i>Division Name</span></b> </th>
                                    <th class="green" style="width: 25%; text-align: center; vertical-align: middle;">
                                        Message Type
                                    </th>
                                    <th class="green" style="width: 15%; text-align: center; vertical-align: middle;">
                                        Message Sent
                                    </th>
                                    <th class="green" style="width: 15%; text-align: center; vertical-align: middle;">
                                        Delivered
                                    </th>
                                    <th class="green" style="width: 15%; text-align: center; vertical-align: middle;">
                                       Un-Delivered
                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCentre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division_Name")%>' />
                                    </td>
                                    <td style="width: 35%; text-align: left;">
                                        <asp:Label ID="lblTestCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Message_Name")%>' />
                                    </td>
                                    <td style="width: 13%; text-align: center;">
                                        <asp:Label ID="lblBatchStrength" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Msg_Sent")%>' />
                                    </td>
                                    <td style="width: 13%; text-align: center;">
                                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Delivered")%>' />
                                    </td>
                                    <td style="width: 13%; text-align: center;">
                                        <asp:Label ID="lblAbsentPercent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Un_Delivered")%>' />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <!--/widget-main-->
                    </div>
                    <!--/widget-body-->
                </div>
                <!--/widget-box-->
            </div>
            <div class="span6">
                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="lighter">
                            <i class="icon-user orange"></i>Divisionwise Email Summary</h4>
                        <div class="widget-toolbar">
                            <a href="#" data-action="collapse"><i class="icon-chevron-up"></i></a>
                        </div>
                    </div>
                    <div class="widget-body">
                        <div class="widget-main no-padding" style="height: 240px; overflow-y: scroll; overflow-x: none;">
                            <asp:DataList ID="dlGrid_StudentAbsent" CssClass="table table-bordered table-striped"
                                runat="server" Width="100%">
                                <HeaderTemplate>
                                    <b><span class="orange" style="vertical-align: middle; text-align: left"><i class="icon-caret-right blue">
                                    </i>Division Name</span></b> </th>
                                    <th class="orange" style="width: 23%; text-align: center; vertical-align: middle;">
                                        Mail Type
                                    </th>
                                    <th class="orange" style="width: 15%; text-align: center; vertical-align: middle;">
                                        Sent
                                    </th>
                                    <th class="orange" style="width: 15%; text-align: center; vertical-align: middle;">
                                    Failed
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCentre" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Division_Name")%>' />
                                    </td>
                                    <td style="width: 23%; text-align: left;">
                                        <asp:Label ID="lblBatchStrength" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MailType")%>' />
                                    </td>
                                    <td style="width: 15%; text-align: center;">
                                        <asp:Label ID="lblAbsentCount" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Sent")%>' />
                                    </td>
                                    <td style="width: 15%; text-align: center;">
                                        <asp:Label ID="lblAbsentPercent" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Failed")%>' />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <!--/widget-main-->
                    </div>
                    <!--/widget-body-->
                </div>
                <!--/widget-box-->
            </div>
        </div>
        <div class="hr hr32 hr-dotted">
        </div>
    </div>
</asp:Content>

