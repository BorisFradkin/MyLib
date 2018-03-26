
Public Class frmBookInfo
    Private m_Book As clsCardBook
    Public WriteOnly Property Book() As clsCardBook
        Set(value As clsCardBook)
            m_Book = value
        End Set
    End Property

    Private Sub frmBookInfo_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblTitle.Text = m_Book.Title
        lblAuthor.Text = String.Join(", ", m_Book.Authors.Select(Function(x) x.ToShow).ToArray)
        lblPublisher.Text = m_Book.Publisher
        lblFolder.Text = m_Book.FolderName
        lblFileName.Text = m_Book.FileName
        lblSize.Text = m_Book.BookSize
        lblDate.Text = m_Book.LoadDate
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class