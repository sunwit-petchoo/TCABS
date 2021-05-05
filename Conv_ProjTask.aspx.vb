Imports MySql.Data.MySqlClient

Public Class Conv_ProjTask
    Inherits System.Web.UI.Page

    Sub Clear()
        txtTaskNo.Text = ""
        txtTaskTitle.Text = ""
        txtTaskDesc.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
    End Sub

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "check"

    '--function check()
    Function check() As Boolean
        Dim chk As String = 1
        Dim selectedDateSt = Trim(txtStartDate.Text).ToString
        Dim selectedDateEd = Trim(txtEndDate.Text).ToString
        Dim regDate As Date = Date.Now()
        Dim regDateStr As String = regDate.ToString("yyyy-MM-dd")
        Dim curDate = DateTime.Parse(regDateStr)
        If ddlYear.SelectedItem.Value = "0" Then
            Me.ddlYear.Focus()
            alert("Please select year")
            chk = 0
        ElseIf ddlSemester.SelectedItem.Value = "0" Then
            Me.ddlSemester.Focus()
            alert("Please select semester")
            chk = 0
            'ElseIf ddlUnitCode.SelectedItem.Value = "0" Then
            '    Me.ddlUnitCode.Focus()
            '    alert("Please select unit")
            '    chk = 0
        ElseIf ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf txtTaskNo.Text = "" Then
            Me.txtTaskNo.Focus()
            alert("Please add task No")
            chk = 0
        ElseIf Not (IsNumeric(txtTaskNo.Text)) Then
            Me.txtTaskNo.Focus()
            alert("Task No must be number")
            chk = 0
        ElseIf txtTaskTitle.Text = "" Then
            Me.txtTaskTitle.Focus()
            alert("Please add task title")
            chk = 0
        ElseIf txtTaskDesc.Text = "" Then
            Me.txtTaskDesc.Focus()
            alert("Please add task description")
            chk = 0
        ElseIf txtStartDate.Text = "" Then
            Me.txtStartDate.Focus()
            alert("Please add start date")
            chk = 0
        ElseIf txtEndDate.Text = "" Then
            Me.txtEndDate.Focus()
            alert("Please add end date")
            chk = 0
        End If

        If Not (selectedDateSt = "") Then
            Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
            Dim startdateC = DateTime.Parse(startDate)
            If startdateC < curDate Then
                alert("Cannot select past start date, please try again")
                chk = 0
            End If
        End If

        If Not (selectedDateEd = "") Then
            Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)
            Dim endDateC = DateTime.Parse(endDate)
            If endDateC < curDate Then
                alert("Cannot select past end date, please try again")
                chk = 0
            End If
        End If
        If selectedDateSt <> "" And selectedDateEd <> "" Then
            Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
            Dim startdateC = DateTime.Parse(startDate)
            Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)
            Dim endDateC = DateTime.Parse(endDate)
            If endDateC < startdateC Then
                alert("Cannot set end-date before start-date")
                chk = 0
            End If
        End If
        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

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

#Region "load data"
    Sub loadYear()
        Dim nowYear As Integer = Date.Now.Year
        Dim nextYear = nowYear + 1
        Dim nextYearStr = nextYear.ToString
        Dim nowYearStr = nowYear.ToString
        SQL(0) = "select distinct(offUnitYear) from offeredunit " _
                & " where offUnitYear = " & nowYearStr & " Or offUnitYear = " & nextYearStr _
                & " and unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlYear.DataSource = DT
        ddlYear.DataTextField = "offUnitYear"
        ddlYear.DataValueField = "offUnitYear"
        ddlYear.DataBind()

    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = "select distinct(offUnitSem) from offeredunit where offUnitYear = " & selectedYear _
                & " and unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        ddlSemester.DataSource = DT
        ddlSemester.DataTextField = "offUnitSem"
        ddlSemester.DataValueField = "offUnitSem"
        ddlSemester.DataBind()
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSemester.SelectedIndexChanged
        Dim selectedYear = ddlYear.SelectedItem.Value
        Dim selectedSem = ddlSemester.SelectedItem.Value
        SQL(0) = "select a.offUnitId, CONCAT(b.unitId, ' - ', b.unitName) as unitStr " _
                & " from offeredunit a " _
                & " join unit b on a.unitId = b.unitId " _
                & " where offUnitYear = " & selectedYear & " And offUnitSem = " & selectedSem _
                & " and a.unitId = '" & Session("unitId") & "' "
        DT = M1.GetDatatable(SQL(0))
        Try
            Session("offUnitId") = DT.Rows(0)("offUnitId").ToString()
        Catch ex As Exception
            alert("There is no offered unit for selected year and semester")
        End Try
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = " Select projId, projName from project where offUnitId = " & Session("offUnitId")
        DT = M1.GetDatatable(SQL(0))
        Try
            ddlProject.DataSource = DT
            ddlProject.DataTextField = "projName"
            ddlProject.DataValueField = "projId"
            ddlProject.DataBind()
        Catch ex As Exception
            alert("There is no project for selected year and semester")
        End Try
    End Sub

    Sub loaddata()
        SQL(0) = "Select c.offUnitYear, c.offUnitSem, CONCAT(d.unitID, '-', d.unitName) as unitStr, " _
                   & " b.projName, a.* " _
                   & "  From task a " _
                   & "  Join project b on a.projId = b.projId " _
                   & "  Join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  Join unit d on c.UnitId = d.UnitId " _
                   & "  Where c.unitId = '" & Session("unitID") & "' " _
                   & "  order by d.unitName, b.projName, a.taskNo "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            Calendar1.Visible = False
            Calendar2.Visible = False
            loaddata()
        End If
    End Sub

