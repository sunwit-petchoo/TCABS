Imports MySql.Data.MySqlClient

Public Class Student_MeetingMinutes
    Inherits System.Web.UI.Page

    Dim DT_Temp As DataTable

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Sub clear()
        ddlProject.SelectedIndex = 0
        lblTeam.Text = ""
        ddlMeeting.SelectedIndex = 0

        ddlTitle_Last.SelectedIndex = 0
        ddlTitle_Present.SelectedIndex = 0
        txtDetails_Last.Text = ""
        txtDetails_Present.Text = ""
        txtDetails_Next.Text = ""
        ddlPerson_Last.SelectedIndex = 0
        ddlPerson_Present.SelectedIndex = 0
        ddlPerson_Next.SelectedIndex = 0
        ddlDate_Last.SelectedIndex = 0
        ddlDate_Present.SelectedIndex = 0
        ddlDate_Next.SelectedIndex = 0
        ddlAction_Last.SelectedIndex = 0
        ddlAction_Present.SelectedIndex = 0
        txtTitle_Next.Text = ""
    End Sub

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

    Protected Sub ddlMeeting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMeeting.SelectedIndexChanged
        '--load agenda
        SQL(0) = " Select * From MeetingAgenda " _
                & " Where meetingId = " & ddlMeeting.SelectedValue.ToString() & " "
        DT = M1.GetDatatable(SQL(0))
        Try
            ddlTitle_Last.DataSource = DT
            ddlTitle_Last.DataTextField = "agendaTitle"
            ddlTitle_Last.DataValueField = "agendaId"
            ddlTitle_Last.DataBind()
            ddlTitle_Present.DataSource = DT
            ddlTitle_Present.DataTextField = "agendaTitle"
            ddlTitle_Present.DataValueField = "agendaId"
            ddlTitle_Present.DataBind()
        Catch ex As Exception

        End Try

        '--load team
        SQL(0) = " Select teamEnrolId, concat(b.stuId, '-', stuName) as stuStr " _
                & " From teamenrol a  " _
                & " join enrolment b on a.enrolId = b.enrolId " _
                & " join student c on b.stuId = c.stuId " _
                & " join team d on d.teamId = a.teamId " _
                & " join meeting e on e.teamId = d.teamId " _
                & " Where e.meetingId = " & ddlMeeting.SelectedValue.ToString() & " "
        DT = M1.GetDatatable(SQL(0))
        Try
            ddlPerson_Last.DataSource = DT
            ddlPerson_Last.DataTextField = "stuStr"
            ddlPerson_Last.DataValueField = "teamEnrolId"
            ddlPerson_Last.DataBind()
            ddlPerson_Present.DataSource = DT
            ddlPerson_Present.DataTextField = "stuStr"
            ddlPerson_Present.DataValueField = "teamEnrolId"
            ddlPerson_Present.DataBind()
            ddlPerson_Next.DataSource = DT
            ddlPerson_Next.DataTextField = "stuStr"
            ddlPerson_Next.DataValueField = "teamEnrolId"
            ddlPerson_Next.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Sub loaddata()
        SQL(0) = " Select * " _
                & " From meetingminutes a " _
                & " Join teamenrol b on a.teamenrolId = b.teamenrolId " _
                & " Join enrolment c On b.enrolId = c.enrolId " _
                & " Where c.offUnitId = " & Session("offUnitId") & " " _
                & " And c.stuId = '" & Session("userId") & "' "

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

