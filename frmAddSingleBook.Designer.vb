<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSingleBook
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
        Me.pnlAddBooks = New System.Windows.Forms.Panel()
        Me.lblAddBook = New System.Windows.Forms.Label()
        Me.pbAddBooks = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblNumBooks = New System.Windows.Forms.Label()
        Me.lblBooks = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cdOpen = New System.Windows.Forms.OpenFileDialog()
        Me.lstBooks = New System.Windows.Forms.ListBox()
        Me.btnCLear = New System.Windows.Forms.Button()
        Me.cmbNameCatalog = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlAddBooks.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAddBooks
        '
        Me.pnlAddBooks.Controls.Add(Me.lblAddBook)
        Me.pnlAddBooks.Controls.Add(Me.pbAddBooks)
        Me.pnlAddBooks.Controls.Add(Me.Label6)
        Me.pnlAddBooks.Location = New System.Drawing.Point(203, 104)
        Me.pnlAddBooks.Name = "pnlAddBooks"
        Me.pnlAddBooks.Size = New System.Drawing.Size(300, 132)
        Me.pnlAddBooks.TabIndex = 41
        '
        'lblAddBook
        '
        Me.lblAddBook.AutoSize = True
        Me.lblAddBook.Location = New System.Drawing.Point(10, 75)
        Me.lblAddBook.Name = "lblAddBook"
        Me.lblAddBook.Size = New System.Drawing.Size(107, 15)
        Me.lblAddBook.TabIndex = 2
        Me.lblAddBook.Text = "Добавление книг"
        '
        'pbAddBooks
        '
        Me.pbAddBooks.Location = New System.Drawing.Point(6, 93)
        Me.pbAddBooks.Name = "pbAddBooks"
        Me.pbAddBooks.Size = New System.Drawing.Size(287, 29)
        Me.pbAddBooks.Step = 1
        Me.pbAddBooks.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 43)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ждите, пока MyLib добавит книги в каталог"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumBooks
        '
        Me.lblNumBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumBooks.Location = New System.Drawing.Point(101, 301)
        Me.lblNumBooks.Name = "lblNumBooks"
        Me.lblNumBooks.Size = New System.Drawing.Size(64, 22)
        Me.lblNumBooks.TabIndex = 40
        Me.lblNumBooks.Text = "XXXXXX"
        '
        'lblBooks
        '
        Me.lblBooks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBooks.Location = New System.Drawing.Point(20, 301)
        Me.lblBooks.Name = "lblBooks"
        Me.lblBooks.Size = New System.Drawing.Size(71, 22)
        Me.lblBooks.TabIndex = 39
        Me.lblBooks.Text = "Файлов:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(373, 293)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(106, 30)
        Me.btnOK.TabIndex = 38
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(486, 293)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 30)
        Me.btnCancel.TabIndex = 37
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Arial Narrow", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(598, 137)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(50, 27)
        Me.btnBrowse.TabIndex = 36
        Me.btnBrowse.Text = "···"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 22)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Выбранные книги"
        '
        'cdOpen
        '
        Me.cdOpen.Multiselect = True
        '
        'lstBooks
        '
        Me.lstBooks.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstBooks.FormattingEnabled = True
        Me.lstBooks.HorizontalScrollbar = True
        Me.lstBooks.ItemHeight = 15
        Me.lstBooks.Location = New System.Drawing.Point(150, 70)
        Me.lstBooks.Name = "lstBooks"
        Me.lstBooks.Size = New System.Drawing.Size(442, 214)
        Me.lstBooks.TabIndex = 42
        '
        'btnCLear
        '
        Me.btnCLear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLear.Location = New System.Drawing.Point(598, 179)
        Me.btnCLear.Name = "btnCLear"
        Me.btnCLear.Size = New System.Drawing.Size(50, 38)
        Me.btnCLear.TabIndex = 43
        Me.btnCLear.Text = "Clear" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "List" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnCLear.UseVisualStyleBackColor = True
        '
        'cmbNameCatalog
        '
        Me.cmbNameCatalog.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbNameCatalog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.cmbNameCatalog.FormattingEnabled = True
        Me.cmbNameCatalog.Location = New System.Drawing.Point(150, 22)
        Me.cmbNameCatalog.Name = "cmbNameCatalog"
        Me.cmbNameCatalog.Size = New System.Drawing.Size(442, 24)
        Me.cmbNameCatalog.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 19)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Название каталога:"
        '
        'frmAddSingleBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 341)
        Me.Controls.Add(Me.cmbNameCatalog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnlAddBooks)
        Me.Controls.Add(Me.btnCLear)
        Me.Controls.Add(Me.lblNumBooks)
        Me.Controls.Add(Me.lblBooks)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lstBooks)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Name = "frmAddSingleBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddSingleBook"
        Me.pnlAddBooks.ResumeLayout(False)
        Me.pnlAddBooks.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAddBooks As System.Windows.Forms.Panel
    Friend WithEvents lblAddBook As System.Windows.Forms.Label
    Friend WithEvents pbAddBooks As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblNumBooks As System.Windows.Forms.Label
    Friend WithEvents lblBooks As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cdOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lstBooks As System.Windows.Forms.ListBox
    Friend WithEvents btnCLear As System.Windows.Forms.Button
    Friend WithEvents cmbNameCatalog As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
