Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmAttach
    Public Property CatalogName() As String
    Private Cat As clsCatalog = Nothing
    Private ci As CatalogInfo = Nothing
    Private Sub frmAttach_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnOK.Enabled = False
        lblNumBooks.Text = "Книг в каталоге - " & "0"
        lblNumBooks.Visible = False
        txtFileName.Text = String.Empty
        txtNameCatalog.Text = String.Empty
        txtDescription.Text = String.Empty
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        cdOpen.InitialDirectory = Config.CatalogBase
        cdOpen.Filter = "Catalogs|*" & Config.PostfixFileName & "|All files|*.*"
        cdOpen.FilterIndex = 1
        cdOpen.RestoreDirectory = True

        If cdOpen.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtFileName.Text = cdOpen.FileName
            Cat = New clsCatalog
            Cat.OpenCatalog(txtFileName.Text)
            If Cat.IsError Then
                MsgBox(Cat.LastError, MsgBoxStyle.Critical)
                txtFileName.Text = String.Empty
                Cat = Nothing
                txtFileName.Focus()
            Else
                lblNumBooks.Text = "Книг в каталоге - " & Cat.NumBooks.ToString
                lblNumBooks.Visible = True
                ci = Cat.GetCatalogInfoFromDB()
                If Not Cat.IsError Then
                    txtNameCatalog.Text = ci.Name
                    txtDescription.Text = ci.Description
                End If
                txtNameCatalog.Focus()
                End If
            End If
        OkEnabled()
    End Sub
    Private Sub OkEnabled()
        If (Cat IsNot Nothing) AndAlso txtNameCatalog.Text.Trim.Length > 0 AndAlso CheckDuplicateCatalogName(txtNameCatalog.Text.Trim) Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If
    End Sub
    Private Function CheckDuplicateCatalogName(NmCatalog As String) As Boolean
        If Catalog_Info.ContainsKey(NmCatalog.ToLower) Then
            MsgBox("Duplicate Name of Catalog", MsgBoxStyle.Critical)
            txtNameCatalog.Focus()
            CheckDuplicateCatalogName = False
        Else
            CheckDuplicateCatalogName = True
        End If
    End Function

    Private Sub txtNameCatalog_Validated(sender As Object, e As EventArgs) Handles txtNameCatalog.Validated
        If CheckDuplicateCatalogName(txtNameCatalog.Text.Trim) Then
            txtDescription.Focus()
        Else
            txtNameCatalog.Focus()
        End If
        OkEnabled()
    End Sub


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Dim ci As CatalogInfo = New CatalogInfo
            ci.Name = txtNameCatalog.Text
            ci.FileName = txtFileName.Text
            ci.Path2Books = Cat.GetPath2Books
            ci.Description = txtDescription.Text
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            Dim arCat As List(Of CatalogInfo) = (From El As String In Config.Catalogs.Split(Chr(255))
                                                 Where El.Length > 0
                                                 Select JsonConvert.DeserializeObject(Of CatalogInfo)(El)).ToList
            arCat.Add(ci)
            Dim st As String = String.Empty
            For Each el In arCat
                Dim jsonObj = JToken.FromObject(el)
                st &= jsonObj.ToString & Chr(255)
            Next
            If st.EndsWith(Chr(255)) Then
                st = st.Substring(0, st.Length - 1)
            End If
            Config.Catalogs = st
            Config.Save()
            Cat.SaveCatalogInfo(CurrentCatalogInfo)
            CatalogName = txtNameCatalog.Text
            Write2Log("Catalog " & txtNameCatalog.Text & " attached. Number Of Books: " & Cat.NumBooks.ToString)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Write2Log(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Cursor = Cursors.Default
        Cat.CloseCatalog()
        Cat = Nothing
        Me.Close()


    End Sub
    Private Sub Write2Log(msg As String)
        Dim st As String = Now.ToString & " " & msg
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
End Class