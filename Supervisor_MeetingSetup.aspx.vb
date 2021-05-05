Imports MySql.Data.MySqlClient

Public Class Supervisor_MeetingSetup
    Inherits System.Web.UI.Page

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Sub clear()
        ddlProject.SelectedIndex = 0
        lblTeam.Text = ""
        txtMeetingTopic.Text = ""
        txtStartDate.Text = ""
        ddlStartHr.SelectedIndex = 0
        ddlStartMin.SelectedIndex = 0
        ddlEndHr.SelectedIndex = 0
        ddlEndMin.SelectedIndex = 0
        txtLocation.Text = ""
    End Sub

#Region "check"

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1
        Dim selectedDateSt = Trim(txtStartDate.Text).ToString

        Dim regDate As Date = Date.Now()
        Dim regDateStr As String = regDate.ToString("yyyy-MM-dd")
        Dim curDate = DateTime.Parse(regDateStr)
        If ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf txtMeetingTopic.Text = "" Then
            Me.txtMeetingTopic.Focus()
            alert("Please add Meeting topic")
            chk = 0
        ElseIf txtStartDate.Text = "" Then
            Me.txtStartDate.Focus()
            alert("Please add meeting date")
            chk = 0
        ElseIf txtLocation.Text = "" Then
            Me.txtLocation.Focus()
            alert("Please add meeting location")
            chk = 0
        End If

        If Not (selectedDateSt = "") Then
            Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
            Dim startdateC = DateTime.Parse(startDate)
            If startdateC < curDate Then
                alert("Cannot select past Meeting date, please try again")
                chk = 0
            End If
        End If
        Dim startTime = ddlStartHr.SelectedValue.ToString & ":" & ddlStartMin.SelectedValue.ToString & ddlStart.SelectedValue.ToString
        Dim endTime = ddlEndHr.SelectedValue.ToString & ":" & ddlEndMin.SelectedValue.ToString & ddlStop.SelectedValue.ToString

        If startTime = endTime Then
            alert("Start time and End time must be different, please try again")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Carlendar"

    Dim vClsFunc As New ClassFunction()

    Protected Sub IMbStartDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbStartDate.Click
        Calendar1.Visible = True
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.txtStartDate.Text = vClsFunc.DateString_Show(Calendar1.SelectedDate)
        Calendar1.Visible = False
    End Sub


#End Region

#Region "loaddata"

    Sub loadProject()
        SQL(0) = " Select a.projId, a.projName " _
                & " From project a " _
                & " Join team b on a.projId = b.projId " _
                & " join employeeenrolment c on b.empEnrolId = c.empEnrolId" _
                & " Where a.offUnitId = " & Session("offUnitId") & " " _
                & " And c.empId = " & Session("userId") & " " _
                & " order by a.projName "
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        SQL(0) = "  Select teamtitle from team a inner join employeeenrolment b on a.empEnrolId = b.empEnrolId  " _
                 & " where b.empId = " _
                 & Session("userId") _
                 & " And a.projId = " _
                 & ddlProject.SelectedValue

        DT = M1.GetDatatable(SQL(0))
        lblTeam.Text = DT.Rows(0).Item(0)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
            loaddata()
        End If
    End Sub

    Sub loaddata()
        SQL(0) = " Select *, DATE_FORMAT(a.meetingDate,'%d/%m/%Y') AS dateStr " _
                & " From meeting a " _
                & " Join team b on a.teamId = b.teamId " _
                & " Join project c On b.projId = c.projId " _
                & " join offeredUnit d On c.offUnitId = d.offUnitId " _
                & " join employeeenrolment e on b.empEnrolId = e.empEnrolId    " _
                & " Where c.offUnitId = " & Session("offUnitId") & " " _
                & " And e.empId = '" & Session("userId") & "' " _
                & " and meetingType = 'Supervisor meeting' order by c.projName, b.teamTitle, a.meetingId  "
        DT = M1.GetDatatable(SQL(0))
        Try
            gvData.DataSource = DT
            gvData.DataBind()
        Catch ex As Exception
            gvData.DataSource = Nothing
            gvData.DataBind()
        End Try
    End Sub

