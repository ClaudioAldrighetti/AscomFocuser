<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbFocuser = New System.Windows.Forms.GroupBox()
        Me.bDisconnect = New System.Windows.Forms.Button()
        Me.bConnect = New System.Windows.Forms.Button()
        Me.bFocuser = New System.Windows.Forms.Button()
        Me.tbFocuser = New System.Windows.Forms.TextBox()
        Me.gbCommand = New System.Windows.Forms.GroupBox()
        Me.lTemperature = New System.Windows.Forms.Label()
        Me.tbTemperature = New System.Windows.Forms.TextBox()
        Me.lMaxPos = New System.Windows.Forms.Label()
        Me.tbMaxPos = New System.Windows.Forms.TextBox()
        Me.tbPosition = New System.Windows.Forms.TextBox()
        Me.lPosition = New System.Windows.Forms.Label()
        Me.cbReverse = New System.Windows.Forms.CheckBox()
        Me.bSTOP = New System.Windows.Forms.Button()
        Me.bGOTO = New System.Windows.Forms.Button()
        Me.tbInsert = New System.Windows.Forms.TextBox()
        Me.bOUT = New System.Windows.Forms.Button()
        Me.bIN = New System.Windows.Forms.Button()
        Me.gbFocuser.SuspendLayout()
        Me.gbCommand.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbFocuser
        '
        Me.gbFocuser.Controls.Add(Me.bDisconnect)
        Me.gbFocuser.Controls.Add(Me.bConnect)
        Me.gbFocuser.Controls.Add(Me.bFocuser)
        Me.gbFocuser.Controls.Add(Me.tbFocuser)
        Me.gbFocuser.Location = New System.Drawing.Point(6, 6)
        Me.gbFocuser.Name = "gbFocuser"
        Me.gbFocuser.Size = New System.Drawing.Size(157, 102)
        Me.gbFocuser.TabIndex = 0
        Me.gbFocuser.TabStop = False
        Me.gbFocuser.Text = "Focuser"
        '
        'bDisconnect
        '
        Me.bDisconnect.Enabled = False
        Me.bDisconnect.Location = New System.Drawing.Point(6, 73)
        Me.bDisconnect.Name = "bDisconnect"
        Me.bDisconnect.Size = New System.Drawing.Size(145, 23)
        Me.bDisconnect.TabIndex = 3
        Me.bDisconnect.TabStop = False
        Me.bDisconnect.Text = "Disconnect"
        Me.bDisconnect.UseVisualStyleBackColor = True
        '
        'bConnect
        '
        Me.bConnect.Location = New System.Drawing.Point(81, 45)
        Me.bConnect.Name = "bConnect"
        Me.bConnect.Size = New System.Drawing.Size(70, 23)
        Me.bConnect.TabIndex = 2
        Me.bConnect.Text = "Connect"
        Me.bConnect.UseVisualStyleBackColor = True
        '
        'bFocuser
        '
        Me.bFocuser.Location = New System.Drawing.Point(6, 45)
        Me.bFocuser.Name = "bFocuser"
        Me.bFocuser.Size = New System.Drawing.Size(69, 23)
        Me.bFocuser.TabIndex = 1
        Me.bFocuser.Text = "Choose"
        Me.bFocuser.UseVisualStyleBackColor = True
        '
        'tbFocuser
        '
        Me.tbFocuser.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.AscomFocuser.My.MySettings.Default, "Focuser", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbFocuser.Location = New System.Drawing.Point(6, 19)
        Me.tbFocuser.Name = "tbFocuser"
        Me.tbFocuser.ReadOnly = True
        Me.tbFocuser.Size = New System.Drawing.Size(145, 20)
        Me.tbFocuser.TabIndex = 0
        Me.tbFocuser.TabStop = False
        Me.tbFocuser.Text = Global.AscomFocuser.My.MySettings.Default.Focuser
        '
        'gbCommand
        '
        Me.gbCommand.Controls.Add(Me.lTemperature)
        Me.gbCommand.Controls.Add(Me.tbTemperature)
        Me.gbCommand.Controls.Add(Me.lMaxPos)
        Me.gbCommand.Controls.Add(Me.tbMaxPos)
        Me.gbCommand.Controls.Add(Me.tbPosition)
        Me.gbCommand.Controls.Add(Me.lPosition)
        Me.gbCommand.Controls.Add(Me.cbReverse)
        Me.gbCommand.Controls.Add(Me.bSTOP)
        Me.gbCommand.Controls.Add(Me.bGOTO)
        Me.gbCommand.Controls.Add(Me.tbInsert)
        Me.gbCommand.Controls.Add(Me.bOUT)
        Me.gbCommand.Controls.Add(Me.bIN)
        Me.gbCommand.Enabled = False
        Me.gbCommand.Location = New System.Drawing.Point(6, 115)
        Me.gbCommand.Name = "gbCommand"
        Me.gbCommand.Size = New System.Drawing.Size(156, 168)
        Me.gbCommand.TabIndex = 1
        Me.gbCommand.TabStop = False
        Me.gbCommand.Text = "Command"
        '
        'lTemperature
        '
        Me.lTemperature.AutoSize = True
        Me.lTemperature.Location = New System.Drawing.Point(3, 145)
        Me.lTemperature.Name = "lTemperature"
        Me.lTemperature.Size = New System.Drawing.Size(67, 13)
        Me.lTemperature.TabIndex = 15
        Me.lTemperature.Text = "Temperature"
        '
        'tbTemperature
        '
        Me.tbTemperature.Location = New System.Drawing.Point(103, 142)
        Me.tbTemperature.Name = "tbTemperature"
        Me.tbTemperature.ReadOnly = True
        Me.tbTemperature.Size = New System.Drawing.Size(48, 20)
        Me.tbTemperature.TabIndex = 14
        Me.tbTemperature.TabStop = False
        '
        'lMaxPos
        '
        Me.lMaxPos.AutoSize = True
        Me.lMaxPos.Location = New System.Drawing.Point(3, 122)
        Me.lMaxPos.Name = "lMaxPos"
        Me.lMaxPos.Size = New System.Drawing.Size(94, 13)
        Me.lMaxPos.TabIndex = 13
        Me.lMaxPos.Text = "Maximum Position:"
        '
        'tbMaxPos
        '
        Me.tbMaxPos.Location = New System.Drawing.Point(103, 119)
        Me.tbMaxPos.Name = "tbMaxPos"
        Me.tbMaxPos.ReadOnly = True
        Me.tbMaxPos.Size = New System.Drawing.Size(48, 20)
        Me.tbMaxPos.TabIndex = 12
        Me.tbMaxPos.TabStop = False
        '
        'tbPosition
        '
        Me.tbPosition.Location = New System.Drawing.Point(103, 93)
        Me.tbPosition.Name = "tbPosition"
        Me.tbPosition.ReadOnly = True
        Me.tbPosition.Size = New System.Drawing.Size(48, 20)
        Me.tbPosition.TabIndex = 11
        Me.tbPosition.TabStop = False
        '
        'lPosition
        '
        Me.lPosition.AutoSize = True
        Me.lPosition.Location = New System.Drawing.Point(3, 96)
        Me.lPosition.Name = "lPosition"
        Me.lPosition.Size = New System.Drawing.Size(84, 13)
        Me.lPosition.TabIndex = 10
        Me.lPosition.Text = "Current Position:"
        '
        'cbReverse
        '
        Me.cbReverse.AutoSize = True
        Me.cbReverse.Location = New System.Drawing.Point(6, 76)
        Me.cbReverse.Name = "cbReverse"
        Me.cbReverse.Size = New System.Drawing.Size(66, 17)
        Me.cbReverse.TabIndex = 9
        Me.cbReverse.TabStop = False
        Me.cbReverse.Text = "Reverse"
        Me.cbReverse.UseVisualStyleBackColor = True
        '
        'bSTOP
        '
        Me.bSTOP.Enabled = False
        Me.bSTOP.Location = New System.Drawing.Point(81, 47)
        Me.bSTOP.Name = "bSTOP"
        Me.bSTOP.Size = New System.Drawing.Size(70, 23)
        Me.bSTOP.TabIndex = 8
        Me.bSTOP.TabStop = False
        Me.bSTOP.Text = "STOP"
        Me.bSTOP.UseVisualStyleBackColor = True
        '
        'bGOTO
        '
        Me.bGOTO.Location = New System.Drawing.Point(6, 47)
        Me.bGOTO.Name = "bGOTO"
        Me.bGOTO.Size = New System.Drawing.Size(69, 23)
        Me.bGOTO.TabIndex = 7
        Me.bGOTO.Text = "GO TO"
        Me.bGOTO.UseVisualStyleBackColor = True
        '
        'tbInsert
        '
        Me.tbInsert.Location = New System.Drawing.Point(57, 21)
        Me.tbInsert.Name = "tbInsert"
        Me.tbInsert.Size = New System.Drawing.Size(41, 20)
        Me.tbInsert.TabIndex = 4
        '
        'bOUT
        '
        Me.bOUT.Location = New System.Drawing.Point(104, 19)
        Me.bOUT.Name = "bOUT"
        Me.bOUT.Size = New System.Drawing.Size(47, 23)
        Me.bOUT.TabIndex = 6
        Me.bOUT.Text = "OUT"
        Me.bOUT.UseVisualStyleBackColor = True
        '
        'bIN
        '
        Me.bIN.Location = New System.Drawing.Point(6, 19)
        Me.bIN.Name = "bIN"
        Me.bIN.Size = New System.Drawing.Size(45, 23)
        Me.bIN.TabIndex = 5
        Me.bIN.Text = "IN"
        Me.bIN.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(167, 284)
        Me.Controls.Add(Me.gbCommand)
        Me.Controls.Add(Me.gbFocuser)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(183, 322)
        Me.MinimumSize = New System.Drawing.Size(183, 322)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Focuser Settings"
        Me.gbFocuser.ResumeLayout(False)
        Me.gbFocuser.PerformLayout()
        Me.gbCommand.ResumeLayout(False)
        Me.gbCommand.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbFocuser As GroupBox
    Friend WithEvents bConnect As Button
    Friend WithEvents bFocuser As Button
    Friend WithEvents tbFocuser As TextBox
    Friend WithEvents bDisconnect As Button
    Friend WithEvents gbCommand As GroupBox
    Friend WithEvents bSTOP As Button
    Friend WithEvents bGOTO As Button
    Friend WithEvents tbInsert As TextBox
    Friend WithEvents bOUT As Button
    Friend WithEvents bIN As Button
    Friend WithEvents lTemperature As Label
    Friend WithEvents tbTemperature As TextBox
    Friend WithEvents lMaxPos As Label
    Friend WithEvents tbMaxPos As TextBox
    Friend WithEvents tbPosition As TextBox
    Friend WithEvents lPosition As Label
    Friend WithEvents cbReverse As CheckBox
End Class
