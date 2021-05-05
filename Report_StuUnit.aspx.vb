Public Class Report_StuUnit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub

    Public Sub BindGridviewData()
        SQL(0) = "SELECT student.stuID, student.stuName, offeredUnit.unitId FROM student " _
                & " INNER JOIN enrolment On student.stuId = enrolment.stuId " _
                & " INNER JOIN offeredUnit ON enrolment.offUnitId = offeredUnit.offUnitId "
        DT = M1.GetDatatable(SQL(0))
        Try
            gvDetails.DataSource = DT
            gvDetails.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class