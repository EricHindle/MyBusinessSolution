' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

''' <summary>
''' The ConvertUtil module contains the procedures used to perform various conversion operations.
''' </summary>
''' <remarks></remarks>
Public Class ConvertUtil
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dgv">The data grid table to convert</param>
    ''' <param name="sFmt">The format to user for date values</param>
    ''' <param name="sSep">The separator to use between columns</param>
    ''' <returns>String representation of the table</returns>
    ''' <remarks></remarks>
    Public Shared Function DataGridViewToTextTable(ByRef dgv As DataGridView, Optional ByVal sFmt As String = Nothing, Optional ByVal sSep As String = vbTab) As String
        logutil.info("Converting data grid to text", "DataGridViewToTextTable")
        Dim sText As New StringBuilder()
        Dim isFirst As Boolean = True
        If dgv.ColumnHeadersVisible Then
            For Each oCol As DataGridViewColumn In dgv.Columns
                If oCol.Visible Then
                    If isFirst Then
                        isFirst = False
                    Else
                        sText.Append(sSep)
                    End If
                    sText.Append(oCol.HeaderText)

                End If
            Next
            sText.Append(vbCrLf)
        End If
        For Each oRow As DataGridViewRow In dgv.Rows
            isFirst = True
            For Each oCell As DataGridViewCell In oRow.Cells
                If oCell.Visible Then
                    If isFirst Then
                        isFirst = False
                    Else
                        sText.Append(sSep)
                    End If
                    If oCell.Value IsNot Nothing AndAlso oCell.Value IsNot DBNull.Value Then
                        Dim sVal As String = CStr(oCell.Value)
                        If sFmt IsNot Nothing Then
                            If oCell.Value.GetType Is GetType(System.DateTime) Then
                                sVal = Format(oCell.Value, sFmt)
                            End If
                        End If
                        '    If sVal.IndexOf(",") >= 0 Or sVal.IndexOf(sSep) >= 0 Then
                        If sVal.IndexOf(sSep) >= 0 Then
                            sText.Append("""").Append(sVal).Append("""")
                        Else
                            sText.Append(sVal)
                        End If
                    Else
                        sText.Append("")
                    End If
                End If
            Next
            sText.Append(vbCrLf)
        Next
        Return sText.ToString
    End Function
End Class
