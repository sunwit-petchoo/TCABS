Imports System.Web.UI.WebControls.Expressions
Imports MySql.Data.MySqlClient

Public Class Student_TaskSubmit
    Inherits System.Web.UI.Page

#Region "Carlendar"
    Dim vClsFunc As New ClassFunction()
#End Region

#Region "check"

    Sub clear()
        ddlProject.SelectedIndex() = 0
        lblTeam.Text = ""
        ddlTask.SelectedIndex() = 0
        ddlRole.SelectedIndex() = 0
        txtMinutes.Text = ""
    End Sub

    '-- alert
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1
        If ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf ddlTask.SelectedItem.Value = "0" Then
            Me.ddlTask.Focus()
            alert("Please select task")
            chk = 0
        ElseIf ddlRole.SelectedItem.Value = "0" Then
            Me.ddlRole.Focus()
            alert("Please select role")
            chk = 0
        ElseIf txtMinutes.Text = "" Then
            Me.txtMinutes.Focus()
            alert("Please add minute taken")
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

    Sub loadProject()
        SQL(0) = " Select * From project " _
        & " Where offUnitId = '" & Session("offUnitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()

        ddlSearchProject.DataSource = DT
        ddlSearchProject.DataTextField = "projName"
        ddlSearchProject.DataValueField = "projId"
        ddlSearchProject.DataBind()
    End Sub

    Sub loadTeamEnrol()
        SQL(0) = " Select * " _
                & " From teamEnrol a " _
                & " join enrolment b on a.enrolId = b.enrolId " _
                & " join student c On b.stuId = c.stuId " _
                & " Where c.stuId = '" & Session("userId") & "' "
        DT = M1.GetDatatable(SQL(0))
        If DT.Rows.Count() > 0 Then
            Session("teamEnrolId") = DT.Rows(0)("teamEnrolId").ToString()
        End If
    End Sub

    Private Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        '--load team
        SQL(0) = "  select b.teamid, concat(b.teamNo, ' - ', b.teamTitle) as teamStr " _
                & " from teamenrol a " _
                & " join team b on a.teamId = b.teamId " _
                & " join project c on b.projId = c.projId " _
                & " Where c.projId = '" & ddlProject.SelectedValue.ToString() & "' "
        DT = M1.GetDatatable(SQL(0))
        If DT.Rows.Count() = 0 Then
            alert("You have not enrol in any project team. Please contact your supervisor.")
            ddlProject.Items.Clear()
            ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
            loadProject()
        Else
            lblTeam.Text = DT.Rows(0)("teamStr").ToString()
        End If

        '--load task
        ddlTask.Items.Clear()
        ddlTask.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select taskid, concat(taskNo, ' - ', taskTitle) as taskStr " _
                & " From task " _
                & " Where projId = '" & ddlProject.SelectedValue.ToString() & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlTask.DataSource = DT
        ddlTask.DataTextField = "taskStr"
        ddlTask.DataValueField = "taskid"
        ddlTask.DataBind()

        '--load role
        ddlRole.Items.Clear()
        ddlRole.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select tmRolId, tmRolName " _
                & " From teamrole " _
                & " Where projId = '" & ddlProject.SelectedValue.ToString() & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlRole.DataSource = DT
        ddlRole.DataTextField = "tmRolName"
        ddlRole.DataValueField = "tmRolId"
        ddlRole.DataBind()
    End Sub

    Protected Sub ddlSearchProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSearchProject.SelectedIndexChanged
        '--load task
        ddlSearchTask.Items.Clear()
        ddlSearchTask.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select taskid, concat(taskNo, ' - ', taskTitle) as taskStr " _
                & " From task " _
                & " Where projId = '" & ddlSearchProject.SelectedValue.ToString() & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlSearchTask.DataSource = DT
        ddlSearchTask.DataTextField = "taskStr"
        ddlSearchTask.DataValueField = "taskid"
        ddlSearchTask.DataBind()
    End Sub

    '--load gridview
    Sub loaddata()
        SQL(0) = "  Select a.*, b.tmRolName, i.stuName, " _
                    & " c.taskTitle, c.taskDesc, d.projName, " _
                    & " concat(f.unitId, ' - ', f.unitName) as unitStr " _
                    & " From task_submit a " _
                    & " join teamrole b on a.tmRolId = b.tmRolId " _
                    & " join task c On a.taskId = c.taskId " _
                    & " join project d on c.projId = d.projId " _
                    & " join offeredunit e On d.offUnitId = e.offUnitId " _
                    & " join unit f on e.unitId = f.unitId " _
                    & " join teamEnrol g On a.teamEnrolId = g.teamEnrolId " _
                    & " join enrolment h on g.enrolId = h.enrolId " _
                    & " join student i On h.stuId = i.stuId " _
                    & " Where h.stuId = '" & Session("userId") & "' " _
                    & " And d.offUnitId = '" & Session("offUnitId") & "' "

        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
            loadTeamEnrol()
            loaddata()
        End If
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

        Dim rvprm As MySqlParameter = New MySqlParameter
        Dim taskId As String = ddlTask.SelectedValue.ToString()
        Dim tmRoleId As String = ddlRole.SelectedValue.ToString()
        Dim minutes As String = txtMinutes.Text
        'Dim submitDate As String = vClsFunc.DateString_Show(Date.Now.ToString())

        'SQL(0) = " INSERT INTO `tcabs`.`task_submit` " _
        '        & " (`taskId`,`teamEnrolId`, " _
        '        & " `minutesTaken`,`tmRolId`,`submitDate`) " _
        '        & " VALUES " _
        '        & " ('" & taskId & "', '" & Session("teamEnrolId") & "', " _
        '        & " '" & minutes & "', '" & tmRoleId & "', '" & submitDate & "'); "
        'M1.Execute(SQL(0))

        cmd.CommandText = "ADD_TASK_SUBMIT;"
        cmd.Parameters.AddWithValue("@ptaskId", taskId)
        cmd.Parameters.AddWithValue("@pteamEnrolId", Session("teamEnrolId"))
        cmd.Parameters.AddWithValue("@pminutesTaken", minutes)
        cmd.Parameters.AddWithValue("@ptmRolId", tmRoleId)

        rvprm.ParameterName = "msg"
        rvprm.MySqlDbType = MySqlDbType.String
        rvprm.Size = 200
        rvprm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvprm)

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

