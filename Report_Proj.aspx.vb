Public Class Report_Proj
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridviewData()
        End If
    End Sub

    Public Sub BindGridviewData()
        SQL(0) = "SELECT * FROM project"
        DT = M1.GetDatatable(SQL(0))
        Try
            gvDetails.DataSource = DT
            gvDetails.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class