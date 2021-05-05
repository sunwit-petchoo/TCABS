Imports MySql.Data.MySqlClient

Public Class Admin_StuEnrolment
    Inherits System.Web.UI.Page

    Sub ClearValue()
        lblCredit.Text = ""
        lblUnitDesc.Text = ""
        lblUnitName.Text = ""
        DT_Student.Clear()
        DT.Clear()
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlUnitCode.Items.Clear()
        ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
    End Sub

    Function check() As Boolean
        Dim chk As String = 1

        If ddlYear.SelectedItem.Value = "0" Then
            Me.ddlYear.Focus()
            alert("Please select year")
            chk = 0
        ElseIf ddlSemester.SelectedItem.Value = "0" Then
            Me.ddlSemester.Focus()
            alert("Please select semester")
            chk = 0
        ElseIf ddlUnitCode.SelectedItem.Value = "0" Then
            Me.ddlUnitCode.Focus()
            alert("Please select unit")
            chk = 0
        ElseIf Me.gvStudent.Rows.Count = 0 Then
            alert("Please search and select student to enrol")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    '--load Year for dropdown
    Sub loadYear()
        Dim nowYear As Integer = Date.Now.Year
        Dim nextYear = nowYear + 1
        Dim nextYearStr = nextYear.ToString
        Dim nowYearStr = nowYear.ToString
        SQL(0) = "select distinct(offUnitYear) from offeredunit where offUnitYear = " & nowYearStr & " or offUnitYear = " & nextYearStr
        DT = M1.GetDatatable(SQL(0))
        ddlYear.DataSource = DT
        ddlYear.DataTextField = "offUnitYear"
        ddlYear.DataValueField = "offUnitYear"
        ddlYear.DataBind()

    End Sub

    Sub loaddata()
        SQL(0) = " Select a.enrolId, c.offUnitYear, c.offUnitSem, concat(d.unitId, ' - ', d.unitName) as unitStr,  " _
                & " b.stuId, b.stuName from enrolment a " _
                & " join student b on a.stuId = b.stuId " _
                & " join offeredunit c on a.offUnitId = c.offUnitId " _
                & " join unit d on c.unitId = d.unitId " _
                & " order by offUnitYear, offUnitSem, unitStr, stuId "


        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            loaddata()
        End If
    End Sub

#Region "Unit"

    Protected Sub ddlUnitCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnitCode.SelectedIndexChanged
        Dim selectedUnit = ddlUnitCode.SelectedItem.Text
        SQL(0) = "select unitname,unitDesc,unitCredit from unit where unitId = '" & selectedUnit & "'"
        DT = M1.GetDatatable(SQL(0))
        lblUnitName.Text = DT.Rows(0).Item(0)
        lblUnitDesc.Text = DT.Rows(0).Item(1)
        lblCredit.Text = DT.Rows(0).Item(2)

    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "select distinct(offUnitSem) from offeredunit where offUnitYear = " & selectedYear
        DT = M1.GetDatatable(SQL(0))
        ddlSemester.DataSource = DT
        ddlSemester.DataTextField = "offUnitSem"
        ddlSemester.DataValueField = "offUnitSem"
        ddlSemester.DataBind()
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        Dim selectedSem = ddlSemester.SelectedItem.Value
        ddlUnitCode.Items.Clear()
        ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "select unitId,offUnitId from offeredunit where offUnitYear = " & selectedYear & " and offUnitSem = " & selectedSem
        DT = M1.GetDatatable(SQL(0))
        ddlUnitCode.DataSource = DT
        ddlUnitCode.DataTextField = "unitId"
        ddlUnitCode.DataValueField = "offUnitId"
        ddlUnitCode.DataBind()
    End Sub

#End Region

