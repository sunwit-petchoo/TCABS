Imports MySql.Data.MySqlClient

Public Class Admin_UnitOffering
    Inherits System.Web.UI.Page

#Region "Carlendar"

    Dim vClsFunc As New ClassFunction()

    Protected Sub IMbStartDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbStartDate.Click
        Calendar1.Visible = True
        Calendar2.Visible = False
    End Sub
    Protected Sub IMbEndDate_Click(sender As Object, e As ImageClickEventArgs) Handles IMbEndDate.Click
        Calendar2.Visible = True
        Calendar1.Visible = False
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        Me.txtStartDate.Text = vClsFunc.DateString_Show(Calendar1.SelectedDate)
        Calendar1.Visible = False
    End Sub
    Protected Sub Calendar2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar2.SelectionChanged
        Me.txtEndDate.Text = vClsFunc.DateString_Show(Calendar2.SelectedDate)
        Calendar2.Visible = False
    End Sub


#End Region

#Region "check"

    Sub clear()
        ddlYear.SelectedIndex() = 0
        ddlSemester.SelectedIndex() = 0
        ddlUnit.SelectedIndex() = 0
        ddlConvenor.SelectedIndex() = 0
        txtRoomNo.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        Calendar1.Visible = False
        Calendar2.Visible = False
    End Sub

    '-- alert
    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1
        Dim selectedDate = Trim(txtStartDate.Text).ToString
        If ddlUnit.SelectedItem.Value = "0" Then
            Me.ddlUnit.Focus()
            alert("Please select unit")
            chk = 0
        ElseIf ddlYear.SelectedItem.Value = "0" Then
            Me.ddlYear.Focus()
            alert("Please select year")
            chk = 0
        ElseIf ddlSemester.SelectedItem.Value = "0" Then
            Me.ddlSemester.Focus()
            alert("Please select semester")
            chk = 0
        ElseIf ddlConvenor.SelectedItem.Value = "0" Then
            Me.ddlConvenor.Focus()
            alert("Please select convenor")
            chk = 0
        ElseIf txtRoomNo.Text = "" Then
            Me.txtRoomNo.Focus()
            alert("Please add Room no.")
            chk = 0
        ElseIf txtStartDate.Text = "" Then
            Me.txtStartDate.Focus()
            alert("Please select start date")
            chk = 0
        End If

        '--Check date
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)
        Dim startdateC = DateTime.Parse(startDate)
        Dim enddateC = DateTime.Parse(endDate)
        Dim regDate As Date = Date.Now()
        Dim regDateStr As String = regDate.ToString("yyyy-MM-dd")
        Dim curDate = DateTime.Parse(regDateStr)
        '--Cannot Select Past Date
        If Not (selectedDate = "") Then
            If (startdateC < curDate) Or (enddateC < curDate) Then
                alert("Cannot select past date, please try again")
                chk = 0
            End If
        End If
        '--Date start > Date end
        Dim startDate_chk As String = Format(startdateC, "yyyyMMdd")
        Dim endDate_chk As String = Format(enddateC, "yyyyMMdd")
        If endDate_chk < startDate_chk Then
            alert("End date must be after start date")
            chk = 0
        End If

        '--Check semester
        startDate_chk = startDate_chk.Substring(0, 4)
        endDate_chk = startDate_chk.Substring(0, 4)
        If startDate_chk <> ddlYear.SelectedValue.ToString() Then
            alert("Selected date is not match with unit offered year")
            chk = 0
        ElseIf endDate_chk <> ddlYear.SelectedValue.ToString() Then
            alert("Selected date is not match with unit offered year")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

#Region "load data"

    Sub loadUnit()
        SQL(0) = " Select unitId, CONCAT(unitId, ' - ', unitName) as unitStr From unit "
        DT = M1.GetDatatable(SQL(0))
        ddlUnit.DataSource = DT
        ddlUnit.DataTextField = "unitStr"
        ddlUnit.DataValueField = "unitId"
        ddlUnit.DataBind()
    End Sub

    Sub loadYear()
        Dim year As Integer = DateTime.Now.Year
        For i = year To year + 3
            ddlYear.Items.Add(i)
        Next
    End Sub

    Sub loadConv()
        SQL(0) = "  Select a.empEnrolId, CONCAT(a.empId, ' - ', b.empName) as empStr " _
                 & " From employeeEnrolment a " _
                 & " Join employee b " _
                 & " On a.empId = b.empId  " _
                 & " Where roleId = 1 "
        DT = M1.GetDatatable(SQL(0))
        ddlConvenor.DataSource = DT
        ddlConvenor.DataTextField = "empStr"
        ddlConvenor.DataValueField = "empEnrolId"
        ddlConvenor.DataBind()
    End Sub

    '--load gridview
    Sub loaddata()
        SQL(0) = "  Select a.*, DATE_FORMAT(a.offUnitStart,'%d/%m/%Y') AS dateStartStr, " _
                     & " DATE_FORMAT(a.offUnitEnd,'%d/%m/%Y') AS dateEndStr, " _
                     & " CONCAT(b.unitId, ' - ', b.unitName) as unitStr, d.EmpName " _
                     & " From offeredUnit a " _
                     & " join unit b on a.unitID = b.unitID " _
                     & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                     & " join employee d on c.empId = d.EmpId "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub page_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Calendar1.Visible = False
            Calendar2.Visible = False
            loadUnit()
            loadYear()
            loadConv()
            loaddata()
        End If
    End Sub

