Imports MySql.Data.MySqlClient

Public Class Conv_TeamEnrolment
    Inherits System.Web.UI.Page

    Sub clear()
        DT_Student.Clear()
        DT.Clear()
        gvStudent.DataSource = DT_Student
        gvStudent.DataBind()
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        'ddlUnitCode.Items.Clear()
        'ddlUnitCode.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlTeam.Items.Clear()
        ddlTeam.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        'ddlUnitCode.SelectedIndex() = 0
        ddlProject.SelectedIndex() = 0
        ddlTeam.SelectedIndex() = 0
    End Sub

#Region "check"
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
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
            'ElseIf ddlUnitCode.SelectedItem.Value = "0" Then
            '    Me.ddlUnitCode.Focus()
            '    alert("Please select unit")
            '    chk = 0
        ElseIf ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select Project")
            chk = 0
        ElseIf ddlTeam.SelectedItem.Value = "0" Then
            Me.ddlTeam.Focus()
            alert("Please select Team")
            chk = 0
        ElseIf Me.gvStudent.Rows.Count = 0 Then
            alert("Please search and select student to enrol in the team")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "load data"
    Sub loadYear()
        Dim nowYear As Integer = Date.Now.Year
        Dim nextYear = nowYear + 1
        Dim nextYearStr = nextYear.ToString
        Dim nowYearStr = nowYear.ToString
        SQL(0) = "select distinct(offUnitYear) from offeredunit " _
                & " where offUnitYear = " & nowYearStr & " Or offUnitYear = " & nextYearStr _
                & " and unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlYear.DataSource = DT
        ddlYear.DataTextField = "offUnitYear"
        ddlYear.DataValueField = "offUnitYear"
        ddlYear.DataBind()

    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "select distinct(offUnitSem) from offeredunit where offUnitYear = " & selectedYear _
                & " and unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlSemester.DataSource = DT
        ddlSemester.DataTextField = "offUnitSem"
        ddlSemester.DataValueField = "offUnitSem"
        ddlSemester.DataBind()
    End Sub
    Protected Sub ddlSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        Dim selectedSem = ddlSemester.SelectedItem.Value
        SQL(0) = "select a.offUnitId, CONCAT(b.unitId, ' - ', b.unitName) as unitStr " _
                & " from offeredunit a " _
                & " join unit b on a.unitId = b.unitId " _
                & " where offUnitYear = " & selectedYear & " And offUnitSem = " & selectedSem _
                & " and a.unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        Try
            Session("offUnitId") = DT.Rows(0)("offUnitId").ToString()
        Catch ex As Exception
            alert("There is no offered unit for selected year and semester")
        End Try
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = " Select projId, projName from project where offUnitId = " & Session("offUnitId")
        DT = M1.GetDatatable(SQL(0))
        Try
            ddlProject.DataSource = DT
            ddlProject.DataTextField = "projName"
            ddlProject.DataValueField = "projId"
            ddlProject.DataBind()
        Catch ex As Exception
            alert("There is no project for selected year and semester")
        End Try
    End Sub

    'Protected Sub ddlUnitCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlUnitCode.SelectedIndexChanged
    '    Dim selectedUnit = ddlUnitCode.SelectedItem.Value
    '    'Session("offUnitId") = selectedUnit
    '    ddlProject.Items.Clear()
    '    ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
    '    SQL(0) = " Select projId, projName from project where offUnitId = " & selectedUnit
    '    DT = M1.GetDatatable(SQL(0))
    '    ddlProject.DataSource = DT
    '    ddlProject.DataTextField = "projName"
    '    ddlProject.DataValueField = "projId"
    '    ddlProject.DataBind()
    'End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        Dim selectedProj As String = ddlProject.SelectedItem.Value.ToString()
        SQL(0) = "  Select * " _
                 & " From team " _
                 & " Where projId = '" & selectedProj & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlTeam.DataSource = DT
        ddlTeam.DataTextField = "teamTitle"
        ddlTeam.DataValueField = "teamId"
        ddlTeam.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            loaddata()
        End If
    End Sub

    Sub loaddata()
        SQL(0) = " select a.teamEnrolId, e.offUnitYear, e.offUnitSem, concat(f.unitId, ' - ', f.unitName) as unitStr, b.teamTitle,  " _
                & " c.stuId, d.stuName, case when a.pm_role=1 then 'Yes' else 'No' end as pm_role from teamenrol a " _
                & " inner join team b on a.teamid = b.teamid " _
                & " inner join enrolment c on a.enrolId = c.enrolId " _
                & " inner join student d on c.stuId = d.stuId " _
                & " inner join offeredunit e on e.offUnitId = c.offUnitId " _
                & " inner join unit f on f.unitId = e.unitId " _
                & " Where e.unitId = '" & Session("unitID") & "' " _
                & " order by offUnitYear, offUnitSem, unitStr, teamTitle, stuId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

#End Region

