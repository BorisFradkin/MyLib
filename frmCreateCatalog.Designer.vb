<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateCatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNameCatalog = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtPath2Books = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.chkAddBooks = New System.Windows.Forms.CheckBox()
        Me.folderBrowse = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblBooks = New System.Windows.Forms.Label()
        Me.lblNumBooks = New System.Windows.Forms.Label()
        Me.pnlCreateCatalog = New System.Windows.Forms.Panel()
        Me.lblAddBook = New System.Windows.Forms.Label()
        Me.pbAddBooks = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cntxTxt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntxDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlCreateCatalog.SuspendLayout()
        Me.cntxTxt.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(570, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Создание каталога"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Название каталога:"
        '
        'txtNameCatalog
        '
        Me.txtNameCatalog.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNameCatalog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameCatalog.Location = New System.Drawing.Point(142, 68)
        Me.txtNameCatalog.Name = "txtNameCatalog"
        Me.txtNameCatalog.Size = New System.Drawing.Size(367, 23)
        Me.txtNameCatalog.TabIndex = 2
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(142, 97)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(367, 23)
        Me.txtFileName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Имя файла"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(515, 187)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(43, 23)
        Me.btnBrowse.TabIndex = 9
        Me.btnBrowse.Text = "···"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPath2Books
        '
        Me.txtPath2Books.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPath2Books.ContextMenuStrip = Me.cntxTxt
        Me.txtPath2Books.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2Books.Location = New System.Drawing.Point(142, 126)
        Me.txtPath2Books.Multiline = True
        Me.txtPath2Books.Name = "txtPath2Books"
        Me.txtPath2Books.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPath2Books.Size = New System.Drawing.Size(367, 161)
        Me.txtPath2Books.TabIndex = 8
        Me.txtPath2Books.WordWrap = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Папка с книгами"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(142, 293)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(367, 65)
        Me.txtDescription.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 314)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 19)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Описание"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(467, 365)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 26)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(370, 365)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(91, 26)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chkAddBooks
        '
        Me.chkAddBooks.AutoSize = True
        Me.chkAddBooks.Checked = True
        Me.chkAddBooks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAddBooks.Location = New System.Drawing.Point(16, 363)
        Me.chkAddBooks.Name = "chkAddBooks"
        Me.chkAddBooks.Size = New System.Drawing.Size(108, 17)
        Me.chkAddBooks.TabIndex = 14
        Me.chkAddBooks.Text = "Добавить книги"
        Me.chkAddBooks.UseVisualStyleBackColor = True
        '
        'lblBooks
        '
        Me.lblBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBooks.Location = New System.Drawing.Point(139, 361)
        Me.lblBooks.Name = "lblBooks"
        Me.lblBooks.Size = New System.Drawing.Size(61, 19)
        Me.lblBooks.TabIndex = 15
        Me.lblBooks.Text = "Файлов:"
        '
        'lblNumBooks
        '
        Me.lblNumBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumBooks.Location = New System.Drawing.Point(206, 361)
        Me.lblNumBooks.Name = "lblNumBooks"
        Me.lblNumBooks.Size = New System.Drawing.Size(55, 19)
        Me.lblNumBooks.TabIndex = 16
        Me.lblNumBooks.Text = "XXXXXX"
        '
        'pnlCreateCatalog
        '
        Me.pnlCreateCatalog.Controls.Add(Me.lblAddBook)
        Me.pnlCreateCatalog.Controls.Add(Me.pbAddBooks)
        Me.pnlCreateCatalog.Controls.Add(Me.Label6)
        Me.pnlCreateCatalog.Location = New System.Drawing.Point(190, 143)
        Me.pnlCreateCatalog.Name = "pnlCreateCatalog"
        Me.pnlCreateCatalog.Size = New System.Drawing.Size(257, 114)
        Me.pnlCreateCatalog.TabIndex = 17
        '
        'lblAddBook
        '
        Me.lblAddBook.AutoSize = True
        Me.lblAddBook.Location = New System.Drawing.Point(9, 65)
        Me.lblAddBook.Name = "lblAddBook"
        Me.lblAddBook.Size = New System.Drawing.Size(96, 13)
        Me.lblAddBook.TabIndex = 2
        Me.lblAddBook.Text = "Добавление книг"
        '
        'pbAddBooks
        '
        Me.pbAddBooks.Location = New System.Drawing.Point(5, 81)
        Me.pbAddBooks.Name = "pbAddBooks"
        Me.pbAddBooks.Size = New System.Drawing.Size(246, 25)
        Me.pbAddBooks.Step = 1
        Me.pbAddBooks.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(247, 37)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ждите, пока MyLib создаст каталог"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cntxTxt
        '
        Me.cntxTxt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cntxDelete})
        Me.cntxTxt.Name = "cntxTxt"
        Me.cntxTxt.Size = New System.Drawing.Size(108, 26)
        '
        'cntxDelete
        '
        Me.cntxDelete.Name = "cntxDelete"
        Me.cntxDelete.Size = New System.Drawing.Size(107, 22)
        Me.cntxDelete.Text = "Delete"
        '
        'frmCreateCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 403)
        Me.Controls.Add(Me.pnlCreateCatalog)
        Me.Controls.Add(Me.lblNumBooks)
        Me.Controls.Add(Me.lblBooks)
        Me.Controls.Add(Me.chkAddBooks)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPath2Books)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNameCatalog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreateCatalog"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlCreateCatalog.ResumeLayout(False)
        Me.pnlCreateCatalog.PerformLayout()
        Me.cntxTxt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNameCatalog As TextBox
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtPath2Books As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents chkAddBooks As CheckBox
    Friend WithEvents folderBrowse As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblBooks As System.Windows.Forms.Label
    Friend WithEvents lblNumBooks As System.Windows.Forms.Label
    Friend WithEvents pnlCreateCatalog As System.Windows.Forms.Panel
    Friend WithEvents lblAddBook As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pbAddBooks As ProgressBar
    Friend WithEvents cntxTxt As ContextMenuStrip
    Friend WithEvents cntxDelete As ToolStripMenuItem
End Class
