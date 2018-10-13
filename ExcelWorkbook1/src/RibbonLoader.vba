Attribute VB_Name = "RibbonLoader"
Option Explicit

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''''''''''''''''''''''''''''   DON'T EDIT THIS MODULE   '''''''''''''''''''''''''
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Private Const ModuleName   As String = "RibbonLoader."

Public Property Get AddInHandle() As Object
    Set AddInHandle = GetManagedClass(ThisWorkbook)
End Property

''' <summary>EventHandler for RibbonLoad, initializing the ViewModel and Model.</summary>
''' <param name="RibbonUI">An IRibbonUI for the ribbon just loaded.</param>
Public Function NewRibbonModel()
    On Error GoTo EH
    With New RibbonModel
        Set NewRibbonModel = .Initialize
    End With
XT: Exit Function
EH: DisplayError Err, ModuleName & "NewRibbonModel"
    Resume XT
    Resume      ' for debugging only
End Function