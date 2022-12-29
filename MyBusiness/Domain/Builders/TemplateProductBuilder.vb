' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class TemplateProductBuilder
    Private _templateProductId As Integer
    Private _product As Product
    Private _quantity As Integer
    Private _template As Template
    Public Shared Function ATemplateProduct() As TemplateProductBuilder
        Return New TemplateProductBuilder
    End Function
    Public Function StartingWith(ByVal oTemplateProduct As TemplateProduct) As TemplateProductBuilder
        With oTemplateProduct
            _templateProductId = .TemplateProductId
            _product = .Product
            _quantity = .Quantity
        End With
        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.template_productRow) As TemplateProductBuilder
        With oRow
            _templateProductId = .template_product_id
            _product = GetProductById(.product_id)
            _quantity = .quantity
            _template = GetTemplateById(.template_id)
        End With
        Return Me
    End Function
    Public Function StartingWithNothing() As TemplateProductBuilder
        _templateProductId = -1
        _product = ProductBuilder.AProduct.StartingWithNothing.Build
        _quantity = 0
        _template = TemplateBuilder.ATemplate.StartingWithNothing.build
        Return Me
    End Function
    Public Function WithTemplateProductId(pTemplateProductId As Integer) As TemplateProductBuilder
        _templateProductId = pTemplateProductId
        Return Me
    End Function
    Public Function WithProduct(pProductId As Integer) As TemplateProductBuilder
        _product = GetProductById(pProductId)
        Return Me
    End Function
    Public Function WithProduct(pProduct As Product) As TemplateProductBuilder
        _product = pProduct
        Return Me
    End Function

    Public Function WithQuantity(pQuantity As Integer) As TemplateProductBuilder
        _quantity = pQuantity
        Return Me
    End Function

    Public Function Build() As TemplateProduct
        Return New TemplateProduct(_templateProductId,
                              _template,
                              _product,
                              _quantity)
    End Function

End Class
