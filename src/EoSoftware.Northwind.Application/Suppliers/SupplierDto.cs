using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class NewSupplierDto
{
    [Required]
    [StringLength(40, MinimumLength = 3)]
    public string CompanyName { get; set; } = null!;
    public string? ContactName { get; set; }
    public string? ContactTitle { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Homepage { get; set; }

    public static Expression<Func<Supplier, SupplierDto>> Projection
    {
        get
        {
            return s => new SupplierDto()
            {
                Id = s.SupplierId, 
                CompanyName = s.CompanyName,
                ContactName = s.ContactName,
                ContactTitle = s.ContactTitle,
                Address = s.Address,
                City = s.City,
                Region = s.Region,
                PostalCode = s.PostalCode,
                Country = s.Country,
                Phone = s.Phone,
                Fax = s.Fax,
                Homepage = s.Homepage
            };
        }
    }
}

public class SupplierDto : NewSupplierDto
{
    [Required]
    [Range(1, 999999999)]
    public short? Id { get; set; }
}
