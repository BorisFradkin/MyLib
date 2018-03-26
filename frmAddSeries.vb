Public Class frmAddSeries
    Public Property EditBookInfo As frmEditBookInfo = Nothing

    Private Sub frmAddAuthors_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillListOfSeries()
        lstSeries.DataSource = ListOfSeries
        lstSeries.DisplayMember = "SeriesTitle"
        lstSeries.ValueMember = "SeriesID"
        If EditBookInfo IsNot Nothing Then
            For Idx As Integer = 0 To lstSeries.Items.Count - 1
                If lstSeries.Items(Idx).SeriesID = EditBookInfo.Book.SeriesID Then
                    lstSeries.SetItemChecked(Idx, True)
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        For Each St As SerieInfo In lstSeries.CheckedItems
            EditBookInfo.Book.Series = St.SeriesTitle
            EditBookInfo.Book.SeriesID = St.SeriesID
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub lstSeries_Click(sender As Object, e As EventArgs) Handles lstSeries.Click
        For Each ch As Integer In lstSeries.CheckedIndices
            lstSeries.SetItemChecked(ch, False)
        Next
    End Sub
End Class