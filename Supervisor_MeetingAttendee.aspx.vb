Imports MySql.Data.MySqlClient

Public Class Supervisor_MeetingAttendee
    Inherits System.Web.UI.Page

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Sub clear()
        ddlProject.SelectedIndex = 0
        'lblTeam.Text = ""
        ddlMeeting.Items.Clear()
        ddlMeeting.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlTeam.Items.Clear()
        ddlTeam.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        gvStudent.DataSource = Nothing
        gvStudent.DataBind()
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
            Me.ddlMeeting.Focus()
            alert("Please select meeting")
            chk = 0
        ElseIf ddlTeam.SelectedItem.Value = "0" Then
            Me.ddlMeeting.Focus()
            alert("Please select Team")
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

    Sub loadTeam()
        SQL(0) = " Select * " _
                & " From teamenrol a  " _
                & " join enrolment b on a.enrolId = b.enrolId " _
                & " join student c On b.stuId = c.stuId " _
                & " join team d on d.teamId = a.teamId " _
                & " join meeting e On e.teamId = d.teamId " _
                & " left join meetingAttendee f On e.meetingId = f.meetingId " _
                & " Where e.meetingId = " & ddlMeeting.SelectedValue.ToString() & " "
        DT = M1.GetDatatable(SQL(0))
        Try
            gvStudent.DataSource = DT
            gvStudent.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        ddlMeeting.Items.Clear()
        ddlMeeting.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlTeam.Items.Clear()
        ddlTeam.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select * from team a Join employeeenrolment b on a.empEnrolId = b.empEnrolId  " _
                 & " where empId = '" & Session("userId") & "' " _
                 & " And a.projId = " & ddlProject.SelectedValue & " "

        DT = M1.GetDatatable(SQL(0))
        ddlTeam.DataSource = DT
        ddlTeam.DataTextField = "teamTitle"
        ddlTeam.DataValueField = "teamId"
        ddlTeam.DataBind()
    End Sub

    Protected Sub ddlTeam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTeam.SelectedIndexChanged
        ddlMeeting.Items.Clear()
        ddlMeeting.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "  Select * from meeting " _
                 & " where teamId = " & ddlTeam.SelectedValue _
                 & " and meetingStatus = 'Created' and meetingType = 'Supervisor meeting'"

        DT = M1.GetDatatable(SQL(0))
        ddlMeeting.DataSource = DT
        ddlMeeting.DataTextField = "meetingTopic"
        ddlMeeting.DataValueField = "meetingId"
        ddlMeeting.DataBind()
    End Sub

    Protected Sub ddlMeeting_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMeeting.SelectedIndexChanged
        loadTeam()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
        End If
    End Sub

#End Region

#Region "gvStudent"

    Protected Sub gvStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudent.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem()
            Dim ddlAttendStatus As DropDownList = e.Row.FindControl("ddlAttendStatus")
            Dim txtComments As TextBox = e.Row.FindControl("txtComments")

            For Each GVRow As GridViewRow In gvStudent.Rows
                Dim K1 As DataKey = gvStudent.DataKeys(GVRow.RowIndex)
                ' 0 
                'teamEnrolId
                SQL(0) = " Select teamEnrolId, attendStatus, comments " _
                        & " From MeetingAttendee " _
                        & " Where meetingId = '" & ddlMeeting.SelectedValue.ToString() & "' " _
                        & " And teamEnrolId = " & K1(0) & " "
                DT = M1.GetDatatable(SQL(0))
                Try
                    If DT.Rows(0)("teamEnrolId").ToString() = K1(0) Then
                        ddlAttendStatus.SelectedValue = DT.Rows(0)("attendStatus").ToString()
                        txtComments.Text = DT.Rows(0)("teamEnrolId").ToString()
                    Else
                        ddlAttendStatus.SelectedIndex = 0
                        txtComments.Text = ""
                    End If
                Catch ex As Exception
                    ddlAttendStatus.SelectedIndex = 0
                    txtComments.Text = ""
                End Try
            Next
        End If
    End Sub

#End Region

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        For Each GVRow As GridViewRow In Me.gvStudent.Rows
            Dim K1 As DataKey = Me.gvStudent.DataKeys(GVRow.RowIndex)
            '   0          1          2           3            4          5              6            7               8
            '"submitId", "stuId", "stuName", "taskTitle", "taskDesc", "tmRolName", "minutesTaken", "submitDate", "taskStatus"
            Dim rvPrm As MySqlParameter = New MySqlParameter
            Dim meetingId As String = ddlMeeting.SelectedValue.ToString()
            Dim teamEnrolId As String = K1(0)
            Dim attendStatus As DropDownList = GVRow.FindControl("ddlAttendStatus")
            Dim attendStatusVal As String = attendStatus.SelectedValue.ToString
            Dim comments As TextBox = GVRow.FindControl("txtComments")
            Dim commentsVal As String = comments.Text

            cmd.CommandText = "ADD_MEETINGATTENDEE;"
            cmd.Parameters.AddWithValue("@pmeetingId", meetingId)
            cmd.Parameters.AddWithValue("@pteamEnrolId", teamEnrolId)
            cmd.Parameters.AddWithValue("@pattendStatus", attendStatusVal)
            cmd.Parameters.AddWithValue("@pcomments", commentsVal)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg <> "SUCCESS" Then
                    'loaddata()
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
        'loaddata()
        alert("Update data successfully") : Exit Sub
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
    End Sub

End Class