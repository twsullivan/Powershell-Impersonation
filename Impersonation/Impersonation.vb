Imports System.Management.Automation

''' <summary>
''' Impersonates an authenticated user until Stop-Impersonation is called.
''' </summary>
''' <remarks></remarks>
<Cmdlet(VerbsLifecycle.Start, "Impersonation")> _
Public Class SetImpersonation
    Inherits Cmdlet

    Private _username As String
    Private _password As String

    <Parameter(Mandatory:=True, Position:=0, _
               ValueFromPipeline:=False, ValueFromPipelineByPropertyName:=False, _
               HelpMessage:="Username for account to be impersonated."), [Alias]("AcctUsername")> _
    Public WriteOnly Property Username As String
        Set(value As String)
            _username = value
        End Set
    End Property

    <Parameter(Mandatory:=True, Position:=1, _
               ValueFromPipeline:=False, ValueFromPipelineByPropertyName:=False, _
               HelpMessage:="Password for account to be impersonated."), [Alias]("AcctPassword")> _
    Public WriteOnly Property Password As String
        Set(value As String)
            _password = value
        End Set
    End Property

    ''' <summary>
    ''' Starts the impersonation
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub EndProcessing()
        Dim Account As New Account(_username, _password)
        Account.BeginImpersonation()
        WriteObject(Account, False)
    End Sub

End Class

''' <summary>
''' Sets the current user account back to the logged on user.
''' </summary>
''' <remarks></remarks>
<Cmdlet(VerbsLifecycle.Stop, "Impersonation")> _
Public Class UndoImpersonation
    Inherits Cmdlet

    <Parameter(Mandatory:=True, Position:=0, _
               HelpMessage:="Impersonated account.")> _
    Property Account As Account

    ''' <summary>
    ''' Stops the impersonation
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub EndProcessing()
        Account.EndImpersonation()
    End Sub

End Class