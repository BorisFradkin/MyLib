Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmAddSingleBook
    Private FlagAddBooks As Boolean = False
    Private cat As clsCatalog = New clsCatalog()
    Public Property CatalogName() As String
    Private m_MyLib As frmMyLib = Nothing
    Public WriteOnly Property MyLib() As frmMyLib
        Set(value As frmMyLib)
            m_MyLib = value
        End Set
    End Property

    Private Sub frmAddSingleBook_Load(sender As Object, e As EventArgs) Handles Me.Load
        cmbNameCatalog.Items.Clear()
        For Each ci As CatalogInfo In Catalog_Info.Values.OrderBy(Function(x) x.Name)
            Dim Num As Integer = cmbNameCatalog.Items.Add(ci.Name)
            If CurrentCatalogInfo IsNot Nothing AndAlso ci.Name = CurrentCatalogInfo.Name Then
                cmbNameCatalog.SelectedIndex = Num
            End If
        Next
        btnOK.Enabled = False
        lblBooks.Visible = False
        lblNumBooks.Text = "0"
        lblNumBooks.Visible = False
        pnlAddBooks.Location = New Point(-32767, 95)
        Dim ar() As String = Config.Formats.Split(";")
        Dim stFilter As String = "Books|"
        For i = 0 To ar.Length - 1
            stFilter &= "*" & ar(i) & ";"
        Next
        cdOpen.Filter = stFilter & "*.zip|All Files|*.*"
        'cdOpen.InitialDirectory = Config.CatalogBase
        cdOpen.FilterIndex = 1
        lstBooks.Items.Clear()
    End Sub

    Private Sub frmAddSingleBook_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        btnBrowse.Focus()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        If cdOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each st In cdOpen.FileNames
                lstBooks.Items.Add(st)
            Next
            lblBooks.Visible = True
            lblNumBooks.Text = lstBooks.Items.Count
            lblNumBooks.Visible = True
            btnOK.Enabled = True
        End If
        btnOK.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If FlagAddBooks Then
            cat.StopAddBooks()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub btnCLear_Click(sender As Object, e As EventArgs) Handles btnCLear.Click
        lstBooks.Items.Clear()
    End Sub

    Private Sub cmbNameCatalog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNameCatalog.SelectedIndexChanged
        If (CurrentCatalogInfo Is Nothing) OrElse (CurrentCatalogInfo.Name <> DirectCast(sender, ComboBox).Text) Then
            Dim CatFileName As String = Path.Combine(Config.CatalogBase, Catalog_Info(DirectCast(sender, ComboBox).Text.ToLower).FileName)
            m_MyLib.OpenCatalog(Catalog_Info(DirectCast(sender, ComboBox).Text.ToLower))
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Dim ci As CatalogInfo = CurrentCatalogInfo
            pnlAddBooks.Location = New Point(183, 95)
            Cursor = Cursors.WaitCursor
            Application.DoEvents()
            cat = CurrentCatalog
            If Not cat.IsError Then
                CatalogName = cmbNameCatalog.Text

                FlagAddBooks = True
                Dim Num As Integer = 0
                Dim NumF As Integer = 0
                FlagAddBooks = True
                pbAddBooks.Visible = True
                Application.DoEvents()

                For Each St As String In lstBooks.Items
                    Dim BookFI As FileInfo = New FileInfo(St)
                    If BookFI.Extension.ToLower = ".fb2" Then                      
                        Num += m_AddBookFb2(BookFI.FullName, BookFI)
                    ElseIf BookFI.Extension.ToLower = ".epub" Then
                        Num += m_AddBookEpub(BookFI.FullName, BookFI)
                    ElseIf BookFI.Extension.ToLower = ".zip" Then
                        Num += m_AddBookFromZip(BookFI.FullName, BookFI)
                    End If
                    NumF += 1
                    pbAddBooks.Value = (NumF / lstBooks.Items.Count) * 100
                    lblNumBooks.Text = "Добавлено книг " & Num.ToString & " из " & lstBooks.Items.Count.ToString & " файлов"

                    Application.DoEvents()
                    If Not FlagAddBooks Then
                        Exit For
                    End If
                Next

                'cat.AddBooks(txtPath2Books.Text, pbAddBooks, lblAddBook)
                pnlAddBooks.Location = New Point(-32767, 95)
                MsgBox("Добавлено книг " & Num.ToString, MsgBoxStyle.Information)
                cat.Add2Log("Добавлено книг " & Num.ToString, "AddSingleBook")
                Me.DialogResult = Windows.Forms.DialogResult.OK
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
    Private Function m_AddBookFb2(Pth As String, FI As FileInfo) As Integer
        Dim Book As clsCardBookFb2 = New clsCardBookFb2(Pth, FI)
        Book.LoadBook = 1
        cat.SaveBookFb2ToCatalog(Book)
        m_AddBookFb2 = 1
    End Function
    Private Function m_AddBookEpub(Pth As String, FI As FileInfo) As Integer
        Dim Book As clsCardBookEpub = New clsCardBookEpub(Pth)
        Book.LoadBook = 1
        cat.SaveBookEpubToCatalog(Book)
        m_AddBookEpub = 1
    End Function
    Private Function m_AddBookFromZip(pth As String, FiBook As FileInfo) As Integer
        Dim Num As Integer = 0
        Dim PthZip As String = cat.Unzip(pth)
        If PthZip.Length > 0 Then
            Dim Di As DirectoryInfo = New DirectoryInfo(PthZip)
            Dim ArTmp() As FileInfo = Di.GetFiles("*", SearchOption.AllDirectories)
            Dim Fi As List(Of FileInfo) = ArTmp.Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").ToList
            For Idx = 0 To Fi.Count - 1
                If Fi(Idx).Extension.ToLower = ".fb2" Then
                    Num += m_AddBookFb2(Fi(Idx).FullName, FiBook)
                ElseIf Fi(Idx).Extension.ToLower = ".epub" Then
                    Num += m_AddBookEpub(Fi(Idx).FullName, FiBook)
                ElseIf Fi(Idx).Extension.ToLower = ".zip" Then
                    Num += m_AddBookFromZip(Fi(Idx).FullName, FiBook)
                End If
            Next
            Directory.Delete(PthZip, True)
        End If
        Return Num
    End Function
End Class