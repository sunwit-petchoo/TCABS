Public Class login
    Inherits System.Web.UI.Page

    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Function check() As Boolean
        Dim chk As String = 1

        If txtUsername.Text = "" Then
            Me.txtUsername.Focus()
            alert("Please enter username")
            chk = 0
        ElseIf txtPwd.Text = "" Then
            Me.txtPwd.Focus()
            alert("Please enter password")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub clearSession()
        Session("userId") = ""
        Session("userName") = ""
        Session("userRole") = ""
        Session("userRole_tmp") = ""
        Session("offUnitId") = ""
        Session("unitId") = ""
        Session("unit_tmp") = ""
        Session("year_tmp") = ""
        Session("sem_tmp") = ""
        Session("teamEnrolId") = ""
    End Sub

    Sub authen()
        Dim chk As String = 1
        Dim i As Integer = 0
        Dim userRoleStr As New StringBuilder("")

        SQL(0) = " Select a.empId, b.empName, c.roleName, c.roleId " _
                & " From employeeEnrolment a " _
                & " Join employee b " _
                & " On a.empId = b.empId " _
                & " Join role c " _
                & " On a.roleId = c.roleId " _
                & " Where a.empId = '" & txtUsername.Text & "' "
        DT = M1.GetDatatable(SQL(0))
        If DT.Rows.Count() = 0 Then
            '--Student
            SQL(0) = " Select * From student " _
                & " Where stuId = '" & txtUsername.Text & "' "
            DT = M1.GetDatatable(SQL(0))
            If DT.Rows.Count() = 0 Then
                chk = 0
            Else
                Session("userId") = DT.Rows(0)("stuId").ToString()
                Session("userName") = DT.Rows(0)("stuName").ToString()
                Session("userRole") = "Student"
            End If
        Else
            '--Admin, Convenor, Supervisor
            Session("userId") = DT.Rows(0)("empId").ToString()
            Session("userName") = DT.Rows(0)("empName").ToString()

            For i = 0 To DT.Rows.Count - 1
                If userRoleStr.Length > 0 Then userRoleStr.Append(",")
                userRoleStr.Append(Trim(DT.Rows(i).Item("roleName").ToString()))
            Next
            Session("userRole") = userRoleStr.ToString()
        End If

        If chk = 0 Then
            alert("Username or Password is incorrect. Please try again.")
        Else
            Response.Redirect("dashboard.aspx")
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        authen()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            clearSession()
        End If
    End Sub

End Class