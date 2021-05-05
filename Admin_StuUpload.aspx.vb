Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.IO
Imports System.Configuration.ConfigurationManager

Public Class Admin_StuUpload
    Inherits Page
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Protected Sub Button1_click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Server.ClearError()
        'Dim csvFilePath As String = "C:\Users\Bharathwaj\Documents\Canvas\Sem3\DI\test csv\stu_mang.csv"
        Dim filename As String = Path.GetFileName(FileUpload1.FileName)
        Dim csvFilePath As String = Path.Combine(Server.MapPath("~/test csv"), filename)
        FileUpload1.SaveAs(csvFilePath)

        Dim dt As New DataTable()
        Dim dt1 As New DataTable()
        Dim dr1 As DataRow = dt1.NewRow()
        Dim rvPrm As MySqlParameter = New MySqlParameter



        dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Student Id", GetType(Int64)), New DataColumn("Student Name", GetType(String)), New DataColumn("Student Level", GetType(String)), New DataColumn("Student Register Date", GetType(Date))})
        dt1.Columns.AddRange(New DataColumn(4) {New DataColumn("Student Id", GetType(Int64)), New DataColumn("Student Name", GetType(String)), New DataColumn("Student Level", GetType(String)), New DataColumn("Student Register Date", GetType(Date)), New DataColumn("Status", GetType(String))})

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
            cmd.CommandText = "BULK_STUDENT_INSERT;"
            cmd.Parameters.AddWithValue("@pstuId", row.ItemArray(0))
            Dim StuID As Int64 = row.ItemArray(0)
            cmd.Parameters.AddWithValue("@pstuName", row.ItemArray(1))
            Dim StuName As String = row.ItemArray(1)
            cmd.Parameters.AddWithValue("@pstuLevel", row.ItemArray(2))
            Dim StuLevel As String = row.ItemArray(2)
            cmd.Parameters.AddWithValue("@pstuRegDate", row.ItemArray(3))
            Dim StuRegDate As Date = row.ItemArray(3)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)
            M1.Execute(SQL(0))

            Dim dr As DataRow = dt1.NewRow()
            dr("Student Id") = StuID
            dr("Student Name") = StuName
            dr("Student Level") = StuLevel
            dr("Student Register Date") = StuRegDate
            dr("Status") = resultMsg
            resultMsg = ""
            dt1.Rows.Add(dr)
        Next row

        GridView1.DataSource = dt1
        GridView1.DataBind()
    End Sub
End Class