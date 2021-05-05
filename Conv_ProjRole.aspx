<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_ProjRole.aspx.vb" Inherits="Test.Conv_ProjRole" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Set Up Team Role
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
                        <%--<td width="3%">&nbsp;</td>
                        <td>
                            Unit
                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text=":"></asp:Label><br/>
                            <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
            <table width="100%">
                <tr><td colspan="3">&nbsp;</td></tr>
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
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Role Name"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtRole" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        Cost</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtCost" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox> /Hour
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>

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
                                        Search by Project Name/Role
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
                    DataKeyNames="tmRolId" 
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

                        <asp:TemplateField HeaderText="Project" SortExpression="projName">
                            <%--<EditItemTemplate>
                                <asp:Textbox ID="txtProjName" runat="server" Text='<%# Bind("projName") %>' ></asp:Textbox>
                           </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblProjName" runat="server" Text='<%# Bind("projName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Role" SortExpression="tmRolName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtRole" runat="server" Text='<%# Bind("tmRolName") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server" Text='<%# Bind("tmRolName") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cost" SortExpression="tmRolName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtCost" runat="server" Text='<%# Bind("tmRolCost") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCost" runat="server" Text='<%# Bind("tmRolCost") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="100px" />
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
        <tr><td align="center" colspan="3"></td></tr>
    </table>
</asp:Content>
