Imports System.IO
Public Class frmDeleteBook
    Public Property Books As List(Of DeletingBooks) = Nothing

    Private Sub frmDeleteBook_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Books IsNot Nothing Then
            lstBooks.DataSource = Books
            lstBooks.DisplayMember = "Tit"
            lstBooks.ValueMember = "ID"
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        CurrentCatalog.DeleteBook(Books, CheckBox1.Checked)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class