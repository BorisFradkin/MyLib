Public Class frmAddKeywords
    Public Property EditBookInfo As frmEditBookInfo = Nothing

    Private Sub frmAddKeywords_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtKeywords.Text = EditBookInfo.Book.KeyWords.Replace(",", vbCrLf)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        EditBookInfo.Book.KeyWords = txtKeywords.Text.Replace(vbCrLf, ",")
        Me.Close()
    End Sub

End Class