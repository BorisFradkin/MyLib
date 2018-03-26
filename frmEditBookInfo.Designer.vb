<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditBookInfo
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtAuthFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAddAuth = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAddGenre = New System.Windows.Forms.Button()
        Me.txtNumOfSerie = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAnnotation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPublisher = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAddKeyWords = New System.Windows.Forms.Button()
        Me.txtKewWords = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnAddSeries = New System.Windows.Forms.Button()
        Me.txtMidleName = New System.Windows.Forms.TextBox()
        Me.txtAuthLastName = New System.Windows.Forms.ComboBox()
        Me.txtGenre = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(100, 22)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(815, 21)
        Me.txtTitle.TabIndex = 1
        '
        'txtAuthFirstName
        '
        Me.txtAuthFirstName.Location = New System.Drawing.Point(364, 58)
        Me.txtAuthFirstName.Name = "txtAuthFirstName"
        Me.txtAuthFirstName.Size = New System.Drawing.Size(246, 21)
        Me.txtAuthFirstName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Author(s)"
        '
        'btnAddAuth
        '
        Me.btnAddAuth.Location = New System.Drawing.Point(888, 56)
        Me.btnAddAuth.Name = "btnAddAuth"
        Me.btnAddAuth.Size = New System.Drawing.Size(26, 25)
        Me.btnAddAuth.TabIndex = 5
        Me.btnAddAuth.Text = "+"
        Me.btnAddAuth.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Genre(s)"
        '
        'btnAddGenre
        '
        Me.btnAddGenre.Location = New System.Drawing.Point(888, 102)
        Me.btnAddGenre.Name = "btnAddGenre"
        Me.btnAddGenre.Size = New System.Drawing.Size(26, 25)
        Me.btnAddGenre.TabIndex = 8
        Me.btnAddGenre.Text = "+"
        Me.btnAddGenre.UseVisualStyleBackColor = True
        '
        'txtNumOfSerie
        '
        Me.txtNumOfSerie.Location = New System.Drawing.Point(777, 153)
        Me.txtNumOfSerie.Name = "txtNumOfSerie"
        Me.txtNumOfSerie.Size = New System.Drawing.Size(96, 21)
        Me.txtNumOfSerie.TabIndex = 11
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(100, 153)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(659, 21)
        Me.txtSerie.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Serie"
        '
        'txtAnnotation
        '
        Me.txtAnnotation.Location = New System.Drawing.Point(100, 190)
        Me.txtAnnotation.Multiline = True
        Me.txtAnnotation.Name = "txtAnnotation"
        Me.txtAnnotation.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAnnotation.Size = New System.Drawing.Size(815, 102)
        Me.txtAnnotation.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Annotation"
        '
        'txtPublisher
        '
        Me.txtPublisher.Location = New System.Drawing.Point(100, 310)
        Me.txtPublisher.Multiline = True
        Me.txtPublisher.Name = "txtPublisher"
        Me.txtPublisher.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtPublisher.Size = New System.Drawing.Size(814, 137)
        Me.txtPublisher.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 313)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Publisher"
        '
        'btnAddKeyWords
        '
        Me.btnAddKeyWords.Location = New System.Drawing.Point(888, 463)
        Me.btnAddKeyWords.Name = "btnAddKeyWords"
        Me.btnAddKeyWords.Size = New System.Drawing.Size(26, 25)
        Me.btnAddKeyWords.TabIndex = 18
        Me.btnAddKeyWords.Text = "+"
        Me.btnAddKeyWords.UseVisualStyleBackColor = True
        '
        'txtKewWords
        '
        Me.txtKewWords.Location = New System.Drawing.Point(100, 465)
        Me.txtKewWords.Name = "txtKewWords"
        Me.txtKewWords.Size = New System.Drawing.Size(773, 21)
        Me.txtKewWords.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 468)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "KeyWords"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(822, 497)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 28)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(724, 497)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(92, 28)
        Me.btnOK.TabIndex = 20
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAddSeries
        '
        Me.btnAddSeries.Location = New System.Drawing.Point(888, 151)
        Me.btnAddSeries.Name = "btnAddSeries"
        Me.btnAddSeries.Size = New System.Drawing.Size(26, 25)
        Me.btnAddSeries.TabIndex = 21
        Me.btnAddSeries.Text = "+"
        Me.btnAddSeries.UseVisualStyleBackColor = True
        '
        'txtMidleName
        '
        Me.txtMidleName.Location = New System.Drawing.Point(627, 58)
        Me.txtMidleName.Name = "txtMidleName"
        Me.txtMidleName.Size = New System.Drawing.Size(246, 21)
        Me.txtMidleName.TabIndex = 22
        '
        'txtAuthLastName
        '
        Me.txtAuthLastName.FormattingEnabled = True
        Me.txtAuthLastName.Location = New System.Drawing.Point(100, 58)
        Me.txtAuthLastName.Name = "txtAuthLastName"
        Me.txtAuthLastName.Size = New System.Drawing.Size(246, 23)
        Me.txtAuthLastName.TabIndex = 23
        '
        'txtGenre
        '
        Me.txtGenre.Location = New System.Drawing.Point(101, 94)
        Me.txtGenre.Multiline = True
        Me.txtGenre.Name = "txtGenre"
        Me.txtGenre.Size = New System.Drawing.Size(771, 42)
        Me.txtGenre.TabIndex = 24
        '
        'frmEditBookInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 537)
        Me.Controls.Add(Me.txtGenre)
        Me.Controls.Add(Me.txtAuthLastName)
        Me.Controls.Add(Me.txtMidleName)
        Me.Controls.Add(Me.btnAddSeries)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddKeyWords)
        Me.Controls.Add(Me.txtKewWords)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPublisher)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAnnotation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNumOfSerie)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnAddGenre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAddAuth)
        Me.Controls.Add(Me.txtAuthFirstName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmEditBookInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmEditBookInfo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents txtAuthFirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddAuth As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnAddGenre As Button
    Friend WithEvents txtNumOfSerie As TextBox
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAnnotation As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPublisher As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddKeyWords As Button
    Friend WithEvents txtKewWords As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnAddSeries As System.Windows.Forms.Button
    Friend WithEvents txtMidleName As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthLastName As System.Windows.Forms.ComboBox
    Friend WithEvents txtGenre As System.Windows.Forms.TextBox
End Class
