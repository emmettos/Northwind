using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public static class SupplierAdapters
{
    public static SupplierDto ToSupplierDto(this Supplier supplier)
    {
        return new SupplierDto
        { 
            Id = supplier.SupplierId, 
            CompanyName = supplier.CompanyName,
            ContactName = supplier.ContactName,
            ContactTitle = supplier.ContactTitle,
            Address = supplier.Address,
            City = supplier.City,
            Region = supplier.Region,
            PostalCode = supplier.PostalCode,
            Country = supplier.Country,
            Phone = supplier.Phone,
            Fax = supplier.Fax,
            Homepage = supplier.Homepage
        };
    }

    public static Supplier ToSupplier(this NewSupplierDto newSupplierDto)
    {
        return new Supplier
        { 
            CompanyName = newSupplierDto.CompanyName,
            ContactName = newSupplierDto.ContactName,
            ContactTitle = newSupplierDto.ContactTitle,
            Address = newSupplierDto.Address,
            City = newSupplierDto.City,
            Region = newSupplierDto.Region,
            PostalCode = newSupplierDto.PostalCode,
            Country = newSupplierDto.Country,
            Phone = newSupplierDto.Phone,
            Fax = newSupplierDto.Fax,
            Homepage = newSupplierDto.Homepage
        };
    }

    public static Supplier ToSupplier(this SupplierDto supplierDto)
    {
        return new Supplier
        { 
            SupplierId = supplierDto.Id!.Value,
            CompanyName = supplierDto.CompanyName,
            ContactName = supplierDto.ContactName,
            ContactTitle = supplierDto.ContactTitle,
            Address = supplierDto.Address,
            City = supplierDto.City,
            Region = supplierDto.Region,
            PostalCode = supplierDto.PostalCode,
            Country = supplierDto.Country,
            Phone = supplierDto.Phone,
            Fax = supplierDto.Fax,
            Homepage = supplierDto.Homepage
        };
    }
}