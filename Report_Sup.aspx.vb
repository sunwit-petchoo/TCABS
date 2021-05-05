Public Class Report_Sup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub

    Public Sub BindGridviewData()
        SQL(0) = "SELECT employee.empId, employee.empName, employee.empEmail FROM employee " _
                & " INNER JOIN employeeEnrolment On employee.empId = employeeEnrolment.empId " _
                & " INNER JOIN role ON employeeEnrolment.roleId = role.roleId " _
                & " WHERE role.roleName = 'supervisor'"
        DT = M1.GetDatatable(SQL(0))
        Try
            gvDetails.DataSource = DT
            gvDetails.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class