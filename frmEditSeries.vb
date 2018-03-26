Public Class frmEditSeries
    Private Enum vEdit
        eAdd = 0
        eEdit = 1
        eMerge = 2
    End Enum


    Private m_SeriesID As Integer = 0
    Private m_FlagEdit As vEdit = vEdit.eAdd '0-Add,1-Edit,2-Merge
    '

    Private Sub frmEditSeries_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            If LstOfSeries.SelectedIndex >= 0 Then
                If MsgBox("Вы хотите удалить серию" & vbCrLf & DirectCast(LstOfSeries.SelectedItem, SerieInfo).SeriesTitle, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    ListOfDeleteSeries.Add(DirectCast(LstOfSeries.SelectedItem, SerieInfo))
                    LstOfSeries.Items.Remove(LstOfSeries.SelectedItem)
                    LstOfSeries.SelectedItems.Clear()
                    m_SeriesID = 0
                    txtSerie.Text = String.Empty
                    m_FlagEdit = vEdit.eEdit
                    btnAdd.Text = "Add"
                End If
            End If
        End If

    End Sub

    Private Sub frmEditSeries_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListOfAddSeries = New List(Of SerieInfo)
        ListOfDeleteSeries = New List(Of SerieInfo)
        ListOfMergeSeries = New List(Of MergeSerieInfo)
        ListOfEditSeries = New List(Of SerieInfo)
        LstOfSeries.Items.Clear()
        LstOfSeries.DisplayMember = "SeriesTitle"
        LstOfSeries.ValueMember = "SeriesID"
        For Each cl As SerieInfo In mdlMyLib.ListOfSeries
            LstOfSeries.Items.Add(cl)
        Next
        LstOfSeries.SelectedIndex = -1
        btnAdd.Text = "Add"
        m_FlagEdit = vEdit.eAdd

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnApplay_Click(sender As Object, e As EventArgs) Handles btnApplay.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub LstOfSeries_Click(sender As Object, e As EventArgs) Handles LstOfSeries.Click
        If DirectCast(sender, ListBox).SelectedItems.Count = 1 Then
            txtSerie.Text = DirectCast(sender.SelectedItem, SerieInfo).SeriesTitle
            m_SeriesID = sender.SelectedItem.SeriesID
            m_FlagEdit = vEdit.eEdit
            btnAdd.Text = "Edit"
        ElseIf DirectCast(sender, ListBox).SelectedItems.Count > 1 Then
            m_FlagEdit = vEdit.eMerge
            btnAdd.Text = "Merge"
        End If
    End Sub

    Private Sub btnClearTxt_Click(sender As Object, e As EventArgs) Handles btnClearTxt.Click
        m_SeriesID = 0
        txtSerie.Text = String.Empty
        m_FlagEdit = vEdit.eAdd
        btnAdd.Text = "Add"
    End Sub

    Private Sub LstOfSeries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstOfSeries.SelectedIndexChanged
        If DirectCast(sender, ListBox).SelectedItems.Count = 1 Then
            txtSerie.Text = DirectCast(sender.SelectedItem, SerieInfo).SeriesTitle
            m_SeriesID = sender.SelectedItem.SeriesID
            m_FlagEdit = vEdit.eEdit
            btnAdd.Text = "Edit"
        ElseIf DirectCast(sender, ListBox).SelectedItems.Count > 1 Then
            m_FlagEdit = vEdit.eMerge
            btnAdd.Text = "Merge"
        End If

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If m_FlagEdit = vEdit.eAdd Then
            Dim cl As New SerieInfo
            cl.SeriesID = 0
            cl.SeriesTitle = txtSerie.Text
            cl.SearchSeriesTitle = txtSerie.Text.ToUpper
            ListOfAddSeries.Add(cl)
            LstOfSeries.Items.Add(cl)
            m_SeriesID = 0
            txtSerie.Text = String.Empty
        ElseIf m_FlagEdit = vEdit.eEdit Then
            Dim cl As SerieInfo = New SerieInfo
            cl.SeriesID = m_SeriesID
            cl.SeriesTitle = txtSerie.Text.Trim
            cl.SearchSeriesTitle = txtSerie.Text.Trim.ToUpper
            ListOfEditSeries.Add(cl)
            For i As Integer = 0 To LstOfSeries.Items.Count - 1
                If cl.SeriesID = LstOfSeries.Items(i).SeriesID Then
                    LstOfSeries.Items(i) = cl
                    Exit For
                End If
            Next
            LstOfSeries.SelectedItem = cl
            LstOfSeries.Refresh()
        ElseIf m_FlagEdit = vEdit.eMerge Then
            Dim cl As MergeSerieInfo = New MergeSerieInfo
            Dim lIDs As List(Of Integer) = New List(Of Integer)
            For i As Integer = 0 To LstOfSeries.SelectedItems.Count - 1
                If DirectCast(LstOfSeries.SelectedItems(i), SerieInfo).SeriesID = m_SeriesID Then
                    cl.Serie = LstOfSeries.SelectedItems(i)
                Else
                    cl.Add(LstOfSeries.SelectedItems(i))
                    lIDs.Add(DirectCast(LstOfSeries.SelectedItems(i), SerieInfo).SeriesID)
                End If
            Next
            ListOfMergeSeries.add(cl)
            For idx As Integer = LstOfSeries.Items.Count - 1 To 0 Step -1
                If lIDs.Contains(DirectCast(LstOfSeries.Items(idx), SerieInfo).SeriesID) Then
                    LstOfSeries.Items.RemoveAt(idx)
                End If
            Next
        End If
    End Sub
End Class