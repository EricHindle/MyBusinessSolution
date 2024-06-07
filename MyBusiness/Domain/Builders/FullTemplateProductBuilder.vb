' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FullTemplateProductBuilder
    Private _template As Template
    Private _product As Product
    Private _supplier As Supplier
    Private _templateProductId As Integer
    Private _quantity As Decimal
    Public Shared Function ATemplateProduct() As FullTemplateProductBuilder
        Return New FullTemplateProductBuilder
    End Function
    Public Function StartingWithNothing() As FullTemplateProductBuilder
        _templateProductId = -1
        _template = TemplateBuilder.ATemplate.StartingWithNothing.Build
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
        _supplier = SupplierBuilder.ASupplier.StartingWithNothing.Build
        _quantity = 0
        Return Me
    End Function
    Public Function StartingWith(ByVal oJobProduct As FullTemplateProduct) As FullTemplateProductBuilder
        With oJobProduct
            _templateProductId = .TemplateProductId
            _supplier = .Supplier
            _product = .Product
            _quantity = .Quantity
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As MyBusinessDataSet.v_templateproductRow) As FullTemplateProductBuilder
        With oRow
            _templateProductId = .template_product_id
            _template = TemplateBuilder.ATemplate.StartingWithNothing _
                                        .WithTemplateId(.template_id) _
                                        .WithTemplateName(.template_name) _
                                        .WithTemplateDescription(.template_description) _
                                        .Build
            _supplier = SupplierBuilder.ASupplier.StartingWithNothing _
                                        .WithSupplierId(.supplier_id) _
                                        .WithSupplierName(.supplier_name) _
                                        .Build
            _product = ProductBuilder.AProduct.StartingWithNothing _
                                        .WithProductId(.product_id) _
                                        .WithProductName(.product_name) _
                                        .WithProductDescription(.product_description) _
                                        .WithProductCost(.product_cost) _
                                        .WithProductPrice(.product_price) _
                                        .WithProductTaxable(.product_taxable) _
                                        .WithPurchaseUnits(.product_purchase_units) _
                                        .WithProductTaxRate(.product_tax_rate) _
                                        .WithProductSupplierId(.supplier_id) _
                                        .Build

            _quantity = .quantity
        End With
        Return Me
    End Function

    Public Function WithTemplateProductId(pTemplateProductId As Integer) As FullTemplateProductBuilder
        _templateProductId = pTemplateProductId
        Return Me
    End Function
    Public Function WithTemplate(pTemplateId As Integer) As FullTemplateProductBuilder
        _template = GetTemplateById(pTemplateId)
        Return Me
    End Function
    Public Function WithTemplate(pTemplate As Template) As FullTemplateProductBuilder
        _template = pTemplate
        Return Me
    End Function

    Public Function WithProduct(pProductId As Integer) As FullTemplateProductBuilder
        _product = GetProductById(pProductId)
        Return Me
    End Function
    Public Function WithSupplier(pSupplier As Supplier) As FullTemplateProductBuilder
        _supplier = pSupplier
        Return Me
    End Function
    Public Function WithSupplier(pSupplierId As Integer) As FullTemplateProductBuilder
        _supplier = GetSupplierById(pSupplierId)
        Return Me
    End Function
    Public Function WithProduct(pProduct As Product) As FullTemplateProductBuilder
        _product = pProduct
        Return Me
    End Function
    Public Function WithQuantity(pQuantity As Integer) As FullTemplateProductBuilder
        _quantity = pQuantity
        Return Me
    End Function

    Public Function Build() As FullTemplateProduct
        Return New FullTemplateProduct(_templateProductId,
                                       _template,
                                       _product,
                                       _quantity,
                                       _supplier)
    End Function

End Class
