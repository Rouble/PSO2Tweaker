﻿Imports DevComponents.DotNetBar
Imports System.Threading
Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Net

Public Class frmOptions
    Declare Auto Function ShellExecute Lib "shell32.dll" (ByVal hwnd As IntPtr, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As UInteger) As IntPtr
    Dim Loading As Boolean
    Dim DPISetting As String
    Private Sub frmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim tempstring As String = frmMain.LoadSetting("Locale")
        If cmbLanguage.SelectedIndex = 0 Then
            'English
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en")
            frmMain.SaveSetting("Locale", "en")
        End If
        If cmbLanguage.SelectedIndex = 1 Then
            'French
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fr")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("fr")
            frmMain.SaveSetting("Locale", "fr")
        End If
        If cmbLanguage.SelectedIndex = 2 Then
            'German
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("de")
            frmMain.SaveSetting("Locale", "de")
        End If
        If cmbLanguage.SelectedIndex = 3 Then
            'Japanese
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("ja")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ja")
            frmMain.SaveSetting("Locale", "ja")
        End If
        If cmbLanguage.SelectedIndex = 4 Then
            'Portuguese
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("pt")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("pt")
            frmMain.SaveSetting("Locale", "pt")
        End If
        If cmbLanguage.SelectedIndex = 5 Then
            'Russian
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("ru")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ru")
            frmMain.SaveSetting("Locale", "ru")
        End If
        If cmbLanguage.SelectedIndex = 6 Then
            'Spanish
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es")
            frmMain.SaveSetting("Locale", "es")
        End If
        If cmbLanguage.SelectedIndex = 7 Then
            'Spanish
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es")
            frmMain.SaveSetting("Locale", "pl")
        End If
        ' Dim RestartYesNo As MsgBoxResult = MsgBox("The program will now restart in the selected language. Hit Cancel if you don't want to restart now.", MsgBoxStyle.OkCancel)
        ' If RestartYesNo = MsgBoxResult.Ok Then
        '    frmMain.CancelDownloadToolStripMenuItem.PerformClick()
        '    If File.Exists("launcherlist.txt") = True Then File.Delete("launcherlist.txt")
        '    If File.Exists("patchlist.txt") = True Then File.Delete("patchlist.txt")
        '    If File.Exists("patchlist_old.txt") = True Then File.Delete("patchlist_old.txt")
        '    If File.Exists("version.ver") = True Then File.Delete("version.ver")
        '    If File.Exists("ALLOFTHETHINGS.txt") = True Then File.Delete("ALLOFTHETHINGS.txt")
        '    If File.Exists("SOMEOFTHETHINGS.txt") = True Then File.Delete("SOMEOFTHETHINGS.txt")
        '    Application.Restart()
        'End If
        Me.CMBStyle.SelectedIndex = -1
    End Sub
    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Loading = True
            If frmMain.LoadSetting("Color") <> "" Then ColorPickerButton1.SelectedColor = Color.FromArgb(frmMain.LoadSetting("Color"))
            If frmMain.LoadSetting("FontColor") <> "" Then ColorPickerButton2.SelectedColor = Color.FromArgb(frmMain.LoadSetting("FontColor"))
            If frmMain.LoadSetting("TextBoxBGColor") <> "" Then ColorPickerButton4.SelectedColor = Color.FromArgb(frmMain.LoadSetting("TextboxBGColor"))
            If frmMain.LoadSetting("TextBoxColor") <> "" Then ColorPickerButton3.SelectedColor = Color.FromArgb(frmMain.LoadSetting("TextboxColor"))
            If frmMain.LoadSetting("Backup") <> "" Then
                If frmMain.LoadSetting("Backup") = "Ask" Then cmbBackupPreference.Text = "Ask every time"
                If frmMain.LoadSetting("Backup") = "Always" Then cmbBackupPreference.Text = "Always backup"
                If frmMain.LoadSetting("Backup") = "Never" Then cmbBackupPreference.Text = "Never backup"
            End If
            If frmMain.LoadSetting("PredownloadedRAR") <> "" Then
                If frmMain.LoadSetting("PredownloadedRAR") = "Ask" Then cmbPredownload.Text = "Ask every time"
                If frmMain.LoadSetting("PredownloadedRAR") = "Always" Then cmbPredownload.Text = "Always backup"
                If frmMain.LoadSetting("PredownloadedRAR") = "Never" Then cmbPredownload.Text = "Never backup"
            End If
            Dim g As Graphics = Me.CreateGraphics
            If g.DpiX.ToString = "120" Then
                DPISetting = "120"
            End If
            If g.DpiX.ToString = "96" Then
                DPISetting = "96"
            End If
            g.Dispose()
            If DPISetting = "96" Then Me.Size = New Size(440, 451)
            If DPISetting = "120" Then Me.Size = New Size(583, 554)
            If frmMain.LoadSetting("Locale") = "" Then
                cmbLanguage.Text = "English"
            End If
            If frmMain.LoadSetting("Locale") = "en" Then
                cmbLanguage.Text = "English"
            End If
            If frmMain.LoadSetting("Locale") = "fr" Then
                cmbLanguage.Text = "French"
            End If
            If frmMain.LoadSetting("Locale") = "de" Then
                cmbLanguage.Text = "German"
            End If
            If frmMain.LoadSetting("Locale") = "ja" Then
                cmbLanguage.Text = "Japanese"
            End If
            If frmMain.LoadSetting("Locale") = "pt" Then
                cmbLanguage.Text = "Portuguese"
            End If
            If frmMain.LoadSetting("Locale") = "ru" Then
                cmbLanguage.Text = "Russian"
            End If
            If frmMain.LoadSetting("Locale") = "es" Then
                cmbLanguage.Text = "Spanish"
            End If
            If frmMain.LoadSetting("Locale") = "pl" Then
                cmbLanguage.Text = "Polish"
            End If
            If frmMain.LoadSetting("Locale") <> "" Then
                Dim Locale As String = frmMain.LoadSetting("Locale")
                Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Locale)
                Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo(Locale)
            End If
            LabelX1.Text = My.Resources.strChooseATheme
            LabelX2.Text = My.Resources.strChooseALanguage
            LabelX3.Text = My.Resources.strChooseABackgroundImage
            'Me.BackgroundImage = Nothing
            CheckBoxX1.Checked = frmMain.LoadSetting("Pastebin")
            CheckBoxX2.Checked = frmMain.LoadSetting("ENPatchAfterInstall")
            CheckBoxX3.Checked = frmMain.LoadSetting("LargeFilesAfterInstall")
            CheckBoxX4.Checked = frmMain.LoadSetting("StoryPatchAfterInstall")
            CheckBoxX5.Checked = frmMain.LoadSetting("SidebarEnabled")
            chkAutoRemoveCensor.Checked = frmMain.LoadSetting("RemoveCensor")
            CMBStyle.Text = frmMain.LoadSetting("Style")
            ComboItem33.Text = "Last installed: " & frmMain.LoadSetting("StoryPatchVersion")
            ComboItem33.Text = "Latest version: " & frmMain.LoadSetting("NewStoryVersion")
            ComboItem35.Text = "Last installed: " & frmMain.LoadSetting("ENPatchVersion")
            ComboItem36.Text = "Latest version: " & frmMain.LoadSetting("NewENVersion")
            ComboItem40.Text = "Last installed: " & frmMain.LoadSetting("LargeFilesVersion")
            ComboItem42.Text = "Latest version: " & frmMain.LoadSetting("NewLargeFilesVersion")
            Loading = False
        Catch ex As Exception
            frmMain.Log(ex.Message)
            frmMain.WriteDebugInfo(My.Resources.strERROR & ex.Message)
        End Try
    End Sub

    Private Sub CMBStyle_SelectedValueChanged(sender As Object, e As EventArgs) Handles CMBStyle.SelectedValueChanged
        'WHAT IN THE FUCK IS GOING ON HERE
        '(╯°□°)╯︵ ┻━┻
        If CMBStyle.Text = "Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
            frmMain.SaveSetting("Style", "Blue")
        End If
        If CMBStyle.Text = "Silver" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver
            frmMain.SaveSetting("Style", "Silver")
        End If
        If CMBStyle.Text = "Black" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Black
            frmMain.SaveSetting("Style", "Black")
        End If
        If CMBStyle.Text = "Vista Glass" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007VistaGlass
            frmMain.SaveSetting("Style", "Vista Glass")
        End If
        If CMBStyle.Text = "2010 Silver" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Silver
            frmMain.SaveSetting("Style", "2010 Silver")
        End If
        If CMBStyle.Text = "Windows 7 Blue" Then
            StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Windows7Blue
            frmMain.SaveSetting("Style", "Windows 7 Blue")
        End If
        'If CMBStyle.SelectedText = "Black" Then Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black
        'If CMBStyle.SelectedText = "Blue" Then Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue
        'If CMBStyle.SelectedText = "Silver" Then Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver
        'If CMBStyle.SelectedText = "Vista Glass" Then Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass
        'If CMBStyle.SelectedIndex <> -1 Then MsgBox("Style applied and saved!")
        'Me.Refresh()
        '┻━┻ ︵ \(Ò_Ó \)
        '(╯°□°）╯︵ /(.□. \)
        '┯━┯ノ(º₋ºノ)
    End Sub

    Private Sub CMBStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBStyle.SelectedIndexChanged
        'If CMBStyle.SelectedText = "Black" Then
        ' Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black
        ' frmMain.SaveSetting("Style", "Black")
        ' End If
        ' If CMBStyle.SelectedText = "Blue" Then
        ' Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue
        ' frmMain.SaveSetting("Style", "Blue")
        ' End If
        ' If CMBStyle.SelectedText = "Silver" Then
        'Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver
        ' frmMain.SaveSetting("Style", "Silver")
        ' End If
        '  If CMBStyle.SelectedText = "Vista Glass" Then
        ' Me.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.VistaGlass
        ' frmMain.SaveSetting("Style", "Vista Glass")
        ' End If
    End Sub


    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
        frmMain.SaveSetting("PatchServer", ComboBoxEx1.Text)
    End Sub

    Private Sub cmbLanguage_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedValueChanged
        Dim DownloadClient As New WebClient
        DownloadClient.DownloadFile(New Uri("http://arks-layer.com/tweaker/LanguagePack.rar"), "LanguagePack.rar")
        Dim process As System.Diagnostics.Process = Nothing
        Dim processStartInfo As System.Diagnostics.ProcessStartInfo
        processStartInfo = New System.Diagnostics.ProcessStartInfo()
        Dim UnRarLocation As String
        UnRarLocation = (Application.StartupPath & "\unrar.exe")
        UnRarLocation = UnRarLocation.Replace("\\", "\")
        processStartInfo.FileName = UnRarLocation
        processStartInfo.Verb = "runas"
        processStartInfo.Arguments = ("x -inul -o+ LanguagePack.rar")
        processStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        processStartInfo.UseShellExecute = True
        process = System.Diagnostics.Process.Start(processStartInfo)
        Do Until process.WaitForExit(1000)
        Loop
        If cmbLanguage.SelectedIndex = 0 Then
            'English
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en")
            frmMain.SaveSetting("Locale", "en")
        End If
        If cmbLanguage.SelectedIndex = 1 Then
            'French
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fr")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("fr")
            frmMain.SaveSetting("Locale", "fr")
        End If
        If cmbLanguage.SelectedIndex = 2 Then
            'German
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("de")
            frmMain.SaveSetting("Locale", "de")
        End If
        If cmbLanguage.SelectedIndex = 3 Then
            'Japanese
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("ja")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ja")
            frmMain.SaveSetting("Locale", "ja")
        End If
        If cmbLanguage.SelectedIndex = 4 Then
            'Portuguese
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("pt")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("pt")
            frmMain.SaveSetting("Locale", "pt")
        End If
        If cmbLanguage.SelectedIndex = 5 Then
            'Russian
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("ru")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ru")
            frmMain.SaveSetting("Locale", "ru")
        End If
        If cmbLanguage.SelectedIndex = 6 Then
            'Spanish
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es")
            frmMain.SaveSetting("Locale", "es")
        End If
        If cmbLanguage.SelectedIndex = 7 Then
            'Spanish
            Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es")
            Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es")
            frmMain.SaveSetting("Locale", "pl")
        End If
    End Sub

    Private Sub ColorPickerButton1_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPickerButton1.SelectedColorChanged
        frmMain.StyleManager1.ManagerColorTint = ColorPickerButton1.SelectedColor
        Me.StyleManager1.ManagerColorTint = ColorPickerButton1.SelectedColor
        frmPSO2Options.StyleManager1.ManagerColorTint = ColorPickerButton1.SelectedColor
        frmMain.SaveSetting("Color", (ColorPickerButton1.SelectedColor.ToArgb))
    End Sub

    Private Sub CheckBoxX1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX1.CheckedChanged
        If CheckBoxX1.Checked = False Then
            MsgBox("PLEASE BE CAUTIOUS - If you turn this function off, the program will not automatically upload your logfile to pastebin, so you can report the bug to AIDA. This means that you'll need to provide the logfile yourself, or the likelyhood of your issue being resolved is very, very, slim.")
        End If
        frmMain.SaveSetting("Pastebin", CheckBoxX1.Checked.ToString)
    End Sub

    Private Sub ColorPickerButton2_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPickerButton2.SelectedColorChanged
        frmMain.ForeColor = ColorPickerButton2.SelectedColor
        frmPSO2Options.ForeColor = ColorPickerButton2.SelectedColor
        frmPSO2Options.TabItem1.TextColor = ColorPickerButton2.SelectedColor
        frmPSO2Options.TabItem2.TextColor = ColorPickerButton2.SelectedColor
        frmPSO2Options.TabItem3.TextColor = ColorPickerButton2.SelectedColor
        Me.ForeColor = ColorPickerButton2.SelectedColor
        CheckBoxX1.TextColor = ColorPickerButton2.SelectedColor
        CheckBoxX2.TextColor = ColorPickerButton2.SelectedColor
        CheckBoxX3.TextColor = ColorPickerButton2.SelectedColor
        CheckBoxX4.TextColor = ColorPickerButton2.SelectedColor
        CheckBoxX5.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRemoveCensor.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRemoveNVidia.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRemovePC.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRemoveSEGA.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRemoveVita.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRestoreCensor.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRestoreNVidia.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRestorePC.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRestoreSEGA.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkRestoreVita.TextColor = ColorPickerButton2.SelectedColor
        frmMain.chkSwapOP.TextColor = ColorPickerButton2.SelectedColor
        frmMain.SaveSetting("FontColor", (ColorPickerButton2.SelectedColor.ToArgb))
    End Sub
    Private Sub LabelX6_Click(sender As Object, e As EventArgs) Handles LabelX6.Click

    End Sub

    Private Sub CheckBoxX2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX2.CheckedChanged
        frmMain.SaveSetting("ENPatchAfterInstall", CheckBoxX2.Checked.ToString)
    End Sub

    Private Sub CheckBoxX3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX3.CheckedChanged
        frmMain.SaveSetting("LargeFilesAfterInstall", CheckBoxX3.Checked.ToString)
    End Sub

    Private Sub CheckBoxX4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX4.CheckedChanged
        frmMain.SaveSetting("StoryPatchAfterInstall", CheckBoxX4.Checked.ToString)
    End Sub

    Private Sub cmbBackupPreference_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBackupPreference.SelectedIndexChanged
        If cmbBackupPreference.SelectedIndex = 0 Then frmMain.SaveSetting("Backup", "Ask")
        If cmbBackupPreference.SelectedIndex = 1 Then frmMain.SaveSetting("Backup", "Always")
        If cmbBackupPreference.SelectedIndex = 2 Then frmMain.SaveSetting("Backup", "Never")
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Process.Start("http://arks-layer.com/credits.php")
    End Sub

    Private Sub cmbENOverride_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbENOverride.SelectedIndexChanged
        Dim strENselection As String
        strENselection = cmbENOverride.Text
        strENselection = strENselection.Replace("Latest version: ", "")
        strENselection = strENselection.Replace("Last installed: ", "")
        MsgBox(strENselection)
        frmMain.SaveSetting("ENPatchVersion", strENselection)
    End Sub

    Private Sub cmbLargeFilesOverride_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLargeFilesOverride.SelectedIndexChanged
        Dim strLargeFilesselection As String
        strLargeFilesselection = cmbLargeFilesOverride.Text
        strLargeFilesselection = strLargeFilesselection.Replace("Latest version: ", "")
        strLargeFilesselection = strLargeFilesselection.Replace("Last installed: ", "")
        MsgBox(strLargeFilesselection)
        frmMain.SaveSetting("LargeFilesVersion", strLargeFilesselection)
    End Sub

    Private Sub cmbStoryOverride_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStoryOverride.SelectedIndexChanged
        Dim strStoryPatchselection As String
        strStoryPatchselection = cmbStoryOverride.Text
        strStoryPatchselection = strStoryPatchselection.Replace("Latest version: ", "")
        strStoryPatchselection = strStoryPatchselection.Replace("Last installed: ", "")
        MsgBox(strStoryPatchselection)
        frmMain.SaveSetting("StoryPatchVersion", strStoryPatchselection)
    End Sub

    Private Sub ColorPickerButton4_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPickerButton4.SelectedColorChanged
        frmMain.rtbDebug.BackColor = ColorPickerButton4.SelectedColor
        frmMain.SaveSetting("TextboxBGColor", (ColorPickerButton4.SelectedColor.ToArgb))
    End Sub

    Private Sub ColorPickerButton3_SelectedColorChanged(sender As Object, e As EventArgs) Handles ColorPickerButton3.SelectedColorChanged
        frmMain.rtbDebug.ForeColor = ColorPickerButton3.SelectedColor
        frmMain.SaveSetting("TextboxColor", (ColorPickerButton3.SelectedColor.ToArgb))
    End Sub

    Private Sub btnPSO2Override_Click(sender As Object, e As EventArgs) Handles btnPSO2Override.Click
        Dim YesNo As MsgBoxResult = MsgBox("This will tell the Tweaker you have the latest version of PSO2 installed - Be aware that this cannot be undone, and should only be used if you update the game outside of the Tweaker. Do you want to continue?", vbYesNo)
        If YesNo = vbYes Then
            Dim lines3 = File.ReadAllLines("version.ver")
            Dim RemoteVersion3 As String = lines3(0)
            frmMain.SaveSetting("PSO2RemoteVersion", RemoteVersion3)
            MsgBox("PSO2 Installed version set to: " & RemoteVersion3)
        End If
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        If TextBoxX1.Text <> "" Then
            Dim UIDString As String = TextBoxX1.Text.Replace("steam://rungameid/", "")
            MsgBox(UIDString)
            frmMain.SaveSetting("SteamUID", UIDString)
        End If
    End Sub
    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        Dim DirectoryString As String = frmMain.lblDirectory.Text
        Dim pso2launchpath As String = DirectoryString.Replace("\data\win32", "")
        Environment.SetEnvironmentVariable("-pso2", "+0x01e3f1e9")
        ' & 
        'MsgBox(frmMain.LoadSetting("SteamEXE") & " -applaunch " & frmMain.LoadSetting("SteamUID"))
        ShellExecute(Handle, "open", ("steam://rungameID/" & frmMain.LoadSetting("SteamUID")), " +0x33aca2b9 -pso2", "", 0)
        'ShellExecute(Handle, "open", frmMain.LoadSetting("SteamEXE"), " -applaunch " & frmMain.LoadSetting("SteamUID"), "", 0)
    End Sub

    Private Sub CheckBoxX5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxX5.CheckedChanged
        frmMain.SaveSetting("SidebarEnabled", CheckBoxX5.Checked.ToString)
    End Sub

    Private Sub chkAutoRemoveCensor_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoRemoveCensor.CheckedChanged
        frmMain.SaveSetting("RemoveCensor", chkAutoRemoveCensor.Checked.ToString)
    End Sub

    Private Sub cmbLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLanguage.SelectedIndexChanged

    End Sub

    Private Sub cmbPredownload_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPredownload.SelectedIndexChanged
        If cmbPredownload.SelectedIndex = 0 Then frmMain.SaveSetting("PredownloadedRAR", "Ask")
        If cmbPredownload.SelectedIndex = 1 Then frmMain.SaveSetting("PredownloadedRAR", "Never")
    End Sub
End Class
