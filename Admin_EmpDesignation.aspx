<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_EmpDesignation.aspx.vb" Inherits="Test.Admin_EmpDesignation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Employee Designation
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        Employee Id</td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlEmpolyee" runat="server" AutoPostBack="true"
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <%-- <tr>
                    <td align="right" valign="top" width="47%">
                         Name</td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">

                        <asp:Label ID="lblEmpName" runat="server" CssClass="LabelData"></asp:Label>

                    </td>
                </tr> --%>
                    <%-- <tr>
                    <td align="right" width="47%">
                        Role Description</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtRoleDesc" runat="server" Width="171px"
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                </tr> --%>
                <tr>
                    <td align="right" width="47%">
                        Role </td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true"
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>

                    <tr><td align="center" colspan="3">
                        <br />
                        </td></tr>
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
                                    <td align="right" style="height: 40px">
                                        Search By Employee ID or Name</td>
                                    <td align="center" style="height: 40px">:</td>
                                    <td align="left" style="height: 40px">
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
                <asp:GridView ID="gvEmpDes" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="empEnrolId"
                    AllowPaging="True" CssClass="GridViewBodyStyle"
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Employee Id" DataField="empId" ReadOnly="True" >

                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Employee Name" SortExpression="empName">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("empName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Role" SortExpression="roleName">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlRoleEdit" runat="server" AutoPostBack="True">
                                  <asp:ListItem Value="">[--Please Select--]</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRole" runat="server" Text='<%# Bind("roleName") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
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
                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"  />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