#Region "last meeting"

    Protected Sub ddlTitle_Last_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTitle_Last.SelectedIndexChanged
        If ddlTitle_Last.SelectedIndex = 99 Then
            txtOther_Last.Visible = True
        Else
            txtOther_Last.Visible = False
        End If
    End Sub

    Protected Sub ddlDate_Last_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDate_Last.SelectedIndexChanged
        If ddlTitle_Last.SelectedIndex = 4 Then
            txtDate_Last.Visible = True
        Else
            txtDate_Last.Visible = False
        End If
    End Sub

    Protected Sub btnAdd_Last_Click(sender As Object, e As EventArgs) Handles btnAdd_Last.Click
        Dim dupStu As Boolean = False
        Dim title As String = ""
        If ddlTitle_Last.SelectedIndex = 0 Then
            title = txtOther_Last.Text
        Else
            title = ddlTitle_Last.SelectedItem.ToString()
        End If

        Dim details As String = txtDetails_Last.Text

        Dim person As String = ""
        If ddlPerson_Last.SelectedIndex = 0 Then
            person = "All"
        Else
            person = ddlPerson_Last.SelectedItem.ToString()
        End If

        Dim duedate As String = ""
        If ddlDate_Last.SelectedIndex = 4 Then
            duedate = txtDate_Last.Text
        Else
            duedate = ddlDate_Last.SelectedItem.ToString()
        End If

        Dim action As String = ddlAction_Last.SelectedItem.ToString()

        If DT_Student.Columns.Count = 0 Then

            DT_Student.Columns.Add("title", GetType(String))
            DT_Student.Columns.Add("details", GetType(String))
            DT_Student.Columns.Add("person", GetType(String))
            DT_Student.Columns.Add("duedate", GetType(String))
            DT_Student.Columns.Add("action", GetType(String))
            DT_Student.Columns.Add("teamenrolIdK", GetType(String))
            DT_Student.Columns.Add("titleK", GetType(String))
            DT_Student.Columns.Add("detailsK", GetType(String))
            DT_Student.Columns.Add("personK", GetType(String))
            DT_Student.Columns.Add("duedateK", GetType(String))
            DT_Student.Columns.Add("actionK", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow
        R("title") = title
        R("details") = details
        R("person") = person
        R("duedate") = duedate
        R("action") = action
        R("teamenrolIdK") = ddlPerson_Last.SelectedValue.ToString()
        R("titleK") = title
        R("detailsK") = details
        R("personK") = person
        R("duedateK") = duedate
        R("actionK") = action

        For Each GVRow As GridViewRow In Me.gvAdd_Last.Rows

            Dim K1 As DataKey = Me.gvAdd_Last.DataKeys(GVRow.RowIndex)
            Dim ckTitle As String = K1(0)

            If title = ckTitle Then
                dupStu = True
            End If
        Next

        If Not (dupStu) Then
            DT_Student.Rows.Add(R)
            gvAdd_Last.DataSource = DT_Student
            gvAdd_Last.DataBind()
        Else
            Dim errMsg = "This title already added"
            alert(errMsg)
        End If
    End Sub

    Protected Sub btnCancel_Last_Click(sender As Object, e As EventArgs) Handles btnCancel_Last.Click
        ddlTitle_Last.SelectedIndex = 0
        txtOther_Last.Text = ""
        txtOther_Last.Visible = False
        txtDetails_Last.Text = ""
        ddlPerson_Last.SelectedIndex = 0
        ddlDate_Last.SelectedIndex = 0
        txtDate_Last.Text = ""
        txtDate_Last.Visible = False
        ddlAction_Last.SelectedIndex = 0
    End Sub

    Protected Sub gvAdd_Last_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAdd_Last.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Student.Rows.RemoveAt(index)
        gvAdd_Last.DataSource = DT_Student
        gvAdd_Last.DataBind()
    End Sub

#End Region

#Region "present"
    Protected Sub btnAdd_Present_Click(sender As Object, e As EventArgs) Handles btnAdd_Present.Click
        DT_Student.Clear()
        Dim dupStu As Boolean = False
        Dim title As String = ""
        If ddlTitle_Present.SelectedIndex = 0 Then
            title = txtOther_present.Text
        Else
            title = ddlTitle_Present.SelectedItem.ToString()
        End If

        Dim details As String = txtDetails_Present.Text

        Dim person As String = ""
        If ddlPerson_Present.SelectedIndex = 0 Then
            person = "All"
        Else
            person = ddlPerson_Present.SelectedItem.ToString()
        End If

        Dim duedate As String = ""
        If ddlDate_Present.SelectedIndex = 4 Then
            duedate = txtDate_Present.Text
        Else
            duedate = ddlDate_Present.SelectedItem.ToString()
        End If

        Dim action As String = ddlAction_Present.SelectedItem.ToString()

        If DT_Student.Columns.Count = 0 Then

            DT_Student.Columns.Add("title", GetType(String))
            DT_Student.Columns.Add("details", GetType(String))
            DT_Student.Columns.Add("person", GetType(String))
            DT_Student.Columns.Add("duedate", GetType(String))
            DT_Student.Columns.Add("action", GetType(String))
            DT_Student.Columns.Add("teamenrolIdK", GetType(String))
            DT_Student.Columns.Add("titleK", GetType(String))
            DT_Student.Columns.Add("detailsK", GetType(String))
            DT_Student.Columns.Add("personK", GetType(String))
            DT_Student.Columns.Add("duedateK", GetType(String))
            DT_Student.Columns.Add("actionK", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow

        R("title") = title
        R("details") = details
        R("person") = person
        R("duedate") = duedate
        R("action") = action
        R("teamenrolIdK") = ddlPerson_Last.SelectedValue.ToString()
        R("titleK") = title
        R("detailsK") = details
        R("personK") = person
        R("duedateK") = duedate
        R("actionK") = action

        For Each GVRow As GridViewRow In Me.gvAdd_Present.Rows

            Dim K1 As DataKey = Me.gvAdd_Present.DataKeys(GVRow.RowIndex)
            Dim ckTitle As String = K1(0)

            If title = ckTitle Then
                dupStu = True
            End If
        Next

        If Not (dupStu) Then
            DT_Student.Rows.Add(R)
            gvAdd_Present.DataSource = DT_Student
            gvAdd_Present.DataBind()
        Else
            Dim errMsg = "This title already added"
            alert(errMsg)
        End If
    End Sub

    Protected Sub gvAdd_Present_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAdd_Present.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Student.Rows.RemoveAt(index)
        gvAdd_Present.DataSource = DT_Student
        gvAdd_Present.DataBind()
    End Sub
#End Region

#Region "next meeting"
    Protected Sub btnAdd_Next_Click(sender As Object, e As EventArgs) Handles btnAdd_Next.Click
        DT_Student.Clear()
        Dim dupStu As Boolean = False
        Dim title As String = ""

        title = txtTitle_Next.Text
        If title = "" Then
            alert("Please add title for next meeting")
            Exit Sub
        End If


        Dim details As String = txtDetails_Next.Text

        Dim person As String = ""
        If ddlPerson_Next.SelectedIndex = 0 Then
            person = "All"
        Else
            person = ddlPerson_Next.SelectedItem.ToString()
        End If

        Dim duedate As String = ""
        If ddlDate_Next.SelectedIndex = 4 Then
            duedate = txtDate_Next.Text
        Else
            duedate = ddlDate_Next.SelectedItem.ToString()
        End If

        If DT_Student.Columns.Count = 0 Then

            DT_Student.Columns.Add("title", GetType(String))
            DT_Student.Columns.Add("details", GetType(String))
            DT_Student.Columns.Add("person", GetType(String))
            DT_Student.Columns.Add("duedate", GetType(String))
            DT_Student.Columns.Add("action", GetType(String))
            DT_Student.Columns.Add("teamenrolIdK", GetType(String))
            DT_Student.Columns.Add("titleK", GetType(String))
            DT_Student.Columns.Add("detailsK", GetType(String))
            DT_Student.Columns.Add("personK", GetType(String))
            DT_Student.Columns.Add("duedateK", GetType(String))
            DT_Student.Columns.Add("actionK", GetType(String))
        End If

        Dim R As DataRow = DT_Student.NewRow

        R("title") = title
        R("details") = details
        R("person") = person
        R("duedate") = duedate
        R("action") = ""
        R("teamenrolIdK") = ddlPerson_Last.SelectedValue.ToString()
        R("titleK") = title
        R("detailsK") = details
        R("personK") = person
        R("duedateK") = duedate
        R("actionK") = ""

        For Each GVRow As GridViewRow In Me.gvAdd_Next.Rows

            Dim K1 As DataKey = Me.gvAdd_Next.DataKeys(GVRow.RowIndex)
            Dim ckTitle As String = K1(0)

            If title = ckTitle Then
                dupStu = True
            End If
        Next

        If Not (dupStu) Then
            DT_Student.Rows.Add(R)
            gvAdd_Next.DataSource = DT_Student
            gvAdd_Next.DataBind()
        Else
            Dim errMsg = "This title already added"
            alert(errMsg)
        End If
    End Sub

    Protected Sub gvAdd_Next_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAdd_Next.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Student.Rows.RemoveAt(index)
        gvAdd_Next.DataSource = DT_Student
        gvAdd_Next.DataBind()
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
            loaddata()
            loadMeeting()
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim meetingId As String = ddlMeeting.SelectedValue

        For Each GVRow As GridViewRow In Me.gvAdd_Last.Rows

            Dim K1 As DataKey = Me.gvAdd_Last.DataKeys(GVRow.RowIndex)

            'teamenrolIdK,titleK,detailsK,personK,duedateK,actionK
            cmd.CommandText = "ADD_MEETING_MINUTES;"
            cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
            cmd.Parameters.AddWithValue("@pcatagory", "Last")
            cmd.Parameters.AddWithValue("@pminutesTitle", K1(1))
            cmd.Parameters.AddWithValue("@pminutesDetails", K1(2))
            cmd.Parameters.AddWithValue("@pactionDetails", K1(5))
            cmd.Parameters.AddWithValue("@pduedate", K1(4))
            cmd.Parameters.AddWithValue("@pteamEnrolId", K1(0))

            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg <> "SUCCESS" Then
                    loaddata()
                    alert(resultMsg)
                    resultMsg = ""
                    Exit Sub
                End If
                resultMsg = ""
            Catch ex As Exception
                alert("Fail to update, please Try again or contact IT support.")
                resultMsg = ""
                cmd.Parameters.Clear()
                Exit Sub
            End Try

        Next

        For Each GVRow As GridViewRow In Me.gvAdd_Present.Rows

            Dim K1 As DataKey = Me.gvAdd_Present.DataKeys(GVRow.RowIndex)

            'teamenrolIdK,titleK,detailsK,personK,duedateK,actionK
            cmd.CommandText = "ADD_MEETING_MINUTES;"
            cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
            cmd.Parameters.AddWithValue("@pcatagory", "Present")
            cmd.Parameters.AddWithValue("@pminutesTitle", K1(1))
            cmd.Parameters.AddWithValue("@pminutesDetails", K1(2))
            cmd.Parameters.AddWithValue("@pactionDetails", K1(5))
            cmd.Parameters.AddWithValue("@pduedate", K1(4))
            cmd.Parameters.AddWithValue("@pteamEnrolId", K1(0))

            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg <> "SUCCESS" Then
                    loaddata()
                    alert(resultMsg)
                    resultMsg = ""
                    Exit Sub
                End If
                resultMsg = ""
            Catch ex As Exception
                alert("Fail to update, please Try again or contact IT support.")
                resultMsg = ""
                cmd.Parameters.Clear()
                Exit Sub
            End Try

        Next

        For Each GVRow As GridViewRow In Me.gvAdd_Next.Rows

            Dim K1 As DataKey = Me.gvAdd_Next.DataKeys(GVRow.RowIndex)

            'teamenrolIdK,titleK,detailsK,personK,duedateK,actionK
            cmd.CommandText = "ADD_MEETING_MINUTES;"
            cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
            cmd.Parameters.AddWithValue("@pcatagory", "Next")
            cmd.Parameters.AddWithValue("@pminutesTitle", K1(1))
            cmd.Parameters.AddWithValue("@pminutesDetails", K1(2))
            cmd.Parameters.AddWithValue("@pactionDetails", K1(5))
            cmd.Parameters.AddWithValue("@pduedate", K1(4))
            cmd.Parameters.AddWithValue("@pteamEnrolId", K1(0))

            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg <> "SUCCESS" Then
                    loaddata()
                    alert(resultMsg)
                    resultMsg = ""
                    Exit Sub
                End If
                resultMsg = ""
            Catch ex As Exception
                alert("Fail to update, please Try again or contact IT support.")
                resultMsg = ""
                cmd.Parameters.Clear()
                Exit Sub
            End Try

        Next
        alert("Data entered successfully.")
        clear()
        loadProject()
        loaddata()
        ' trCriteria.Visible = False
    End Sub


    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = ""
        If ddlSearch.SelectedIndex > 0 Then
            searchTerm = " and a.meetingId = '" & ddlSearch.SelectedValue.ToString() & "' "
        End If

        SQL(0) = " Select * " _
                & " From meetingminutes a " _
                & " Join teamenrol b on a.teamenrolId = b.teamenrolId " _
                & " Join enrolment c On b.enrolId = c.enrolId " _
                & " Where c.offUnitId = " & Session("offUnitId") & " " _
                & " And c.stuId = '" & Session("userId") & "' " _
                & searchTerm

        DT = M1.GetDatatable(SQL(0))
        Try
            gvData.DataSource = DT
            gvData.DataBind()
        Catch ex As Exception
            gvData.DataSource = Nothing
            gvData.DataBind()
        End Try
    End Sub
End Class