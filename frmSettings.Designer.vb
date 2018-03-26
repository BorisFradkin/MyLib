<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.lblCatalogBase = New System.Windows.Forms.Label()
        Me.txtCatalogBase = New System.Windows.Forms.TextBox()
        Me.btnBrowseCatalogBase = New System.Windows.Forms.Button()
        Me.btnBrowseTempPath = New System.Windows.Forms.Button()
        Me.txtTempPath = New System.Windows.Forms.TextBox()
        Me.lblTempPath = New System.Windows.Forms.Label()
        Me.txtFormats = New System.Windows.Forms.TextBox()
        Me.lblFormats = New System.Windows.Forms.Label()
        Me.chkLookZip = New System.Windows.Forms.CheckBox()
        Me.chkSubFolders = New System.Windows.Forms.CheckBox()
        Me.txtLogFile = New System.Windows.Forms.TextBox()
        Me.lblLogFile = New System.Windows.Forms.Label()
        Me.txtPrefixFileName = New System.Windows.Forms.TextBox()
        Me.lblPrefixFileName = New System.Windows.Forms.Label()
        Me.txtPostfixFileName = New System.Windows.Forms.TextBox()
        Me.lblPostfixFileName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cdFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrowseList2Read = New System.Windows.Forms.Button()
        Me.txtList2Read = New System.Windows.Forms.TextBox()
        Me.lblRead2List = New System.Windows.Forms.Label()
        Me.btnBrowserReader = New System.Windows.Forms.Button()
        Me.txtReader = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cdOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.chkShowSeriesInTree = New System.Windows.Forms.CheckBox()
        Me.lblLangInterface = New System.Windows.Forms.Label()
        Me.cmbLangInterface = New System.Windows.Forms.ComboBox()
        Me.chkAddGenres = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblCatalogBase
        '
        Me.lblCatalogBase.Location = New System.Drawing.Point(9, 25)
        Me.lblCatalogBase.Name = "lblCatalogBase"
        Me.lblCatalogBase.Size = New System.Drawing.Size(119, 15)
        Me.lblCatalogBase.TabIndex = 0
        Me.lblCatalogBase.Text = "Каталоги"
        Me.lblCatalogBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCatalogBase
        '
        Me.txtCatalogBase.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtCatalogBase.Location = New System.Drawing.Point(143, 22)
        Me.txtCatalogBase.Name = "txtCatalogBase"
        Me.txtCatalogBase.Size = New System.Drawing.Size(644, 23)
        Me.txtCatalogBase.TabIndex = 1
        '
        'btnBrowseCatalogBase
        '
        Me.btnBrowseCatalogBase.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnBrowseCatalogBase.Location = New System.Drawing.Point(808, 22)
        Me.btnBrowseCatalogBase.Name = "btnBrowseCatalogBase"
        Me.btnBrowseCatalogBase.Size = New System.Drawing.Size(43, 22)
        Me.btnBrowseCatalogBase.TabIndex = 2
        Me.btnBrowseCatalogBase.Text = "···"
        Me.btnBrowseCatalogBase.UseVisualStyleBackColor = True
        '
        'btnBrowseTempPath
        '
        Me.btnBrowseTempPath.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnBrowseTempPath.Location = New System.Drawing.Point(808, 59)
        Me.btnBrowseTempPath.Name = "btnBrowseTempPath"
        Me.btnBrowseTempPath.Size = New System.Drawing.Size(43, 22)
        Me.btnBrowseTempPath.TabIndex = 8
        Me.btnBrowseTempPath.Text = "···"
        Me.btnBrowseTempPath.UseVisualStyleBackColor = True
        '
        'txtTempPath
        '
        Me.txtTempPath.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtTempPath.Location = New System.Drawing.Point(143, 62)
        Me.txtTempPath.Name = "txtTempPath"
        Me.txtTempPath.Size = New System.Drawing.Size(644, 23)
        Me.txtTempPath.TabIndex = 7
        '
        'lblTempPath
        '
        Me.lblTempPath.AutoSize = True
        Me.lblTempPath.Location = New System.Drawing.Point(9, 62)
        Me.lblTempPath.Name = "lblTempPath"
        Me.lblTempPath.Size = New System.Drawing.Size(119, 15)
        Me.lblTempPath.TabIndex = 6
        Me.lblTempPath.Text = "Временные файлы"
        Me.lblTempPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFormats
        '
        Me.txtFormats.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtFormats.Location = New System.Drawing.Point(143, 180)
        Me.txtFormats.Name = "txtFormats"
        Me.txtFormats.Size = New System.Drawing.Size(644, 23)
        Me.txtFormats.TabIndex = 10
        '
        'lblFormats
        '
        Me.lblFormats.Location = New System.Drawing.Point(8, 183)
        Me.lblFormats.Name = "lblFormats"
        Me.lblFormats.Size = New System.Drawing.Size(119, 15)
        Me.lblFormats.TabIndex = 9
        Me.lblFormats.Text = "Форматы"
        Me.lblFormats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkLookZip
        '
        Me.chkLookZip.AutoSize = True
        Me.chkLookZip.Location = New System.Drawing.Point(143, 304)
        Me.chkLookZip.Name = "chkLookZip"
        Me.chkLookZip.Size = New System.Drawing.Size(133, 19)
        Me.chkLookZip.TabIndex = 12
        Me.chkLookZip.Text = "Читать Zip файлы"
        Me.chkLookZip.UseVisualStyleBackColor = True
        '
        'chkSubFolders
        '
        Me.chkSubFolders.AutoSize = True
        Me.chkSubFolders.Location = New System.Drawing.Point(143, 328)
        Me.chkSubFolders.Name = "chkSubFolders"
        Me.chkSubFolders.Size = New System.Drawing.Size(213, 19)
        Me.chkSubFolders.TabIndex = 13
        Me.chkSubFolders.Text = "Просматривать поддериктории"
        Me.chkSubFolders.UseVisualStyleBackColor = True
        '
        'txtLogFile
        '
        Me.txtLogFile.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtLogFile.Location = New System.Drawing.Point(143, 220)
        Me.txtLogFile.Name = "txtLogFile"
        Me.txtLogFile.Size = New System.Drawing.Size(644, 23)
        Me.txtLogFile.TabIndex = 15
        '
        'lblLogFile
        '
        Me.lblLogFile.Location = New System.Drawing.Point(8, 223)
        Me.lblLogFile.Name = "lblLogFile"
        Me.lblLogFile.Size = New System.Drawing.Size(119, 15)
        Me.lblLogFile.TabIndex = 14
        Me.lblLogFile.Text = "Имя Лог файла"
        Me.lblLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrefixFileName
        '
        Me.txtPrefixFileName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtPrefixFileName.Location = New System.Drawing.Point(143, 255)
        Me.txtPrefixFileName.Name = "txtPrefixFileName"
        Me.txtPrefixFileName.Size = New System.Drawing.Size(235, 23)
        Me.txtPrefixFileName.TabIndex = 17
        '
        'lblPrefixFileName
        '
        Me.lblPrefixFileName.Location = New System.Drawing.Point(8, 249)
        Me.lblPrefixFileName.Name = "lblPrefixFileName"
        Me.lblPrefixFileName.Size = New System.Drawing.Size(101, 33)
        Me.lblPrefixFileName.TabIndex = 16
        Me.lblPrefixFileName.Text = "Начало имени каталога"
        Me.lblPrefixFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPostfixFileName
        '
        Me.txtPostfixFileName.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtPostfixFileName.Location = New System.Drawing.Point(576, 255)
        Me.txtPostfixFileName.Name = "txtPostfixFileName"
        Me.txtPostfixFileName.Size = New System.Drawing.Size(211, 23)
        Me.txtPostfixFileName.TabIndex = 19
        '
        'lblPostfixFileName
        '
        Me.lblPostfixFileName.Location = New System.Drawing.Point(443, 250)
        Me.lblPostfixFileName.Name = "lblPostfixFileName"
        Me.lblPostfixFileName.Size = New System.Drawing.Size(127, 33)
        Me.lblPostfixFileName.TabIndex = 18
        Me.lblPostfixFileName.Text = "Конец имени каталога"
        Me.lblPostfixFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(775, 351)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(694, 351)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 22)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBrowseList2Read
        '
        Me.btnBrowseList2Read.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnBrowseList2Read.Location = New System.Drawing.Point(808, 102)
        Me.btnBrowseList2Read.Name = "btnBrowseList2Read"
        Me.btnBrowseList2Read.Size = New System.Drawing.Size(43, 22)
        Me.btnBrowseList2Read.TabIndex = 24
        Me.btnBrowseList2Read.Text = "···"
        Me.btnBrowseList2Read.UseVisualStyleBackColor = True
        '
        'txtList2Read
        '
        Me.txtList2Read.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtList2Read.Location = New System.Drawing.Point(144, 101)
        Me.txtList2Read.Name = "txtList2Read"
        Me.txtList2Read.Size = New System.Drawing.Size(644, 23)
        Me.txtList2Read.TabIndex = 23
        '
        'lblRead2List
        '
        Me.lblRead2List.AutoSize = True
        Me.lblRead2List.Location = New System.Drawing.Point(9, 104)
        Me.lblRead2List.Name = "lblRead2List"
        Me.lblRead2List.Size = New System.Drawing.Size(126, 15)
        Me.lblRead2List.TabIndex = 22
        Me.lblRead2List.Text = "Список ""Для чтения"""
        Me.lblRead2List.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBrowserReader
        '
        Me.btnBrowserReader.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnBrowserReader.Location = New System.Drawing.Point(807, 141)
        Me.btnBrowserReader.Name = "btnBrowserReader"
        Me.btnBrowserReader.Size = New System.Drawing.Size(43, 22)
        Me.btnBrowserReader.TabIndex = 27
        Me.btnBrowserReader.Text = "···"
        Me.btnBrowserReader.UseVisualStyleBackColor = True
        '
        'txtReader
        '
        Me.txtReader.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.txtReader.Location = New System.Drawing.Point(143, 140)
        Me.txtReader.Name = "txtReader"
        Me.txtReader.Size = New System.Drawing.Size(644, 23)
        Me.txtReader.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Читалка"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cdOpenFile
        '
        Me.cdOpenFile.FileName = "OpenFileDialog1"
        '
        'chkShowSeriesInTree
        '
        Me.chkShowSeriesInTree.AutoSize = True
        Me.chkShowSeriesInTree.Location = New System.Drawing.Point(143, 354)
        Me.chkShowSeriesInTree.Name = "chkShowSeriesInTree"
        Me.chkShowSeriesInTree.Size = New System.Drawing.Size(215, 19)
        Me.chkShowSeriesInTree.TabIndex = 28
        Me.chkShowSeriesInTree.Text = "Показывать серии в списке книг"
        Me.chkShowSeriesInTree.UseVisualStyleBackColor = True
        '
        'lblLangInterface
        '
        Me.lblLangInterface.AutoSize = True
        Me.lblLangInterface.Location = New System.Drawing.Point(468, 304)
        Me.lblLangInterface.Name = "lblLangInterface"
        Me.lblLangInterface.Size = New System.Drawing.Size(113, 15)
        Me.lblLangInterface.TabIndex = 29
        Me.lblLangInterface.Text = "Язык интерфейса"
        '
        'cmbLangInterface
        '
        Me.cmbLangInterface.FormattingEnabled = True
        Me.cmbLangInterface.Items.AddRange(New Object() {"Русский", "English", "עברית"})
        Me.cmbLangInterface.Location = New System.Drawing.Point(618, 297)
        Me.cmbLangInterface.Name = "cmbLangInterface"
        Me.cmbLangInterface.Size = New System.Drawing.Size(169, 23)
        Me.cmbLangInterface.TabIndex = 30
        '
        'chkAddGenres
        '
        Me.chkAddGenres.Location = New System.Drawing.Point(471, 328)
        Me.chkAddGenres.Name = "chkAddGenres"
        Me.chkAddGenres.Size = New System.Drawing.Size(217, 34)
        Me.chkAddGenres.TabIndex = 31
        Me.chkAddGenres.Text = "Использовать дополнительные жанры из тектовых файлов"
        Me.chkAddGenres.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 385)
        Me.Controls.Add(Me.chkAddGenres)
        Me.Controls.Add(Me.cmbLangInterface)
        Me.Controls.Add(Me.lblLangInterface)
        Me.Controls.Add(Me.chkShowSeriesInTree)
        Me.Controls.Add(Me.btnBrowserReader)
        Me.Controls.Add(Me.txtReader)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowseList2Read)
        Me.Controls.Add(Me.txtList2Read)
        Me.Controls.Add(Me.lblRead2List)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPostfixFileName)
        Me.Controls.Add(Me.lblPostfixFileName)
        Me.Controls.Add(Me.txtPrefixFileName)
        Me.Controls.Add(Me.lblPrefixFileName)
        Me.Controls.Add(Me.txtLogFile)
        Me.Controls.Add(Me.lblLogFile)
        Me.Controls.Add(Me.chkSubFolders)
        Me.Controls.Add(Me.chkLookZip)
        Me.Controls.Add(Me.txtFormats)
        Me.Controls.Add(Me.lblFormats)
        Me.Controls.Add(Me.btnBrowseTempPath)
        Me.Controls.Add(Me.txtTempPath)
        Me.Controls.Add(Me.lblTempPath)
        Me.Controls.Add(Me.btnBrowseCatalogBase)
        Me.Controls.Add(Me.txtCatalogBase)
        Me.Controls.Add(Me.lblCatalogBase)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCatalogBase As System.Windows.Forms.Label
    Friend WithEvents txtCatalogBase As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseCatalogBase As System.Windows.Forms.Button
    Friend WithEvents btnBrowseTempPath As System.Windows.Forms.Button
    Friend WithEvents txtTempPath As System.Windows.Forms.TextBox
    Friend WithEvents lblTempPath As System.Windows.Forms.Label
    Friend WithEvents txtFormats As System.Windows.Forms.TextBox
    Friend WithEvents lblFormats As System.Windows.Forms.Label
    Friend WithEvents chkLookZip As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubFolders As System.Windows.Forms.CheckBox
    Friend WithEvents txtLogFile As System.Windows.Forms.TextBox
    Friend WithEvents lblLogFile As System.Windows.Forms.Label
    Friend WithEvents txtPrefixFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefixFileName As System.Windows.Forms.Label
    Friend WithEvents txtPostfixFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPostfixFileName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cdFolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrowseList2Read As Button
    Friend WithEvents txtList2Read As TextBox
    Friend WithEvents lblRead2List As Label
    Friend WithEvents btnBrowserReader As System.Windows.Forms.Button
    Friend WithEvents txtReader As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cdOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkShowSeriesInTree As CheckBox
    Friend WithEvents lblLangInterface As System.Windows.Forms.Label
    Friend WithEvents cmbLangInterface As System.Windows.Forms.ComboBox
    Friend WithEvents chkAddGenres As System.Windows.Forms.CheckBox
End Class
