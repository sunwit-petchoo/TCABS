<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Student_TaskAccept.aspx.vb" Inherits="Test.Student_TaskAccept" %>
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
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gv_Show" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="---No Record---" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Student Details">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label5" runat="server" CssClass="LabelMenu" Text="ID :"></asp:Label>
                                            <asp:Label ID="LB_EmpID" runat="server" Text='<%# Bind("stuId") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label17" runat="server" CssClass="LabelMenu" Text="Name :"></asp:Label>
                                            <asp:Label ID="LB_EmpName" runat="server" Text='<%# Bind("stuName") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Task Description">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="Task :"></asp:Label>
                                            <asp:Label ID="Label20" runat="server" Text='<%# Bind("taskTitle") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label19" runat="server" CssClass="LabelMenu" Text="Task Desc :"></asp:Label>
                                            <asp:Label ID="LB_TrueNo" runat="server" Text='<%# Bind("taskDesc") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label14" runat="server" CssClass="LabelMenu" Text="Role :"></asp:Label>
                                            <asp:Label ID="LB_TrueComp" runat="server" Text='<%# Bind("tmRolName") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label16" runat="server" CssClass="LabelMenu" Text="Minutes Taken :"></asp:Label>
                                            <asp:TextBox ID="txtMinuteTaken" runat="server" Text='<%# Bind("minutesTaken") %>' TextMode="Number"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 10px">
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="submitDate" HeaderText="Submit Date">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="stuName" HeaderText="Submit By" Visible="False">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="taskStatus" HeaderText="Status">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px" Wrap="False" />
                        </asp:BoundField>              
                        <asp:TemplateField HeaderText="Your Approve">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 1px">
                                    <tr>
                                        <td align="left" style="height: 16px">
                                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Action Status :"></asp:Label><br />
                                        <asp:RadioButtonList ID="RAD_YourApprove" runat="server" RepeatDirection="Horizontal" Width="170px" Font-Names="Verdana" Font-Size="8pt">
                                            <asp:ListItem Value="approved">Approve</asp:ListItem>
                                            <asp:ListItem Value="unapproved">Unapprove</asp:ListItem>
                                            <asp:ListItem Value="resubmit">Resubmit</asp:ListItem>
                                        </asp:RadioButtonList>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                            <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text="Comment :"></asp:Label><br />
                                            <asp:TextBox ID="TB_Comment" runat="server"  ForeColor="Blue" Font-Names="vernada" Font-Size="8" Width="164px" Height="52px" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="height: 16px">
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" VerticalAlign="Top" />
                        </asp:TemplateField>  
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sttApp" HeaderText="sttApp" Visible="False">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle BackColor="DeepSkyBlue" ForeColor="White" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" Font-Bold="False" />
                </asp:GridView>
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
