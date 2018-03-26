<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditGenres
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node1")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node2")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node4")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Node3", New System.Windows.Forms.TreeNode() {TreeNode4})
        Me.trvGenre = New System.Windows.Forms.TreeView()
        Me.btnApplay = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'trvGenre
        '
        Me.trvGenre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvGenre.LabelEdit = True
        Me.trvGenre.Location = New System.Drawing.Point(0, 1)
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
        Me.trvGenre.Size = New System.Drawing.Size(381, 441)
        Me.trvGenre.TabIndex = 1
        '
        'btnApplay
        '
        Me.btnApplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnApplay.Location = New System.Drawing.Point(212, 448)
        Me.btnApplay.Name = "btnApplay"
        Me.btnApplay.Size = New System.Drawing.Size(76, 23)
        Me.btnApplay.TabIndex = 20
        Me.btnApplay.Text = "OK"
        Me.btnApplay.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(294, 448)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(76, 23)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditGenres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 477)
        Me.Controls.Add(Me.btnApplay)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.trvGenre)
        Me.Name = "frmEditGenres"
        Me.Text = "frmEditGenres"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents trvGenre As TreeView
    Friend WithEvents btnApplay As Button
    Friend WithEvents btnCancel As Button
End Class
