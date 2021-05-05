<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dashboard.aspx.vb" Inherits="Test.dashboard" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="utf-8" />    
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>
        TEAM CONTRIBUTION & BUDGET SYSTEM (TCABS)
    </title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <style type="text/css">
        .Hide 
        { 
            display:none; 
        }
    </style>
</head>

<body id="page-top">
    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="dashboard.aspx">
                <div class="sidebar-brand-icon rotate-n-15">
                    <i class="fas fa-laugh-wink"></i>
                </div>
                <div class="sidebar-brand-text mx-3">TCAB<sup>s</sup></div>
            </a>

            <!-- Divider -->
            <hr class="sidebar-divider my-0">

            <!-- Nav Item - Dashboard -->
            <li class="nav-item active">
            <a class="nav-link" href="dashboard.aspx">
                <i class="fas fa-fw fa-tachometer-alt"></i>
                <span>Dashboard</span></a>
            </li>

            <!-- Divider -->
            <hr class="sidebar-divider">

            <!-- Admin -->
            <div id="divAdmin" runat="server">
                <div class="sidebar-heading">
                    Admin
                </div>
                <!-- Nav Item - Role Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseRole" aria-expanded="true" aria-controls="collapseRole">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Role</span>
                    </a>
                    <div id="collapseRole" class="collapse" aria-labelledby="headingEmp" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Role Menu:</h6>
                        <a class="collapse-item" href="Admin_RoleManagement.aspx">Role Management</a>
                        </div>
                    </div>
                </li>
                <!-- Nav Item - Employee Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseEmp" aria-expanded="true" aria-controls="collapseEmp">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Employee</span>
                    </a>
                    <div id="collapseEmp" class="collapse" aria-labelledby="headingEmp" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Employee Menu:</h6>
                        <a class="collapse-item" href="Admin_EmpManagement.aspx">Employee Management</a>
                        <a class="collapse-item" href="Admin_EmpDesignation.aspx">Employee Designation</a>
                        <a class="collapse-item" href="Admin_EmpUpload.aspx">Upload Employee (CSV File)</a>
                        </div>
                    </div>
                </li>
                <!-- Nav Item - Unit Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseUnit" aria-expanded="true" aria-controls="collapseUnit">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Unit of Study</span>
                    </a>
                    <div id="collapseUnit" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Unit Menu:</h6>
                        <a class="collapse-item" href="Admin_UnitManagement.aspx">Unit Management</a>
                        <a class="collapse-item" href="Admin_UnitOffering.aspx">Unit Offering</a>
                        <a class="collapse-item" href="Admin_UnitBulkLoad.aspx">Upload Unit (CSV File)</a>
                        </div>
                    </div>
                </li>
                <!-- Nav Item - Student Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseStu" aria-expanded="true" aria-controls="collapseStu">
                        <i class="fas fa-fw fa-wrench"></i>
                        <span>Student</span>
                    </a>
                    <div id="collapseStu" class="collapse" aria-labelledby="headingStu" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                        <h6 class="collapse-header">Student Menu:</h6>
                        <a class="collapse-item" href="Admin_StuManagement.aspx">Student Management</a>
                        <a class="collapse-item" href="Admin_StuEnrolment.aspx">Student Enrolment</a>
                        <a class="collapse-item" href="Admin_StuUpload.aspx">Upload Student (CSV File)</a>
                        <a class="collapse-item" href="Admin_EnrolBulk.aspx">Upload Student Enrolment (CSV File)</a>
                        </div>
                    </div>
                </li>
                <!-- Nav Item - Report -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseAdminReport" aria-expanded="true" aria-controls="collapseAdminReport">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Report</span>
                    </a>
                    <div id="collapseAdminReport" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Report Menu:</h6>
                            <a class="collapse-item" href="Report_ConvUnit.aspx">Registered Convenors</a>
                            <a class="collapse-item" href="Report_Unit.aspx">Offered unit</a>
                            <a class="collapse-item" href="Report_StuUnit.aspx">Enrolled students</a>
                        </div>
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">
            </div>

            <!-- Convenor -->
            <div id="divConvenor" runat="server">
                <div class="sidebar-heading">
                    Convenor
                </div>
                <!-- Nav Item - Project Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseProject" aria-expanded="true" aria-controls="collapseProject">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Project</span>
                    </a>
                    <div id="collapseProject" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Project Menu:</h6>
                            <a class="collapse-item" href="Conv_ProjManagement.aspx">Project Management</a>
                            <a class="collapse-item" href="Conv_ProjRole.aspx">Project Role</a>
                            <a class="collapse-item" href="Conv_ProjTask.aspx">Project Task</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Team Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTeam" aria-expanded="true" aria-controls="collapseTeam">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Team</span>
                    </a>
                    <div id="collapseTeam" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Team Menu:</h6>
                            <a class="collapse-item" href="Conv_TeamFormation.aspx">Team Formation</a>
                            <a class="collapse-item" href="Conv_TeamEnrolment.aspx">Team Allocation</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Peer Assessment Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseConvPeer" aria-expanded="true" aria-controls="collapseConvPeer">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Peer Assessment</span>
                    </a>
                    <div id="collapseConvPeer" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Peer Assessment Menu:</h6>
                            <a class="collapse-item" href="Conv_PeerCriteria.aspx">Criteria management</a>
                            <a class="collapse-item" href="Conv_PeerSetup.aspx">Peer Assessment Setup</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Report -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseConvReport" aria-expanded="true" aria-controls="collapseConvReport">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Report</span>
                    </a>
                    <div id="collapseConvReport" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Report Menu:</h6>
                            <a class="collapse-item" href="Report_StuUnit.aspx">Enrolled students</a>
                            <a class="collapse-item" href="Report_Sup.aspx">Registered supervisors</a>
                            <a class="collapse-item" href="Report_Proj.aspx">Registered projects</a>
                            <a class="collapse-item" href="Report_Team.aspx">Registered teams</a>
                        </div>
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">
            </div>
            
            <!-- Supervisor -->
            <div id="divSupervisor" runat="server">
                <div class="sidebar-heading">
                    Supervisor
                </div>
                <!-- Nav Item - Unit Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseSupMeeting" aria-expanded="true" aria-controls="collapseSupMeeting">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Meeting</span>
                    </a>
                    <div id="collapseSupMeeting" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Meeting Menu:</h6>
                            <a class="collapse-item" href="Supervisor_MeetingSetup.aspx">Meeting Management</a>
                            <a class="collapse-item" href="Supervisor_MeetingAttendee.aspx">Attendee Management</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Report -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseSupReport" aria-expanded="true" aria-controls="collapseSupReport">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Report</span>
                    </a>
                    <div id="collapseSupReport" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Report Menu:</h6>
                            <a class="collapse-item" href="Report_Attendee.aspx">Record of attendees</a>
                            <a class="collapse-item" href="Report_Budget.aspx">Project Budget Report</a>
                        </div>
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">
            </div>
            
            <!-- Student -->
            <div id="divStudent" runat="server">
                <div class="sidebar-heading">
                    Student
                </div>
                <!-- Nav Item - Task Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTask" aria-expanded="true" aria-controls="collapseTask">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Task</span>
                    </a>
                    <div id="collapseTask" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Task Menu:</h6>
                            <a class="collapse-item" href="Student_TaskSubmit.aspx">Submit Individual Task</a>
                            <a id="divPM_taskAccept" runat="server" visible="false" class="collapse-item" href="Student_TaskAccept.aspx">Student Task Approve</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Meeting Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseMeeting" aria-expanded="true" aria-controls="collapseMeeting">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Meeting</span>
                    </a>
                    <div id="collapseMeeting" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Meeting Menu:</h6>
                            <a class="collapse-item" href="Student_MeetingSetup.aspx">Meeting Setup</a>
                            <a class="collapse-item" href="Student_MeetingAgenda.aspx">Meeting Agenda</a>
                            <a class="collapse-item" href="Student_MeetingAttendee.aspx">Meeting Attendee</a>
                            <a class="collapse-item" href="Student_MeetingMinutes.aspx">MeetingMinutes</a>
                            <a class="collapse-item" href="Report_MeetingSummary.aspx">Meeting Summary</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Peer Assessment Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePeer" aria-expanded="true" aria-controls="collapsePeer">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Peer Assessment</span>
                    </a>
                    <div id="collapsePeer" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Peer Assessment Menu:</h6>
                            <a class="collapse-item" href="Student_PeerSubmit.aspx">Submit Peer Assessment</a>
                        </div>
                    </div>
                </li> -->
                <!-- Nav Item - Report -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseStuReport" aria-expanded="true" aria-controls="collapseStuReport">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Report</span>
                    </a>
                    <div id="collapseStuReport" class="collapse" aria-labelledby="headingUnit" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Report Menu:</h6>
                            <a class="collapse-item" href="Report_Budget.aspx">Project Budget Report</a>
                        </div>
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider d-none d-md-block">
            </div>
            
            <!-- Sidebar Toggler (Sidebar) -->
            <div class="text-center d-none d-md-inline">
                <button class="rounded-circle border-0" id="sidebarToggle"></button>
            </div>

        </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

            <!-- Topbar -->
            <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                <!-- Sidebar Toggle (Topbar) -->
                <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
                <i class="fa fa-bars"></i>
                </button>

                <!-- Topbar Navbar -->
                <ul class="navbar-nav ml-auto">

                <div class="topbar-divider d-none d-sm-block"></div>

                <!-- Nav Item - User Information -->
                <li class="nav-item dropdown no-arrow">
                    <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <span class="mr-2 d-none d-lg-inline text-gray-600 small">Siripond Mullanu</span>
                        <img class="img-profile rounded-circle" src="https://source.unsplash.com/QAB-WJcbgJk/60x60">
                    </a>
                    <!-- Dropdown - User Information -->
                    <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                    <!-- <a class="dropdown-item" href="#">
                        <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                        Profile
                    </a> -->
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                        <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                        Logout
                    </a>
                    </div>
                </li>

                </ul>

            </nav>
            <!-- End of Topbar -->

            <!-- Begin Page Content -->
            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="d-sm-flex align-items-center justify-content-between mb-4">
                    <h1 class="h3 mb-0 text-gray-800">
                        Dashboard
                    </h1>
                </div>

                <!-- Registered Unit Tab -->
                <div id="divRegisteredUnit" runat="server" class="row justify-content-center">

                    <div class="col-xl-10 col-lg-12 col-md-9">
                        <div class="card shadow mb-4">
                            <!-- Header -->
                            <div class="card-header py-3 d-flex flex-row align-items-center justify-content-between">
                                <h6 class="m-0 font-weight-bold text-primary">
                                    Registered Unit
                                </h6>
                            </div>
                            <!-- Body -->
                            <div class="card-body">
                                <form runat="server">
                                    <center>
                                        <div id="divUnitConv" runat="server">
                                            <p>Convenor</p>
                                            <asp:GridView ID="gvConvenor" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="unitId" class="alert alert-info" 
                                                EmptyDataText="---No Registered Unit---" ShowHeader="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Unit ID" DataField="unitId" ReadOnly="True">
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField SortExpression="unitName" ItemStyle-Width="300px" ItemStyle-Height="80px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("unitStr") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("unitDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"  />
                                            </asp:GridView>
                                        </div>
                                        <div id="divUnitSup" runat="server">
                                            <p>Supervisor</p>
                                            <asp:GridView ID="gvSupervisor" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="offUnitId" class="alert alert-info" 
                                                EmptyDataText="---No Registered Unit---" ShowHeader="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Unit Offer" DataField="offUnitID" ReadOnly="True">
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField SortExpression="unitName" ItemStyle-Width="300px" ItemStyle-Height="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("unitStr") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("unitDesc") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblYear" runat="server" Text='<%# Bind("offUnitYear") %>'></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblSem" runat="server" Text='<%# Bind("semStr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"  />
                                            </asp:GridView>
                                        </div>
                                        <div id="divUnitStu" runat="server">
                                            <p>Student</p>
                                            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
                                                DataKeyNames="offUnitId" class="alert alert-info"
                                                EmptyDataText="---No Registered Unit---" ShowHeader="False">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Unit Offer" DataField="offUnitID" ReadOnly="True">
                                                        <ItemStyle CssClass="Hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField SortExpression="unitName" ItemStyle-Width="300px" ItemStyle-Height="100px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("unitStr") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("unitDesc") %>'></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblYear" runat="server" Text='<%# Bind("offUnitYear") %>'></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:Label ID="lblSem" runat="server" Text='<%# Bind("semStr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary" />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                                                <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"  />
                                            </asp:GridView>
                                        </div>
                                    </center>
                                </form>
                            </div>
                        </div>

                        <!-- Profile -->
                        <%--<div class="card shadow mb-4">
                            <div class="card-header py-3">
                                <h6 class="m-0 font-weight-bold text-primary">Profile</h6>
                            </div>
                            <div class="card-body">
                                <p>User Profile</p>
                                <p class="mb-0">Details.</p>
                            </div>
                        </div>--%>
                    </div>

                </div>

                

            </div>
            <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->

            <!-- Footer -->
            <footer class="sticky-footer bg-white">
            <div class="container my-auto">
                <div class="copyright text-center my-auto">
                <span>Copyright &copy; TCABS 2020</span>
                </div>
            </div>
            </footer>
            <!-- End of Footer -->

        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->
        
    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
        <i class="fas fa-angle-up"></i>
    </a>

    <!-- Logout Modal-->
    <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
        <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
            </button>
        </div>
        <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
        <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
            <a class="btn btn-primary" href="login.aspx">Logout</a>
        </div>
        </div>
    </div>
    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/chart-area-demo.js"></script>
    <script src="js/demo/chart-pie-demo.js"></script>
</body>
</html>
