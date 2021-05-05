<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Supervisor_MeetingSetup.aspx.vb" Inherits="Test.Supervisor_MeetingSetup" %>
<asp:Content ID = "Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Meeting Management
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
                            <asp:Label ID="Label16" runat="server" CssClass="LabelMenu" Text="Meeting Topic"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label18" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtMeetingTopic" runat="server" Width="171px"
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text="Meeting Date"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtStartDate" runat="server" Width="171px"
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                            <asp:ImageButton ID="IMbStartDate" runat="server" ImageUrl="~/icons/icon_carlendar.gif"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                        <td align="left">
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White"
                                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest"
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px"
                                Width="200px" Visible="False">
                                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt"/>
                                <NextPrevStyle VerticalAlign="Bottom"/>
                                <OtherMonthDayStyle ForeColor="#808080"/>
                                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White"/>
                                <SelectorStyle BackColor="#CCCCCC"/>
                                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True"/>
                                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black"/>
                                <WeekendDayStyle BackColor="#FFFFCC"/>
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table>
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Start Time"></asp:Label>
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlStartHr" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="01">01</asp:ListItem>
                                            <asp:ListItem Value="02">02</asp:ListItem>
                                            <asp:ListItem Value="03">03</asp:ListItem>
                                            <asp:ListItem Value="04">04</asp:ListItem>
                                            <asp:ListItem Value="05">05</asp:ListItem>
                                            <asp:ListItem Value="06">06</asp:ListItem>
                                            <asp:ListItem Value="07">07</asp:ListItem>
                                            <asp:ListItem Value="08">08</asp:ListItem>
                                            <asp:ListItem Value="09">09</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                        <asp:DropDownList ID="ddlStartMin" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                        </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlStart" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="am">am</asp:ListItem>
                                            <asp:ListItem Value="pm">pm</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>&nbsp;</td>
                        <td align="left">
                            <table>
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="End Time"></asp:Label>
                                    </td>
                                    <td align="center" valign="top">
                                        <asp:Label ID="Label14" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEndHr" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="01">01</asp:ListItem>
                                            <asp:ListItem Value="02">02</asp:ListItem>
                                            <asp:ListItem Value="03">03</asp:ListItem>
                                            <asp:ListItem Value="04">04</asp:ListItem>
                                            <asp:ListItem Value="05">05</asp:ListItem>
                                            <asp:ListItem Value="06">06</asp:ListItem>
                                            <asp:ListItem Value="07">07</asp:ListItem>
                                            <asp:ListItem Value="08">08</asp:ListItem>
                                            <asp:ListItem Value="09">09</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label ID="Label15" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                                        <asp:DropDownList ID="ddlEndMin" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="00">00</asp:ListItem>
                                            <asp:ListItem Value="15">15</asp:ListItem>
                                            <asp:ListItem Value="30">30</asp:ListItem>
                                            <asp:ListItem Value="45">45</asp:ListItem>
                                        </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlStop" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="am">am</asp:ListItem>
                                            <asp:ListItem Value="pm">pm</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td align="right" width="47%">Location</td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtLocation" runat="server" Width="171px"
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3">&nbsp;</td></tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="Btn"/>&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn"/>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3">&nbsp;</td></tr>
                    <tr id="trSearchNo" runat="server">
                        <td align="right">
                            <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu"
                                Text="Searching by Meeting Status"></asp:Label>&nbsp;
                    </td>
                        <td align="center"> : </td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="true"
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                <asp:ListItem Value="Created">Created</asp:ListItem>
                                <asp:ListItem Value="Canceled">Canceled</asp:ListItem>
                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                            </asp:DropDownList>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Btn"/>
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
                                                        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False"
                                                            DataKeyNames="meetingId"
                                                            AllowPaging="True" CssClass="GridViewBodyStyle"
                                                            EmptyDataText="---No Record---">
                                                            <Columns>
                                                            <asp:BoundField HeaderText="Project" DataField="projName" ReadOnly="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:BoundField>

                                                            <asp:BoundField HeaderText="Team" DataField="teamTitle" ReadOnly="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:BoundField>

                                                            <asp:TemplateField HeaderText="Topic" SortExpression="meetingTopic">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtMeeting" runat="server" Text='<%# Bind("meetingTopic") %>' ></asp:Textbox>
                                                               </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMeeting" runat="server" Text='<%# Bind("meetingTopic") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Date" SortExpression="meetingDate">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtMeetingDate" runat="server" Text='<%# Bind("dateStr") %>' TextMode="Date"></asp:Textbox>
                                                               </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMeetingDate" runat="server" Text='<%# Bind("dateStr") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Start Time" SortExpression="startTime">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtStartTime" runat="server" Text='<%# Bind("startTime") %>' TextMode="Time"></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("startTime") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="End Time" SortExpression="endTime">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="txtEndTime" runat="server" Text='<%# Bind("endTime") %>' TextMode="Time"></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("endTime") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Location" SortExpression="location">
                                                                <EditItemTemplate>
                                                                    <asp:Textbox ID="Textbox1" runat="server" Text='<%# Bind("location") %>' ></asp:Textbox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("location") %>' ></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>

                                                            <asp:BoundField HeaderText="Status" DataField="meetingStatus" ReadOnly="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:BoundField>

                                                            <asp:CommandField ShowEditButton="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:CommandField>

                                                            <asp:CommandField ShowDeleteButton="True" >
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:CommandField>
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
                        </asp:Panel>
                    </td>
                </tr>
                <tr><td align="center" colspan="3" height="20px"></td></tr>
            </table>
            </td>
        </tr>
    </table>
</asp:Content>
