<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.gbxBS = New System.Windows.Forms.GroupBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.lblRow = New System.Windows.Forms.Label()
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.lblCol = New System.Windows.Forms.Label()
        Me.gbxMC = New System.Windows.Forms.GroupBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbxBS.SuspendLayout()
        Me.gbxMC.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxBS
        '
        Me.gbxBS.Controls.Add(Me.txtRow)
        Me.gbxBS.Controls.Add(Me.lblRow)
        Me.gbxBS.Controls.Add(Me.txtCol)
        Me.gbxBS.Controls.Add(Me.lblCol)
        Me.gbxBS.Location = New System.Drawing.Point(52, 49)
        Me.gbxBS.Name = "gbxBS"
        Me.gbxBS.Size = New System.Drawing.Size(227, 258)
        Me.gbxBS.TabIndex = 0
        Me.gbxBS.TabStop = False
        Me.gbxBS.Text = "Board size"
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(111, 147)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(58, 21)
        Me.txtRow.TabIndex = 4
        '
        'lblRow
        '
        Me.lblRow.AutoSize = True
        Me.lblRow.Location = New System.Drawing.Point(76, 153)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(29, 12)
        Me.lblRow.TabIndex = 3
        Me.lblRow.Text = "Rows"
        '
        'txtCol
        '
        Me.txtCol.Location = New System.Drawing.Point(111, 90)
        Me.txtCol.Name = "txtCol"
        Me.txtCol.Size = New System.Drawing.Size(58, 21)
        Me.txtCol.TabIndex = 2
        '
        'lblCol
        '
        Me.lblCol.AutoSize = True
        Me.lblCol.Location = New System.Drawing.Point(58, 93)
        Me.lblCol.Name = "lblCol"
        Me.lblCol.Size = New System.Drawing.Size(47, 12)
        Me.lblCol.TabIndex = 0
        Me.lblCol.Text = "Columns"
        '
        'gbxMC
        '
        Me.gbxMC.Controls.Add(Me.txtNum)
        Me.gbxMC.Controls.Add(Me.lblNum)
        Me.gbxMC.Location = New System.Drawing.Point(288, 49)
        Me.gbxMC.Name = "gbxMC"
        Me.gbxMC.Size = New System.Drawing.Size(227, 258)
        Me.gbxMC.TabIndex = 1
        Me.gbxMC.TabStop = False
        Me.gbxMC.Text = "Mines count"
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(108, 119)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(58, 21)
        Me.txtNum.TabIndex = 4
        '
        'lblNum
        '
        Me.lblNum.AutoSize = True
        Me.lblNum.Location = New System.Drawing.Point(61, 125)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(41, 12)
        Me.lblNum.TabIndex = 3
        Me.lblNum.Text = "Number"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(110, 341)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(347, 41)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK - Empty means default"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 450)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.gbxMC)
        Me.Controls.Add(Me.gbxBS)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfig"
        Me.Text = "Configure Game"
        Me.gbxBS.ResumeLayout(False)
        Me.gbxBS.PerformLayout()
        Me.gbxMC.ResumeLayout(False)
        Me.gbxMC.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbxBS As GroupBox
    Friend WithEvents gbxMC As GroupBox
    Friend WithEvents btnOK As Button
    Friend WithEvents txtCol As TextBox
    Friend WithEvents lblCol As Label
    Friend WithEvents txtRow As TextBox
    Friend WithEvents lblRow As Label
    Friend WithEvents txtNum As TextBox
    Friend WithEvents lblNum As Label
End Class
