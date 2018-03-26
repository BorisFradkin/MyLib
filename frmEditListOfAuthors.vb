Public Class frmEditListOfAuthors
    Private Enum vEdit
        eAdd = 0
        eEdit = 1
        eMerge = 2
    End Enum


    Private m_AuthID As Integer = 0
    Private m_FlagEdit As vEdit = vEdit.eAdd '0-Add,1-Edit,2-Merge
    '

    Private Sub frmEditListOfAuthors_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then
            If LstOfAuthors.SelectedIndex >= 0 Then
                If MsgBox("Вы хотите удалить автора" & vbCrLf & DirectCast(LstOfAuthors.SelectedItem, Author).FullName, MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    ListOfDeleteAuth.Add(DirectCast(LstOfAuthors.SelectedItem, Author))
                    LstOfAuthors.Items.Remove(LstOfAuthors.SelectedItem)
                    LstOfAuthors.SelectedItems.Clear()
                    LstOfBooks.DataSource = {}
                    m_AuthID = 0
                    txtFirstName.Text = String.Empty
                    txtLastName.Text = String.Empty
                    txtMiddleName.Text = String.Empty
                    m_FlagEdit = vEdit.eEdit
                    btnAdd.Text = "Add"
                End If
            End If
        End If
    End Sub

 

    Private Sub frmEditListOfAuthors_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListOfAddAuth = New List(Of Author)
        ListOfDeleteAuth = New List(Of Author)
        ListOfMergeAuth = New List(Of MergeAuthors)
        ListOfEditAuth = New List(Of Author)
        LstOfAuthors.Items.Clear()
        LstOfAuthors.DisplayMember = "FullName"
        LstOfAuthors.ValueMember = "AuthorID"
        For Each cl As Author In mdlMyLib.ListOfAuthors
            LstOfAuthors.Items.Add(cl)
        Next
        LstOfAuthors.SelectedIndex = -1
        btnAdd.Text = "Add"
        m_FlagEdit = vEdit.eAdd
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnApplay_Click(sender As Object, e As EventArgs) Handles btnApplay.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub LstOfAuthors_Click(sender As Object, e As EventArgs) Handles LstOfAuthors.Click
        If DirectCast(sender, ListBox).SelectedItems.Count = 1 Then
            txtLastName.Text = DirectCast(sender.SelectedItem, Author).LastName
            txtFirstName.Text = DirectCast(sender.SelectedItem, Author).FirstName
            txtMiddleName.Text = DirectCast(sender.SelectedItem, Author).MiddleName
            m_AuthID = sender.SelectedItem.AuthorID
            m_FlagEdit = vEdit.eEdit
            btnAdd.Text = "Edit"
        ElseIf DirectCast(sender, ListBox).SelectedItems.Count > 1 Then
            m_FlagEdit = vEdit.eMerge
            btnAdd.Text = "Merge"
        End If
        Dim ar() As Integer = (From el In DirectCast(sender, ListBox).SelectedItems
                               Select DirectCast(el.AuthorID, Integer)).ToArray
        LstOfBooks.DataSource = CurrentCatalog.GetListOfBooksByListOfAuthors(ar)
        LstOfBooks.Refresh()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        LstOfAuthors.SelectedItems.Clear()
        LstOfBooks.DataSource = {}
        m_AuthID = 0
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        m_FlagEdit = vEdit.eEdit
        btnAdd.Text = "Add"
    End Sub

    Private Sub btnClearTxt_Click(sender As Object, e As EventArgs) Handles btnClearTxt.Click
        m_AuthID = 0
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtMiddleName.Text = String.Empty
        m_FlagEdit = vEdit.eAdd
        btnAdd.Text = "Add"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If m_FlagEdit = vEdit.eAdd Then
            Dim cl As New Author
            cl.AuthorID = 0
            cl.LastName = txtLastName.Text
            cl.FirstName = txtFirstName.Text
            cl.MiddleName = txtMiddleName.Text
            ListOfAddAuth.Add(cl)
            LstOfAuthors.Items.Add(cl)
            m_AuthID = 0
            txtFirstName.Text = String.Empty
            txtLastName.Text = String.Empty
            txtMiddleName.Text = String.Empty
        ElseIf m_FlagEdit = vEdit.eEdit Then
            Dim cl As Author = New Author
            cl.AuthorID = m_AuthID
            cl.LastName = txtLastName.Text
            cl.FirstName = txtFirstName.Text
            cl.MiddleName = txtMiddleName.Text
            ListOfEditAuth.Add(cl)
            For i As Integer = 0 To LstOfAuthors.Items.Count - 1
                If cl.AuthorID = LstOfAuthors.Items(i).AuthorID Then
                    LstOfAuthors.Items(i) = cl
                    Exit For
                End If
            Next
            LstOfAuthors.SelectedItem = cl
            LstOfAuthors.Refresh()
        ElseIf m_FlagEdit = vEdit.eMerge Then
            Dim cl As MergeAuthors = New MergeAuthors
            Dim lIDs As List(Of Integer) = New List(Of Integer)
            For i As Integer = 0 To LstOfAuthors.SelectedItems.Count - 1
                If DirectCast(LstOfAuthors.SelectedItems(i), Author).AuthorID = m_AuthID Then
                    cl.Auth = LstOfAuthors.SelectedItems(i)
                Else
                    cl.Add(LstOfAuthors.SelectedItems(i))
                    lIDs.Add(DirectCast(LstOfAuthors.SelectedItems(i), Author).AuthorID)
                End If
            Next
            ListOfMergeAuth.Add(cl)
            For idx As Integer = LstOfAuthors.Items.Count - 1 To 0 Step -1
                If lIDs.Contains(DirectCast(LstOfAuthors.Items(idx), Author).AuthorID) Then
                    LstOfAuthors.Items.RemoveAt(idx)
                End If
            Next
        End If
    End Sub

    Private Sub LstOfAuthors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstOfAuthors.SelectedIndexChanged
        If DirectCast(sender, ListBox).SelectedItems.Count = 1 Then
            txtLastName.Text = DirectCast(sender.SelectedItem, Author).LastName
            txtFirstName.Text = DirectCast(sender.SelectedItem, Author).FirstName
            txtMiddleName.Text = DirectCast(sender.SelectedItem, Author).MiddleName
            m_AuthID = sender.SelectedItem.AuthorID
            m_FlagEdit = vEdit.eEdit
            btnAdd.Text = "Edit"
        ElseIf DirectCast(sender, ListBox).SelectedItems.Count > 1 Then
            m_FlagEdit = vEdit.eMerge
            btnAdd.Text = "Merge"
        End If
        Dim ar() As Integer = (From el In DirectCast(sender, ListBox).SelectedItems
                               Select DirectCast(el.AuthorID, Integer)).ToArray
        LstOfBooks.DataSource = CurrentCatalog.GetListOfBooksByListOfAuthors(ar)
        LstOfBooks.Refresh()

    End Sub
End Class