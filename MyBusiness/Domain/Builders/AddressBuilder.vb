' Hindleware
' Copyright (c) 2022-23 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports HindlewareLib.Domain
''' <summary>
''' Customer or shop address object builder  (see https://en.wikipedia.org/wiki/Builder_pattern)
''' </summary>
''' <remarks></remarks>
Public Class AddressBuilder
    Inherits Builders.AddressBuilder
    Public Overloads Shared Function AnAddress() As AddressBuilder
        Return New AddressBuilder
    End Function
    Public Overloads Function StartingWith(ByVal oRow As netwyrksDataSet.customerRow) As AddressBuilder
        WithAddress1(If(oRow.Iscustomer_address_1Null, "", oRow.customer_address_1))
        WithAddress2(If(oRow.Iscustomer_address_2Null, "", oRow.customer_address_2))
        WithAddress3(If(oRow.Iscustomer_address_3Null, "", oRow.customer_address_3))
        WithAddress4(If(oRow.Iscustomer_address_4Null, "", oRow.customer_address_4))
        WithPostcode(If(oRow.Iscustomer_postcodeNull, "", oRow.customer_postcode))
        Return Me
    End Function
    Public Overloads Function StartingWith(ByVal oRow As netwyrksDataSet.supplierRow) As AddressBuilder
        WithAddress1(If(oRow.Issupplier_address_1Null, "", oRow.supplier_address_1))
        WithAddress2(If(oRow.Issupplier_address_2Null, "", oRow.supplier_address_2))
        WithAddress3(If(oRow.Issupplier_address_3Null, "", oRow.supplier_address_3))
        WithAddress4(If(oRow.Issupplier_address_4Null, "", oRow.supplier_address_4))
        WithPostcode(If(oRow.Issupplier_postcodeNull, "", oRow.supplier_postcode))
        Return Me
    End Function
    Public Overloads Function StartingWith(ByVal oRow As netwyrksDataSet.v_jobproductRow) As AddressBuilder
        WithAddress1(If(oRow.Issupplier_address_1Null, "", oRow.supplier_address_1))
        WithAddress2(If(oRow.Issupplier_address_2Null, "", oRow.supplier_address_2))
        WithAddress3(If(oRow.Issupplier_address_3Null, "", oRow.supplier_address_3))
        WithAddress4(If(oRow.Issupplier_address_4Null, "", oRow.supplier_address_4))
        WithPostcode(If(oRow.Issupplier_postcodeNull, "", oRow.supplier_postcode))
        Return Me
    End Function
End Class
