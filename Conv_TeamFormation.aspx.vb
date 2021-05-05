Imports MySql.Data.MySqlClient

Public Class Conv_TeamFormation
    Inherits System.Web.UI.Page

    Sub clear()
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        'ddlUnitCode.SelectedIndex() = 0
        ddlProject.SelectedIndex() = 0
        ddlSupervisor.SelectedIndex() = 0
        txtNo.Text = ""
        txtName.Text = ""
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
            alert("Please select project")
            chk = 0
        ElseIf txtNo.Text = "" Then
            Me.txtNo.Focus()
            alert("Please add team no.")
            chk = 0
        ElseIf Not (IsNumeric(txtNo.Text)) Then
            Me.txtNo.Focus()
            alert("Team No must be number")
            chk = 0
        ElseIf txtName.Text = "" Then
            Me.txtName.Focus()
            alert("Please add team name")
            chk = 0
        ElseIf ddlSupervisor.SelectedItem.Value = "0" Then
            Me.ddlSupervisor.Focus()
            alert("Please select supervisor")
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
        ddlSupervisor.Items.Clear()
        ddlSupervisor.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select a.empEnrolId, CONCAT(a.empId, ' - ', b.empName) as empStr " _
                 & " From employeeEnrolment a " _
                 & " Join employee b " _
                 & " On a.empId = b.empId  " _
                 & " Where roleId = 2 "
        DT = M1.GetDatatable(SQL(0))
        ddlSupervisor.DataSource = DT
        ddlSupervisor.DataTextField = "empStr"
        ddlSupervisor.DataValueField = "empEnrolId"
        ddlSupervisor.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            loaddata()
        End If
    End Sub

    Sub loaddata()
        SQL(0) = " Select z.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, " _
                & " d.EmpName, a.offUnitYear, a.offUnitSem, e.projName " _
                & " From team z " _
                & " join project e On e.projId = z.projId " _
                & " join offeredUnit a on e.offUnitId = a.offUnitId " _
                & " join unit b On a.unitID = b.unitID " _
                & " join employeeEnrolment c on z.empEnrolId = c.EmpEnrolId " _
                & " join employee d On c.empId = d.EmpId " _
                & " Where a.unitId = '" & Session("unitID") & "' " _
                & " order by b.unitName, e.projName, z.teamNo"
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

#End Region

#Region "Save"
    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    '--click save
    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim projId As String = ddlProject.SelectedValue.ToString()
        Dim teamNo As String = Me.txtNo.Text
        Dim teamName As String = Me.txtName.Text
        Dim empEnrolId As String = ddlSupervisor.SelectedValue.ToString()

        cmd.CommandText = "ADD_TEAM;"
        cmd.Parameters.AddWithValue("@pteamNo", teamNo)
        cmd.Parameters.AddWithValue("@pteamTitle", teamName)
        cmd.Parameters.AddWithValue("@pprojId", projId)
        cmd.Parameters.AddWithValue("@pempEnrolId", empEnrolId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                clear()
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Insert Error, please Try again Or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

#End Region

#Region "gridview"
    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gridviewdata_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewdata_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing
        gvData.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()

        Dim supervisor As DropDownList = CType(gvData.Rows(gvData.EditIndex).FindControl("ddlSupervisorEdit"), DropDownList)

        SQL(0) = "  Select a.empEnrolId, CONCAT(a.empId, ' - ', b.empName) as empStr " _
                 & " From employeeEnrolment a " _
                 & " Join employee b " _
                 & " On a.empId = b.empId  " _
                 & " Where roleId = 2 "
        DT = M1.GetDatatable(SQL(0))
        supervisor.DataSource = DT
        supervisor.DataTextField = "empStr"
        supervisor.DataValueField = "empEnrolId"
        supervisor.DataBind()
        supervisor.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
    End Sub

    Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim teamId As String = Me.gvData.DataKeys(index).Values(0).ToString()
        Dim teamName As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtTeamName"), TextBox)
        Dim supervisor As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlSupervisorEdit"), DropDownList)
        Dim teamNameStr As String = teamName.Text

        If teamNameStr = "" Then
            alert("please enter updated team Name")
            teamName.Focus()
            Exit Sub
        ElseIf supervisor.SelectedItem.Value = "0" Then
            alert("please select updated supervisor")
            supervisor.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_TEAM;"
        cmd.Parameters.AddWithValue("@pteamId", teamId)
        cmd.Parameters.AddWithValue("@pteamTitle", teamNameStr)
        cmd.Parameters.AddWithValue("@pempEnrolId", supervisor.SelectedItem.Value)

        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Update data successfully")
                gvData.EditIndex = -1
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Fail to update, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim teamId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_TEAM;"
        cmd.Parameters.AddWithValue("@pteamId", teamId)
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

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SQL(0) = " Select z.*, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, " _
                & " d.EmpName, a.offUnitYear, a.offUnitSem, e.projName " _
                & " From team z " _
                & " join project e On e.projId = z.projId " _
                & " join offeredUnit a on e.offUnitId = a.offUnitId " _
                & " join unit b On a.unitID = b.unitID " _
                & " join employeeEnrolment c on z.empEnrolId = c.EmpEnrolId " _
                & " join employee d On c.empId = d.EmpId " _
                & "  Where z.teamTitle like '%" & txtSearch.Text & "%'  order by b.unitName, e.projName, z.teamNo"
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub
    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub
#End Region

End Class