#End Region

    Protected Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim projId As String = ddlProject.SelectedValue.ToString()

        SQL(0) = "  Select a.teamId from team a inner join employeeenrolment b on a.empEnrolId = b.empEnrolId  " _
                 & " where b.empId = " _
                 & Session("userId") _
                 & " And a.projId = " _
                 & ddlProject.SelectedValue
        DT = M1.GetDatatable(SQL(0))
        Dim teamId As String = DT.Rows(0).Item(0)
        Dim meetingDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim startTime = ddlStartHr.SelectedValue.ToString & ":" & ddlStartMin.SelectedValue.ToString & " " & ddlStart.SelectedValue.ToString
        Dim endTime = ddlEndHr.SelectedValue.ToString & ":" & ddlEndMin.SelectedValue.ToString & " " & ddlStop.SelectedValue.ToString
        Dim location As String = txtLocation.Text
        Dim meetingTopic As String = txtMeetingTopic.Text

        cmd.CommandText = "ADD_MEETING;"
        cmd.Parameters.AddWithValue("@pteamId", teamId)
        cmd.Parameters.AddWithValue("@pmeetingDate", meetingDate)
        cmd.Parameters.AddWithValue("@pstartTime", startTime)
        cmd.Parameters.AddWithValue("@pendTime", endTime)
        cmd.Parameters.AddWithValue("@plocation", location)
        cmd.Parameters.AddWithValue("@puserId", Session("userId"))
        cmd.Parameters.AddWithValue("@pmeetingType", "Supervisor meeting")
        cmd.Parameters.AddWithValue("@pmeetingTopic", meetingTopic)
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
                loadProject()
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Insert Error, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = ""
        If ddlSearch.SelectedIndex > 0 Then
            searchTerm = " and a.meetingStatus = '" & ddlSearch.SelectedValue.ToString() & "' "
        End If
        SQL(0) = " Select *, DATE_FORMAT(a.meetingDate,'%d/%m/%Y') AS dateStr " _
                & " From meeting a " _
                & " Join team b on a.teamId = b.teamId " _
                & " Join project c On b.projId = c.projId " _
                & " join offeredUnit d On c.offUnitId = d.offUnitId " _
                & " join employeeenrolment e on b.empEnrolId = e.empEnrolId  " _
                & " Where c.offUnitId = " & Session("offUnitId") & " " _
                & " And e.empId = '" & Session("userId") & "' " _
                & searchTerm _
                & " and meetingType = 'Supervisor meeting' order by c.projName, b.teamTitle, a.meetingId  "

        DT = M1.GetDatatable(SQL(0))
        Try
            gvData.DataSource = DT
            gvData.DataBind()
        Catch ex As Exception
            gvData.DataSource = Nothing
            gvData.DataBind()
        End Try
    End Sub

#Region "gridview"
    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gvData_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvData_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing
        gvData.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim meetingId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        Dim txtMeeting As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtMeeting"), TextBox)
        Dim txtMeetingDate As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtMeetingDate"), TextBox)
        Dim txtStartTime As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtStartTime"), TextBox)
        Dim txtEndTime As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtEndTime"), TextBox)
        Dim txtLocation As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtLocation"), TextBox)

        If txtMeeting.Text = "" Then
            alert("please enter meeting topic")
            txtMeeting.Focus()
            Exit Sub
        ElseIf txtMeetingDate.Text = "" Then
            alert("please select meeting date")
            txtMeetingDate.Focus()
            Exit Sub
        ElseIf txtStartTime.Text = "" Then
            alert("please select start time")
            txtMeetingDate.Focus()
            Exit Sub
        ElseIf txtEndTime.Text = "" Then
            alert("please select end time")
            txtMeetingDate.Focus()
            Exit Sub
        ElseIf txtLocation.Text = "" Then
            alert("please select location")
            txtMeetingDate.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_MEETING;"
        cmd.Parameters.AddWithValue("@pmeetingTopic", txtMeeting.Text)
        cmd.Parameters.AddWithValue("@pmeetingDate", txtMeetingDate.Text)
        cmd.Parameters.AddWithValue("@pstartTime", txtStartTime.Text)
        cmd.Parameters.AddWithValue("@pendTime", txtEndTime.Text)
        cmd.Parameters.AddWithValue("@plocation", txtLocation.Text)

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
        Dim meetingId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_MEETING;"
        cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
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

#End Region

End Class