#Region "gridview data"

    Protected Sub gridviewdata_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewdata_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    '--click edit
    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing

        gvData.EditIndex = e.NewEditIndex
        Dim submitId As String = gvData.DataKeys(gvData.EditIndex).Values(0).ToString()
        SQL(0) = " select taskStatus from task_submit where submitId = " & submitId
        DT = M1.GetDatatable(SQL(0))
        'Dim status As String = DT.Rows(0)("taskStatus").ToString()
        'If status <> "
        ' Then
        '    alert("Only Submitted status allowed to update")
        '    gvData.EditIndex = -1
        '    loaddata()
        '    Exit Sub

        'End If

        'bind Data to the gridview control.
        Me.loaddata()

        Dim ddlRoleEdit As DropDownList = CType(gvData.Rows(gvData.EditIndex).FindControl("ddlRole"), DropDownList)

        SQL(0) = "  Select tmRolId, tmRolName from" _
                & " teamrole where projId in (select projId from task a inner join task_submit b on a.taskId = b.taskId " _
                & " where b.submitId = " & submitId & ")"

        DT = M1.GetDatatable(SQL(0))
        ddlRoleEdit.DataSource = DT
        ddlRoleEdit.DataTextField = "tmRolName"
        ddlRoleEdit.DataValueField = "tmRolId"
        ddlRoleEdit.DataBind()

    End Sub

    Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim submitId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        Dim ddlRoleEdit As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlRole"), DropDownList)
        Dim minute As TextBox = CType(gvData.Rows(gvData.EditIndex).FindControl("txtMin"), TextBox)
        Dim status As Label = CType(gvData.Rows(gvData.EditIndex).FindControl("lblStatus"), Label)
        Dim isLog As String = "No"
        If status.Text = "resubmit" Then
            isLog = "Yes"
        End If
        Dim minuteVal As String = minute.Text
        Dim roleVal As String = ddlRoleEdit.SelectedItem.Value

        If minuteVal = "" Then
            alert("please add updated minutes taken")
            minute.Focus()
            Exit Sub
        ElseIf Not (IsNumeric(minuteVal)) Then
            alert("minutes taken must be number")
            minute.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_TASK_SUBMIT;"
        cmd.Parameters.AddWithValue("@psubmitId", submitId)
        cmd.Parameters.AddWithValue("@pminutesTaken", minuteVal)
        cmd.Parameters.AddWithValue("@ptmRolId", roleVal)
        cmd.Parameters.AddWithValue("@pisLog", isLog)
        cmd.Parameters.AddWithValue("@pstuId", Session("userId"))

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
        Dim submitId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_TASK_SUBMIT;"
        cmd.Parameters.AddWithValue("@psubmitId", submitId)
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

    Protected Sub gvEmpDes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvData.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem()

            '--Check Edit
            If e.Row.DataItem("taskStatus") <> "submitted" Then
                If e.Row.DataItem("taskStatus") <> "resubmit" Then
                    e.Row.Cells(6).Text = ""
                End If
            End If

            '--Check Delete
            If e.Row.DataItem("taskStatus") <> "submitted" Then
                e.Row.Cells(7).Text = ""
            End If
        End If
    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm_1 As String = ""
        Dim searchTerm_2 As String = ""
        If ddlSearchProject.SelectedItem.Value <> "0" Then
            searchTerm_1 = " And c.projId = '" & ddlSearchProject.SelectedValue.ToString() & "' "
        End If
        If ddlSearchTask.SelectedItem.Value <> "0" Then
            searchTerm_2 = " And c.taskId = '" & ddlSearchTask.SelectedValue.ToString() & "' "
        End If
        SQL(0) = "  Select a.*, b.tmRolName, i.stuName, " _
                    & " c.taskTitle, c.taskDesc, d.projName, " _
                    & " concat(f.unitId, ' - ', f.unitName) as unitStr " _
                    & " From task_submit a " _
                    & " join teamrole b on a.tmRolId = b.tmRolId " _
                    & " join task c On a.taskId = c.taskId " _
                    & " join project d on c.projId = d.projId " _
                    & " join offeredunit e On d.offUnitId = e.offUnitId " _
                    & " join unit f on e.unitId = f.unitId " _
                    & " join teamEnrol g On a.teamEnrolId = g.teamEnrolId " _
                    & " join enrolment h on g.enrolId = h.enrolId " _
                    & " join student i On h.stuId = i.stuId " _
                    & " Where h.stuId = 101318759 And d.offUnitId = 8" _
                    & searchTerm_1 _
                    & searchTerm_2

        '& " Where h.stuId = '" & Session("userId") & "' " _
        '& " And d.offUnitId = '" & Session("offUnitId") & "' " _
        '& searchTerm_1 _
        '& searchTerm_2
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        ddlSearchProject.SelectedIndex() = 0
        ddlSearchTask.SelectedIndex() = 0
        loaddata()
    End Sub

#End Region

End Class