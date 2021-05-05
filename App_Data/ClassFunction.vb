Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Web

Public Class ClassFunction

    Public Sub MessageBox(ByVal msg As String, ByVal obj As Object)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'>" & Environment.NewLine & "window.alert('" + msg + "')</scr" & "ipt>"
        obj.controls.add(lbl)
    End Sub

    Public Function GetIPAddress(ByVal sender As Object) As String
        Dim clientip As String = ""
        If Not sender.Request.ServerVariables("HTTP_X_FORWARDED_FOR") Is Nothing Then
            clientip = sender.Request.ServerVariables("HTTP_X_FORWARDED_FOR").ToString()
        Else
            clientip = sender.Request.ServerVariables("REMOTE_ADDR").ToString()
        End If
        Return clientip
    End Function

    Public Function EncryptPassword(ByVal User As String, ByVal Pass As String) As String
        Dim Firstdigit As String
        Dim Joincode As String
        Dim zz, tr_code As Integer
        Dim Lastcode As String
        Dim drum As String

        Firstdigit = Chr(88 - Len(User)) ' Tel Digit of Useid
        For zz = 1 To Len(User)
            drum = Asc(Mid(User, zz, 1))
            tr_code = drum * 2
            drum = Chr(tr_code)
            Firstdigit = Firstdigit & drum
        Next zz
        Joincode = Chr(103 + Len(Pass)) ' Tel Digit of Useid
        Lastcode = ""
        drum = 0
        For zz = Len(Pass) To 1 Step -1
            drum = 5 * Asc(Mid(Pass, zz, 1))
            Lastcode = Lastcode & Hex(drum)
        Next zz
        ' Change 32 bit
        EncryptPassword = Firstdigit & Joincode & Lastcode
        Return EncryptPassword
    End Function

    Public Function GetPhoto(ByVal filePath As String) As Byte()
        Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)
        Dim photo() As Byte = br.ReadBytes(fs.Length)
        br.Close()
        fs.Close()
        Return photo
    End Function

    'Public Sub BlobFile(ByVal PathFile As String, ByVal TableName As String, ByVal WhereString As String, ByVal ParameterString As String)
    '    Dim Cn As SqlConnection = New SqlConnection(SQLCon)
    '    Dim cmd As SqlClient.SqlCommand
    '    Dim photo As Byte()

    '    photo = GetPhoto(PathFile)
    '    SQL(1) = "Update " & TableName & " Set " & ParameterString & "=@" & ParameterString & " " & WhereString
    '    Cn.Open()
    '    cmd = New SqlClient.SqlCommand(SQL(1), Cn)
    '    cmd.Parameters.Add("@" & ParameterString & "", SqlDbType.Image, photo.Length).Value = photo
    '    If (Cn.State = ConnectionState.Closed) Then Cn.Open()
    '    cmd.ExecuteNonQuery()
    '    Cn.Close()
    'End Sub

    Public Sub UploadFile(ByVal FileControlUpload As System.Web.UI.WebControls.FileUpload, ByVal FileName As String, ByVal TargetDirectory As String)
        Dim vNameForSave As String = ""
        Dim vOldname As String = ""
        Dim vFileType As String = ""
        '===Set value
        'vOldname = FileControlUpload.PostedFile.FileName.Trim()
        'vFileType = Right(vOldname, Len(vOldname) - InStr(vOldname, "."))
        'vNameForSave = FileName & Right(vOldname, Len(vOldname) - InStr(vOldname, ".") + 1)
        '===Check repeat file
        Dim ObjFile As New FileInfo(TargetDirectory + FileName)
        If ObjFile.Exists = True Then
            ObjFile.Delete()
        End If
        '===Save file
        FileControlUpload.PostedFile.SaveAs(TargetDirectory + FileName)
    End Sub

#Region "Format Date"

    Public Function DateString_Save(ByVal dDate As Date) As String
        '===format=>01-01-2010
        Dim d As String = Day(dDate)
        Dim m As String = Month(dDate)
        DateString_Save = Year(dDate) & "-" & Format(Month(dDate), "00") & "-" & Format(Day(dDate), "00")
    End Function
    Public Function DateString_Save(ByVal dDate As String) As String
        '===format=>01-01-2010
        DateString_Save = Right(dDate, 4) & "-" & Mid(dDate, 4, 2) & "-" & Left(dDate, 2)
    End Function

    Public Function DateString_Show(ByVal dDate As Date) As String
        '===format=>01-01-2010
        Dim d As String = Day(dDate)
        Dim m As String = Month(dDate)
        DateString_Show = Format(Day(dDate), "00") & "-" & Format(Month(dDate), "00") & "-" & Year(dDate)
    End Function
    Public Function DateString_Show(ByVal dDate As String) As String
        '===format=>01-01-2010
        DateString_Show = Left(dDate, 2) & "-" & Mid(dDate, 4, 2) & "-" & Right(dDate, 4)
    End Function
#End Region
End Class
