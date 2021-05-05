<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_RoleManagement.aspx.vb" Inherits="Test.Admin_RoleManagement" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Role Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        Role Name</td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtRoleName" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        Role Description</td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtRoleDesc" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        Role Type </td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtRoleType" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                </tr>
                    <%--<tr>
                    <td align="right" width="47%">
                        Password</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtpass" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox></td>
                </tr>--%>

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
                                <%--<tr>
                                    <td align="right">
                                        <asp:CheckBox ID="chkHolding" runat="server" AutoPostBack="true"
                                            CssClass="LabelMenu" Text="Search Holding" /></td>
                                    <td align="center">:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlSearchHolding" runat="server" AutoPostBack="true" 
                                            CssClass="DDSelect" Enabled="False">
                                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                            <asp:ListItem Value="AA">AA : Paper Holding</asp:ListItem>
                                            <asp:ListItem Value="PO">PO : Power Holding</asp:ListItem>
                                            <asp:ListItem Value="QS">QS : Other Holding</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>--%>
                                <tr>

                                    <h2 align = "center">Search and Edit Role Details</h2>
                                    <td align="right">
                                        Role Name</td>
                                    <td align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" 
                                            Enabled="True"></asp:TextBox>
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
                <asp:GridView ID="gvRole" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="roleId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Role ID" DataField="roleId" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Role Name" SortExpression="roleName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtroleName" runat="server" Text='<%# Bind("roleName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblroleName" runat="server" Text='<%# Bind("roleName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Role Description" SortExpression="roleDesc">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtroleDesc" runat="server" Text='<%# Bind("roleDesc") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblroleDesc" runat="server" Text='<%# Bind("roleDesc") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Role Type" SortExpression="roleType">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtroleType" runat="server" Text='<%# Bind("roleType") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblroleType" runat="server" Text='<%# Bind("roleType") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit">
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
