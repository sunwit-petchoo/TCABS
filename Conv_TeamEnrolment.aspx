<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_TeamEnrolment.aspx.vb" Inherits="Test.Conv_TeamEnrolment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript" language="javascript">
        function fnEnableDisblePrice(ID) {

            var gridViewControl = document.getElementById('<%= gvStudent.ClientID %>');
            var inputs = gridViewControl.getElementsByTagName("input");
            if (inputs.length > 1) {
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].id.indexOf("_chkSelect") != -1) {
                        if (inputs[i].id == ID) {
                            inputs[i].checked = true;
                        } else {
                            inputs[i].checked = false;
                        }
                    }
                }
            }

        }
    </script>
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
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text="Team"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="true" 
                            CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                            <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr id="trSearchNo" runat="server">
                    <td align="right">
                        <asp:Label ID="lblMenuSearchNo" runat="server" CssClass="LabelMenu" 
                            Text="Searching by Student ID or Name"></asp:Label>&nbsp;
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
                                                        DataKeyNames="enrolId"
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
                    DataKeyNames="enrolId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:TemplateField HeaderText="Project Manager">
		                    <ItemTemplate>
			                    <asp:CheckBox id="chkSelect" runat="server"></asp:CheckBox>
		                    </ItemTemplate>
	                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Student ID">
		                    <ItemTemplate>
			                    <asp:Label ID="lblStuId" runat="server" Text='<%# Bind("stuid") %>' Width="200px"></asp:Label>
                            </ItemTemplate>
	                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                    </asp:TemplateField>

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
        <tr><td colspan="3">&nbsp;</td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
            </td>
        </tr>
       
        <tr><td align="center" colspan="3"><br /></td></tr>
       
        <tr>
            <td align="center" colspan="3" style="height: 20px">
                                        <table>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Student ID or Name"></asp:Label>
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
                    DataKeyNames="teamEnrolId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="offUnitYear" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Sem" SortExpression="offUnitSem">
                            <ItemTemplate>
                                <asp:Label ID="lblSem" runat="server" Text='<%# Bind("offUnitSem") %>' Width="30"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Unit" SortExpression="unitStr">
                            <ItemTemplate>
                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("unitStr") %>' Width="250px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="250px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Team Name" SortExpression="teamTitle">
                            <ItemTemplate>
                                <asp:Label ID="lblTeamTitle" runat="server" Text='<%# Bind("teamTitle") %>' Width="150px"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="150px" />
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
                        <asp:TemplateField HeaderText="PM" SortExpression="pm_role">
                         
                            <ItemTemplate>
                                <asp:Label ID="lblPmRole" runat="server" Text='<%# Bind("pm_role") %>' Width="30"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
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
