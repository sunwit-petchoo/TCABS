Public Class Report_Team
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub

    Public Sub BindGridviewData()
        SQL(0) = "SELECT offeredUnit.unitId, team.teamNo, count(team.projId) As totTeams, student.stuId, student.stuName FROM teamEnrol" _
                & "INNER JOIN enrolment On enrolment.enrolId = teamEnrol.enrolId" _
                & "INNER JOIN student ON student.stuId = enrolment.stuId" _
                & "INNER JOIN team On teamEnrol.teamId = team.teamId" _
                & "INNER JOIN project ON project.projId = team.projId" _
                & "INNER JOIN offeredUnit On offeredUnit.offUnitId = project.offUnitId" _
                & "GROUP BY offeredUnit.unitId"
        DT = M1.GetDatatable(SQL(0))
        Try
            gvDetails.DataSource = DT
            gvDetails.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class