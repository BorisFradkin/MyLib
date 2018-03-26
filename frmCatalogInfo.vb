Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmCatalogInfo
    Private NumAuth As Integer = CurrentCatalog.NumAuthors()
    Private NumBooks As Integer = CurrentCatalog.NumBooks()
    Private NumSeries As Integer = CurrentCatalog.NumSeries()
    Private FlagChanged As Boolean = False
    Private Sub frmCatalogInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        With CurrentCatalogInfo
            txtNameCatalog.Text = .Name
            txtFileName.Text = Path.Combine(Config.CatalogBase, .FileName)
            txtPath2Books.Text = .Path2Books.Replace(";", vbCrLf)
            txtDescription.Text = .Description

        End With
        lblStatistic.Text = "Авторов: " & NumAuth.ToString & ", " & "Книг: " & NumBooks.ToString & ", " & "Серий: " & NumSeries.ToString
        FlagChanged = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged
        FlagChanged = True
    End Sub

    Private Sub txtNameCatalog_TextChanged(sender As Object, e As EventArgs) Handles txtNameCatalog.TextChanged
        FlagChanged = True
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If FlagChanged Then
            Dim ci As CatalogInfo = New CatalogInfo
            ci = CurrentCatalogInfo
            Dim arCat As List(Of CatalogInfo) = (From El As String In Config.Catalogs.Split(Chr(255))
                                                 Where El.Length > 0
                                                 Select JsonConvert.DeserializeObject(Of CatalogInfo)(El)).ToList
            For Idx = 0 To arCat.Count - 1
                If ci.Name = CurrentCatalogInfo.Name Then
                    ci.Name = txtNameCatalog.Text
                    ci.Description = txtDescription.Text
                    arCat.Item(Idx) = ci
                    Exit For
                End If
            Next
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
            CurrentCatalogInfo = ci
            CurrentCatalog.SaveCatalogInfo(CurrentCatalogInfo)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.No
        End If
        Me.Close()
    End Sub
End Class