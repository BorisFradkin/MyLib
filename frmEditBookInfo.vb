Imports System.IO

Public Class frmEditBookInfo
    Public Property Book As clsCardBook
    Public Genres As List(Of String) = Nothing
    Private Title As String = String.Empty
    Private Authors As List(Of Author) = New List(Of Author)
    Private Series As String = String.Empty
    Private SeqNumber As Integer = 0
    Private Publisher As String = String.Empty
    Private Annotation As String = String.Empty
    Private KeyWords As String = String.Empty
    Private FlagLoad As Boolean = False
    Private FlagChangeAuthors As Boolean = False
    Private FlagChangeSeries As Boolean = False

    Private Sub frmEditBookInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        FlagLoad = True
        txtTitle.Text = Book.Title

        txtAuthLastName.DataSource = Book.Authors
        txtAuthLastName.DisplayMember = "LastName"
        txtAuthLastName.ValueMember = "AuthorID"
        txtAuthLastName.SelectedIndex = 0
        txtAuthFirstName.Text = Book.Authors(0).FirstName
        txtMidleName.Text = Book.Authors(0).MiddleName
        txtGenre.Text = ""
        For Each Gr In Book.Genres
            txtGenre.Text &= Gr.Trim & "; "
        Next
        'txtGenre.Items.Clear()
        'For Each Gr In Book.Genres
        '    txtGenre.Items.Add(Gr.Trim)
        'Next
        txtSerie.Text = Book.Series
        txtNumOfSerie.Text = Book.SeqNumber
        txtAnnotation.Text = Book.Annotation
        txtKewWords.Text = Book.KeyWords
        txtPublisher.Text = Book.Publisher
        btnOK.Enabled = False
        FlagLoad = False
    End Sub

    Private Sub txtAnnotation_TextChanged(sender As Object, e As EventArgs) Handles txtAnnotation.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub txtAuthFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtAuthFirstName.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtAuthLastName_TextChanged(sender As Object, e As EventArgs)
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtGenre_TextChanged(sender As Object, e As EventArgs)
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtKewWords_TextChanged(sender As Object, e As EventArgs) Handles txtKewWords.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtNumOfSerie_TextChanged(sender As Object, e As EventArgs) Handles txtNumOfSerie.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtPublisher_TextChanged(sender As Object, e As EventArgs) Handles txtPublisher.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged
        If Not FlagLoad Then
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAddAuth_Click(sender As Object, e As EventArgs) Handles btnAddAuth.Click
        Dim frm As frmAddAuthors = New frmAddAuthors
        frm.EditBookInfo = Me
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FlagLoad = True
            txtAuthLastName.DataSource = Nothing
            txtAuthLastName.Items.Clear()
            txtAuthLastName.DataSource = Book.Authors
            txtAuthLastName.DisplayMember = "LastName"
            txtAuthLastName.ValueMember = "AuthorID"
            txtAuthLastName.SelectedIndex = 0
            txtAuthFirstName.Text = Book.Authors(0).FirstName
            txtMidleName.Text = Book.Authors(0).MiddleName
            FlagLoad = False
            FlagChangeAuthors = True
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnAddGenre_Click(sender As Object, e As EventArgs) Handles btnAddGenre.Click
        Dim frm As frmAddGenres = New frmAddGenres
        frm.EditBookInfo = Me
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtGenre.Text = ""
            For Each al As String In CurrentCatalog.GetGenresAlias(Genres)
                txtGenre.Text &= al & "; "
            Next
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub btnAddKeyWords_Click(sender As Object, e As EventArgs) Handles btnAddKeyWords.Click
        Dim frm As frmAddKeywords = New frmAddKeywords
        frm.EditBookInfo = Me
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtKewWords.Text = Book.KeyWords
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub btnAddSeries_Click(sender As Object, e As EventArgs) Handles btnAddSeries.Click
        Dim frm As frmAddSeries = New frmAddSeries
        frm.EditBookInfo = Me
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FlagLoad = True
            txtSerie.Text = Book.Series
            FlagLoad = False
            FlagChangeSeries = True
            btnOK.Enabled = True
        End If

    End Sub

    Private Sub txtAuthLastName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtAuthLastName.SelectedIndexChanged
        If Not FlagLoad Then
            Dim ID As Integer = txtAuthLastName.SelectedValue
            For Each auth As Author In Book.Authors
                If auth.ID = ID Then
                    txtAuthFirstName.Text = auth.FirstName
                    txtMidleName.Text = auth.MiddleName
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Book.Title = txtTitle.Text
        Book.Annotation = txtAnnotation.Text
        Book.Publisher = txtPublisher.Text
        Book = CurrentCatalog.EditBookInfo(Book, FlagChangeAuthors, FlagChangeSeries, Genres)
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub
End Class