<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Conv_PeerCriteria.aspx.vb" Inherits="Test.Conv_PeerCriteria" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    General Aspect Management
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
                        <asp:Label ID="Label2" runat="server" CssClass="LabelMenu" Text="General Aspect"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label8" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtGeneralAspect" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label3" runat="server" CssClass="LabelMenu" Text="Specific Aspect"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label9" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtSpecificAspect" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label6" runat="server" CssClass="LabelMenu" Text="Type"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label7" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                                <asp:ListItem Value="1">Scoring</asp:ListItem>
                                <asp:ListItem Value="2">Budgeting</asp:ListItem>
                            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label10" runat="server" CssClass="LabelMenu" Text="Minimum"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label11" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtMin" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="47%">
                        <asp:Label ID="Label12" runat="server" CssClass="LabelMenu" Text="Maximum"></asp:Label>
                    </td>
                    <td align="center" valign="top" width="3%">
                        <asp:Label ID="Label13" runat="server" CssClass="LabelMenu" Text=":"></asp:Label>
                    </td>
                    <td align="left" width="50%">
                        <asp:TextBox ID="txtMax" runat="server" Width="171px" 
                            Font-Size="8pt" CssClass="textbox" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr>
                    <td colspan="3">
                        <center>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="Btn" />
                        </center>
                    </td>
                </tr>
                <tr><td colspan="3">&nbsp;</td></tr>
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="pnAdd" runat="server" Visible="false">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr><td height="20px">&nbsp;</td></tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:GridView ID="gvAdd" runat="server" AutoGenerateColumns="False" 
                                                        DataKeyNames="criteriaItem" CssClass="GridViewBodyStyle">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Specific Aspect">
		                                                        <ItemTemplate>
			                                                        <asp:Label ID="lblCriteriaItem" runat="server" Text='<%# Bind("criteriaItem") %>'></asp:Label>
                                                                </ItemTemplate>
	                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Type">
		                                                        <ItemTemplate>
			                                                        <asp:Label ID="lblType" runat="server" Text='<%# Bind("scoreType") %>'></asp:Label>
                                                                </ItemTemplate>
	                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Minimum">
		                                                        <ItemTemplate>
			                                                        <asp:Label ID="lblMin" runat="server" Text='<%# Bind("scoreMin") %>'></asp:Label>
                                                                </ItemTemplate>
	                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                                                        </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Maximum">
		                                                        <ItemTemplate>
			                                                        <asp:Label ID="lblMax" runat="server" Text='<%# Bind("scoreMax") %>'></asp:Label>
                                                                </ItemTemplate>
	                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
	                                                        </asp:TemplateField>
                                                            <asp:CommandField ShowDeleteButton="True" />
                                                        </Columns>
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr><td height="20px">&nbsp;</td></tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="Btn" />&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="Btn" />
                    </td>
                </tr>
                </table>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3" height="20px">
                <table>
                    <tr>
                        <td align="right">Search by Year</td>
                        <td align="center">:</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlYearSearch" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">Search by Semester</td>
                        <td align="center">:</td>
                        <td align="left">
                            <asp:DropDownList ID="ddlSemSearch" runat="server" AutoPostBack="true" 
                                CssClass="DDSelect" Enabled="True" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">[--Please Select--]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr><td colspan="3">&nbsp;</td></tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" />
                            &nbsp;
                            <asp:Button ID="btnSearchCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td align="center" colspan="3"></td></tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="categoryId, criteriaId" 
                    AllowPaging="True" CssClass="GridViewBodyStyle" 
                    EmptyDataText="---No Record---">
                    <Columns>
                        <asp:BoundField HeaderText="Year" DataField="offUnitYear" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Semester" DataField="offUnitSem" ReadOnly="True" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="General Aspect" SortExpression="categoryItem">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtCategory" runat="server" Text='<%# Bind("categoryItem") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("categoryItem") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Specific Aspect" SortExpression="tmRolName">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtCriteria" runat="server" Text='<%# Bind("criteriaItem") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCriteria" runat="server" Text='<%# Bind("criteriaItem") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" SortExpression="scoreType">
                            <EditItemTemplate>
                                <asp:Textbox ID="txtType" runat="server" Text='<%# Bind("scoreType") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("scoreType") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Minimum" SortExpression="scoreMin">
                            <EditItemTemplate>
                                <asp:Textbox ID="Textbox1" runat="server" Text='<%# Bind("scoreMin") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("scoreMin") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Maximum" SortExpression="scoreMax">
                            <EditItemTemplate>
                                <asp:Textbox ID="Textbox2" runat="server" Text='<%# Bind("scoreMax") %>' ></asp:Textbox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("scoreMax") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="200px" />
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
        <tr><td align="center" colspan="3"></td></tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="Head">
    </asp:Content>

