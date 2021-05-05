Imports MySql.Data.MySqlClient

Public Class Student_MeetingAgenda
    Inherits System.Web.UI.Page
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Sub clear()
        ddlProject.SelectedIndex = 0
        lblTeam.Text = ""
        ddlMeeting.SelectedIndex = 0
        ddlCatagory.SelectedIndex = 0
        txtTitle.Text = ""
        txtDetails.Text = ""
    End Sub

#Region "check"

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1

        If ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf ddlMeeting.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select meeting")
            chk = 0
        ElseIf ddlCatagory.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select category")
            chk = 0
        ElseIf txtTitle.Text = "" Then
            Me.txtTitle.Focus()
            alert("Please add agenda title")
            chk = 0
        ElseIf txtDetails.Text = "" Then
            Me.txtDetails.Focus()
            alert("Please add agenda details")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "loaddata"

    Sub loadProject()
        SQL(0) = " Select a.projId, a.projName " _
                & " From project a " _
                & " Join team b on a.projId = b.projId " _
                & " Join teamenrol c on c.teamId = b.teamId " _
                & " Join enrolment d on c.enrolId = d.enrolId " _
                & " Where a.offUnitId = " & Session("offUnitId") & " " _
                & " And d.stuId = " & Session("userId") & " " _
                & " order by a.projName "
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
    End Sub

    Sub loadMeeting()
        SQL(0) = "  Select meetingId, meetingTopic " _
                 & " from team a " _
                 & " inner join teamenrol b On a.teamId = b.teamId  " _
                 & " inner join enrolment c On c.enrolId = b.enrolId  " _
                 & " inner join meeting d on a.teamId = d.teamId  " _
                 & " where c.stuId = '" & Session("userId") & "' "

        DT = M1.GetDatatable(SQL(0))
        ddlSearch.DataSource = DT
        ddlSearch.DataTextField = "meetingTopic"
        ddlSearch.DataValueField = "meetingId"
        ddlSearch.DataBind()
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        SQL(0) = "  Select teamtitle, meetingId, meetingTopic " _
                 & " from team a " _
                 & " inner join teamenrol b On a.teamId = b.teamId  " _
                 & " inner join enrolment c On c.enrolId = b.enrolId  " _
                 & " inner join meeting d on a.teamId = d.teamId  " _
                 & " where c.stuId = '" & Session("userId") & "' " _
                 & " And a.projId = " & ddlProject.SelectedValue & " "
        DT = M1.GetDatatable(SQL(0))
        Try
            lblTeam.Text = DT.Rows(0).Item(0)
            ddlMeeting.DataSource = DT
            ddlMeeting.DataTextField = "meetingTopic"
            ddlMeeting.DataValueField = "meetingId"
            ddlMeeting.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
            loaddata()
            loadMeeting()
        End If
    End Sub

    Sub loaddata()
        'SQL(0) = " Select *, CONCAT(startTime, ' - ', endTime) as timeStr " _
        '        & " From meeting a " _
        '        & " Join team b on a.teamId = b.teamId " _
        '        & " Join project c On b.projId = c.projId " _
        '        & " join offeredUnit d On c.offUnitId = d.offUnitId " _
        '        & " join enrolment e On d.offUnitId = e.offUnitId " _
        '        & " join meetingAgenda f On a.meetingId = f.meetingId " _
        '        & " Where c.offUnitId = " & Session("offUnitId") & " " _
        '        & " And e.stuId = '" & Session("userId") & "' " _
        '        & " order by c.projName, b.teamTitle, a.meetingId  "
        SQL(0) = " Select *, CONCAT(a.startTime, ' - ', a.endTime) as timeStr " _
                & " From meeting a " _
                & " join meetingagenda z on a.meetingId = z.meetingId " _
                & " join team b on a.teamId = b.teamId " _
                & " join teamEnrol c on b.teamId = c.teamId " _
                & " join enrolment d on c.enrolId = d.enrolId " _
                & " join project e on b.projId = e.projId " _
                & " Where d.stuId = '" & Session("userId") & "' " _
                & " order by e.projName, b.teamTitle, a.meetingId "
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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim meetingId As String = ddlMeeting.SelectedValue.ToString()
        Dim category As String = ddlCatagory.SelectedValue.ToString()
        Dim title As String = txtTitle.Text
        Dim details As String = txtDetails.Text



        cmd.CommandText = "ADD_MEETINGAGENDA;"
        cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
        cmd.Parameters.AddWithValue("@pcategory", category)
        cmd.Parameters.AddWithValue("@pagendaTitle", title)
        cmd.Parameters.AddWithValue("@pagendaDetails", details)
        cmd.Parameters.AddWithValue("@pteamEnrolId", Session("userId"))
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
            searchTerm = " and a.meetingId = '" & ddlSearch.SelectedValue.ToString() & "' "
        End If
        SQL(0) = " Select *, CONCAT(startTime, ' - ', endTime) as timeStr " _
                & " From meeting a " _
                & " Join team b on a.teamId = b.teamId " _
                & " Join project c On b.projId = c.projId " _
                & " join offeredUnit d On c.offUnitId = d.offUnitId " _
                & " join enrolment e On d.offUnitId = e.offUnitId " _
                & " join meetingAgenda f On a.meetingId = f.meetingId " _
                & " Where c.offUnitId = " & Session("offUnitId") & " " _
                & " And e.stuId = '" & Session("userId") & "' " _
                & searchTerm _
                & " order by c.projName, b.teamTitle, a.meetingId  "
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

        Dim ddlCategory As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlCategory"), DropDownList)
        Dim txtTitle As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtTitle"), TextBox)
        Dim txtDetails As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtDetails"), TextBox)

        If txtTitle.Text = "" Then
            alert("please enter agenda title")
            txtTitle.Focus()
            Exit Sub
        ElseIf txtDetails.Text = "" Then
            alert("please select agenda details")
            txtDetails.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_MEETINGAGENDA;"
        cmd.Parameters.AddWithValue("@pcategory", ddlCategory.SelectedValue.ToString())
        cmd.Parameters.AddWithValue("@pagendaTitile", txtTitle.Text)
        cmd.Parameters.AddWithValue("@pagendaDetails", txtDetails.Text)
        cmd.Parameters.AddWithValue("@pteamEnrolId", Session("userId"))

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
        Dim agendaId As String = Me.gvData.DataKeys(index).Values(1).ToString()

        cmd.CommandText = "DELETE_MEETINGAGENDA;"
        cmd.Parameters.AddWithValue("@pagendaId", agendaId)
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