Public Class dashboard_2
    Inherits System.Web.UI.Page

    Sub checkMenu()
        Me.divAdmin.Style.Value = "Display:none"
        Me.divConvenor.Style.Value = "Display:none"
        Me.divSupervisor.Style.Value = "Display:none"
        Me.divStudent.Style.Value = "Display:none"

        If Session("userRole_tmp") = "Convenor" Then
            'Convenor
            Me.divConvenor.Style.Value = ""

            SQL(0) = " Select concat(unitId , ' - ', unitDesc, ' (', unitName, ') ') as unitStr " _
                    & " from unit " _
                    & " where unitId = '" & Session("unitID") & "' "
            DT = M1.GetDatatable(SQL(0))
            Session("unit_tmp") = DT.Rows(0)("unitStr").ToString()
            Session("year_tmp") = ""
            Session("sem_tmp") = ""
            lblUnit.Text = Session("unit_tmp")
            lblYearSem.Text = Session("year_tmp") & Session("sem_tmp")
        ElseIf Session("userRole_tmp") = "Supervisor" Then
            'Supervisor
            Me.divSupervisor.Style.Value = ""

            SQL(0) = " Select f.unitId, f.unitDesc, concat(f.unitId , ' - ', f.unitDesc, ' (', f.unitName, ') ') as unitStr, " _
                    & " c.offUnitYear, c.offUnitSem " _
                    & " from offeredunit c " _
                    & " join unit f on c.unitId = f.unitId " _
                    & " where c.offUnitId = " & Session("offUnitId") & " "
            DT = M1.GetDatatable(SQL(0))
            Session("unit_tmp") = DT.Rows(0)("unitStr").ToString()
            Session("year_tmp") = DT.Rows(0)("offUnitYear").ToString()
            Session("sem_tmp") = "  Semester " & DT.Rows(0)("offUnitSem").ToString()
            lblUnit.Text = Session("unit_tmp")
            lblYearSem.Text = Session("year_tmp") & Session("sem_tmp")
        ElseIf Session("userRole_tmp") = "Student" Then
            'Student
            Me.divStudent.Style.Value = ""

            SQL(0) = " Select f.unitId, f.unitDesc, concat(f.unitId , ' - ', f.unitDesc, ' (',  f.unitName, ') ') as unitStr, " _
                    & " c.offUnitYear, c.offUnitSem " _
                    & " from offeredunit c " _
                    & " join unit f on c.unitId = f.unitId " _
                    & " where c.offUnitId = " & Session("offUnitId") & " "
            DT = M1.GetDatatable(SQL(0))
            Session("unit_tmp") = DT.Rows(0)("unitStr").ToString()
            Session("year_tmp") = DT.Rows(0)("offUnitYear").ToString()
            Session("sem_tmp") = "  Semester " & DT.Rows(0)("offUnitSem").ToString()
            lblUnit.Text = Session("unit_tmp")
            lblYearSem.Text = Session("year_tmp") & Session("sem_tmp")

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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("userRole_tmp") = "" Then
            Response.Redirect("dashboard.aspx")
        Else
            checkMenu()
        End If
    End Sub

End Class