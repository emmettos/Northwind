using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public class NewOrderDto
{   
    public char? CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public short? EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public DateOnly? OrderDate { get; set; }
    public DateOnly? RequiredDate { get; set; }
    public DateOnly? ShippedDate { get; set; }
    public short? ShipVia { get; set; }
    public string? ShipViaName { get; set; }
    public decimal? FreightCost { get; set; }
    public string? ShipName { get; set; }
    public string? ShipAddress { get; set; }
    public string? ShipCity { get; set; }
    public string? ShipRegion { get; set; }
    public string? ShipPostalCode { get; set; }
    public string? ShipCountry { get; set; }

    public static Expression<Func<Order, OrderDto>> Projection
    {
        get
        {
            return o => new OrderDto()
            {
                Id = o.OrderId,
                CustomerId = o.CustomerId,
                CustomerName= o.Customer == null ? String.Empty : (o.Customer.CompanyName ?? String.Empty),
                EmployeeId = o.EmployeeId,
                EmployeeName = $"{(o.Employee == null ? String.Empty : (o.Employee.FirstName ?? String.Empty))} {(o.Employee == null ? String.Empty : (o.Employee.LastName ?? String.Empty))}", 
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                ShipVia = o.ShipVia,
                ShipViaName = (o.ShipViaNavigation == null ? String.Empty : (o.ShipViaNavigation.CompanyName ?? String.Empty)),
                FreightCost = Convert.ToDecimal(o.Freight),
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            };
        }
    }
}

public class OrderDto : NewOrderDto
{
    [Required]
    [Range(1, 999999999)]
    public short Id { get; set; }
}
