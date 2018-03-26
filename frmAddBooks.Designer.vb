<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddBooks
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
        Me.lblAddBook = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlAddBooks = New System.Windows.Forms.Panel()
        Me.pbAddBooks = New System.Windows.Forms.ProgressBar()
        Me.lblNumBooks = New System.Windows.Forms.Label()
        Me.lblBooks = New System.Windows.Forms.Label()
        Me.folderBrowse = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNameCatalog = New System.Windows.Forms.ComboBox()
        Me.txtPath2Books = New System.Windows.Forms.TextBox()
        Me.cntxTxt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cntxDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlAddBooks.SuspendLayout()
        Me.cntxTxt.SuspendLayout()
        Me.SuspendLayout()
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
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(242, 37)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ждите, пока MyLib добавит книги в каталог"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAddBooks
        '
        Me.pnlAddBooks.Controls.Add(Me.lblAddBook)
        Me.pnlAddBooks.Controls.Add(Me.pbAddBooks)
        Me.pnlAddBooks.Controls.Add(Me.Label6)
        Me.pnlAddBooks.Location = New System.Drawing.Point(184, 123)
        Me.pnlAddBooks.Name = "pnlAddBooks"
        Me.pnlAddBooks.Size = New System.Drawing.Size(257, 114)
        Me.pnlAddBooks.TabIndex = 33
        '
        'pbAddBooks
        '
        Me.pbAddBooks.Location = New System.Drawing.Point(5, 81)
        Me.pbAddBooks.Name = "pbAddBooks"
        Me.pbAddBooks.Size = New System.Drawing.Size(246, 25)
        Me.pbAddBooks.Step = 1
        Me.pbAddBooks.TabIndex = 1
        '
        'lblNumBooks
        '
        Me.lblNumBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumBooks.Location = New System.Drawing.Point(203, 356)
        Me.lblNumBooks.Name = "lblNumBooks"
        Me.lblNumBooks.Size = New System.Drawing.Size(55, 19)
        Me.lblNumBooks.TabIndex = 32
        Me.lblNumBooks.Text = "XXXXXX"
        '
        'lblBooks
        '
        Me.lblBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBooks.Location = New System.Drawing.Point(136, 356)
        Me.lblBooks.Name = "lblBooks"
        Me.lblBooks.Size = New System.Drawing.Size(61, 19)
        Me.lblBooks.TabIndex = 31
        Me.lblBooks.Text = "Файлов:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(370, 356)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(91, 26)
        Me.btnOK.TabIndex = 29
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(467, 356)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 26)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(142, 285)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(367, 65)
        Me.txtDescription.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 19)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Описание"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(515, 163)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(43, 23)
        Me.btnBrowse.TabIndex = 25
        Me.btnBrowse.Text = "···"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 19)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Папки с книгами"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 19)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Название каталога:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(573, 37)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Добавление книг в каталог"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbNameCatalog
        '
        Me.cmbNameCatalog.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbNameCatalog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmbNameCatalog.FormattingEnabled = True
        Me.cmbNameCatalog.Location = New System.Drawing.Point(142, 60)
        Me.cmbNameCatalog.Name = "cmbNameCatalog"
        Me.cmbNameCatalog.Size = New System.Drawing.Size(367, 24)
        Me.cmbNameCatalog.TabIndex = 34
        '
        'txtPath2Books
        '
        Me.txtPath2Books.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPath2Books.ContextMenuStrip = Me.cntxTxt
        Me.txtPath2Books.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtPath2Books.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPath2Books.Location = New System.Drawing.Point(142, 90)
        Me.txtPath2Books.Multiline = True
        Me.txtPath2Books.Name = "txtPath2Books"
        Me.txtPath2Books.ReadOnly = True
        Me.txtPath2Books.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPath2Books.Size = New System.Drawing.Size(366, 189)
        Me.txtPath2Books.TabIndex = 35
        Me.txtPath2Books.WordWrap = False
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
        'frmAddBooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 394)
        Me.Controls.Add(Me.pnlAddBooks)
        Me.Controls.Add(Me.txtPath2Books)
        Me.Controls.Add(Me.lblNumBooks)
        Me.Controls.Add(Me.lblBooks)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbNameCatalog)
        Me.Name = "frmAddBooks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddBooks"
        Me.pnlAddBooks.ResumeLayout(False)
        Me.pnlAddBooks.PerformLayout()
        Me.cntxTxt.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents lblAddBook As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlAddBooks As System.Windows.Forms.Panel
    Friend WithEvents pbAddBooks As System.Windows.Forms.ProgressBar
    Friend WithEvents lblNumBooks As System.Windows.Forms.Label
    Friend WithEvents lblBooks As System.Windows.Forms.Label
    Friend WithEvents folderBrowse As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbNameCatalog As System.Windows.Forms.ComboBox
    Friend WithEvents txtPath2Books As TextBox
    Friend WithEvents cntxTxt As ContextMenuStrip
    Friend WithEvents cntxDelete As ToolStripMenuItem
End Class
