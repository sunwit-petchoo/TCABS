Public Class dashboard
    Inherits System.Web.UI.Page

    Dim i As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.divUnitConv.Style.Value = "Display:none"
        Me.divUnitSup.Style.Value = "Display:none"
        Me.divUnitStu.Style.Value = "Display:none"

        Me.divAdmin.Style.Value = "Display:none"
        Me.divConvenor.Style.Value = "Display:none"
        Me.divSupervisor.Style.Value = "Display:none"
        Me.divStudent.Style.Value = "Display:none"

        If Session("userRole") = "" Then
            Response.Redirect("login.aspx")
        Else
            Dim userRole() As String = Session("userRole").ToString().Trim().Split(",")
            For i = 0 To userRole.Length - 1
                '--Check Menu
                If userRole(i) = "Admin" Then 'Admin
                    Me.divAdmin.Style.Value = ""
                    divRegisteredUnit.Style.Value = "Display:none"
                Else
                    '--Check Dashboard
                    If userRole(i) = "Convenor" Then
                        '--Convenor
                        Me.divConvenor.Style.Value = ""

                        Me.divUnitConv.Style.Value = ""
                        SQL(0) = " Select DISTINCT f.unitId, f.unitDesc, concat(f.unitId , ' - ', f.unitName) as unitStr, c.offUnitYear " _
                                & " from offeredunit c " _
                                & " join unit f on c.unitId = f.unitId " _
                                & " join employeeenrolment d On c.empEnrolId = d.empEnrolId " _
                                & " join employee e on d.empId = e.empId " _
                                & " where d.empId = " & Session("userId") & " " _
                                & " And (c.offUnitStart >= curdate() Or curdate() <= c.offUnitEnd) "
                        DT = M1.GetDatatable(SQL(0))
                        gvConvenor.DataSource = DT
                        gvConvenor.DataBind()
                    ElseIf userRole(i) = "Supervisor" Then
                        '--Supervisor
                        Me.divSupervisor.Style.Value = ""

                        Me.divUnitSup.Style.Value = ""
                        SQL(0) = " Select DISTINCT concat(f.unitId , ' - ', f.unitName) as unitStr, f.unitDesc," _
                                & " c.offUnitYear, concat( 'Semester ', c.offUnitSem) as semStr, c.offUnitId " _
                                & " from team a  " _
                                & " join project b on a.projId = b.projId " _
                                & " join offeredunit c On b.offUnitId = c.offUnitId " _
                                & " join unit f on c.unitId = f.unitId " _
                                & " join employeeenrolment d On a.empEnrolId = d.empEnrolId " _
                                & " join employee e on d.empId = e.empId " _
                                & " where d.empId = " & Session("userId") & " " _
                                & " And curdate() between c.offUnitStart And c.offUnitEnd "
                        DT = M1.GetDatatable(SQL(0))
                        gvSupervisor.DataSource = DT
                        gvSupervisor.DataBind()
                    ElseIf userRole(i) = "Student" Then
                        '--Student
                        Me.divStudent.Style.Value = ""

                        Me.divUnitStu.Style.Value = ""
                        SQL(0) = " Select a. offUnitId, concat(c.unitId , ' - ', c.unitName) as unitStr, c.unitDesc, " _
                            & " b.offUnitYear, concat( 'Semester ', b.offUnitSem) as semStr " _
                            & " From enrolment a " _
                            & " join offeredunit b " _
                            & " on a.offUnitId = b.offUnitId " _
                            & " join unit c " _
                            & " on b.unitId = c.unitId " _
                            & " where a.stuId = " & Session("userId") & " " _
                            & " And curdate() between offUnitStart and offUnitEnd "
                        DT = M1.GetDatatable(SQL(0))
                        gvStudent.DataSource = DT
                        gvStudent.DataBind()

                        SQL(0) = " Select PM_Role " _
                                & " From teamEnrol a " _
                                & " join enrolment b on a.enrolId = b.enrolId " _
                                & " where b.stuId = '" & Session("userId") & "' "
                        DT = M1.GetDatatable(SQL(0))
                        Try
                            If DT.Rows(0)("PM_Role").count() = 0 Then
                                divPM_taskAccept.Visible = False
                            Else
                                divPM_taskAccept.Visible = True
                            End If
                        Catch ex As Exception
                            divPM_taskAccept.Visible = False
                        End Try

                    End If
                End If
            Next
        End If
    End Sub

#Region "Dashboard"

    Protected Sub gvConvenor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConvenor.SelectedIndexChanged
        Session("userRole_tmp") = "Convenor"
        Session("unitId") = gvConvenor.SelectedRow.Cells(0).Text
        Response.Redirect("dashboard_2.aspx")
    End Sub

    Protected Sub gvSupervisor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvSupervisor.SelectedIndexChanged
        Session("userRole_tmp") = "Supervisor"
        Session("offUnitId") = gvSupervisor.SelectedRow.Cells(0).Text
        Response.Redirect("dashboard_2.aspx")
    End Sub

    Protected Sub gvStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvStudent.SelectedIndexChanged
        Session("userRole_tmp") = "Student"
        Session("offUnitId") = gvStudent.SelectedRow.Cells(0).Text
        Response.Redirect("dashboard_2.aspx")
    End Sub

#End Region

End Class