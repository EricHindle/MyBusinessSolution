﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ShowDiaryBody() As Boolean
            Get
                Return CType(Me("ShowDiaryBody"),Boolean)
            End Get
            Set
                Me("ShowDiaryBody") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ShowCustomer() As Boolean
            Get
                Return CType(Me("ShowCustomer"),Boolean)
            End Get
            Set
                Me("ShowCustomer") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property ShowSupplier() As Boolean
            Get
                Return CType(Me("ShowSupplier"),Boolean)
            End Get
            Set
                Me("ShowSupplier") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ShowJob() As Boolean
            Get
                Return CType(Me("ShowJob"),Boolean)
            End Get
            Set
                Me("ShowJob") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property DebugOn() As Boolean
            Get
                Return CType(Me("DebugOn"),Boolean)
            End Get
            Set
                Me("DebugOn") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("7")>  _
        Public Property RetentionPeriod() As Integer
            Get
                Return CType(Me("RetentionPeriod"),Integer)
            End Get
            Set
                Me("RetentionPeriod") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property AutoTidy() As Boolean
            Get
                Return CType(Me("AutoTidy"),Boolean)
            End Get
            Set
                Me("AutoTidy") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property TempFolder() As String
            Get
                Return CType(Me("TempFolder"),String)
            End Get
            Set
                Me("TempFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property LogFolder() As String
            Get
                Return CType(Me("LogFolder"),String)
            End Get
            Set
                Me("LogFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ReportFolder() As String
            Get
                Return CType(Me("ReportFolder"),String)
            End Get
            Set
                Me("ReportFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property CacheFolder() As String
            Get
                Return CType(Me("CacheFolder"),String)
            End Get
            Set
                Me("CacheFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkEnabled() As Boolean
            Get
                Return CType(Me("splchkEnabled"),Boolean)
            End Get
            Set
                Me("splchkEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkAdd() As Boolean
            Get
                Return CType(Me("splchkAdd"),Boolean)
            End Get
            Set
                Me("splchkAdd") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkIgnore() As Boolean
            Get
                Return CType(Me("splchkIgnore"),Boolean)
            End Get
            Set
                Me("splchkIgnore") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkNumber() As Boolean
            Get
                Return CType(Me("splchkNumber"),Boolean)
            End Get
            Set
                Me("splchkNumber") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkRemove() As Boolean
            Get
                Return CType(Me("splchkRemove"),Boolean)
            End Get
            Set
                Me("splchkRemove") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkUpper() As Boolean
            Get
                Return CType(Me("splchkUpper"),Boolean)
            End Get
            Set
                Me("splchkUpper") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkShowMistakes() As Boolean
            Get
                Return CType(Me("splchkShowMistakes"),Boolean)
            End Get
            Set
                Me("splchkShowMistakes") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkShowIgnore() As Boolean
            Get
                Return CType(Me("splchkShowIgnore"),Boolean)
            End Get
            Set
                Me("splchkShowIgnore") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property splchkShowCaseError() As Boolean
            Get
                Return CType(Me("splchkShowCaseError"),Boolean)
            End Get
            Set
                Me("splchkShowCaseError") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Red")>  _
        Public Property splchkMistakeColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("splchkMistakeColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("splchkMistakeColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Blue")>  _
        Public Property splchkIgnoreColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("splchkIgnoreColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("splchkIgnoreColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Green")>  _
        Public Property splchkCaseErrorColor() As Global.System.Drawing.Color
            Get
                Return CType(Me("splchkCaseErrorColor"),Global.System.Drawing.Color)
            End Get
            Set
                Me("splchkCaseErrorColor") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DataFolder() As String
            Get
                Return CType(Me("DataFolder"),String)
            End Get
            Set
                Me("DataFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("server=127.0.0.1;user id=ehindle;password=dkk.mysql;persistsecurityinfo=True;data"& _ 
            "base=netwyrks")>  _
        Public ReadOnly Property netwyrksConnectionString() As String
            Get
                Return CType(Me("netwyrksConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.0.0")>  _
        Public Property Version() As String
            Get
                Return CType(Me("Version"),String)
            End Get
            Set
                Me("Version") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property showProduct() As Boolean
            Get
                Return CType(Me("showProduct"),Boolean)
            End Get
            Set
                Me("showProduct") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property showTask() As Boolean
            Get
                Return CType(Me("showTask"),Boolean)
            End Get
            Set
                Me("showTask") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 24pt")>  _
        Public Property InvHdrFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvHdrFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvHdrFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 14pt")>  _
        Public Property InvBodyLargeFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvBodyLargeFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvBodyLargeFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 10pt")>  _
        Public Property InvFtrFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvFtrFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvFtrFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 24pt")>  _
        Public Property InvCmpyNameFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvCmpyNameFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvCmpyNameFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 14pt")>  _
        Public Property InvCmpyAddrFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvCmpyAddrFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvCmpyAddrFont") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Cambria, 12pt")>  _
        Public Property InvBodyFont() As Global.System.Drawing.Font
            Get
                Return CType(Me("InvBodyFont"),Global.System.Drawing.Font)
            End Get
            Set
                Me("InvBodyFont") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.MyBusiness.My.MySettings
            Get
                Return Global.MyBusiness.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
