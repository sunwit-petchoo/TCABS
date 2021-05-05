<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_StuManagement.aspx.vb" Inherits="Test.Admin_StuManagement" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Student Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Student ID"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                            <asp:TextBox ID="txtStuID" runat="server" Width="171px" 
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="47%">
                            <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Student Name"></asp:Label>
                        </td>
                        <td align="center" valign="top" width="3%">
                            <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                        <td align="left" width="50%">
                        
                            <asp:TextBox ID="txtStuName" runat="server" Width="171px" 
                                Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="47%">
                            
                            <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text="Student Level"></asp:Label>
                            
                        </td>
                        <td align="center" width="3%">
                            <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                            </td>
                        <td align="left" width="50%">
                            <asp:DropDownList ID="ddlStudentLevel" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="none">[--Please Select--]</asp:ListItem>
                                <asp:ListItem Value="Certificate">Certificate</asp:ListItem>
                                <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                <asp:ListItem Value="Bachelor">Bachelor</asp:ListItem>
                                <asp:ListItem Value="Master">Master</asp:ListItem>
                                <asp:ListItem Value="PhD">PhD</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td align="center" colspan="3">&nbsp;</td></tr>
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
                            <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Search by Student ID or Name"></asp:Label>
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
                </table>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="stuid" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Student ID" DataField="stuid" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Student Name" SortExpression="stuname">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtStuName" runat="server" Text='<%# Bind("StuName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("StuName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Student Level">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlStuLevel" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="Certificate">Certificate</asp:ListItem>
                                    <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                    <asp:ListItem Value="Bachelor">Bachelor</asp:ListItem>
                                    <asp:ListItem Value="Master">Master</asp:ListItem>
                                    <asp:ListItem Value="PhD">PhD</asp:ListItem>
                                </asp:DropDownList>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStuLevel" runat="server" Text='<%# Bind("stulevel") %>' Width="100px"></asp:Label>
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
