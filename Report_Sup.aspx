<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Report_Sup.aspx.vb" Inherits="Test.Report_Sup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
    .mydatagrid
    {
    width: 80%;
    border: solid 2px black;
    min-width: 80%;
    }
    .header
    {
    background-color: #646464;
    font-family: Arial;
    color: White;
    border: none 0px transparent;
    height: 25px;
    text-align: center;
    font-size: 16px;
    }

    .rows
    {
    background-color: #fff;
    font-family: Arial;
    font-size: 14px;
    color: #000;
    min-height: 25px;
    text-align: left;
    border: none 0px transparent;
    }
    .rows:hover
    {
    background-color: #ff8000;
    font-family: Arial;
    color: #fff;
    text-align: left;
    }
    .selectedrow
    {
    background-color: #ff8000;
    font-family: Arial;
    color: #fff;
    font-weight: bold;
    text-align: left;
    }
    .mydatagrid a /** FOR THE PAGING ICONS **/
    {
    background-color: Transparent;
    padding: 5px 5px 5px 5px;
    color: #fff;
    text-decoration: none;
    font-weight: bold;
    }

    .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
    {
    background-color: #000;
    color: #fff;
    }
    .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
    {
    background-color: #c9c9c9;
    color: #000;
    padding: 5px 5px 5px 5px;
    }
    .pager
    {
    background-color: #646464;
    font-family: Arial;
    color: White;
    height: 30px;
    text-align: left;
    }

    .mydatagrid td
    {
    padding: 5px;
    }
    .mydatagrid th
    {
    padding: 5px;
    }
    </style>
    
    <script>
        function exportTableToExcel(tableID, filename = '') {
            var downloadLink;
            var dataType = 'application/vnd.ms-excel';
            var tableSelect = document.getElementById(tableID);
            var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

            filename = filename ? filename : 'excel_data';
            downloadLink = document.createElement("a");
            document.body.appendChild(downloadLink);

            if (navigator.msSaveOrOpenBlob) {
                var blob = new Blob(['\ufeff', tableHTML], {
                    type: dataType
                });
                navigator.msSaveOrOpenBlob(blob, filename);
            } else {
                downloadLink.href = 'data:' + dataType + ', ' + tableHTML;
                downloadLink.download = filename;
                downloadLink.click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainHeader" runat="server">
    Report - Enrolled Students
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <asp:GridView ID="gvDetails" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" EmptyDataText="---No Registered Convenors---">
    </asp:GridView>
    <button onclick="exportTableToExcel('gvDetails')">Export Table Data To Excel File</button>
    </center>
</asp:Content>
