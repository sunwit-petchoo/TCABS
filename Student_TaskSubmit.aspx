<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_TaskSubmit.aspx.vb" Inherits="Test.Student_TaskSubmit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Submit Individual Task
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text="Project"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text="Team"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:Label ID="lblTeam" runat="server" CssClass="LabelMenu"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Task"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlTask" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text="Role"></asp:Label>
                        </td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Minutes Taken"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtMinutes" runat="server" Width="100px" 
                                Font-Size="8pt" CssClass="textbox" TextMode="Number"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Minutes"></asp:Label>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" class="auto-style1"></td></tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3" height="20px"></td></tr>
                    <tr>
                        <td align="center" colspan="3" height="20px">
                            <table width="100%">
                                <tr>
                                    <td align="right" width="47%">
                                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Search by Project"></asp:Label>
                                    </td>
                                    <td align="center" width="3%">:</td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlSearchProject" runat="server" AutoPostBack="true" 
                                            CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">[-- All --]</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="47%">
                                        <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Search by Task"></asp:Label>
                                    </td>
                                    <td align="center" width="3%">:</td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlSearchTask" runat="server" AutoPostBack="true" 
                                            CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                                            <asp:ListItem Value="0">[-- All --]</asp:ListItem>
                                        </asp:DropDownList>
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
                    DataKeyNames="submitId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>

                        <asp:TemplateField HeaderText="Project" SortExpression="projName">
                            <ItemTemplate>
                                <asp:Label ID="lblProject" runat="server" Text='<%# Bind("projName") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Task" SortExpression="stuname">
                            
                            <ItemTemplate>
                                <asp:Label ID="lblTask" runat="server" Text='<%# Bind("taskTitle") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Role" SortExpression="tmRolName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server" Text='<%# Bind("tmRolName") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Minutes" SortExpression="minutesTaken">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtMin" runat="server" Text='<%# Bind("minutesTaken") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblMin" runat="server" Text='<%# Bind("minutesTaken") %>' Width="30px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" SortExpression="taskStatus">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("taskStatus") %>' Width="80px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Comment" SortExpression="comment">
                            <ItemTemplate>
                                <asp:Label ID="lblComment" runat="server" Text='<%# Bind("comment") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" >
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
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</asp:Content>

