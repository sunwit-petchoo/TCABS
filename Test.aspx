<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Test.aspx.vb" Inherits="Test.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Unit of Study
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Unit Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Unit Code"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtUnitCode" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Unit Name"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        
                        <asp:TextBox ID="txtUnitName" runat="server" Width="171px" 
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
                        <asp:TextBox ID="txtUnitName0" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        </td>
                </tr>
                    <tr>
                    <td align="right" width="47%">
                        Credit</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtName" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox></td>
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
                                    <td align="right">
                                        <asp:CheckBox ID="chkComCode" runat="server" AutoPostBack="true"
                                            CssClass="LabelMenu" Text="Search by Unit Code" /></td>
                                    <td align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtSearchUnit" runat="server" CssClass="textbox" 
                                            Enabled="False"></asp:TextBox>
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
                <asp:GridView ID="gvUnit" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="ComCode" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Unit Code" DataField="UnitCode" ReadOnly="True" >

                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Unit Name" SortExpression="ComName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtUnitName" runat="server" Text='<%# Bind("UnitName") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUnitName" runat="server" Text='<%# Bind("UnitName") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="UnitDesc">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtUnitDesc" runat="server" Text='<%# Bind("UnitDesc") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUnitDesc" runat="server" Text='<%# Bind("UnitDesc") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Credit">
                            <%--<EditItemTemplate>
                                <asp:DropDownList ID="ddlHoldingID" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="AA">AA : Paper Holding</asp:ListItem>
                                    <asp:ListItem Value="PP">PP : Power Holding</asp:ListItem>
                                    <asp:ListItem Value="QS">QS : Other Holding</asp:ListItem>
                                </asp:DropDownList>
                           </EditItemTemplate>--%>
                            <ItemTemplate>
                                <asp:Label ID="lblCredit" runat="server" Text='<%# Bind("UnitCredit") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Edit" ShowEditButton="True" >
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
