Public Class SiteMaster
    Inherits MasterPage

    Sub checkMenu()
        Me.divAdmin.Style.Value = "Display:none"
        Me.divConvenor.Style.Value = "Display:none"
        Me.divSupervisor.Style.Value = "Display:none"
        Me.divStudent.Style.Value = "Display:none"

        If Session("userRole") = "Admin" Then
            Me.divAdmin.Style.Value = ""
        ElseIf Session("userRole_tmp") = "Convenor" Then
            Me.divConvenor.Style.Value = ""
        ElseIf Session("userRole_tmp") = "Supervisor" Then
            Me.divSupervisor.Style.Value = ""
        ElseIf Session("userRole_tmp") = "Student" Then
            Me.divStudent.Style.Value = ""
            SQL(0) = " Select PM_Role " _
                    & " From teamEnrol a " _
                    & " join enrolment b on a.enrolId = b.enrolId " _
                    & " where b.stuId = '" & Session("userId") & "' "
            DT = M1.GetDatatable(SQL(0))
            If DT.Rows(0)("PM_Role").ToString() = 0 Then
                divPM_taskAccept.Visible = False
            Else
                divPM_taskAccept.Visible = True
            End If
        End If

        'Dim userRole() As String = Session("userRole").ToString().Trim().Split(",")
        'Dim i As Integer = 0
        'For i = 0 To userRole.Length - 1
        'If userRole(i) = "Admin" Then 'Admin
        'Me.divAdmin.Style.Value = ""
        'ElseIf userRole(i) = "Convenor" Then 'Convenor
        'Me.divConvenor.Style.Value = ""
        'ElseIf userRole(i) = "Supervisor" Then 'Supervisor
        'Me.divSupervisor.Style.Value = ""
        'End If
        'Next
        'If Session("userRole") = "Student" Then
        'Me.divStudent.Style.Value = ""
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Session("userRole") = "" Then
            Response.Redirect("login.aspx")
        Else
            checkMenu()
        End If

        lblUnit.Text = Session("unit_tmp")
        lblYearSem.Text = Session("year_tmp") & Session("sem_tmp")
    End Sub

End Class