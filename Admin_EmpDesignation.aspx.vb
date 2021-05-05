Imports MySql.Data.MySqlClient

Public Class Admin_EmpDesignation
    Inherits System.Web.UI.Page

    Sub loadEmp()

        SQL(0) = "SELECT CONCAT(empId, ': ', empName) as empNameStr,empId from employee order by empId asc;"
        DT = M1.GetDatatable(SQL(0))
        ddlEmpolyee.DataSource = DT
        ddlEmpolyee.DataTextField = "empNameStr"
        ddlEmpolyee.DataValueField = "empId"
        ddlEmpolyee.DataBind()
    End Sub

    Sub loadRole()

        SQL(0) = "select roleName,roleId from role order by roleName asc;"
        DT = M1.GetDatatable(SQL(0))
        ddlRole.DataSource = DT
        ddlRole.DataTextField = "roleName"
        ddlRole.DataValueField = "roleId"
        ddlRole.DataBind()
    End Sub
    Sub loaddata()

        SQL(0) = "select empEnrolId,a.empId as empId, empName, roleName from employeeenrolment a
                  inner join employee b on a.empId = b.empId inner join role c on a.roleId = c.roleId;"
        DT = M1.GetDatatable(SQL(0))
        gvEmpDes.DataSource = DT
        gvEmpDes.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
            loadEmp()
            loadRole()
        End If
    End Sub
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim pempId As Integer = ddlEmpolyee.SelectedValue
        Dim proleId As String = ddlRole.SelectedValue

        cmd.CommandText = "SP_ADD_EMPENROLLMENT;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        cmd.Parameters.AddWithValue("@proleId", proleId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                ClearValue()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Data entered fail, please Try again.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub
    Sub ClearValue()
        DT.Clear()
        ddlEmpolyee.Items.Clear()
        ddlEmpolyee.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        ddlRole.Items.Clear()
        ddlRole.Items.Insert(0, New ListItem("[--Please Select--]", ""))
        loaddata()
        loadEmp()
        loadRole()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "SP_SEARCH_EMPENROLMENT('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvEmpDes.DataSource = DT
        gvEmpDes.DataBind()
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ddlEmpolyee.SelectedIndex() = 0
        ddlRole.SelectedIndex() = 0
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#Region "gvEmpDes"

    Protected Sub gvEmpDes_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEmpDes.RowEditing
        gvEmpDes.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
        Dim role As DropDownList = CType(gvEmpDes.Rows(gvEmpDes.EditIndex).FindControl("ddlRoleEdit"), DropDownList)
        SQL(0) = "select roleId,roleName from role;"
        DT = M1.GetDatatable(SQL(0))
        role.DataSource = DT
        role.DataTextField = "roleName"
        role.DataValueField = "roleId"
        role.DataBind()
    End Sub

    Protected Sub gvEmpDes_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEmpDes.RowUpdating
        Dim index As Integer = e.RowIndex
        Dim empEnrolId As String = Me.gvEmpDes.DataKeys(index).Values(0).ToString()
        Dim role As DropDownList = CType(gvEmpDes.Rows(e.RowIndex).FindControl("ddlRoleEdit"), DropDownList)

        Dim roleStr As String = role.SelectedValue.ToString()

        cmd.CommandText = "UPDATE_EMP_ENROLMENT;"
        cmd.Parameters.AddWithValue("@pempEnrolId", empEnrolId)
        cmd.Parameters.AddWithValue("@proleId", roleStr)

        Try
            M1.Execute(SQL(0))
            If m_ErrorString = "" Then
                alert("Data updated successfully")
                gvEmpDes.EditIndex = -1
                loaddata()
            Else
                alert(m_ErrorString)
                m_ErrorString = ""
                cmd.Parameters.Clear()
                gvEmpDes.EditIndex = -1
                loaddata()
            End If
        Catch ex As Exception
            alert("Fail to update, please Try again.")
            cmd.Parameters.Clear()
        End Try

    End Sub

    Protected Sub gvEmpDes_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmpDes.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim empEnrolId As String = Me.gvEmpDes.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_EMPLOYEEENROLMENT;"
        cmd.Parameters.AddWithValue("@pempEnrolId", empEnrolId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data deleted successfully")
                gvEmpDes.EditIndex = -1
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

    Protected Sub gvEmpDes_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvEmpDes.SelectedIndexChanging
        Dim k1 As DataKey = gvEmpDes.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvEmpDes_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvEmpDes.PageIndexChanging
        Me.gvEmpDes.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvEmpDes.PageIndex
        loaddata()
    End Sub

    Protected Sub gvEmpDes_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEmpDes.RowCancelingEdit
        gvEmpDes.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gvEmpDes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvEmpDes.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim drv As DataRowView = e.Row.DataItem()

            If e.Row.DataItem("empId") = "1111" Then
                e.Row.Cells(3).Text = ""
                e.Row.Cells(4).Text = ""
            End If
        End If
    End Sub
#End Region

End Class
