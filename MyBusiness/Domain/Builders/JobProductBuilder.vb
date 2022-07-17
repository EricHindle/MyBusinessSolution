Public Class JobProductBuilder
    Private _jobProductId As Integer
    Private _job As Job
    Private _product As Product
    Private _quantity As Integer
    Private _jobProductCreated As DateTime?
    Private _jobProductChanged As DateTime?
    Private _taxable As Boolean
    Private _tax_rate As Decimal
    Private _price As Decimal
    Public Shared Function AJobProduct() As JobProductBuilder
        Return New JobProductBuilder
    End Function
    Public Function StartingWith(ByVal jobProductId As Integer) As JobProductBuilder
        Dim oJobProductTa As New netwyrksDataSetTableAdapters.job_productTableAdapter
        Dim oJobProductTable As New netwyrksDataSet.job_productDataTable
        If oJobProductTa.FillById(oJobProductTable, jobProductId) > 0 Then
            StartingWith(oJobProductTable.Rows(0))
        Else
            StartingWithNothing()
        End If
        oJobProductTa.Dispose()
        oJobProductTable.Dispose()
        Return Me
    End Function
    Public Function StartingWith(ByVal oJobProduct As JobProduct) As JobProductBuilder
        With oJobProduct
            _jobProductId = .JobProductId
            _job = .ThisJob
            _product = .ThisProduct
            _quantity = .Quantity
            _jobProductCreated = .JobProductCreated
            _jobProductChanged = .JobProductChanged
            _taxable = .Taxable
            _tax_rate = .Tax_Rate
            _price = .Price
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.job_productRow) As JobProductBuilder
        With oRow
            _jobProductId = .job_product_id
            _job = GetJobById(.jp_job_id)
            _product = GetProductById(.jp_product_id)
            _quantity = .jp_quantity
            _jobProductCreated = .jp_created
            _jobProductChanged = .jp_changed
            _taxable = .jp_taxable
            _tax_rate = .jp_tax_rate
            _price = .jp_price
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As JobProductBuilder
        _jobProductId = -1
        _job = JobBuilder.AJob.StartingWithNothing.Build
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
        _quantity = 0
        _jobProductCreated = Nothing
        _jobProductChanged = Nothing
        _taxable = False
        _tax_rate = 0.00D
        _price = 0.00D
        Return Me
    End Function
End Class
