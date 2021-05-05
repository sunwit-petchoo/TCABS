Imports MySql.Data.MySqlClient

Public Class Admin_UnitManagement
    Inherits System.Web.UI.Page

    Sub clear()
        txtUnitCode.Text = ""
        txtUnitName.Text = ""
        txtUnitDesc.Text = ""
        txtCredit.Text = ""
    End Sub

#Region "check"

    '-- alert
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1

        If txtUnitCode.Text = "" Then
            Me.txtUnitCode.Focus()
            alert("Please add unit code")
            chk = 0
        ElseIf txtUnitName.Text = "" Then
            Me.txtUnitName.Focus()
            alert("Please add unit name")
            chk = 0
        ElseIf txtUnitDesc.Text = "" Then
            Me.txtUnitDesc.Focus()
            alert("Please add unit description")
            chk = 0
        ElseIf txtCredit.Text = "" Then
            Me.txtCredit.Focus()
            alert("Please add credit")
            chk = 0
        End If

        If Not (IsNumeric(txtCredit.Text)) Then
            Me.txtCredit.Focus()
            alert("Unit credit has to be number")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "Manage Unit"

    '--load gridview
    Sub loaddata()
        SQL(0) = " Select * From unit"
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loaddata()
        End If
    End Sub

    '--click cancel
    Protected Sub btncancel_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
    End Sub

    '--click save
    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim unitCode As String = Trim(Me.txtUnitCode.Text.ToUpper)
        Dim unitName As String = Trim(Me.txtUnitName.Text)
        Dim unitDesc As String = Trim(Me.txtUnitDesc.Text)
        Dim unitCredit As String = Trim(Me.txtCredit.Text)

        cmd.CommandText = "addUnit;"
        cmd.Parameters.AddWithValue("@punitId", unitCode)
        cmd.Parameters.AddWithValue("@punit_name", unitName)
        cmd.Parameters.AddWithValue("@punitDesc", unitDesc)
        cmd.Parameters.AddWithValue("@PunitCredit", unitCredit)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                clear()
                loaddata()
            Else
                alert(resultMsg)
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Insert Error, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try
    End Sub

#End Region

#Region "gridview data"

    '--managing gridview
    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    '--click edit
    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing
        gvData.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    '--click update
    Protected Sub gvStudent_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim unitCode As String = Me.gvData.DataKeys(index).Values(0).ToString()
        Dim unitName As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtUnitName"), TextBox)
        Dim unitDesc As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtUnitDesc"), TextBox)
        Dim unitCredit As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtCredit"), TextBox)

        Dim unitNameStr As String = unitName.Text
        Dim unitDescStr As String = unitDesc.Text
        Dim unitCreditStr As String = unitCredit.Text
        If unitNameStr = "" Then
            alert("please enter updated unit Name")
            unitName.Focus()
            Exit Sub
        ElseIf unitDescStr = "" Then
            alert("please enter updated Email")
            unitDesc.Focus()
            Exit Sub
        ElseIf unitCreditStr = "" Then
            alert("please enter updated unit credit")
            unitCredit.Focus()
            Exit Sub
        End If

        If Not (IsNumeric(unitCredit.Text)) Then
            Me.txtCredit.Focus()
            alert("Unit credit has to be number")
            unitCredit.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_UNIT;"
        cmd.Parameters.AddWithValue("@punitId", unitCode)
        cmd.Parameters.AddWithValue("@punitName", unitNameStr)
        cmd.Parameters.AddWithValue("@punitDesc", unitDescStr)
        cmd.Parameters.AddWithValue("@punitCredit", unitCreditStr)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Update data successfully")
                gvData.EditIndex = -1
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

    '--click delete
    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim unitId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_UNIT;"
        cmd.Parameters.AddWithValue("@punitId", unitId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)
        Try
            M1.Execute(SQL(0))

            If resultMsg = "SUCCESS" Then
                alert("Data deleted successfully")
                gvData.EditIndex = -1
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

    '--gridview page
    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        SQL(0) = "Select * From Unit " _
                & " Where UnitName like '" & searchTerm & "' " _
                & " or unitID like '" & searchTerm & "'  "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

End Class