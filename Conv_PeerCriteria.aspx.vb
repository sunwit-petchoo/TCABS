Imports MySql.Data.MySqlClient

Public Class Conv_PeerCriteria
    Inherits System.Web.UI.Page

    Sub Clear()
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        txtGeneralAspect.Text = ""
        txtSpecificAspect.Text = ""
        ddlType.SelectedIndex = 0
        txtMin.Text = ""
        txtMax.Text = ""
        DT_Temp.Clear()

    End Sub

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#Region "load data"

    Sub loaddata()
        SQL(0) = " Select * " _
                   & "  From peer_criteria a " _
                   & "  join peer_category b on a.categoryId = b.categoryId " _
                   & "  join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  join unit d on c.unitId = d.unitId " _
                   & "  Where c.unitId = '" & Session("unitId") & "' " _
                   & "  order by d.unitName "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

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

        ddlYearSearch.DataSource = DT
        ddlYearSearch.DataTextField = "offUnitYear"
        ddlYearSearch.DataValueField = "offUnitYear"
        ddlYearSearch.DataBind()
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
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadYear()
            loaddata()
        End If
    End Sub

#End Region

#Region "gvAdd "

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        pnAdd.Visible = True

        Dim criteriaItem As String = txtSpecificAspect.Text
        Dim scoreType As String = ddlType.SelectedItem.Text
        Dim scoreMin As String = txtMin.Text
        Dim scoreMax As String = txtMax.Text
        Dim dupStu As Boolean = False

        If DT_Temp.Columns.Count = 0 Then
            DT_Temp.Columns.Add("criteriaItem", GetType(String))
            DT_Temp.Columns.Add("scoreType", GetType(String))
            DT_Temp.Columns.Add("scoreMin", GetType(String))
            DT_Temp.Columns.Add("scoreMax", GetType(String))
        End If

        Dim R As DataRow = DT_Temp.NewRow
        R("criteriaItem") = criteriaItem
        R("scoreType") = scoreType
        R("scoreMin") = scoreMin
        R("scoreMax") = scoreMax
        For Each GVRow As GridViewRow In Me.gvAdd.Rows

            Dim K1 As DataKey = Me.gvAdd.DataKeys(GVRow.RowIndex)
            Dim ckCriteriaItem As String = K1(0)

            If criteriaItem = ckCriteriaItem Then
                dupStu = True
            End If
        Next
        If Not (dupStu) Then
            DT_Temp.Rows.Add(R)
            gvAdd.DataSource = DT_Temp
            gvAdd.DataBind()
        Else
            Dim errMsg = "Specific Aspect: " + criteriaItem + " already entered"
            alert(errMsg)
        End If
    End Sub

    Protected Sub gvAdd_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAdd.RowDeleting
        Dim index As Integer
        index = e.RowIndex
        DT_Temp.Rows.RemoveAt(index)
        gvAdd.DataSource = DT_Temp
        gvAdd.DataBind()
    End Sub

#End Region

