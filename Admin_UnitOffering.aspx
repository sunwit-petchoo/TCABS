<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_UnitOffering.aspx.vb" Inherits="Test.Admin_UnitOffering" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Unit Offering
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td align="right" width="47%">
                            Unit </td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Year"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Semester"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                        
                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                            </asp:DropDownList>
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            Convenor</td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlConvenor" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Room No."></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtRoomNo" runat="server" Width="171px" 
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
                            <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" readonly = "true"></asp:TextBox>
                            <asp:ImageButton ID="IMbEndDate" runat="server" ImageUrl="~/icons/icon_carlendar.gif" />
                        </td>
                    </tr>
                    <tr id="trCalendar1">
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
                    <tr><td align="center" colspan="3"></td></tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" height="20px"></td></tr>
                    <tr>
                        <td align="center" colspan="3" height="20px">
                            <table>
                                <tr>
                                    <td align="center" colspan="3" height="20px">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Search by unit code or name"></asp:Label>
                                                </td>
                                                <td align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td colspan="3">&nbsp;</td></tr>
                                <tr><td colspan="3" align="center">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" />
                                    &nbsp;<asp:Button ID="btnSearchCancel" runat="server" Text="Cancel" />
                                    </td></tr>
                            </table>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" height="20px"></td></tr>
                </table>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="offUnitId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Unit" DataField="unitStr" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Year" SortExpression="offUnitYear">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlYearEdit" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblYear" runat="server" Text='<%# Bind("offUnitYear") %>' Width="80"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Semester" SortExpression="offUnitSem">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlSemesterEdit" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                            </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSem" runat="server" Text='<%# Bind("offUnitSem") %>' Width="50px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Convenor" SortExpression="empEnrolId">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlConvenorEdit" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblConv" runat="server" Text='<%# Bind("EmpName") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start date" SortExpression="offUnitStart">
                            <ItemTemplate>
                                <asp:Label ID="lbloffUnitStart" runat="server" Text='<%# Bind("dateStartStr") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End date" SortExpression="offUnitEnd">
                            <ItemTemplate>
                                <asp:Label ID="lbloffUnitEnd" runat="server" Text='<%# Bind("dateEndStr") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                         <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True"  HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"/>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
