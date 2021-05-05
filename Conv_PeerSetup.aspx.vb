Imports MySql.Data.MySqlClient

Public Class Conv_PeerSetup
    Inherits System.Web.UI.Page

    Sub Clear()
        ddlYear.Items.Clear()
        ddlYear.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlSemester.Items.Clear()
        ddlSemester.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        txtPeerNo.Text = ""
        txtPeerName.Text = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""
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
        ElseIf ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf txtPeerNo.Text = "" Then
            Me.txtPeerNo.Focus()
            alert("Please add peer no")
            chk = 0
        ElseIf Not (IsNumeric(txtPeerNo.Text)) Then
            Me.txtPeerNo.Focus()
            alert("Peer Assessment No must be number")
            chk = 0
        ElseIf txtPeerName.Text = "" Then
            Me.txtPeerName.Focus()
            alert("Please add peer assessment name")
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

#Region "loaddata"

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
                & " and unitId = '" & Session("unitId") & "'"
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

        '--load project
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

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        loaddata()
    End Sub

    Sub loaddata()
        '--load category and criteria
        SQL(0) = " Select * " _
                & " From peer_category a  " _
                & " join peer_criteria b on a.categoryId = b.categoryId " _
                & " Where a.offUnitId = " & Session("offUnitId") & " "
        DT = M1.GetDatatable(SQL(0))

        Try
            trCriteria.Visible = True
            gvData.DataSource = DT
            gvData.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'trCriteria.Visible = False
            loadYear()
            Calendar1.Visible = False
            Calendar2.Visible = False
        End If
    End Sub

#End Region

#Region "gvData"

    'Private Sub gvData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvData.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Dim drv As DataRowView = e.Row.DataItem()
    '        Dim chkSelect As CheckBox = CType(e.Row.FindControl("chkSelect"), CheckBox)

    '        If drv("criteriaId") IsNot DBNull.Value Then
    '            SQL(0) = " Select * " _
    '                    & " From peer_setupdetail a " _
    '                    & " join peer_setupmain b on a.peerId = b.peerId " _
    '                    & " where b.projId = '" & ddlProject.SelectedValue.ToString() & "' " _
    '                    & " and a.criteriaId = " & drv("criteriaId") & " "
    '            DT = M1.GetDatatable(SQL(0))
    '            Try
    '                If DT.Rows.Count() = 0 Then
    '                    chkSelect.Checked = True
    '                Else
    '                    chkSelect.Checked = False
    '                End If
    '            Catch ex As Exception
    '                chkSelect.Checked = False
    '            End Try
    '        End If
    '    End If
    'End Sub

#End Region

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        '--Add Peer_SetupMain
        Dim rvPrm As MySqlParameter = New MySqlParameter
        Dim peerNo As String = Me.txtPeerNo.Text
        Dim peerName As String = Me.txtPeerName.Text
        Dim startDate As String = vClsFunc.DateString_Save(txtStartDate.Text)
        Dim endDate As String = vClsFunc.DateString_Save(txtEndDate.Text)
        Dim projId As String = ddlProject.SelectedValue.ToString()

        cmd.CommandText = "ADD_PEER_SETUPMAIN;"
        cmd.Parameters.AddWithValue("@ppeerNo", peerNo)
        cmd.Parameters.AddWithValue("@ppeerName", peerName)
        cmd.Parameters.AddWithValue("@pstartDate", startDate)
        cmd.Parameters.AddWithValue("@pendDate", endDate)
        cmd.Parameters.AddWithValue("@pprojId", projId)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)

        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                'alert("Data entered successfully.")
                'Clear()
                'loadYear()
                'loaddata()
            Else
                alert(resultMsg)
                Exit Sub
            End If
            resultMsg = ""
        Catch ex As Exception
            alert("Insert Error, please Try again or contact IT support.")
            resultMsg = ""
            cmd.Parameters.Clear()
        End Try

        '--Add Peer_SetupDetail
        Dim peerId As Integer = 0
        For Each GVRow As GridViewRow In Me.gvData.Rows
            Dim chkSelect As CheckBox = GVRow.FindControl("chkSelect")
            Dim K1 As DataKey = Me.gvData.DataKeys(GVRow.RowIndex)
            'K1(0) = criteriaId
            If chkSelect.Checked = True Then
                cmd.CommandText = "ADD_PEER_SETUPDETAIL;"
                cmd.Parameters.AddWithValue("@pcriteriaId", K1(0))


                rvPrm.ParameterName = "msg"
                rvPrm.MySqlDbType = MySqlDbType.String
                rvPrm.Size = 200
                rvPrm.Direction = ParameterDirection.Output
                cmd.Parameters.Add(rvPrm)

                Try
                    M1.Execute(SQL(0))
                    If resultMsg <> "SUCCESS" Then
                        loaddata()
                        alert(resultMsg)
                        resultMsg = ""
                        Exit Sub
                    End If
                    resultMsg = ""
                Catch ex As Exception
                    alert("Fail to update, please Try again or contact IT support.")
                    resultMsg = ""
                    cmd.Parameters.Clear()
                    Exit Sub
                End Try
            End If
        Next
        alert("Data entered successfully.")
        Clear()
        loadYear()
        loaddata()
        trCriteria.Visible = False
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
        'trCriteria.Visible = False
    End Sub

End Class