#End Region

#Region "Save"

    Protected Sub btnsave_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim projId As String = ddlProject.SelectedValue.ToString()
        Dim taskNo As String = Me.txtTaskNo.Text
        Dim taskTitle As String = Me.txtTaskTitle.Text
        Dim taskDesc As String = Me.txtTaskDesc.Text
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)

        cmd.CommandText = "ADD_TASK;"
        cmd.Parameters.AddWithValue("@pprojId", projId)
        cmd.Parameters.AddWithValue("@ptaskNo", taskNo)
        cmd.Parameters.AddWithValue("@ptaskTitle", taskTitle)
        cmd.Parameters.AddWithValue("@ptaskDesc", taskDesc)
        cmd.Parameters.AddWithValue("@pstartDate", startDate)
        cmd.Parameters.AddWithValue("@pendDate", endDate)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)
        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                Clear()
                loadYear()
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

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SQL(0) = "Select c.offUnitYear, c.offUnitSem, CONCAT(d.unitID, '-', d.unitName) as unitStr, " _
                   & " b.projName, a.* " _
                   & "  From task a " _
                   & "  Join project b on a.projId = b.projId " _
                   & "  Join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  Join unit d on c.UnitId = d.UnitId " _
                   & "  Where taskTitle like '%" & txtSearch.Text & "%'  "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

    Protected Sub btnSearchCancel_Click(sender As Object, e As EventArgs) Handles btnSearchCancel.Click
        txtSearch.Text = ""
        loaddata()
    End Sub

#End Region

#Region "gridview data"
    Protected Sub gridviewdata_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gridviewdata_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

    Protected Sub gvData_rowcancelingedit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvData.RowCancelingEdit
        gvData.EditIndex = -1
        Me.loaddata()
    End Sub

    Protected Sub gvData_rowediting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvData.RowEditing
        gvData.EditIndex = e.NewEditIndex
        'bind Data to the gridview control.
        Me.loaddata()
    End Sub

    Protected Sub gvData_rowupdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvData.RowUpdating
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim taskId As String = Me.gvData.DataKeys(index).Values(0).ToString()
        Dim taskNo As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtTaskNo"), TextBox)
        Dim taskTitle As TextBox = CType(gvData.Rows(e.RowIndex).FindControl("txtTaskTitle"), TextBox)


        Dim taskNoStr As String = taskNo.Text
        Dim taskTitleStr As String = taskTitle.Text

        If taskNoStr = "" Then
            alert("please enter updated task no.")
            taskNo.Focus()
            Exit Sub
        ElseIf taskTitleStr = "" Then
            alert("please enter updated task title")
            taskTitle.Focus()
            Exit Sub
        End If

        cmd.CommandText = "UPDATE_TASK;"
        cmd.Parameters.AddWithValue("@ptaskId", taskId)
        cmd.Parameters.AddWithValue("@ptaskNo", taskNoStr)
        cmd.Parameters.AddWithValue("@ptaskTitle", taskTitleStr)

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
        Dim taskId As String = Me.gvData.DataKeys(index).Values(0).ToString()

        cmd.CommandText = "DELETE_TASK;"
        cmd.Parameters.AddWithValue("@ptaskId", taskId)
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

End Class
