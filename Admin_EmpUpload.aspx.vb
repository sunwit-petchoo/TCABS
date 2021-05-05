Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Configuration.ConfigurationManager

Public Class Admin_EmpUpload
    Inherits Page
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Public Sub Button1_click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Server.ClearError()
        Dim EmpID As Integer
        Dim EmpName As String
        Dim EmpEmail As String
        Dim rvPrm As MySqlParameter = New MySqlParameter

        'Dim csvFilePath As String = "C:\Users\Bharathwaj\Documents\Canvas\Sem3\DI\test csv\emp_mang.csv"
        Dim filename As String = Path.GetFileName(FileUpload1.FileName)
        Dim csvFilePath As String = Path.Combine(Server.MapPath("~/test csv"), filename)

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dr1 As DataRow = dt1.NewRow()

        dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Employee Id", GetType(Int64)), New DataColumn("Employee Name", GetType(String)), New DataColumn("Employee Email", GetType(String))})
        dt1.Columns.AddRange(New DataColumn(3) {New DataColumn("Employee Id", GetType(Int64)), New DataColumn("Employee Name", GetType(String)), New DataColumn("Employee Email", GetType(String)), New DataColumn("Status", GetType(String))})
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
            cmd.CommandText = "BULK_EMPLOYEE_INSERT;"
            cmd.Parameters.AddWithValue("@pempId", row.ItemArray(0))
            EmpID = row.ItemArray(0)
            cmd.Parameters.AddWithValue("@pempName", row.ItemArray(1))
            EmpName = row.ItemArray(1)
            cmd.Parameters.AddWithValue("@pempEmail", row.ItemArray(2))
            EmpEmail = row.ItemArray(2)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            M1.Execute(SQL(0))

            Dim dr As DataRow = dt1.NewRow()
            dr("Employee Id") = EmpID
            dr("Employee Name") = EmpName
            dr("Employee Email") = EmpEmail
            dr("Status") = resultMsg
            resultMsg = ""

            dt1.Rows.Add(dr)
        Next row

        GridView1.DataSource = dt1
        GridView1.DataBind()
    End Sub
End Class