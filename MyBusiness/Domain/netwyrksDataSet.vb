' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Partial Class netwyrksDataSet
    Partial Public Class jobDataTable
        Private Sub JobDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If e.Column.ColumnName = job_createdColumn.ColumnName Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class supplierDataTable
    End Class
End Class

Namespace netwyrksDataSetTableAdapters
    Partial Public Class job_imageTableAdapter
    End Class
End Namespace

Namespace netwyrksDataSetTableAdapters
    Partial Public Class template_taskTableAdapter
    End Class
End Namespace
