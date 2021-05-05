<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_EmpManagement.aspx.vb" Inherits="Test.Admin_EmpManagement" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Employee Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Employee Id"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtemployeeId" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Employee Name"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtempName" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        Email </td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtemailId" runat="server" Width="171px" type="email"
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

                                    <h2 align = "center">Search and Edit Employee Details</h2>
                                    <td align="right">
                                        Employee Name or ID</td>
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
                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="empId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Empolyee ID" DataField="empId" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Employee Name" SortExpression="empName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtEmpName" runat="server" Text='<%# Bind("empName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("empName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Email" SortExpression="empEmail">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtEmpEmail" runat="server"  Text='<%# Bind("empEmail") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmpEmail" runat="server" Text='<%# Bind("empEmail") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>

                        <asp:CommandField ShowDeleteButton="True"  >
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
