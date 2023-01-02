<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SMS_Batchwise.aspx.cs" Inherits="SMS_Batchwise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         function openModalDelete() {
             $('#DivDelete').modal({
                 backdrop: 'static'
             })

             $('#DivDelete').modal('show');
         }
         function CloseModalSms() {
             $('#Divsmsstd').modal('hide');
         }
    </script>
    <script type="text/javascript">
        function openModalSms() {
            $('#Divsmsstd').modal({
                backdrop: 'static'
            })

            $('#Divsmsstd').modal('show');
        }
    </script>
    <script type="text/javascript">
        function LimtCharacters(txtMsg, CharLength, indicator) {
            chars = txtMsg.value.length;
            document.getElementById(indicator).innerHTML = CharLength - chars;
            if (chars > CharLength) {
                txtMsg.value = txtMsg.value.substring(0, CharLength);
            }
        }
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" Runat="Server">
     <asp:ScriptManager ID="script1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid hidden-print">
                <div id="breadcrumbs" class="position-relative" style="height: 53px">
                    <ul class="breadcrumb" style="height: 15px">
                        <li><i class="icon-home"></i><a href="Homepage.aspx">Home</a><span class="divider"><i
                            class="icon-angle-right"></i></span></li>
                        <li>
                            <h4 class="blue">
                                <asp:Label ID="lblpagetitle1" runat="server"></asp:Label>&nbsp;<b><asp:Label ID="lblstudentname"
                                    runat="server" ForeColor="DarkRed"></asp:Label></b><small> &nbsp;
                                        <asp:Label ID="lblpagetitle2" runat="server"></asp:Label></small>
                                <asp:Label ID="lblusercompany" runat="server" Visible="false"></asp:Label>
                                <span class="divider"></span>
                            </h4>
                        </li>
                        <li id="limidbreadcrumb" runat="server" visible="false"><a href="lead.aspx">
                            <asp:Label ID="lblmidbreadcrumb" runat="server"></asp:Label></a></li>
                        <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right">
                        </i><a href="#">
                            <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>
                        
                        

                        <li class="btn-group" id="liregno" runat="server" visible ="false" >
                            <button type="button" class="btn purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                                data-delay="1000" data-close-others="true" visible ="false" >
                                <span>Actions </span><i class="fa fa-angle-down"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" role="menu">
                                <li><a id="A2" runat="server" href="Series.aspx" target="_blank">Manage Statutory Info.</a>
                                </li>
                            </ul>
                        </li>
                        <li class="btn-group"><a data-loading-text="Loading..." class="demo-loading-btn btn blue"
                            runat="server" visible="false" target="_blank" id="btnviewenrollment" style="margin-right: 197px;
                            position: relative"><i class="fa fa-bullhorn"></i>View Order</a>&nbsp; 
                        </li>
                        
                        
                    </ul>
                    <div id="nav-search">
                        <span id="listudentstatus" runat="server">
                        <span id="badgeError" runat="server" class="badge badge-important" visible ="false">Student Status : Pending</span>
                        <span id="Span1" runat="server" class="badge badge-important" visible ="false">Student Status : Cancelled</span>
                        <span id="badgeSuccess" runat="server" class="badge badge-success" visible ="false" >Student Status : Confirmed</span>
                        <asp:Label ID="lblstdstaus" runat="server" Visible ="false" ></asp:Label>
                        </span>
                        <!-- /btn-group -->
                        <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true"
                runat="server" ID="BtnShowSearchPanel" Text="Search" 
                onclick="BtnShowSearchPanel_Click" />
                        
                    </div>

                    <%--<asp:AsyncPostBackTrigger ControlID ="Exporttoexcel" />--%>
                    <!-- END PAGE TITLE & BREADCRUMB-->
                </div>
            </div>

            <!-- END PAGE HEADER-->
    <!-- BEGIN CONTENT -->
    <div id="page-content" class="clearfix">
        <div class="page-content">
            
            <div class="alert alert-danger" id="divErrormessage" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblerrormessage" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-danger" id="divpendingreuesterror" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblpendingreuesterror" runat="server"></asp:Label></strong>
            </div>
            <div class="alert alert-success" id="divSuccessmessage" runat="server">
                <button class="close" data-close="alert">
                </button>
                <strong>
                    <asp:Label ID="lblsuccessMessage" runat="server"></asp:Label></strong>
            </div>

            <div class="alert alert-info" id="Msg_Info" visible="false" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            <i class="icon-remove"></i>
                        </button>
                        <p>
                            <strong><i class="icon-info-sign"></i> Note !</strong>
                            <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
            <asp:UpdatePanel ID="upnlsearch" runat="server">
                <ContentTemplate>
                    <div class="row-fluid" id="divSearch" runat="server">
                        <div class="span12">
                            <div id="tab_1_31" class="row-fluid">
                                <div class="row-fluid" id="Divsearchcriteria" runat="server">
                                    <div class="span12">

                                            <table class="table table-striped table-bordered table-advance table-hover">
                                                <thead>
                                                    <tr>
                                                        <th colspan="6">
                                                            Organization Assignment
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tr>
                                                    <td width="10%">
                                                        Company
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                            AutoPostBack="true" OnSelectedIndexChanged ="ddlcompany_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        Division
                                                        <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddldivision_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddldivision"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Division"
                                                        InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Zone/Area
                                                        <asp:Label ID="label5" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlzone" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlzone_SelectedIndexChanged" >
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlzone"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Zone"
                                                        InitialValue="Select" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Location / Center
                                                        <asp:Label ID="label6" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                        <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged ="ddlcenter_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlcenter"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Center"
                                                        InitialValue="Select" />
                                                    </td>
                                                    <td width="10%">
                                                        Academic Year
                                                        <asp:Label ID="label7" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                         <asp:DropDownList ID="ddlacademicyear" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlacademicyear"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                        InitialValue="Select" />
                                                    </td>
                                                     <td width="10%">
                                                        Course
                                                        <asp:Label ID="label9" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%">
                                                         <asp:DropDownList ID="ddlCourse" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlCourse"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Course"
                                                        InitialValue="Select" />
                                                    </td>
                                                    </tr>
  <tr>
                                                    <td width="10%">
                                                        SMS Category
                                                        <asp:Label ID="label1" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" >
                                                        <asp:DropDownList ID="ddlCategory" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" >
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlCategory"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Category"
                                                        InitialValue="Select" />
                                                    </td>
                                                   
                                                </tr>

                                                    <tr>
                                                    <td width="10%">
                                                        Batch
                                                        <asp:Label ID="label8" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                    <td width="20%" colspan="5">
                                                        <%-- <asp:DropDownList ID="ddlBatch" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                        </asp:DropDownList>--%>
                                                        <asp:ListBox runat="server" ID="ddlBatch"  data-placeholder="Select Batch(es)"
                                                                    CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true"></asp:ListBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlBatch"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Batch"
                                                        InitialValue="Select" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:TextBox ID="txtcurrentout" Visible="false" runat="server"></asp:TextBox>
                                            <div class="well" style="text-align: center; background-color: #F0F0F0">
                                                <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick" ValidationGroup="Grplead12"
                                                    runat="server" >
                                                    Search
                                                </button>
                                                <asp:ValidationSummary ID="ValidationSummary17" runat="server" ShowMessageBox="True"
                                                                ValidationGroup="Grplead12" ShowSummary="False" />
                                            </div>

                                    </div>
                                </div>
                                <div class="row-fluid" id="divsearchresults" runat="server">
                                    <div class="span12">
                                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                        <div class="widget-box">
                                        <div class="table-header">
                                            <table width="100%">
                                                <tr>
                                                    <td class="span10">
                                                        Total No of Records:
                                                        <asp:Label runat="server" ID="lbltotalcount" Text="0" />
                                                        <asp:CheckBox ID="chkStudentAllHidden_Sel" runat="server" Visible="False" />
                                                    </td>
                                                    <td style="text-align: right" class="span2">
                                                        <button id="btnSmsSend" runat="server" class="btn btn-small btn-warning radius-4"
                                                            data-rel="tooltip" data-placement="top" title="Send SMS" visible="true"  onserverclick="btnSmsSend_ServerClick"> 
                                                            <i class="icon-envelope-alt"></i>
                                                        </button>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        </div>
                                        <div class="portlet box ">
                                            <div class="portlet-title">
                                                <div class="table-header">
                                                    
                                                    
                                                        <!---->
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <asp:Repeater ID="Repeater1" runat="server" >
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover table2">
                                                            <thead>
                                                                <tr>
                                                                    <th><asp:CheckBox ID="chkStudentAll" runat="server" AutoPostBack="True" OnCheckedChanged="All_Student_ChkBox_Selected_Sel" />
                                                                                        <span class="lbl"></span>
                                                                    </th>
                                                                    <th>
                                                                        Division
                                                                    </th>
                                                                    <th>
                                                                        Location / Center
                                                                    </th>                                                                   
                                                                    <th>
                                                                        Customer Name
                                                                    </th>
                                                                    <th>
                                                                        SBEntrycode
                                                                    </th>
                                                                    <th>
                                                                        Academic Year
                                                                    </th>
                                                                   <th>
                                                                        Product
                                                                    </th>
                                                                    <th>
                                                                        Student Contact No
                                                                    </th>
                                                                     <th>
                                                                        Parents Contact No
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td><asp:CheckBox ID="chkStudent" runat="server" />
                                                                                    <span class="lbl"></span>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDivision" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblCenterCodeSR" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Code")%>'
                                                                    runat="server" Visible ="false"></asp:Label>

                                                            </td>                                                            
                                                            <td>
                                                                <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblfirststudentname" Text='<%#DataBinder.Eval(Container.DataItem, "FirstName")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCurSBCode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblacadyear" Text='<%#DataBinder.Eval(Container.DataItem, "acadyear")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblproduct" Text='<%#DataBinder.Eval(Container.DataItem, "Stream")%>'
                                                                    runat="server"></asp:Label>
                                                                
                                                            </td>
                                                            <td>
                                                               
                                                                <asp:Label ID="lblmno" Text='<%#DataBinder.Eval(Container.DataItem, "Motherno")%>'
                                                                runat="server" Visible ="false"></asp:Label>
                                                                <asp:Label ID="lblNHandphone1" Text='<%#DataBinder.Eval(Container.DataItem, "NHandphone1")%>'
                                                                runat="server" ></asp:Label>
                                                                <asp:Label ID="lblstudentno" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                                runat="server" visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                            <asp:Label ID="lblNFatherNo" Text='<%#DataBinder.Eval(Container.DataItem, "NFatherno")%>'
                                                                    runat="server" ></asp:Label>
                                                                 <asp:Label ID="lblfno" Text='<%#DataBinder.Eval(Container.DataItem, "Fatherno")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </tbody> </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Label ID="lbloppurid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblaccountid" runat="server" Visible="false"></asp:Label>
                                                <asp:Label ID="lblpromoteflag" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        
                                        </div>
                                        <!-- END EXAMPLE TABLE PORTLET-->
                                    </div>
                                </div>
                                <div class="alert alert-danger" id="divmessage" runat="server">
                                    <strong>
                                        <asp:Label ID="lblmessage" runat="server"></asp:Label></strong>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--end tabbable-->
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                    <%--<asp:AsyncPostBackTrigger ControlID ="Exporttoexcel" />--%>
                </Triggers>
            </asp:UpdatePanel>
            </div>
    </div>

    <div class="modal hide fade" id="Divsmsstd" style="width: 80%; max-width: 700px;
        left: 43%; position: absolute; display: none; top: 50px" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel runat="server" ID="UpdatePaneSMSsend" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="row-fluid">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Send SMS
                                </h4>
                            </div>
                            <!--<div class="modal-body" style="overflow:hidden;">  </div> -->
                            <!--Actaul Use Area -->
                            <div class="modal-body" style="overflow: hidden;">
                                <table width="100%" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td width="25%" class="well ">
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <h4 class="green">
                                                                Tag</h4>
                                                            <asp:LinkButton ID="Linkbtnstdnm" runat="server" OnClick="Linkbtnstdnm_Click">Full Name</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <asp:LinkButton ID="Linkbtnstdfnm" runat="server" OnClick="Linkbtnstdfnm_Click">First Name</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <%--<asp:LinkButton ID="Linkbtntestnm" runat="server" OnClick="Linkbtntestnm_Click">Test Name</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <asp:LinkButton ID="Linkbtntestdt" runat="server" OnClick="Linkbtntestdt_Click">Test Date</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <asp:LinkButton ID="Linkbtnmxmark" runat="server" OnClick="Linkbtnmxmark_Click">Max Mark</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <asp:LinkButton ID="Linkbtnobtnmark" runat="server" OnClick="Linkbtnobtnmark_Click">Obtain Mark</asp:LinkButton>&nbsp;&nbsp;<br />
                                                            <asp:LinkButton ID="Linkbtnperctg" runat="server" OnClick="Linkbtnperctg_Click">percentage</asp:LinkButton>&nbsp;&nbsp;<br />--%>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="1%">
                                        </td>
                                        <td class="well ">
                                            <table>
                                                <tr>
                                                    <td width="20%">Characters Left:</td>
                                                    <td width="65%" colspan="3"><label id="lblcount" style="background-color:#E2EEF1;color:Red;font-weight:bold;">600</label></td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        Message Text 
                                                    </td>
                                                    <td width="65%" colspan="3">
                                                        <asp:TextBox TextMode="multiline" runat="server" ID="txtsmsstd" class="autosize-transition span12" Text="Dear "
                                                            Style="overflow: hidden; word-wrap: break-word; resize: horizontal; height: 100px;" onkeyup="LimtCharacters(this,600,'lblcount');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Send To
                                                    </td>
                                                    <td style="text-align: left;" width="25%">
                                                        <label>
                                                            <input name="form-field-radio" runat="server" type="radio" id="inputstd" />
                                                            <span class="lbl">Student</span>
                                                        </label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <label>
                                                            <input name="form-field-radio" runat="server" type="radio" id="inputpar" />
                                                            <span class="lbl">Parent</span>
                                                        </label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <label>
                                                            <input name="form-field-radio" runat="server" type="radio" id="inputboth" />
                                                            <span class="lbl">Both</span>
                                                        </label>
                                                    </td>

                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <!--Footers Button Area -->
                                <asp:Label ID="Label11" runat="server" Font-Bold="true" ForeColor="Red" Text="" />
                                <asp:Button class="btn btn-app btn-success  btn-mini radius-4" runat="server" ID="btnSendsmsstd" OnClick="btnSendsmsstd_Click"
                                    Text="Send" /><!---->
                                <asp:Button class="btn btn-app btn-primary  btn-mini radius-4" runat="server" ID="Button4"
                                    data-dismiss="modal" Text="Close" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>

