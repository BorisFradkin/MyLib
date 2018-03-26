<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMyLib
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3", New System.Windows.Forms.TreeNode() {TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {TreeNode8})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMyLib))
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabSelect = New System.Windows.Forms.TabControl()
        Me.Authors = New System.Windows.Forms.TabPage()
        Me.AuthSearch = New System.Windows.Forms.TextBox()
        Me.lstAuthors = New System.Windows.Forms.ListBox()
        Me.Series = New System.Windows.Forms.TabPage()
        Me.lstSeries = New System.Windows.Forms.ListBox()
        Me.Genres = New System.Windows.Forms.TabPage()
        Me.trvGenre = New System.Windows.Forms.TreeView()
        Me.Search = New System.Windows.Forms.TabPage()
        Me.rbNonDuplicate = New System.Windows.Forms.RadioButton()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearchAnnotation = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSearchKeyWords = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cmbSearchGenres = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSearchSeries = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSearchAuthors = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSearchTitle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbSearch = New System.Windows.Forms.RadioButton()
        Me.rbDuplicate = New System.Windows.Forms.RadioButton()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.trvListBooks = New System.Windows.Forms.TreeView()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.pnlAuthors = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblGenres = New System.Windows.Forms.Label()
        Me.lblSeries = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtAnnotation = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picCover = New System.Windows.Forms.PictureBox()
        Me.pnlAlphabet = New System.Windows.Forms.FlowLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.mnuCatalog = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAddBook = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAddBooks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAttach = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDetach = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSynchronizationCatalog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCatalogInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDeleteCatalog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCatalogInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditAuthor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditSerie = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditGanre = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClearList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuRefreshGenres = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyLibMenu = New System.Windows.Forms.MenuStrip()
        Me.StrStatus = New System.Windows.Forms.StatusStrip()
        Me.lblStatusRefreshCatalog = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BookMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntxSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cntxUnselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxBookInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxRefreshBookInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxEditBookCard = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.cntxAddToListToRead = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TabSelect.SuspendLayout()
        Me.Authors.SuspendLayout()
        Me.Series.SuspendLayout()
        Me.Genres.SuspendLayout()
        Me.Search.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.MyLibMenu.SuspendLayout()
        Me.StrStatus.SuspendLayout()
        Me.BookMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TabSelect)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1184, 609)
        Me.SplitContainer2.SplitterDistance = 316
        Me.SplitContainer2.TabIndex = 0
        '
        'TabSelect
        '
        Me.TabSelect.Controls.Add(Me.Authors)
        Me.TabSelect.Controls.Add(Me.Series)
        Me.TabSelect.Controls.Add(Me.Genres)
        Me.TabSelect.Controls.Add(Me.Search)
        Me.TabSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabSelect.Location = New System.Drawing.Point(0, 0)
        Me.TabSelect.Name = "TabSelect"
        Me.TabSelect.SelectedIndex = 0
        Me.TabSelect.Size = New System.Drawing.Size(314, 607)
        Me.TabSelect.TabIndex = 0
        '
        'Authors
        '
        Me.Authors.Controls.Add(Me.AuthSearch)
        Me.Authors.Controls.Add(Me.lstAuthors)
        Me.Authors.Location = New System.Drawing.Point(4, 22)
        Me.Authors.Name = "Authors"
        Me.Authors.Padding = New System.Windows.Forms.Padding(3)
        Me.Authors.Size = New System.Drawing.Size(306, 581)
        Me.Authors.TabIndex = 0
        Me.Authors.Text = "Авторы"
        Me.Authors.UseVisualStyleBackColor = True
        '
        'AuthSearch
        '
        Me.AuthSearch.Location = New System.Drawing.Point(66, 141)
        Me.AuthSearch.Name = "AuthSearch"
        Me.AuthSearch.Size = New System.Drawing.Size(172, 20)
        Me.AuthSearch.TabIndex = 1
        Me.AuthSearch.Visible = False
        '
        'lstAuthors
        '
        Me.lstAuthors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAuthors.FormattingEnabled = True
        Me.lstAuthors.Location = New System.Drawing.Point(3, 3)
        Me.lstAuthors.Name = "lstAuthors"
        Me.lstAuthors.Size = New System.Drawing.Size(300, 575)
        Me.lstAuthors.TabIndex = 0
        '
        'Series
        '
        Me.Series.Controls.Add(Me.lstSeries)
        Me.Series.Location = New System.Drawing.Point(4, 22)
        Me.Series.Name = "Series"
        Me.Series.Size = New System.Drawing.Size(306, 581)
        Me.Series.TabIndex = 2
        Me.Series.Text = "Серии"
        Me.Series.UseVisualStyleBackColor = True
        '
        'lstSeries
        '
        Me.lstSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstSeries.FormattingEnabled = True
        Me.lstSeries.Location = New System.Drawing.Point(0, 0)
        Me.lstSeries.Name = "lstSeries"
        Me.lstSeries.Size = New System.Drawing.Size(306, 581)
        Me.lstSeries.TabIndex = 0
        '
        'Genres
        '
        Me.Genres.Controls.Add(Me.trvGenre)
        Me.Genres.Location = New System.Drawing.Point(4, 22)
        Me.Genres.Name = "Genres"
        Me.Genres.Padding = New System.Windows.Forms.Padding(3)
        Me.Genres.Size = New System.Drawing.Size(306, 581)
        Me.Genres.TabIndex = 1
        Me.Genres.Text = "Жанры"
        Me.Genres.UseVisualStyleBackColor = True
        '
        'trvGenre
        '
        Me.trvGenre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvGenre.Location = New System.Drawing.Point(3, 3)
        Me.trvGenre.Name = "trvGenre"
        TreeNode1.Name = "Node1"
        TreeNode1.Text = "Node1"
        TreeNode2.Name = "Node2"
        TreeNode2.Text = "Node2"
        TreeNode3.Name = "Node0"
        TreeNode3.Text = "Node0"
        TreeNode4.Name = "Node4"
        TreeNode4.Text = "Node4"
        TreeNode5.Name = "Node3"
        TreeNode5.Text = "Node3"
        Me.trvGenre.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode5})
        Me.trvGenre.Size = New System.Drawing.Size(300, 575)
        Me.trvGenre.TabIndex = 0
        '
        'Search
        '
        Me.Search.Controls.Add(Me.rbNonDuplicate)
        Me.Search.Controls.Add(Me.pnlSearch)
        Me.Search.Controls.Add(Me.rbSearch)
        Me.Search.Controls.Add(Me.rbDuplicate)
        Me.Search.Location = New System.Drawing.Point(4, 22)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(306, 581)
        Me.Search.TabIndex = 3
        Me.Search.Text = "Поиск"
        Me.Search.UseVisualStyleBackColor = True
        '
        'rbNonDuplicate
        '
        Me.rbNonDuplicate.AutoSize = True
        Me.rbNonDuplicate.Location = New System.Drawing.Point(127, 25)
        Me.rbNonDuplicate.Name = "rbNonDuplicate"
        Me.rbNonDuplicate.Size = New System.Drawing.Size(93, 17)
        Me.rbNonDuplicate.TabIndex = 3
        Me.rbNonDuplicate.Text = "Non Duplicate"
        Me.rbNonDuplicate.UseVisualStyleBackColor = True
        '
        'pnlSearch
        '
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSearch.Controls.Add(Me.txtSearchAnnotation)
        Me.pnlSearch.Controls.Add(Me.Label11)
        Me.pnlSearch.Controls.Add(Me.txtSearchKeyWords)
        Me.pnlSearch.Controls.Add(Me.Label9)
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.cmbSearchGenres)
        Me.pnlSearch.Controls.Add(Me.Label8)
        Me.pnlSearch.Controls.Add(Me.cmbSearchSeries)
        Me.pnlSearch.Controls.Add(Me.Label7)
        Me.pnlSearch.Controls.Add(Me.cmbSearchAuthors)
        Me.pnlSearch.Controls.Add(Me.Label6)
        Me.pnlSearch.Controls.Add(Me.txtSearchTitle)
        Me.pnlSearch.Controls.Add(Me.Label5)
        Me.pnlSearch.Location = New System.Drawing.Point(17, 83)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(271, 378)
        Me.pnlSearch.TabIndex = 2
        '
        'txtSearchAnnotation
        '
        Me.txtSearchAnnotation.Location = New System.Drawing.Point(15, 241)
        Me.txtSearchAnnotation.Name = "txtSearchAnnotation"
        Me.txtSearchAnnotation.Size = New System.Drawing.Size(245, 20)
        Me.txtSearchAnnotation.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 225)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Аннотация"
        '
        'txtSearchKeyWords
        '
        Me.txtSearchKeyWords.Location = New System.Drawing.Point(15, 289)
        Me.txtSearchKeyWords.Name = "txtSearchKeyWords"
        Me.txtSearchKeyWords.Size = New System.Drawing.Size(245, 20)
        Me.txtSearchKeyWords.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 273)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Ключевые слова"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(150, 337)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(108, 25)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearchGenres
        '
        Me.cmbSearchGenres.FormattingEnabled = True
        Me.cmbSearchGenres.Location = New System.Drawing.Point(15, 30)
        Me.cmbSearchGenres.Name = "cmbSearchGenres"
        Me.cmbSearchGenres.Size = New System.Drawing.Size(245, 21)
        Me.cmbSearchGenres.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Жанр"
        '
        'cmbSearchSeries
        '
        Me.cmbSearchSeries.FormattingEnabled = True
        Me.cmbSearchSeries.Location = New System.Drawing.Point(15, 83)
        Me.cmbSearchSeries.Name = "cmbSearchSeries"
        Me.cmbSearchSeries.Size = New System.Drawing.Size(245, 21)
        Me.cmbSearchSeries.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Серия"
        '
        'cmbSearchAuthors
        '
        Me.cmbSearchAuthors.FormattingEnabled = True
        Me.cmbSearchAuthors.Location = New System.Drawing.Point(15, 138)
        Me.cmbSearchAuthors.Name = "cmbSearchAuthors"
        Me.cmbSearchAuthors.Size = New System.Drawing.Size(245, 21)
        Me.cmbSearchAuthors.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Автор"
        '
        'txtSearchTitle
        '
        Me.txtSearchTitle.Location = New System.Drawing.Point(15, 190)
        Me.txtSearchTitle.Name = "txtSearchTitle"
        Me.txtSearchTitle.Size = New System.Drawing.Size(245, 20)
        Me.txtSearchTitle.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Название"
        '
        'rbSearch
        '
        Me.rbSearch.AutoSize = True
        Me.rbSearch.Checked = True
        Me.rbSearch.Location = New System.Drawing.Point(17, 48)
        Me.rbSearch.Name = "rbSearch"
        Me.rbSearch.Size = New System.Drawing.Size(59, 17)
        Me.rbSearch.TabIndex = 1
        Me.rbSearch.TabStop = True
        Me.rbSearch.Text = "Search"
        Me.rbSearch.UseVisualStyleBackColor = True
        '
        'rbDuplicate
        '
        Me.rbDuplicate.AutoSize = True
        Me.rbDuplicate.Location = New System.Drawing.Point(17, 25)
        Me.rbDuplicate.Name = "rbDuplicate"
        Me.rbDuplicate.Size = New System.Drawing.Size(70, 17)
        Me.rbDuplicate.TabIndex = 0
        Me.rbDuplicate.Text = "Duplicate"
        Me.rbDuplicate.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.trvListBooks)
        Me.SplitContainer3.Panel1MinSize = 100
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.pnlCard)
        Me.SplitContainer3.Panel2MinSize = 272
        Me.SplitContainer3.Size = New System.Drawing.Size(864, 609)
        Me.SplitContainer3.SplitterDistance = 324
        Me.SplitContainer3.TabIndex = 0
        '
        'trvListBooks
        '
        Me.trvListBooks.CheckBoxes = True
        Me.trvListBooks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvListBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.trvListBooks.FullRowSelect = True
        Me.trvListBooks.Location = New System.Drawing.Point(0, 0)
        Me.trvListBooks.Name = "trvListBooks"
        TreeNode6.Name = "Node2"
        TreeNode6.Text = "Node2"
        TreeNode7.Name = "Node0"
        TreeNode7.Text = "Node0"
        TreeNode8.Name = "Node3"
        TreeNode8.Text = "Node3"
        TreeNode9.Name = "Node1"
        TreeNode9.Text = "Node1"
        Me.trvListBooks.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode7, TreeNode9})
        Me.trvListBooks.Size = New System.Drawing.Size(862, 322)
        Me.trvListBooks.TabIndex = 0
        '
        'pnlCard
        '
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCard.Controls.Add(Me.pnlAuthors)
        Me.pnlCard.Controls.Add(Me.lblGenres)
        Me.pnlCard.Controls.Add(Me.lblSeries)
        Me.pnlCard.Controls.Add(Me.lblTitle)
        Me.pnlCard.Controls.Add(Me.GroupBox1)
        Me.pnlCard.Controls.Add(Me.Label4)
        Me.pnlCard.Controls.Add(Me.Label3)
        Me.pnlCard.Controls.Add(Me.Label2)
        Me.pnlCard.Controls.Add(Me.Label1)
        Me.pnlCard.Controls.Add(Me.picCover)
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Location = New System.Drawing.Point(0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(862, 279)
        Me.pnlCard.TabIndex = 1
        '
        'pnlAuthors
        '
        Me.pnlAuthors.Location = New System.Drawing.Point(298, 42)
        Me.pnlAuthors.Name = "pnlAuthors"
        Me.pnlAuthors.Size = New System.Drawing.Size(460, 41)
        Me.pnlAuthors.TabIndex = 11
        '
        'lblGenres
        '
        Me.lblGenres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblGenres.Location = New System.Drawing.Point(303, 111)
        Me.lblGenres.Name = "lblGenres"
        Me.lblGenres.Size = New System.Drawing.Size(466, 22)
        Me.lblGenres.TabIndex = 10
        Me.lblGenres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSeries
        '
        Me.lblSeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblSeries.Location = New System.Drawing.Point(302, 86)
        Me.lblSeries.Name = "lblSeries"
        Me.lblSeries.Size = New System.Drawing.Size(466, 22)
        Me.lblSeries.TabIndex = 9
        Me.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(303, 7)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(466, 22)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAnnotation)
        Me.GroupBox1.Location = New System.Drawing.Point(230, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 127)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Аннотация"
        '
        'txtAnnotation
        '
        Me.txtAnnotation.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnnotation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAnnotation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnotation.Location = New System.Drawing.Point(13, 20)
        Me.txtAnnotation.Multiline = True
        Me.txtAnnotation.Name = "txtAnnotation"
        Me.txtAnnotation.ReadOnly = True
        Me.txtAnnotation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAnnotation.Size = New System.Drawing.Size(516, 91)
        Me.txtAnnotation.TabIndex = 0
        Me.txtAnnotation.Text = "123"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Жанр(ы):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(237, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Серия:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(237, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Автор(ы):"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(236, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Название:"
        '
        'picCover
        '
        Me.picCover.Location = New System.Drawing.Point(13, 12)
        Me.picCover.Name = "picCover"
        Me.picCover.Size = New System.Drawing.Size(210, 250)
        Me.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCover.TabIndex = 0
        Me.picCover.TabStop = False
        '
        'pnlAlphabet
        '
        Me.pnlAlphabet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlphabet.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlphabet.Name = "pnlAlphabet"
        Me.pnlAlphabet.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.pnlAlphabet.Size = New System.Drawing.Size(1184, 25)
        Me.pnlAlphabet.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlAlphabet)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1184, 638)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 2
        '
        'mnuCatalog
        '
        Me.mnuCatalog.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.ToolStripMenuItem14, Me.mnuAddBook, Me.mnuAddBooks, Me.ToolStripMenuItem1, Me.mnuAttach, Me.mnuDetach, Me.ToolStripMenuItem3, Me.mnuSynchronizationCatalog, Me.ToolStripMenuItem6, Me.mnuCatalogInfo, Me.ToolStripMenuItem9, Me.mnuDeleteCatalog, Me.ToolStripMenuItem2, Me.mnuExit})
        Me.mnuCatalog.Name = "mnuCatalog"
        Me.mnuCatalog.Size = New System.Drawing.Size(60, 20)
        Me.mnuCatalog.Text = "Catalog"
        '
        'mnuNew
        '
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(198, 22)
        Me.mnuNew.Text = "New..."
        '
        'mnuOpen
        '
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.Size = New System.Drawing.Size(198, 22)
        Me.mnuOpen.Text = "Open"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(195, 6)
        '
        'mnuAddBook
        '
        Me.mnuAddBook.Name = "mnuAddBook"
        Me.mnuAddBook.Size = New System.Drawing.Size(198, 22)
        Me.mnuAddBook.Text = "Add Single Book"
        '
        'mnuAddBooks
        '
        Me.mnuAddBooks.Name = "mnuAddBooks"
        Me.mnuAddBooks.Size = New System.Drawing.Size(198, 22)
        Me.mnuAddBooks.Text = "Add Books From Folder"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(195, 6)
        '
        'mnuAttach
        '
        Me.mnuAttach.Name = "mnuAttach"
        Me.mnuAttach.Size = New System.Drawing.Size(198, 22)
        Me.mnuAttach.Text = "Attach..."
        '
        'mnuDetach
        '
        Me.mnuDetach.Name = "mnuDetach"
        Me.mnuDetach.Size = New System.Drawing.Size(198, 22)
        Me.mnuDetach.Text = "Detach..."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(195, 6)
        '
        'mnuSynchronizationCatalog
        '
        Me.mnuSynchronizationCatalog.Name = "mnuSynchronizationCatalog"
        Me.mnuSynchronizationCatalog.Size = New System.Drawing.Size(198, 22)
        Me.mnuSynchronizationCatalog.Text = "Refresh Catalog"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(195, 6)
        '
        'mnuCatalogInfo
        '
        Me.mnuCatalogInfo.Name = "mnuCatalogInfo"
        Me.mnuCatalogInfo.Size = New System.Drawing.Size(198, 22)
        Me.mnuCatalogInfo.Text = "Catalog Info"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(195, 6)
        '
        'mnuDeleteCatalog
        '
        Me.mnuDeleteCatalog.Name = "mnuDeleteCatalog"
        Me.mnuDeleteCatalog.Size = New System.Drawing.Size(198, 22)
        Me.mnuDeleteCatalog.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(198, 22)
        Me.mnuExit.Text = "Exit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditCatalogInfo, Me.ToolStripMenuItem10, Me.mnuEditAuthor, Me.ToolStripMenuItem7, Me.mnuEditSerie, Me.ToolStripMenuItem8, Me.mnuEditGanre})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.mnuEdit.Text = "Edit"
        '
        'mnuEditCatalogInfo
        '
        Me.mnuEditCatalogInfo.Name = "mnuEditCatalogInfo"
        Me.mnuEditCatalogInfo.Size = New System.Drawing.Size(139, 22)
        Me.mnuEditCatalogInfo.Text = "Catalog Info"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(136, 6)
        '
        'mnuEditAuthor
        '
        Me.mnuEditAuthor.Name = "mnuEditAuthor"
        Me.mnuEditAuthor.Size = New System.Drawing.Size(139, 22)
        Me.mnuEditAuthor.Text = "Author"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(136, 6)
        '
        'mnuEditSerie
        '
        Me.mnuEditSerie.Name = "mnuEditSerie"
        Me.mnuEditSerie.Size = New System.Drawing.Size(139, 22)
        Me.mnuEditSerie.Text = "Serie"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(136, 6)
        '
        'mnuEditGanre
        '
        Me.mnuEditGanre.Name = "mnuEditGanre"
        Me.mnuEditGanre.Size = New System.Drawing.Size(139, 22)
        Me.mnuEditGanre.Text = "Ganre"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuClearList, Me.ToolStripMenuItem5, Me.mnuRefreshGenres, Me.ToolStripMenuItem15, Me.mnuSettings})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(48, 20)
        Me.mnuTools.Text = "Tools"
        '
        'mnuClearList
        '
        Me.mnuClearList.Name = "mnuClearList"
        Me.mnuClearList.Size = New System.Drawing.Size(187, 22)
        Me.mnuClearList.Text = "Clear List Of Catalogs"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(184, 6)
        '
        'mnuRefreshGenres
        '
        Me.mnuRefreshGenres.Name = "mnuRefreshGenres"
        Me.mnuRefreshGenres.Size = New System.Drawing.Size(187, 22)
        Me.mnuRefreshGenres.Text = "Refresh Genres"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(184, 6)
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(187, 22)
        Me.mnuSettings.Text = "Settings"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
        Me.mnuHelp.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'MyLibMenu
        '
        Me.MyLibMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCatalog, Me.mnuEdit, Me.mnuTools, Me.mnuHelp})
        Me.MyLibMenu.Location = New System.Drawing.Point(0, 0)
        Me.MyLibMenu.Name = "MyLibMenu"
        Me.MyLibMenu.Size = New System.Drawing.Size(1184, 24)
        Me.MyLibMenu.TabIndex = 1
        Me.MyLibMenu.Text = "MenuStrip1"
        '
        'StrStatus
        '
        Me.StrStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusRefreshCatalog})
        Me.StrStatus.Location = New System.Drawing.Point(0, 662)
        Me.StrStatus.Name = "StrStatus"
        Me.StrStatus.Size = New System.Drawing.Size(1184, 22)
        Me.StrStatus.TabIndex = 0
        Me.StrStatus.Text = "StatusStrip1"
        '
        'lblStatusRefreshCatalog
        '
        Me.lblStatusRefreshCatalog.Name = "lblStatusRefreshCatalog"
        Me.lblStatusRefreshCatalog.Size = New System.Drawing.Size(0, 17)
        '
        'BookMenu
        '
        Me.BookMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntxSelectAll, Me.cntxUnselectAll, Me.ToolStripMenuItem17, Me.cntxOpen, Me.ToolStripMenuItem13, Me.cntxBookInfo, Me.ToolStripMenuItem4, Me.cntxRefreshBookInfo, Me.ToolStripMenuItem16, Me.cntxEditBookCard, Me.ToolStripMenuItem12, Me.cntxDelete, Me.ToolStripMenuItem11, Me.cntxAddToListToRead, Me.ToolStripSeparator1})
        Me.BookMenu.Name = "BookMenu"
        Me.BookMenu.Size = New System.Drawing.Size(188, 222)
        '
        'cntxSelectAll
        '
        Me.cntxSelectAll.Name = "cntxSelectAll"
        Me.cntxSelectAll.Size = New System.Drawing.Size(187, 22)
        Me.cntxSelectAll.Text = "Select All"
        '
        'cntxUnselectAll
        '
        Me.cntxUnselectAll.Name = "cntxUnselectAll"
        Me.cntxUnselectAll.Size = New System.Drawing.Size(187, 22)
        Me.cntxUnselectAll.Text = "Unselect All"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        Me.ToolStripMenuItem17.Size = New System.Drawing.Size(184, 6)
        '
        'cntxOpen
        '
        Me.cntxOpen.Name = "cntxOpen"
        Me.cntxOpen.Size = New System.Drawing.Size(187, 22)
        Me.cntxOpen.Text = "Read"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(184, 6)
        '
        'cntxBookInfo
        '
        Me.cntxBookInfo.Name = "cntxBookInfo"
        Me.cntxBookInfo.Size = New System.Drawing.Size(187, 22)
        Me.cntxBookInfo.Text = "Book Info"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(184, 6)
        '
        'cntxRefreshBookInfo
        '
        Me.cntxRefreshBookInfo.Name = "cntxRefreshBookInfo"
        Me.cntxRefreshBookInfo.Size = New System.Drawing.Size(187, 22)
        Me.cntxRefreshBookInfo.Text = "Refresh Book Info"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(184, 6)
        '
        'cntxEditBookCard
        '
        Me.cntxEditBookCard.Name = "cntxEditBookCard"
        Me.cntxEditBookCard.Size = New System.Drawing.Size(187, 22)
        Me.cntxEditBookCard.Text = "Edit BookCard"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(184, 6)
        '
        'cntxDelete
        '
        Me.cntxDelete.Name = "cntxDelete"
        Me.cntxDelete.Size = New System.Drawing.Size(187, 22)
        Me.cntxDelete.Text = "Delete"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(184, 6)
        '
        'cntxAddToListToRead
        '
        Me.cntxAddToListToRead.Name = "cntxAddToListToRead"
        Me.cntxAddToListToRead.Size = New System.Drawing.Size(187, 22)
        Me.cntxAddToListToRead.Text = "Add To List ""ToRead"""
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'frmMyLib
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 684)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StrStatus)
        Me.Controls.Add(Me.MyLibMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MyLibMenu
        Me.MinimumSize = New System.Drawing.Size(750, 550)
        Me.Name = "frmMyLib"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMyLib"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TabSelect.ResumeLayout(False)
        Me.Authors.ResumeLayout(False)
        Me.Authors.PerformLayout()
        Me.Series.ResumeLayout(False)
        Me.Genres.ResumeLayout(False)
        Me.Search.ResumeLayout(False)
        Me.Search.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.MyLibMenu.ResumeLayout(False)
        Me.MyLibMenu.PerformLayout()
        Me.StrStatus.ResumeLayout(False)
        Me.StrStatus.PerformLayout()
        Me.BookMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents TabSelect As TabControl
    Friend WithEvents Authors As TabPage
    Friend WithEvents lstAuthors As ListBox
    Friend WithEvents Genres As TabPage
    Friend WithEvents trvGenre As TreeView
    Friend WithEvents Series As TabPage
    Friend WithEvents lstSeries As ListBox
    Friend WithEvents Search As TabPage
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents pnlAlphabet As FlowLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents mnuCatalog As ToolStripMenuItem
    Friend WithEvents mnuNew As ToolStripMenuItem
    Friend WithEvents mnuOpen As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents mnuCatalogInfo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripSeparator
    Friend WithEvents mnuDeleteCatalog As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuAddBooks As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuEdit As ToolStripMenuItem
    Friend WithEvents mnuEditCatalogInfo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As ToolStripSeparator
    Friend WithEvents mnuEditAuthor As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents mnuEditSerie As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents mnuEditGanre As ToolStripMenuItem
    Friend WithEvents mnuTools As ToolStripMenuItem
    Friend WithEvents mnuClearList As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents MyLibMenu As MenuStrip
    Friend WithEvents StrStatus As StatusStrip
    Friend WithEvents pnlCard As Panel
    Friend WithEvents pnlAuthors As FlowLayoutPanel
    Friend WithEvents lblGenres As Label
    Friend WithEvents lblSeries As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAnnotation As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents picCover As PictureBox
    Friend WithEvents trvListBooks As System.Windows.Forms.TreeView
    Friend WithEvents AuthSearch As TextBox
    Friend WithEvents BookMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cntxBookInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cntxDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cntxAddToListToRead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rbSearch As System.Windows.Forms.RadioButton
    Friend WithEvents rbDuplicate As System.Windows.Forms.RadioButton
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cmbSearchGenres As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSearchSeries As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSearchAuthors As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSearchTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearchKeyWords As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cntxEditBookCard As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem14 As ToolStripSeparator
    Friend WithEvents mnuAttach As ToolStripMenuItem
    Friend WithEvents mnuDetach As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuSynchronizationCatalog As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents mnuAddBook As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSearchAnnotation As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cntxOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuRefreshGenres As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cntxRefreshBookInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblStatusRefreshCatalog As ToolStripStatusLabel
    Friend WithEvents cntxSelectAll As ToolStripMenuItem
    Friend WithEvents cntxUnselectAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents rbNonDuplicate As RadioButton
End Class