#Region "GV Search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearchStu.Text) & "%"
        SQL(0) = "SEARCH_STUDENT('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvSearch.DataSource = DT
        gvSearch.DataBind()
        pnQuerySearch.Visible = True
        DT.Clear()

    End Sub

    Protected Sub gvSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSearch.SelectedIndexChanged
        Dim stuId As String
        Dim stuName As String
        Dim stuLevel As String
        Dim dupStu As Boolean = False
        stuId = gvSearch.Rows(gvSearch.SelectedIndex).Cells(0).Text
        stuName = gvSearch.Rows(gvSearch.SelectedIndex).Cells(1).Text
        stuLevel = gvSearch.Rows(gvSearch.SelectedIndex).Cells(2).Text
        gvSearch.DataSource = Nothing
        gvSearch.DataBind()
        If DT_Student.Columns.Count = 0 Then
            DT_Student.Columns.Add("stuId", GetType(String))
            DT_Student.Columns.Add("stuName", GetType(String))
            DT_Student.Columns.Add("stulevel", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow
        R("stuId") = stuId
        R("stuName") = stuName
        R("stuLevel") = stuLevel
        For Each GVRow As GridViewRow In Me.gvStudent.Rows
            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            Dim ckStuId As String = K1(0)
            If stuId = ckStuId Then
                dupStu = True
            End If
        Next
        'DT_Student.Rows.Add(stuId, stuName, stuLevel)
        If Not (dupStu) Then
            DT_Student.Rows.Add(R)
            gvStudent.DataSource = DT_Student
            gvStudent.DataBind()
        Else
            Dim errMsg = "Student Id " + stuId + " already selected"
            alert(errMsg)
        End If
    End Sub

#End Region

#Region "GV Student"

    Protected Sub gvStudent_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvStudent.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Student.Rows.RemoveAt(index)
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
    End Sub

    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim enrolId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_ENROLMENT;"
        cmd.Parameters.AddWithValue("@penrolId", enrolId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)
        Try
            M1.Execute(SQL(0))

            If resultMsg = "SUCCESS" Then
                alert("Data deleted successfully")
                gvData.EditIndex = -1
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Fail to delete, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim message As String
        Dim success = ""
        Dim failure = ""
        Dim newLine = "\r\n"
        For Each GVRow As GridViewRow In Me.gvStudent.Rows
            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            Dim stuId As String = K1(0)
            Dim offUnitId As Integer = ddlUnitCode.SelectedValue

            cmd.CommandText = "ADD_STUDENT_ENROL"
            cmd.Parameters.AddWithValue("@pstuId", stuId)
            cmd.Parameters.AddWithValue("@poffUnitId", offUnitId)

            Try
                M1.Execute(SQL(0))
                If m_ErrorString = "" Then
                    success += stuId + newLine
                Else
                    failure += m_ErrorString + newLine
                    m_ErrorString = ""
                    cmd.Parameters.Clear()
                End If
            Catch ex As Exception
                alert("Data entered fail, please Try again.")
            End Try
        Next
        If success = "" Then
            success = " - "
        End If
        If failure = "" Then
            failure = " - "
        End If
        message = "Successful enrolment student Id :" + newLine + success
        message += newLine + "Student already enrol this unit :" + newLine + failure
        alert(message)
        ClearValue()
        pnQuerySearch.Visible = False
        loadYear()
        loaddata()
    End Sub

    Protected Sub btnCancelSave_Click(sender As Object, e As EventArgs) Handles btnCancelSave.Click
        ClearValue()
        loaddata()
        pnQuerySearch.Visible = False
    End Sub

    Protected Sub btnSearchForDelete_Click(sender As Object, e As EventArgs) Handles btnSearchForDelete.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = " Select a.enrolId, c.offUnitYear, c.offUnitSem, concat(d.unitId, ' - ', d.unitName) as unitStr,  " _
                & " b.stuId, b.stuName from enrolment a " _
                & " join student b on a.stuId = b.stuId " _
                & " join offeredunit c on a.offUnitId = c.offUnitId " _
                & " join unit d on c.unitId = d.unitId " _
                & " Where b.stuId Like '" & searchTerm & "' " _
                & " or b.stuName Like '" & searchTerm & "' " _
                & " order by offUnitYear, offUnitSem, unitStr, stuId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

    Protected Sub gridviewdata_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewdata_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

#End Region

End Class