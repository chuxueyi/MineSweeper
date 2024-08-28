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
        Me.mnSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnEasy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnNotEasy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCfgSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnNumSggsted = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCfgNum = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnConfig = New System.Windows.Forms.MenuStrip()
        Me.mnConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(283, 173)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(234, 104)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'mnSize
        '
        Me.mnSize.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnEasy, Me.mnNotEasy, Me.mnCfgSize})
        Me.mnSize.Name = "mnSize"
        Me.mnSize.Size = New System.Drawing.Size(115, 20)
        Me.mnSize.Text = "Choose board size"
        '
        'mnEasy
        '
        Me.mnEasy.Name = "mnEasy"
        Me.mnEasy.Size = New System.Drawing.Size(180, 22)
        Me.mnEasy.Text = "Easy 10*10"
        '
        'mnNotEasy
        '
        Me.mnNotEasy.Name = "mnNotEasy"
        Me.mnNotEasy.Size = New System.Drawing.Size(180, 22)
        Me.mnNotEasy.Text = "Not Easy 20*20"
        '
        'mnCfgSize
        '
        Me.mnCfgSize.Name = "mnCfgSize"
        Me.mnCfgSize.Size = New System.Drawing.Size(180, 22)
        Me.mnCfgSize.Text = "Configure"
        '
        'mnNum
        '
        Me.mnNum.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnNumSggsted, Me.mnCfgNum})
        Me.mnNum.Name = "mnNum"
        Me.mnNum.Size = New System.Drawing.Size(136, 20)
        Me.mnNum.Text = "Type in mines number"
        '
        'mnNumSggsted
        '
        Me.mnNumSggsted.Name = "mnNumSggsted"
        Me.mnNumSggsted.Size = New System.Drawing.Size(233, 22)
        Me.mnNumSggsted.Text = "Suggested - reduce in guesses"
        '
        'mnCfgNum
        '
        Me.mnCfgNum.Name = "mnCfgNum"
        Me.mnCfgNum.Size = New System.Drawing.Size(233, 22)
        Me.mnCfgNum.Text = "Configure"
        '
        'mnConfig
        '
        Me.mnConfig.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSize, Me.mnNum})
        Me.mnConfig.Location = New System.Drawing.Point(0, 0)
        Me.mnConfig.Name = "mnConfig"
        Me.mnConfig.Size = New System.Drawing.Size(800, 24)
        Me.mnConfig.TabIndex = 0
        Me.mnConfig.Text = "MenuStrip1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.mnConfig)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnConfig
        Me.Name = "Form1"
        Me.Text = "MineSweeper"
        Me.TopMost = True
        Me.mnConfig.ResumeLayout(False)
        Me.mnConfig.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPlay As Button
    Friend WithEvents mnSize As ToolStripMenuItem
    Friend WithEvents mnEasy As ToolStripMenuItem
    Friend WithEvents mnNotEasy As ToolStripMenuItem
    Friend WithEvents mnCfgSize As ToolStripMenuItem
    Friend WithEvents mnNum As ToolStripMenuItem
    Friend WithEvents mnNumSggsted As ToolStripMenuItem
    Friend WithEvents mnCfgNum As ToolStripMenuItem
    Friend WithEvents mnConfig As MenuStrip
End Class
