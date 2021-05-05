<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_MeetingMinutes.aspx.vb" Inherits="Test.Student_MeetingMinutes" %>
<%-- <asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Meeting
</asp:Content> --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Minutes Meeting
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">

        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
            <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Team"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                            <asp:Label ID="lblTeam" runat="server" CssClass="LabelMenu"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label16" runat="server" CssClass="LabelMenu" Text="Meeting"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label18" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlMeeting" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr><td colspan="3" style="background-color: #99CCFF; color: #000000;">Action List from Last Meeting</td></tr>
                <tr>
                    <td colspan="3">
                        <center>
                        <table>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="right">Title</td>
                                <td align="center">
                                    <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlTitle_Last" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                        <asp:ListItem Value="99">Other</asp:ListItem>
                                    </asp:DropDownList>&nbsp;
                                    <asp:TextBox ID="txtOther_Last" runat="server" Width="171px" visible="false"
                                        Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Details</td>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetails_Last" runat="server" Width="300px"
                                        Font-Size="8pt" CssClass="textbox" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Person</td>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlPerson_Last" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--All Team Members--]</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Due date</td>
                                <td align="center">
                                    <asp:Label ID="Label14" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDate_Last" runat="server" AutoPostBack="true" 
                                                    CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                                    <asp:ListItem Value="1">ASAP</asp:ListItem>
                                                    <asp:ListItem Value="2">Soon</asp:ListItem>
                                                    <asp:ListItem Value="3">Next Week</asp:ListItem>
                                                    <asp:ListItem Value="4">Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtDate_Last" runat="server" Width="171px" visible="false"
                                                Font-Size="8pt" CssClass="textbox" TextMode="Date"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text="Action Point"></asp:Label>
                                </td>
                                <td align="center" valign="top">
                                    <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAction_Last" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                        <asp:ListItem Value="1">Completed</asp:ListItem>
                                        <asp:ListItem Value="2">In progress</asp:ListItem>
                                        <asp:ListItem Value="3">Incompleted</asp:ListItem>
                                        <asp:ListItem Value="4">Cancel</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnAdd_Last" runat="server" Text="Add" CssClass="Btn" />&nbsp;
                                    <asp:Button ID="btnCancel_Last" runat="server" Text="Cancel" CssClass="Btn" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;

                                    <asp:GridView ID="gvAdd_Last" runat="server" AutoGenerateColumns="False" CssClass="GridViewBodyStyle"
                                        DataKeyNames="teamenrolIdK,titleK,detailsK,personK,duedateK,actionK">
                                         <Columns>
                                            <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" />
                                            <asp:BoundField DataField="details" HeaderText="Details" ReadOnly="True" />
                                            <asp:BoundField DataField="person" HeaderText="Person" ReadOnly="True" />
                                            <asp:BoundField DataField="duedate" HeaderText="Due Date" ReadOnly="True" />
                                            <asp:BoundField DataField="action" HeaderText="Action Point" ReadOnly="True" />
                                            <asp:CommandField ShowDeleteButton="True" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </asp:CommandField>
                                        </Columns>     
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                        </center>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr><td colspan="3" style="background-color: #99CCFF; color: #000000;">Present Meeting</td></tr>
                <tr>
                    <td colspan="3">
                        <center>
                        <table>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="right">Title</td>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlTitle_Present" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                        <asp:ListItem Value="99">Other</asp:ListItem>
                                    </asp:DropDownList>&nbsp;
                                    <asp:TextBox ID="txtOther_present" runat="server" Width="171px" visible="false"
                                        Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Details</td>
                                <td align="center">
                                    <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetails_Present" runat="server" Width="300px"
                                        Font-Size="8pt" CssClass="textbox" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"">Person</td>
                                <td align="center">
                                    <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlPerson_Present" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--All Team Members--]</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Due date</td>
                                <td align="center">
                                    <asp:Label ID="Label15" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDate_Present" runat="server" AutoPostBack="true" 
                                                    CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                                    <asp:ListItem Value="1">ASAP</asp:ListItem>
                                                    <asp:ListItem Value="2">Soon</asp:ListItem>
                                                    <asp:ListItem Value="3">Next Week</asp:ListItem>
                                                    <asp:ListItem Value="4">Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtDate_Present" runat="server" Width="171px" visible="false"
                                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Label ID="Label25" runat="server" CssClass="LabelMenu" Text="Action Point"></asp:Label>
                                </td>
                                <td align="center" valign="top">
                                    <asp:Label ID="Label26" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlAction_Present" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                        <asp:ListItem Value="1">Completed</asp:ListItem>
                                        <asp:ListItem Value="2">In progress</asp:ListItem>
                                        <asp:ListItem Value="3">Incompleted</asp:ListItem>
                                        <asp:ListItem Value="4">Cancel</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnAdd_Present" runat="server" Text="Add" CssClass="Btn" />&nbsp;
                                    <asp:Button ID="btnCancel_Present" runat="server" Text="Cancel" CssClass="Btn" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;

                                    <asp:GridView ID="gvAdd_Present" runat="server" AutoGenerateColumns="False" CssClass="GridViewBodyStyle"
                                        DataKeyNames="teamenrolIdK,titleK,detailsK,personK,duedateK,actionK">
                                         <Columns>
                                            <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" />
                                            <asp:BoundField DataField="details" HeaderText="Details" ReadOnly="True" />
                                            <asp:BoundField DataField="person" HeaderText="Person" ReadOnly="True" />
                                            <asp:BoundField DataField="duedate" HeaderText="Due Date" ReadOnly="True" />
                                            <asp:BoundField DataField="action" HeaderText="Action Point" ReadOnly="True" />
                                            <asp:CommandField ShowDeleteButton="True" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </asp:CommandField>
                                        </Columns>     
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                        </center>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr><td colspan="3" style="background-color: #99CCFF; color: #000000;">Follow-up action for Next Meeting</td></tr>
                <tr>
                    <td colspan="3">
                        <center>
                        <table>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="right">Title</td>
                                <td align="center">
                                    <asp:Label ID="Label21" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    &nbsp;<asp:TextBox ID="txtTitle_Next" runat="server" Width="171px"
                                        Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Details</td>
                                <td align="center">
                                    <asp:Label ID="Label22" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetails_Next" runat="server" Width="300px"
                                        Font-Size="8pt" CssClass="textbox" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Person</td>
                                <td align="center">
                                    <asp:Label ID="Label23" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlPerson_Next" runat="server" AutoPostBack="true" 
                                        CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">[--All Team Members--]</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Due date</td>
                                <td align="center">
                                    <asp:Label ID="Label24" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                <td align="left">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlDate_Next" runat="server" AutoPostBack="true" 
                                                    CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                                    <asp:ListItem Value="1">ASAP</asp:ListItem>
                                                    <asp:ListItem Value="2">Soon</asp:ListItem>
                                                    <asp:ListItem Value="3">Next Week</asp:ListItem>
                                                    <asp:ListItem Value="4">Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtDate_Next" runat="server" Width="171px" visible="false"
                                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td colspan="3">&nbsp;</td></tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="btnAdd_Next" runat="server" Text="Add" CssClass="Btn" />&nbsp;
                                    <asp:Button ID="btnCancel_Next" runat="server" Text="Cancel" CssClass="Btn" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;

                                    <asp:GridView ID="gvAdd_Next" runat="server" AutoGenerateColumns="False" CssClass="GridViewBodyStyle"
                                        DataKeyNames="teamenrolIdK,titleK,detailsK,personK,duedateK,actionK">
                                        <Columns>
                                            <asp:BoundField DataField="title" HeaderText="Title" ReadOnly="True" />
                                            <asp:BoundField DataField="details" HeaderText="Details" ReadOnly="True" />
                                            <asp:BoundField DataField="person" HeaderText="Person" ReadOnly="True" />
                                            <asp:BoundField DataField="duedate" HeaderText="Due Date" ReadOnly="True" />
                                            <asp:BoundField DataField="action" HeaderText="Action Point" ReadOnly="True" />
                                            <asp:CommandField ShowDeleteButton="True" >
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                            </asp:CommandField>
                                        </Columns>     
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                        </center>
                    </td>
                </tr>
                <tr><td align="center" colspan="3">&nbsp;</td></tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                    </td>
                </tr>
                <tr><td align="center" colspan="3">&nbsp;</td></tr>
                <tr id="trSearchNo" runat="server">
                    <td align="right">
                        <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu" 
                            Text="Searching by Meeting"></asp:Label>&nbsp;
                    </td>
                    <td align="center"> : </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnQuerySearch" runat="server">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr><td height="20px">&nbsp;</td></tr>
                                            <tr>
                                                <td align="center">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                                                                    DataKeyNames="meetingId" 
                                                                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                                                                    EmptyDataText="---No Record---">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Type" SortExpression="startTime">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblType" runat="server" Text='<%# Bind("catagory") %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Title" SortExpression="startTime">
            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("minutesTitle") %>' Width="200px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="200px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Details" SortExpression="startTime">
                                                                            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("minutesDetails") %>' Width="200px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="200px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Person" SortExpression="stulevel">
                                                                            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPerson" runat="server" Text='<%# Bind("stuId") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="100px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date" SortExpression="stulevel">
                                                                           
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("duedate") %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Status" SortExpression="stulevel">
                                                                            
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("actionDetails") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="100px" />
                                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:TemplateField>

                                                                       
                                                                    </Columns>
                                                                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr><td align="center" colspan="3" height="20px"></td></tr>
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    </asp:Content>

