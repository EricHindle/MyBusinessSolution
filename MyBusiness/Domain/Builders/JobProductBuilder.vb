' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

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
    Public Function StartingWith(ByVal oTemplateProduct As FullTemplateProduct) As JobProductBuilder
        With oTemplateProduct
            _jobProductId = .Product.ProductId
            _job = Nothing
            _product = .Product
            _quantity = .Quantity
            _jobProductCreated = Now
            _jobProductChanged = Nothing
            _taxable = .Product.IsProductTaxable
            _tax_rate = .Product.ProductTaxRate
            _price = .Product.ProductCost
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
            If .Isjp_changedNull Then
                _jobProductChanged = Nothing
            Else
                _jobProductChanged = .jp_changed
            End If

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
    Public Function WithJobProductId(pJobProductId As Integer) As JobProductBuilder
        _jobProductId = pJobProductId
        Return Me
    End Function
    Public Function WithJob(pJobId As Integer) As JobProductBuilder
        _job = GetJobById(pJobId)
        Return Me
    End Function
    Public Function WithJob(pJob As Job) As JobProductBuilder
        _job = pJob
        Return Me
    End Function

    Public Function WithProduct(pProductId As Integer) As JobProductBuilder
        _product = GetProductById(pProductId)
        Return Me
    End Function
    Public Function WithProduct(pProduct As Product) As JobProductBuilder
        _product = pProduct
        Return Me
    End Function

    Public Function WithQuantity(pQuantity As Integer) As JobProductBuilder
        _quantity = pQuantity
        Return Me
    End Function
    Public Function WithTaxable(pTaxable As Boolean) As JobProductBuilder
        _taxable = pTaxable
        Return Me
    End Function
    Public Function WithTaxRate(pTaxRate As Decimal) As JobProductBuilder
        _tax_rate = pTaxRate
        Return Me
    End Function
    Public Function WithPrice(pPrice As Decimal) As JobProductBuilder
        _price = pPrice
        Return Me
    End Function
    Public Function WithCreated(ByVal pCreated As DateTime) As JobProductBuilder
        _jobProductCreated = pCreated
        Return Me
    End Function
    Public Function WithChanged(ByVal pChanged As DateTime?) As JobProductBuilder
        _jobProductChanged = pChanged
        Return Me
    End Function
    Public Function Build() As JobProduct
        Return New JobProduct(_jobProductId,
                              _job,
                              _product,
                              _quantity,
                              _jobProductCreated,
                              _jobProductChanged,
                              _taxable,
                              _tax_rate,
                              _price)
    End Function
End Class
