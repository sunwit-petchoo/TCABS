<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_ProjManagement.aspx.vb" Inherits="Test.Conv_ProjManagement" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Project Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" class="auto-style1"></td></tr>
        <tr>
            <td align="center" colspan="5">
                <table>
                    <tr>
                        <td>
                            Year
                            <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td width="3%">&nbsp;</td>
                        <td>
                            Semester
                            <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <%--<td width="3%">&nbsp;</td>
                        <td>
                            Unit
                            <asp:Label ID="Label4" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td colspan="5">&nbsp;</td></tr>
        <tr>
            <td colspan="5" align="center">
                <table>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Project Name"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                        
                            <asp:TextBox ID="txtProjName" runat="server" Width="171px" 
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            Description</td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtProjDesc" runat="server" Width="171px" 
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
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
                                    <td align="right">
                                        Search by Project Name
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
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="projId" 
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

                        <asp:TemplateField HeaderText="Project Name" SortExpression="projName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtProjName" runat="server" Text='<%# Bind("projName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblProjName" runat="server" Text='<%# Bind("projName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="projDesc">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtDesc" runat="server" Text='<%# Bind("projDesc") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("projDesc") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
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
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>

