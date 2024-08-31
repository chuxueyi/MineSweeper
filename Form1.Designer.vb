<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.gbxMC = New System.Windows.Forms.GroupBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.gbxBS = New System.Windows.Forms.GroupBox()
        Me.txtRow = New System.Windows.Forms.TextBox()
        Me.lblRow = New System.Windows.Forms.Label()
        Me.txtCol = New System.Windows.Forms.TextBox()
        Me.lblCol = New System.Windows.Forms.Label()
        Me.gbxMC.SuspendLayout()
        Me.gbxBS.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(273, 325)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(234, 71)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'gbxMC
        '
        Me.gbxMC.Controls.Add(Me.txtNum)
        Me.gbxMC.Controls.Add(Me.lblNum)
        Me.gbxMC.Location = New System.Drawing.Point(405, 28)
        Me.gbxMC.Name = "gbxMC"
        Me.gbxMC.Size = New System.Drawing.Size(227, 258)
        Me.gbxMC.TabIndex = 3
        Me.gbxMC.TabStop = False
        Me.gbxMC.Text = "Mines count"
        '
        'txtNum
        '
        Me.txtNum.Location = New System.Drawing.Point(108, 119)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(58, 21)
        Me.txtNum.TabIndex = 4
        Me.txtNum.Text = "15"
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
        'gbxBS
        '
        Me.gbxBS.Controls.Add(Me.txtRow)
        Me.gbxBS.Controls.Add(Me.lblRow)
        Me.gbxBS.Controls.Add(Me.txtCol)
        Me.gbxBS.Controls.Add(Me.lblCol)
        Me.gbxBS.Location = New System.Drawing.Point(148, 28)
        Me.gbxBS.Name = "gbxBS"
        Me.gbxBS.Size = New System.Drawing.Size(227, 258)
        Me.gbxBS.TabIndex = 2
        Me.gbxBS.TabStop = False
        Me.gbxBS.Text = "Board size"
        '
        'txtRow
        '
        Me.txtRow.Location = New System.Drawing.Point(111, 147)
        Me.txtRow.Name = "txtRow"
        Me.txtRow.Size = New System.Drawing.Size(58, 21)
        Me.txtRow.TabIndex = 4
        Me.txtRow.Text = "10"
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
        Me.txtCol.Text = "10"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gbxMC)
        Me.Controls.Add(Me.gbxBS)
        Me.Controls.Add(Me.btnPlay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "MineSweeper"
        Me.TopMost = True
        Me.gbxMC.ResumeLayout(False)
        Me.gbxMC.PerformLayout()
        Me.gbxBS.ResumeLayout(False)
        Me.gbxBS.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPlay As Button
    Friend WithEvents gbxMC As GroupBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents lblNum As Label
    Friend WithEvents gbxBS As GroupBox
    Friend WithEvents txtRow As TextBox
    Friend WithEvents lblRow As Label
    Friend WithEvents txtCol As TextBox
    Friend WithEvents lblCol As Label
End Class
