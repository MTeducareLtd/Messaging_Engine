<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SMS.aspx.cs" Inherits="SMS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="Server">
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
                <li id="lilastbreadcrumb" runat="server" visible="false"><i class="fa fa-angle-right"></i><a href="#">
                    <asp:Label ID="lbllastbreadcrumb" runat="server"></asp:Label></a></li>



                <li class="btn-group" id="liregno" runat="server" visible="false">
                    <button type="button" class="btn purple dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                        data-delay="1000" data-close-others="true" visible="false">
                        <span>Actions </span><i class="fa fa-angle-down"></i>
                    </button>
                    <ul class="dropdown-menu pull-right" role="menu">
                        <li><a id="A2" runat="server" href="Series.aspx" target="_blank">Manage Statutory Info.</a>
                        </li>
                    </ul>
                </li>
                <li class="btn-group"><a data-loading-text="Loading..." class="demo-loading-btn btn blue"
                    runat="server" visible="false" target="_blank" id="btnviewenrollment" style="margin-right: 197px; position: relative"><i class="fa fa-bullhorn"></i>View Order</a>&nbsp; 
                </li>


            </ul>
            <div id="nav-search">
                <span id="listudentstatus" runat="server">
                    <span id="badgeError" runat="server" class="badge badge-important" visible="false">Student Status : Pending</span>
                    <span id="Span1" runat="server" class="badge badge-important" visible="false">Student Status : Cancelled</span>
                    <span id="badgeSuccess" runat="server" class="badge badge-success" visible="false">Student Status : Confirmed</span>
                    <asp:Label ID="lblstdstaus" runat="server" Visible="false"></asp:Label>
                </span>
                <!-- /btn-group -->
                <asp:Button class="btn  btn-app btn-primary btn-mini radius-4  " Visible="true"
                    runat="server" ID="BtnShowSearchPanel" Text="Search"
                    OnClick="BtnShowSearchPanel_Click" />

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
                    <strong><i class="icon-info-sign"></i>Note !</strong>
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
                                                    <th colspan="6">Organization Assignment
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">Company
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcompany" runat="server" data-placeholder="Select" CssClass="chzn-select" ValidationGroup="Grplead12"
                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlcompany_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Division
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddldivision" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddldivision_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Zone/Area
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlzone" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlzone_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">Location / Center
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcenter" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcenter_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover" id="tblci"
                                            runat="server" visible="false">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">Customer Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">Customer Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcustomertypesearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Institution Type
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlinstitutionsearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlinstitutionsearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Board
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlboardsearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Show Only Promoted
                                                </td>
                                                <td width="20%">
                                                    <asp:CheckBox ID="chkpromoted" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">Standard
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstandardsearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">Handphone
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txthandphonesearch" runat="server" Width="70%" placeholder="Search by Handphone 1"></asp:TextBox>
                                                </td>
                                                <td width="10%">Event
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlevent" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">From
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txteventdatefrom" runat="server" Width="70%"></asp:TextBox>
                                                    <CC1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdatefrom"
                                                        DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                    </CC1:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txteventdatefrom"
                                                        ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                </td>
                                                <td width="10%">To
                                                </td>
                                                <td width="20%">
                                                    <asp:TextBox ID="txteventdateto" runat="server" Width="70%"></asp:TextBox>
                                                    <CC1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd-MM-yyyy" TargetControlID="txteventdateto"
                                                        DaysModeTitleFormat="dd-MM-yyyy" Enabled="True" TodaysDateFormat="dd-MM-yyyy">
                                                    </CC1:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txteventdateto"
                                                        ValidationGroup="Grplead1" Text="#" SetFocusOnError="True" ErrorMessage="Please Enter a valid date in the format (dd-mm-yyyy)"
                                                        ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- -.](0[1-9]|1[012])[- -.](19|20)\d\d$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover" id="tblcri"
                                            runat="server" visible="false">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">Customer Residential Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">Country
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcountrysearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcountrysearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">State
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlstatesearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlstatesearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%">City
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlcitysearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlcitysearch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">Location
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddllocationsearch" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-striped table-bordered table-advance table-hover">
                                            <thead>
                                                <tr>
                                                    <th colspan="6">Stream Information
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tr>
                                                <td width="10%">SMS Type
                                                       <asp:Label ID="label4" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlSMS_Type" runat="server" data-placeholder="Select"
                                                        CssClass="chzn-select" AutoPostBack="true">
                                                        <asp:ListItem Selected="True">Select</asp:ListItem>
                                                        <asp:ListItem Value="01">Account</asp:ListItem>
                                                        <asp:ListItem Value="02">Opportunity</asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlSMS_Type"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select SMS Type"
                                                        InitialValue="Select" />
                                                </td>
                                                <td width="10%">Academic Year
                                                        <asp:Label ID="label42" runat="server" Text=" *" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlacademicyear" runat="server" ValidationGroup="Grplead12" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true" OnSelectedIndexChanged="ddlacademicyear_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlacademicyear"
                                                        Text="#" runat="server" ValidationGroup="Grplead12" SetFocusOnError="True" ErrorMessage="Select Academic Year"
                                                        InitialValue="Select" />
                                                </td>
                                                <td width="10%">Product Category</td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlproductcategory" runat="server" AutoPostBack="true" data-placeholder="Select" CssClass="chzn-select">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">Product(S)</td>
                                                <td width="20%">

                                                    <%-- <asp:DropDownList ID="ddlstream" runat="server" AutoPostBack="true" 
                                                            CssClass="chzn-select" data-placeholder="Select">
                                                        </asp:DropDownList>--%>



                                                    <asp:ListBox runat="server" ID="lststreams"  data-placeholder="Select Product(s)"
                                                        CssClass="chzn-select" SelectionMode="Multiple" AutoPostBack="true" OnSelectedIndexChanged="lststreams_SelectedIndexChanged"></asp:ListBox>


                                                </td>
                                                <td width="10%">Status</td>
                                                <td width="20%">
                                                    <asp:DropDownList ID="ddlorderstatus" runat="server" data-placeholder="Select" CssClass="chzn-select" AutoPostBack="true">
                                                        <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                                        <asp:ListItem Value="01">Pending</asp:ListItem>
                                                        <asp:ListItem Value="03">Confirmed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="10%" id="tdapplicationid" runat="server">Customer Number / SB Entry Code</td>
                                                <td width="20%" id="tdapplicationid1" runat="server">

                                                    <asp:TextBox ID="txtsbentrycode" runat="server"
                                                        placeholder="Search by SBEntrycode" Width="70%"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="10%">App. Form No</td>
                                                <td width="20%">

                                                    <asp:TextBox ID="txtapplicationno" runat="server"
                                                        placeholder="Search by Application Form No." Width="70%"></asp:TextBox>

                                                </td>
                                                <td width="10%">Active
                                                </td>
                                                <td width="20%">
                                                    <asp:CheckBox ID="Chkactive" runat="server" Checked="true" /><span class="lbl"> </span>
                                                </td>
                                                <td>Customer Name</td>
                                                <td>
                                                    <asp:TextBox ID="txtstudentname" runat="server" placeholder="Search by Name"
                                                        Width="70%"></asp:TextBox>
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
                                               
                                                <td width="10%"></td>
                                                
                                                <td></td>
                                                
                                            </tr>
                                        </table>
                                        <asp:TextBox ID="txtcurrentout" Visible="false" runat="server"></asp:TextBox>
                                        <div class="well" style="text-align: center; background-color: #F0F0F0">
                                            <button class="btn btn-app btn-primary btn-mini radius-4" id="btnsearch" onserverclick="btnsearch_ServerClick" validationgroup="Grplead12"
                                                runat="server">
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
                                        <div class="portlet box ">
                                            <div class="portlet-title">
                                                <div class="table-header">
                                                    SMS Search Results
                                                    <asp:CheckBox ID="chkStudentAllHidden_Sel" runat="server" Visible="False" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <button id="btnSmsSend" runat="server" class="btn btn-small btn-warning radius-4"
                                                        data-rel="tooltip" data-placement="top" title="Send SMS" visible="true" onserverclick="btnSmsSend_ServerClick">
                                                        <i class="icon-envelope-alt"></i>
                                                    </button>
                                                    <!---->
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <HeaderTemplate>
                                                        <table class="table table-striped table-bordered table-hover table2">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        <asp:CheckBox ID="chkStudentAll" runat="server" AutoPostBack="True" OnCheckedChanged="All_Student_ChkBox_Selected_Sel" />
                                                                        <span class="lbl"></span>
                                                                    </th>
                                                                    <th>Division
                                                                    </th>
                                                                    <th>Location / Center
                                                                    </th>
                                                                    <th>Date
                                                                    </th>
                                                                    <th>App. Form No.
                                                                    </th>
                                                                    <th>Customer Name
                                                                    </th>
                                                                    <th>SBEntrycode
                                                                    </th>
                                                                    <th>Academic Year
                                                                    </th>
                                                                    <th>Product
                                                                    </th>
                                                                    <th>Student Contact No
                                                                    </th>
                                                                    <th>Parents Contact No
                                                                    </th>
                                                                    <%-- <th>
                                                                        Cheque O/S
                                                                    </th>
                                                                    <th>
                                                                        Admission Status
                                                                    </th>
                                                                    <th>
                                                                        Action
                                                                    </th>--%>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr class="odd gradeX">
                                                            <td>
                                                                <asp:CheckBox ID="chkStudent" runat="server" />
                                                                <span class="lbl"></span>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" Text='<%#DataBinder.Eval(Container.DataItem, "Division")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcenter" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Name")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblCenterCodeSR" Text='<%#DataBinder.Eval(Container.DataItem, "Source_Center_Code")%>'
                                                                    runat="server" Visible="false"></asp:Label>

                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbldate" Text='<%#DataBinder.Eval(Container.DataItem, "EventDate")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label38" Text='<%#DataBinder.Eval(Container.DataItem, "App_no")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblcustomername" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label43" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
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
                                                                    runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="Label2" Text='<%#DataBinder.Eval(Container.DataItem, "NHandphone1")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblstudentno" Text='<%#DataBinder.Eval(Container.DataItem, "Handphone1")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" Text='<%#DataBinder.Eval(Container.DataItem, "NFatherno")%>'
                                                                    runat="server"></asp:Label>
                                                                <asp:Label ID="lblfno" Text='<%#DataBinder.Eval(Container.DataItem, "Fatherno")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <%-- <td>
                                                                <asp:Label ID="lblchequeos" Text='<%#DataBinder.Eval(Container.DataItem, "Chqoutstanding")%>'
                                                                    runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lbladmissionstatus" runat="server" Font-Bold="true" ></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label30" Text='<%#DataBinder.Eval(Container.DataItem, "Adm_Status")%>'
                                                                    runat="server" Visible="false"></asp:Label>&nbsp;
                                                                <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblpromotedflag" Text='<%#DataBinder.Eval(Container.DataItem, "IsPromote")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                <asp:Label ID="lbladmnreasonid" Text='<%#DataBinder.Eval(Container.DataItem, "Account_Cancel_Reason_Id")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Account_Display.aspx?&Oppur_ID={0}") %>'
                                                                    id="btndisplay" runat="server" target="_blank" visible="false" class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                 
                                                                 <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Opportunity_Add.aspx?&Oppurtunity_code={0}") %>'
                                                                    id="btndisplayopp" runat="server" target="_blank" visible="false" class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip" data-placement="top" title="Display"></a>
                                                                
                                                                <asp:LinkButton ID="lnkEdit" runat="server" Visible="false" CommandName="Edit" class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip" data-placement="top" title="Edit"
                                                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>'></asp:LinkButton>

                                                                <asp:LinkButton ID="lnkledger" runat="server" CommandName="Ledger"
                                                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Cur_sb_code")%>' class="btn btn-minier btn-success icon-eye-open tooltip-success" data-rel="tooltip" data-placement="top" title="View Ledger"></asp:LinkButton>
                                                                
                                                                <a href='<%#DataBinder.Eval(Container.DataItem,"Oppor_Id","Opportunity_Edit.aspx?&Opportunity_Code={0}") %>'
                                                                    id="btneditenroll" class="btn btn-minier btn-primary icon-edit tooltip-info" data-rel="tooltip" data-placement="top" title="Edit"
                                                                     runat="server" target="_blank">
                                                                </a>
                                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                <asp:Label ID="lblsbentrycode" Text='<%#DataBinder.Eval(Container.DataItem, "Cur_sb_code")%>'
                                                                    runat="server" Visible="false"></asp:Label>
                                                            </td>--%>
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

    <div class="modal hide fade" id="Divsmsstd" style="width: 80%; max-width: 700px; left: 43%; position: absolute; display: none; top: 50px"
        tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel runat="server" ID="UpdatePaneSMSsend" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="row-fluid">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                    &times;</button>
                                <h4 class="modal-title">Send SMS
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
                                                            <h4 class="green">Tag</h4>
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
                                        <td width="1%"></td>
                                        <td class="well ">
                                            <table>
                                                <tr>
                                                    <td width="20%">Characters Left:</td>
                                                    <td width="65%" colspan="3">
                                                        <label id="lblcount" style="background-color: #E2EEF1; color: Red; font-weight: bold;">600</label></td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">Message Text 
                                                    </td>
                                                    <td width="65%" colspan="3">
                                                        <asp:TextBox TextMode="multiline" runat="server" ID="txtsmsstd" class="autosize-transition span12" Text="Dear "
                                                            Style="overflow: hidden; word-wrap: break-word; resize: horizontal; height: 100px;" onkeyup="LimtCharacters(this,600,'lblcount');" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Send To
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

