Imports MySql.Data.MySqlClient

Public Class Student_PeerSubmit
    Inherits System.Web.UI.Page

    Sub clear()
        ddlProject.SelectedIndex = 0
        ddlPeer.SelectedIndex = 0
        txtComment.Text = ""
        gv_Show.DataSource = Nothing
        gv_Show.DataBind()
    End Sub

#Region "check"

    Function check() As Boolean
        Dim chk As String = 1

        If ddlProject.SelectedItem.Value = "0" Then
            Me.ddlProject.Focus()
            alert("Please select project")
            chk = 0
        ElseIf ddlPeer.SelectedItem.Value = "0" Then
            Me.ddlPeer.Focus()
            alert("Please select peer assessment")
            chk = 0
        ElseIf gv_Show.Rows.Count = 0 Then
            alert("There is no peer assessment")
            chk = 0
        ElseIf txtComment.Text = "" Then
            alert("Please add comments")
            chk = 0
        End If

        If chk = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Protected Sub alert(ByVal scriptalert As String)
        Dim script As String = ""
        script = "alert('" + scriptalert + "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "jscall", script, True)
    End Sub

#End Region

#Region "loaddata"

    Sub loadProject()
        ddlProject.Items.Clear()
        ddlProject.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        SQL(0) = " Select * " _
                & " From project a  " _
                & " join team b on a. projId = b.projId " _
                & " join teamEnrol c on b.teamId = c.teamId " _
                & " join enrolment d on c.enrolId = d.enrolId " _
                & " join offeredUnit e on a.offUnitId = e.offUnitId " _
                & " where d.stuId = '" & Session("userId") & "' " _
                & " and d.offUnitId = " & Session("offUnitId") & " " _
                & " order by projName "
        DT = M1.GetDatatable(SQL(0))
        ddlProject.DataSource = DT
        ddlProject.DataTextField = "projName"
        ddlProject.DataValueField = "projId"
        ddlProject.DataBind()
        ddlProject.SelectedIndex() = 0
    End Sub

    Protected Sub ddlProject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProject.SelectedIndexChanged
        '--load peer assessment
        ddlPeer.Items.Clear()
        ddlPeer.Items.Insert(0, New ListItem("[--Please Select--]", "0"))
        'SQL(0) = " Select *, peerNo, concat(peerNo, ' - ', peerName) as peerStr " _
        '        & " From project a  " _
        '        & " join team b on a. projId = b.projId " _
        '        & " join teamEnrol c on b.teamId = c.teamId " _
        '        & " join enrolment d on c.enrolId = d.enrolId " _
        '        & " join offeredUnit e on a.offUnitId = e.offUnitId " _
        '        & " join Peer_SetupMain f on a.projId = f.projId " _
        '        & " where a.projId = " & ddlProject.SelectedValue.ToString() & " " _
        '        & " and current_date() between f.startDate And f.stopDate " _
        '        & " order by peerNo "
        SQL(0) = " Select *, peerNo, concat(peerNo, ' - ', peerName) as peerStr " _
                & " From project a  " _
                & " join Peer_SetupMain f on a.projId = f.projId " _
                & " where a.projId = " & ddlProject.SelectedValue.ToString() & " " _
                & " order by peerNo "
        DT = M1.GetDatatable(SQL(0))
        Try
            ddlPeer.DataSource = DT
            ddlPeer.DataTextField = "peerStr"
            ddlPeer.DataValueField = "peerId"
            ddlPeer.DataBind()
            ddlPeer.SelectedIndex() = 0

            'Session("teamEnrolId") = DT.Rows(0)("teamEnrolId").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlPeer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPeer.SelectedIndexChanged
        SQL(0) = " Select *, concat('( Min ', scoreMin, ' - ', scoreMax, ' Max )') as minmaxStr " _
                & " From Peer_SetupDetail a " _
                & " join peer_setupmain b on a.peerId = b.peerId " _
                & " join peer_criteria c on a.criteriaId = c.criteriaId " _
                & " join peer_category d on c.categoryId = d.categoryId " _
                & " where a.peerId = " & ddlPeer.SelectedValue.ToString() & " " _
                & " order by peerNo "
        DT = M1.GetDatatable(SQL(0))
        gv_Show.DataSource = DT
        gv_Show.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadProject()
        End If
    End Sub

#End Region

#Region "save"

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If check() = False Then
            Exit Sub
        End If

        '--Add Peer_Submit
        Dim rvPrm As MySqlParameter = New MySqlParameter

        cmd.CommandText = "ADD_PEER_SUBMIT;"
        cmd.Parameters.AddWithValue("@puserId", Session("userId"))
        cmd.Parameters.AddWithValue("@poffUnitId", Session("offUnitId"))
        cmd.Parameters.AddWithValue("@pcomment", txtComment.Text)
        rvPrm.ParameterName = "msg"
        rvPrm.MySqlDbType = MySqlDbType.String
        rvPrm.Size = 200
        rvPrm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(rvPrm)
        Try
            M1.Execute(SQL(0))
            If resultMsg = "SUCCESS" Then
                alert("Data entered successfully.")
                'clear()
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

        '--Add Peer_Score
        Dim sttChk As Boolean = True
        For Each GVRow As GridViewRow In Me.gv_Show.Rows
            Dim txtScore As TextBox = GVRow.FindControl("txtScore")
            If txtScore.Text <> "" Then
            Else
                sttChk = False
            End If
        Next

        If sttChk = False Then
            alert("Please enter score") : Exit Sub
        End If

        For Each GVRow As GridViewRow In Me.gv_Show.Rows
            Dim K1 As DataKey = Me.gv_Show.DataKeys(GVRow.RowIndex)
            '   0
            '"peerDetailId"

            Dim peerDetailId As String = K1(0)
            Dim txtScore As TextBox = GVRow.FindControl("txtScore")

            cmd.CommandText = "ADD_PEER_SCORE;"
            cmd.Parameters.AddWithValue("@pscore", txtScore.Text)
            cmd.Parameters.AddWithValue("@ppeerDetailId", K1(0))

            rvPrm.ParameterName = "msg"
            rvPrm.MySqlDbType = MySqlDbType.String
            rvPrm.Size = 200
            rvPrm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(rvPrm)

            Try
                M1.Execute(SQL(0))
                If resultMsg <> "SUCCESS" Then
                    'clear()
                    alert(resultMsg)
                    resultMsg = ""
                    Exit Sub
                End If
                resultMsg = ""
            Catch ex As Exception
                alert("Fail to update, please Try again or contact IT support.")
                clear()
                resultMsg = ""
                cmd.Parameters.Clear()
                Exit Sub
            End Try
        Next

        alert("Save data successfully") : Exit Sub

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
    End Sub

#End Region

End Class