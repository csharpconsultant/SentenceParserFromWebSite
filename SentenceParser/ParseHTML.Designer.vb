<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParseHTML
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
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnParseHtml = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grdViewSentences = New System.Windows.Forms.DataGridView()
        CType(Me.grdViewSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(25, 36)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(410, 20)
        Me.txtURL.TabIndex = 0
        Me.txtURL.Text = "http://www.sec.gov/Archives/edgar/data/100493/000119312510265708/d10k.htm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(288, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter URL To Retrieve Text From Or Browse For HTML File"
        '
        'btnParseHtml
        '
        Me.btnParseHtml.Location = New System.Drawing.Point(360, 105)
        Me.btnParseHtml.Name = "btnParseHtml"
        Me.btnParseHtml.Size = New System.Drawing.Size(75, 23)
        Me.btnParseHtml.TabIndex = 2
        Me.btnParseHtml.Text = "Parse HTML"
        Me.btnParseHtml.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(158, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 4
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(442, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Browse For File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grdViewSentences
        '
        Me.grdViewSentences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdViewSentences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdViewSentences.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdViewSentences.Location = New System.Drawing.Point(0, 147)
        Me.grdViewSentences.MultiSelect = False
        Me.grdViewSentences.Name = "grdViewSentences"
        Me.grdViewSentences.Size = New System.Drawing.Size(759, 266)
        Me.grdViewSentences.TabIndex = 6
        '
        'ParseHTML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 413)
        Me.Controls.Add(Me.grdViewSentences)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnParseHtml)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtURL)
        Me.Name = "ParseHTML"
        Me.Text = "HTML Sentence Parsing Utility"
        CType(Me.grdViewSentences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnParseHtml As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents grdViewSentences As System.Windows.Forms.DataGridView

End Class
