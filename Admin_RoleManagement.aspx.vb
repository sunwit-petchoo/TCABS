Imports System.Data
Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports MySql.Data


Public Class Admin_RoleManagement
    Inherits System.Web.UI.Page


    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "loaddata"

    Sub loaddata()
        SQL(0) = "select * from role"
        DT = M1.GetDatatable(SQL(0))
        gvRole.DataSource = DT
        gvRole.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub


#End Region

    Protected Sub Btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim proleName1 As String = Me.txtRoleName.Text
        Dim proleDesc1 As String = Me.txtRoleDesc.Text
        Dim proleType1 As String = txtRoleType.Text

        cmd.CommandText = "SP_ADD_ROLE"
        cmd.Parameters.AddWithValue("@proleName", proleName1)
        cmd.Parameters.AddWithValue("@proleDesc", proleDesc1)
        cmd.Parameters.AddWithValue("@proleType", proleType1)

        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                txtRoleName.Text = ""
                txtRoleDesc.Text = ""
                txtRoleType.Text = ""
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
            cmd.Parameters.Clear()
            resultMsg = ""
        End Try

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = " select * from role " _
        & " Where roleName Like '" & searchTerm & "' "
        DT = M1.GetDatatable(SQL(0))
        gvRole.DataSource = DT
        gvRole.DataBind()
    End Sub


#Region "Gridview"
    Protected Sub gvRole_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvRole.RowDeleting
        Dim index As Integer = e.RowIndex
        Dim proleId As String = Me.gvRole.DataKeys(index).Values(0).ToString()
        Dim rvPrm As MySqlParameter = New MySqlParameter
        cmd.CommandText = "SP_DELETE_ROLE;"
        cmd.Parameters.AddWithValue("@proleId", proleId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data deleted successfully")
                gvRole.EditIndex = -1
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Fail to delete, please Try again.")
            cmd.Parameters.Clear()
            resultMsg = ""
        End Try
    End Sub
    Protected Sub gvRole_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvRole.RowCancelingEdit
        gvRole.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gvRole_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvRole.RowUpdating
        Dim index As Integer = e.RowIndex
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim roleId As String = Me.gvRole.DataKeys(index).Values(0).ToString()
        Dim roleName As TextBox = CType(gvRole.Rows(e.RowIndex).FindControl("txtroleName"), TextBox)
        Dim roleDesc As TextBox = CType(gvRole.Rows(e.RowIndex).FindControl("txtroleDesc"), TextBox)
        Dim roleType As TextBox = CType(gvRole.Rows(e.RowIndex).FindControl("txtroleType"), TextBox)

        If roleName.Text = "" Then
            alert("please enter updated role name")
            Exit Sub
        ElseIf roleDesc.Text = "" Then
            alert("please enter updated role description")
            Exit Sub
        ElseIf roleType.Text = "" Then
            alert("please enter updated role type")
            Exit Sub
        End If

        cmd.CommandText = "SP_UPDATE_ROLE;"
        cmd.Parameters.AddWithValue("@proleId", roleId)
        cmd.Parameters.AddWithValue("@proleName", roleName.Text)
        cmd.Parameters.AddWithValue("@proleDesc", roleDesc.Text)
        cmd.Parameters.AddWithValue("@proleType", roleType.Text)

        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data edited successfully")
                gvRole.EditIndex = -1
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Fail to update, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

    Protected Sub gvRole_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvRole.RowEditing
        gvRole.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gvRole_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvRole.SelectedIndexChanging
        Dim k1 As DataKey = gvRole.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvRole_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvRole.PageIndexChanging
        Me.gvRole.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvRole.PageIndex
        loaddata()
    End Sub

    Protected Sub gvRole_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRole.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem()

            If e.Row.DataItem("roleId") = "1" Or e.Row.DataItem("roleId") = "2" Or e.Row.DataItem("roleId") = "3" Then
                e.Row.Cells(4).Text = ""
                e.Row.Cells(5).Text = ""
            End If
        End If
    End Sub

#End Region

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtRoleName.Text = ""
        txtRoleDesc.Text = ""
        txtRoleType.Text = ""

    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub


End Class