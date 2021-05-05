<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Supervisor_MeetingAttendee.aspx.vb" Inherits="Test.Supervisor_MeetingAttendee" %>
<%-- <asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Meeting
</asp:Content> --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Attendee Management
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
                           <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
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
                <tr><td align="center" colspan="3">&nbsp;</td></tr>
                <tr><td align="center" colspan="3">Attendees</td></tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="teamEnrolId" 
                            AllowPaging="True" CssClass="GridViewBodyStyle" 
                            EmptyDataText="---No Record---">
                            <Columns>
                                <asp:TemplateField HeaderText="Student ID">
		                            <ItemTemplate>
			                            <asp:Label ID="lblStuId" runat="server" Text='<%# Bind("stuid") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
	                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Student Name" SortExpression="stuname">
                                    <EditItemTemplate>
                                        <asp:Textbox ID="txtStuName" runat="server" Text='<%# Bind("stuname") %>' ></asp:Textbox>
                                   </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("stuname") %>' Width="200px"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Attended Status">
		                            <ItemTemplate>
			                            <asp:DropDownList ID="ddlAttendStatus" runat="server" AutoPostBack="true" 
                                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                            <asp:ListItem Value="Attended">Attended</asp:ListItem>
                                            <asp:ListItem Value="Absent">Absent</asp:ListItem>
                                            <asp:ListItem Value="Late">Late</asp:ListItem>
                                        </asp:DropDownList>
		                            </ItemTemplate>
	                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Comments">
		                            <ItemTemplate>
			                            <asp:Textbox ID="txtComments" runat="server" Text='<%# Bind("comments") %>' ></asp:Textbox>
		                            </ItemTemplate>
	                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                            </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                        </asp:GridView>
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
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
