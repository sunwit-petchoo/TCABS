<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_EnrolBulk.aspx.vb" Inherits="Test.Admin_EnrolBulk" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Enrolment Management
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">
        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Upload CSV File"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        &nbsp;</td>
                    <td align="center" valign="top" width="3%">
                        &nbsp;</td>
                    <td align="left" width="50%">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        &nbsp;</td>
                    <td align="center" width="3%">
                        &nbsp;</td>
                    <td align="left" width="50%">
                        <asp:Button ID="Button1" runat="server" Text="Upload" />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align ="center" colspan ="3" >
                        <asp:GridView ID="GridView1" runat="server">  
                    </asp:GridView>
                   
                    </td>
                </tr>

             
    </table>
</asp:Content>
