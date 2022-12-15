' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ClsRtfConstants
    Public Const RTF_ROW_START As String = "\trowd\trgaph108\trleft284\trpaddl108\trpaddr108\trpaddt108\trpaddb108\trpaddfl3\trpaddfr3\trpaddft3\trpaddbr3 "
    Public Const RTF_ROW_END As String = "\row"
    Public Const RTF_V_CENTRE As String = "\clvertalc"
    Public Const RTF_CUST_COLS As String = "\cellx5072\cellx9860"
    Public Const RTF_CELL_START As String = "\pard\intbl\keep\nowidctlpar"
    Public Const RTF_CELL_END As String = "\cell"
    Public Const RTF_CUST_TAB1 As String = "\tx550\tqr\tx8000"
    ' + xnnnn for width
    Public Const RTF_END_PAR As String = "\par"
    Public Const RTF_CELL_RESET As String = "\pard\intbl\b0\f1\fs20"
    Public Const RTF_FONT_SIZE As String = "\fs"                                            ' + font size
    Public Const RTF_RIGHT_ALIGN As String = "\qr"
    Public Const RTF_CENTRE_ALIGN As String = "\qc"
    Public Const RTF_SINGLE_RIGHT_TABLE_BORDER As String = "\trbrdrr\brdrs\brdrw10"
    Public Const RTF_SINGLE_LEFT_TABLE_BORDER As String = "\trbrdrl\brdrs\brdrw10"
    Public Const RTF_SINGLE_TOP_TABLE_BORDER As String = "\trbrdrt\brdrs\brdrw10"
    Public Const RTF_SINGLE_BOTTOM_TABLE_BORDER As String = "\trbrdrt\brdrb\brdrw10"
    Public Const RTF_SINGLE_RIGHT_CELL_BORDER As String = "\clbrdrr\brdrs\brdrw10"
    Public Const RTF_SINGLE_LEFT_CELL_BORDER As String = "\clbrdrl\brdrs\brdrw10"
    Public Const RTF_SINGLE_TOP_CELL_BORDER As String = "\clbrdrt\brdrs\brdrw10"
    Public Const RTF_SINGLE_BOTTOM_CELL_BORDER As String = "\clbrdrt\brdrb\brdrw10"
    Public Const RTF_CELL_BKGRD_COLOR As String = "\clcbpat"                                ' + color number
    Public Const RTF_CELL_V_MRG_FIRST As String = "\clvmgf"
    Public Const RTF_CELL_V_MRG_OTHER As String = "\clvmrg"
End Class
