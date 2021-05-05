<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_ProjTask.aspx.vb" Inherits="Test.Conv_ProjTask" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Task Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td>
                            Year
                            <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="3%">&nbsp;</td>
                        <td>
                            Semester
                            <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <%--<td width="3%">&nbsp;</td>
                        <td>
                            Unit
                            <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td align="right" width="47%">Project</td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                        <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3">&nbsp;</td></tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            Task No.</td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            
                                        <asp:TextBox ID="txtTaskNo" runat="server" CssClass="textbox"></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            Task Title</td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtTaskTitle" runat="server" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            Task Description</td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtTaskDesc" runat="server" CssClass="LabelData" Height="100px" style="margin-left: 0px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            Start date
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" readonly = "true"></asp:TextBox>
                            <asp:ImageButton ID="IMbStartDate" runat="server" ImageUrl="~/icons/icon_carlendar.gif" />
                        <td align="center" valign="top" width="3%">&nbsp;</td>
                        <td align="left" valign="top" width="47%">
                            End date
                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
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
                    <tr><td colspan="3">&nbsp;</td></tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" height="20px"></td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" height="20px">
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Search by Task"></asp:Label>
                        </td>
                        <td align="center">:</td>
                        <td align="left">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
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
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="taskId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="offUnitYear" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Semester" DataField="offUnitSem" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Unit" DataField="unitStr" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Project" DataField="projName" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Task No" SortExpression="taskNo">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtTaskNo" runat="server" Text='<%# Bind("taskNo") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTaskNo" runat="server" Text='<%# Bind("taskNo") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Task Title" SortExpression="taskTitle">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtTaskTitle" runat="server" Text='<%# Bind("taskTitle") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTaskTitle" runat="server" Text='<%# Bind("taskTitle") %>' Width="200px"></asp:Label>
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
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
