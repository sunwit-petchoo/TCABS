Imports MySql.Data.MySqlClient

Public Class Admin_EmpManagement
    Inherits System.Web.UI.Page

    Function check() As Boolean
        Dim chk As String = 1

        If txtemployeeId.Text = "" Then
            Me.txtemployeeId.Focus()
            alert("Please Enter Employee ID")
            chk = 0
        ElseIf txtempName.Text = "" Then
            Me.txtempName.Focus()
            alert("Please Enter Employee Name")
            chk = 0
        ElseIf txtemailId.Text = "" Then
            Me.txtemailId.Focus()
            alert("Please Enter Email")
            chk = 0
        End If

        If Not (IsNumeric(txtemployeeId.Text)) Then
            alert("Employee ID must be number")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "load data"
    Sub loaddata()
        SQL(0) = " GET_EMPLOYEE;"
        DT = M1.GetDatatable(SQL(0))
        gvEmployee.DataSource = DT
        gvEmployee.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub

#End Region

#Region "save"

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim pempId As Integer = Trim(Me.txtemployeeId.Text)
        Dim pempName As String = Me.txtempName.Text
        Dim pemail As String = txtemailId.Text

        cmd.CommandText = "SP_ADD_EMPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        cmd.Parameters.AddWithValue("@pempName", pempName)
        cmd.Parameters.AddWithValue("@pempEmail", pemail)

        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                txtemployeeId.Text = ""
                txtempName.Text = ""
                txtemailId.Text = ""
                loaddata()
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

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtemployeeId.Text = ""
        txtempName.Text = ""
        txtemailId.Text = ""

    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "SP_SEARCH_EMPLOYEE('" & searchTerm & "');"
        DT = M1.GetDatatable(SQL(0))
        gvEmployee.DataSource = DT
        gvEmployee.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

#Region "GV"
    Protected Sub gvEmployee_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvEmployee.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim pempId As String = Me.gvEmployee.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "SP_DELETE_EMLPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", pempId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))

            If resultMsg = "SUCCESS" Then
                alert("Data deleted successfully")
                gvEmployee.EditIndex = -1
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Fail to delete, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

    Protected Sub gvEmployee_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvEmployee.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim empId As String = Me.gvEmployee.DataKeys(index).Values(0).ToString()
        Dim empName As TextBox = CType(gvEmployee.Rows(e.RowIndex).FindControl("txtEmpName"), TextBox)
        Dim empEmail As TextBox = CType(gvEmployee.Rows(e.RowIndex).FindControl("txtEmpEmail"), TextBox)

        If empName.Text = "" Then
            alert("please enter updated Employee Name")
            empName.Focus()
            Exit Sub
        ElseIf empEmail.Text = "" Then
            alert("please enter updated Email")
            empEmail.Focus()
            Exit Sub
        End If


        cmd.CommandText = "SP_UPDATE_EMPLOYEE;"
        cmd.Parameters.AddWithValue("@pempId", empId)
        cmd.Parameters.AddWithValue("@pempName", empName.Text)
        cmd.Parameters.AddWithValue("@pempEmail", empEmail.Text)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Update data successfully")
                gvEmployee.EditIndex = -1
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

    Protected Sub gvEmployee_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvEmployee.RowEditing
        gvEmployee.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gvEmpolyee_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvEmployee.RowCancelingEdit
        gvEmployee.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gvEmpolyee_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvEmployee.SelectedIndexChanging
        Dim k1 As DataKey = gvEmployee.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvEmpolyee_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvEmployee.PageIndexChanging
        Me.gvEmployee.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvEmployee.PageIndex
        loaddata()
    End Sub

#End Region

End Class