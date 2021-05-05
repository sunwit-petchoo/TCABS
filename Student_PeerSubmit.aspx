<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_PeerSubmit.aspx.vb" Inherits="Test.Student_PeerSubmit" %>
<%-- <asp:Content ID="Content1" ContentPlaceHolderID="TopHeader" runat="server">
    Student
</asp:Content> --%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Accept Task Submission
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>
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
                <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Peer Assessment"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                <asp:DropDownList ID="ddlPeer" runat="server" AutoPostBack="true" 
                    CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td align="right" valign="top" width="47%">
                <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Comment"></asp:Label>
            </td>
            <td align="center" valign="top" width="3%">
                <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
            </td>
            <td align="left" width="50%">
                            <asp:TextBox ID="txtComment" runat="server" Width="300px" Height="100px"
                                Font-Size="8pt" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td colspan="3">
                <center>
                <asp:GridView ID="gv_Show" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="peerDetailId" EmptyDataText="---No Record---" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="categoryItem" HeaderText="General Aspect">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="criteriaItem" HeaderText="Specific Aspect">
                            <HeaderStyle Font-Bold="True" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Score" SortExpression="startTime">
                            <ItemTemplate>
                                <asp:Textbox ID="txtScore" runat="server" Text="" TextMode="Number"></asp:Textbox>
                                &nbsp;&nbsp;
                                <asp:label ID="lblMaxMin" runat="server" Text='<%# Bind("minmaxStr") %>' ></asp:label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="DeepSkyBlue" ForeColor="White" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" Font-Bold="False" />
                </asp:GridView>
                </center>
            </td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
            </td>
        </tr>
    </table>
    </center>
</asp:Content>
