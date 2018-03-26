Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmAddBooks
    Private FlagAddBooks As Boolean = False
    Private cat As clsCatalog = New clsCatalog()
    Public Property CatalogName() As String
    Private m_MyLib As frmMyLib = Nothing
    Private m_NumBooks As Integer = 0
    Private m_NumFolders As Integer
    Dim LineNum As Integer

    Public WriteOnly Property MyLib() As frmMyLib
        Set(value As frmMyLib)
            m_MyLib = value
        End Set
    End Property
    Private Sub frmAddBook_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbNameCatalog.Items.Clear()
        For Each ci As CatalogInfo In Catalog_Info.Values.OrderBy(Function(x) x.Name)
            Dim Num As Integer = cmbNameCatalog.Items.Add(ci.Name)
            If CurrentCatalogInfo IsNot Nothing AndAlso ci.Name = CurrentCatalogInfo.Name Then
                cmbNameCatalog.SelectedIndex = Num
            End If
        Next
        txtPath2Books.Text = String.Empty
        'txtPath2Books.Text = CurrentCatalogInfo.Path2Books.Trim(";").Replace(";", vbCrLf) & vbCrLf
        btnOK.Enabled = OkEnabled()
        lblBooks.Visible = False
        lblNumBooks.Text = m_NumBooks.ToString
        lblNumBooks.Visible = False
        pnlAddBooks.Location = New Point(-32767, 95)
    End Sub

    Private Sub frmAddBook_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        btnBrowse.Focus()
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
        If btnOK.Enabled Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If FlagAddBooks Then
            cat.StopAddBooks()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub
    Private Function CheckFolderPath(Pth As String) As Integer
        Dim NumBooks As Integer = 0
        Dim Di As DirectoryInfo = New DirectoryInfo(Pth)
        NumBooks = Di.GetFiles("*", SearchOption.AllDirectories).Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").Count
        Return NumBooks
    End Function


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            EnabledControls(False)
            Dim ci As CatalogInfo = CurrentCatalogInfo
            ci.Description = txtDescription.Text
            pnlAddBooks.Location = New Point(183, 95)
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            cat = CurrentCatalog
            If Not cat.IsError Then
                CatalogName = cmbNameCatalog.Text
                For Each pth As String In txtPath2Books.Lines
                    FlagAddBooks = True
                    cat.AddBooks(pth, pbAddBooks, lblAddBook)
                    ci.Path2Books &= pth & ";"
                Next
                pnlAddBooks.Location = New Point(-32767, 95)
                MsgBox("Добавлено книг " & cat.NumAddBooks.ToString, MsgBoxStyle.Information)

                If cat.IsError Then
                    MsgBox(cat.LastError, MsgBoxStyle.Critical)
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Else
                    Dim ct As CatalogInfo = Nothing
                    If Config.Catalogs IsNot Nothing Then
                        Dim ArCat() As String = Config.Catalogs.Split(Chr(255))
                        For Idx = 0 To Config.Catalogs.Count - 1
                            Dim st As String = ArCat(Idx)
                            ct = JsonConvert.DeserializeObject(Of CatalogInfo)(st)
                            If ct.Name = CurrentCatalogInfo.Name Then
                                Dim JsonObj = JToken.FromObject(ci)
                                ArCat(Idx) = JsonObj.ToString
                                Config.Catalogs = Join(ArCat, vbCrLf)
                                Exit For
                            End If
                        Next
                        Config.Save()
                        cat.SaveCatalogInfo(CurrentCatalogInfo)
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    End If
                End If
            Else
                MsgBox(cat.LastError, MsgBoxStyle.Critical)
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If

        Catch ex As Exception
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
        cmbNameCatalog.Enabled = Ena
        txtPath2Books.Enabled = Ena
        btnOK.Enabled = OkEnabled()
    End Sub


    Private Sub cmbNameCatalog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNameCatalog.SelectedIndexChanged
        If (CurrentCatalogInfo Is Nothing) OrElse (CurrentCatalogInfo.Name <> DirectCast(sender, ComboBox).Text) Then
            Dim CatFileName As String = Path.Combine(Config.CatalogBase, Catalog_Info(DirectCast(sender, ComboBox).Text.ToLower).FileName)
            txtDescription.Text = Catalog_Info(DirectCast(sender, ComboBox).Text.ToLower).Description
            m_MyLib.OpenCatalog(Catalog_Info(DirectCast(sender, ComboBox).Text.ToLower))
        End If
    End Sub




    Private Sub txtPath2Books_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPath2Books.MouseDown
        LineNum = -1
        If e.Button = MouseButtons.Right Then
            Dim idx As Integer = txtPath2Books.GetCharIndexFromPosition(New Point(e.X, e.Y))
            LineNum = txtPath2Books.GetLineFromCharIndex(idx)
        End If
    End Sub

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
        If (cmbNameCatalog.SelectedIndex >= 0) AndAlso ((CurrentCatalog IsNot Nothing) And (CurrentCatalogInfo IsNot Nothing)) Then
            If m_NumBooks > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
End Class