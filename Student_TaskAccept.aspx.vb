Imports MySql.Data.MySqlClient

Public Class Student_TaskAccept
    Inherits System.Web.UI.Page

#Region "check"

    Function check() As Boolean
        Dim chk As String = 1

        If ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf gv_Show.Rows.Count = 0 Then
            alert("There is no task to be approved")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub
#End Region

    Sub loaddata()
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = " select projId, projName from project where offUnitId = " _
            & Session("offUnitId") _
            & " order by projName"
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
        ddlProject.SelectedIndex() = 0
        DT = Nothing
        gv_Show.DataSource = DT
        gv_Show.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        SQL(0) = "  Select a.submitId, e.stuId, e.stuName, c.taskTitle, c.taskDesc, f.tmRolName, a.minutesTaken, " _
                 & " a.submitDate, a.taskStatus from task_submit a " _
                 & " inner Join teamrole f on f.tmRolId = a.tmRolId " _
                 & " inner Join teamenrol b on a.teamenrolId = b.teamenrolId  " _
                 & " inner Join task c on c.taskId = a.taskId " _
                 & " inner Join enrolment d on d.enrolId = b.enrolId " _
                 & " inner Join student e on e.stuId = d.stuId " _
                 & " where c.projId =  " _
                 & ddlProject.SelectedValue _
                 & " and b.teamId in ( " _
                 & " select teamId from teamenrol team inner join enrolment enrol " _
                 & " On team.enrolId = enrol.enrolId where enrol.stuId = " _
                 & Session("userId") _
                 & ") and taskStatus = 'submitted' "

        DT = M1.GetDatatable(SQL(0))
        gv_Show.DataSource = DT
        Dim X() As String = {"submitId", "stuId", "stuName", "taskTitle", "taskDesc", "tmRolName", "minutesTaken", "submitDate", "taskStatus"}
        gv_Show.DataKeyNames = X
        gv_Show.DataBind()
    End Sub

#Region "save"

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        Dim sttChk As Boolean = True

        For Each GVRow As GridViewRow In Me.gv_Show.Rows

            Dim K1 As DataKey = Me.gv_Show.DataKeys(GVRow.RowIndex)
            '   0          1          2           3            4          5              6            7               8
            '"submitId", "stuId", "stuName", "taskTitle", "taskDesc", "tmRolName", "minutesTaken", "submitDate", "taskStatus"    

            Dim RAD_YourApprove As RadioButtonList = GVRow.FindControl("RAD_YourApprove")
            Dim TB_Comment As TextBox = GVRow.FindControl("TB_Comment")
            Dim minutesTaken As TextBox = GVRow.FindControl("txtMinuteTaken")
            Dim minuteStr = minutesTaken.Text
            If RAD_YourApprove.SelectedIndex <> -1 Then

                If (RAD_YourApprove.SelectedValue.ToString() = "unapproved" Or RAD_YourApprove.SelectedValue.ToString() = "resubmit") And TB_Comment.Text = "" Then
                    TB_Comment.Focus()
                    alert("Please enter comments") : Exit Sub
                ElseIf (minuteStr <> K1(6)) And (RAD_YourApprove.SelectedValue.ToString() = "approved") And TB_Comment.Text = "" Then
                    TB_Comment.Focus()
                    alert("Please enter comments for approved with updated value") : Exit Sub
                End If
            Else
                sttChk = False
            End If
        Next

        If sttChk = False Then
            alert("Please select action status") : Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        For Each GVRow As GridViewRow In Me.gv_Show.Rows
            Dim K1 As DataKey = Me.gv_Show.DataKeys(GVRow.RowIndex)
            '   0          1          2           3            4          5              6            7               8
            '"submitId", "stuId", "stuName", "taskTitle", "taskDesc", "tmRolName", "minutesTaken", "submitDate", "taskStatus"

            Dim submitId As String = K1(0)
            Dim minutesTaken As TextBox = GVRow.FindControl("txtMinuteTaken")
            Dim minuteStr = minutesTaken.Text
            Dim isLog As String = "No"
            If minuteStr = "" Then
                alert("please add minute taken")
                minutesTaken.Focus()
                Exit Sub
            ElseIf Not IsNumeric(minuteStr) Then
                alert("minute taken must be number")
                minutesTaken.Focus()
                Exit Sub
            End If


            Dim RAD_YourApprove As RadioButtonList = GVRow.FindControl("RAD_YourApprove")
            Dim TB_Comment As TextBox = GVRow.FindControl("TB_Comment")
            If (minuteStr <> K1(6)) And RAD_YourApprove.SelectedValue.ToString() = "approved" Then
                isLog = "Yes"
            End If

            cmd.CommandText = "UPDATE_TASK_ACCEPT;"
            cmd.Parameters.AddWithValue("@psubmitId", submitId)
            cmd.Parameters.AddWithValue("@pminutesTaken", minuteStr)
            cmd.Parameters.AddWithValue("@ptaskStatus", RAD_YourApprove.SelectedValue.ToString())
            cmd.Parameters.AddWithValue("@pcomment", TB_Comment.Text)
            cmd.Parameters.AddWithValue("@pstuId", Session("userId"))
            cmd.Parameters.AddWithValue("@pisLog", isLog)

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

        loaddata()
        alert("Update data successfully") : Exit Sub

    End Sub

#End Region

End Class