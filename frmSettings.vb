Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmSettings

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtCatalogBase.Text = Config.CatalogBase
        txtFormats.Text = Config.Formats
        txtList2Read.Text = Config.List2Read
        txtReader.Text = Config.Reader
        txtLogFile.Text = Config.LogFile
        txtPostfixFileName.Text = Config.PostfixFileName
        txtPrefixFileName.Text = Config.PrefixFileName
        txtTempPath.Text = Config.TempPath
        chkLookZip.Checked = Config.LookZip
        chkSubFolders.Checked = Config.Subfolders
        chkShowSeriesInTree.Checked = Config.ShowSeriesOnTree
        cmbLangInterface.SelectedIndex = SetLang(Config.InterfaceLanguage)
        chkAddGenres.Checked = Config.GenresFromFiles
    End Sub

    Private Sub btnBrowseCatalogBase_Click(sender As Object, e As EventArgs) Handles btnBrowseCatalogBase.Click
        cdFolderBrowser.SelectedPath = txtCatalogBase.Text
        Dim ret = cdFolderBrowser.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            txtCatalogBase.Text = cdFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub btnBrowseTempPath_Click(sender As Object, e As EventArgs) Handles btnBrowseTempPath.Click
        cdFolderBrowser.SelectedPath = txtTempPath.Text
        Dim ret = cdFolderBrowser.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            txtTempPath.Text = cdFolderBrowser.SelectedPath
        End If

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Config.CatalogBase = txtCatalogBase.Text
        Config.Formats = txtFormats.Text
        Config.List2Read = txtList2Read.Text
        Config.Reader = txtReader.Text
        Config.LogFile = txtLogFile.Text
        Config.PostfixFileName = txtPostfixFileName.Text
        Config.PrefixFileName = txtPrefixFileName.Text
        Config.TempPath = txtTempPath.Text
        Config.LookZip = chkLookZip.Checked
        Config.Subfolders = chkSubFolders.Checked
        Config.ShowSeriesOnTree = chkShowSeriesInTree.Checked
        Config.GenresFromFiles = chkAddGenres.Checked
        Config.InterfaceLanguage = SetLang(cmbLangInterface.SelectedIndex)
        Config.Save()
        Me.Close()
    End Sub

    Private Sub btnBrowseList2Read_Click(sender As Object, e As EventArgs) Handles btnBrowseList2Read.Click
        cdFolderBrowser.SelectedPath = txtList2Read.Text
        Dim ret = cdFolderBrowser.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            txtList2Read.Text = cdFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub btnBrowserReader_Click(sender As Object, e As EventArgs) Handles btnBrowserReader.Click
        cdOpenFile.Filter = "EXE|*.exe|All Files|*.*" '
        cdOpenFile.InitialDirectory = "c:\Program Files"
        cdOpenFile.FilterIndex = 1
        Dim ret = cdOpenFile.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            txtReader.Text = cdOpenFile.FileName
        End If
    End Sub

    Private Function SetLang(Lang As String) As Integer
        For i As Integer = 0 To cmbLangInterface.Items.Count - 1
            If (cmbLangInterface.Items(i).ToString.ToLower = "русский" And Lang.ToLower = "ru") Or
                (cmbLangInterface.Items(i).ToString.ToLower = "english" And Lang.ToLower = "en") Or
                (cmbLangInterface.Items(i).ToString.ToLower = "עברית" And Lang.ToLower = "he") Then
                Return i
            End If
        Next
        Return -1
    End Function

    Private Function SetLang(idx As Integer) As String
        Select Case cmbLangInterface.SelectedItem.ToString.ToLower
            Case "русский"
                Return "RU"
            Case "english"
                Return "EN"
            Case "עברית"
                Return "HE"
        End Select
        Return ""
    End Function
End Class