#Region "GV Search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Session("offUnitId") = "" Then
            alert("Please select year and semester")
            ddlYear.Focus()
        Else
            Dim searchTerm As String = "%" & Trim(txtSearchStu.Text) & "%"
            Dim selectedUnit = Session("offUnitId")
            If selectedUnit = "0" Then
                alert("Please select unit first")
                Exit Sub
            End If

            SQL(0) = " Select a.enrolId, b.stuId, b.stuName, b.stulevel " _
                & " from enrolment a " _
                & " join student b on a.stuId = b.stuId " _
                & " join offeredunit c On a.offUnitId = c.offUnitId " _
                & " Where c.offUnitId = " & selectedUnit & " " _
                & " And (b.stuId Like '" & searchTerm & "'" _
                & " or b.stuName like '" & searchTerm & "')"
            DT = M1.GetDatatable(SQL(0))
            gvSearch.DataSource = DT
            gvSearch.DataBind()
            pnQuerySearch.Visible = True
            'DT.Clear()
        End If

    End Sub

    Protected Sub gvSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvSearch.SelectedIndexChanged

        Dim enrolId As String = Me.gvSearch.DataKeys(gvSearch.SelectedIndex).Values(0).ToString()
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
            DT_Student.Columns.Add("enrolId", GetType(String))
            DT_Student.Columns.Add("stuId", GetType(String))
            DT_Student.Columns.Add("stuName", GetType(String))
            DT_Student.Columns.Add("stulevel", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow
        R("enrolId") = enrolId
        R("stuId") = stuId
        R("stuName") = stuName
        R("stuLevel") = stuLevel
        For Each GVRow As GridViewRow In Me.gvStudent.Rows

            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            Dim ckEnrolId As String = K1(0)

            If enrolId = ckEnrolId Then
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

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim countPM As Integer = 0
        Dim teamId As String = ddlTeam.SelectedValue.ToString()
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim pmMsg As String = ""
        For Each GVRowPM As GridViewRow In Me.gvStudent.Rows

            Dim chkPM As CheckBox = CType(gvStudent.Rows(GVRowPM.RowIndex).FindControl("chkSelect"), CheckBox)
            If chkPM.Checked = True Then
                countPM += 1
            End If
        Next
        cmd.CommandText = "CHECK_PM"
        cmd.Parameters.AddWithValue("@pteamId", teamId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            pmMsg = resultMsg
            resultMsg = ""
        Catch ex As Exception
            resultMsg = ""
            alert("Data entered fail, please Try again.")
            clear()
            pnQuerySearch.Visible = False
            loadYear()
            loaddata()
        End Try

        If countPM = 0 And pmMsg = "NO_PM_YET" Then
            alert("Please select project manager for the team")
            Exit Sub
        ElseIf countPM <> 0 And pmMsg = "PM_EXIST" Then
            alert("This team already have project manager")
            Exit Sub
        End If

        Dim message As String
        Dim success = ""
        Dim failure = ""
        Dim newLine = "\r\n"


        For Each GVRow As GridViewRow In Me.gvStudent.Rows
            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            Dim enrolId As String = K1(0)

            Dim PM_Role As Integer
            Dim chkChangePro As CheckBox = CType(gvStudent.Rows(GVRow.RowIndex).FindControl("chkSelect"), CheckBox)
            Dim studentId As Label = CType(gvStudent.Rows(GVRow.RowIndex).FindControl("lblStuId"), Label)
            If chkChangePro.Checked = True Then
                PM_Role = 1
            Else
                PM_Role = 0
            End If

            cmd.CommandText = "ADD_TEAM_ENROL"
            cmd.Parameters.AddWithValue("@pteamId", teamId)
            cmd.Parameters.AddWithValue("@penrolId", enrolId)
            cmd.Parameters.AddWithValue("@pPM_Role", PM_Role)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg = "" Then
                    success += studentId.Text + newLine
                Else
                    failure += resultMsg + newLine
                    resultMsg = ""
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
        message = "Successful team enrolment student Id :" + newLine + success
        message += newLine + "Student Id already exists in a team for this unit:" + newLine + failure
        alert(message)
        clear()
        pnQuerySearch.Visible = False
        loadYear()
        loaddata()
    End Sub

    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        loadYear()
        loaddata()
        pnQuerySearch.Visible = False
    End Sub

#End Region

#Region "GV Data"

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

    Protected Sub btnSearchForDelete_Click(sender As Object, e As EventArgs) Handles btnSearchForDelete.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"

        SQL(0) = " select a.teamEnrolId, e.offUnitYear, e.offUnitSem, concat(f.unitId, ' - ', f.unitName) as unitStr, b.teamTitle,  " _
                & " c.stuId, d.stuName, case when a.pm_role=1 then 'Yes' else 'No' end as pm_role from teamenrol a " _
                & " inner join team b on a.teamid = b.teamid " _
                & " inner join enrolment c on a.enrolId = c.enrolId " _
                & " inner join student d on c.stuId = d.stuId " _
                & " inner join offeredunit e on e.offUnitId = c.offUnitId " _
                & " inner join unit f on f.unitId = e.unitId " _
                & " Where d.stuId Like '" & searchTerm & "' " _
                & " or d.stuName Like '" & searchTerm & "' " _
                & " order by offUnitYear, offUnitSem, unitStr, teamTitle, stuId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim teamEnrolId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_TEAMENROL;"
        cmd.Parameters.AddWithValue("@pteamEnrolId", teamEnrolId)
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

    Protected Sub gvData_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvData_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

#End Region

End Class