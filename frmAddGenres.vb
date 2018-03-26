Public Class frmAddGenres
    Public Property EditBookInfo As frmEditBookInfo = Nothing
    Private Sub frmAddGenres_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
        Dim lstGenreBook As List(Of String) = CurrentCatalog.GetGenriesIDByBookId(EditBookInfo.Book.BookID)
        Dim lstChk As List(Of TreeNode) = (From el In lst
                                         Where lstGenreBook.Contains(el.GenreCode)
                                         Select el.TrvNode).ToList
        For Each nd As TreeNode In lstChk
            nd.Checked = True
            If nd.Parent IsNot Nothing AndAlso nd.Parent IsNot trvGenre Then
                nd.Parent.Expand()
            End If

        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Dim LstG As List(Of String) = New List(Of String)
        For Each nd As TreeNode In trvGenre.Nodes
            For Each ndc As TreeNode In nd.Nodes
                If ndc.Checked Then
                    LstG.Add(ndc.Tag)
                End If
            Next
        Next
        EditBookInfo.Genres = LstG
        Me.Close()
    End Sub

    Private Sub trvGenre_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvGenre.AfterCheck
        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Checked Then
                e.Node.Expand()
            End If
            For Each nd As TreeNode In e.Node.Nodes
                nd.Checked = e.Node.Checked
            Next
        End If
    End Sub
End Class