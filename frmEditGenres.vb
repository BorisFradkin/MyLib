Public Class frmEditGenres
    Private Sub frmEditGenres_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
    End Sub
End Class