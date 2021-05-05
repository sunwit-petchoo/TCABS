<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin_StuEnrolment.aspx.vb" Inherits="Test.Admin_StuEnrolment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Student Enrolment
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%">

        <tr><td align="center" colspan="5" height="20px"></td></tr>

        <tr>
            <td align="center">
            <table width="100%">
                
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="Year"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Semester"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlSemester" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Unit Code"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlUnitCode" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="true" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%" style="height: 32px">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Unit Name"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%" style="height: 32px">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%" style="height: 32px">
                        <asp:Label ID="lblUnitName" runat="server" CssClass="LabelData"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        Description</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:Label ID="lblUnitDesc" runat="server" CssClass="LabelData"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="47%">
                        Credit</td>
                    <td align="center" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                        </td>
                    <td align="left" width="50%">
                        <asp:Label ID="lblCredit" runat="server" CssClass="LabelData"></asp:Label></td>
                </tr>
                <tr><td align="center" colspan="3"></td></tr>
                
                
                <tr id="trSearchNo" runat="server">
                    <td align="right">
                        <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu" 
                            Text="Searching for add by Student ID or Name"></asp:Label>&nbsp;
                    </td>
                    <td align="center"> : </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtSearchStu" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="Btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnQuerySearch" runat="server" Visible="false">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr><td height="20px">&nbsp;</td></tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="GridViewBodyStyle">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Student ID" DataField="StuID" ReadOnly="True" />
                                                            <asp:BoundField HeaderText="Name" DataField="StuName" ReadOnly="True"/>
                                                            <asp:BoundField HeaderText="Level" DataField="stulevel" ReadOnly="True"/>
                                                            <asp:CommandField ShowSelectButton="True" />
                                                        </Columns>
                                                        <%--<SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />--%>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
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
                                <asp:Textbox ID="txtStuName" runat="server" Text='<%# Bind("stuname") %>' ></asp:Textbox>
                           </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("stuname") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Level" SortExpression="stulevel">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtLevel" runat="server" Text='<%# Bind("stulevel") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblLevel" runat="server" Text='<%# Bind("stulevel") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:CommandField ShowDeleteButton="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                </asp:GridView>
            </td>
        </tr>

        
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                <asp:Button ID="btnCancelSave" runat="server" Text="Cancel" CssClass="Btn" />
            </td>
        </tr>
        <tr><td align="center" colspan="3"><br /></td></tr>
       
        <tr>
            <td align="center" colspan="3" style="height: 20px">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label1" runat="server" CssClass="LabelMenu" Text="Student ID or Name"></asp:Label>
                                                </td>
                                                <td align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
        </tr>

         <tr><td align="center" colspan="3"><br /></td></tr>
        <tr><td colspan="3" align="center">
                                    <asp:Button ID="btnSearchForDelete" runat="server" Text="Search" />
                                    &nbsp;<asp:Button ID="btnSearchCancel" runat="server" Text="Cancel" />
                                    </td></tr>
        <tr><td align="center" colspan="3"><br /></td></tr>
    <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="enrolId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="offUnitYear" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Semester" SortExpression="offUnitSem">
                            <ItemTemplate>
                                <asp:Label ID="lblSem" runat="server" Text='<%# Bind("offUnitSem") %>' Width="80"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Unit" SortExpression="unitStr">
                            <ItemTemplate>
                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("unitStr") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="250px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Student Id" SortExpression="stuId">              
                            <ItemTemplate>
                                <asp:Label ID="lblStudent" runat="server" Text='<%# Bind("stuId") %>' Width="100px"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name" SortExpression="stuName">
                         
                            <ItemTemplate>
                                <asp:Label ID="lblStuName" runat="server" Text='<%# Bind("stuName") %>' Width="150px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="150px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                      
                        <asp:CommandField ShowDeleteButton="True"  HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataRowStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Blue" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" HorizontalAlign="Center" VerticalAlign="Top"/>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
