<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_PeerSetup.aspx.vb" Inherits="Test.Conv_PeerSetup" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Peer Assessment Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>
        <tr>
            <td align="center" colspan="5">
                <table>
                    <tr>
                        <td>
                            Year
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="3%">&nbsp;</td>
                        <td>
                            Semester
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                    CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                    <asp:ListItem Value="1">Scoring</asp:ListItem>
                    <asp:ListItem Value="2">Budgeting</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="Peer Assessment No."></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="txtPeerNo" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Peer Assessment Name"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:TextBox ID="txtPeerName" runat="server" Width="171px" 
                    Font-Size="8pt" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" width="47%">
                Start date
                <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" readonly = "true"></asp:TextBox>
                <asp:ImageButton ID="IMbStartDate" runat="server" ImageUrl="~/icons/icon_carlendar.gif" />
            <td align="center" valign="top" width="3%">&nbsp;</td>
            <td align="left" valign="top" width="47%">
                End date
                <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" readonly = "true"></asp:TextBox>
                <asp:ImageButton ID="IMbEndDate" runat="server" ImageUrl="~/icons/icon_carlendar.gif" />
            </td>
        </tr>
        <tr id="trCalendar1" visible="false">
            <td align="right">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                    Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td>&nbsp;</td>
            <td align="left">
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                    Width="200px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
        </tr>
        <tr id="trCriteria" runat="server"><td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="criteriaId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>

                        <asp:TemplateField HeaderText="Select">
		                    <ItemTemplate>
			                    <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>
		                    </ItemTemplate>
	                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="General Aspect" SortExpression="categoryItem">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtGA" runat="server" Text='<%# Bind("categoryItem") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblGA" runat="server" Text='<%# Bind("categoryItem") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Specific Aspect" SortExpression="criteriaItem">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtSA" runat="server" Text='<%# Bind("criteriaItem") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSA" runat="server" Text='<%# Bind("criteriaItem") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td></tr>
        
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>