#Region "Save"

    Function check() As Boolean
        Dim chk As String = 1

        If ddlYear.SelectedItem.Value = "0" Then
            Me.ddlYear.Focus()
            alert("Please select year")
            chk = 0
        ElseIf ddlSemester.SelectedItem.Value = "0" Then
            Me.ddlSemester.Focus()
            alert("Please select semester")
            chk = 0
        ElseIf txtGeneralAspect.Text = "" Then
            Me.txtGeneralAspect.Focus()
            alert("Please add general aspect")
            chk = 0
        ElseIf Me.gvAdd.Rows.Count = 0 Then
            txtSpecificAspect.Focus()
            alert("Please add specific aspect")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        'SQL(0) = " Insert into peer_category " _
        '        & " (categoryItem, offUnitId) " _
        '       & " values " _
        '        & " ( '" & txtGeneralAspect.Text & "', '" & Session("offUnitId") & "') "
        'M1.Execute(SQL(0))

        'SQL(0) = " select categoryId from peer_category " _
        ''& " where categoryItem = '" & txtGeneralAspect.Text & "' "
        '    DT = M1.GetDatatable(SQL(0))
        '  Dim categoryId As Integer = DT.Rows(0)(0).ToString()

        Dim message As String
        Dim success = ""
        Dim failure = ""
        Dim newLine = "\r\n"
        Dim rvPrm As MySqlParameter = New MySqlParameter
        For Each GVRow As GridViewRow In Me.gvAdd.Rows
            Dim K1 As DataKey = Me.gvAdd.DataKeys(GVRow.RowIndex)
            Dim criteriaItem As String = K1(0)

            Dim lblCriteriaItem As Label = CType(gvAdd.Rows(GVRow.RowIndex).FindControl("lblCriteriaItem"), Label)
            Dim lblType As Label = CType(gvAdd.Rows(GVRow.RowIndex).FindControl("lblType"), Label)
            Dim lblMin As Label = CType(gvAdd.Rows(GVRow.RowIndex).FindControl("lblMin"), Label)
            Dim lblMax As Label = CType(gvAdd.Rows(GVRow.RowIndex).FindControl("lblMax"), Label)
            cmd.CommandText = "ADD_PEER_CRITERIA"
            cmd.Parameters.AddWithValue("@pcriteriaItem", lblCriteriaItem.Text)
            cmd.Parameters.AddWithValue("@pscoreType", lblType.Text)
            cmd.Parameters.AddWithValue("@pscoreMin", lblMin.Text)
            cmd.Parameters.AddWithValue("@pscoreMax", lblMax.Text)
            cmd.Parameters.AddWithValue("@poffUnitId", Session("offUnitId"))
            cmd.Parameters.AddWithValue("@pcategoryItem", txtGeneralAspect.Text)
            'cmd.Parameters.AddWithValue("@pcategoryId", categoryId)
            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg = "SUCCESS" Then
                    success += lblCriteriaItem.Text + newLine
                Else
                    failure += lblCriteriaItem.Text + newLine
                    resultMsg = ""
                    cmd.Parameters.Clear()
                End If
            Catch ex As Exception
                alert("Data entered fail, please Try again.")
            End Try
        Next
        If success = "" Then
            success = " - "
        End If
        If failure = "" Then
            failure = " - "
        End If
        message = "Successful specific aspect :" + newLine + success
        message += newLine + "Specific aspect already exists for this unit:" + newLine + failure
        alert(message)
        Clear()
        pnAdd.Visible = False
        loadYear()
        loaddata()
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

#End Region

#Region "search"

    Protected Sub ddlYearSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYearSearch.SelectedIndexChanged

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchYear As String = "%" & Trim(ddlYearSearch.SelectedValue.ToString()) & "%"
        Dim searchSem As String = "%" & Trim(ddlSemSearch.SelectedValue.ToString()) & "%"

        SQL(0) = SQL(0) = " Select * " _
                   & "  From peer_criteria a " _
                   & "  join peer_category b on a.categoryId = b.categoryId " _
                   & "  join offeredunit c on b.offUnitId = c.offUnitId " _
                   & "  join unit d on c.unitId = d.unitId " _
                   & "  Where c.unitId = '" & Session("unitId") & "' " _
                   & "  And c.offUnitYear like '" & searchYear & "' " _
                   & "  And c.offUnitSem like '" & searchSem & "' " _
                   & "  order by d.unitName, b.projName, b.peer_category, b.peer_criteria "
        DT = M1.GetDatatable(SQL(0))
        gvData.DataSource = DT
        gvData.DataBind()
    End Sub

#End Region

#Region "gvData"

    Protected Sub gvData_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvData.RowDeleting
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim index As Integer = e.RowIndex
        Dim categoryId As String = Me.gvData.DataKeys(index).Values(0).ToString()
        Dim criteriaId As String = Me.gvData.DataKeys(index).Values(1).ToString()

        cmd.CommandText = "DELETE_PEER_CRITERIA;"
        cmd.Parameters.AddWithValue("@pcriteriaId", criteriaId)
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

        cmd.CommandText = "DELETE_PEER_CATEGORY;"
        cmd.Parameters.AddWithValue("@pcategoryId", categoryId)
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

    Protected Sub gvData_selectedindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gvData.SelectedIndexChanging
        Dim k1 As DataKey = gvData.DataKeys(e.NewSelectedIndex)
    End Sub

    Protected Sub gvData_pageindexchanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvData.PageIndexChanging
        Me.gvData.PageIndex = e.NewPageIndex
        ViewState("page") = Me.gvData.PageIndex
        loaddata()
    End Sub

#End Region

End Class