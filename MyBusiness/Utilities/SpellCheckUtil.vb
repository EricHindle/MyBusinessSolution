' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Sep 2015
Imports i00SpellCheck
''' <summary>
''' Functions for use in conjunction with the i00SpellCheck utility
''' </summary>
''' <remarks></remarks>
Public Class SpellCheckUtil

    ''' <summary>
    ''' Set spell check options from personal option settings
    ''' </summary>
    ''' <returns>Spell check settings</returns>
    ''' <remarks></remarks>
    Public Shared Function SetSpellCheckOptions() As i00SpellCheck.SpellCheckSettings
        Dim SpellCheckSettings As New i00SpellCheck.SpellCheckSettings
        SpellCheckSettings.AllowAdditions = My.Settings.splchkAdd                      'Specifies if you want to allow the user to add words to the dictionary
        SpellCheckSettings.AllowIgnore = My.Settings.splchkIgnore                      'Specifies if you want to allow the user to ignore words
        SpellCheckSettings.AllowRemovals = My.Settings.splchkRemove                    'Specifies if you want to allow users to delete words from the dictionary
        SpellCheckSettings.AllowInMenuDefs = False                                     'Specifies if the in menu definitions should be shown for correctly spelled words
        SpellCheckSettings.AllowChangeTo = False                                       'Specifies if "Change to..." (to change to a synonym) should be shown in the menu for correctly spelled words
        SpellCheckSettings.IgnoreWordsInUpperCase = My.Settings.splchkUpper
        SpellCheckSettings.IgnoreWordsWithNumbers = My.Settings.splchkNumber
        SpellCheckSettings.AllowF7 = False
        SpellCheckSettings.ShowMistakes = My.Settings.splchkShowMistakes
        If My.Settings.splchkShowIgnore Then
            SpellCheckSettings.ShowIgnored = i00SpellCheck.SpellCheckSettings.ShowIgnoreState.AlwaysShow
        Else
            SpellCheckSettings.ShowIgnored = i00SpellCheck.SpellCheckSettings.ShowIgnoreState.AlwaysHide
        End If
        SpellCheckSettings.MistakeColor = My.Settings.splchkMistakeColor
        SpellCheckSettings.IgnoreColor = My.Settings.splchkIgnoreColor
        SpellCheckSettings.CaseMistakeColor = My.Settings.splchkCaseErrorColor
        Return SpellCheckSettings
    End Function

    Public Shared Sub SetSpellCheckOptions(ByRef oControl As Control)
        oControl.SpellCheck.Settings.AllowAdditions = My.Settings.splchkAdd                      'Specifies if you want to allow the user to add words to the dictionary
        oControl.SpellCheck.Settings.AllowIgnore = My.Settings.splchkIgnore                      'Specifies if you want to allow the user to ignore words
        oControl.SpellCheck.Settings.AllowRemovals = My.Settings.splchkRemove                    'Specifies if you want to allow users to delete words from the dictionary
        oControl.SpellCheck.Settings.AllowInMenuDefs = False                                     'Specifies if the in menu definitions should be shown for correctly spelled words
        oControl.SpellCheck.Settings.AllowChangeTo = False                                       'Specifies if "Change to..." (to change to a synonym) should be shown in the menu for correctly spelled words
        oControl.SpellCheck.Settings.IgnoreWordsInUpperCase = My.Settings.splchkUpper
        oControl.SpellCheck.Settings.IgnoreWordsWithNumbers = My.Settings.splchkNumber
        oControl.SpellCheck.Settings.AllowF7 = False
        oControl.SpellCheck.Settings.ShowMistakes = My.Settings.splchkShowMistakes
        If My.Settings.splchkShowIgnore Then
            oControl.SpellCheck.Settings.ShowIgnored = i00SpellCheck.SpellCheckSettings.ShowIgnoreState.AlwaysShow
        Else
            oControl.SpellCheck.Settings.ShowIgnored = i00SpellCheck.SpellCheckSettings.ShowIgnoreState.AlwaysHide
        End If
        oControl.SpellCheck.Settings.MistakeColor = My.Settings.splchkMistakeColor
        oControl.SpellCheck.Settings.IgnoreColor = My.Settings.splchkIgnoreColor
        oControl.SpellCheck.Settings.CaseMistakeColor = My.Settings.splchkCaseErrorColor
    End Sub

    ''' <summary>
    ''' Enable spell checking on a control (e.g. textbox)
    ''' </summary>
    ''' <param name="oControls">Array of controls to have spell checking</param>
    ''' <remarks>Sets spell check options on each individual control</remarks>
    Public Shared Sub EnableSpellChecking(ByRef oControls() As Control)
        If My.Settings.splchkEnabled Then
            For Each oControl As Control In oControls
                Try
                    SetSpellCheckOptions(oControl)
                    oControl.EnableSpellCheck()
                Catch ex As Exception
                    LogUtil.Exception("Exception when enabling Spell Checking", ex, "EnableSpellChecking")
                End Try
            Next
        Else
            For Each oControl As Control In oControls
                LogUtil.Debug("Disable spellcheck on " & oControl.Name)
                oControl.DisableSpellCheck()
            Next
        End If
    End Sub
End Class
