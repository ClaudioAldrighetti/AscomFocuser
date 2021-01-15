Public Class Form1

    ' Focuser object
    Private oFocuser As ASCOM.DriverAccess.Focuser

    ' Timers
    Private WithEvents dataTimer As New Timer With {
            .Interval = 500
        }
    Private WithEvents movingTimer As New Timer With {
            .Interval = 100
        }

    Private isAbsolute As Boolean

    ' Decimal digits to represent temperature
    Private Const temprDD As Integer = 2

    ' Main window
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbFocuser.Text = "Choose Focuser..."
    End Sub

    ' Focuser choose button
    Private Sub BFocuser_Click(sender As Object, e As EventArgs) Handles bFocuser.Click

        ' Set Chooser as a Focuser Chooser
        Dim chs As New ASCOM.Utilities.Chooser With {
           .DeviceType = "Focuser"
        }

        ' Retrive Focuser via ASCOM choose dialog
        My.Settings.Focuser = chs.Choose(My.Settings.Focuser)
    End Sub

    ' Focuser connect button
    Private Sub BConnect_Click(sender As Object, e As EventArgs) Handles bConnect.Click
        If (Not ((My.Settings.Focuser Is Nothing) Or (My.Settings.Focuser.Length < 1) Or (tbFocuser.Text = "Choose Focuser..."))) Then
            ' Connect choosen Focuser
            oFocuser = New ASCOM.DriverAccess.Focuser(My.Settings.Focuser)
            oFocuser.Connected = True

            ' Enable and disable things
            sender.enabled = False
            bFocuser.Enabled = False
            bDisconnect.Enabled = True
            gbCommand.Enabled = True
            tbInsert.Text = ""
            tbPosition.Text = oFocuser.Position
            tbMaxPos.Text = oFocuser.MaxStep
            tbTemperature.Text = Math.Round(oFocuser.Temperature, temprDD)

            ' Absolute/Relative positioning Focuser
            isAbsolute = oFocuser.Absolute

            ' Timer used to update informations
            dataTimer.Start()
        Else
            MessageBox.Show("Choose a focuser before performing connection.", "Missing focuser", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Focuser disconnect button
    Private Sub BDisconnect_Click(sender As Object, e As EventArgs) Handles bDisconnect.Click

        ' Disconnect Focuser
        oFocuser.Connected = False
        oFocuser = Nothing

        ' Enable and disable things
        sender.enabled = False
        bFocuser.Enabled = True
        bConnect.Enabled = True
        gbCommand.Enabled = False
        tbInsert.Clear()
        tbPosition.Clear()
        tbMaxPos.Clear()
        tbTemperature.Clear()

        dataTimer.Stop()
        movingTimer.Stop()
    End Sub

    ' Update data
    Private Sub DATATIMER_Tick(sender As Object, e As EventArgs) Handles dataTimer.Tick
        tbPosition.Text = oFocuser.Position
        tbTemperature.Text = Math.Round(oFocuser.Temperature, temprDD)
    End Sub

    ' Container method for IN
    Private Sub BIN_Click(sender As Object, e As EventArgs) Handles bIN.Click
        ' Check numerical input and absolute positioning
        Dim numCheck As Boolean = checkTBInsert()
        If (numCheck And isAbsolute) Then
            ' Check reverse choice
            If (cbReverse.Checked) Then
                auxOUT()
            Else
                auxIN()
            End If
        ElseIf (Not isAbsolute) Then
            MessageBox.Show("Focuser must have absolute positioning." & Environment.NewLine & "Please disconnect and set it using ASCOM chooser dialog.", "Absolute positioning is needed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (Not numCheck) Then
            MessageBox.Show("Number of steps wasn't been recognized or it's negative." & Environment.NewLine & "Please insert a positive valid value to perform IN.", "Number of steps unrecognized", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Container method for OUT
    Private Sub BOUT_Click(sender As Object, e As EventArgs) Handles bOUT.Click
        ' Check numerical input and absolute positioning
        Dim numCheck As Boolean = checkTBInsert()
        If (numCheck And isAbsolute) Then
            ' Check reverse choice
            If (cbReverse.Checked) Then
                auxIN()
            Else
                auxOUT()
            End If

        ElseIf (Not isAbsolute) Then
            MessageBox.Show("Focuser must have absolute positioning." & Environment.NewLine & "Please disconnect and set it using ASCOM chooser dialog.", "Absolute positioning is needed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (Not numCheck) Then
            MessageBox.Show("Number of steps wasn't been recognized or it's negative." & Environment.NewLine & "Please insert a positive valid value to perform OUT.", "Number of steps unrecognized", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Perform IN function
    Private Sub auxIN()
        ' New position
        Dim inSteps As Integer = CInt(tbInsert.Text) ' inSteps is positive because of checkTBInsert()
        Dim newPos As Integer = oFocuser.Position - inSteps

        ' Check if new position is valid and no other movements are being performed
        If ((newPos >= 0) And Not oFocuser.IsMoving) Then
            moveFocuser(newPos)
        ElseIf (newPos < 0) Then
            MessageBox.Show("New computed position exceed the minimum allowed position for the focuser." & Environment.NewLine & "Please insert a lesser number of steps.", "Unreachable target position", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (oFocuser.IsMoving) Then
            MessageBox.Show("Can't perform a new movement while focuser is arleady moving.", "Focuser is already moving", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Perform OUT function
    Private Sub auxOUT()
        ' New position
        Dim outSteps As Integer = CInt(tbInsert.Text) ' outSteps is positive because of checkTBInsert()
        Dim newPos As Integer = oFocuser.Position + outSteps

        ' Check if new position is valid and no other movements are being performed
        If ((newPos <= oFocuser.MaxStep) And Not oFocuser.IsMoving) Then
            moveFocuser(newPos)
        ElseIf (newPos > oFocuser.MaxStep) Then
            MessageBox.Show("New computed position exceed the maximum allowed position for the focuser." & Environment.NewLine & "Please insert a lesser number of steps.", "Unreachable target position", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (oFocuser.IsMoving) Then
            MessageBox.Show("Can't perform a new movement while focuser is arleady moving.", "Focuser is already moving", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' Perform GOTO function
    Private Sub bGOTO_Click(sender As Object, e As EventArgs) Handles bGOTO.Click
        ' Check numerical input and absolute positioning
        Dim numCheck As Boolean = checkTBInsert()
        If (checkTBInsert() And isAbsolute) Then
            ' New position
            Dim newPos As Integer = CInt(tbInsert.Text) ' newPos is positive because of checkTBInsert()

            ' Check if new position is valid and no other movements are being performed
            If ((newPos <= oFocuser.MaxStep) And Not oFocuser.IsMoving) Then
                moveFocuser(newPos)

            ElseIf (newPos > oFocuser.MaxStep) Then
                MessageBox.Show("New position exceed the maximum allowed position for the focuser." & Environment.NewLine & "Please insert a position value lesser than " & oFocuser.MaxStep & ".", "Unreachable target position", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (oFocuser.IsMoving) Then
                MessageBox.Show("Can't perform a new movement while focuser is arleady moving.", "Focuser is already moving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf (Not isAbsolute) Then
            MessageBox.Show("Focuser must have absolute positioning." & Environment.NewLine & "Please disconnect and set it using ASCOM chooser dialog.", "Absolute positioning is needed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf (Not numCheck) Then
            MessageBox.Show("Position value wasn't been recognized or it's negative." & Environment.NewLine & "Please insert a positive valid value to perform GOTO.", "Position unrecognized", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub moveFocuser(newPos As Integer)
        oFocuser.Move(newPos)

        ' Disable movement options
        bIN.Enabled = False
        bOUT.Enabled = False
        bGOTO.Enabled = False
        cbReverse.Enabled = False
        bDisconnect.Enabled = False
        bSTOP.Enabled = True

        movingTimer.Start()
    End Sub

    Private Sub MOVINGTIMER_Tick(sender As Object, e As EventArgs) Handles movingTimer.Tick
        ' Check if Focuser is no longer moving
        If (Not oFocuser.IsMoving) Then
            ' Enable movement options
            bIN.Enabled = True
            bOUT.Enabled = True
            bGOTO.Enabled = True
            cbReverse.Enabled = True
            bDisconnect.Enabled = True
            bSTOP.Enabled = False

            movingTimer.Stop()
        End If
    End Sub

    ' STOP button
    Private Sub bSTOP_Click(sender As Object, e As EventArgs) Handles bSTOP.Click
        If (oFocuser.IsMoving) Then
            oFocuser.Halt()
        End If
    End Sub

    ' Check if tbInsert.Text contains a positive number
    Private Function checkTBInsert() As Boolean
        If (tbInsert.Text.Length > 0) Then
            Dim text As Char() = tbInsert.Text.ToCharArray
            For i = 0 To (tbInsert.Text.Length - 1)
                If (Asc(text(i)) < 48 Or Asc(text(i)) > 57) Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False
    End Function

End Class
