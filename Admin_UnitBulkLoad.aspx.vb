Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Configuration.ConfigurationManager

Public Class Admin_UnitBulkLoad
    Inherits Page
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Protected Sub Button1_click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Server.ClearError()
        'Dim csvFilePath As String = "C:\Users\Bharathwaj\Documents\Canvas\Sem3\DI\test csv\unit_mang.csv"
        Dim filename As String = Path.GetFileName(FileUpload1.FileName)
        Dim csvFilePath As String = Path.Combine(Server.MapPath("~/test csv"), filename)
        FileUpload1.SaveAs(csvFilePath)

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dr1 As DataRow = dt1.NewRow()
        Dim rvPrm As MySqlParameter = New MySqlParameter

        dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Unit Code", GetType(String)), New DataColumn("Unit Name", GetType(String)), New DataColumn("Unit Description", GetType(String)), New DataColumn("Unit Credit", GetType(Decimal))})
        dt1.Columns.AddRange(New DataColumn(4) {New DataColumn("Unit Code", GetType(String)), New DataColumn("Unit Name", GetType(String)), New DataColumn("Unit Description", GetType(String)), New DataColumn("Unit Credit", GetType(Decimal)), New DataColumn("Status", GetType(String))})
        Dim csvData As String = File.ReadAllText(csvFilePath)

        For Each row As String In csvData.Split(ControlChars.Lf)
            If Not String.IsNullOrEmpty(row) Then
                dt.Rows.Add()
                Dim i As Integer = 0
                For Each cell As String In row.Split(","c)
                    dt.Rows(dt.Rows.Count - 1)(i) = cell
                    i += 1
                Next
            End If
        Next

        For Each row As DataRow In dt.Rows
            cmd.CommandText = "BULK_UNIT_INSERT;"
            cmd.Parameters.AddWithValue("@punitId", row.ItemArray(0))
            Dim UnitId As String = row.ItemArray(0)
            cmd.Parameters.AddWithValue("@pUnitName", row.ItemArray(1))
            Dim UnitName As String = row.ItemArray(1)
            cmd.Parameters.AddWithValue("@pUnitDesc", row.ItemArray(2))
            Dim UnitDesc As String = row.ItemArray(2)
            cmd.Parameters.AddWithValue("@pUnitCre", row.ItemArray(3))
            Dim UnitCre As Decimal = row.ItemArray(3)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)
            M1.Execute(SQL(0))
            cmd.Parameters.Clear()


            Dim dr As DataRow = dt1.NewRow()
            dr("Unit Code") = UnitId
            dr("Unit Name") = UnitName
            dr("Unit Description") = UnitDesc
            dr("Unit Credit") = UnitCre
            dr("Status") = resultMsg
            resultMsg = ""
            dt1.Rows.Add(dr)
        Next row

        GridView1.DataSource = dt1
        GridView1.DataBind()
    End Sub
End Class