#End Region

#Region "Save"

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
        Dim year As String = ddlYear.SelectedValue.ToString()
        Dim sem As String = ddlSemester.SelectedValue.ToString()
        Dim unit As String = ddlUnit.SelectedValue.ToString()
        Dim convenor As String = ddlConvenor.SelectedValue.ToString()
        Dim roomNo As String = Trim(Me.txtRoomNo.Text)
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)

        cmd.CommandText = "addOfferedUnit;"
        cmd.Parameters.AddWithValue("@pyear", year)
        cmd.Parameters.AddWithValue("@psem", sem)
        cmd.Parameters.AddWithValue("@punit_id", unit)
        cmd.Parameters.AddWithValue("@pempEnrolId", convenor)
        cmd.Parameters.AddWithValue("@proom", roomNo)
        cmd.Parameters.AddWithValue("@poffUnitStart", startDate)
        cmd.Parameters.AddWithValue("@poffUnitEnd", endDate)
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

    '--gridview page
    Protected Sub gridviewcompany_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewcompany_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    '--click edit
    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing
        gvData.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
        Dim yearEdit As DropDownList = CType(gvData.Rows(gvData.EditIndex).FindControl("ddlYearEdit"), DropDownList)
        Dim ddlConvenorEdit As DropDownList = CType(gvData.Rows(gvData.EditIndex).FindControl("ddlConvenorEdit"), DropDownList)

        Dim year As Integer = DateTime.Now.Year
        For i = year To year + 3
            yearEdit.Items.Add(i)
        Next

        SQL(0) = "  Select a.empEnrolId, CONCAT(a.empId, ' - ', b.empName) as empStr " _
                 & " From employeeEnrolment a " _
                 & " Join employee b " _
                 & " On a.empId = b.empId  " _
                 & " Where roleId = 1 "
        DT = M1.GetDatatable(SQL(0))
        ddlConvenorEdit.DataSource = DT
        ddlConvenorEdit.DataTextField = "empStr"
        ddlConvenorEdit.DataValueField = "empEnrolId"
        ddlConvenorEdit.DataBind()

    End Sub

    Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim offUnitId As String = Me.gvData.DataKeys(index).Values(0).ToString()
        Dim year As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlYearEdit"), DropDownList)
        Dim semester As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlSemesterEdit"), DropDownList)
        Dim empEnrolId As DropDownList = CType(gvData.Rows(e.RowIndex).FindControl("ddlConvenorEdit"), DropDownList)

        Dim yearVal As String = year.SelectedItem.Value
        Dim semesterVal As String = semester.SelectedItem.Value
        Dim empEnrolIdVal As String = empEnrolId.SelectedItem.Value
        If year.SelectedItem.Value = "0" Then
            alert("please select updated year")
            year.Focus()
            Exit Sub
        ElseIf semester.SelectedItem.Value = "0" Then
            alert("please select updated semester")
            semester.Focus()
            Exit Sub
        ElseIf empEnrolId.SelectedItem.Value = "0" Then
            alert("please select updated convenor")
            empEnrolId.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_OFFEREDUNIT;"
        cmd.Parameters.AddWithValue("@poffUnitId", offUnitId)
        cmd.Parameters.AddWithValue("@poffUnitYear", yearVal)
        cmd.Parameters.AddWithValue("@poffUnitSem", semesterVal)
        cmd.Parameters.AddWithValue("@pempEnrolId", empEnrolIdVal)

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

    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim offUnitId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_OFFEREDUNIT;"
        cmd.Parameters.AddWithValue("@poffUnitId", offUnitId)
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

#End Region

#Region "search"

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchTerm As String = "%" & Trim(txtSearch.Text) & "%"
        'SQL(0) = "SEARCH_STUDENT('" & searchTerm & "');"
        SQL(0) = " Select a.*, DATE_FORMAT(a.offUnitStart,'%d/%m/%Y') AS dateStr, CONCAT(b.unitId, ' - ', b.unitName) as unitStr, d.EmpName " _
                 & " From offeredUnit a " _
                 & " join unit b on a.unitID = b.unitID " _
                 & " join employeeEnrolment c on a.empEnrolId = c.EmpEnrolId " _
                 & " join employee d on c.empId = d.EmpId " _
                 & "  Where b.unitId like '" & searchTerm & "' or b.unitName like '" & searchTerm & "' "
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