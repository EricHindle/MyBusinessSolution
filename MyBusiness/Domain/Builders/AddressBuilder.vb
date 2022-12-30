' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

''' <summary>
''' Customer or shop address object builder  (see https://en.wikipedia.org/wiki/Builder_pattern)
''' </summary>
''' <remarks></remarks>
Public Class AddressBuilder
    Private _address1 As String
    Private _address2 As String
    Private _address3 As String
    Private _address4 As String
    Private _postcode As String

    Public Shared Function AnAddress() As AddressBuilder
        Return New AddressBuilder
    End Function

    ''' <summary>
    ''' Create a builder from an existing address object
    ''' </summary>
    ''' <param name="oAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartingWith(ByVal oAddress As Address) As AddressBuilder
        If oAddress IsNot Nothing Then
            _address1 = oAddress.Address1
            _address2 = oAddress.Address2
            _address3 = oAddress.Address3
            _address4 = oAddress.Address4
            _postcode = oAddress.Postcode
        Else
            startingWithNothing()
        End If
        Return Me
    End Function

    ''' <summary>
    ''' Create a builder from nothing
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartingWithNothing() As AddressBuilder
        _address1 = ""
        _address2 = ""
        _address3 = ""
        _address4 = ""
        _postcode = ""
        Return Me
    End Function

    ''' <summary>
    ''' Create a builder from a row in the v_customer view
    ''' </summary>
    ''' <param name="oRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.customerRow) As AddressBuilder
        _address1 = If(oRow.Iscustomer_address_1Null, "", oRow.customer_address_1)
        _address2 = If(oRow.Iscustomer_address_2Null, "", oRow.customer_address_2)
        _address3 = If(oRow.Iscustomer_address_3Null, "", oRow.customer_address_3)
        _address4 = If(oRow.Iscustomer_address_4Null, "", oRow.customer_address_4)
        _postcode = If(oRow.Iscustomer_postcodeNull, "", oRow.customer_postcode)
        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.supplierRow) As AddressBuilder
        _address1 = If(oRow.Issupplier_address_1Null, "", oRow.supplier_address_1)
        _address2 = If(oRow.Issupplier_address_2Null, "", oRow.supplier_address_2)
        _address3 = If(oRow.Issupplier_address_3Null, "", oRow.supplier_address_3)
        _address4 = If(oRow.Issupplier_address_4Null, "", oRow.supplier_address_4)
        _postcode = If(oRow.Issupplier_postcodeNull, "", oRow.supplier_postcode)
        Return Me
    End Function
    Public Function StartingWith(ByVal oRow As netwyrksDataSet.v_jobproductRow) As AddressBuilder
        _address1 = If(oRow.Issupplier_address_1Null, "", oRow.supplier_address_1)
        _address2 = If(oRow.Issupplier_address_2Null, "", oRow.supplier_address_2)
        _address3 = If(oRow.Issupplier_address_3Null, "", oRow.supplier_address_3)
        _address4 = If(oRow.Issupplier_address_4Null, "", oRow.supplier_address_4)
        _postcode = If(oRow.Issupplier_postcodeNull, "", oRow.supplier_postcode)
        Return Me
    End Function
    Public Function WithAddress1(ByVal Address1 As String) As AddressBuilder
        _address1 = Address1
        Return Me
    End Function
    Public Function WithAddress2(ByVal Address2 As String) As AddressBuilder
        _address2 = Address2
        Return Me
    End Function
    Public Function WithAddress3(ByVal Address3 As String) As AddressBuilder
        _address3 = Address3
        Return Me
    End Function
    Public Function WithAddress4(ByVal Address4 As String) As AddressBuilder
        _address4 = Address4
        Return Me
    End Function
    Public Function WithPostcode(ByVal Postcode As String) As AddressBuilder
        _postcode = Postcode
        Return Me
    End Function
    Public Function Build() As Address
        Return New Address(_address1,
                           _address2,
                           _address3,
                           _address4,
                           _postcode)
    End Function
End Class
