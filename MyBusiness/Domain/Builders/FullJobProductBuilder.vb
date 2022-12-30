' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullJobProductBuilder
    Private _jobProductId As Integer
    Private _job As Job
    Private _product As Product
    Private _quantity As Integer
    Private _jobProductCreated As DateTime?
    Private _jobProductChanged As DateTime?
    Private _taxable As Boolean
    Private _tax_rate As Decimal
    Private _price As Decimal
    Private _supplier As Supplier
    Private _customer As Customer
    Public Shared Function AJobProduct() As FullJobProductBuilder
        Return New FullJobProductBuilder
    End Function
    Public Function StartingWith(ByVal oJobProduct As FullJobProduct) As FullJobProductBuilder
        With oJobProduct
            _jobProductId = .JobProductId
            _job = .CustomerJob
            _customer = .JobCustomer
            _supplier = .ProductSupplier
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
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.v_jobproductRow) As FullJobProductBuilder
        With oRow
            _jobProductId = .job_product_id
            _job = JobBuilder.AJob.StartingWith(oRow).Build
            _product = ProductBuilder.AProduct.StartingWith(oRow).Build
            _customer = CustomerBuilder.ACustomer.StartingWith(oRow).Build
            _supplier = SupplierBuilder.ASupplier.StartingWith(oRow).Build
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
    Public Function StartingWithNothing() As FullJobProductBuilder
        _jobProductId = -1
        _job = JobBuilder.AJob.StartingWithNothing.Build
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
        _supplier = SupplierBuilder.ASupplier.StartingWithNothing.Build
        _customer = CustomerBuilder.ACustomer.StartingWithNothing.Build
        _quantity = 0
        _jobProductCreated = Nothing
        _jobProductChanged = Nothing
        _taxable = False
        _tax_rate = 0.00D
        _price = 0.00D
        Return Me
    End Function
    Public Function WithJobProductId(pJobProductId As Integer) As FullJobProductBuilder
        _jobProductId = pJobProductId
        Return Me
    End Function
    Public Function WithJob(pJobId As Integer) As FullJobProductBuilder
        _job = GetJobById(pJobId)
        Return Me
    End Function
    Public Function WithJob(pJob As Job) As FullJobProductBuilder
        _job = pJob
        Return Me
    End Function

    Public Function WithProduct(pProductId As Integer) As FullJobProductBuilder
        _product = GetProductById(pProductId)
        Return Me
    End Function
    Public Function WithProduct(pProduct As Product) As FullJobProductBuilder
        _product = pProduct
        Return Me
    End Function

    Public Function WithQuantity(pQuantity As Integer) As FullJobProductBuilder
        _quantity = pQuantity
        Return Me
    End Function
    Public Function WithTaxable(pTaxable As Boolean) As FullJobProductBuilder
        _taxable = pTaxable
        Return Me
    End Function
    Public Function WithTaxRate(pTaxRate As Decimal) As FullJobProductBuilder
        _tax_rate = pTaxRate
        Return Me
    End Function
    Public Function WithPrice(pPrice As Decimal) As FullJobProductBuilder
        _price = pPrice
        Return Me
    End Function
    Public Function WithCreated(ByVal pCreated As DateTime) As FullJobProductBuilder
        _jobProductCreated = pCreated
        Return Me
    End Function
    Public Function WithChanged(ByVal pChanged As DateTime?) As FullJobProductBuilder
        _jobProductChanged = pChanged
        Return Me
    End Function
    Public Function Build() As FullJobProduct
        Return New FullJobProduct(_jobProductId,
                              _job,
                              _product,
                              _quantity,
                              _jobProductCreated,
                              _jobProductChanged,
                              _taxable,
                              _tax_rate,
                              _price,
                              _customer,
                              _supplier)
    End Function
End Class
