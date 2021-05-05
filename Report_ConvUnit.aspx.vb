Public Class Report_ConvUnit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub

    Public Sub BindGridviewData()
        SQL(0) = "SELECT unit.unitID, unit.unitName, role.roleName, employee.empId FROM offeredUnit " _
                & " INNER Join unit ON offeredUnit.unitId = unit.unitId " _
                & " INNER Join employeeEnrolment ON offeredUnit.empEnrolId = employeeEnrolment.empEnrolId " _
                & " INNER Join role ON employeeEnrolment.roleId = role.roleId " _
                & " INNER Join employee ON employeeEnrolment.empId = employee.empId " _
                & " WHERE role.roleName = 'Convenor'"
        DT = M1.GetDatatable(SQL(0))
        Try
            gvDetails.DataSource = DT
            gvDetails.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class