Public Class frmAddAuthors
    Private toolTip As ToolTip = New ToolTip()
    Public Property EditBookInfo As frmEditBookInfo = Nothing

    Private Sub frmAddAuthors_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillListOfAuthors()
        lstAuth.DataSource = ListOfAuthors
        lstAuth.DisplayMember = "ToShow"
        lstAuth.ValueMember = "AuthorID"
        If EditBookInfo IsNot Nothing Then
            For Idx As Integer = 0 To lstAuth.Items.Count - 1
                For Each auth As Author In EditBookInfo.Book.Authors
                    If auth.AuthorID = lstAuth.Items(Idx).ID Then
                        lstAuth.SetItemChecked(Idx, True)
                    End If
                Next
            Next
        End If
    End Sub

 
    Private Sub lstAuth_MouseMove(sender As Object, e As MouseEventArgs) Handles lstAuth.MouseMove
        Dim index As Integer = lstAuth.IndexFromPoint(e.Location)
        If (index <> -1 AndAlso index < lstAuth.Items.Count) Then
            If (toolTip.GetToolTip(lstAuth) <> lstAuth.Items(index).ToString()) Then
                toolTip.SetToolTip(lstAuth, lstAuth.Items(index).ToString())
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        EditBookInfo.Book.Authors.Clear()
        For Each Auth As Author In lstAuth.CheckedItems
            EditBookInfo.Book.Authors.Add(Auth)
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class