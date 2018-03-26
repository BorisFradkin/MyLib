Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Public Class frmMyLib

    Private Sub frmMyLib_Load(sender As Object, e As EventArgs) Handles Me.Load
        CurrentCatalog = Nothing
        CurrentCatalogInfo = Nothing
        reCreateMenuOpen()
        For idx = 0 To stAlphabet.Length - 1
            Dim Ln As New LinkLabel
            Ln.Font = New Font("Arial", 10, FontStyle.Bold)
            Ln.ForeColor = Color.Black
            Ln.LinkColor = Color.DarkBlue
            Ln.Text = stAlphabet.Substring(idx, 1)
            Ln.AutoSize = True
            Ln.Visible = True
            AddHandler Ln.Click, AddressOf Alphabet_Click
            pnlAlphabet.Controls.Add(Ln)
        Next
        Me.Text = "Не выбран каталог"
        TabSelect.SelectTab(0)
        pnlCard.Visible = False
        trvListBooks.Nodes.Clear()
        trvListBooks.Font = New Font("Arial", 10)
        lstAuthors.Font = New Font("Arial", 10)
    End Sub
    Private Sub SelectCatalog_Click(sender As Object, e As EventArgs)
        OpenCatalog(DirectCast(sender, ToolStripItem).Tag)
    End Sub
    Private Sub ShowBook(m_CardBook As clsCardBook)
        If m_CardBook IsNot Nothing Then
            pnlCard.Visible = True
            Dim Pic As String = m_CardBook.Cover
            If Pic.Length = 0 Then
                Using stream As New System.IO.MemoryStream
                    Dim btm As Bitmap = My.Resources.StdCover
                    btm.Save(stream, btm.RawFormat)
                    Pic = System.Convert.ToBase64String(stream.ToArray)
                End Using
            End If
            Dim xxx As New IO.MemoryStream(System.Convert.FromBase64String(Pic))
            Dim img As Image = Image.FromStream(xxx)
            picCover.Width = (img.Width / img.Height) * Me.picCover.Height
            picCover.Image = img
            lblTitle.Text = m_CardBook.Title
            lblSeries.Text = m_CardBook.Series()
            lblGenres.Text = ""
            For Each Gr In m_CardBook.Genres
                lblGenres.Text &= Gr.Trim & "; "
            Next

            Dim lstAuth As List(Of Author) = m_CardBook.Authors()
            pnlAuthors.Controls.Clear()
            For Each auth In lstAuth
                Dim linklbl As New LinkLabel()
                linklbl.LinkColor = Color.DarkBlue
                linklbl.ForeColor = Color.Black
                linklbl.Text = auth.ToShow
                linklbl.Visible = True
                linklbl.AutoSize = True
                linklbl.Tag = auth.AuthorID
                AddHandler linklbl.Click, AddressOf LinkAuth_Click
                pnlAuthors.Controls.Add(linklbl)
            Next
            txtAnnotation.Text = m_CardBook.Annotation()
            'txtAnnotation.Select()
            picCover.Focus()
        End If
    End Sub

    Private Sub LinkAuth_Click(sender As Object, e As EventArgs)
        Dim auth As Author = (From Au In ListOfAuthors
                              Where (Au.AuthorID = sender.tag)
                              Select Au).First
        lstAuthors.SelectedIndex = lstAuthors.Items.IndexOf(auth)
    End Sub

    Private Sub Alphabet_Click(sender As Object, e As EventArgs)
        If TabSelect.SelectedIndex = 0 Then
            If sender.text = "*" Then
                AuthSearch.Text = String.Empty
            Else
                AuthSearch.Text &= sender.text
            End If
        End If
    End Sub

    Private Sub mnuAddBooks_Click(sender As Object, e As EventArgs) Handles mnuAddBooks.Click
        Dim frm As frmAddBooks = New frmAddBooks
        frm.MyLib = Me
        Dim ret As DialogResult = frm.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            If CurrentCatalog IsNot Nothing AndAlso CurrentCatalog.NumAddBooks > 0 Then
                OpenCatalog(CurrentCatalogInfo)
            End If
        End If
    End Sub

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        mnuClearList.Enabled = False
        Dim frm As frmCreateCatalog = New frmCreateCatalog
        Dim ret As DialogResult = frm.ShowDialog()

        If ret = Windows.Forms.DialogResult.OK Then
            Dim catname As String = frm.CatalogName
            reCreateMenuOpen()
            For Each mn As ToolStripItem In mnuOpen.DropDownItems
                If mn.Text = catname Then
                    mn.PerformClick()
                    Exit For
                End If
            Next
        End If

    End Sub
    Private Sub reCreateMenuOpen()
        Catalog_Info.Clear()
        If Config.Catalogs IsNot Nothing Then
            For Each St In Config.Catalogs.Split(Chr(255))
                If St.Length > 0 Then
                    Dim ci As CatalogInfo = JsonConvert.DeserializeObject(Of CatalogInfo)(St)
                    Catalog_Info.Add(ci.Name.ToLower, ci)
                End If
            Next
            mnuOpen.DropDownItems.Clear()
            For Each ci As CatalogInfo In Catalog_Info.Values
                Dim mnu As ToolStripItem = mnuOpen.DropDownItems.Add(ci.Name)
                mnu.Tag = ci
                AddHandler mnu.Click, AddressOf SelectCatalog_Click
            Next
        End If
    End Sub

    Private Sub mnuClearList_Click(sender As Object, e As EventArgs) Handles mnuClearList.Click
        If Config.Catalogs IsNot Nothing Then
            For Each ci As CatalogInfo In Catalog_Info.Values
                If File.Exists(Path.Combine(Config.CatalogBase, ci.FileName)) Then
                    Try
                        File.Delete(Path.Combine(Config.CatalogBase, ci.FileName))
                    Catch ex As Exception
                        Write2Log(ex.Message, Path.Combine(Config.CatalogBase, ci.FileName))
                    End Try
                End If
            Next
            Config.Catalogs = String.Empty
            Config.Save()
            reCreateMenuOpen()
        End If
    End Sub

    Private Sub lstAuthors_Click(sender As Object, e As EventArgs) Handles lstAuthors.Click
        If lstAuthors.SelectedItem IsNot Nothing Then
            pnlCard.Visible = False
            CurrentCatalog.FillTreeBooks(0, lstAuthors.SelectedItem.AuthorID, trvListBooks, BookMenu)
        End If
    End Sub

    Public Sub OpenCatalog(Ci As CatalogInfo)
        mnuClearList.Enabled = False
        If CurrentCatalog IsNot Nothing Then
            CurrentCatalog.CloseCatalog()
        End If
        CurrentCatalog = New clsCatalog
        CurrentCatalogInfo = Ci
        CurrentCatalog.OpenCatalog(Path.Combine(Config.CatalogBase, CurrentCatalogInfo.FileName))
        FillListOfAuthors()
        lstAuthors.DataSource = ListOfAuthors
        lstAuthors.DisplayMember = "ToShow"
        lstAuthors.ValueMember = "AuthorID"

        cmbSearchAuthors.DataSource = ListOfAuthors
        cmbSearchAuthors.DisplayMember = "ToShow"
        cmbSearchAuthors.ValueMember = "AuthorID"
        cmbSearchAuthors.SelectedIndex = -1

        FillListOfSeries()
        lstSeries.DataSource = ListOfSeries
        lstSeries.DisplayMember = "SeriesTitle"
        lstSeries.ValueMember = "SeriesID"

        cmbSearchSeries.DataSource = ListOfSeries
        cmbSearchSeries.DisplayMember = "SeriesTitle"
        cmbSearchSeries.ValueMember = "SeriesID"
        cmbSearchSeries.SelectedIndex = -1

        Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
        cmbSearchGenres.DataSource = lst
        cmbSearchGenres.DisplayMember = "GenreAllias"
        cmbSearchGenres.ValueMember = "GenreCode"

        cmbSearchGenres.SelectedIndex = -1

        Me.Text = "Выбран каталог " & CurrentCatalogInfo.Name & StatisticCurrentCatalog()

        TabSelect.SelectTab(0)
        If lstAuthors.SelectedItem IsNot Nothing Then
            pnlCard.Visible = False
            CurrentCatalog.FillTreeBooks(0, lstAuthors.SelectedItem.AuthorID, trvListBooks, BookMenu)
        End If
    End Sub

    Private Sub trvListBooks_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles trvListBooks.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.Node.Tag IsNot Nothing Then
                ShowBook(e.Node.Tag)
            Else
                pnlCard.Visible = False
            End If
            trvListBooks.SelectedNode = e.Node 'DirectCast(sender, TreeView).GetNodeAt(e.X, e.Y)
        End If
    End Sub

    Private Sub AuthSearch_TextChanged(sender As Object, e As EventArgs) Handles AuthSearch.TextChanged
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            lstAuthors.DataSource = ListOfAuthors.Where(Function(x) x.LastName.ToUpper.StartsWith(AuthSearch.Text)).ToList
        Else
            lstAuthors.DataSource = ListOfAuthors
        End If
        lstAuthors.DisplayMember = "ToShow"
        lstAuthors.ValueMember = "AuthorID"

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        If CurrentCatalog IsNot Nothing Then
            CurrentCatalog.CloseCatalog()
        End If
        Me.Close()
    End Sub

    Private Sub frmMyLib_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If CurrentCatalog IsNot Nothing Then
            CurrentCatalog.CloseCatalog()
        End If

    End Sub

    Private Sub mnuDeleteCatalog_Click(sender As Object, e As EventArgs) Handles mnuDeleteCatalog.Click
        Dim ci As CatalogInfo = Nothing
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            If MsgBox("Удалить текущий каталог?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                CurrentCatalog.CloseCatalog()
                Dim arCat As List(Of CatalogInfo) = (From El As String In Config.Catalogs.Split(Chr(255))
                                                     Where El.Length > 0
                                                     Select JsonConvert.DeserializeObject(Of CatalogInfo)(El)).ToList
                For Idx = 0 To arCat.Count - 1
                    ci = arCat(Idx)
                    If ci.Name = CurrentCatalogInfo.Name Then
                        arCat.RemoveAt(Idx)
                        Exit For
                    End If
                Next
                If ci IsNot Nothing Then
                    Try
                        File.Delete(Path.Combine(Config.CatalogBase, ci.FileName))
                    Catch ex As Exception
                        Write2Log(ex.Message, Path.Combine(Config.CatalogBase, ci.FileName))
                    End Try
                End If
                Dim st As String = String.Empty
                For Each el In arCat
                    Dim jsonobj = JToken.FromObject(el)
                    st &= jsonobj.ToString & Chr(255)
                Next
                If st.EndsWith(Chr(255)) Then
                    st = st.Substring(0, st.Length - 1)
                End If
                Config.Catalogs = st
                Config.Save()
                reCreateMenuOpen()
                ClearShow()
            End If
        End If
    End Sub
    Private Sub ClearShow()
        mnuClearList.Enabled = True
        CurrentCatalog = Nothing
        CurrentCatalogInfo = Nothing
        Me.Text = "Не выбран каталог"
        lstAuthors.DataSource = Nothing
        lstAuthors.Items.Clear()
        lstSeries.DataSource = Nothing
        lstSeries.Items.Clear()
        TabSelect.SelectTab(0)
        trvGenre.Nodes.Clear()
        pnlCard.Visible = False
        trvListBooks.Nodes.Clear()
    End Sub

    Private Sub mnuCatalogInfo_Click(sender As Object, e As EventArgs) Handles mnuCatalogInfo.Click
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            Dim _frm As frmCatalogInfo = New frmCatalogInfo
            If _frm.ShowDialog() = DialogResult.OK Then
                reCreateMenuOpen()
                Me.Text = "Выбран каталог " & CurrentCatalogInfo.Name & StatisticCurrentCatalog()
            End If
        End If
    End Sub

    Private Sub TabSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabSelect.SelectedIndexChanged
        trvListBooks.Nodes.Clear()
        Select Case DirectCast(sender, TabControl).SelectedIndex
            Case 0
                If lstAuthors.SelectedItem IsNot Nothing Then
                    pnlCard.Visible = False
                    CurrentCatalog.FillTreeBooks(0, lstAuthors.SelectedItem.AuthorID, trvListBooks, BookMenu)
                End If
            Case 1
                If lstSeries.SelectedItem IsNot Nothing Then
                    pnlCard.Visible = False
                    CurrentCatalog.FillTreeBooks(1, lstSeries.SelectedItem.SeriesID, trvListBooks, BookMenu)
                End If
            Case 2
                If trvGenre.SelectedNode IsNot Nothing Then
                    If trvGenre.SelectedNode.Tag.ToString.Length > 0 Then
                        pnlCard.Visible = False
                        CurrentCatalog.FillTreeBooks(2, trvGenre.SelectedNode.Tag.ToString, trvListBooks, BookMenu)
                    End If
                End If
            Case 3
                If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
                    rbDuplicate.Visible = True
                    rbSearch.Visible = True
                    If rbDuplicate.Checked Then
                        pnlSearch.Visible = False
                        pnlCard.Visible = False
                        CurrentCatalog.FillTreeBooks(4, "", trvListBooks, BookMenu)
                    ElseIf rbSearch.Checked Then
                        pnlSearch.Visible = True
                    End If
                Else
                    rbDuplicate.Visible = False
                    rbSearch.Visible = False
                    pnlSearch.Visible = False
                End If
        End Select
    End Sub

    Private Sub lstSeries_Click(sender As Object, e As EventArgs) Handles lstSeries.Click
        If lstSeries.SelectedItem IsNot Nothing Then
            pnlCard.Visible = False
            CurrentCatalog.FillTreeBooks(1, lstSeries.SelectedItem.SeriesID, trvListBooks, BookMenu)
        End If

    End Sub

    Private Sub trvGenre_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles trvGenre.NodeMouseClick
        If e.Node.Tag.ToString.Length > 0 Then
            pnlCard.Visible = False
            CurrentCatalog.FillTreeBooks(2, e.Node.Tag.ToString, trvListBooks, BookMenu)
        End If
    End Sub

    Private Sub rbDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles rbDuplicate.CheckedChanged
        trvListBooks.Nodes.Clear()
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            If rbDuplicate.Checked Then
                pnlSearch.Visible = False
                pnlCard.Visible = False
                CurrentCatalog.FillTreeBooks(4, "", trvListBooks, BookMenu)
            End If
        End If
    End Sub

    Private Sub rbSearch_CheckedChanged(sender As Object, e As EventArgs) Handles rbSearch.CheckedChanged
        trvListBooks.Nodes.Clear()
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            If rbSearch.Checked Then
                pnlSearch.Visible = True
                pnlCard.Visible = False
            End If
        End If
    End Sub


    Private Sub cntxBookInfo_Click(sender As Object, e As EventArgs) Handles cntxBookInfo.Click
        Dim frm As frmBookInfo = New frmBookInfo

        frm.Book = trvListBooks.SelectedNode.Tag
        frm.ShowDialog()
    End Sub

    Private Sub cntxDelete_Click(sender As Object, e As EventArgs) Handles cntxDelete.Click
        Dim frm As frmDeleteBook = New frmDeleteBook
        Dim Cl As DeletingBooks = Nothing
        Dim LstChecked As List(Of DeletingBooks) = New List(Of DeletingBooks)
        If (Not trvListBooks.SelectedNode.Checked) AndAlso (trvListBooks.SelectedNode.Tag IsNot Nothing) Then
            Cl = New DeletingBooks(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).Title, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).BookID)
            Cl.FilePath = Path.Combine(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FolderName, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FileName)
            LstChecked.Add(Cl)
        End If
        For Each nd As TreeNode In trvListBooks.Nodes
            If nd.Tag Is Nothing Then
                If nd.Nodes.Count > 0 Then
                    For Each ndd As TreeNode In nd.Nodes
                        If ndd.Checked And ndd.Tag IsNot Nothing Then
                            Cl = New DeletingBooks(DirectCast(ndd.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(ndd.Tag, clsCardBook).Title, DirectCast(ndd.Tag, clsCardBook).BookID)
                            Cl.FilePath = Path.Combine(DirectCast(ndd.Tag, clsCardBook).FolderName, DirectCast(ndd.Tag, clsCardBook).FileName)
                            LstChecked.Add(Cl)
                        End If
                    Next
                End If
            Else
                If nd.Checked Then
                    Cl = New DeletingBooks(DirectCast(nd.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(nd.Tag, clsCardBook).Title, DirectCast(nd.Tag, clsCardBook).BookID)
                    Cl.FilePath = Path.Combine(DirectCast(nd.Tag, clsCardBook).FolderName, DirectCast(nd.Tag, clsCardBook).FileName)
                    LstChecked.Add(Cl)
                End If
            End If
        Next
        frm.Books = LstChecked
        'frm.Book = trvListBooks.SelectedNode.Tag
        If frm.ShowDialog() = DialogResult.OK Then
            CurrentCatalog.RefreshTreeBooks(trvListBooks, BookMenu)
        End If
    End Sub

    Private Sub cntxEditBookCard_Click(sender As Object, e As EventArgs) Handles cntxEditBookCard.Click
        Dim frm As frmEditBookInfo = New frmEditBookInfo
        frm.Book = trvListBooks.SelectedNode.Tag
        If frm.ShowDialog() = DialogResult.OK Then
            CurrentCatalog.RefreshTreeBooks(trvListBooks, BookMenu)
            'trvListBooks.SelectedNode.Tag = frm.Book
            'ShowBook(trvListBooks.SelectedNode.Tag)
        End If

    End Sub

    Private Sub cntxShowAsXML_Click(sender As Object, e As EventArgs)
        Dim startInfo As New ProcessStartInfo
        startInfo.FileName = "IEXPLORE.EXE"
        startInfo.Arguments = Path.Combine(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FolderName, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FileName)
        Process.Start(startInfo)
    End Sub

    Private Sub mnuAuthor_Click(sender As Object, e As EventArgs) Handles mnuEditAuthor.Click
        If CurrentCatalog IsNot Nothing Then
            Dim frm As frmEditListOfAuthors = New frmEditListOfAuthors
            If frm.ShowDialog <> DialogResult.Cancel Then
                editAuthorsList()
                lstAuthors.DataSource = Nothing
                lstAuthors.DataSource = ListOfAuthors
                lstAuthors.DisplayMember = "ToShow"
                lstAuthors.ValueMember = "AuthorID"
                cmbSearchAuthors.DataSource = Nothing
                cmbSearchAuthors.DataSource = ListOfAuthors
                cmbSearchAuthors.DisplayMember = "ToShow"
                cmbSearchAuthors.ValueMember = "AuthorID"
                cmbSearchAuthors.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub mnuDetach_Click(sender As Object, e As EventArgs) Handles mnuDetach.Click
        Dim ci As CatalogInfo = Nothing
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            CurrentCatalog.CloseCatalog()
            Dim arCat As List(Of CatalogInfo) = (From El As String In Config.Catalogs.Split(Chr(255))
                                                 Where El.Length > 0
                                                 Select JsonConvert.DeserializeObject(Of CatalogInfo)(El)).ToList
            For Idx = 0 To arCat.Count - 1
                ci = arCat(Idx)
                If ci.Name = CurrentCatalogInfo.Name Then
                    arCat.RemoveAt(Idx)
                    Exit For
                End If
            Next
            Dim st As String = String.Empty
            For Each el In arCat
                Dim jsonobj = JToken.FromObject(el)
                st &= jsonobj.ToString & Chr(255)
            Next
            If st.EndsWith(Chr(255)) Then
                st = st.Substring(0, st.Length - 1)
            End If
            Config.Catalogs = st
            Config.Save()
            reCreateMenuOpen()
            ClearShow()
        End If

    End Sub

    Private Sub mnuAttach_Click(sender As Object, e As EventArgs) Handles mnuAttach.Click
        mnuClearList.Enabled = False
        Dim frm As frmAttach = New frmAttach
        Dim ret As DialogResult = frm.ShowDialog()

        If ret = Windows.Forms.DialogResult.OK Then
            Dim catname As String = frm.CatalogName
            reCreateMenuOpen()
            For Each mn As ToolStripItem In mnuOpen.DropDownItems
                If mn.Text = catname Then
                    mn.PerformClick()
                    Exit For
                End If
            Next
        End If


    End Sub

    Private Sub mnuAddBook_Click(sender As Object, e As EventArgs) Handles mnuAddBook.Click
        Dim frm As frmAddSingleBook = New frmAddSingleBook
        frm.MyLib = Me
        Dim ret As DialogResult = frm.ShowDialog()
        If ret = Windows.Forms.DialogResult.OK Then
            If CurrentCatalog IsNot Nothing Then 'AndAlso CurrentCatalog.NumAddBooks > 0 Then
                OpenCatalog(CurrentCatalogInfo)
            End If
        End If

    End Sub


    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        Dim frm As frmSettings = New frmSettings
        frm.ShowDialog()
        If CurrentCatalog IsNot Nothing Then
            CurrentCatalog.RefreshTreeBooks(trvListBooks, BookMenu)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim lst As List(Of clsCardBook) = CurrentCatalog.GetListSearch(cmbSearchGenres.SelectedValue, cmbSearchSeries.SelectedValue, cmbSearchAuthors.SelectedValue, txtSearchTitle.Text, txtSearchAnnotation.Text, txtSearchKeyWords.Text)
        CurrentCatalog.FillTreeBooks(5, lst, trvListBooks, BookMenu)
    End Sub

    Private Sub mnuSynchronizationCatalog_Click(sender As Object, e As EventArgs) Handles mnuSynchronizationCatalog.Click
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            Dim AddBook As Integer = 0
            Dim DelBook As Integer = 0
            Me.Enabled = False
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Application.DoEvents()
            CurrentCatalog.RefreshCatalog(CurrentCatalogInfo, AddBook, DelBook, lblStatusRefreshCatalog)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Me.Enabled = True
            Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
            cmbSearchGenres.DataSource = lst
            cmbSearchGenres.DisplayMember = "GenreAllias"
            cmbSearchGenres.ValueMember = "GenreCode"
            cmbSearchGenres.SelectedIndex = -1
            MsgBox("Каталог """ & CurrentCatalogInfo.Name & """ обновлен." & vbCrLf & "добавлено книг: " & AddBook.ToString & vbCrLf & "удалено книг: " & DelBook.ToString)
            Write2Log("RefreshCatalog """ & CurrentCatalogInfo.Name & """   --Added Books=" & AddBook.ToString & "   --Deleted Books=" & DelBook.ToString, "")
            lblStatusRefreshCatalog.Text = ""
        End If

    End Sub
    Private Sub trvListBooks_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvListBooks.AfterCheck
        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Checked Then
                e.Node.Expand()
            End If
            For Each nd As TreeNode In e.Node.Nodes
                nd.Checked = e.Node.Checked
            Next
        End If
    End Sub

    Private Sub trvListBooks_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvListBooks.AfterSelect
        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Tag IsNot Nothing Then
                ShowBook(e.Node.Tag)
            Else
                pnlCard.Visible = False
            End If
        End If
    End Sub

    Private Sub cntxAddToListToRead_Click(sender As Object, e As EventArgs) Handles cntxAddToListToRead.Click
        Dim Cl As DeletingBooks = Nothing
        Dim LstChecked As List(Of DeletingBooks) = New List(Of DeletingBooks)
        If (Not trvListBooks.SelectedNode.Checked) AndAlso (trvListBooks.SelectedNode.Tag IsNot Nothing) Then
            Cl = New DeletingBooks(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).Title, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).BookID)
            Cl.FilePath = Path.Combine(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FolderName, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FileName)
            LstChecked.Add(Cl)
        End If
        For Each nd As TreeNode In trvListBooks.Nodes
            If nd.Tag Is Nothing Then
                If nd.Nodes.Count > 0 Then
                    For Each ndd As TreeNode In nd.Nodes
                        If ndd.Checked And ndd.Tag IsNot Nothing Then
                            Cl = New DeletingBooks(DirectCast(ndd.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(ndd.Tag, clsCardBook).Title, DirectCast(ndd.Tag, clsCardBook).BookID)
                            Cl.FilePath = Path.Combine(DirectCast(ndd.Tag, clsCardBook).FolderName, DirectCast(ndd.Tag, clsCardBook).FileName)
                            LstChecked.Add(Cl)
                        End If
                    Next
                End If
            Else
                If nd.Checked Then
                    Cl = New DeletingBooks(DirectCast(nd.Tag, clsCardBook).Authors(0).ToShow & ": " & DirectCast(nd.Tag, clsCardBook).Title, DirectCast(nd.Tag, clsCardBook).BookID)
                    Cl.FilePath = Path.Combine(DirectCast(nd.Tag, clsCardBook).FolderName, DirectCast(nd.Tag, clsCardBook).FileName)
                    LstChecked.Add(Cl)
                End If
            End If
        Next
        Dim DirOut As String = String.Empty
        If Config.List2Read = "" Then
            DirOut = Path.Combine(Config.CatalogBase, "ToRead" & Now.ToString("yyyyMMdd"))
        Else
            If Not Directory.Exists(Config.List2Read) Then
                Directory.CreateDirectory(Config.List2Read)
            End If

            DirOut = Path.Combine(Config.List2Read, "ToRead" & Now.ToString("yyyyMMdd"))
        End If
        If Not Directory.Exists(DirOut) Then
            Directory.CreateDirectory(DirOut)
        End If
        For Each di As DeletingBooks In LstChecked
            Try
                Dim Fi As FileInfo = New FileInfo(di.FilePath)
                File.Copy(di.FilePath, Path.Combine(DirOut, Fi.Name), True)
            Catch ex As Exception
                Write2Log(ex.Message, di.FilePath)
            End Try
        Next
        If LstChecked.Count > 0 Then
            Dim Kn As String = ""
            If LstChecked.Count >= 10 And LstChecked.Count <= 19 Then
                Kn = " книг"
            Else
                Select Case LstChecked.Count Mod 10
                    Case 1
                        Kn = " книга"
                    Case 2, 3, 4
                        Kn = " книги"
                    Case Else
                        Kn = " книг"
                End Select
            End If
            MsgBox(LstChecked.Count.ToString & Kn & " скопировано в директорию " & DirOut)
        End If
    End Sub
    Private Sub Write2Log(msg As String, Fil As String)
        Dim st As String = Now.ToString & If(Fil.Length > 0, " File=" & Fil & " ", " ") & msg
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub

    Private Sub mnuEditCatalogInfo_Click(sender As Object, e As EventArgs) Handles mnuEditCatalogInfo.Click
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            Dim _frm As frmCatalogInfo = New frmCatalogInfo
            If _frm.ShowDialog() = DialogResult.OK Then
                reCreateMenuOpen()
                Me.Text = "Выбран каталог " & CurrentCatalogInfo.Name & StatisticCurrentCatalog()
            End If
        End If
    End Sub

    Private Sub mnuEditSerie_Click(sender As Object, e As EventArgs) Handles mnuEditSerie.Click
        If CurrentCatalog IsNot Nothing Then
            Dim frm As frmEditSeries = New frmEditSeries
            If frm.ShowDialog <> DialogResult.Cancel Then
                editSeries()
                lstSeries.DataSource = Nothing
                lstSeries.DataSource = ListOfSeries
                lstSeries.DisplayMember = "SeriesTitle"
                lstSeries.ValueMember = "SeriesID"
                cmbSearchSeries.DataSource = Nothing
                cmbSearchSeries.DataSource = ListOfSeries
                cmbSearchSeries.DisplayMember = "SeriesTitle"
                cmbSearchSeries.ValueMember = "SeriesID"
                cmbSearchSeries.SelectedIndex = -1
            End If
        End If

    End Sub

    Private Sub mnuEditGanre_Click(sender As Object, e As EventArgs) Handles mnuEditGanre.Click

        If CurrentCatalog IsNot Nothing Then
            Dim frm As frmEditGenres = New frmEditGenres
            If frm.ShowDialog <> DialogResult.Cancel Then
                editGenres()
                cmbSearchGenres.DataSource = Nothing
                Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
                cmbSearchGenres.DataSource = lst
                cmbSearchGenres.DisplayMember = "GenreAllias"
                cmbSearchGenres.ValueMember = "GenreCode"

                cmbSearchGenres.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles cntxOpen.Click
        If trvListBooks.SelectedNode.Tag IsNot Nothing Then
            If Config.Reader.Trim.Length > 0 Then
                Process.Start(Config.Reader, Path.Combine(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FolderName, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FileName))
            Else
                Process.Start(Path.Combine(DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FolderName, DirectCast(trvListBooks.SelectedNode.Tag, clsCardBook).FileName))
            End If
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub frmMyLib_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Debug.Print("resize:" & Me.Width & "," & Me.Height)
    End Sub

    Private Sub frmMyLib_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        'Debug.Print("resize Begin:" & Me.Width & "," & Me.Height)
    End Sub

    Private Sub frmMyLib_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If Me.Width < 750 Then Me.Width = 750
        If Me.Height < 550 Then Me.Height = 550
    End Sub
    Private Sub mnuRefreshGenres_Click(sender As Object, e As EventArgs) Handles mnuRefreshGenres.Click
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()
        If CurrentCatalog IsNot Nothing Then
            CurrentCatalog.RefreshGenres(lblStatusRefreshCatalog)
        End If
        Dim lst As List(Of GenreInfo) = CurrentCatalog.GetTreeGenries(trvGenre)
        cmbSearchGenres.DataSource = lst
        cmbSearchGenres.DisplayMember = "GenreAllias"
        cmbSearchGenres.ValueMember = "GenreCode"
        cmbSearchGenres.SelectedIndex = -1
        Me.Enabled = True
        Me.Cursor = Cursors.Arrow
        Application.DoEvents()
    End Sub
    Private Sub rbNonDuplicate_CheckedChanged(sender As Object, e As EventArgs) Handles rbNonDuplicate.CheckedChanged
        trvListBooks.Nodes.Clear()
        If (CurrentCatalog IsNot Nothing) AndAlso (CurrentCatalogInfo IsNot Nothing) Then
            If rbNonDuplicate.Checked Then
                pnlSearch.Visible = False
                pnlCard.Visible = False
                CurrentCatalog.FillTreeBooks(6, "", trvListBooks, BookMenu)
            End If
        End If
    End Sub
    Private Sub cntxSelectAll_Click(sender As Object, e As EventArgs) Handles cntxSelectAll.Click
        For Each trv As TreeNode In trvListBooks.Nodes
            CheckUncheckTreenode(trv, True)
        Next
    End Sub

    Private Sub cntxUnselectAll_Click(sender As Object, e As EventArgs) Handles cntxUnselectAll.Click
        For Each trv As TreeNode In trvListBooks.Nodes
            CheckUncheckTreenode(trv, False)
        Next

    End Sub
    Private Sub CheckUncheckTreenode(trv As TreeNode, chk As Boolean)
        If trv.Nodes.Count > 0 Then
            If chk Then
                trv.Expand()
            Else
                trv.Collapse()
            End If
            For Each tr As TreeNode In trv.Nodes
                CheckUncheckTreenode(tr, chk)
            Next
        Else
            trv.Checked = chk
        End If
    End Sub
    Private Function StatisticCurrentCatalog() As String
        Return " (Книг: " & CurrentCatalog.NumBooks.ToString & ", Авторов: " & CurrentCatalog.NumAuthors.ToString & ", Серий: " & CurrentCatalog.NumSeries.ToString & ")"
    End Function

End Class