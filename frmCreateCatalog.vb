Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmCreateCatalog
    Private FlagAddBooks As Boolean = False
    Private cat As clsCatalog = New clsCatalog()
    Public Property CatalogName() As String
    Private LineNum As Integer
    Private m_NumBooks As Integer = 0

    Private Sub frmCreateCatalog_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnOK.Enabled = False
        lblBooks.Visible = False
        lblNumBooks.Text = "0"
        lblNumBooks.Visible = False
        pnlCreateCatalog.Location = New Point(-32767, 95)

    End Sub

    Private Sub frmCreateCatalog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtNameCatalog.Focus()
    End Sub

    Private Sub txtNameCatalog_Validated(sender As Object, e As EventArgs) Handles txtNameCatalog.Validated
        If Catalog_Info.ContainsKey(DirectCast(sender, TextBox).Text.ToLower) Then
            MsgBox("duplicate Name of Catalog", MsgBoxStyle.Critical)
            txtNameCatalog.Focus()
        Else
            Dim Pth As String = Config.CatalogBase
            For i As Integer = 1 To 9999
                txtFileName.Text = Config.PrefixFileName & i.ToString.PadLeft(4, "0") & Config.PostfixFileName
                If Not File.Exists(Path.Combine(Pth, txtFileName.Text)) Then
                    Exit For
                End If
            Next
            txtFileName.Focus()
        End If
    End Sub

    Private Sub txtFileName_Validated(sender As Object, e As EventArgs) Handles txtFileName.Validated
        If File.Exists(Path.Combine(Config.CatalogBase, sender.text)) Then
            MsgBox("Duplicate FileName", MsgBoxStyle.Critical)
            txtFileName.Focus()
        Else
            btnOK.Enabled = True
            btnBrowse.Focus()
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ret = folderBrowse.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            txtPath2Books.Text &= folderBrowse.SelectedPath & vbCrLf

            lblBooks.Visible = True
            m_NumBooks += CheckFolderPath(folderBrowse.SelectedPath)
            lblNumBooks.Text = m_NumBooks.ToString
            lblNumBooks.Visible = True
            btnOK.Enabled = OkEnabled()
        End If
        txtDescription.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If FlagAddBooks Then
            cat.stopAddBooks()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub txtPath2Books_Validated(sender As Object, e As EventArgs) Handles txtPath2Books.Validated
        If txtPath2Books.Text.Trim.Length > 0 AndAlso Directory.Exists(txtPath2Books.Text) Then
            lblBooks.Visible = True
            lblNumBooks.Text = CheckFolderPath(txtPath2Books.Text.Trim).ToString
            lblNumBooks.Visible = True
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            EnabledControls(False)
            Dim ci As CatalogInfo = New CatalogInfo
            ci.Version = My.Application.Info.Version.ToString
            ci.Name = txtNameCatalog.Text
            ci.FileName = txtFileName.Text
            ci.Path2Books = String.Empty
            For Each Pth As String In txtPath2Books.Lines
                ci.Path2Books &= Pth & ";"
            Next
            ci.Description = txtDescription.Text
            lblAddBook.Visible = False
            lblAddBook.Visible = False
            pbAddBooks.Visible = False
            pnlCreateCatalog.Location = New Point(183, 95)
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            cat.CreteNewCatalog(ci.FileName)
            If Not cat.IsError Then
                Write2Log("Catalog: " & ci.Name & " успешно создан File:" & ci.FileName)
                Dim arCat As List(Of CatalogInfo) = (From El As String In Config.Catalogs.Split(Chr(255))
                                                     Where El.Length > 0
                                                     Select JsonConvert.DeserializeObject(Of CatalogInfo)(El)).ToList
                arCat.Add(ci)
                Dim st As String = String.Empty
                For Each el In arCat
                    Dim jsonobj = JToken.FromObject(el)
                    st &= jsonobj.ToString & Chr(255)
                Next
                If st.EndsWith(Chr(255)) Then
                    st = st.Substring(0, st.Length - 1)
                End If
                Config.Catalogs = st
                Config.Save()
                CatalogName = txtNameCatalog.Text
                cat.SaveCatalogInfo(ci)
                If chkAddBooks.Checked Then
                    For Each Pth As String In txtPath2Books.Lines
                        Try
                            If Pth.Trim.Length > 0 Then
                                FlagAddBooks = True
                                cat.AddBooks(Pth, pbAddBooks, lblAddBook)
                            End If
                        Catch ex As Exception
                            Write2Log(ex.Message)
                        End Try
                    Next
                    pnlCreateCatalog.Location = New Point(-32767, 95)
                    MsgBox("Добавлено книг " & cat.NumAddBooks.ToString, MsgBoxStyle.Information)
                    Write2Log("Добавлено книг " & cat.NumAddBooks.ToString)
                End If

                If cat.IsError Then
                    MsgBox(cat.LastError, MsgBoxStyle.Critical)
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Else
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                Write2Log(cat.LastError)
                MsgBox(cat.LastError, MsgBoxStyle.Critical)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If

        Catch ex As Exception
            Write2Log(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
        Cursor = Cursors.Default
        cat.CloseCatalog()
        cat = Nothing
        Me.Close()

    End Sub
    Private Sub EnabledControls(Ena As Boolean)
        txtDescription.Enabled = Ena
        txtFileName.Enabled = Ena
        txtNameCatalog.Enabled = Ena
        txtPath2Books.Enabled = Ena
        chkAddBooks.Enabled = Ena
        btnOK.Enabled = Ena
    End Sub
    Private Sub Write2Log(msg As String)
        Dim st As String = Now.ToString & " " & msg
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
    Private Sub txtPath2Books_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPath2Books.MouseDown
        LineNum = -1
        If e.Button = MouseButtons.Right Then
            Dim idx As Integer = txtPath2Books.GetCharIndexFromPosition(New Point(e.X, e.Y))
            LineNum = txtPath2Books.GetLineFromCharIndex(idx)
        End If
    End Sub
    Private Function CheckFolderPath(Pth As String) As Integer
        Dim NumBooks As Integer = 0
        Dim Di As DirectoryInfo = New DirectoryInfo(Pth)
        NumBooks = Di.GetFiles("*", SearchOption.AllDirectories).Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").Count
        Return NumBooks
    End Function
    Private Sub cntxDelete_Click(sender As Object, e As EventArgs) Handles cntxDelete.Click
        If LineNum >= 0 Then
            If LineNum = 0 Then
                txtPath2Books.Lines = txtPath2Books.Lines.Skip(1).ToArray
            ElseIf LineNum = txtPath2Books.Lines.Length - 1 Then
                txtPath2Books.Lines = txtPath2Books.Lines.Take(txtPath2Books.Lines.Length - 1).ToArray
            Else
                txtPath2Books.Lines = txtPath2Books.Lines.Where(Function(item, index) index <> LineNum).ToArray
            End If
        End If
        m_NumBooks = 0
        For Each st As String In txtPath2Books.Lines
            If st.Trim.Length > 0 Then
                m_NumBooks += CheckFolderPath(st)
            End If
        Next
        lblNumBooks.Text = m_NumBooks.ToString
        lblNumBooks.Visible = True
        btnOK.Enabled = OkEnabled()
    End Sub
    Private Function OkEnabled() As Boolean
        If m_NumBooks > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
End Class