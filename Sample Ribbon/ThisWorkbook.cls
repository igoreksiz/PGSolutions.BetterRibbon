VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "ThisWorkbook"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
Option Explicit

Private MRibbonModel    As RibbonModel

Implements PGSolutions_RibbonDispatcher.IRibbonWorkbook

''' <summary>Returns the RibbonViewModel for this workbook.</summary>
Friend Property Get IRibbonWorkbook_ViewModel() As PGSolutions_RibbonDispatcher.RibbonViewModel
    Set IRibbonWorkbook_ViewModel = MRibbonModel.ViewModel
End Property

''' <summary>Initializes the RobbonModel for this workbook, and activates its RibbonTab.</summary>
Friend Property Set RibbonModel(ByVal Value As RibbonModel)
    Set MRibbonModel = Value
End Property

Private Sub Workbook_Open()
    On Error GoTo EH
    If ShowAlerts Then DisplayAlert "Workbook_Open"
XT: Exit Sub
EH: DisplayError Err, TypeName(Me) & "Workbook_Open"
    Resume XT
    Resume      ' for debugging only
End Sub